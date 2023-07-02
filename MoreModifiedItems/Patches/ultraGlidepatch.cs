using AlexejheroYTB.MoreModifiedItems.fins;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexejheroYTB.MoreModifiedItems.Patches
{

    [HarmonyPatch(typeof(UnderwaterMotor), nameof(UnderwaterMotor.AlterMaxSpeed))]
    public static class UnderwaterMotor_AlterMaxSpeed_Patch
    {
        public static void Postfix(UnderwaterMotor __instance, ref float __result)
        {
            if (Inventory.Get().equipment.GetCount(UltraGlideSwimChargeFins.TechType) > 0)
            {
                __result += 2.5f * __instance.currentPlayerSpeedMultipler;
            }
        }
    }
}