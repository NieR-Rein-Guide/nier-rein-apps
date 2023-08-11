using System.Collections.Generic;
using System.Linq;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.Purchase;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using NierReincarnation.Core.UnityEngine;

namespace NierReincarnation.Core.Dark.Calculator.Outgame
{
    public static class CalculatorShop
    {
        private static readonly int kInvalidLimitedOpenId;

        public static int kShopIdItem => ShopId(ShopType.ITEM_SHOP);
        public static int kShopIdStamina => ShopId(ShopType.STAMINA_RECOVERY_SHOP);

        public static List<DataShop> CreateDataShopList(long userId, ShopGroupType shopGroupType)
        {
            var validList = GetValidEntityMShopList(userId, shopGroupType);
            return validList.OrderBy(x => x.SortOrderInShopGroup).Select(x => CreateDataShop(userId, x)).ToList();
        }

        public static List<DataShopItem> CreateDataShopItemList(long userId, int shopId)
        {
            if (shopId == kShopIdItem)
                return CreateDataItemShopItemList(userId);

            var masterShop = EntityMShop(shopId);
            var activeItems = ActiveEntityMShopItems(masterShop.ShopItemCellGroupId);

            return activeItems
                .Select(x => CreateDataShopItem(userId, x.Item1, x.Item2, x.Item3))
                .Where(x => x != null)
                .OrderBy(x => x.SortOrder)
                .ToList();
        }

        private static List<DataShopItem> CreateDataItemShopItemList(long userId)
        {
            // TODO: Implement maybe?
            return new List<DataShopItem>();
        }

        private static DataShopItem CreateDataShopItem(long userId, int sortOrder, EntityMShopItem entityMShopItem, EntityMShopItemCellTerm entityMShopItemCellTerm)
        {
            var limitedStock = EntityMShopItemLimitedStock(entityMShopItem.ShopItemLimitedStockId);
            var shopItem = EntityIUserShopItem(userId, entityMShopItem.ShopItemId);
            var itemPossession = EntityMShopItemContentPossession(entityMShopItem.ShopItemId);

            var productId = string.Empty;
            if (entityMShopItem.PriceType == PriceType.PLATFORM_PAYMENT)
            {
                productId = GetProductId(entityMShopItem.PriceId);
                if (string.IsNullOrEmpty(productId))
                    return null;

                // HINT: This check goes against the products retrieved from the platforms shop SDK
                // Since we do not have access to such a shop SDK, we do not return an invalid result, as the game does
                if (!DarkPurchase.Instance.IsExistsProduct(productId))
                    ;
            }

            var result = new DataShopItem
            {
                ShopItemId = entityMShopItem.ShopItemId,
                SortOrder = sortOrder,

                DataPriceType = new DataPriceType
                {
                    PriceType = entityMShopItem.PriceType,
                    ConsumableItemId = entityMShopItem.PriceId
                },

                Price = entityMShopItem.Price,
                OldPrice = entityMShopItem.RegularPrice,

                //PlatformPrice = ???
                PlatformPriceString = DarkPurchase.Instance.GetStorePriceString(productId),
                ProductId = productId,

                ShopPromotionType = entityMShopItem.ShopPromotionType,
                ShopItemDecorationType = entityMShopItem.ShopItemDecorationType,
                AssetCategoryId = entityMShopItem.AssetCategoryId,
                AssetVariationId = entityMShopItem.AssetVariationId,

                DataPossessionItemList = itemPossession.Select(x => new DataPossessionItem
                {
                    PossessionType = x.PossessionType,
                    PossessionId = x.PossessionId,
                    Count = x.Count
                }).ToList(),

                IsLimitedStock = limitedStock != null,

                // TODO: Send over correct count
                ItemName = GetItemName(entityMShopItem.NameShopTextId, -1),
                DescriptionText = GetItemDescription(entityMShopItem.DescriptionShopTextId)
            };

            if (entityMShopItemCellTerm != null)
            {
                result.StartUnixTime = entityMShopItemCellTerm.StartDatetime;
                result.EndUnixTime = entityMShopItemCellTerm.EndDatetime;
            }

            if (limitedStock != null)
            {
                result.RemainingStock = limitedStock.MaxCount;
                if (shopItem != null)
                    result.RemainingStock -= shopItem.BoughtCount;
            }

            return result;
        }

        private static EntityMShopItemLimitedStock EntityMShopItemLimitedStock(int shopItemLimitedStockId)
        {
            var table = DatabaseDefine.Master.EntityMShopItemLimitedStockTable;
            return table.FindByShopItemLimitedStockId(shopItemLimitedStockId);
        }

        private static EntityIUserShopItem EntityIUserShopItem(long userId, int shopItemId)
        {
            var table = DatabaseDefine.User.EntityIUserShopItemTable;
            return table.All.Where(x => x.UserId == userId).FirstOrDefault(x => x.ShopItemId == shopItemId);
        }

        private static List<EntityMShopItemContentPossession> EntityMShopItemContentPossession(int shopItemId)
        {
            var table = DatabaseDefine.Master.EntityMShopItemContentPossessionTable;
            return table.All.Where(x => x.ShopItemId == shopItemId).OrderBy(x => x.SortOrder).ToList();
        }

        private static DataShop CreateDataShop(long userId, EntityMShop entityMShop)
        {
            var (start, end) = entityMShop.LimitedOpenId == 0 ?
                (entityMShop.StartDatetime, entityMShop.EndDatetime) :
                CalculatorLimitedOpen.GetTerm(userId, LimitedOpenTargetType.SHOP, entityMShop.ShopId);

            var result = new DataShop
            {
                ShopId = entityMShop.ShopId,
                Name = GetName(entityMShop.NameShopTextId),
                ShopUpdatableLabelType = entityMShop.ShopUpdatableLabelType,
                StartDateTime = start,
                EndDateTime = end,
                IsLimitedOpen = entityMShop.LimitedOpenId != 0,
                ShopType = entityMShop.ShopType,
                ShopExchangeType = entityMShop.ShopExchangeType
            };

            return result;
        }

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
            return table.All
                .Where(x => x.ShopItemCellGroupId == shopItemCellGroupId)
                .OrderBy(x => x.SortOrder)
                .Select(x => (x.SortOrder, x, EntityMShopItemCellTerm(x.ShopItemCellTermId)))
                .Where(x => x.Item3 == null ? x.x.ShopItemCellTermId == 0 : CalculatorDateTime.IsWithinThePeriod(x.Item3.StartDatetime, x.Item3.EndDatetime))
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

        private static string GetName(int nameTextId)
        {
            if (nameTextId == 0)
                return null;

            return $"shop.name.{nameTextId}".Localize();
        }

        private static string GetItemName(int nameTextId, int count)
        {
            return $"shop.item.name.{nameTextId}".LocalizeWithParams(count);
        }

        private static string GetItemDescription(int descriptionTextId)
        {
            return $"shop.item.description.{descriptionTextId}".Localize();
        }

        private static int ShopId(ShopType shopType)
        {
            var shopTable = DatabaseDefine.Master.EntityMShopTable;
            return shopTable.All
                .Where(x => CalculatorDateTime.IsWithinThePeriod(x.StartDatetime, x.EndDatetime))
                .Where(x => x.ShopType == shopType)
                .Select(x => x.ShopId)
                .FirstOrDefault();
        }
    }
}
