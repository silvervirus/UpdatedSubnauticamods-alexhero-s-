using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using Nautilus.Handlers;
using System.Collections.Generic;
using System.Linq;
using static CraftData;
using HarmonyLib;
using RamuneLib;
using System.Reflection.Emit;
using UnityEngine;

namespace AlexejheroYTB.MoreModifiedItems.fins
{
    internal class UltraGlideSwimChargeFins
    {
        public static PrefabInfo Info;
        public static TechType TechType;

        public static void Awake()

        {


            Info = Utilities.CreatePrefabInfo("ugscfins", "Ultra Glide Swim Charge Fins", "Has the same speed increase as the Ultra Glide Fins, but also has the tool recharge ability of the Swim Charge Fins.", SpriteManager.Get(TechType.UltraGlideFins), 2, 3);
            var prefab = new CustomPrefab(Info);


            CraftDataHandler.SetEquipmentType(UltraGlideSwimChargeFins.Info.TechType, EquipmentType.Foots);
            prefab.SetUnlock(TechType.UltraGlideFins);

            _ = prefab.SetRecipe(Utilities.CreateRecipe(1,
                new Ingredient(TechType.UltraGlideFins, 1),
            new Ingredient(TechType.SwimChargeFins, 1),
            new Ingredient(TechType.Lubricant, 2),
            new Ingredient(TechType.HydrochloricAcid, 1)))


                .WithFabricatorType(CraftTree.Type.Workbench)
                .WithStepsToFabricatorTab("FinsMenu".Split('/'))
                .WithCraftingTime(0.5f);

            var clone = new CloneTemplate(UltraGlideSwimChargeFins.Info, TechType.SwimChargeFins)
            {

            };


            prefab.SetGameObject(clone);
            prefab.Register();

            TechType = Info.TechType;

        }
    }
}










    

