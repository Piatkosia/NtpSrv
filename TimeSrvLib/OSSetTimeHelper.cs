using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TimeSrvLib
{
    public class OSSetTimeHelper
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetSystemTime(ref SYSTEMTIME st);
        //SetSystemTime(ref st); 
        public static SYSTEMTIME GetSystemTimeFromDateTime(DateTime localtime, bool isUtc = false)
        {
            if (!isUtc) localtime = localtime.ToUniversalTime();
            return new SYSTEMTIME
            {
                wYear = (short)localtime.Year,
                wMonth = (short)localtime.Month,
                wDayOfWeek = (short)localtime.DayOfWeek,
                wDay = (short)localtime.Day,
                wHour = (short)localtime.Hour,
                wMinute = (short)localtime.Minute,
                wSecond = (short)localtime.Second,
                wMilliseconds = (short)localtime.Millisecond,
            };
        }
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEMTIME
    {
        public short wYear;
        public short wMonth;
        public short wDayOfWeek;
        public short wDay;
        public short wHour;
        public short wMinute;
        public short wSecond;
        public short wMilliseconds;
    }
}
