﻿using AlexejheroYTB.MoreModifiedItems.fins;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using Nautilus.Handlers;
using RamuneLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CraftData;
using Nautilus.Assets.Gadgets;
using HarmonyLib;
using UnityEngine;
using AlexejheroYTB.MoreModifiedItems.Patches;

namespace AlexejheroYTB.MoreModifiedItems.ESSG
{
    internal class EnhancedStillSuitGloves
    {
        public static PrefabInfo Info;
        public static TechType TechType;

        public static void Patch()

        {


            Info = Utilities.CreatePrefabInfo("ESSG", "Enhanced Still Suit Gloves", "New addon to the normal StillSuit We added Gloves to help collect more water.", SpriteManager.Get(TechType.RadiationGloves), 2, 2);
            var prefab = new CustomPrefab(Info);


            CraftDataHandler.SetEquipmentType(Info.TechType, EquipmentType.Gloves);
            prefab.SetUnlock(TechType.PrecursorIonPowerCell);

            _ = prefab.SetRecipe(Utilities.CreateRecipe(1,
                new Ingredient(TechType.RadiationGloves, 1),
                 new Ingredient(TechType.RadiationGloves, 1),
                new Ingredient(TechType.ComputerChip, 1),
                new Ingredient(TechType.CopperWire, 2),
                new Ingredient(TechType.Silver, 1)))


                .WithFabricatorType(CraftTree.Type.Workbench)
                .WithStepsToFabricatorTab("FinsMenu".Split('/'))
                .WithCraftingTime(0.5f);

            prefab.SetGameObject(new CloneTemplate(Info, TechType.WaterFiltrationSuit)
            {
                ModifyPrefab = prefab1 =>
                {
                    prefab1.EnsureComponent<DamagePlayerInRadius>().damageAmount = 0;
                    
                }
            });



            prefab.Register();

            TechType = Info.TechType;

        }

    }
}
    



