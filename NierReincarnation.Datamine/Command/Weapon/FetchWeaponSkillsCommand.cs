using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator.Database;
using NierReincarnation.Core.Dark.View.HeadUpDisplay.Calculator;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using NierReincarnation.Datamine.Model;

namespace NierReincarnation.Datamine.Command;

public class FetchWeaponSkillsCommand : AbstractDbQueryCommand<FetchWeaponSkillsCommandArg, List<WeaponSkill>>
{
    public override Task<List<WeaponSkill>> ExecuteAsync(FetchWeaponSkillsCommandArg arg)
    {
        if (!arg.IsValid()) return Task.FromResult<List<WeaponSkill>>(null);

        var darkWeapon = arg.Entity ?? MasterDb.EntityMWeaponTable.FindByWeaponId(arg.EntityId);
        if (darkWeapon == null) return Task.FromResult<List<WeaponSkill>>(null);

        List<WeaponSkill> weaponSkills = new();
        var evolution = CalculatorWeapon.GetWeaponEvolutionGroupIdAndEvolutionOrder(darkWeapon.WeaponId);
        var skillGroups = CalculatorMasterData.GetEntityMWeaponSkillGroups(darkWeapon.WeaponSkillGroupId).OrderBy(x => x.SlotNumber);

        foreach (var skillGroup in skillGroups)
        {
            var skill = CalculatorSkill.CreateDataWeaponSkill(skillGroup.SkillId, CalculatorSkill.MAX_LEVEL, CalculatorSkill.MAX_LEVEL, evolution.Item2, skillGroup.SlotNumber);

            if (skill != null)
            {
                weaponSkills.Add(new WeaponSkill
                {
                    Name = skill.SkillName,
                    Description = skill.SkillDescriptionText,
                    SlotNumber = skill.SlotNumber,
                    Cooldown = CalculatorSkill.GetEntityMSkillDetail(CalculatorSkill.GetSkillDetailId(skill.SkillId, CalculatorSkill.MAX_LEVEL)).SkillCooltimeValue / 30
                });
            }
        }

        return Task.FromResult(weaponSkills);
    }
}

public class FetchWeaponSkillsCommandArg : AbstractEntityCommandArg<EntityMWeapon>
{ }
