using System;

namespace AreaImportExportTool
{
    internal class ScheduleInfo
    {
        public String StoragePath { get; set; } = string.Empty;
        public String DisplayPath { get; set; } = String.Empty;
        public DateTime? StartDate { get; set; } = null;
        public DateTime? EndDate { get; set; } = null;        
    }
}