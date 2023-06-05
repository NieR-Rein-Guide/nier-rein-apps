using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using NierReincarnation.Datamine.Model;

namespace NierReincarnation.Datamine.Command;

public class FetchComanionCommand : AbstractDbQueryCommand<FetchComanionCommandArg, Companion>
{
    public override async Task<Companion> ExecuteAsync(FetchComanionCommandArg arg)
    {
        if (!arg.IsValid()) return null;

        var darkCompanion = arg.Entity ?? MasterDb.EntityMCompanionTable.FindByCompanionId(arg.EntityId);
        if (darkCompanion == null) return null;

        var companionCatalog = MasterDb.EntityMCatalogCompanionTable.FindByCompanionId(darkCompanion.CompanionId);
        var termCatalog = MasterDb.EntityMCatalogTermTable.FindByCatalogTermId(companionCatalog?.CatalogTermId ?? 0);

        if (termCatalog != null)
        {
            if (arg.FromDate > CalculatorDateTime.FromUnixTime(termCatalog.StartDatetime)) return null;
            if (arg.ToDate < CalculatorDateTime.FromUnixTime(termCatalog.StartDatetime)) return null;
        }

        return new Companion
        {
            Name = CalculatorCompanion.CompanionName(darkCompanion.CompanionId),
            AttributeType = darkCompanion.AttributeType,
            ReleaseDateTimeOffset = termCatalog != null ? CalculatorDateTime.FromUnixTime(termCatalog.StartDatetime) : DateTimeOffset.MaxValue,
            Stats = await GetCompanionStatsAsync(arg, darkCompanion),
            Skill = await GetCompanionSkillAsync(arg, darkCompanion),
            Ability = await GetCompanionAbilityAsync(arg, darkCompanion)
        };
    }

    private static async Task<CompanionStats> GetCompanionStatsAsync(FetchComanionCommandArg arg, EntityMCompanion darkCompanion)
    {
        if (!arg.IncludeStats) return null;

        return await new FetchCompanionStatsCommand().ExecuteAsync(new FetchCompanionStatsCommandArg
        {
            Entity = darkCompanion
        });
    }

    private static async Task<CompanionSkill> GetCompanionSkillAsync(FetchComanionCommandArg arg, EntityMCompanion darkCompanion)
    {
        if (!arg.IncludeSkills) return null;

        return await new FetchCompanionSkillCommand().ExecuteAsync(new FetchCompanionSkillCommandArg
        {
            Entity = darkCompanion
        });
    }

    private static async Task<CompanionAbility> GetCompanionAbilityAsync(FetchComanionCommandArg arg, EntityMCompanion darkCompanion)
    {
        if (!arg.IncludeAbilities) return null;

        return await new FetchCompanionAbilityCommand().ExecuteAsync(new FetchCompanionAbilityCommandArg
        {
            Entity = darkCompanion
        });
    }
}

public class FetchComanionCommandArg : AbstractEntityCommandWithDatesArg<EntityMCompanion>
{
    public bool IncludeStats { get; init; } = true;

    public bool IncludeSkills { get; init; } = true;

    public bool IncludeAbilities { get; init; } = true;

    public override bool IsValid()
    {
        return Entity?.CompanionId < 8000000 || (EntityId > 0 && EntityId < 8000000);
    }
}
