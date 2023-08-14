using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using NierReincarnation.Datamine.Model;

namespace NierReincarnation.Datamine.Command;

public class FetchCompanionSkillCommand : AbstractDbQueryCommand<FetchCompanionSkillCommandArg, CompanionSkill>
{
    public override Task<CompanionSkill> ExecuteAsync(FetchCompanionSkillCommandArg arg)
    {
        if (!arg.IsValid()) return Task.FromResult<CompanionSkill>(null);

        var darkCompanion = arg.Entity ?? MasterDb.EntityMCompanionTable.FindByCompanionId(arg.EntityId);
        if (darkCompanion == null) return Task.FromResult<CompanionSkill>(null);

        var skill = CalculatorCompanion.GetCompanionSkill(darkCompanion.SkillId, 50);

        return Task.FromResult(new CompanionSkill
        {
            Name = skill.SkillName,
            Description = skill.SkillDescriptionText,
            Cooldown = CalculatorSkill.GetEntityMSkillDetail(CalculatorSkill.GetSkillDetailId(skill.SkillId, skill.SkillLevel)).SkillCooltimeValue / 30
        });
    }
}

public class FetchCompanionSkillCommandArg : AbstractEntityCommandArg<EntityMCompanion>
{
    public override bool IsValid()
    {
        return Entity?.CompanionId < 8000000 || (EntityId > 0 && EntityId < 8000000);
    }
}
