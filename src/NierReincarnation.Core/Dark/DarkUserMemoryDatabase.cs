using NierReincarnation.Core.Dark.Tables;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

public class DarkUserMemoryDatabase : MemoryDatabaseBase
{
    public EntityIUserTable EntityIUserTable { get; private set; }

    public EntityIUserAppleTable EntityIUserAppleTable { get; private set; }

    public EntityIUserAutoSaleSettingDetailTable EntityIUserAutoSaleSettingDetailTable { get; private set; }

    public EntityIUserBeginnerCampaignTable EntityIUserBeginnerCampaignTable { get; private set; }

    public EntityIUserBigHuntMaxScoreTable EntityIUserBigHuntMaxScoreTable { get; private set; }

    public EntityIUserBigHuntProgressStatusTable EntityIUserBigHuntProgressStatusTable { get; private set; }

    public EntityIUserBigHuntScheduleMaxScoreTable EntityIUserBigHuntScheduleMaxScoreTable { get; private set; }

    public EntityIUserBigHuntStatusTable EntityIUserBigHuntStatusTable { get; private set; }

    public EntityIUserBigHuntWeeklyMaxScoreTable EntityIUserBigHuntWeeklyMaxScoreTable { get; private set; }

    public EntityIUserBigHuntWeeklyStatusTable EntityIUserBigHuntWeeklyStatusTable { get; private set; }

    public EntityIUserCageOrnamentRewardTable EntityIUserCageOrnamentRewardTable { get; private set; }

    public EntityIUserCharacterTable EntityIUserCharacterTable { get; private set; }

    public EntityIUserCharacterBoardTable EntityIUserCharacterBoardTable { get; private set; }

    public EntityIUserCharacterBoardAbilityTable EntityIUserCharacterBoardAbilityTable { get; private set; }

    public EntityIUserCharacterBoardCompleteRewardTable EntityIUserCharacterBoardCompleteRewardTable { get; private set; }

    public EntityIUserCharacterBoardStatusUpTable EntityIUserCharacterBoardStatusUpTable { get; private set; }

    public EntityIUserCharacterCostumeLevelBonusTable EntityIUserCharacterCostumeLevelBonusTable { get; private set; }

    public EntityIUserCharacterRebirthTable EntityIUserCharacterRebirthTable { get; private set; }

    public EntityIUserCharacterViewerFieldTable EntityIUserCharacterViewerFieldTable { get; private set; }

    public EntityIUserComebackCampaignTable EntityIUserComebackCampaignTable { get; private set; }

    public EntityIUserCompanionTable EntityIUserCompanionTable { get; private set; }

    public EntityIUserConsumableItemTable EntityIUserConsumableItemTable { get; private set; }

    public EntityIUserContentsStoryTable EntityIUserContentsStoryTable { get; private set; }

    public EntityIUserCostumeTable EntityIUserCostumeTable { get; private set; }

    public EntityIUserCostumeActiveSkillTable EntityIUserCostumeActiveSkillTable { get; private set; }

    public EntityIUserCostumeAwakenStatusUpTable EntityIUserCostumeAwakenStatusUpTable { get; private set; }

    public EntityIUserCostumeLevelBonusReleaseStatusTable EntityIUserCostumeLevelBonusReleaseStatusTable { get; private set; }

    public EntityIUserCostumeLotteryEffectTable EntityIUserCostumeLotteryEffectTable { get; private set; }

    public EntityIUserCostumeLotteryEffectAbilityTable EntityIUserCostumeLotteryEffectAbilityTable { get; private set; }

    public EntityIUserCostumeLotteryEffectPendingTable EntityIUserCostumeLotteryEffectPendingTable { get; private set; }

    public EntityIUserCostumeLotteryEffectStatusUpTable EntityIUserCostumeLotteryEffectStatusUpTable { get; private set; }

    public EntityIUserDeckTable EntityIUserDeckTable { get; private set; }

    public EntityIUserDeckCharacterTable EntityIUserDeckCharacterTable { get; private set; }

