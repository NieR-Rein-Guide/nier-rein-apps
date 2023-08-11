using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Status;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Calculator;

public static class CalculatorDataCostumeAwakenStatus
{
    public static bool CreateCostumeAwakenStatusList(long userId, string costumeUuid, List<DataCostumeAwakenStatus> costumeAwakenStatusList)
    {
        var result = false;
        if (DatabaseDefine.User.EntityIUserCostumeAwakenStatusUpTable.TryFindByUserIdAndUserCostumeUuidAndStatusCalculationType((userId, costumeUuid, StatusCalculationType.ADD), out var userCostumeAwakenStatusUp))
        {
            costumeAwakenStatusList.Add(CreateDataCostumeAwakenStatus(userCostumeAwakenStatusUp));
            result = true;
        }

        if (DatabaseDefine.User.EntityIUserCostumeAwakenStatusUpTable.TryFindByUserIdAndUserCostumeUuidAndStatusCalculationType((userId, costumeUuid, StatusCalculationType.MULTIPLY), out userCostumeAwakenStatusUp))
        {
            costumeAwakenStatusList.Add(CreateDataCostumeAwakenStatus(userCostumeAwakenStatusUp));
            result = true;
        }

        return result;
    }

    private static DataCostumeAwakenStatus CreateDataCostumeAwakenStatus(EntityIUserCostumeAwakenStatusUp entity)
    {
        return CreateDataCostumeAwakenStatus(entity.Agility, entity.Attack, entity.CriticalAttack, entity.CriticalRatio, 0, entity.Hp, entity.Vitality, entity.StatusCalculationType);
    }

    public static DataCostumeAwakenStatus CreateDataCostumeAwakenStatus(int agility, int attack, int criticalAttack,
        int criticalRatio, int evasionRatio, int hp, int vitality, StatusCalculationType statusCalculationType)
    {
        return new DataCostumeAwakenStatus
        {
            StatusCalculationType = statusCalculationType,
            StatusChangeValue = new StatusValue(agility, attack, criticalAttack, criticalRatio, evasionRatio, hp, vitality)
        };
    }
}
