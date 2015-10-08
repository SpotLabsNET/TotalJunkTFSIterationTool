using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using Microsoft.TeamFoundation.Server;
using System.Net;
using Microsoft.TeamFoundation.ProcessConfiguration.Client;
using System.Linq;
using System.Xml;

namespace AreaImportExportTool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            chkIterationStructure_CheckedChanged(this, EventArgs.Empty);

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private void chkIterationStructure_CheckedChanged(object sender, EventArgs e)
        {
            cmdExport.Enabled = cmdImport.Enabled =
                (chkAreaStructure.Checked || chkIterationStructure.Checked) &&
                (!(String.IsNullOrEmpty(txtCollectionUri.Text) ||
                txtCollectionUri.Text.Trim().Length == 0) ||
                !Uri.IsWellFormedUriString(txtCollectionUri.Text, UriKind.Absolute)) &&
                (!(String.IsNullOrEmpty(txtTeamProject.Text) ||
                txtTeamProject.Text.Trim().Length == 0));
        }

        private void cmdExport_Click(object sender, EventArgs e)
        {
            Uri collectionUri = new Uri(txtCollectionUri.Text);
            string teamProject = txtTeamProject.Text;

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.CheckPathExists = true;
            dlg.Title = "Export Area/Iteration structure";
            dlg.DefaultExt = ".nodes";
            dlg.Filter = "TFS Node Structure (*.nodes)|*.nodes";
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                string filename = dlg.FileName;

                var networkCredential = new NetworkCredential("username", "password");
                var basicAuthCredential = new BasicAuthCredential(networkCredential);
                var tfsCredential = new TfsClientCredentials(basicAuthCredential);

                using(var tfs = new TfsTeamProjectCollection(collectionUri, tfsCredential))
                //using (var tfs = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(collectionUri))
                using (WaitState waitState = new WaitState(this))
                {
                    tfs.Authenticate();
                    tfs.EnsureAuthenticated();

                    //  get the configuration server
                    var svr = tfs.ConfigurationServer;
                   
                    //  get the configuration service                    
                    var svc = tfs.GetService<TeamSettingsConfigurationService>();

                    // get the common structure service
                    var css = tfs.GetService<ICommonStructureService4>();

                    //  get the spotlabs project
                    var prj = css.GetProjectFromName(txtTeamProject.Text);

                    //  get the configurations
                    var cfg = svc.GetTeamConfigurationsForUser(new[] { prj.Uri }).Single<TeamConfiguration>();

                    //  get the settings
                    var opt = cfg.TeamSettings;

                    //  get the iteration schedule
                    var schedule = css.GetIterationDates(prj.Uri);

                    Console.WriteLine(opt.ToString());

                    var store = (WorkItemStore)tfs.GetService(typeof(WorkItemStore));
                    var proj = store.Projects[teamProject];

                    using (FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write))
                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        writer.WriteLine("NODES");
                        writer.WriteLine(String.Format("{0}, Version {1}", Application.ProductName, Application.ProductVersion));
                        writer.WriteLine("Copyright (C) 2010 " + Application.CompanyName);

                        if (chkAreaStructure.Checked)
                        {
                            WriteNodes(proj.AreaRootNodes, writer, "A");
                        }

                        if (chkIterationStructure.Checked)
                        {
                            WriteNodes(proj.IterationRootNodes, writer, "I");
                        }

                        writer.Close();
                    }
                }

                MessageBox.Show("Export successful.");
            }
        }


        private static void WriteNodes(NodeCollection nodes, StreamWriter writer, string prefix)
        {
            foreach (Node node in nodes)
            {
                writer.Write(prefix);
                writer.WriteLine(node.Path.Substring(node.Path.IndexOf(@"\")));

                if (node.ChildNodes.Count > 0)
                {
                    WriteNodes(node.ChildNodes, writer, prefix);
                }
            }
        }

        private void cmdImport_Click(object sender, EventArgs e)
        {
            Uri collectionUri = new Uri(txtCollectionUri.Text);
            string teamProject = txtTeamProject.Text;

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.CheckFileExists = true;
            dlg.Title = "Import Area/Iteration structure";
            dlg.DefaultExt = ".nodes";
            dlg.Filter = "TFS Node Structure (*.nodes)|*.nodes";
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                string filename = dlg.FileName;

                var networkCredential = new NetworkCredential("username", "password");
                var basicAuthCredential = new BasicAuthCredential(networkCredential);
                var tfsCredential = new TfsClientCredentials(basicAuthCredential);
                using (var tfs = new TfsTeamProjectCollection(collectionUri, tfsCredential))
                //using (var tfs = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(collectionUri, new UICredentialsProvider()))
                using (WaitState waitState = new WaitState(this))
                {
                    tfs.Authenticate();
                    tfs.EnsureAuthenticated();

                    WorkItemStore store = (WorkItemStore)tfs.GetService(typeof(WorkItemStore));
                    Project proj = store.Projects[teamProject];

                    NodeInfo rootAreaNode = null;
                    NodeInfo rootIterationNode = null;

                    var css = (ICommonStructureService4)tfs.GetService(typeof(ICommonStructureService4));
                    foreach (NodeInfo info in css.ListStructures(proj.Uri.ToString()))
                    {
                        if (info.StructureType == "ProjectModelHierarchy")
                        {
                            rootAreaNode = info;
                        }
                        else if (info.StructureType == "ProjectLifecycle")
                        {
                            rootIterationNode = info;
                        }
                    }

                    using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
                    using (StreamReader reader = new StreamReader(fs))
                    {
                        string nextLine = reader.ReadLine();
                        if (nextLine != "NODES")
                        {
                            MessageBox.Show("Wrong file format!");
                            return;
                        }

                        reader.ReadLine();
                        reader.ReadLine();

                        while (!reader.EndOfStream)
                        {
                            nextLine = reader.ReadLine();
                            if (nextLine.StartsWith("A") && chkAreaStructure.Checked)
                            {
                                CreateNode(css, nextLine.Substring(2), rootAreaNode);
                            }
                            else if (nextLine.StartsWith("I") && chkIterationStructure.Checked)
                            {
                                CreateNode(css, nextLine.Substring(2), rootIterationNode);
                            }
                            else
                            { // Ignore other lines
                            }
                        }
                        reader.Close();
                    }

                    MessageBox.Show("Import successful.");
                }
            }
        }

        private void CreateNode(ICommonStructureService4 css, string nodeName, NodeInfo rootNode)
        {
            char _delimeter = '|';

            var name = String.Empty;
            DateTime? startDate = null;
            DateTime? endDate = null;

            if (nodeName.Contains(_delimeter))
            {
                var parts = nodeName.Split(_delimeter);

                name = parts[0];
                startDate = DateTime.Parse(parts[1]);
                endDate = DateTime.Parse(parts[2]);
            }
            else
            {
                name = nodeName;
            }

            if (!name.Contains("\\"))
            {
                try
                {
                    var iterationUri = css.CreateNode(name, rootNode.Uri);
                    css.SetIterationDates(iterationUri, startDate, endDate);
                }
                catch(Exception ex) when (ex.ToString().Contains("TF200020"))
                {
                    Console.WriteLine("Node Exists. Skipping...");
                }
            }
            else
            {
                int lastBackslash = name.LastIndexOf("\\");
                NodeInfo info = css.GetNodeFromPath(rootNode.Path + "\\" + name.Substring(0, lastBackslash));
                var iterationUri = css.CreateNode(name.Substring(lastBackslash + 1), info.Uri);
                css.SetIterationDates(iterationUri, startDate, endDate);
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private class WaitState : IDisposable
        {
            private Form parent;

            public WaitState(Form parent)
            {
                parent.Cursor = Cursors.WaitCursor;
                parent.Enabled = false;
                this.parent = parent;
            }

            void IDisposable.Dispose()
            {
                parent.Cursor = Cursors.Default;
                parent.Enabled = true;
            }
        }
    }
}