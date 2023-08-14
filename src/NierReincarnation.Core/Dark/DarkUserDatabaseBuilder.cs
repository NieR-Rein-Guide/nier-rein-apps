using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

public sealed class DarkUserDatabaseBuilder : DatabaseBuilderBase
{
    public DarkUserDatabaseBuilder() : base(null)
    {
    }

    public DarkUserDatabaseBuilder(IFormatterResolver resolver) : base(resolver)
    {
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUser> dataSource)
    {
        AppendCore(dataSource, user => user.UserId, Comparer<long>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserBeginnerCampaign> dataSource)
    {
        AppendCore(dataSource, user => user.UserId, Comparer<long>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserBigHuntMaxScore> dataSource)
    {
        AppendCore(dataSource, user => (user.UserId, user.BigHuntBossId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserBigHuntProgressStatus> dataSource)
    {
        AppendCore(dataSource, user => user.UserId, Comparer<long>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserBigHuntScheduleMaxScore> dataSource)
    {
        AppendCore(dataSource, user => (user.UserId, user.BigHuntScheduleId, user.BigHuntBossId), Comparer<(long, int, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserBigHuntStatus> dataSource)
    {
        AppendCore(dataSource, user => (user.UserId, user.BigHuntBossQuestId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserBigHuntWeeklyMaxScore> dataSource)
    {
        AppendCore(dataSource, user => (user.UserId, user.BigHuntWeeklyVersion, user.AttributeType), Comparer<(long, long, AttributeType)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserCageOrnamentReward> dataSource)
    {
        AppendCore(dataSource, user => (user.UserId, user.CageOrnamentId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserCharacter> dataSource)
    {
        AppendCore(dataSource, user => (user.UserId, user.CharacterId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserCharacterBoardAbility> dataSource)
    {
        AppendCore(dataSource, user => (user.UserId, user.CharacterId, user.AbilityId), Comparer<(long, int, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserCharacterBoardStatusUp> dataSource)
    {
        AppendCore(dataSource, user => (user.UserId, user.CharacterId, user.StatusCalculationType), Comparer<(long, int, StatusCalculationType)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserCompanion> dataSource)
    {
        AppendCore(dataSource, user => (user.UserId, user.UserCompanionUuid), Comparer<(long, string)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserCharacterCostumeLevelBonus> dataSource)
    {
        AppendCore(dataSource, user => (user.UserId, user.CharacterId, user.StatusCalculationType), Comparer<(long, int, StatusCalculationType)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserCharacterRebirth> dataSource)
    {
        AppendCore(dataSource, user => (user.UserId, user.CharacterId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserComebackCampaign> dataSource)
    {
        AppendCore(dataSource, user => user.UserId, Comparer<long>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserConsumableItem> dataSource)
    {
        AppendCore(dataSource, user => (user.UserId, user.ConsumableItemId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserCostume> dataSource)
    {
        AppendCore(dataSource, user => (user.UserId, user.UserCostumeUuid), Comparer<(long, string)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserCostumeActiveSkill> dataSource)
    {
        AppendCore(dataSource, user => (user.UserId, user.UserCostumeUuid), Comparer<(long, string)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserDeck> dataSource)
    {
        AppendCore(dataSource, user => (user.UserId, user.DeckType, user.UserDeckNumber), Comparer<(long, DeckType, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserDeckCharacter> dataSource)
    {
        AppendCore(dataSource, user => (user.UserId, user.UserDeckCharacterUuid), Comparer<(long, string)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserDeckCharacterDressupCostume> dataSource)
    {
        AppendCore(dataSource, user => (user.UserId, user.UserDeckCharacterUuid), Comparer<(long, string)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserDeckPartsGroup> dataSource)
    {
        AppendCore(dataSource, user => (user.UserId, user.UserDeckCharacterUuid, user.UserPartsUuid), Comparer<(long, string, string)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserDeckSubWeaponGroup> dataSource)
    {
        AppendCore(dataSource, user => (user.UserId, user.UserDeckCharacterUuid, user.UserWeaponUuid), Comparer<(long, string, string)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserDeckTypeNote> dataSource)
    {
        AppendCore(dataSource, user => (user.UserId, user.DeckType), Comparer<(long, DeckType)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserEventQuestDailyGroupCompleteReward> dataSource)
    {
        AppendCore(dataSource, user => user.UserId, Comparer<long>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserEventQuestGuerrillaFreeOpen> dataSource)
    {
        AppendCore(dataSource, user => user.UserId, Comparer<long>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserEventQuestProgressStatus> dataSource)
    {
        AppendCore(dataSource, user => user.UserId, Comparer<long>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserExtraQuestProgressStatus> dataSource)
    {
        AppendCore(dataSource, user => user.UserId, Comparer<long>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserGem> dataSource)
    {
        AppendCore(dataSource, user => user.UserId, Comparer<long>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserGimmick> dataSource)
    {
        AppendCore(dataSource, user => (user.UserId, user.GimmickSequenceScheduleId, user.GimmickSequenceId, user.GimmickId), Comparer<(long, int, int, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserGimmickOrnamentProgress> dataSource)
    {
        AppendCore(dataSource, user => (user.UserId, user.GimmickSequenceScheduleId, user.GimmickSequenceId, user.GimmickId, user.GimmickOrnamentIndex), Comparer<(long, int, int, int, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserGimmickSequence> dataSource)
    {
        AppendCore(dataSource, user => (user.UserId, user.GimmickSequenceScheduleId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserMainQuestProgressStatus> dataSource)
    {
        AppendCore(dataSource, user => user.UserId, Comparer<long>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserLimitedOpen> dataSource)
    {
        AppendCore(dataSource, user => (user.UserId, user.LimitedOpenTargetType, user.TargetId), Comparer<(long, LimitedOpenTargetType, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserMainQuestSeasonRoute> dataSource)
    {
        AppendCore(dataSource, user => (user.UserId, user.MainQuestSeasonId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserMaterial> dataSource)
    {
        AppendCore(dataSource, user => (user.UserId, user.MaterialId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserParts> dataSource)
    {
        AppendCore(dataSource, user => (user.UserId, user.UserPartsUuid), Comparer<(long, string)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserPartsStatusSub> dataSource)
    {
        AppendCore(dataSource, user => (user.UserId, user.UserPartsUuid, user.StatusIndex), Comparer<(long, string, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserProfile> dataSource)
    {
        AppendCore(dataSource, user => user.UserId, Comparer<long>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserQuest> dataSource)
    {
        AppendCore(dataSource, user => (user.UserId, user.QuestId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserQuestMission> dataSource)
    {
        AppendCore(dataSource, user => (user.UserId, user.QuestId, user.QuestMissionId), Comparer<(long, int, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserQuestSceneChoice> dataSource)
    {
        AppendCore(dataSource, user => (user.UserId, user.QuestSceneChoiceGroupingId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserQuestLimitContentStatus> dataSource)
    {
        AppendCore(dataSource, user => (user.UserId, user.QuestId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserShopItem> dataSource)
    {
        AppendCore(dataSource, user => (user.UserId, user.ShopItemId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserStatus> dataSource)
    {
        AppendCore(dataSource, user => user.UserId, Comparer<long>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserThought> dataSource)
    {
        AppendCore(dataSource, user => (user.UserId, user.UserThoughtUuid), Comparer<(long, string)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserWeapon> dataSource)
    {
        AppendCore(dataSource, user => (user.UserId, user.UserWeaponUuid), Comparer<(long, string)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserWeaponAbility> dataSource)
    {
        AppendCore(dataSource, user => (user.UserId, user.UserWeaponUuid, user.SlotNumber), Comparer<(long, string, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserWeaponNote> dataSource)
    {
        AppendCore(dataSource, user => (user.UserId, user.WeaponId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserWeaponSkill> dataSource)
    {
        AppendCore(dataSource, user => (user.UserId, user.UserWeaponUuid, user.SlotNumber), Comparer<(long, string, int)>.Default);
        return this;
    }
}
