using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Networking;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using NierReincarnation.Datamine.Model;

namespace NierReincarnation.Datamine.Command;

public class FetchCostumeSkillCommand : AbstractDbQueryCommand<FetchCostumeSkillCommandArg, CostumeSkill>
{
    public override Task<CostumeSkill> ExecuteAsync(FetchCostumeSkillCommandArg arg)
    {
        if (!arg.IsValid()) return Task.FromResult<CostumeSkill>(null);

        var darkCostume = arg.Entity ?? MasterDb.EntityMCostumeTable.FindByCostumeId(arg.EntityId);
        if (darkCostume == null) return Task.FromResult<CostumeSkill>(null);

        var dataSkill = (DataCostumeSkill)CalculatorCostume.GetCostumeActiveDataSkill(darkCostume.CostumeId,
            CalculatorSkill.MAX_LEVEL, Config.GetCostumeLimitBreakAvailableCount());

        if (dataSkill == null) return Task.FromResult<CostumeSkill>(null);

        return Task.FromResult(new CostumeSkill
        {
            Name = dataSkill.SkillName,
            Description = dataSkill.SkillDescriptionText.Replace("\\n", " "),
            Gauge = dataSkill.GaugeRiseSpeed,
            Cooldown = CalculatorSkill.GetEntityMSkillDetail(CalculatorSkill.GetSkillDetailId(dataSkill.SkillId,
                    CalculatorSkill.MAX_LEVEL)).SkillCooltimeValue
        });
    }
}

public class FetchCostumeSkillCommandArg : AbstractEntityCommandArg<EntityMCostume>
{ }
