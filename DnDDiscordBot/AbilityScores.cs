using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDDiscordBot
{
    public class AbilityScores
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Skill
        {
            public string name { get; set; }
            public string index { get; set; }
            public string url { get; set; }
        }

        public class Root
        {
            public string index { get; set; }
            public string name { get; set; }
            public string full_name { get; set; }
            public List<string> desc { get; set; }
            public List<Skill> skills { get; set; }
            public string url { get; set; }
        }

    }
}
