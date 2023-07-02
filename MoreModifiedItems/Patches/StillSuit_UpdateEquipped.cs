using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AlexejheroYTB.MoreModifiedItems.Patches
{

    public class ESSBehaviour : MonoBehaviour { }

    [HarmonyPatch(typeof(Stillsuit), nameof(IEquippable.OnEquip))]
    [HarmonyPatch("IEquippable.OnEquip")]
    public static  class StillSuit_UpdateEquipped
    {
        [HarmonyPrefix]
        public static bool Prefix(Stillsuit __instance)
        {
            if (!__instance.GetComponent<ESSBehaviour>()) return true;

            if (GameModeUtils.RequiresSurvival() && !Player.main.GetComponent<Survival>().freezeStats)
            {
                ErrorMessage.AddDebug(Mathf.RoundToInt(__instance.waterCaptured).ToString() + "/" + __instance.waterPrefab.waterValue.ToString());


                __instance.waterCaptured += Time.deltaTime / 18f * 0.75f;
                if (__instance.waterCaptured >= __instance.waterPrefab.waterValue)
                {
                    ErrorMessage.AddDebug("Enhanced Stillsuit activated!");

                    GameObject gameObject = GameObject.Instantiate(__instance.waterPrefab.gameObject);
                    Pickupable component = gameObject.GetComponent<Pickupable>();
                    Player.main.GetComponent<Survival>().Eat(component.gameObject);
                    __instance.waterCaptured -= __instance.waterPrefab.waterValue;
                }
                
            }
            return false;

        }
    }
}