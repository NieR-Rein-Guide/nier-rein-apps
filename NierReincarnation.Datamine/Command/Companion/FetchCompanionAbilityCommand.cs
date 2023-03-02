using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using NierReincarnation.Datamine.Model;

namespace NierReincarnation.Datamine.Command;

public class FetchCompanionAbilityCommand : AbstractDbQueryCommand<FetchCompanionAbilityCommandArg, CompanionAbility>
{
    public override Task<CompanionAbility> ExecuteAsync(FetchCompanionAbilityCommandArg arg)
    {
        if (!arg.IsValid()) return Task.FromResult<CompanionAbility>(null);

        var darkCompanion = arg.Entity ?? MasterDb.EntityMCompanionTable.FindByCompanionId(arg.EntityId);
        if (darkCompanion == null) return Task.FromResult<CompanionAbility>(null);

        var ability = CalculatorCompanion.GetCompanionAbility(darkCompanion, 50);

        return Task.FromResult(new CompanionAbility
        {
            Name = ability.AbilityName,
            Description = ability.AbilityDescriptionText
        });
    }
}

public class FetchCompanionAbilityCommandArg : AbstractEntityCommandArg<EntityMCompanion>
{
    public override bool IsValid()
    {
        return Entity?.CompanionId < 8000000 || (EntityId > 0 && EntityId < 8000000);
    }
}
