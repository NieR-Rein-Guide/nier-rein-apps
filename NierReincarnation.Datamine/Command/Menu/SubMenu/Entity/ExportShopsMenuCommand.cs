using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.Tables;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public class ExportShopsMenuCommand : AbstractMenuCommand
{
    public override bool IsActive => Program.AppSettings.IsSetup;

    public override Task ExecuteAsync()
    {
        Console.WriteLine(nameof(EntityMShopTable));
        foreach (var shop in MasterDb.EntityMShopTable.All
            .Where(x => DateTimeExtensions.IsCurrentOrFuture(x.StartDatetime, x.EndDatetime))
            .OrderBy(x => x.StartDatetime))
        {
            var shopStr = $"shop.name.{shop.NameShopTextId}".Localize();

            if (shopStr.Contains("Weekly")) continue;

            var shopItemCellGroups = MasterDb.EntityMShopItemCellGroupTable.All.Where(x => x.ShopItemCellGroupId == shop.ShopItemCellGroupId);

            Console.WriteLine($"**{shopStr} ({shop.ShopType.ToFormattedStr()}) {shop.ToFormattedDateStr()}**");

            foreach (var shopItemCellGroup in shopItemCellGroups.OrderBy(x => x.SortOrder))
            {
                var shopItemCells = MasterDb.EntityMShopItemCellTable.All.Where(x => x.ShopItemCellId == shopItemCellGroup.ShopItemCellId);
                foreach (var shopItem in shopItemCells.Select(x => MasterDb.EntityMShopItemTable.FindByShopItemId(x.ShopItemId)))
                {
                    if (shop.ShopType == ShopType.MISSION_SHOP)
                    {
                        var itemMission = MasterDb.EntityMShopItemContentMissionTable.FindByShopItemId(shopItem.ShopItemId);
                        var missionGroup = MasterDb.EntityMMissionGroupTable.FindByMissionGroupId(itemMission.MissionGroupId);

                        foreach (var mission in MasterDb.EntityMMissionTable.All.Where(x => x.MissionGroupId == missionGroup.MissionGroupId))
                        {
                            var missionReward = MasterDb.EntityMMissionRewardTable.FindByMissionRewardId(mission.MissionRewardId);

                            var missionStr = $"mission.name.{mission.NameMissionTextId}".Localize();
                            var missionRewardStr = CalculatorPossession.GetItemName(missionReward.PossessionType, missionReward.PossessionId);

                            Console.WriteLine($"{missionStr}");
                            Console.WriteLine($"- {missionRewardStr} x{missionReward.Count}");
                        }
                    }
                    else
                    {
                        var itemPosessions = MasterDb.EntityMShopItemContentPossessionTable.All.Where(x => x.ShopItemId == shopItem.ShopItemId);
                        var itemLimitedStock = MasterDb.EntityMShopItemLimitedStockTable.All.FirstOrDefault(x => x.ShopItemLimitedStockId == shopItem.ShopItemLimitedStockId);
                        var shopItemStr = $"shop.item.name.{shopItem.NameShopTextId}".Localize();
                        var itemStockStr = itemLimitedStock != null ? $" x{itemLimitedStock.MaxCount}" : "";
                        var itemPrice = shopItem.Price.ToString();

                        if (shopItem.Price == 0)
                        {
                            var itemPaymentPrice = MasterDb.EntityMPlatformPaymentPriceTable.FindByPlatformPaymentIdAndPlatformType((shopItem.PriceId, PlatformType.GOOGLE_PLAY_STORE));

                            if (itemPaymentPrice != null)
                            {
                                itemPrice = $"¥{itemPaymentPrice.Price}";
                            }
                        }

                        Console.WriteLine($"{shopItemStr}{itemStockStr} ({itemPrice})");

                        foreach (var itemPosession in itemPosessions.OrderBy(x => x.SortOrder))
                        {
                            var itemPosessionStr = CalculatorPossession.GetItemName(itemPosession.PossessionType, itemPosession.PossessionId);

                            if (itemPosession.Count == 1 && shopItemStr.Equals(itemPosessionStr, StringComparison.OrdinalIgnoreCase)) continue;

                            Console.WriteLine($"- {itemPosessionStr} x{itemPosession.Count}");
                        }
                    }
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine();

        return Task.CompletedTask;
    }
}
