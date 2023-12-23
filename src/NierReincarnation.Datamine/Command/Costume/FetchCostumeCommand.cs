using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Networking;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using NierReincarnation.Datamine.Model;

namespace NierReincarnation.Datamine.Command;

public class FetchCostumeCommand : AbstractDbQueryCommand<FetchCostumeCommandArg, Costume>
{
    public override async Task<Costume> ExecuteAsync(FetchCostumeCommandArg arg)
    {
        if (!arg.IsValid()) return null;

        var darkCostume = arg.Entity ?? MasterDb.EntityMCostumeTable.FindByCostumeId(arg.EntityId);
        if (darkCostume == null) return null;

        MasterDb.EntityMCatalogCostumeTable.TryFindByCostumeId(darkCostume.CostumeId, out var costumeCatalog);
        var termCatalog = MasterDb.EntityMCatalogTermTable.FindByCatalogTermId(costumeCatalog?.CatalogTermId ?? 0);

        if (termCatalog != null)
        {
            if (arg.FromDate > CalculatorDateTime.FromUnixTime(termCatalog.StartDatetime)) return null;
            if (arg.ToDate < CalculatorDateTime.FromUnixTime(termCatalog.StartDatetime)) return null;
        }

        return new Costume
        {
            Name = CalculatorCostume.CostumeName(darkCostume.CostumeId),
            AssetId = CalculatorCostume.ActorAssetId(darkCostume.CostumeId).StringId,
            Level = CalculatorCostume.GetMaxLevel(darkCostume, Config.GetCostumeLimitBreakAvailableCount(), Config.GetCharacterRebirthAvailableCount()),
            RarityType = darkCostume.RarityType,
            WeaponType = darkCostume.SkillfulWeaponType,
            ReleaseDateTimeOffset = termCatalog != null ? CalculatorDateTime.FromUnixTime(termCatalog.StartDatetime) : DateTimeOffset.MaxValue,
            Stats = await GetCostumeStatsAsync(arg, darkCostume),
            Skill = await GetCostumeSkillAsync(arg, darkCostume),
            Abilities = await GetCostumeAbilitiesAsync(arg, darkCostume),
            Debris = await GetCostumeDebrisAsync(arg, darkCostume),
            KarmaSlots = await GetCostumeKarmaSlotsAsync(arg, darkCostume)
        };
    }

    private static async Task<List<CostumeStats>> GetCostumeStatsAsync(FetchCostumeCommandArg arg, EntityMCostume darkCostume)
    {
        if (!arg.IncludeStats) return null;

        return await new FetchCostumeStatsCommand().ExecuteAsync(new FetchCostumeStatsCommandArg
        {
            Entity = darkCostume,
            Awakenings = arg.Awakenings
        });
    }

    private static async Task<CostumeSkill> GetCostumeSkillAsync(FetchCostumeCommandArg arg, EntityMCostume darkCostume)
    {
        if (!arg.IncludeSkills) return null;

        return await new FetchCostumeSkillCommand().ExecuteAsync(new FetchCostumeSkillCommandArg
        {
            Entity = darkCostume
        });
    }

    private static async Task<List<CostumeAbility>> GetCostumeAbilitiesAsync(FetchCostumeCommandArg arg, EntityMCostume darkCostume)
    {
        if (!arg.IncludeAbilities) return null;

        return await new FetchCostumeAbilitiesCommand().ExecuteAsync(new FetchCostumeAbilitiesCommandArg
        {
            Entity = darkCostume,
            IncludeAwakenAbility = true
        });
    }

    private static async Task<Debris> GetCostumeDebrisAsync(FetchCostumeCommandArg arg, EntityMCostume darkCostume)
    {
        if (!arg.IncludeDebris) return null;

        return await new FetchDebrisCommand().ExecuteAsync(new FetchDebrisByCostumeCommandArg
        {
            Entity = darkCostume
        });
    }

    private static async Task<List<CostumeKarmaSlot>> GetCostumeKarmaSlotsAsync(FetchCostumeCommandArg arg, EntityMCostume darkCostume)
    {
        if (!arg.IncludeKarmaSlots) return null;

        return await new FetchCostumeKarmaSlotsCommand().ExecuteAsync(new FetchCostumeKarmaSlotsCommandArg
        {
            Entity = darkCostume,
            KarmaSlots = [1, 2, 3],
            KarmaRarityTypes = arg.KarmaRarityTypes
        });
    }
}

public class FetchCostumeCommandArg : AbstractEntityCommandWithDatesArg<EntityMCostume>
{
    public int[] Awakenings { get; init; } = Array.Empty<int>();

    public bool IncludeStats { get; init; } = true;

    public bool IncludeSkills { get; init; } = true;

    public bool IncludeAbilities { get; init; } = true;

    public bool IncludeDebris { get; init; } = true;

    public bool IncludeKarmaSlots { get; init; } = true;

    public RarityType[] KarmaRarityTypes { get; init; } = [RarityType.SS_RARE];

    public override bool IsValid()
    {
        return Entity?.CostumeId < 100000 || (EntityId > 0 && EntityId < 100000);
    }
}
