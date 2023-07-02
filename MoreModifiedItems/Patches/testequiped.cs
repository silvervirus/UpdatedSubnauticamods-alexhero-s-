using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlexejheroYTB.MoreModifiedItems.ESS;
using AlexejheroYTB.MoreModifiedItems.ESSG;
using AlexejheroYTB.MoreModifiedItems.Water;
using System.Collections;
using UnityEngine;

namespace AlexejheroYTB.MoreModifiedItems.Patches
{
  
    class testequiped
    {
        // Token: 0x02000003 RID: 3
        [HarmonyPatch(typeof(Player))]
        [HarmonyPatch("EquipmentChanged")]
        internal class CheckIfChipEquipped
        {
            // Token: 0x06000004 RID: 4 RVA: 0x00002200 File Offset: 0x00000400
            public static bool Prefix(Player __instance)
            {
                Inventory main = Inventory.main;
               int Count = main.equipment.GetCount(EnhancedStillSuit.TechType);
                int Count2 = main.equipment.GetCount(EnhancedStillSuitGloves.TechType);
                bool flag = Count > CheckIfChipEquipped.EquippedESSAmount;
                flag2 = flag;
                
                if (flag2)
                {
                    ErrorMessage.AddMessage("Flag2 is True");
                    UWE.CoroutineHost.StartCoroutine(WaterShite());
                    CheckIfChipEquipped.EquippedESSAmount= Count;
                    
                   
                }

                bool flag3 = Count2 > EquippedESSGAmount;
                flag4 = flag3;
                if (flag4)
                {
                    ErrorMessage.AddMessage("Flag4 is True");
                    UWE.CoroutineHost.StartCoroutine(Watergloves());
                    CheckIfChipEquipped.EquippedESSGAmount = Count;
                }

                return true;
            }


            // Token: 0x06000005 RID: 5 RVA: 0x00002282 File Offset: 0x00000482
            public static IEnumerator WaterShite()
            {
                bool ya = flag2;
                while (ya ==true)
                {
                    yield return new WaitForSeconds(600);
                    CraftData.AddToInventory(BigReclamedWater.TechType, 1, false, true);
                }
                
            }
            public static IEnumerator Watergloves()
            {
                bool s = flag4;
                while (s == true)
                {
                    yield return new WaitForSeconds(200);
                    CraftData.AddToInventory(TinyReclamedWater.TechType, 1, false, true);
                }

            }



            // Token: 0x06000006 RID: 6 RVA: 0x000022AD File Offset: 0x000004AD


            // Token: 0x04000003 RID: 3
            public static int EquippedESSAmount = 0;
            public static int EquippedESSGAmount = 0;
            public static bool flag2;
            public static bool flag4;


        }
    }
}

