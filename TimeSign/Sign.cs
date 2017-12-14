using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TimeSrvLib;
using System.Security.Cryptography;

namespace TimeSign
{
    class Sign
    {
        /// <summary>
        /// Zwraca opis pliku pozwalający na zweryfikowanie czasu
        /// </summary>
        /// <param name="path">ścieżka lokalna do pliku do podpisania</param>
        /// <returns>ścieżka dostępu do podpisu danego pliku</returns>
        public FileDescription TagLocalFile(string path)
        {
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentException("We have no path:(");
            if (!File.Exists(path)) throw new FileNotFoundException("We have no " + path + "on local machine", path);
            FileDescription description = new FileDescription();
            TimeRefresher refresher = new TimeRefresher();
            DateTime tm = DateTime.Now;
            string ServerPath = "time.windows.com"; //potem się z configa pociągnie
            var IsSet = refresher.RefreshOSTime(ServerPath);
            if (IsSet)
            {
                description.SyncFrom = ServerPath;
                tm = refresher.LastSet;
            }
            description.SignTime = tm;
            description.FileName = path;
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(path))
                {
                    var hash = md5.ComputeHash(stream);
                    description.Checksum = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
            return description;
        }
    }
}