    public EntityIUserDeckCharacterDressupCostumeTable EntityIUserDeckCharacterDressupCostumeTable { get; private set; }

    public EntityIUserDeckLimitContentDeletedCharacterTable EntityIUserDeckLimitContentDeletedCharacterTable { get; private set; }

    public EntityIUserDeckLimitContentRestrictedTable EntityIUserDeckLimitContentRestrictedTable { get; private set; }

    public EntityIUserDeckPartsGroupTable EntityIUserDeckPartsGroupTable { get; private set; }

    public EntityIUserDeckSubWeaponGroupTable EntityIUserDeckSubWeaponGroupTable { get; private set; }

    public EntityIUserDeckTypeNoteTable EntityIUserDeckTypeNoteTable { get; private set; }

    public EntityIUserDokanTable EntityIUserDokanTable { get; private set; }

    public EntityIUserEventQuestDailyGroupCompleteRewardTable EntityIUserEventQuestDailyGroupCompleteRewardTable { get; private set; }

    public EntityIUserEventQuestGuerrillaFreeOpenTable EntityIUserEventQuestGuerrillaFreeOpenTable { get; private set; }

    public EntityIUserEventQuestLabyrinthSeasonTable EntityIUserEventQuestLabyrinthSeasonTable { get; private set; }

    public EntityIUserEventQuestLabyrinthStageTable EntityIUserEventQuestLabyrinthStageTable { get; private set; }

    public EntityIUserEventQuestProgressStatusTable EntityIUserEventQuestProgressStatusTable { get; private set; }

    public EntityIUserEventQuestTowerAccumulationRewardTable EntityIUserEventQuestTowerAccumulationRewardTable { get; private set; }

    public EntityIUserExploreTable EntityIUserExploreTable { get; private set; }

    public EntityIUserExploreScoreTable EntityIUserExploreScoreTable { get; private set; }

    public EntityIUserExtraQuestProgressStatusTable EntityIUserExtraQuestProgressStatusTable { get; private set; }

    public EntityIUserFacebookTable EntityIUserFacebookTable { get; private set; }

    public EntityIUserGemTable EntityIUserGemTable { get; private set; }

    public EntityIUserGimmickTable EntityIUserGimmickTable { get; private set; }

    public EntityIUserGimmickOrnamentProgressTable EntityIUserGimmickOrnamentProgressTable { get; private set; }

    public EntityIUserGimmickSequenceTable EntityIUserGimmickSequenceTable { get; private set; }

    public EntityIUserGimmickUnlockTable EntityIUserGimmickUnlockTable { get; private set; }

    public EntityIUserImportantItemTable EntityIUserImportantItemTable { get; private set; }

    public EntityIUserLimitedOpenTable EntityIUserLimitedOpenTable { get; private set; }

    public EntityIUserLoginTable EntityIUserLoginTable { get; private set; }

    public EntityIUserLoginBonusTable EntityIUserLoginBonusTable { get; private set; }

    public EntityIUserMainQuestFlowStatusTable EntityIUserMainQuestFlowStatusTable { get; private set; }

    public EntityIUserMainQuestMainFlowStatusTable EntityIUserMainQuestMainFlowStatusTable { get; private set; }

    public EntityIUserMainQuestProgressStatusTable EntityIUserMainQuestProgressStatusTable { get; private set; }

    public EntityIUserMainQuestReplayFlowStatusTable EntityIUserMainQuestReplayFlowStatusTable { get; private set; }

    public EntityIUserMainQuestSeasonRouteTable EntityIUserMainQuestSeasonRouteTable { get; private set; }

    public EntityIUserMaterialTable EntityIUserMaterialTable { get; private set; }

    public EntityIUserMissionTable EntityIUserMissionTable { get; private set; }

    public EntityIUserMissionCompletionProgressTable EntityIUserMissionCompletionProgressTable { get; private set; }

    public EntityIUserMissionPassPointTable EntityIUserMissionPassPointTable { get; private set; }

