using BepInEx;
using AlexejheroYTB.MoreModifiedItems.tank;
using AlexejheroYTB.MoreModifiedItems.fins;
using HarmonyLib;
using AlexejheroYTB.MoreModifiedItems.ESS;
using AlexejheroYTB.MoreModifiedItems.ESSG;
using AlexejheroYTB.MoreModifiedItems.Addon;
using System.Reflection;
using Nautilus.Handlers;
using AlexejheroYTB.MoreModifiedItems.Patches;
using AlexejheroYTB.MoreModifiedItems.Water;

namespace MoreModifiedItems
{
    [BepInPlugin(QMod.PLUGIN_GUID, QMod.PLUGIN_NAME, QMod.PLUGIN_VERSION)]
    public class QMod : BaseUnityPlugin
    {
        public const string PLUGIN_GUID = "SN.MoreModifiedItems";

        // Token: 0x04000007 RID: 7
        public const string PLUGIN_NAME = "SN.MoreModifiedItems";

        // Token: 0x04000008 RID: 8
        public const string PLUGIN_VERSION = "1.0.1";
        internal static Config config { get; } = OptionsPanelHandler.RegisterModOptions<Config>();
        public void Awake()
        {

            CraftTreeHandler.AddTabNode(CraftTree.Type.Workbench, "BodyMenu", "Suit Upgrades", SpriteManager.Get(TechType.WaterFiltrationSuit));
            CraftTreeHandler.AddTabNode(CraftTree.Type.Workbench, "TanksMenu", "Tanks Upgrades", SpriteManager.Get(TechType.HighCapacityTank));
            CraftTreeHandler.AddTabNode(CraftTree.Type.Workbench, "FinsMenu", "Fins Upgrades", SpriteManager.Get(TechType.UltraGlideFins));
            LightweightUltraHighCapacityTank.Patch();
            UltraGlideSwimChargeFins.Awake();
            EnhancedStillSuitGloves.Patch();
            EnhancedStillSuit.Patch();
            BigReclamedWater.Patch();
            ScubaManifoldItem.Patch();
           new Harmony("MoreModifiedItems.mod").PatchAll(Assembly.GetExecutingAssembly());


            AlexejheroYTB.Common.Logger.Log("Patched");
        }
    }
}

   
    

