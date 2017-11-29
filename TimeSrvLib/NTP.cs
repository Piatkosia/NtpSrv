using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TimeSrvLib
{
    public class NTP
    {
        public bool SetFromLocal = false;
        public DateTime GetTimeFromHost(string serverAddress)
        {
            //protocol's definition
            var ntpData = new byte[48];
            ntpData[0] = 0x1B;
            IPAddress addr = NetHelper.GetAddressFromString(serverAddress);
            if (addr == IPAddress.None)
            {
                SetFromLocal = true;
                return DateTime.Now;
            }
            GetDataFromServer(ntpData, addr);
            DateTime newTime = GetDateTimeFromData(ntpData);
            return newTime;

        }

        private DateTime GetDateTimeFromData(byte[] ntpData)
        {
            const byte serverReplyTime = 40;
            ulong intPart = BitConverter.ToUInt32(ntpData, serverReplyTime);
            ulong fractPart = BitConverter.ToUInt32(ntpData, serverReplyTime + 4);
            intPart = MachineHelper.SwapEndianness(intPart);
            fractPart = MachineHelper.SwapEndianness(fractPart);
            var milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);
            var networkDateTime = (new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddMilliseconds((long)milliseconds);
            SetFromLocal = false;
            return networkDateTime.ToLocalTime();
        }

        private static void GetDataFromServer(byte[] ntpData, IPAddress addr)
        {
            var ipEndPoint = new IPEndPoint(addr, 123);
            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
            {
                socket.Connect(ipEndPoint);
                socket.ReceiveTimeout = 3000;
                socket.Send(ntpData);
                socket.Receive(ntpData);
                socket.Close();
            }
        }
    }
}
