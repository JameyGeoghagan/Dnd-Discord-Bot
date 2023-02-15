using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDDiscordBot
{
   public class SpellsByName
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class DamageType
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class DamageAtCharacterLevel
        {
            public string _1 { get; set; }
            public string _5 { get; set; }
            public string _11 { get; set; }
            public string _17 { get; set; }
        }

        public class Damage
        {
            public DamageType damage_type { get; set; }
            public DamageAtCharacterLevel damage_at_character_level { get; set; }
        }
        public class HealAtSlotLevel
        {
            public string _2 { get; set; }
            public string _3 { get; set; }
            public string _4 { get; set; }
            public string _5 { get; set; }
            public string _6 { get; set; }
            public string _7 { get; set; }
            public string _8 { get; set; }
            public string _9 { get; set; }
        }


        public class DcType
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Dc
        {
            public DcType dc_type { get; set; }
            public string dc_success { get; set; }
        }

        public class School
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Class
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Subclass
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Root
        {
            public string _id { get; set; }
            public List<object> higher_level { get; set; }
            public string index { get; set; }
            public string name { get; set; }
            public List<string> desc { get; set; }
            public string range { get; set; }
            public List<string> components { get; set; }
            public bool ritual { get; set; }
            public string duration { get; set; }
            public bool concentration { get; set; }
            public string casting_time { get; set; }
            public int level { get; set; }
            public string attack_type { get; set; }
            public Damage damage { get; set; }

            public Dc dc { get; set; }
            public School school { get; set; }
            public List<Class> classes { get; set; }
            public List<Subclass> subclasses { get; set; }
            public string url { get; set; }
            public HealAtSlotLevel heal_at_slot_level { get; set; }
        
        }


    }
}
