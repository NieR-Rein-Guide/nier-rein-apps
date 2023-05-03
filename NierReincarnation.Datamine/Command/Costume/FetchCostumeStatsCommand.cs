using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Networking;
using NierReincarnation.Core.Dark.Status;
using NierReincarnation.Datamine.Model;

namespace NierReincarnation.Datamine.Command;

public class FetchCostumeStatsCommand : AbstractDbQueryCommand<FetchCostumeStatsCommandArg, List<CostumeStats>>
{
    public override Task<List<CostumeStats>> ExecuteAsync(FetchCostumeStatsCommandArg arg)
    {
        if (!arg.IsValid()) return Task.FromResult<List<CostumeStats>>(null);

        var darkCostume = arg.Entity ?? MasterDb.EntityMCostumeTable.FindByCostumeId(arg.EntityId);
        if (darkCostume == null) return Task.FromResult<List<CostumeStats>>(null);

        List<CostumeStats> costumeStats = new();
        MasterDb.EntityMCostumeAwakenTable.TryFindByCostumeId(darkCostume.CostumeId, out EntityMCostumeAwaken darkCostumeAwaken);
        var darkCostumeAwakenEffectGroups = MasterDb.EntityMCostumeAwakenEffectGroupTable
            .FindByCostumeAwakenEffectGroupIdAndCostumeAwakenEffectType((darkCostumeAwaken.CostumeAwakenEffectGroupId, CostumeAwakenEffectType.STATUS_UP));
        DataCostumeStatus status = CalculatorCostume.GetDataCostumeStatus(darkCostume);
        int maxLmb = Config.GetCostumeLimitBreakAvailableCount();
        status.Level = CalculatorCostume.GetMaxLevel(darkCostume, maxLmb, Config.GetCharacterRebirthAvailableCount());

        DataAbility[] abilities = CalculatorCostume.CreateCostumeDataAbilityList(darkCostume.CostumeAbilityGroupId, maxLmb);
        DataAbility[] awakenAbilities = GetCostumeAwakenAbilities(darkCostume, abilities);

        // Base
        StatusValue baseStats = GetBaseStatus(status);
        costumeStats.Add(new CostumeStats
        {
            Agility = baseStats.Agility,
            Attack = baseStats.Attack,
            Hp = baseStats.Hp,
            Defense = baseStats.Vitality,
            CritRate = baseStats.CriticalRatio / 10,
            CritDamage = baseStats.CriticalAttack / 10,
            EvasionRate = baseStats.EvasionRatio / 10
        });

        // Awakening
        foreach (int i in arg.Awakenings)
        {
            List<DataAbilityStatus> abilityStatus = (i > 2 ? awakenAbilities : abilities).Where(x => !x.IsLocked).SelectMany(x => x.AbilityStatusList).ToList();
            StatusValue stats = CalculatorStatus.GetCostumeStatus(status, null, null, abilityStatus, null, null, null, null, 0);

            decimal awakeningMultiplier = darkCostumeAwakenEffectGroups
                    .Where(x => x.AwakenStep <= i)
                    .Select(x => MasterDb.EntityMCostumeAwakenStatusUpGroupTable.All.FirstOrDefault(y => y.CostumeAwakenStatusUpGroupId == x.CostumeAwakenEffectId))
                    .Sum(x => x.EffectValue) / 1000M;

            StatusValue awakeningStats = GetAwakeningStatus(baseStats, awakeningMultiplier);

            costumeStats.Add(new CostumeStats
            {
                Awakenings = i,
                Agility = (stats + awakeningStats).Agility,
                Attack = (stats + awakeningStats).Attack,
                Hp = (stats + awakeningStats).Hp,
                Defense = (stats + awakeningStats).Vitality,
                CritRate = (stats + awakeningStats).CriticalRatio / 10,
                CritDamage = (stats + awakeningStats).CriticalAttack / 10,
                EvasionRate = (stats + awakeningStats).EvasionRatio / 10
            });
        }

        return Task.FromResult(costumeStats);
    }

    private static StatusValue GetBaseStatus(DataCostumeStatus status)
    {
        CalculatorStatus.GetCostumeBaseStatus(status, out int agility, out int attack, out int criticalAttack, out int criticalRatio, out int evasionRatio, out int hp, out int vitality);

        return new StatusValue(agility, attack, criticalAttack, criticalRatio, evasionRatio, hp, vitality);
    }

    private static StatusValue GetAwakeningStatus(StatusValue baseStatus, decimal awakeningMultiplier)
    {
        return new StatusValue
        {
            Attack = (int)(baseStatus.Attack * awakeningMultiplier),
            Hp = (int)(baseStatus.Hp * awakeningMultiplier),
            Vitality = (int)(baseStatus.Vitality * awakeningMultiplier)
        };
    }

    private DataAbility[] GetCostumeAwakenAbilities(EntityMCostume darkCostume, DataAbility[] abilities)
    {
        DataAbility[] awakenAbilities = new DataAbility[abilities.Length];
        Array.Copy(abilities, awakenAbilities, abilities.Length);

        if (MasterDb.EntityMCostumeAwakenAbilityTable.TryFindByCostumeAwakenAbilityId(darkCostume.CostumeId, out EntityMCostumeAwakenAbility awakenAbility))
        {
            Array.Resize(ref awakenAbilities, awakenAbilities.Length + 1);
            awakenAbilities[^1] = CalculatorAbility.CreateDataAbility(awakenAbility.AbilityId, awakenAbility.AbilityLevel, awakenAbility.AbilityLevel);
        }

        return awakenAbilities;
    }
}

public class FetchCostumeStatsCommandArg : AbstractEntityCommandArg<EntityMCostume>
{
    public int[] Awakenings { get; init; } = Array.Empty<int>();

    public override bool IsValid()
    {
        return base.IsValid() && Awakenings.All(x => x >= 0 && x <= 5);
    }
}
