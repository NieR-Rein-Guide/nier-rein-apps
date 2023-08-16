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
        AppendCore(dataSource, x => x.UserId, Comparer<long>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserApple> dataSource)
    {
        AppendCore(dataSource, x => x.UserId, Comparer<long>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserAutoSaleSettingDetail> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.PossessionAutoSaleItemType), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserBeginnerCampaign> dataSource)
    {
        AppendCore(dataSource, x => x.UserId, Comparer<long>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserBigHuntMaxScore> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.BigHuntBossId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserBigHuntProgressStatus> dataSource)
    {
        AppendCore(dataSource, x => x.UserId, Comparer<long>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserBigHuntScheduleMaxScore> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.BigHuntScheduleId, x.BigHuntBossId), Comparer<(long, int, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserBigHuntStatus> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.BigHuntBossQuestId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserBigHuntWeeklyMaxScore> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.BigHuntWeeklyVersion, x.AttributeType), Comparer<(long, long, AttributeType)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserBigHuntWeeklyStatus> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.BigHuntWeeklyVersion), Comparer<(long, long)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserCageOrnamentReward> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.CageOrnamentId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserCharacter> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.CharacterId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserCharacterBoard> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.CharacterBoardId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserCharacterBoardAbility> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.CharacterId, x.AbilityId), Comparer<(long, int, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserCharacterBoardCompleteReward> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.CharacterBoardCompleteRewardId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserCharacterBoardStatusUp> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.CharacterId, x.StatusCalculationType), Comparer<(long, int, StatusCalculationType)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserCharacterCostumeLevelBonus> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.CharacterId, x.StatusCalculationType), Comparer<(long, int, StatusCalculationType)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserCharacterRebirth> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.CharacterId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserCharacterViewerField> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.CharacterViewerFieldId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserComebackCampaign> dataSource)
    {
        AppendCore(dataSource, x => x.UserId, Comparer<long>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserCompanion> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.UserCompanionUuid), Comparer<(long, string)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserConsumableItem> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.ConsumableItemId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserContentsStory> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.ContentsStoryId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserCostume> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.UserCostumeUuid), Comparer<(long, string)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserCostumeActiveSkill> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.UserCostumeUuid), Comparer<(long, string)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserCostumeAwakenStatusUp> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.UserCostumeUuid, x.StatusCalculationType), Comparer<(long, string, StatusCalculationType)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserCostumeLevelBonusReleaseStatus> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.CostumeId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserDeck> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.DeckType, x.UserDeckNumber), Comparer<(long, DeckType, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserDeckCharacter> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.UserDeckCharacterUuid), Comparer<(long, string)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserDeckCharacterDressupCostume> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.UserDeckCharacterUuid), Comparer<(long, string)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserDeckLimitContentRestricted> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.EventQuestChapterId, x.QuestId, x.DeckRestrictedUuid), Comparer<(long, int, int, string)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserDeckPartsGroup> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.UserDeckCharacterUuid, x.UserPartsUuid), Comparer<(long, string, string)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserDeckSubWeaponGroup> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.UserDeckCharacterUuid, x.UserWeaponUuid), Comparer<(long, string, string)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserDeckTypeNote> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.DeckType), Comparer<(long, DeckType)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserDokan> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.DokanId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserEventQuestDailyGroupCompleteReward> dataSource)
    {
        AppendCore(dataSource, x => x.UserId, Comparer<long>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserEventQuestGuerrillaFreeOpen> dataSource)
    {
        AppendCore(dataSource, x => x.UserId, Comparer<long>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserEventQuestLabyrinthSeason> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.EventQuestChapterId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserEventQuestLabyrinthStage> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.EventQuestChapterId, x.StageOrder), Comparer<(long, int, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserEventQuestProgressStatus> dataSource)
    {
        AppendCore(dataSource, x => x.UserId, Comparer<long>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserEventQuestTowerAccumulationReward> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.EventQuestChapterId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserExplore> dataSource)
    {
        AppendCore(dataSource, x => x.UserId, Comparer<long>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserExploreScore> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.ExploreId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserExtraQuestProgressStatus> dataSource)
    {
        AppendCore(dataSource, x => x.UserId, Comparer<long>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserFacebook> dataSource)
    {
        AppendCore(dataSource, x => x.UserId, Comparer<long>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserGem> dataSource)
    {
        AppendCore(dataSource, x => x.UserId, Comparer<long>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserGimmick> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.GimmickSequenceScheduleId, x.GimmickSequenceId, x.GimmickId), Comparer<(long, int, int, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserGimmickOrnamentProgress> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.GimmickSequenceScheduleId, x.GimmickSequenceId, x.GimmickId, x.GimmickOrnamentIndex), Comparer<(long, int, int, int, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserGimmickSequence> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.GimmickSequenceScheduleId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserGimmickUnlock> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.GimmickSequenceScheduleId, x.GimmickSequenceId, x.GimmickId), Comparer<(long, int, int, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserImportantItem> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.ImportantItemId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserLimitedOpen> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.LimitedOpenTargetType, x.TargetId), Comparer<(long, LimitedOpenTargetType, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserLogin> dataSource)
    {
        AppendCore(dataSource, x => x.UserId, Comparer<long>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserLoginBonus> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.LoginBonusId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserMainQuestFlowStatus> dataSource)
    {
        AppendCore(dataSource, x => x.UserId, Comparer<long>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserMainQuestMainFlowStatus> dataSource)
    {
        AppendCore(dataSource, x => x.UserId, Comparer<long>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserMainQuestProgressStatus> dataSource)
    {
        AppendCore(dataSource, x => x.UserId, Comparer<long>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserMainQuestReplayFlowStatus> dataSource)
    {
        AppendCore(dataSource, x => x.UserId, Comparer<long>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserMainQuestSeasonRoute> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.MainQuestSeasonId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserMaterial> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.MaterialId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserMission> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.MissionId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserMissionCompletionProgress> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.MissionId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserMissionPassPoint> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.MissionPassId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserMovie> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.MovieId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserNaviCutIn> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.NaviCutInId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserOmikuji> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.OmikujiId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserParts> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.UserPartsUuid), Comparer<(long, string)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserPartsGroupNote> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.PartsGroupId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserPartsPreset> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.UserPartsPresetNumber), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserPartsPresetTag> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.UserPartsPresetTagNumber), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserPartsStatusSub> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.UserPartsUuid, x.StatusIndex), Comparer<(long, string, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserPortalCageStatus> dataSource)
    {
        AppendCore(dataSource, x => x.UserId, Comparer<long>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserPossessionAutoConvert> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.PossessionType, x.PossessionId), Comparer<(long, PossessionType, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserPremiumItem> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.PremiumItemId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserProfile> dataSource)
    {
        AppendCore(dataSource, x => x.UserId, Comparer<long>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserPvpDefenseDeck> dataSource)
    {
        AppendCore(dataSource, x => x.UserId, Comparer<long>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserPvpStatus> dataSource)
    {
        AppendCore(dataSource, x => x.UserId, Comparer<long>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserPvpWeeklyResult> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.PvpWeeklyVersion), Comparer<(long, long)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserQuest> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.QuestId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserQuestAutoOrbit> dataSource)
    {
        AppendCore(dataSource, x => x.UserId, Comparer<long>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserQuestLimitContentStatus> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.QuestId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserQuestMission> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.QuestId, x.QuestMissionId), Comparer<(long, int, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserQuestReplayFlowRewardGroup> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.QuestReplayFlowRewardGroupId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserQuestSceneChoice> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.QuestSceneChoiceGroupingId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserQuestSceneChoiceHistory> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.QuestSceneChoiceEffectId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserSetting> dataSource)
    {
        AppendCore(dataSource, x => x.UserId, Comparer<long>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserShopItem> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.ShopItemId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserShopReplaceable> dataSource)
    {
        AppendCore(dataSource, x => x.UserId, Comparer<long>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserShopReplaceableLineup> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.SlotNumber), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserSideStoryQuest> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.SideStoryQuestId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserSideStoryQuestSceneProgressStatus> dataSource)
    {
        AppendCore(dataSource, x => x.UserId, Comparer<long>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserStatus> dataSource)
    {
        AppendCore(dataSource, x => x.UserId, Comparer<long>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserThought> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.UserThoughtUuid), Comparer<(long, string)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserTripleDeck> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.DeckType, x.UserDeckNumber), Comparer<(long, DeckType, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserTutorialProgress> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.TutorialType), Comparer<(long, TutorialType)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserWeapon> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.UserWeaponUuid), Comparer<(long, string)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserWeaponAbility> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.UserWeaponUuid, x.SlotNumber), Comparer<(long, string, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserWeaponAwaken> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.UserWeaponUuid), Comparer<(long, string)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserWeaponNote> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.WeaponId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserWeaponSkill> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.UserWeaponUuid, x.SlotNumber), Comparer<(long, string, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserWeaponStory> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.WeaponId), Comparer<(long, int)>.Default);
        return this;
    }

    public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserWebviewPanelMission> dataSource)
    {
        AppendCore(dataSource, x => (x.UserId, x.WebviewPanelMissionPageId), Comparer<(long, int)>.Default);
        return this;
    }
}
