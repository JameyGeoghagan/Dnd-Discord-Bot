using Discord;
using Discord.Commands;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DnDDiscordBot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        private readonly CommandService _service;
    

        public Commands(CommandService service)
        {
            _service = service;
         
        }

        [Command("commands")]
        public async Task HelpAsync()
        {
            string prefix = "!";
            var builder = new EmbedBuilder()
            {
                Color = new Color(114, 137, 218),
                Description = "These are the commands you can use"
            };

            foreach (var module in _service.Modules)
            {
                string description = null;
                foreach (var cmd in module.Commands)
                {
                    var result = await cmd.CheckPreconditionsAsync(Context);
                    if (result.IsSuccess)
                        description += $"{prefix}{cmd.Aliases.First()}\n";
                }

                if (!string.IsNullOrWhiteSpace(description))
                {
                    builder.AddField(x =>
                    {
                        x.Name = module.Name;
                        x.Value = description;
                        x.IsInline = false;
                    });
                }
            }

            await ReplyAsync("", false, builder.Build());
        }



        [Command("listclass")]
        [Summary("Gets a list of classes")]
        public async Task ClassList()
        {
            var client = new HttpClient();
            var spellsURL = ($"https://www.dnd5eapi.co/api/classes");
            var spellsResponse = client.GetStringAsync(spellsURL).Result;

            ClassList.Root myDeserializedClass = JsonConvert.DeserializeObject<ClassList.Root>(spellsResponse);

            ClassList.Root spellList = new ClassList.Root();
            spellList.results = myDeserializedClass.results;
            foreach (var item in spellList.results)
            {
                await ReplyAsync($"Name-=====> {item.name}, ");
            }

        }

        [Command("dnd")]
        [Summary("Gets info on a DND class")]
        public async Task classbyName([Remainder] string insClass)
        {
            var dndClas = insClass.ToLower();
            try
            {
                var client = new HttpClient();
                var conByNameURL = ($"https://www.dnd5eapi.co/api/classes/{dndClas}");
                var conByNameResponse = client.GetStringAsync(conByNameURL).Result;
                DND5eClass.Root myDeserializedClass = JsonConvert.DeserializeObject<DND5eClass.Root>(conByNameResponse);

                DND5eClass.Root response = new DND5eClass.Root();
                response.class_levels = myDeserializedClass.class_levels;
                response.hit_die = myDeserializedClass.hit_die;
                response.index = myDeserializedClass.index;
                response.multi_classing = myDeserializedClass.multi_classing;
                response.name = myDeserializedClass.name;
                response.proficiencies = myDeserializedClass.proficiencies;
                response.proficiency_choices = myDeserializedClass.proficiency_choices;
                response.saving_throws = myDeserializedClass.saving_throws;
                response.starting_equipment = myDeserializedClass.starting_equipment;
                response.starting_equipment_options = myDeserializedClass.starting_equipment_options;
                response.subclasses = myDeserializedClass.subclasses;
                response.url = myDeserializedClass.url;

                await ReplyAsync($"Class -===> {response.name},    Hit Die: {response.hit_die}");
                await ReplyAsync("------------------------------------------");
                await ReplyAsync("Proficiency Choices:");
                foreach (var item in response.proficiency_choices)
                {
                    await ReplyAsync($"Choose: {item.choose}");
                    await ReplyAsync("------------------------------------------");
                    await ReplyAsync($"Type: {item.type}");
                    await ReplyAsync("------------------------------------------");
                    foreach (var x in item.from)
                    {
                        await ReplyAsync($"Name:--==> {x.name}");
                    }
                    await ReplyAsync("------------------------------------------");
                }
                await ReplyAsync($"{response.name} are Proficiency with: ");
                foreach (var item in response.proficiencies)
                {
                    await ReplyAsync($"{item.name}");
                }
                await ReplyAsync("------------------------------------------");
                await ReplyAsync($"{response.name} saving throws: ");
                foreach (var item in response.saving_throws)
                {
                    await ReplyAsync($"{item.name}");
                }
                await ReplyAsync("------------------------------------------");
                await ReplyAsync($"{response.name} starting equimpent: ");
                foreach (var item in response.starting_equipment)
                {
                    var toshow = "";
                    await ReplyAsync($"equipment:");
                    foreach (var x in item.equipment.name)
                    {
                        toshow += x.ToString();                       
                    }
                    await ReplyAsync($"Name ==> {toshow},   Quantity: {item.quantity}");

                }
                await ReplyAsync("Let me know if you want more equimpent!");
                await ReplyAsync("------------------------------------------");
                await ReplyAsync($"Multi Classing with a {response.name}");
                await ReplyAsync("------------------------------------------");
                await ReplyAsync("Prerequisites: ");
                foreach (var item in response.multi_classing.prerequisites)
                {
                    var toShow = " ";
                    foreach (var x in item.ability_score.name)
                    {
                        toShow += x.ToString();
                    }
                    await ReplyAsync($"Ability Score: {toShow}, ----------Minimim Score needed is {item.minimum_score}");
                }
                await ReplyAsync($"Multi Classing with a {response.name}, you will be proficienct with: ");
                foreach (var item in response.multi_classing.proficiencies)
                {
                    await ReplyAsync($"==> {item.name}");
                }
                await ReplyAsync("------------------------------------------");
                foreach (var item in response.subclasses)
                {
                    await ReplyAsync($"Subclass ========> {item.name}");
                }

            }
            catch
            {
                await ReplyAsync("Nop that didt go the way we wanted, you good? Mby you should roll another? hopefully you can get it rught this time!! Try one more time check the spelling of what your trying to see");
                await ReplyAsync("Its also a posibilty hat I do not have this information yet! But i might have it soon!");
            }
        }
        // end of class by name 

        [Command("classspell")]
        [Summary("Get spells available for a class")]
        public async Task ClassSpellList([Remainder] string userIn)
        {
            string use = userIn.ToLower();
            if (use == "barbarian")
            {
                await ReplyAsync("If you think a barbarian needs to use spells all i have to say to you is... ┌П┐(▀̿Ĺ̯▀̿)");
            }
            else if (use == "fighter")
            {
                await ReplyAsync("No No NO , that would be just wrong a fighter useing spells, mby if your multiclassing? but fighters are not spellcasters");
            }
            else if (use == "monk")
            {
                await ReplyAsync("im going to have to use my inner monk, so im just going to tell you in a nice calm voice, monks are not spellcasters ");
            }
            else if (use == "rogue")
            {
                await ReplyAsync("Well look at that who would of thought that rogues were not spellcasters! The more you know!");
                await ReplyAsync("!dndmeme");
            }
            else
            {
                try
                {
                    var client = new HttpClient();
                    var spellsURL = ($"https://www.dnd5eapi.co/api/classes/{use}/spells");
                    var spellsResponse = client.GetStringAsync(spellsURL).Result;

                    ClassSpellList.Root myDeserializedClass = JsonConvert.DeserializeObject<ClassSpellList.Root>(spellsResponse);

                    ClassSpellList.Root spellList = new ClassSpellList.Root();
                    spellList.results = myDeserializedClass.results;
                    await ReplyAsync($"This is a list of spell available for a {userIn}");
                    foreach (var item in spellList.results)
                    {
                        await ReplyAsync($"Name--====> {item.name}, ");
                    }

                }
                catch
                {
                    await ReplyAsync("Well something didnt go right, check you spelling and try one more time!");
                }
            }

        }
        //end of list of spells for a class

        [Command("classfeature")]
        [Summary("Get features available for a class")]
        public async Task ClassFeaturesList([Remainder] string userIn)
        {
            string use = userIn.ToLower();

            try
            {
                var client = new HttpClient();
                var spellsURL = ($"https://www.dnd5eapi.co/api/classes/{use}/features");
                var spellsResponse = client.GetStringAsync(spellsURL).Result;

                ClassFeaturesList.Root myDeserializedClass = JsonConvert.DeserializeObject<ClassFeaturesList.Root>(spellsResponse);

                ClassFeaturesList.Root spellList = new ClassFeaturesList.Root();
                spellList.results = myDeserializedClass.results;
                //await ReplyAsync($"This is a list of features available for a {userIn}");
                //foreach (var item in spellList.results)
                //{
                //    await ReplyAsync($"Name--====> {item.name}, ");

                string feats = " ";
                foreach (var item in spellList.results)
                {
                    feats = ($"{item.name}, ");
                }

                var builder = new EmbedBuilder
                {
                    Color = new Color(114, 137, 218),
                    Title = $"{userIn} Features",
                    Description = $"This is a list of features for a {userIn}"
                };
                string description = null;

                builder.AddField(x =>
                {
                    x.Name = "Features";
                        foreach (var module in myDeserializedClass.results)
                {
                 
                    foreach (var cmd in module.name)
                    {
                        var result = cmd;
                        if (result != 0)
                        {
                            description += $"{cmd}";
                        }
                    }                                  
                }
                    x.Value = $"|-{description}-|";
                    x.IsInline = true;
                });
            
               
                await ReplyAsync("", false, builder.Build());
            } 
            catch
            {
                await ReplyAsync("Well something didnt go right, check you spelling and try one more time!");
            }
        }

        //end of class features 
        [Command("classlevel")]
        [Summary("Get features available for a class")]
        public async Task ClassLevelList([Remainder] string userIn)
        {
            string use = userIn.ToLower();

            try
            {
                var client = new HttpClient();
                var spellsURL = ($"https://www.dnd5eapi.co/api/classes/{use}/levels");
                var spellsResponse = client.GetStringAsync(spellsURL).Result;
                ClassLevelResources.Root myDeserializedClass = new ClassLevelResources.Root();
             

                var jsonresponse = JsonConvert.DeserializeObject<List<ClassLevelResources.Root>>(spellsResponse);
                foreach (var item in jsonresponse)
                {
                    //bard.bardic_inspiration_die = item.class_specificBard.bardic_inspiration_die;
                    myDeserializedClass.ability_score_bonuses = item.ability_score_bonuses;
                    myDeserializedClass.class_specific = item.class_specific;
                    myDeserializedClass.features = item.features;
                    myDeserializedClass.index = item.index;
                    myDeserializedClass.level = item.level;
                    myDeserializedClass.prof_bonus = item.prof_bonus;
                    myDeserializedClass.spellcasting = item.spellcasting;
                    myDeserializedClass.url = item.url;
                }

                


           
                await ReplyAsync($"Leveling for a {userIn}");
                foreach (var item in jsonresponse)
                {
                    await ReplyAsync($"Level: {item.level} |         | Prof Bonus: {item.prof_bonus}");
                    await ReplyAsync("-----------------------------------------------------");
                    await ReplyAsync($"Features: ");
                    foreach (var x in item.features)
                    {
                        await ReplyAsync($"Name: --=> {x.name}");
                    }
                    await ReplyAsync("-----------------------------------------------------");
                    if (item.spellcasting != null)
                    {
                           await ReplyAsync($"Cantrips Known: {item.spellcasting.cantrips_known}");
                           await ReplyAsync($"Spells Known: {item.spellcasting.spells_known}");
                  

                        if (item.spellcasting.spell_slots_level_1 != 0) { await ReplyAsync($"Spell Slots Level 1: {item.spellcasting.spell_slots_level_1}"); }
                        if (item.spellcasting.spell_slots_level_2 != 0) { await ReplyAsync($"Spell Slots Level 2: {item.spellcasting.spell_slots_level_2}"); }
                        if (item.spellcasting.spell_slots_level_3 != 0) { await ReplyAsync($"Spell Slots Level 3: {item.spellcasting.spell_slots_level_3}"); }
                        if (item.spellcasting.spell_slots_level_4 != 0) { await ReplyAsync($"Spell Slots Level 4: {item.spellcasting.spell_slots_level_4}"); }
                        if (item.spellcasting.spell_slots_level_5 != 0) { await ReplyAsync($"Spell Slots Level 5: {item.spellcasting.spell_slots_level_5}"); }
                        if (item.spellcasting.spell_slots_level_6 != 0) { await ReplyAsync($"Spell Slots Level 6: {item.spellcasting.spell_slots_level_6}"); }
                        if (item.spellcasting.spell_slots_level_7 != 0) { await ReplyAsync($"Spell Slots Level 7: {item.spellcasting.spell_slots_level_7}"); }
                        if (item.spellcasting.spell_slots_level_8 != 0) { await ReplyAsync($"Spell Slots Level 8: {item.spellcasting.spell_slots_level_8}"); }
                        if (item.spellcasting.spell_slots_level_9 != 0) { await ReplyAsync($"Spell Slots Level 9: {item.spellcasting.spell_slots_level_9}"); }
                        await ReplyAsync("-----------------------------------------------------");

                    }
                    if (use == "bard")
                    {
                        await ReplyAsync($"{userIn} Specific:");
                       
                        await ReplyAsync($"Bard Inspiration Die: {item.class_specific.bardic_inspiration_die}, Song of rest Die: { item.class_specific.song_of_rest_die}");
                        if (item.class_specific.magical_secrets_max_5 != 0) { await ReplyAsync($"Magical Secrets Max 5: {item.class_specific.magical_secrets_max_5}"); }
                        if (item.class_specific.magical_secrets_max_7 != 0) { await ReplyAsync($"Magical Secrets Max 7: {item.class_specific.magical_secrets_max_5}"); }
                        if (item.class_specific.magical_secrets_max_9 != 0) { await ReplyAsync($"Magical Secrets Max 9: {item.class_specific.magical_secrets_max_5}"); }
                        await ReplyAsync("-----------------------------------------------------");
                    }
                    else if (use == "barbarian")
                    {
                        await ReplyAsync($"{userIn} Specific:");
                        await ReplyAsync($" Rage Count: {item.class_specific.rage_count.ToString()}");
                        await ReplyAsync($" Rage Damage Bounus: {item.class_specific.rage_damage_bonus.ToString()} ");
                        await ReplyAsync($" Brutal Critical Dice: {item.class_specific.brutal_critical_dice}");
                    }
                    else if (use == "cleric")
                    {
                        await ReplyAsync($"{userIn} Specific:");
                        await ReplyAsync($"Channel Divinity Charged: {item.class_specific.destroy_undead_cr}");
                        await ReplyAsync($"Destroy Undead CR: {item.class_specific.destroy_undead_cr}");

                    }
                    else if (use == "druid")
                    {
                        await ReplyAsync($"{userIn} Specific:");
                        await ReplyAsync($"Wild Shape Max CR: {item.class_specific.wild_shape_max_cr}");
                        if (item.class_specific.wild_shape_fly == false)
                        {
                            await ReplyAsync($"Wild Shape Fly = false");
                        }
                        else
                        {
                            await ReplyAsync($"Wild Shape Fly = true");
                        }
                        if (item.class_specific.wild_shape_swim == false)
                        {
                            await ReplyAsync($"Wild Shape Swim = false");
                        }
                        else
                        {
                            await ReplyAsync($"Wild Shape Swim = true");
                        }
                    }
                    else if (use == "fighter")
                    {
                        await ReplyAsync($"Extra Attacks: {item.class_specific.extra_attacks}");
                        await ReplyAsync($"Action Surges: {item.class_specific.action_surges}");
                        await ReplyAsync($"Indomitable Uses: {item.class_specific.indomitable_uses}");
                    }
                    else if (use == "monk")
                    {
                        await ReplyAsync($"Ki Points: {item.class_specific.ki_points}");
                        await ReplyAsync($"Dice Count: {item.class_specific.martial_arts.dice_count}");
                        await ReplyAsync($"Dice Value: {item.class_specific.martial_arts.dice_value}");
                        await ReplyAsync($"Unarmored Movement: {item.class_specific.unarmored_movement}");
                    }
                    else if (use == "paladin")
                    {
                        await ReplyAsync($"Aura Range: {item.class_specific.aura_range}");

                    }
                    else if (use == "ranger")
                    {
                        await ReplyAsync($"Favored Enemies: {item.class_specific.favored_enemies}");
                        await ReplyAsync($"Favored Terrain: {item.class_specific.favored_terrain}");
                    }
                    else if (use == "rogue")
                    {
                        await ReplyAsync($"Sneak Attack: {item.class_specific.sneak_attack}");

                    }
                    else if (use == "sorcerer")
                    {
                        await ReplyAsync($"Creating Spell Slots: {item.class_specific.creating_spell_slots}");
                        await ReplyAsync($"Metamagic Known: {item.class_specific.metamagic_known}");
                        await ReplyAsync($"Sorcery: {item.class_specific.sorcery_points}");
                    }
                    else if (use == "warlock")
                    {
                        await ReplyAsync($"Invocations Known: {item.class_specific.invocations_known}");
                        await ReplyAsync($"Mystic Arcamum Level 6: {item.class_specific.mystic_arcanum_level_6}");
                        await ReplyAsync($"Mystic Arcamum Level 7: {item.class_specific.mystic_arcanum_level_7}");
                        await ReplyAsync($"Mystic Arcamum Level 8: {item.class_specific.mystic_arcanum_level_8}");
                        await ReplyAsync($"Mystic Arcamum Level 9: {item.class_specific.mystic_arcanum_level_9}");

                    }
                    else if (use == "wizard")
                    {
                        await ReplyAsync($"Arcane Recover Levels: {item.class_specific.arcane_recovery_levels}");
                    }
                }
               
                
              
               




            }
            catch
            {

                await ReplyAsync($"Still building this command my bad my guys");
                var Error = new MyException();
                await ReplyAsync(Error.StackTrace);



            }
        }




        [Command("listspell")]
        [Summary("Gets a list of spells")]
        public async Task SpellList()
        {
            var client = new HttpClient();
            var spellsURL = ($"https://www.dnd5eapi.co/api/spells");
            var spellsResponse = client.GetStringAsync(spellsURL).Result;

            SpellList.Root myDeserializedClass = JsonConvert.DeserializeObject<SpellList.Root>(spellsResponse);

            SpellList.Root spellList = new SpellList.Root();
            spellList.results = myDeserializedClass.results;
            await ReplyAsync($"There is a total of {spellList.count} spells in the api ");
            foreach (var item in spellList.results)
            {
                await ReplyAsync($"Name--====> {item.name}, ");
            }

        }

        [Command("spell")]
        [Summary("Gets a spell by name")]
        public async Task SpellByName([Remainder] string spell)
        {
            string spellToUse = spell.ToLower().Replace(" ", "-");
            try
            {
                var client = new HttpClient();
                var spellByNameURL = ($"https://www.dnd5eapi.co/api/spells/{spellToUse}");
                var spellByNameResponse = client.GetStringAsync(spellByNameURL).Result;


                SpellsByName.Root myDeserializedClass = JsonConvert.DeserializeObject<SpellsByName.Root>(spellByNameResponse);

                SpellsByName.Root spellByName = new SpellsByName.Root();

                spellByName.attack_type = myDeserializedClass.attack_type;
                spellByName.casting_time = myDeserializedClass.casting_time;
                spellByName.damage = myDeserializedClass.damage;
                spellByName.desc = myDeserializedClass.desc;
                spellByName.duration = myDeserializedClass.duration;
                spellByName.higher_level = myDeserializedClass.higher_level;
                spellByName.level = myDeserializedClass.level;
                spellByName.name = myDeserializedClass.name;
                spellByName.range = myDeserializedClass.range;
                spellByName.ritual = myDeserializedClass.ritual;
                spellByName.school = myDeserializedClass.school;
                spellByName.classes = myDeserializedClass.classes;
                spellByName.heal_at_slot_level = myDeserializedClass.heal_at_slot_level;


                var school = "";
                foreach (var item in spellByName.school.name)
                {

                    school += item.ToString();

                }
                var descrip = " ";
                if (myDeserializedClass.desc.Count() != 0)
                {
                    foreach (var item in myDeserializedClass.desc)
                    {
                        descrip = item;
                    }
                }

                var builder = new EmbedBuilder
                {
                    Color = new Color(114, 137, 218),
                    Title = myDeserializedClass.name,
                    Description = descrip
                };
                builder.AddField(x =>
                {
                    x.Name = $"School";
                    x.Value = school;
                });
                builder.AddField(x =>
                {
                    x.Name = $"Class";
                    foreach (var item in spellByName.classes)
                    {
                        x.Value = ($"{item.name} ");
                    }

                });
                builder.AddField(x =>
                {
                    x.Name = "Casting Time and Duration";
                    x.Value = $"Casting time: {spellByName.casting_time}, Duration: { spellByName.duration}";
                });

                if (spellByName.attack_type != null)
                {
                    builder.AddField(x =>
                    {
                        x.Name = "Attack Type";
                        x.Value = spellByName.attack_type;

                    });
                }
                if (spellByName.concentration == false)
                {
                    builder.AddField(x =>
                    {
                        x.Name = "Concentration";
                        x.Value = "No Concentration Needed";
                    });
                }
                else
                {
                    builder.AddField(x =>
                    {
                        x.Name = "Concentration";
                        x.Value = "Concentration is Needed";
                    });
                }
                if (spellByName.damage != null)
                {
                    var toShow = " ";
                    foreach (var item in spellByName.damage.damage_type.name)
                    {
                        toShow += item;
                    }
                    builder.AddField(x =>
                    {
                        x.Name = "Damage Type";
                        x.Value = toShow;

                    });
                }

             
                if (myDeserializedClass.higher_level.Count() != 0)
                {
                    builder.AddField(x =>
                    {
                        x.Name = "More Information";
                        foreach (var item in spellByName.higher_level)
                        {
                            x.Value = item;
                        }

                    });
                }

                await ReplyAsync("", false, builder.Build());

            }
            catch
            {
                await ReplyAsync("This shit so buggy but thats why we are testing it out");
            }
        }
        // end of spells


        [Command("ability")]
        [Summary("Gets info on a ability")]
        public async Task abilityScorebyName([Remainder] string abil)
        {
            var abilToUse = abil.ToLower();
            try
            {

                var client = new HttpClient();
                var abilByNameURL = ($"https://www.dnd5eapi.co/api/ability-scores/{abilToUse}");
                var abilByNameResponse = client.GetStringAsync(abilByNameURL).Result;

                AbilityScores.Root myDeserializedClass = JsonConvert.DeserializeObject<AbilityScores.Root>(abilByNameResponse);
                AbilityScores.Root results = new AbilityScores.Root();
                results.name = myDeserializedClass.name;
                results.full_name = myDeserializedClass.full_name;
                results.desc = myDeserializedClass.desc;
                results.skills = myDeserializedClass.skills;


        
          

                var builder = new EmbedBuilder
                {
                    Color = new Color(114, 137, 218),
                    Title = results.full_name,
                    Description = $"{results.desc[0].ToString()}, {results.desc[1]}"
                };
                builder.AddField(x =>
                {
                    x.Name = $"Skills that go with {results.full_name}";
                    foreach (var item in results.skills)
                    {
                        x.Value = item.name;
                    }
                });

                await ReplyAsync("", false, builder.Build());


            }
            catch
            {
                await ReplyAsync("Something did go right lol, things to check is the way we enter in the ability for example Strength should be ====> str, give it another shoot!");
            }
        }
        //end of ability score

        [Command("listskill")]
        [Summary("Gets a list of skill")]
        public async Task skillList()
        {
            var client = new HttpClient();
            var spellsURL = ($"https://www.dnd5eapi.co/api/skills");
            var spellsResponse = client.GetStringAsync(spellsURL).Result;

            SkillList.Root myDeserializedClass = JsonConvert.DeserializeObject<SkillList.Root>(spellsResponse);

            SkillList.Root skills = new SkillList.Root();
            skills.results = myDeserializedClass.results;
          
            foreach (var item in skills.results)
            {
                await ReplyAsync($"Name ::- {item.name}, ");
            }

        }

        [Command("skill")]
        [Summary("Gets info on a skill")]
        public async Task skillbyName([Remainder] string insSkill)
        {
            var skillToUse = insSkill.ToLower();
            try
            {
                var client = new HttpClient();
                var abilByNameURL = ($"https://www.dnd5eapi.co/api/skills/{skillToUse}");
                var abilByNameResponse = client.GetStringAsync(abilByNameURL).Result;

                Skills.Root myDeserializedClass = JsonConvert.DeserializeObject<Skills.Root>(abilByNameResponse);
                Skills.Root results = new Skills.Root();
                results.name = myDeserializedClass.name;
                results.desc = myDeserializedClass.desc;
                results.ability_score = myDeserializedClass.ability_score;

                await ReplyAsync($"FUll-Name : {results.name}");
                await ReplyAsync("-----------------------------------");

                for (int i = 0; i < results.desc.Count; i++)
                {
                    await ReplyAsync(results.desc[i]);
                }
                await ReplyAsync("-------------------------------------");
                await ReplyAsync($"Ability score to use with {results.name}");
                string theOne = " ";
                foreach (var item in results.ability_score.name)
                {
                    theOne += item.ToString();
                }
                await ReplyAsync(theOne);
                await ReplyAsync("--------------------------------");

            }
            catch
            {
                await ReplyAsync("Something isnt right here, hmm you must rolled low on your luck, LMAO try one more time, check the spelling of what your trying to do");
            }
        }
        //end of skills

        [Command("listcondition")]
        [Summary("Gets a list of conditions")]
        public async Task ConditionList()
        {
            var client = new HttpClient();
            var spellsURL = ($"https://www.dnd5eapi.co/api/conditions");
            var spellsResponse = client.GetStringAsync(spellsURL).Result;

            ConditionsList.Root myDeserializedClass = JsonConvert.DeserializeObject<ConditionsList.Root>(spellsResponse);

            ConditionsList.Root spellList = new ConditionsList.Root();
            spellList.results = myDeserializedClass.results;
          
            foreach (var item in spellList.results)
            {
                await ReplyAsync($"Name-=====> {item.name}, ");
            }

        }

        [Command("condition")]
        [Summary("Gets info on a condition")]
        public async Task conditionbyName([Remainder] string insCondition)
        {
            var condition = insCondition.ToLower();
            try
            {
                var client = new HttpClient();
                var conByNameURL = ($"https://www.dnd5eapi.co/api/conditions/{condition}");
                var conByNameResponse = client.GetStringAsync(conByNameURL).Result;

                Conditions.Root myDeserializedClass = JsonConvert.DeserializeObject<Conditions.Root>(conByNameResponse);
                Conditions.Root results = new Conditions.Root();
                results.name = myDeserializedClass.name;
                results.desc = myDeserializedClass.desc;

                var builder = new EmbedBuilder
                {
                    Color = new Color(114, 137, 218),
                    Title = results.name,
                    Description = $"{results.desc[0].ToString()}, {results.desc[1]}"
                };
              

                await ReplyAsync("", false, builder.Build());


             
            }
            catch
            {
                await ReplyAsync("Nop that didt go the way we wanted, try one more time check the spelling of what your trying to see");
            }
        }
        //end of conditions

        [Command("listfeature")]
        [Summary("Gets a list of feature")]
        public async Task FeatureList()
        {
            var client = new HttpClient();
            var spellsURL = ($"https://www.dnd5eapi.co/api/features");
            var spellsResponse = client.GetStringAsync(spellsURL).Result;

            FeaturesList.Root myDeserializedClass = JsonConvert.DeserializeObject<FeaturesList.Root>(spellsResponse);

            FeaturesList.Root spellList = new FeaturesList.Root();
            spellList.results = myDeserializedClass.results;
            await ReplyAsync($"There is a total of {spellList.count} Features in the api ");
            foreach (var item in spellList.results)
            {
                await ReplyAsync($"Name-=====> {item.name}, ");
            }

        }

        [Command("feature")]
        [Summary("Gets info on a feature")]
        public async Task featurebyName([Remainder] string insCondition)
        {
            var condition = insCondition.ToLower().Trim().Replace(" ", "-");
            try
            {
                var client = new HttpClient();
                var conByNameURL = ($"https://www.dnd5eapi.co/api/features/{condition}");
                var conByNameResponse = client.GetStringAsync(conByNameURL).Result;

                Features.Root myDeserializedClass = JsonConvert.DeserializeObject<Features.Root>(conByNameResponse);
                Features.Root result = new Features.Root();
                result.name = myDeserializedClass.name;
                result.level = myDeserializedClass.level;
                result.prerequisites = myDeserializedClass.prerequisites; // can be null
                result.desc = myDeserializedClass.desc;
                result.@class = myDeserializedClass.@class;
                result.index = myDeserializedClass.index;

                var toShow = " ";
                foreach (var x in result.@class.name)
                {
                    toShow += x.ToString();
                }

                var builder = new EmbedBuilder
                {
                    Color = new Color(114, 137, 218),
                    Title = result.name,
                    
                };
                builder.AddField(x => {

                    x.Name = "Desc";
                    foreach (var item in result.desc)
                    {
                      x.Value =($"{item}");
                    }

                });
                builder.AddField(x => {

                    x.Name = "Class";
                    x.Value = toShow;

                });


                await ReplyAsync("", false, builder.Build());
                
               
            }
            catch
            {
                await ReplyAsync("Nop that didt go the way we wanted, you good? hopefully you can get it rught this time!! Try one more time check the spelling of what your trying to see and make sure that the spaces are filled with a - for exp sneak attack =====> sneak-attack");
                await ReplyAsync("DND is also money hungry! so i may not be able to use this information at the moment");
            }
        }
        //end of feature

        [Command("listmonster")]
        [Summary("Gets a list of monster")]
        public async Task MonsterList()
        {
            var client = new HttpClient();
            var spellsURL = ($"https://www.dnd5eapi.co/api/monsters");
            var spellsResponse = client.GetStringAsync(spellsURL).Result;

            MonsterList.Root myDeserializedClass = JsonConvert.DeserializeObject<MonsterList.Root>(spellsResponse);

            MonsterList.Root spellList = new MonsterList.Root();
            spellList.results = myDeserializedClass.results;
            foreach (var item in spellList.results)
            {
                await ReplyAsync($"Name-=====> {item.name}, ");
            }

        }

        [Command("monster")]
        [Summary("Gets info on a monster")]
        public async Task monsterbyName([Remainder] string insMonster)
        {
            var monster = insMonster.ToLower().Trim().Replace(" ", "-");
            try
            {
                var client = new HttpClient();
                var monsterByNameURL = ($"https://www.dnd5eapi.co/api/monsters/{monster}");
                var monsterByNameResponse = client.GetStringAsync(monsterByNameURL).Result;

                MonsterByName.Root myDeserializedClass = JsonConvert.DeserializeObject<MonsterByName.Root>(monsterByNameResponse);
                MonsterByName.Root resluts = new MonsterByName.Root();
                resluts.actions = myDeserializedClass.actions;
                resluts.alignment = myDeserializedClass.alignment;
                resluts.armor_class = myDeserializedClass.armor_class;
                resluts.challenge_rating = myDeserializedClass.challenge_rating;
                resluts.charisma = myDeserializedClass.charisma;
                resluts.condition_immunities = myDeserializedClass.condition_immunities;
                resluts.constitution = myDeserializedClass.constitution;
                resluts.damage_immunities = myDeserializedClass.damage_immunities;
                resluts.damage_resistances = myDeserializedClass.damage_resistances;
                resluts.damage_vulnerabilities = myDeserializedClass.damage_vulnerabilities;
                resluts.dexterity = myDeserializedClass.dexterity;
                resluts.hit_dice = myDeserializedClass.hit_dice;
                resluts.hit_points = myDeserializedClass.hit_points;
                resluts.intelligence = myDeserializedClass.intelligence;
                resluts.legendary_actions = myDeserializedClass.legendary_actions;
                resluts.name = myDeserializedClass.name;
                resluts.proficiencies = myDeserializedClass.proficiencies;
                resluts.senses = myDeserializedClass.senses;
                resluts.size = myDeserializedClass.size;
                resluts.special_abilities = myDeserializedClass.special_abilities;
                resluts.speed = myDeserializedClass.speed;
                resluts.strength = myDeserializedClass.strength;
                resluts.type = myDeserializedClass.type;
                resluts.wisdom = myDeserializedClass.wisdom;


                var builder = new EmbedBuilder
                {
                    Color = new Color(114, 137, 218),
                    Title = myDeserializedClass.name,
                    Description = $"{myDeserializedClass.size} {myDeserializedClass.type} || {myDeserializedClass.alignment}"

                };
                builder.AddField(x =>
                {
                    x.IsInline = true;
                    x.Name = "Armor Class";
                    x.Value = resluts.armor_class;
                });
                builder.AddField(x =>
                {
                    x.IsInline = true;
                    x.Name = "Hit Points";
                    x.Value = resluts.hit_points;
                });
                builder.AddField(x =>
                {
                    x.IsInline = true;
                    x.Name = "Speed";
                    x.Value = resluts.speed.walk;
                });
                builder.AddField(x =>
                {
                    x.IsInline = true;
                    x.Name = "Str";
                    x.Value = resluts.strength;

                });
                builder.AddField(x =>
                {
                    x.IsInline = true;
                    x.Name = "Dex";
                    x.Value = resluts.dexterity;


                });
                builder.AddField(x =>
                {
                    x.IsInline = true;
                    x.Name = "CON";
                    x.Value = resluts.constitution;

                });
                builder.AddField(x =>
                {
                    x.IsInline = true;
                    x.Name = "INT";
                    x.Value = resluts.intelligence;

                });
                builder.AddField(x =>
                {
                    x.IsInline = true;
                    x.Name = "WIS";
                    x.Value = resluts.wisdom;

                });
                 
                builder.AddField(x =>
                {
                    x.IsInline = true;
                    x.Name = "CHA";
                    x.Value = resluts.charisma;

                });


                builder.AddField(x =>
                {
                    x.Name = "Proficiencies";
                    foreach (var item in resluts.proficiencies)
                    {
                        x.IsInline = true;
                        x.Value = ($"{item.proficiency.name} +{item.value.ToString()}");
                    }

                });
                builder.AddField(x =>
                {
                    x.IsInline = true;
                    x.Name = "Passive Perception";
                    x.Value = $"{ resluts.senses.passive_perception.ToString()}";
                });
                if (myDeserializedClass.senses.darkvision != null)
                {
                    builder.AddField(x =>
                    {
                        x.IsInline = true;
                        x.Name = "Dark Vision";
                        x.Value = myDeserializedClass.senses.darkvision;
                    });
                }
                builder.AddField(x =>
                {
                    x.IsInline = true;
                    x.Name = "Challenger rating";
                    x.Value = myDeserializedClass.challenge_rating.ToString();
                });
                if(myDeserializedClass.special_abilities.Count > 0)
                {
                    builder.AddField(x => {
                        x.Name = "Abilities";
                        x.Value = $"This is what {myDeserializedClass.name} can do";
                    });

                    foreach (var item in myDeserializedClass.special_abilities)
                    {
                        builder.AddField(x => {
                            x.Name = item.name;
                            x.Value = item.desc;
                            x.IsInline = true;
                        });
                    }
                }
                if(myDeserializedClass.legendary_actions.Count > 0)
                {
                    builder.AddField(x => {
                        x.Name = "Legendary Actions";
                        x.Value = "These are the Legendary Actions";
                    });


                    foreach (var item in myDeserializedClass.legendary_actions)
                    {
                        builder.AddField(x => {
                            x.Name = item.name;
                            x.Value = item.desc;
                            x.IsInline = true;
                        });
                    }
                }

                await ReplyAsync("", false, builder.Build());
            }


            catch
            {
                await ReplyAsync("This is a new api so that monster might not be here yet try another or good ole dnd wont let anyone use that monster");
            }
        }
        //end of monsters


        [Command("dndmeme")]

        [Summary("gives you a random dnd meme")]
        public async Task randomdndmeme()
        {
            var client = new HttpClient();
            var memeUrl = "https://api.giphy.com/v1/gifs/random?api_key=QNtbvhjxuL3IuKbEgj1IcxuwfQ8CezUt&tag=dungeons+and+dragons&rating=r";
            var Response = client.GetStringAsync(memeUrl).Result;

            DNDMEME.Root myDeserializedClass = JsonConvert.DeserializeObject<DNDMEME.Root>(Response);
            DNDMEME.Root meme = new DNDMEME.Root();
            meme.data = myDeserializedClass.data;
            DNDMEME.Data data = new DNDMEME.Data();
            data = myDeserializedClass.data;
            data.url = myDeserializedClass.data.url;

            string needUrl = data.url;
            string toPost = needUrl.Replace(@"\", "");

            await ReplyAsync(toPost);
        }

        [Command("notlookinggood")]

        [Summary("gives you a random meme for things going bad")]
        public async Task randomdndmemebad()
        {
            var client = new HttpClient();
            var memeUrl = "https://api.giphy.com/v1/gifs/random?api_key=QNtbvhjxuL3IuKbEgj1IcxuwfQ8CezUt&tag=dead&rating=r";
            var Response = client.GetStringAsync(memeUrl).Result;

            DNDMEME.Root myDeserializedClass = JsonConvert.DeserializeObject<DNDMEME.Root>(Response);
            DNDMEME.Root meme = new DNDMEME.Root();
            meme.data = myDeserializedClass.data;
            DNDMEME.Data data = new DNDMEME.Data();
            data = myDeserializedClass.data;
            data.url = myDeserializedClass.data.url;

            string needUrl = data.url;
            string toPost = needUrl.Replace(@"\", "");

            await ReplyAsync(toPost);
        }

        [Command("rolld20")]
        [Summary("Rolls a d20 for you")]
        public async Task d20()
        {
            Random random = new Random(21);
            int roll = random.Next(21);

            await ReplyAsync($"you rolled a {roll.ToString()}");
        }

        [Command("meme")]
        public async Task Meme()
        {
            var client = new HttpClient();
            var result = await client.GetStringAsync("");
            JArray arr = JArray.Parse(result);
            JObject post = JObject.Parse(arr[0]["data"]["children"][0]["data"].ToString());

            var builder = new EmbedBuilder()
                .WithImageUrl(post["url"].ToString())
                .WithColor(new Color(33, 176, 252))
                .WithTitle(post["title"].ToString())
                .WithUrl("https://reddit.com" + post["permalink"].ToString());

            var embed = builder.Build();
        }
    }

    public class MyException : Exception
    {
        public MyException() { }
        public MyException(string message) : base(message) { }
        public MyException(string message, Exception inner) : base(message, inner) { }
        protected MyException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
