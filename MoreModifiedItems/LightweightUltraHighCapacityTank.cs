using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using Nautilus.Crafting;
using Nautilus.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static CraftData;
using UnityStandardAssets.ImageEffects;
using HarmonyLib;
using UnityEngine;
using UnityEngine.U2D;

namespace AlexejheroYTB.MoreModifiedItems.tank
{
    internal class LightweightUltraHighCapacityTank
    {
        public static void Patch()
        {
            var lighttank = new CustomPrefab(
               "lwuhtank",
               "Lightweight Ultra High Capacity Tank",
               "Has the same amount of oxygen as the Ultra High Capacity Tank, but has the no speed penalty bonus of the Lightweight High Capacity Tank.");

            // Set our prefab to a clone of the Seamoth electrical defense module
            lighttank.SetGameObject(new CloneTemplate(lighttank.Info, TechType.HighCapacityTank)
            {
                ModifyPrefab = prefab =>
                {
                    prefab.GetAllComponentsInChildren<Oxygen>().Do(o => o.oxygenCapacity = 180);
                }
            });

            // Make our item compatible with the seamoth module slot
            SpriteHandler.RegisterSprite(lighttank.Info.TechType, SpriteManager.Get(TechType.HighCapacityTank));



            // Make the Vehicle upgrade console a requirement for our item's blueprint
            ScanningGadget scanning = lighttank.SetUnlock(TechType.HighCapacityTank);

            // Add our item to the Vehicle upgrades category
            scanning.WithPdaGroupCategory(TechGroup.Personal, TechCategory.Tools);

            var recipe = new RecipeData()
            {
                craftAmount = 1,
                Ingredients =
    {
        new Ingredient(TechType.HighCapacityTank, 1),
            new Ingredient(TechType.PlasteelTank, 1),
            new Ingredient(TechType.Lubricant, 2),
            new Ingredient(TechType.HydrochloricAcid, 1)

    },
            };
            CraftDataHandler.SetEquipmentType(lighttank.Info.TechType, EquipmentType.Tank);
            // Add a recipe for our item, as well as add it to the Moonpool fabricator and Seamoth modules tab
            lighttank.SetRecipe(recipe)
            .WithFabricatorType(CraftTree.Type.Workbench)
            .WithStepsToFabricatorTab("TankMenu".Split('/'));



            // Register our item to the game
            lighttank.Register();



        }
    }
}
