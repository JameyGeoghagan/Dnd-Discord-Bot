using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDDiscordBot
{
   public class MonsterByName
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Speed
        {
            public string walk { get; set; }
            public string swim { get; set; }
        }

        public class Proficiency2
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Proficiency
        {
            public int value { get; set; }
            public Proficiency2 proficiency { get; set; }
        }

        public class Senses
        {
            public string darkvision { get; set; }
            public int passive_perception { get; set; }
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
            public int dc_value { get; set; }
            public string success_type { get; set; }
        }

        public class SpecialAbility
        {
            public string name { get; set; }
            public string desc { get; set; }
            public Dc dc { get; set; }
        }

        public class _0
        {
            public string name { get; set; }
            public int count { get; set; }
            public string type { get; set; }
        }

        public class From
        {
            public _0 _0 { get; set; }
        }

        public class Options
        {
            public int choose { get; set; }
            public List<From> from { get; set; }
        }

        public class DamageType
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Damage
        {
            public DamageType damage_type { get; set; }
            public string damage_dice { get; set; }
        }

        public class Usage
        {
            public string type { get; set; }
            public int times { get; set; }
        }

        public class Action
        {
            public string name { get; set; }
            public string desc { get; set; }
            public Options options { get; set; }
            public int? attack_bonus { get; set; }
            public Dc dc { get; set; }
            public List<Damage> damage { get; set; }
            public Usage usage { get; set; }
        }

        public class LegendaryAction
        {
            public string name { get; set; }
            public string desc { get; set; }
            public int? attack_bonus { get; set; }
            public List<Damage> damage { get; set; }
        }

        public class Root
        {
            public string index { get; set; }
            public string name { get; set; }
            public string size { get; set; }
            public string type { get; set; }
            public string alignment { get; set; }
            public int armor_class { get; set; }
            public int hit_points { get; set; }
            public string hit_dice { get; set; }
            public Speed speed { get; set; }
            public int strength { get; set; }
            public int dexterity { get; set; }
            public int constitution { get; set; }
            public int intelligence { get; set; }
            public int wisdom { get; set; }
            public int charisma { get; set; }
            public List<Proficiency> proficiencies { get; set; }
            public List<object> damage_vulnerabilities { get; set; }
            public List<object> damage_resistances { get; set; }
            public List<object> damage_immunities { get; set; }
            public List<object> condition_immunities { get; set; }
            public Senses senses { get; set; }
            public string languages { get; set; }
            public int challenge_rating { get; set; }
            public int xp { get; set; }
            public List<SpecialAbility> special_abilities { get; set; }
            public List<Action> actions { get; set; }
            public List<LegendaryAction> legendary_actions { get; set; }
            public string url { get; set; }
        }

    }
}
