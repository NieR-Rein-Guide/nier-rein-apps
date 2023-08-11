namespace NierReincarnation.Core.Dark.Calculator.Outgame;

public static class CalculatorRebirth
{
    public static readonly int kFirstRebirthStep = 0;
    public static readonly int kRebirthStepDelta = 1;
    public static readonly int kMaxMaterialCount = 5;
    public static readonly int kInvalidCharacterRebirthStepGroupId = 0;
    public static readonly int kDefaultLevelLimitUpValue = 0;

    public static int GetRebirthCount(long userId, int characterId)
    {
        var table = DatabaseDefine.User.EntityIUserCharacterRebirthTable;
        var rebirth = table.FindByUserIdAndCharacterId((userId, characterId));

        return rebirth?.RebirthCount ?? kFirstRebirthStep;
    }

    public static int GenerateTotalLevelLimitUpValueByCharacterId(int characterId, int rebirthCount)
    {
        var table = DatabaseDefine.Master.EntityMCharacterRebirthTable;
        foreach (var entry in table.All)
            if (entry.CharacterId == characterId)
                return GenerateTotalLevelLimitUpValue(entry.CharacterRebirthStepGroupId, rebirthCount);

        return kDefaultLevelLimitUpValue;
    }

    public static int GenerateTotalLevelLimitUpValue(int characterRebirthStepGroupId, int rebirthCount)
    {
        if (kFirstRebirthStep == rebirthCount)
            return kDefaultLevelLimitUpValue;

        if (rebirthCount < 1)
            return 0;

        var result = 0;
        var table = DatabaseDefine.Master.EntityMCharacterRebirthStepGroupTable;
        for (var i = 0; i < rebirthCount; i++)
            result += table.FindByCharacterRebirthStepGroupIdAndBeforeRebirthCount((characterRebirthStepGroupId, i)).CostumeLevelLimitUp;

        return result;
    }
}
