using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSign
{
    public class FileDescription
    {
        public string FileName { get; set; }
        public string Checksum { get; set; }

        public DateTime SignTime { get; set; }

        public string SyncFrom { get; set; } = "localhost";


    }
}
