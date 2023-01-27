using SMLHelper.V2.Assets;
using SMLHelper.V2.Crafting;
using System.Collections;
using UnityEngine;
using SMLHelper.V2.Utility;

namespace SeamothBrineResist.Modules
{
    public class SeamothBrineResistanceModule : Equipable
    {
        public static TechType TechTypeID { get; protected set; }
        public SeamothBrineResistanceModule() 
            : base("SeamothBrineResistModule",
                  "Seamoth brine resistant coating",
                  "Makes the Seamoth resistant to corrosive brine pools, by means of a protective coating.")
        {
            OnFinishedPatching += () =>
            {
                TechTypeID = this.TechType;
            };
        }
        public override EquipmentType EquipmentType => EquipmentType.SeamothModule;
        public override TechType RequiredForUnlock => TechType.BaseUpgradeConsole;
        public override TechGroup GroupForPDA => TechGroup.VehicleUpgrades;
        public override TechCategory CategoryForPDA => TechCategory.VehicleUpgrades;
        public override CraftTree.Type FabricatorType => CraftTree.Type.SeamothUpgrades;
        public override string[] StepsToFabricatorTab => new string[] { "SeamothModules" };
        public override QuickSlotType QuickSlotType => QuickSlotType.Passive;

        public override IEnumerator GetGameObjectAsync(IOut<GameObject> gameObject)
        {
            CoroutineTask<GameObject> task = CraftData.GetPrefabForTechTypeAsync(TechType.SeamothElectricalDefense);
            yield return task;
            GameObject prefab = task.GetResult();
            GameObject obj = Object.Instantiate(prefab);
        }
        protected override TechData GetBlueprintRecipe()
        {
            return new TechData()
            {
                craftAmount = 1,
                Ingredients =
                {
                    new Ingredient(TechType.Polyaniline, 1),
                    new Ingredient(TechType.CopperWire, 2),
                    new Ingredient(TechType.AluminumOxide, 2),
                    new Ingredient(TechType.Nickel, 1),
                },
            };
        }
        protected override Atlas.Sprite GetItemSprite() => ImageUtils.LoadSpriteFromFile(BrineUpdate.BrineUpdate_SN.AssetsFolder + "/SeamothBrineResistModule.png");
        public override string AssetsFolder { get; } = BrineUpdate.BrineUpdate_SN.AssetsFolder;
    }
}