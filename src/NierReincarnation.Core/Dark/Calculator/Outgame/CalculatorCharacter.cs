using NierReincarnation.Core.Dark.Calculator.Database;
using NierReincarnation.Core.Dark.Localization;

namespace NierReincarnation.Core.Dark.Calculator.Outgame;

public static class CalculatorCharacter
{
    private static readonly int kInvalidQuestId;
    public static readonly int kInvalidCharacterId;

    public static string GetCharacterName(int characterId)
    {
        return CharacterName(characterId);
    }

    public static string GetCharacterSymbolName(long userId, int characterId)
    {
        var characterDisplaySwitch = CalculatorMasterData.GetEntityMCharacterDisplaySwitch(characterId);

        if (characterDisplaySwitch != null && CalculatorQuest.IsClearQuest(characterDisplaySwitch.DisplayConditionClearQuestId, userId))
        {
            return GetSymbolName(characterDisplaySwitch.NameCharacterTextId);
        }

        var character = CalculatorMasterData.GetEntityMCharacter(characterId);

        return character != null
            ? GetSymbolName(character.NameCharacterTextId)
            : null;
    }

    public static bool HasCharacter(int characterId) => HasCharacter(CalculatorStateUser.GetUserId(), characterId);

    public static int GetCharacterSortOrder(int characterId)
    {
        var character = CalculatorMasterData.GetEntityMCharacter(characterId);

        return (character?.SortOrder) ?? 0;
    }

    public static bool HasCharacter(long userId, int characterId) =>
        DatabaseDefine.User.EntityIUserCharacterTable.TryFindByUserIdAndCharacterId((userId, characterId), out var _);

    public static ValueTuple<int, int> GetCharacterRankExp(int characterId) =>
        (CalculatorCharacterRank.GetCharacterRank(characterId), CalculatorCharacterRank.GetCurrentRankExp(characterId));

    public static int GetDefaultCostumeId(int characterId)
    {
        var characterDisplaySwitch = CalculatorMasterData.GetEntityMCharacterDisplaySwitch(characterId);

        if (characterDisplaySwitch != null && CalculatorQuest.IsClearQuest(characterDisplaySwitch.DisplayConditionClearQuestId, CalculatorStateUser.GetUserId()))
        {
            return characterDisplaySwitch.DefaultCostumeId;
        }

        var character = CalculatorMasterData.GetEntityMCharacter(characterId);

        return (character?.DefaultCostumeId) ?? 0;
    }

    public static int GetCharacterAssetId(int characterId)
    {
        var characterDisplaySwitch = CalculatorMasterData.GetEntityMCharacterDisplaySwitch(characterId);

        if (characterDisplaySwitch != null && CalculatorQuest.IsClearQuest(characterDisplaySwitch.DisplayConditionClearQuestId, CalculatorStateUser.GetUserId()))
        {
            return characterDisplaySwitch.CharacterAssetId;
        }

        var character = CalculatorMasterData.GetEntityMCharacter(characterId);

        return (character?.CharacterAssetId) ?? 0;
    }

    public static int GetDefaultWeaponId(int characterId)
    {
        var characterDisplaySwitch = CalculatorMasterData.GetEntityMCharacterDisplaySwitch(characterId);

        if (characterDisplaySwitch != null && CalculatorQuest.IsClearQuest(characterDisplaySwitch.DisplayConditionClearQuestId, CalculatorStateUser.GetUserId()))
        {
            return characterDisplaySwitch.DefaultWeaponId;
        }

        var character = CalculatorMasterData.GetEntityMCharacter(characterId);

        return (character?.DefaultWeaponId) ?? 0;
    }

    public static int GetEndCostumeId(int characterId)
    {
        var character = CalculatorMasterData.GetEntityMCharacter(characterId);

        return (character?.EndCostumeId) ?? 0;
    }

    public static int GetEndWeaponId(int characterId)
    {
        var character = CalculatorMasterData.GetEntityMCharacter(characterId);

        return (character?.EndWeaponId) ?? 0;
    }

    public static List<string> GetUnlockVoicePaths(int characterId)
    {
        throw new NotImplementedException();
    }

    public static string GetUnlockVoiceText(int characterId)
    {
        throw new NotImplementedException();
    }

    public static bool TryGetCharacterIdFromEventQuestChapterId(int eventQuestChapterId, out int resultCharacterId)
    {
        resultCharacterId = 0;

        if (eventQuestChapterId > 0)
        {
            var eventQuestChapterCharacter = DatabaseDefine.Master.EntityMEventQuestChapterCharacterTable.FindByEventQuestChapterId(eventQuestChapterId);
            resultCharacterId = eventQuestChapterCharacter.CharacterId;
            return true;
        }

        return false;
    }

    private static string GetUnlockVoiceText(CharacterVoiceUnlockConditionType conditionType, int conditionValue)
    {
        if (conditionType != CharacterVoiceUnlockConditionType.QUEST_CLEAR)
        {
            return string.Empty;
        }

        return CalculatorUnlockCondition.GetMainQuestChapterClearUnlockText(CalculatorQuest.GetMainQuestChapterNameByQuestId(conditionValue));
    }

    private static bool IsUnlockVoice(CharacterVoiceUnlockConditionType conditionType, int conditionValue)
    {
        return conditionType == CharacterVoiceUnlockConditionType.QUEST_CLEAR && conditionValue != kInvalidQuestId
            ? CalculatorQuest.IsClearQuest(conditionValue, CalculatorStateUser.GetUserId())
            : conditionType == CharacterVoiceUnlockConditionType.NONE;
    }

    // TODO: Hard-coded language code
    private static string ConvertVoicePath(int characterId, int voiceOrder)
    {
        var characterVoiceUnlock = DatabaseDefine.Master.EntityMCharacterVoiceUnlockConditionTable.FindByCharacterIdAndSortOrder((characterId, voiceOrder));

        return $"voice)en)outgame){characterVoiceUnlock.VoiceAssetId:D5})pfv_0000_0010g_{voiceOrder:D5}_{characterVoiceUnlock.VoiceAssetId:D5}_1";
    }

    //public static DataOutgameCharacter CreateDataOutgameCharacter(int characterId)
    //{
    //    throw new NotImplementedException();
    //}

    public static bool IsOrganizedCharacter(DataDeck dataDeck, int characterId)
    {
        throw new NotImplementedException();
    }

    public static List<int> GetUserCharacterIdList()
    {
        return DatabaseDefine.User.EntityIUserCharacterTable.All
            .Select(x => x.CharacterId)
            .ToList();
    }

    private static string GetSymbolName(int nameTextId) => $"character.symbol.{nameTextId}".Localize();

    private static string GetName(int nameTextId) => $"character.name.{nameTextId}".Localize();

    // CUSTOM: Ignore display switch for character name
    public static string CharacterName(int characterId, bool ignoreDisplaySwitch = false)
    {
        var userId = CalculatorStateUser.GetUserId();

        if (!ignoreDisplaySwitch)
        {
            var displaySwitch = CalculatorMasterData.GetEntityMCharacterDisplaySwitch(characterId);
            if (displaySwitch != null)
            {
                var clearCond = displaySwitch.DisplayConditionClearQuestId;
                if (CalculatorQuest.IsClearQuest(clearCond, userId))
                    return GetName(displaySwitch.NameCharacterTextId);
            }
        }

        var character = CalculatorMasterData.GetEntityMCharacter(characterId);
        if (character == null)
            return null;

        return GetName(character.NameCharacterTextId);
    }
}
