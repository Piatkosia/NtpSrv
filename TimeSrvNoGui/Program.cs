using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSrvLib;

namespace TimeSrvNoGui
{
    class Program
    {
        static void Main(string[] args)
        {
            TimeRefresher refresher = new TimeRefresher();
            var IsSet = refresher.RefreshOSTime("time.windows.com"); //potem się pomyśli nad załadowaniem z zewnątrz
            if (IsSet) Console.WriteLine("Time is set as " + refresher.LastSet.ToString());
            else Console.WriteLine("Set time rejected");
            Console.ReadKey();
        }
    }
}
