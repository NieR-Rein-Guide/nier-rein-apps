using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator.Database;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Datamine.Model;

namespace NierReincarnation.Datamine.Command;

public class FetchWeaponAbilitiesCommand : AbstractDbQueryCommand<FetchWeaponAbilitiesCommandArg, List<WeaponAbility>>
{
    public override Task<List<WeaponAbility>> ExecuteAsync(FetchWeaponAbilitiesCommandArg arg)
    {
        if (!arg.IsValid()) return Task.FromResult<List<WeaponAbility>>(null);
        var darkWeapon = arg.Entity ?? MasterDb.EntityMWeaponTable.FindByWeaponId(arg.EntityId);
        if (darkWeapon == null) return Task.FromResult<List<WeaponAbility>>(null);

        List<WeaponAbility> weaponAbilities = new();
        foreach (var abilityGroup in CalculatorMasterData.GetEntityMWeaponAbilityGroupList(darkWeapon.WeaponAbilityGroupId).OrderBy(x => x.SlotNumber))
        {
            if (!arg.IncludeBarrierAbility && abilityGroup.SlotNumber == 3) continue;

            var abilityDetail = CalculatorMasterData.GetEntityMAbilityDetail(abilityGroup.AbilityId, CalculatorAbility.MAX_LEVEL);

            if (abilityDetail != null)
            {
                weaponAbilities.Add(new WeaponAbility
                {
                    Name = CalculatorAbility.GetName(abilityDetail.NameAbilityTextId),
                    Description = CalculatorAbility.GetDescriptionLong(abilityDetail.DescriptionAbilityTextId),
                    SlotNumber = abilityGroup.SlotNumber,
                    SourceType = AbilitySourceType.DEFAULT
                });
            }
        }

        if (arg.IncludeAwakenAbility)
        {
            MasterDb.EntityMWeaponAwakenTable.TryFindByWeaponId(darkWeapon.WeaponId, out EntityMWeaponAwaken darkWeaponAwaken);

            if (darkWeaponAwaken != null)
            {
                var darkWeaponAwakenEffectGroup = MasterDb.EntityMWeaponAwakenEffectGroupTable
                    .FindByWeaponAwakenEffectGroupIdAndWeaponAwakenEffectType((darkWeaponAwaken.WeaponAwakenEffectGroupId, (int)CostumeAwakenEffectType.ABILITY));

                var awakenAbility = MasterDb.EntityMWeaponAwakenAbilityTable.FindByWeaponAwakenAbilityId(darkWeaponAwakenEffectGroup.WeaponAwakenEffectId);

                if (awakenAbility != null)
                {
                    var awakenAbilityDetail = CalculatorMasterData.GetEntityMAbilityDetail(awakenAbility.AbilityId, awakenAbility.AbilityLevel);

                    if (awakenAbilityDetail != null)
                    {
                        weaponAbilities.Add(new WeaponAbility
                        {
                            Name = CalculatorAbility.GetName(awakenAbilityDetail.NameAbilityTextId),
                            Description = CalculatorAbility.GetDescriptionLong(awakenAbilityDetail.DescriptionAbilityTextId),
                            SlotNumber = weaponAbilities.Count + 1,
                            SourceType = AbilitySourceType.AWAKEN
                        });
                    }
                }
            }
        }

        return Task.FromResult(weaponAbilities);
    }
}

public class FetchWeaponAbilitiesCommandArg : AbstractEntityCommandArg<EntityMWeapon>
{
    public bool IncludeBarrierAbility { get; init; } = true;

    public bool IncludeAwakenAbility { get; init; } = true;
}
