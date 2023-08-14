using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator.Database;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using NierReincarnation.Datamine.Model;

namespace NierReincarnation.Datamine.Command;

public class FetchDebrisCommand : AbstractDbQueryCommand<IFetchDebrisCommandArg, Debris>
{
    public override Task<Debris> ExecuteAsync(IFetchDebrisCommandArg arg)
    {
        return Task.FromResult(arg switch
        {
            FetchDebrisByCostumeCommandArg costumeArg => GetByCostume(costumeArg),
            FetchDebrisByDebrisCommandArg debrisArg => GetByDebris(debrisArg),
            _ => null
        });
    }

    private Debris GetByDebris(FetchDebrisByDebrisCommandArg arg, DebrisSourceType debrisSource = DebrisSourceType.UNKNOWN, string unlockCondition = "")
    {
        if (!arg.IsValid()) return null;

        var darkDebris = arg.Entity;

        if (darkDebris == null)
        {
            MasterDb.EntityMThoughtTable.TryFindByThoughtId(arg.EntityId, out darkDebris);
        }

        if (darkDebris == null) return null;

        var darkDebrisCatalog = MasterDb.EntityMCatalogThoughtTable.All.FirstOrDefault(x => x.ThoughtId == darkDebris.ThoughtId);
        var termCatalog = MasterDb.EntityMCatalogTermTable.FindByCatalogTermId(darkDebrisCatalog?.CatalogTermId ?? 0);

        if (termCatalog != null)
        {
            if (arg.FromDate > CalculatorDateTime.FromUnixTime(termCatalog.StartDatetime)) return null;
            if (arg.ToDate < CalculatorDateTime.FromUnixTime(termCatalog.StartDatetime)) return null;
        }

        var abilityDetail = CalculatorMasterData.GetEntityMAbilityDetail(darkDebris.AbilityId, darkDebris.AbilityLevel);

        if (abilityDetail == null) return null;

        Debris debris = new()
        {
            Name = CalculatorAbility.GetName(abilityDetail.NameAbilityTextId).Replace("Debris: ", string.Empty).Trim(),
            Description = CalculatorAbility.GetDescriptionLong(abilityDetail.DescriptionAbilityTextId),
            SourceType = debrisSource,
            UnlockCondition = unlockCondition
        };

        if (debrisSource == DebrisSourceType.UNKNOWN)
        {
            (DebrisSourceType SourceType, string UnlockCondition) = GetExtraDebrisInfo(darkDebris.ThoughtId);

            debris.SourceType = SourceType;
            debris.UnlockCondition = UnlockCondition;
        }

        return debris;
    }

    private Debris GetByCostume(FetchDebrisByCostumeCommandArg arg)
    {
        if (!arg.IsValid()) return null;

        var darkCostume = arg.Entity ?? MasterDb.EntityMCostumeTable.FindByCostumeId(arg.EntityId);
        if (darkCostume == null) return null;

        MasterDb.EntityMCostumeAwakenTable.TryFindByCostumeId(darkCostume.CostumeId, out EntityMCostumeAwaken darkCostumeAwaken);
        var darkCostumeAwakenEffectGroup = MasterDb.EntityMCostumeAwakenEffectGroupTable
            .FindByCostumeAwakenEffectGroupIdAndCostumeAwakenEffectType((darkCostumeAwaken.CostumeAwakenEffectGroupId, CostumeAwakenEffectType.ITEM_ACQUIRE));
        if (darkCostumeAwakenEffectGroup.Count == 0) return null;

        MasterDb.EntityMThoughtTable.TryFindByThoughtId(darkCostumeAwakenEffectGroup[0].CostumeAwakenEffectId, out var darkDebris);

        return GetByDebris(new FetchDebrisByDebrisCommandArg
        {
            Entity = darkDebris
        },
        DebrisSourceType.COSTUME,
        CalculatorCostume.CostumeName(darkCostume.CostumeId));
    }

    private (DebrisSourceType SourceType, string UnlockCondition) GetExtraDebrisInfo(int thoughtId)
    {
        var darkCostumeAwakenEffectGroup = MasterDb.EntityMCostumeAwakenEffectGroupTable.All
            .FirstOrDefault(x => x.CostumeAwakenEffectType == CostumeAwakenEffectType.ITEM_ACQUIRE && x.CostumeAwakenEffectId == thoughtId);

        // Costume
        if (darkCostumeAwakenEffectGroup != null)
        {
            var darkCostumeAwaken = MasterDb.EntityMCostumeAwakenTable.All.FirstOrDefault(x => x.CostumeAwakenEffectGroupId == darkCostumeAwakenEffectGroup.CostumeAwakenEffectGroupId);
            return darkCostumeAwaken != null
                ? (DebrisSourceType.COSTUME, CalculatorCostume.CostumeName(darkCostumeAwaken.CostumeId))
                : (DebrisSourceType.UNKNOWN, string.Empty);
        }
        // Mission
        else
        {
            var darkMissionReward = MasterDb.EntityMMissionRewardTable.All.FirstOrDefault(x => x.PossessionId == thoughtId);
            var darkMission = MasterDb.EntityMMissionTable.All.FirstOrDefault(x => x.MissionRewardId == darkMissionReward?.MissionRewardId);

            return darkMission != null
                ? (DebrisSourceType.MISSION, $"mission.name.{darkMission.NameMissionTextId}".Localize())
                : (DebrisSourceType.UNKNOWN, string.Empty);
        }
    }
}

public interface IFetchDebrisCommandArg
{ }

public class FetchDebrisByCostumeCommandArg : AbstractEntityCommandArg<EntityMCostume>, IFetchDebrisCommandArg
{
    public override bool IsValid()
    {
        return Entity?.CostumeId < 100000 || (EntityId > 0 && EntityId < 100000);
    }
}

public class FetchDebrisByDebrisCommandArg : AbstractEntityCommandWithDatesArg<EntityMThought>, IFetchDebrisCommandArg
{
}
