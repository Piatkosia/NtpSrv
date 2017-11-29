using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TimeSrvLib
{
    class NetHelper
    {
        internal static IPAddress GetAddressFromString(string serverAddress, int which = 0)
        {
            IPAddress address = IPAddress.None;
            try
            {
                var addresses = Dns.GetHostEntry(serverAddress).AddressList;
                int addressesLength = addresses.Length;
                if (addressesLength > which)
                {
                    address = addresses[which];
                }
                else if (addressesLength > 0)
                {
                    address = addresses[addressesLength - 1];
                }
                return address;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.GetType().ToString() + ex.Message);
            }
            return address;
        }
    }
}
