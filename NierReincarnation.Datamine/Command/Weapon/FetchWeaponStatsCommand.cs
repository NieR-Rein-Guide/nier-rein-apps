using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Calculator.Database;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Networking;
using NierReincarnation.Core.Dark.Status;
using NierReincarnation.Core.Dark.View.HeadUpDisplay.Calculator;
using NierReincarnation.Datamine.Model;

namespace NierReincarnation.Datamine.Command;

public class FetchWeaponStatsCommand : AbstractDbQueryCommand<FetchWeaponStatsCommandArg, WeaponStats>
{
    public override Task<WeaponStats> ExecuteAsync(FetchWeaponStatsCommandArg arg)
    {
        if (!arg.IsValid()) return Task.FromResult<WeaponStats>(null);

        var darkWeapon = arg.Entity ?? MasterDb.EntityMWeaponTable.FindByWeaponId(arg.EntityId);
        if (darkWeapon == null) return Task.FromResult<WeaponStats>(null);

        var darkWeaponAwaken = MasterDb.EntityMWeaponAwakenTable.FindByWeaponId(darkWeapon.WeaponId);
        DataWeaponStatus status = CalculatorWeapon.GetDataWeaponStatus(darkWeapon, true);
        int maxLmb = Config.GetWeaponLimitBreakAvailableCount();
        status.Level = CalculatorWeapon.GetWeaponMaxLevel(darkWeapon, maxLmb, darkWeaponAwaken?.LevelLimitUp ?? 0);
        StatusValue stats = GetWeaponStatus(status, darkWeapon);

        return Task.FromResult(new WeaponStats
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

    private static StatusValue GetWeaponStatus(DataWeaponStatus status, EntityMWeapon darkWeapon)
    {
        var abilityStatuses = CalculatorMasterData.GetEntityMWeaponAbilityGroupList(darkWeapon.WeaponAbilityGroupId)
            .Select(x => CalculatorAbility.CreateDataAbility(x.AbilityId, x.SlotNumber, status.Level, CalculatorAbility.MAX_LEVEL))
            .Where(x => !x.IsLocked)
            .SelectMany(x => x.AbilityStatusList)
            .ToList();

        return CalculatorStatus.GetWeaponStatus(status, abilityStatuses);
    }
}

public class FetchWeaponStatsCommandArg : AbstractEntityCommandArg<EntityMWeapon>
{ }
