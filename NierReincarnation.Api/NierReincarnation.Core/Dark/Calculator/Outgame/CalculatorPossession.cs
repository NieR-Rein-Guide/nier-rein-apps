using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.View.HeadUpDisplay.Calculator;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;

namespace NierReincarnation.Core.Dark.Calculator.Outgame
{
    public static class CalculatorPossession
    {
        private const int kInvalidSortOrder = 0;
        private const int kSimpleIncreaseAddValue = 1;

        public static string GetItemName(DataPossessionItem dataPossessionItem, bool isDistinctionGem = false)
        {
            return GetItemName(dataPossessionItem.PossessionType, dataPossessionItem.PossessionId, isDistinctionGem);
        }

        public static string GetItemName(PossessionType possessionType, int possessionId, bool isDistinctionGem = false)
        {
            return possessionType switch
            {
                PossessionType.COSTUME => CalculatorCostume.CostumeName(possessionId),
                PossessionType.WEAPON => CalculatorWeapon.WeaponName(possessionId),
                PossessionType.COMPANION => CalculatorCompanion.CompanionName(possessionId),
                PossessionType.PARTS => CalculatorMemory.MemoryName(possessionId),
                PossessionType.MATERIAL => CalculatorMaterial.MaterialName(possessionId),
                PossessionType.CONSUMABLE_ITEM => CalculatorConsumable.ConsumableItemName(possessionId),
                PossessionType.COSTUME_ENHANCED => CalculatorCostume.CostumeName(CalculatorCostume.GetCostumeIdByCostumeEnhancedId(possessionId)),
                PossessionType.WEAPON_ENHANCED => CalculatorWeapon.WeaponName(CalculatorWeapon.GetWeaponIdByWeaponEnhancedId(possessionId)),
                PossessionType.COMPANION_ENHANCED => CalculatorCompanion.CompanionName(CalculatorCompanion.GetCompanionIdByCompanionEnhancedId(possessionId)),
                PossessionType.PARTS_ENHANCED => CalculatorMemory.MemoryName(CalculatorMemory.GetPartsIdByPartsEnhancedId(possessionId)),
                PossessionType.PAID_GEM => (isDistinctionGem) ? CalculatorGem.PaidGemName() : CalculatorGem.Name(),
                PossessionType.FREE_GEM => (isDistinctionGem) ? CalculatorGem.FreeGemName() : CalculatorGem.Name(),
                PossessionType.IMPORTANT_ITEM => CalculatorImportantItem.ImportantItemName(possessionId),
                PossessionType.MISSION_PASS_POINT => CalculatorMissionPass.GetMissionPointName(),
                _ => null,
            };
        }

        public static string GetItemName(DataPriceType dataPriceType)
        {
            return dataPriceType.PriceType switch
            {
                PriceType.CONSUMABLE_ITEM => CalculatorConsumable.ConsumableItemName(dataPriceType.ConsumableItemId),
                PriceType.GEM => CalculatorGem.Name(),
                _ => string.Empty
            };
        }
    }
}
