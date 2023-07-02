
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AlexejheroYTB.MoreModifiedItems.ESS;
using AlexejheroYTB.MoreModifiedItems.ESSG;
using static HandReticle;

namespace AlexejheroYTB.MoreModifiedItems.Patches
{
    internal class hasStillSuitGloves
    {
        [HarmonyPatch(typeof(Player), nameof(Player.HasReinforcedGloves))]
        public static class Player_HasrandationprotectionSuit_Patch
        {
            [HarmonyPostfix]
            public static void Postfix(ref bool __result)
            {
                __result = __result || Inventory.main.equipment.GetTechTypeInSlot("Gloves") == EnhancedStillSuitGloves.TechType;
            }
        }
    }
}
