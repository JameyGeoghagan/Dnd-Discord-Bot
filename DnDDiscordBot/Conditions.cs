using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDDiscordBot
{
   public class Conditions
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Root
        {
            public string index { get; set; }
            public string name { get; set; }
            public List<string> desc { get; set; }
            public string url { get; set; }
        }


    }
}
