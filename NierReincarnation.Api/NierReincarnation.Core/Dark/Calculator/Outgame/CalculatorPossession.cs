using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.View.HeadUpDisplay.Calculator;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;

namespace NierReincarnation.Core.Dark.Calculator.Outgame
{
    public static class CalculatorPossession
    {
        public static string GetItemName(DataPossessionItem dataPossessionItem, bool isDistinctionGem = false)
        {
            return GetItemName(dataPossessionItem.PossessionType, dataPossessionItem.PossessionId, isDistinctionGem);
        }

        public static string GetItemName(PossessionType possessionType, int possessionId, bool isDistinctionGem = false)
        {
            switch (possessionType)
            {
                case PossessionType.COSTUME:
                    return CalculatorCostume.CostumeName(possessionId);

                case PossessionType.WEAPON:
                    return CalculatorWeapon.WeaponName(possessionId);

                case PossessionType.COMPANION:
                    return CalculatorCompanion.CompanionName(possessionId);

                case PossessionType.PARTS:
                    return CalculatorMemory.MemoryName(possessionId);

                case PossessionType.MATERIAL:
                    return CalculatorMaterial.MaterialName(possessionId);

                case PossessionType.CONSUMABLE_ITEM:
                    return CalculatorConsumable.ConsumableItemName(possessionId);

                case PossessionType.COSTUME_ENHANCED:
                    return CalculatorCostume.CostumeName(CalculatorCostume.GetCostumeIdByCostumeEnhancedId(possessionId));

                case PossessionType.WEAPON_ENHANCED:
                    return CalculatorWeapon.WeaponName(CalculatorWeapon.GetWeaponIdByWeaponEnhancedId(possessionId));

                case PossessionType.COMPANION_ENHANCED:
                    return CalculatorCompanion.CompanionName(CalculatorCompanion.GetCompanionIdByCompanionEnhancedId(possessionId));

                case PossessionType.PARTS_ENHANCED:
                    return CalculatorMemory.MemoryName(CalculatorMemory.GetPartsIdByPartsEnhancedId(possessionId));

                case PossessionType.PAID_GEM:
                    if (isDistinctionGem)
                        return CalculatorGem.PaidGemName();

                    return CalculatorGem.Name();

                case PossessionType.FREE_GEM:
                    if (isDistinctionGem)
                        return CalculatorGem.FreeGemName();

                    return CalculatorGem.Name();

                case PossessionType.IMPORTANT_ITEM:
                    return CalculatorImportantItem.ImportantItemName(possessionId);

                default:
                    return null;
            }
        }
    }
}
