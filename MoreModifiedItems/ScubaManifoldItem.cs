using AlexejheroYTB.MoreModifiedItems.fins;
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
using System.IO;
using System.Reflection;

namespace AlexejheroYTB.MoreModifiedItems.Addon
{
    internal class ScubaManifoldItem
    {
        public static PrefabInfo Info;
        public static TechType TechType;

        public static void Patch()

        {


            Info = Utilities.CreatePrefabInfo("ScubaManifold", "Scuba Manifold", "Combines the oxygen supply of all carried tanks", Utilities.GetSprite("ScubaManifold"), 2, 3);
            var prefab = new CustomPrefab(Info);


            CraftDataHandler.SetEquipmentType(Info.TechType, EquipmentType.Tank);
            prefab.SetUnlock(TechType.PrecursorIonPowerCell);

            _ = prefab.SetRecipe(Utilities.CreateRecipe(1,

                new Ingredient(TechType.Silicone, 1),
                new Ingredient(TechType.Titanium, 3),
                new Ingredient(TechType.Lubricant, 2)))


              .WithFabricatorType(CraftTree.Type.Workbench)
                .WithStepsToFabricatorTab("FinsMenu".Split('/'))
                .WithCraftingTime(0.5f);

            prefab.SetGameObject(new CloneTemplate(Info, TechType.DoubleTank)
            {
                ModifyPrefab = prefab1 =>
                {
                    

                    ScubaManifold scuba = Player.mainObject.GetComponent<ScubaManifold>() ?? Player.mainObject.AddComponent<ScubaManifold>();

                    

                }
            });



            prefab.Register();

            TechType = Info.TechType;


        }
        public class ScubaManifold : MonoBehaviour
        {
            public static TechType techType;

            public void Start()
            {
                if (GameObject.FindObjectsOfType<ScubaManifold>().Length >= 2)
                {
                    Console.WriteLine("[ScubaManifold] [ERROR] ScubaManifold component must be a singleton!");
                    DestroyImmediate(this);
                }
            }

            public void Update()
            {
                List<InventoryItem> items = new List<InventoryItem>();
                Inventory.main.container.GetItemTypes().ForEach(type => items.AddRange(Inventory.main.container.GetItems(type)));
                List<Oxygen> sources = items.Where(item => item.item.gameObject.GetComponent<Oxygen>() != null).Select(item => item.item.gameObject.GetComponent<Oxygen>()).ToList();

                if (Inventory.main.equipment.GetItemInSlot("Tank")?.item?.GetTechType() == ScubaManifoldItem.TechType) sources.ForEach(source => Player.main.oxygenMgr.RegisterSource(source));
                else sources.ForEach(source => Player.main.oxygenMgr.UnregisterSource(source));
            }
        }
    }
}




