
using HarmonyLib;
using Klei.AI;
using TUNING;
using UnityEngine;

namespace DupeAttrMod
{
    public class Patches
    {
        public static readonly string[] allAttrs = new string[12]
        {
            "Strength", 
            "Caring", 
            "Construction", 
            "Digging", 
            "Machinery", 
            "Learning", 
            "Cooking", 
            "Botanist", 
            "Art", 
            "Ranching",
            "Athletics", 
            "SpaceNavigation"
        };

        public static int[] addList;

        [HarmonyPatch(typeof(MinionModifiers) , "OnPrefabInit")]

        public class MinionModifiers_OnPrefabInit_Patch
        {
            public static void Postfix(MinionModifiers __instance)
            {
                if(addList == null)
                {
                    addList = new int[12]
                    {
                        Settings.Instance.Strength,
                        Settings.Instance.Caring,
                        Settings.Instance.Construction,
                        Settings.Instance.Digging,
                        Settings.Instance.Machinery,
                        Settings.Instance.Learning,
                        Settings.Instance.Cooking,
                        Settings.Instance.Botanist,
                        Settings.Instance.Art,
                        Settings.Instance.Ranching,
                        Settings.Instance.Athletics,
                        Settings.Instance.SpaceNavigation,
                    };
                }

                for (int i = 0 ; i < allAttrs.Length ; i++)
                {
                    AttributeModifier expertAthleticsModifier = new AttributeModifier(allAttrs[i] , addList[i] , "MOD下小人能力提升");
                    __instance.attributes.Get(allAttrs[i]).Add(expertAthleticsModifier);
                }
            }
        }
    }
}
