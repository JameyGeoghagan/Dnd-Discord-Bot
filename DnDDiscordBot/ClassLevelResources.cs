using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DnDDiscordBot
{
    public class ClassLevelResources
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Feature
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }
       
      
        public class Spellcasting
        {
            public int cantrips_known { get; set; }
            public int spells_known { get; set; }
            public int spell_slots_level_1 { get; set; }
            public int spell_slots_level_2 { get; set; }
            public int spell_slots_level_3 { get; set; }
            public int spell_slots_level_4 { get; set; }
            public int spell_slots_level_5 { get; set; }
            public int spell_slots_level_6 { get; set; }
            public int spell_slots_level_7 { get; set; }
            public int spell_slots_level_8 { get; set; }
            public int spell_slots_level_9 { get; set; }
            public int spell_slots_level_10 { get; set; }
            public int spell_slots_level_11 { get; set; }
            public int spell_slots_level_12 { get; set; }
            public int spell_slots_level_13 { get; set; }
            public int spell_slots_level_14 { get; set; }
            public int spell_slots_level_15 { get; set; }
            public int spell_slots_level_16 { get; set; }
            public int spell_slots_level_17 { get; set; }
            public int spell_slots_level_18 { get; set; }
            public int spell_slots_level_19 { get; set; }
            public int spell_slots_level_20 { get; set; }
        }
        public class MartialArts
        {
            public int dice_count { get; set; }
            public int dice_value { get; set; }
        }

     
    
        public class SneakAttack
        {
            public int dice_count { get; set; }
            public int dice_value { get; set; }
        }

     
        public class ClassSpecific
        {
            public int bardic_inspiration_die { get; set; }
            public int song_of_rest_die { get; set; }
            public int magical_secrets_max_5 { get; set; }
            public int magical_secrets_max_7 { get; set; }
            public int magical_secrets_max_9 { get; set; }
            //end of bard
            //Start of wizard
            public int arcane_recovery_levels { get; set; }
            //end of wizard
            //WarLock
            public int invocations_known { get; set; }
            public int mystic_arcanum_level_6 { get; set; }
            public int mystic_arcanum_level_7 { get; set; }
            public int mystic_arcanum_level_8 { get; set; }
            public int mystic_arcanum_level_9 { get; set; }
            //end of Warlock
            //Sorcerer
            public int sorcery_points { get; set; }
            public int metamagic_known { get; set; }
            public List<object> creating_spell_slots { get; set; }
            //Socerer
            //roug
            public SneakAttack sneak_attack { get; set; }
            //end rouge 
            //start ranger 
            public int favored_enemies { get; set; }
            public int favored_terrain { get; set; }
            //Monk 
            public MartialArts martial_arts { get; set; }
            public int ki_points { get; set; }
            public int unarmored_movement { get; set; }
            //end
            // FIghter 
            public int action_surges { get; set; }
            public int indomitable_uses { get; set; }
            public int extra_attacks { get; set; }
            //end 
            //Barbairan
            public int rage_count { get; set; }
            public int rage_damage_bonus { get; set; }
            public int brutal_critical_dice { get; set; }
            //end of barb
            //Druid
            public int wild_shape_max_cr { get; set; }
            public bool wild_shape_swim { get; set; }
            public bool wild_shape_fly { get; set; }
            //end
            //Clar
            public int channel_divinity_charges { get; set; }
            public int destroy_undead_cr { get; set; }
            public int aura_range { get; set; }


        }



        public class Class
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }
     
        public class Root
        {
          
            public int level { get; set; }
            public int ability_score_bonuses { get; set; }
            public int prof_bonus { get; set; }
            public List<Feature> features { get; set; }
            
       
            public Spellcasting spellcasting { get; set; }

            public ClassSpecific class_specific { get; set; }

            public string index { get; set; }
         
            public string url { get; set; }
        }


    }
}
