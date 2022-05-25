using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Text;

namespace NierReincarnation.Core.Subsystem.Calculator.Outgame
{
    public static class CalculatorConsumable
    {
        private static EntityMConsumableItem GetEntityMConsumableItem(int consumableItemId)
        {
            var table = DatabaseDefine.Master.EntityMConsumableItemTable;
            return table.FindByConsumableItemId(consumableItemId);
        }

        private static string GetName(int categoryId, int variationId)
        {
            return string.Format(UserInterfaceTextKey.ConsumableItem.kName, categoryId, variationId).Localize();
        }

        public static string ConsumableItemName(int consumableItemId)
        {
            var masterConsumable = GetEntityMConsumableItem(consumableItemId);
            if (masterConsumable == null)
                return null;

            return GetName(masterConsumable.AssetCategoryId, masterConsumable.AssetVariationId);
        }
    }
}
