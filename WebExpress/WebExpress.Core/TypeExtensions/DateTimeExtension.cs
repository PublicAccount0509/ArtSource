using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExpress.Core
{
    public static class DateTimeExtension
    {
        public static DateTime EndOfDay(this DateTime dt)
        {
            return DateTime.Parse(dt.ToShortDateString().Trim() + " 23:59:59");
        }

        public static DateTime BeginOfDay(this DateTime dt)
        {
            return DateTime.Parse(dt.ToShortDateString().Trim() + " 00:00:00");
        }

        public static string ToGeneralString(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd hh:mm:ss");
        }
    }
}
