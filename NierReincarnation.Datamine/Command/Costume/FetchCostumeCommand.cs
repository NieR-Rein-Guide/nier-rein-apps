using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator.Outgame;
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

        if (!MasterDb.EntityMCatalogCostumeTable.TryFindByCostumeId(darkCostume.CostumeId, out var costumeCatalog)) return null;
        var termCatalog = MasterDb.EntityMCatalogTermTable.FindByCatalogTermId(costumeCatalog.CatalogTermId);

        if (arg.FromDate > CalculatorDateTime.FromUnixTime(termCatalog.StartDatetime)) return null;
        if (arg.ToDate < CalculatorDateTime.FromUnixTime(termCatalog.StartDatetime)) return null;

        return new Costume
        {
            Name = CalculatorCostume.CostumeName(darkCostume.CostumeId),
            AssetId = CalculatorCostume.ActorAssetId(darkCostume.CostumeId).StringId,
            Level = CalculatorCostume.GetMaxLevel(darkCostume, Config.GetCostumeLimitBreakAvailableCount()),
            RarityType = darkCostume.RarityType,
            WeaponType = darkCostume.SkillfulWeaponType,
            ReleaseDateTimeOffset = CalculatorDateTime.FromUnixTime(termCatalog.StartDatetime),
            Stats = await GetCostumeStatsAsync(arg, darkCostume),
            Skill = await GetCostumeSkillAsync(arg, darkCostume),
            Abilities = await GetCostumeAbilitiesAsync(arg, darkCostume),
            Debris = await GetCostumeDebrisAsync(arg, darkCostume)
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
}

public class FetchCostumeCommandArg : AbstractEntityCommandWithDatesArg<EntityMCostume>
{
    public int[] Awakenings { get; init; } = Array.Empty<int>();

    public bool IncludeStats { get; init; } = true;

    public bool IncludeSkills { get; init; } = true;

    public bool IncludeAbilities { get; init; } = true;

    public bool IncludeDebris { get; init; } = true;

    public override bool IsValid()
    {
        return Entity?.CostumeId < 100000 || (EntityId > 0 && EntityId < 100000);
    }
}