    public EntityIUserMovieTable EntityIUserMovieTable { get; private set; }

    public EntityIUserNaviCutInTable EntityIUserNaviCutInTable { get; private set; }

    public EntityIUserOmikujiTable EntityIUserOmikujiTable { get; private set; }

    public EntityIUserPartsTable EntityIUserPartsTable { get; private set; }

    public EntityIUserPartsGroupNoteTable EntityIUserPartsGroupNoteTable { get; private set; }

    public EntityIUserPartsPresetTable EntityIUserPartsPresetTable { get; private set; }

    public EntityIUserPartsPresetTagTable EntityIUserPartsPresetTagTable { get; private set; }

    public EntityIUserPartsStatusSubTable EntityIUserPartsStatusSubTable { get; private set; }

    public EntityIUserPortalCageStatusTable EntityIUserPortalCageStatusTable { get; private set; }

    public EntityIUserPossessionAutoConvertTable EntityIUserPossessionAutoConvertTable { get; private set; }

    public EntityIUserPremiumItemTable EntityIUserPremiumItemTable { get; private set; }

    public EntityIUserProfileTable EntityIUserProfileTable { get; private set; }

    public EntityIUserPvpDefenseDeckTable EntityIUserPvpDefenseDeckTable { get; private set; }

    public EntityIUserPvpStatusTable EntityIUserPvpStatusTable { get; private set; }

    public EntityIUserPvpWeeklyResultTable EntityIUserPvpWeeklyResultTable { get; private set; }

    public EntityIUserQuestTable EntityIUserQuestTable { get; private set; }

    public EntityIUserQuestAutoOrbitTable EntityIUserQuestAutoOrbitTable { get; private set; }

    public EntityIUserQuestLimitContentStatusTable EntityIUserQuestLimitContentStatusTable { get; private set; }

    public EntityIUserQuestMissionTable EntityIUserQuestMissionTable { get; private set; }

    public EntityIUserQuestReplayFlowRewardGroupTable EntityIUserQuestReplayFlowRewardGroupTable { get; private set; }

    public EntityIUserQuestSceneChoiceTable EntityIUserQuestSceneChoiceTable { get; private set; }

    public EntityIUserQuestSceneChoiceHistoryTable EntityIUserQuestSceneChoiceHistoryTable { get; private set; }

    public EntityIUserSettingTable EntityIUserSettingTable { get; private set; }

    public EntityIUserShopItemTable EntityIUserShopItemTable { get; private set; }

    public EntityIUserShopReplaceableTable EntityIUserShopReplaceableTable { get; private set; }

    public EntityIUserShopReplaceableLineupTable EntityIUserShopReplaceableLineupTable { get; private set; }

    public EntityIUserSideStoryQuestTable EntityIUserSideStoryQuestTable { get; private set; }

    public EntityIUserSideStoryQuestSceneProgressStatusTable EntityIUserSideStoryQuestSceneProgressStatusTable { get; private set; }

    public EntityIUserStatusTable EntityIUserStatusTable { get; private set; }

    public EntityIUserThoughtTable EntityIUserThoughtTable { get; private set; }

    public EntityIUserTripleDeckTable EntityIUserTripleDeckTable { get; private set; }

    public EntityIUserTutorialProgressTable EntityIUserTutorialProgressTable { get; private set; }

    public EntityIUserWeaponTable EntityIUserWeaponTable { get; private set; }

    public EntityIUserWeaponAbilityTable EntityIUserWeaponAbilityTable { get; private set; }

    public EntityIUserWeaponAwakenTable EntityIUserWeaponAwakenTable { get; private set; }

    public EntityIUserWeaponNoteTable EntityIUserWeaponNoteTable { get; private set; }

    public EntityIUserWeaponSkillTable EntityIUserWeaponSkillTable { get; private set; }

    public EntityIUserWeaponStoryTable EntityIUserWeaponStoryTable { get; private set; }

    public EntityIUserWebviewPanelMissionTable EntityIUserWebviewPanelMissionTable { get; private set; }

