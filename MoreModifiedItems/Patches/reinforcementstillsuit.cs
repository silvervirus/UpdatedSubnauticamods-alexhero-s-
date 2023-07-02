
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AlexejheroYTB.MoreModifiedItems.ESS;
using static HandReticle;

namespace AlexejheroYTB.MoreModifiedItems.Patches
{
    internal class reinforcementstillsuit
    {
        [HarmonyPatch(typeof(Player), nameof(Player.HasReinforcedSuit))]
        public static class Player_HasReinforcedSuit_Patch
        {
            [HarmonyPostfix]
            public static void Postfix(ref bool __result)
            {
                __result = __result || Inventory.main.equipment.GetTechTypeInSlot("Body") == EnhancedStillSuit.TechType;
            }
        }
    }
}
