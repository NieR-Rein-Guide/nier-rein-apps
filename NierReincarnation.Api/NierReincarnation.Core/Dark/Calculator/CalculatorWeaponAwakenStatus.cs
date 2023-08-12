using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Status;

namespace NierReincarnation.Core.Dark.Calculator;

public static class CalculatorWeaponAwakenStatus
{
    public static readonly int kStatusDataListCapacity = 2;

    public static void CreateDataWeaponAwakenStatusList(int weaponAwakenEffectGroupId, List<DataWeaponAwakenStatus> weaponAwakenStatusList)
    {
        EntityMWeaponAwakenStatusUpGroup[] weaponAwakenStatusUps = Database.CalculatorMasterData.GetEntityMWeaponAwakenStatusUpGroupsByEffectGroupId(weaponAwakenEffectGroupId: weaponAwakenEffectGroupId);

        if (weaponAwakenStatusUps.Length == 0) return;

        DataWeaponAwakenStatus multiStatus = CreateDataWeaponAwakenStatus(weaponAwakenStatusUps, StatusCalculationType.MULTIPLY);
        if (multiStatus != null)
        {
            weaponAwakenStatusList.Add(multiStatus);
        }

        DataWeaponAwakenStatus addStatus = CreateDataWeaponAwakenStatus(weaponAwakenStatusUps, StatusCalculationType.ADD);
        if (addStatus != null)
        {
            weaponAwakenStatusList.Add(addStatus);
        }
    }

    private static DataWeaponAwakenStatus CreateDataWeaponAwakenStatus(EntityMWeaponAwakenStatusUpGroup[] entityMWeaponAwakenStatusUps, StatusCalculationType calculationType)
    {
        StatusValue statusValue = new();

        foreach (var entityMWeaponAwakenStatusUp in entityMWeaponAwakenStatusUps)
        {
            if (entityMWeaponAwakenStatusUp.StatusCalculationType == calculationType)
            {
                AddWeaponAwakenStatusValue(ref statusValue, entityMWeaponAwakenStatusUp.EffectValue, entityMWeaponAwakenStatusUp.StatusKindType);
            }
        }

        return new DataWeaponAwakenStatus
        {
            StatusCalculationType = calculationType,
            StatusChangeValue = statusValue
        };
    }

    private static void AddWeaponAwakenStatusValue(ref StatusValue statusValue, int effectValue, StatusKindType statusKindType)
    {
        switch (statusKindType)
        {
            case StatusKindType.AGILITY:
                statusValue.Agility += effectValue;
                break;

            case StatusKindType.ATTACK:
                statusValue.Attack += effectValue;
                break;

            case StatusKindType.CRITICAL_ATTACK:
                statusValue.CriticalAttack += effectValue;
                break;

            case StatusKindType.CRITICAL_RATIO:
                statusValue.CriticalRatio += effectValue;
                break;

            case StatusKindType.HP:
                statusValue.Hp += effectValue;
                break;

            case StatusKindType.VITALITY:
                statusValue.Vitality += effectValue;
                break;
        }
    }
}
