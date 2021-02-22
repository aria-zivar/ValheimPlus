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
    class ExperienceBumps
    {
        [HarmonyPatch(typeof(Player), "RaiseSkill")]
        public static class ExpModBumps
        {
            private static void Prefix(Player __instance, Skills.SkillType skill, float value = 1f)
            {
                float exp_multi = 3f;
                if (skill == Skills.SkillType.Blocking || skill == Skills.SkillType.Jump || skill == Skills.SkillType.Sneak)
                {
                    __instance.m_seman.ModifyRaiseSkill(skill, ref exp_multi);
                    value *= exp_multi;
                    __instance.m_skills.RaiseSkill(skill, value);
                }
            }
        }
    }
}
