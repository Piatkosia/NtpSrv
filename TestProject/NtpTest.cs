using System;
using System.Linq;
using TimeSrvLib;
using Xunit;

namespace TestProject
{
    public class NtpTest
    {
        [Fact]
        public void NtpWorks()
        {
            NTP ntp = new NTP();
            var tm = ntp.GetTimeFromHost("time.windows.com");
            Assert.Equal(tm.Year, 2017);

        }
    }
}
