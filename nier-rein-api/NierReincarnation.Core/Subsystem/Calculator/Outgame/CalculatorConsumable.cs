using System.Linq;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using NierReincarnation.Core.Dark.View.UserInterface.Text;

namespace NierReincarnation.Core.Subsystem.Calculator.Outgame
{
    public static class CalculatorConsumable
    {
        public static int[] StaminaConsumableItemIds { get; } = { 3001, 3002, 3003 };

        private static EntityMConsumableItem GetEntityMConsumableItem(int consumableItemId)
        {
            var table = DatabaseDefine.Master.EntityMConsumableItemTable;
            return table.FindByConsumableItemId(consumableItemId);
        }

        public static DataConsumableItem CreateDataConsumableItem(int consumableItemId)
        {
            var masterItem = GetEntityMConsumableItem(consumableItemId);
            return CreateDataConsumableItem(masterItem);
        }

        private static DataConsumableItem CreateDataConsumableItem(EntityMConsumableItem entityMConsumableItem)
        {
            return new DataConsumableItem
            {
                ConsumableItemId = entityMConsumableItem.ConsumableItemId,
                Name = GetName(entityMConsumableItem.AssetCategoryId,entityMConsumableItem.AssetVariationId),
                Description = GetDescription(entityMConsumableItem.AssetCategoryId,entityMConsumableItem.AssetVariationId),
                AssetCategoryId = entityMConsumableItem.AssetCategoryId,
                AssetVariationId = entityMConsumableItem.AssetVariationId,
                ConsumableItemTermId = entityMConsumableItem.ConsumableItemTermId
            };
        }

        public static RecoverData[] CreateRecoverItemData(EffectTargetType targetType)
        {
            var userId = CalculatorStateUser.GetUserId();

            var itemTable = DatabaseDefine.Master.EntityMConsumableItemTable;
            return itemTable.All.Where(x => x.ConsumableItemType == ConsumableItemType.EFFECT)
                .Select(x => (x.SortOrder, x, GetEntityMConsumableItemCellTerm(x.ConsumableItemTermId)))
                .OrderBy(x => x.Item3 == null)
                .ThenBy(x => x.Item1)
                .Where(x => x.Item3 == null ? x.x.ConsumableItemTermId == 0 : CalculatorDateTime.IsWithinThePeriod(x.Item3.StartDatetime, x.Item3.EndDatetime))
                .Select(x => (x.x, DatabaseDefine.Master.EntityMConsumableItemEffectTable.FindByConsumableItemId(x.x.ConsumableItemId), x.Item3))
                .Where(x => x.Item2.EffectTargetType == targetType)
                .Select(x => CreateRecoverData(userId, x.x, x.Item2))
                .ToArray();
        }

        private static EntityMConsumableItemTerm GetEntityMConsumableItemCellTerm(int consumableItemTermId)
        {
            var table = DatabaseDefine.Master.EntityMConsumableItemTermTable;
            return table.FindByConsumableItemTermId(consumableItemTermId);
        }

        private static RecoverData CreateRecoverData(long userId, EntityMConsumableItem item, EntityMConsumableItemEffect effect)
        {
            return new RecoverData
            {
                ConsumableId = item.ConsumableItemId,
                Name = GetName(item.AssetCategoryId, item.AssetVariationId),
                DetailText = GetDescription(item.AssetCategoryId, item.AssetVariationId),
                PossessionCount = PossessionCount(userId, item.ConsumableItemId),
                EffectValue = CalculateEffectValue(effect.EffectTargetType, effect.EffectValueType, effect.EffectValue),
                EffectTargetType = effect.EffectTargetType,
                NeedCount = 1,
                SortOrder = item.SortOrder,
                ConsumableItemTermId = item.ConsumableItemTermId
            };
        }

        public static int PossessionCount(long userId, int consumableItemId)
        {
            var table = DatabaseDefine.User.EntityIUserConsumableItemTable;
            return table.All.Where(x => x.UserId == userId && x.ConsumableItemId == consumableItemId).Select(x => x.Count).FirstOrDefault();
        }

        public static int CalculateEffectValue(EffectTargetType targetType, EffectValueType valueType, int effectValue)
        {
            if (valueType == EffectValueType.FIXED_VALUE)
                return effectValue;

            // HINT: PVP will not be implemented, so we don't need BP
            //if (targetType == EffectTargetType.BATTLE_POINT_RECOVERY)
            //    return (int)(effectValue / 1000f * CalculatorUserStatus.GetMaxBp());

            if (targetType == EffectTargetType.STAMINA_RECOVERY)
                return (int)(effectValue / 1000f * CalculatorUserStatus.GetMaxStamina());

            return 0;
        }

        private static string GetName(int categoryId, int variationId)
        {
            return string.Format(UserInterfaceTextKey.ConsumableItem.kName, categoryId, variationId).Localize();
        }

        private static string GetDescription(int categoryId, int variationId)
        {
            return string.Format(UserInterfaceTextKey.ConsumableItem.kDescription, categoryId, variationId).Localize();
        }

        public static string ConsumableItemName(int consumableItemId)
        {
            var masterConsumable = GetEntityMConsumableItem(consumableItemId);
            if (masterConsumable == null)
                return null;

            return GetName(masterConsumable.AssetCategoryId, masterConsumable.AssetVariationId);
        }

        public static string ConsumableItemDescription(int consumableItemId)
        {
            var masterConsumable = GetEntityMConsumableItem(consumableItemId);
            if (masterConsumable == null)
                return null;

            return GetDescription(masterConsumable.AssetCategoryId, masterConsumable.AssetVariationId);
        }
    }
}
