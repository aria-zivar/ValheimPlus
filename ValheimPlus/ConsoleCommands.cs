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
    class ConsoleCommands
    {
        [HarmonyPatch(typeof(Console), "InputText")]

        public static class ConsoleDevStuff
        {
            private static void Prefix(Console __instance)
            {
                string input_text = __instance.m_input.text;
                if (input_text.StartsWith("save"))
                {
                    ZNet.instance.ConsoleSave();
                }
            }
        }
    }
}
