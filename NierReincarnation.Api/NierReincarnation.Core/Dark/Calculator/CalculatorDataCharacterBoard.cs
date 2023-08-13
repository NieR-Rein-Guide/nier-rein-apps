using NierReincarnation.Core.Dark.Status;

namespace NierReincarnation.Core.Dark.Calculator;

public static class CalculatorDataCharacterBoard
{
    public static List<EntityIUserCharacterBoardAbility> CreateUserCharacterBoardAbilities(long userId, int characterId)
    {
        var result = new List<EntityIUserCharacterBoardAbility>();

        var table = DatabaseDefine.User.EntityIUserCharacterBoardAbilityTable;
        foreach (var element in table.All)
        {
            if (element.UserId == userId && element.CharacterId == characterId)
                result.Add(element);
        }

        return result;
    }

    public static bool CreateCharacterBoardStatusList(long userId, int characterId, List<DataCharacterBoardStatus> characterBoardStatusList)
    {
        var table = DatabaseDefine.User.EntityIUserCharacterBoardStatusUpTable;
        var range = table.FindRangeByUserIdAndCharacterIdAndStatusCalculationType(
            (userId, characterId, (StatusCalculationType)int.MinValue),
            (userId, characterId, (StatusCalculationType)int.MaxValue));

        foreach (var item in range)
        {
            if (item.UserId != userId || item.CharacterId != characterId)
                continue;

            characterBoardStatusList.Add(CreateDataCharacterBoardStatus(item));
        }

        return true;
    }

    private static DataCharacterBoardStatus CreateDataCharacterBoardStatus(EntityIUserCharacterBoardStatusUp entity)
    {
        return CreateDataCharacterBoardStatus(entity.Agility, entity.Attack, entity.Hp, entity.Vitality, entity.CriticalAttack, entity.CriticalRatio, entity.StatusCalculationType);
    }

    public static DataCharacterBoardStatus CreateDataCharacterBoardStatus(int agility, int attack, int hp, int vitality, int criticalAttack, int criticalRatio, StatusCalculationType statusCalculationType)
    {
        return new DataCharacterBoardStatus
        {
            StatusCalculationType = statusCalculationType,
            StatusChangeValue = new StatusValue(agility, attack, criticalAttack, criticalRatio, 0, hp, vitality)
        };
    }
}
