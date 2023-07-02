using AlexejheroYTB.MoreModifiedItems.Patches;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Crafting;
using Nautilus.Handlers;
using RamuneLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CraftData;

namespace AlexejheroYTB.MoreModifiedItems.Water
{
    internal class TinyReclamedWater
    { 
    public static PrefabInfo Info;
    public static TechType TechType;

    public static void Patch()

    {


        Info = Utilities.CreatePrefabInfo("TWTFAIDN", "Tiny Reclamed Water", "Water Extracted from the Enhanced WaterFiltration Gloves .", SpriteManager.Get(TechType.FilteredWater), 1, 1);
        var prefab = new CustomPrefab(Info);


       
        prefab.SetUnlock(TechType.PrecursorIonPowerCell);

           


        prefab.SetGameObject(new CloneTemplate(Info, TechType.WaterFiltrationSuitWater)
        {
            ModifyPrefab = prefab1 =>
            {
                Eatable eatable = prefab1.EnsureComponent<Eatable>();
                eatable.foodValue = -1;
                eatable.waterValue = 5;

            }
        });



        prefab.Register();

        TechType = Info.TechType;

    }

}
}
    