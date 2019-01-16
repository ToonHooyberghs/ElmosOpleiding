using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsDemo
{
   
    public class LogLevel
    {
        public string Default { get; set; }
    }

    public class Logging
    {
        public LogLevel LogLevel { get; set; }
    }

    public class BeOneSettings
    {
        public int Version { get; set; }
        public string Url { get; set; }
    }

    public class BeOneGeneral
    {
        public Logging Logging { get; set; }
        public BeOneSettings BeOneSettings { get; set; }
        public string AllowedHosts { get; set; }
    }

}
