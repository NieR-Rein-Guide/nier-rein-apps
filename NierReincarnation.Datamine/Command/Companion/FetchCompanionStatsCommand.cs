using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using NierReincarnation.Datamine.Model;

namespace NierReincarnation.Datamine.Command;

public class FetchCompanionStatsCommand : AbstractDbQueryCommand<FetchCompanionStatsCommandArg, CompanionStats>
{
    public override Task<CompanionStats> ExecuteAsync(FetchCompanionStatsCommandArg arg)
    {
        if (!arg.IsValid()) return Task.FromResult<CompanionStats>(null);

        var darkCompanion = arg.Entity ?? MasterDb.EntityMCompanionTable.FindByCompanionId(arg.EntityId);
        if (darkCompanion == null) return Task.FromResult<CompanionStats>(null);

        var status = CalculatorCompanion.GetDataCompanionStatus(darkCompanion);
        status.Level = 50;

        var ability = CalculatorCompanion.GetCompanionAbility(darkCompanion, status.Level);
        var stats = CalculatorStatus.GetCompanionStatus(status, ability.AbilityStatusList);

        return Task.FromResult(new CompanionStats
        {
            Agility = stats.Agility,
            Attack = stats.Attack,
            Hp = stats.Hp,
            Defense = stats.Vitality,
            CritRate = stats.CriticalRatio / 10,
            CritDamage = stats.CriticalAttack / 10,
            EvasionRate = stats.EvasionRatio / 10
        });
    }
}

public class FetchCompanionStatsCommandArg : AbstractEntityCommandArg<EntityMCompanion>
{
    public override bool IsValid()
    {
        return Entity?.CompanionId < 8000000 || (EntityId > 0 && EntityId < 8000000);
    }
}
