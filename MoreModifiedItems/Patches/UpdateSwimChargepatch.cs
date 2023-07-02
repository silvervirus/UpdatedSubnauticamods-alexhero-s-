using AlexejheroYTB.MoreModifiedItems.fins;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AlexejheroYTB.MoreModifiedItems.Patches
{

    [HarmonyPatch(typeof(UpdateSwimCharge), nameof(UpdateSwimCharge.FixedUpdate))]
    public static class UpdateSwimCharge_FixedUpdate_Patch
    {
        [HarmonyTranspiler]
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> c = instructions.ToList();
            int index = c.FindIndex(o => o.opcode == OpCodes.Ldc_I4_0);

            c.InsertRange(index, new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(Inventory), nameof(Inventory.Get))),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Property(typeof(Inventory), nameof(Inventory.equipment)).GetGetMethod()),
               new CodeInstruction(OpCodes.Ldsfld, AccessTools.Field(typeof(UltraGlideSwimChargeFins), nameof(UltraGlideSwimChargeFins.TechType))),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(Equipment), nameof(Equipment.GetCount))),
                new CodeInstruction(OpCodes.Add),



            });

            return c;
        }
    }
}
