using System.Collections.Generic;
using System.Linq;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using NierReincarnation.Core.UnityEngine;

namespace NierReincarnation.Core.Dark.Calculator.Outgame
{
    public static class CalculatorShop
    {
        private static readonly int kInvalidLimitedOpenId; // 0x18

        public static List<int> CreateShopIdList(long userId, ShopGroupType shopGroupType)
        {
            var validList = GetValidEntityMShopList(userId, shopGroupType);
            return validList.OrderBy(x => x.SortOrderInShopGroup).Select(x => x.ShopId).ToList();
        }

        private static IEnumerable<EntityMShop> GetValidEntityMShopList(long userId, ShopGroupType shopGroupType)
        {
            var table = DatabaseDefine.Master.EntityMShopTable;
            return table.All
                .Where(x => CalculatorDateTime.IsWithinThePeriod(x.StartDatetime, x.EndDatetime))
                .Where(x => x.ShopGroupType == shopGroupType)
                .Where(x => IsOpenShop(userId, x))
                .Where(x => IsShopReleaseFunctionType(x.ShopId) || x.RelatedMainFunctionType != MainFunctionType.END_CONTENTS);
        }

        private static bool IsOpenShop(long userId, EntityMShop entityMShop)
        {
            if (entityMShop.LimitedOpenId == kInvalidLimitedOpenId)
                return true;

            return CalculatorLimitedOpen.IsOpen(userId, LimitedOpenTargetType.SHOP, entityMShop.ShopId);
        }

        public static bool IsShopReleaseFunctionType(int shopId)
        {
            var shopEntity = EntityMShop(shopId);
            if (shopEntity == null)
                return false;

            return CalculatorUnlockCondition.IsUnlockFunction(shopEntity.RelatedMainFunctionType);
        }

        public static EntityMShop EntityMShop(int shopId)
        {
            var table = DatabaseDefine.Master.EntityMShopTable;
            return table.FindByShopId(shopId);
        }

        public static IEnumerable<(int, EntityMShopItem, EntityMShopItemCellTerm)> ActiveEntityMShopItems(int shopItemCellGroupId)
        {
            var table = DatabaseDefine.Master.EntityMShopItemCellGroupTable;
            return table.All.Where(x => x.ShopItemCellGroupId == shopItemCellGroupId)
                .OrderBy(x => x.SortOrder)
                .Select(x => (x.SortOrder, x, EntityMShopItemCellTerm(x.ShopItemCellTermId)))
                .Where(x => CalculatorDateTime.IsWithinThePeriod(x.Item3.StartDatetime, x.Item3.EndDatetime))
                .Select(x => (x.Item1, EntityMShopItemCellList(x.x.ShopItemCellId).OrderBy(y => y.StepNumber).Where(y => y.ShopItemId != 0).Select(y => EntityMShopItem(y.ShopItemId)).FirstOrDefault(), x.Item3));
        }

        private static EntityMShopItemCellTerm EntityMShopItemCellTerm(int shopItemTermId)
        {
            var table = DatabaseDefine.Master.EntityMShopItemCellTermTable;
            return table.FindByShopItemCellTermId(shopItemTermId);
        }

        private static List<EntityMShopItemCell> EntityMShopItemCellList(int shopItemCellId)
        {
            var table = DatabaseDefine.Master.EntityMShopItemCellTable;
            return table.All.Where(x => x.ShopItemCellId == shopItemCellId).ToList();
        }

        private static EntityMShopItem EntityMShopItem(int shopItemId)
        {
            var table = DatabaseDefine.Master.EntityMShopItemTable;
            return table.FindByShopItemId(shopItemId);
        }

        public static string GetProductId(int platformPaymentId)
        {
            var table = DatabaseDefine.Master.EntityMPlatformPaymentTable;
            var element = table.FindByPlatformPaymentIdAndPlatformType((platformPaymentId, Application.Platform));
            if (element == null)
                return string.Empty;

            return element.ProductIdSuffix;
        }
    }
}
