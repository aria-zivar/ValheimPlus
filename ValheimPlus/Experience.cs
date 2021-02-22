using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using Unity;
using UnityEngine;
using System.IO;
using System.Reflection;
using System.Runtime;
using IniParser;
using IniParser.Model;
using HarmonyLib;
using System.Globalization;
using Steamworks;
using ValheimPlus;
using UnityEngine.Rendering;
using UnityEngine.UI;
using ValheimPlus.Configurations;

namespace ValheimPlus
{
    class Experience
    {
        
        [HarmonyPatch(typeof(Skills), "RaiseSkill")]
        public static class AddExpGainedDisplay
        {

            /*
            private static void Prefix(Skills __instance, Skills.SkillType skillType, float factor = 1f)
            {
               

            }*/

            private static void Postfix(Skills __instance, Skills.SkillType skillType, float factor = 1f)
            {
                Skills.Skill skill = __instance.GetSkill(skillType);
                String skill_name = skill.m_info.m_skill.ToString();

                if (skill_name.ToString() == "900" || skill_name.ToString() == "skill_900")
                {
                    skill_name = "Athletics";
                }

                var display_message = skill_name != "Athletics" && skill_name != "Run" && skill_name != "Swim" && skill_name != "Jump" && skill_name != "Sneak";

                if (display_message)
                {
                    if (Configuration.Current.Player.IsEnabled && Configuration.Current.Player.ExperienceGainedNotifications)
                    {
                        float percent = skill.m_accumulator / (skill.GetNextLevelRequirement() / 100);
                        int level = (int)skill.m_level;
                        //__instance.m_player.Message(MessageHud.MessageType.TopLeft, skill.m_info.m_skill + " [" + Helper.tFloat(skill.m_accumulator, 2) + "/" + Helper.tFloat(skill.GetNextLevelRequirement(), 2) + "] (" + Helper.tFloat(percent, 0) + "%)", 0, skill.m_info.m_icon);



                        __instance.m_player.Message(MessageHud.MessageType.TopLeft, skill_name + " " + level.ToString() + " (" + Helper.tFloat(percent, 0) + "%)", 0, skill.m_info.m_icon);
                    }
                }
            }
        }
    }
}
