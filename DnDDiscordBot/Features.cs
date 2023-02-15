using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDDiscordBot
{
   public class Features
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Class
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Root
        {
            public string index { get; set; }
            public Class @class { get; set; }
            public string name { get; set; }
            public int level { get; set; }
            public List<object> prerequisites { get; set; }
            public List<string> desc { get; set; }
            public string url { get; set; }
        }


    }
}
