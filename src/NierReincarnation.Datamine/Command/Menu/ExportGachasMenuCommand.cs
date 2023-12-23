using Newtonsoft.Json;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.View.HeadUpDisplay.Calculator;
using NierReincarnation.Datamine.Model;
using static NierReincarnation.Context.Models.Web.GachaRateBasic;

namespace NierReincarnation.Datamine.Command;

public class ExportGachasMenuCommand : AbstractMenuCommand<ExportGachasCommandArg>
{
    public override bool IsActive => false;

    public ExportGachasMenuCommand(ExportGachasCommandArg arg) : base(arg)
    {
    }

    public override async Task ExecuteAsync(ExportGachasCommandArg arg)
    {
        List<GachaModel> gachas = [];
        string filePath = Path.Combine(Constants.DataPath, "gacha.json");

        if (File.Exists(filePath))
        {
            string gachaJson = File.ReadAllText(filePath);
            gachas = JsonConvert.DeserializeObject<List<GachaModel>>(gachaJson);
        }

        //GachaContext gachaContext = new(new DarkClient());
        //await foreach (var gacha in gachaContext.GetBanners())
        //{
        //    // Exclude banners with no names
        //    if (arg.ExcludeNoName && string.IsNullOrEmpty(gacha.Name)) continue;

        // // Exclude banners that don't match the keyword if (!string.IsNullOrEmpty(arg.Keyword) && !gacha.Name.Contains(arg.Keyword,
        // StringComparison.OrdinalIgnoreCase)) continue;

        // // Exclude banners that don't match one of the specified types if (arg.GachaLabelTypes?.Count > 0 &&
        // !arg.GachaLabelTypes.Contains(gacha.GachaLabelType)) continue;

        // // Process banner var gachaRates = await gachaContext.GetRates(gacha.GachaId); if (gachaRates is GachaRateBasic rates) { GachaModel
        // existing = gachas.Find(x => x.GachaId == gacha.GachaId);

        // if (existing != null) { gachas.Remove(existing); }

        //        gachas.Add(new GachaModel
        //        {
        //            GachaId = gacha.GachaId,
        //            Name = gacha.Name,
        //            StartTime = gacha.StartTime,
        //            EndTime = gacha.EndTime,
        //            ItemsPerPull = 10,
        //            RarityRateList = rates.rarityRateList.Select(x => ToExport(x)).ToList(),
        //            LastChanceRarityRateList = rates.lastChanceRarityRateList.Select(x => ToExport(x)).ToList(),
        //            RarityRateDetailList = rates.rarityRateDetailList.Select(x => ToExport(x)).ToList(),
        //            LastChanceRarityRateDetailList = rates.lastChanceRarityRateDetailList.Select(x => ToExport(x)).ToList()
        //        });
        //    }
        //}

        Directory.CreateDirectory(Path.GetDirectoryName(filePath));
        await File.WriteAllTextAsync(filePath, JsonConvert.SerializeObject(gachas.OrderByDescending(x => x.GachaId), Formatting.Indented));
    }

    private static RarityRateListModel ToExport(RarityRateListElement element)
    {
        return new RarityRateListModel
        {
            RarityType = element.rarityType,
            Rate = decimal.TryParse(element.rateString.TrimEnd('%'), out decimal rate) ? rate : 0.0M,
            WithCostume = element.withCostume
        };
    }

    private static RarityRateDetailModel ToExport(RarityRateDetail x)
    {
        return new RarityRateDetailModel
        {
            Rate = decimal.TryParse(x.rateString.TrimEnd('%'), out decimal rate) ? rate : 0.0M,
            Weapon = new GachaWeaponModel
            {
                Name = x.gachaOddsItem.gachaItem.name,
                RarityType = x.gachaOddsItem.gachaItem.rarityType,
                AttributeType = x.gachaOddsItem.gachaItem.attributeType,
                WeaponType = x.gachaOddsItem.gachaItem.weaponType,
                FileName = CalculatorWeapon.ActorAssetId(x.gachaOddsItem.gachaItem.possessionId).StringId
            },
            Costume = x.gachaOddsItem.releaseItem.Count > 0
                ? new GachaCostumeModel
                {
                    CostumeName = x.gachaOddsItem.releaseItem[0].costumeName,
                    CharacterName = x.gachaOddsItem.releaseItem[0].characterName,
                    RarityType = x.gachaOddsItem.releaseItem[0].rarityType,
                    FileName = CalculatorCostume.ActorAssetId(x.gachaOddsItem.releaseItem[0].possessionId).StringId,
                }
                : null
        };
    }
}

public class ExportGachasCommandArg
{
    public string Keyword { get; init; }

    public bool ExcludeNoName { get; init; } = true;

    public List<GachaLabelType> GachaLabelTypes { get; init; }
}
