using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator.Database;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Datamine.Model;

namespace NierReincarnation.Datamine.Command;

public class FetchCostumeAbilitiesCommand : AbstractDbQueryCommand<FetchCostumeAbilitiesCommandArg, List<CostumeAbility>>
{
    public override Task<List<CostumeAbility>> ExecuteAsync(FetchCostumeAbilitiesCommandArg arg)
    {
        if (!arg.IsValid()) return Task.FromResult<List<CostumeAbility>>(null);

        var darkCostume = arg.Entity ?? MasterDb.EntityMCostumeTable.FindByCostumeId(arg.EntityId);
        if (darkCostume == null) return Task.FromResult<List<CostumeAbility>>(null);

        List<CostumeAbility> costumeAbilities = new();
        foreach (var abilityGroup in CalculatorMasterData.GetEntityCostumeAbilityGroupList(darkCostume.CostumeAbilityGroupId).OrderBy(x => x.SlotNumber))
        {
            var abilityDetail = CalculatorMasterData.GetEntityMAbilityDetail(abilityGroup.AbilityId, CalculatorAbility.MAX_LEVEL);

            if (abilityDetail != null)
            {
                costumeAbilities.Add(new CostumeAbility
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
            MasterDb.EntityMCostumeAwakenTable.TryFindByCostumeId(darkCostume.CostumeId, out EntityMCostumeAwaken darkCostumeAwaken);
            var darkCostumeAwakenEffectGroups = MasterDb.EntityMCostumeAwakenEffectGroupTable
                .FindByCostumeAwakenEffectGroupIdAndCostumeAwakenEffectType((darkCostumeAwaken.CostumeAwakenEffectGroupId, CostumeAwakenEffectType.ABILITY))
                .OrderBy(x => x.AwakenStep);

            foreach (var darkCostumeAwakenEffectGroup in darkCostumeAwakenEffectGroups)
            {
                if (MasterDb.EntityMCostumeAwakenAbilityTable.TryFindByCostumeAwakenAbilityId(darkCostumeAwakenEffectGroup.CostumeAwakenEffectId, out EntityMCostumeAwakenAbility awakenAbility))
                {
                    var awakenAbilityDetail = CalculatorMasterData.GetEntityMAbilityDetail(awakenAbility.AbilityId, awakenAbility.AbilityLevel);

                    if (awakenAbilityDetail != null)
                    {
                        costumeAbilities.Add(new CostumeAbility
                        {
                            Name = CalculatorAbility.GetName(awakenAbilityDetail.NameAbilityTextId),
                            Description = CalculatorAbility.GetDescriptionLong(awakenAbilityDetail.DescriptionAbilityTextId),
                            SlotNumber = costumeAbilities.Count + 1,
                            SourceType = AbilitySourceType.AWAKEN
                        });
                    }
                }
            }
        }

        return Task.FromResult(costumeAbilities);
    }
}

public class FetchCostumeAbilitiesCommandArg : AbstractEntityCommandArg<EntityMCostume>
{
    public bool IncludeAwakenAbility { get; init; } = true;
}
