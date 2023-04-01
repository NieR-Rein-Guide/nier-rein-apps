using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.Tables;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public class ExportShopsMenuCommand : AbstractMenuCommand
{
    public override bool IsActive => Program.AppSettings.IsSetup;

    public override Task ExecuteAsync()
    {
        Console.WriteLine(nameof(EntityMShopTable));
        foreach (var darkShop in MasterDb.EntityMShopTable.All
            .Where(x => DateTimeExtensions.IsCurrentOrFuture(x.StartDatetime, x.EndDatetime))
            .OrderBy(x => x.StartDatetime))
        {
            var shopStr = $"shop.name.{darkShop.NameShopTextId}".Localize();

            if (shopStr.Contains("Weekly")) continue;

            var darkShopItemCellGroups = MasterDb.EntityMShopItemCellGroupTable.All.Where(x => x.ShopItemCellGroupId == darkShop.ShopItemCellGroupId);

            Console.WriteLine($"**{shopStr} ({darkShop.ShopType.ToFormattedStr()}) {darkShop.ToFormattedDateStr()}**");

            List<int> terms = new();
            foreach (var darkShopItemCellGroup in darkShopItemCellGroups.OrderBy(x => x.ShopItemCellTermId).ThenBy(x => x.SortOrder))
            {
                if (darkShopItemCellGroup.ShopItemCellTermId > 0 && !terms.Contains(darkShopItemCellGroup.ShopItemCellTermId))
                {
                    terms.Add(darkShopItemCellGroup.ShopItemCellTermId);
                    var darkShopItemCellTerm = MasterDb.EntityMShopItemCellTermTable.FindByShopItemCellTermId(darkShopItemCellGroup.ShopItemCellTermId);
                    Console.WriteLine(DateTimeExtensions.GetExtraScheduleStr(CalculatorDateTime.FromUnixTime(darkShop.StartDatetime), CalculatorDateTime.FromUnixTime(darkShop.EndDatetime),
                        CalculatorDateTime.FromUnixTime(darkShopItemCellTerm.StartDatetime), CalculatorDateTime.FromUnixTime(darkShopItemCellTerm.EndDatetime)));
                }
                var darkShopItemCells = MasterDb.EntityMShopItemCellTable.All.Where(x => x.ShopItemCellId == darkShopItemCellGroup.ShopItemCellId);
                foreach (var darkShopItem in darkShopItemCells.Select(x => MasterDb.EntityMShopItemTable.FindByShopItemId(x.ShopItemId)))
                {
                    if (darkShop.ShopType == ShopType.MISSION_SHOP)
                    {
                        var darkShopItemMission = MasterDb.EntityMShopItemContentMissionTable.FindByShopItemId(darkShopItem.ShopItemId);
                        var darkMissionGroup = MasterDb.EntityMMissionGroupTable.FindByMissionGroupId(darkShopItemMission.MissionGroupId);

                        foreach (var darkMission in MasterDb.EntityMMissionTable.All.Where(x => x.MissionGroupId == darkMissionGroup.MissionGroupId))
                        {
                            var darkMissionReward = MasterDb.EntityMMissionRewardTable.FindByMissionRewardId(darkMission.MissionRewardId);

                            var missionStr = $"mission.name.{darkMission.NameMissionTextId}".Localize();
                            var missionRewardStr = CalculatorPossession.GetItemName(darkMissionReward.PossessionType, darkMissionReward.PossessionId);

                            Console.WriteLine($"{missionStr}");
                            Console.WriteLine($"- {missionRewardStr} x{darkMissionReward.Count}");
                        }
                    }
                    else
                    {
                        var darkShopItemPosessions = MasterDb.EntityMShopItemContentPossessionTable.All.Where(x => x.ShopItemId == darkShopItem.ShopItemId);
                        var darkShopItemLimitedStock = MasterDb.EntityMShopItemLimitedStockTable.All.FirstOrDefault(x => x.ShopItemLimitedStockId == darkShopItem.ShopItemLimitedStockId);
                        var shopItemStr = $"shop.item.name.{darkShopItem.NameShopTextId}".Localize();
                        var itemStockStr = darkShopItemLimitedStock != null ? $" x{darkShopItemLimitedStock.MaxCount}" : "";
                        var itemPrice = darkShopItem.Price.ToString();
                        //var itemCurrency = CalculatorPossession.GetItemName(PossessionType.CONSUMABLE_ITEM, darkShopItem.PriceId);

                        if (darkShopItem.PriceType == PriceType.PLATFORM_PAYMENT)
                        {
                            var darkShopItemPaymentPrice = MasterDb.EntityMPlatformPaymentPriceTable.FindByPlatformPaymentIdAndPlatformType((darkShopItem.PriceId, PlatformType.GOOGLE_PLAY_STORE));

                            if (darkShopItemPaymentPrice != null)
                            {
                                itemPrice = $"¥{darkShopItemPaymentPrice.Price}";
                            }
                        }

                        Console.WriteLine($"{shopItemStr}{itemStockStr} ({itemPrice})");
                        //Console.WriteLine($"{shopItemStr}{itemStockStr} ({itemPrice} {itemCurrency})");

                        foreach (var itemPosession in darkShopItemPosessions.OrderBy(x => x.SortOrder))
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