    public DarkUserMemoryDatabase(byte[] databaseBinary, bool internString = true, IFormatterResolver formatterResolver = null) :
        base(databaseBinary, internString, formatterResolver)
    {
    }

    protected override void Init(Dictionary<string, (int, int)> header, ReadOnlyMemory<byte> databaseBinary, MessagePackSerializerOptions options)
    {
        EntityIUserTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUser[], EntityIUserTable>(data => new EntityIUserTable(data)));
        EntityIUserAppleTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserApple[], EntityIUserAppleTable>(data => new EntityIUserAppleTable(data)));
        EntityIUserAutoSaleSettingDetailTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserAutoSaleSettingDetail[], EntityIUserAutoSaleSettingDetailTable>(data => new EntityIUserAutoSaleSettingDetailTable(data)));
        EntityIUserBeginnerCampaignTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserBeginnerCampaign[], EntityIUserBeginnerCampaignTable>(data => new EntityIUserBeginnerCampaignTable(data)));
        EntityIUserBigHuntMaxScoreTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserBigHuntMaxScore[], EntityIUserBigHuntMaxScoreTable>(data => new EntityIUserBigHuntMaxScoreTable(data)));
        EntityIUserBigHuntProgressStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserBigHuntProgressStatus[], EntityIUserBigHuntProgressStatusTable>(data => new EntityIUserBigHuntProgressStatusTable(data)));
        EntityIUserBigHuntScheduleMaxScoreTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserBigHuntScheduleMaxScore[], EntityIUserBigHuntScheduleMaxScoreTable>(data => new EntityIUserBigHuntScheduleMaxScoreTable(data)));
        EntityIUserBigHuntStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserBigHuntStatus[], EntityIUserBigHuntStatusTable>(data => new EntityIUserBigHuntStatusTable(data)));
        EntityIUserBigHuntWeeklyMaxScoreTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserBigHuntWeeklyMaxScore[], EntityIUserBigHuntWeeklyMaxScoreTable>(data => new EntityIUserBigHuntWeeklyMaxScoreTable(data)));
        EntityIUserBigHuntWeeklyStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserBigHuntWeeklyStatus[], EntityIUserBigHuntWeeklyStatusTable>(data => new EntityIUserBigHuntWeeklyStatusTable(data)));
        EntityIUserCageOrnamentRewardTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserCageOrnamentReward[], EntityIUserCageOrnamentRewardTable>(data => new EntityIUserCageOrnamentRewardTable(data)));
        EntityIUserCharacterTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserCharacter[], EntityIUserCharacterTable>(data => new EntityIUserCharacterTable(data)));
        EntityIUserCharacterBoardTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserCharacterBoard[], EntityIUserCharacterBoardTable>(data => new EntityIUserCharacterBoardTable(data)));
        EntityIUserCharacterBoardAbilityTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserCharacterBoardAbility[], EntityIUserCharacterBoardAbilityTable>(data => new EntityIUserCharacterBoardAbilityTable(data)));
        EntityIUserCharacterBoardCompleteRewardTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserCharacterBoardCompleteReward[], EntityIUserCharacterBoardCompleteRewardTable>(data => new EntityIUserCharacterBoardCompleteRewardTable(data)));
        EntityIUserCharacterBoardStatusUpTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserCharacterBoardStatusUp[], EntityIUserCharacterBoardStatusUpTable>(data => new EntityIUserCharacterBoardStatusUpTable(data)));
        EntityIUserCharacterCostumeLevelBonusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserCharacterCostumeLevelBonus[], EntityIUserCharacterCostumeLevelBonusTable>(data => new EntityIUserCharacterCostumeLevelBonusTable(data)));
        EntityIUserCharacterRebirthTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserCharacterRebirth[], EntityIUserCharacterRebirthTable>(data => new EntityIUserCharacterRebirthTable(data)));
        EntityIUserCharacterViewerFieldTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserCharacterViewerField[], EntityIUserCharacterViewerFieldTable>(data => new EntityIUserCharacterViewerFieldTable(data)));
        EntityIUserComebackCampaignTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserComebackCampaign[], EntityIUserComebackCampaignTable>(data => new EntityIUserComebackCampaignTable(data)));
        EntityIUserCompanionTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserCompanion[], EntityIUserCompanionTable>(data => new EntityIUserCompanionTable(data)));
        EntityIUserConsumableItemTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserConsumableItem[], EntityIUserConsumableItemTable>(data => new EntityIUserConsumableItemTable(data)));
        EntityIUserContentsStoryTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserContentsStory[], EntityIUserContentsStoryTable>(data => new EntityIUserContentsStoryTable(data)));
        EntityIUserCostumeTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserCostume[], EntityIUserCostumeTable>(data => new EntityIUserCostumeTable(data)));
        EntityIUserCostumeActiveSkillTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserCostumeActiveSkill[], EntityIUserCostumeActiveSkillTable>(data => new EntityIUserCostumeActiveSkillTable(data)));
        EntityIUserCostumeAwakenStatusUpTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserCostumeAwakenStatusUp[], EntityIUserCostumeAwakenStatusUpTable>(data => new EntityIUserCostumeAwakenStatusUpTable(data)));
        EntityIUserCostumeLevelBonusReleaseStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserCostumeLevelBonusReleaseStatus[], EntityIUserCostumeLevelBonusReleaseStatusTable>(data => new EntityIUserCostumeLevelBonusReleaseStatusTable(data)));
        EntityIUserCostumeLotteryEffectTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserCostumeLotteryEffect[], EntityIUserCostumeLotteryEffectTable>(data => new EntityIUserCostumeLotteryEffectTable(data)));
        EntityIUserCostumeLotteryEffectAbilityTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserCostumeLotteryEffectAbility[], EntityIUserCostumeLotteryEffectAbilityTable>(data => new EntityIUserCostumeLotteryEffectAbilityTable(data)));
        EntityIUserCostumeLotteryEffectPendingTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserCostumeLotteryEffectPending[], EntityIUserCostumeLotteryEffectPendingTable>(data => new EntityIUserCostumeLotteryEffectPendingTable(data)));
        EntityIUserCostumeLotteryEffectStatusUpTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserCostumeLotteryEffectStatusUp[], EntityIUserCostumeLotteryEffectStatusUpTable>(data => new EntityIUserCostumeLotteryEffectStatusUpTable(data)));
        EntityIUserDeckTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserDeck[], EntityIUserDeckTable>(data => new EntityIUserDeckTable(data)));
        EntityIUserDeckCharacterTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserDeckCharacter[], EntityIUserDeckCharacterTable>(data => new EntityIUserDeckCharacterTable(data)));
        EntityIUserDeckCharacterDressupCostumeTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserDeckCharacterDressupCostume[], EntityIUserDeckCharacterDressupCostumeTable>(data => new EntityIUserDeckCharacterDressupCostumeTable(data)));
        EntityIUserDeckLimitContentDeletedCharacterTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserDeckLimitContentDeletedCharacter[], EntityIUserDeckLimitContentDeletedCharacterTable>(data => new EntityIUserDeckLimitContentDeletedCharacterTable(data)));
        EntityIUserDeckLimitContentRestrictedTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserDeckLimitContentRestricted[], EntityIUserDeckLimitContentRestrictedTable>(data => new EntityIUserDeckLimitContentRestrictedTable(data)));
        EntityIUserDeckPartsGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserDeckPartsGroup[], EntityIUserDeckPartsGroupTable>(data => new EntityIUserDeckPartsGroupTable(data)));
        EntityIUserDeckSubWeaponGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserDeckSubWeaponGroup[], EntityIUserDeckSubWeaponGroupTable>(data => new EntityIUserDeckSubWeaponGroupTable(data)));
        EntityIUserDeckTypeNoteTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserDeckTypeNote[], EntityIUserDeckTypeNoteTable>(data => new EntityIUserDeckTypeNoteTable(data)));
        EntityIUserDokanTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserDokan[], EntityIUserDokanTable>(data => new EntityIUserDokanTable(data)));
        EntityIUserEventQuestDailyGroupCompleteRewardTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserEventQuestDailyGroupCompleteReward[], EntityIUserEventQuestDailyGroupCompleteRewardTable>(data => new EntityIUserEventQuestDailyGroupCompleteRewardTable(data)));
        EntityIUserEventQuestGuerrillaFreeOpenTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserEventQuestGuerrillaFreeOpen[], EntityIUserEventQuestGuerrillaFreeOpenTable>(data => new EntityIUserEventQuestGuerrillaFreeOpenTable(data)));
        EntityIUserEventQuestLabyrinthSeasonTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserEventQuestLabyrinthSeason[], EntityIUserEventQuestLabyrinthSeasonTable>(data => new EntityIUserEventQuestLabyrinthSeasonTable(data)));
        EntityIUserEventQuestLabyrinthStageTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserEventQuestLabyrinthStage[], EntityIUserEventQuestLabyrinthStageTable>(data => new EntityIUserEventQuestLabyrinthStageTable(data)));
        EntityIUserEventQuestProgressStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserEventQuestProgressStatus[], EntityIUserEventQuestProgressStatusTable>(data => new EntityIUserEventQuestProgressStatusTable(data)));
        EntityIUserEventQuestTowerAccumulationRewardTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserEventQuestTowerAccumulationReward[], EntityIUserEventQuestTowerAccumulationRewardTable>(data => new EntityIUserEventQuestTowerAccumulationRewardTable(data)));
        EntityIUserExploreTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserExplore[], EntityIUserExploreTable>(data => new EntityIUserExploreTable(data)));
        EntityIUserExploreScoreTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserExploreScore[], EntityIUserExploreScoreTable>(data => new EntityIUserExploreScoreTable(data)));
        EntityIUserExtraQuestProgressStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserExtraQuestProgressStatus[], EntityIUserExtraQuestProgressStatusTable>(data => new EntityIUserExtraQuestProgressStatusTable(data)));
        EntityIUserFacebookTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserFacebook[], EntityIUserFacebookTable>(data => new EntityIUserFacebookTable(data)));
        EntityIUserGemTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserGem[], EntityIUserGemTable>(data => new EntityIUserGemTable(data)));
        EntityIUserGimmickTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserGimmick[], EntityIUserGimmickTable>(data => new EntityIUserGimmickTable(data)));
        EntityIUserGimmickOrnamentProgressTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserGimmickOrnamentProgress[], EntityIUserGimmickOrnamentProgressTable>(data => new EntityIUserGimmickOrnamentProgressTable(data)));
        EntityIUserGimmickSequenceTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserGimmickSequence[], EntityIUserGimmickSequenceTable>(data => new EntityIUserGimmickSequenceTable(data)));
        EntityIUserGimmickUnlockTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserGimmickUnlock[], EntityIUserGimmickUnlockTable>(data => new EntityIUserGimmickUnlockTable(data)));
        EntityIUserImportantItemTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserImportantItem[], EntityIUserImportantItemTable>(data => new EntityIUserImportantItemTable(data)));
        EntityIUserLimitedOpenTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserLimitedOpen[], EntityIUserLimitedOpenTable>(data => new EntityIUserLimitedOpenTable(data)));
        EntityIUserLoginTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserLogin[], EntityIUserLoginTable>(data => new EntityIUserLoginTable(data)));
        EntityIUserLoginBonusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserLoginBonus[], EntityIUserLoginBonusTable>(data => new EntityIUserLoginBonusTable(data)));
        EntityIUserMainQuestFlowStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserMainQuestFlowStatus[], EntityIUserMainQuestFlowStatusTable>(data => new EntityIUserMainQuestFlowStatusTable(data)));
        EntityIUserMainQuestMainFlowStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserMainQuestMainFlowStatus[], EntityIUserMainQuestMainFlowStatusTable>(data => new EntityIUserMainQuestMainFlowStatusTable(data)));
        EntityIUserMainQuestProgressStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserMainQuestProgressStatus[], EntityIUserMainQuestProgressStatusTable>(data => new EntityIUserMainQuestProgressStatusTable(data)));
        EntityIUserMainQuestReplayFlowStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserMainQuestReplayFlowStatus[], EntityIUserMainQuestReplayFlowStatusTable>(data => new EntityIUserMainQuestReplayFlowStatusTable(data)));
        EntityIUserMainQuestSeasonRouteTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserMainQuestSeasonRoute[], EntityIUserMainQuestSeasonRouteTable>(data => new EntityIUserMainQuestSeasonRouteTable(data)));
        EntityIUserMaterialTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserMaterial[], EntityIUserMaterialTable>(data => new EntityIUserMaterialTable(data)));
        EntityIUserMissionTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserMission[], EntityIUserMissionTable>(data => new EntityIUserMissionTable(data)));
        EntityIUserMissionCompletionProgressTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserMissionCompletionProgress[], EntityIUserMissionCompletionProgressTable>(data => new EntityIUserMissionCompletionProgressTable(data)));
        EntityIUserMissionPassPointTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserMissionPassPoint[], EntityIUserMissionPassPointTable>(data => new EntityIUserMissionPassPointTable(data)));
        EntityIUserMovieTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserMovie[], EntityIUserMovieTable>(data => new EntityIUserMovieTable(data)));
        EntityIUserNaviCutInTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserNaviCutIn[], EntityIUserNaviCutInTable>(data => new EntityIUserNaviCutInTable(data)));
        EntityIUserOmikujiTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserOmikuji[], EntityIUserOmikujiTable>(data => new EntityIUserOmikujiTable(data)));
        EntityIUserPartsTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserParts[], EntityIUserPartsTable>(data => new EntityIUserPartsTable(data)));
        EntityIUserPartsGroupNoteTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserPartsGroupNote[], EntityIUserPartsGroupNoteTable>(data => new EntityIUserPartsGroupNoteTable(data)));
        EntityIUserPartsPresetTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserPartsPreset[], EntityIUserPartsPresetTable>(data => new EntityIUserPartsPresetTable(data)));
        EntityIUserPartsPresetTagTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserPartsPresetTag[], EntityIUserPartsPresetTagTable>(data => new EntityIUserPartsPresetTagTable(data)));
        EntityIUserPartsStatusSubTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserPartsStatusSub[], EntityIUserPartsStatusSubTable>(data => new EntityIUserPartsStatusSubTable(data)));
        EntityIUserPortalCageStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserPortalCageStatus[], EntityIUserPortalCageStatusTable>(data => new EntityIUserPortalCageStatusTable(data)));
        EntityIUserPossessionAutoConvertTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserPossessionAutoConvert[], EntityIUserPossessionAutoConvertTable>(data => new EntityIUserPossessionAutoConvertTable(data)));
        EntityIUserPremiumItemTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserPremiumItem[], EntityIUserPremiumItemTable>(data => new EntityIUserPremiumItemTable(data)));
        EntityIUserProfileTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserProfile[], EntityIUserProfileTable>(data => new EntityIUserProfileTable(data)));
        EntityIUserPvpDefenseDeckTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserPvpDefenseDeck[], EntityIUserPvpDefenseDeckTable>(data => new EntityIUserPvpDefenseDeckTable(data)));
        EntityIUserPvpStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserPvpStatus[], EntityIUserPvpStatusTable>(data => new EntityIUserPvpStatusTable(data)));
        EntityIUserPvpWeeklyResultTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserPvpWeeklyResult[], EntityIUserPvpWeeklyResultTable>(data => new EntityIUserPvpWeeklyResultTable(data)));
        EntityIUserQuestTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserQuest[], EntityIUserQuestTable>(data => new EntityIUserQuestTable(data)));
        EntityIUserQuestAutoOrbitTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserQuestAutoOrbit[], EntityIUserQuestAutoOrbitTable>(data => new EntityIUserQuestAutoOrbitTable(data)));
        EntityIUserQuestLimitContentStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserQuestLimitContentStatus[], EntityIUserQuestLimitContentStatusTable>(data => new EntityIUserQuestLimitContentStatusTable(data)));
        EntityIUserQuestMissionTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserQuestMission[], EntityIUserQuestMissionTable>(data => new EntityIUserQuestMissionTable(data)));
        EntityIUserQuestReplayFlowRewardGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserQuestReplayFlowRewardGroup[], EntityIUserQuestReplayFlowRewardGroupTable>(data => new EntityIUserQuestReplayFlowRewardGroupTable(data)));
        EntityIUserQuestSceneChoiceTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserQuestSceneChoice[], EntityIUserQuestSceneChoiceTable>(data => new EntityIUserQuestSceneChoiceTable(data)));
        EntityIUserQuestSceneChoiceHistoryTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserQuestSceneChoiceHistory[], EntityIUserQuestSceneChoiceHistoryTable>(data => new EntityIUserQuestSceneChoiceHistoryTable(data)));
        EntityIUserSettingTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserSetting[], EntityIUserSettingTable>(data => new EntityIUserSettingTable(data)));
        EntityIUserShopItemTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserShopItem[], EntityIUserShopItemTable>(data => new EntityIUserShopItemTable(data)));
        EntityIUserShopReplaceableTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserShopReplaceable[], EntityIUserShopReplaceableTable>(data => new EntityIUserShopReplaceableTable(data)));
        EntityIUserShopReplaceableLineupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserShopReplaceableLineup[], EntityIUserShopReplaceableLineupTable>(data => new EntityIUserShopReplaceableLineupTable(data)));
        EntityIUserSideStoryQuestTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserSideStoryQuest[], EntityIUserSideStoryQuestTable>(data => new EntityIUserSideStoryQuestTable(data)));
        EntityIUserSideStoryQuestSceneProgressStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserSideStoryQuestSceneProgressStatus[], EntityIUserSideStoryQuestSceneProgressStatusTable>(data => new EntityIUserSideStoryQuestSceneProgressStatusTable(data)));
        EntityIUserStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserStatus[], EntityIUserStatusTable>(data => new EntityIUserStatusTable(data)));
        EntityIUserThoughtTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserThought[], EntityIUserThoughtTable>(data => new EntityIUserThoughtTable(data)));
        EntityIUserTripleDeckTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserTripleDeck[], EntityIUserTripleDeckTable>(data => new EntityIUserTripleDeckTable(data)));
        EntityIUserTutorialProgressTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserTutorialProgress[], EntityIUserTutorialProgressTable>(data => new EntityIUserTutorialProgressTable(data)));
        EntityIUserWeaponTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserWeapon[], EntityIUserWeaponTable>(data => new EntityIUserWeaponTable(data)));
        EntityIUserWeaponAbilityTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserWeaponAbility[], EntityIUserWeaponAbilityTable>(data => new EntityIUserWeaponAbilityTable(data)));
        EntityIUserWeaponAwakenTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserWeaponAwaken[], EntityIUserWeaponAwakenTable>(data => new EntityIUserWeaponAwakenTable(data)));
        EntityIUserWeaponNoteTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserWeaponNote[], EntityIUserWeaponNoteTable>(data => new EntityIUserWeaponNoteTable(data)));
        EntityIUserWeaponSkillTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserWeaponSkill[], EntityIUserWeaponSkillTable>(data => new EntityIUserWeaponSkillTable(data)));
        EntityIUserWeaponStoryTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserWeaponStory[], EntityIUserWeaponStoryTable>(data => new EntityIUserWeaponStoryTable(data)));
        EntityIUserWebviewPanelMissionTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserWebviewPanelMission[], EntityIUserWebviewPanelMissionTable>(data => new EntityIUserWebviewPanelMissionTable(data)));
    }
}
