using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSrvLib
{
    public class ConfigLoader
    {
        public Config Load(string ConfigPath, bool localfile = true)
        {
            Config config = null;
            if (localfile) config = LoadFromFile(ConfigPath);

            return config;


        }

        private Config LoadFromFile(string configPath)
        {
            if (!File.Exists(configPath)) throw new FileNotFoundException("File not found on local machine", configPath);
            if (configPath.EndsWith(".ini", StringComparison.InvariantCultureIgnoreCase)) throw new ArgumentException("Incorrect filetype");
            Config config = new Config();


            return config;


        }
    }
}
