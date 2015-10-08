using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var date = new DateTime(2015, 10, 5);
            var curQ = 0;

            for (Int32 i = 1; i <= 52; i++)
            {
                var newQ = date.GetQuarter();
                if(curQ != newQ)
                {
                    curQ = newQ;
                    Console.WriteLine($"I\\{date.Year}.{curQ:D2}|{date.GetQuarterStart().ToShortDateString()}|{date.GetQuarterEnd().ToShortDateString()}");
                }
                                
                Console.WriteLine($"I\\{date.Year}.{curQ:D2}\\{date.Year}.{curQ:D2}-{date.GetWeekNum():D2}|{date.ToShortDateString()}|{date.AddDays(6).ToShortDateString()}");
                date = date.AddDays(7);
            }
        }
    }

    public static class Extensions
    {
        private static Int32 GetQuarterStartMonth(Int32 month)
        {
            if (Enumerable.Range(1, 3).Contains(month)) { return 1; }
            if (Enumerable.Range(3, 3).Contains(month)) { return 3; }
            if (Enumerable.Range(6, 3).Contains(month)) { return 6; }
            if (Enumerable.Range(9, 3).Contains(month)) { return 9; }
            throw new IndexOutOfRangeException();
        }

        private static Int32 GetQuarterEndMonth(Int32 month)
        {
            if (Enumerable.Range(1, 3).Contains(month)) { return 3; }
            if (Enumerable.Range(3, 3).Contains(month)) { return 6; }
            if (Enumerable.Range(6, 3).Contains(month)) { return 9; }
            if (Enumerable.Range(9, 3).Contains(month)) { return 12; }
            throw new IndexOutOfRangeException();
        }

        public static DateTime GetQuarterStart(this DateTime date) => new DateTime(date.Year, GetQuarterStartMonth(date.Month), 1);
        public static DateTime GetQuarterEnd(this DateTime date) => new DateTime(date.Year, GetQuarterEndMonth(date.Month), 1).AddMonths(1).AddDays(-1);
        public static Int32 GetQuarter(this DateTime date) => DateAndTime.DatePart(DateInterval.Quarter, date, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1);
        public static Int32 GetWeekNum(this DateTime date) => DateAndTime.DatePart(DateInterval.WeekOfYear, date, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1);
    }
}
