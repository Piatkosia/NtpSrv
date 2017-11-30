using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSrvLib
{
    public class TimeRefresher
    {
        public DateTime LastSet = DateTime.MinValue;
        public bool RefreshOSTime(string serverPath)
        {
            NTP ntp = new NTP();
            LastSet = ntp.GetTimeFromHost(serverPath);
            var dt = OSSetTimeHelper.GetSystemTimeFromDateTime(LastSet);
            return OSSetTimeHelper.SetSystemTime(ref dt);

        }
    }
}
