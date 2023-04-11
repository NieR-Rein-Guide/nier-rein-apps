using MessagePack;
using NierReincarnation.Core.Dark.Tables;
using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark
{
    public class DarkUserMemoryDatabase : MemoryDatabaseBase
    {
        // 0x10
        public EntityIUserTable EntityIUserTable { get; private set; }

        // 0x18
        public EntityIUserAppleTable EntityIUserAppleTable { get; private set; }

        // 0x20
        public EntityIUserAutoSaleSettingDetailTable EntityIUserAutoSaleSettingDetailTable { get; private set; }

        // 0x28
        public EntityIUserBeginnerCampaignTable EntityIUserBeginnerCampaignTable { get; private set; }

        // 0x30
        public EntityIUserBigHuntMaxScoreTable EntityIUserBigHuntMaxScoreTable { get; private set; }

        // 0x38
        public EntityIUserBigHuntProgressStatusTable EntityIUserBigHuntProgressStatusTable { get; private set; }

        // 0x40
        public EntityIUserBigHuntScheduleMaxScoreTable EntityIUserBigHuntScheduleMaxScoreTable { get; private set; }

        // 0x48
        public EntityIUserBigHuntStatusTable EntityIUserBigHuntStatusTable { get; private set; }

        // 0x50
        public EntityIUserBigHuntWeeklyMaxScoreTable EntityIUserBigHuntWeeklyMaxScoreTable { get; private set; }

        // 0x58
        public EntityIUserBigHuntWeeklyStatusTable EntityIUserBigHuntWeeklyStatusTable { get; private set; }

        // 0x60
        public EntityIUserCageOrnamentRewardTable EntityIUserCageOrnamentRewardTable { get; private set; }

        // 0x68
        public EntityIUserCharacterTable EntityIUserCharacterTable { get; private set; }

        // 0x70
        public EntityIUserCharacterBoardTable EntityIUserCharacterBoardTable { get; private set; }

        // 0x78
        public EntityIUserCharacterBoardAbilityTable EntityIUserCharacterBoardAbilityTable { get; private set; }

        // 0x80
        public EntityIUserCharacterBoardCompleteRewardTable EntityIUserCharacterBoardCompleteRewardTable { get; private set; }

        // 0x88
        public EntityIUserCharacterBoardStatusUpTable EntityIUserCharacterBoardStatusUpTable { get; private set; }

        // 0x90
        public EntityIUserCharacterCostumeLevelBonusTable EntityIUserCharacterCostumeLevelBonusTable { get; private set; }

        // 0x98
        public EntityIUserCharacterRebirthTable EntityIUserCharacterRebirthTable { get; private set; }

        // 0xA0
        public EntityIUserCharacterViewerFieldTable EntityIUserCharacterViewerFieldTable { get; private set; }

        // 0xA8
        public EntityIUserComebackCampaignTable EntityIUserComebackCampaignTable { get; private set; }

        // 0xB0
        public EntityIUserCompanionTable EntityIUserCompanionTable { get; private set; }

        // 0xB8
        public EntityIUserConsumableItemTable EntityIUserConsumableItemTable { get; private set; }

        // 0xC0
        public EntityIUserContentsStoryTable EntityIUserContentsStoryTable { get; private set; }

        // 0xC8
        public EntityIUserCostumeTable EntityIUserCostumeTable { get; private set; }

        // 0xD0
        public EntityIUserCostumeActiveSkillTable EntityIUserCostumeActiveSkillTable { get; private set; }

        // 0xD8
        public EntityIUserCostumeAwakenStatusUpTable EntityIUserCostumeAwakenStatusUpTable { get; private set; }

        // 0xE0
        public EntityIUserCostumeLevelBonusReleaseStatusTable EntityIUserCostumeLevelBonusReleaseStatusTable { get; private set; }

        // 0xE8
        public EntityIUserDeckTable EntityIUserDeckTable { get; private set; }

        // 0xF0
        public EntityIUserDeckCharacterTable EntityIUserDeckCharacterTable { get; private set; }

        // 0xF8
        public EntityIUserDeckCharacterDressupCostumeTable EntityIUserDeckCharacterDressupCostumeTable { get; private set; }

        // 0x100
        public EntityIUserDeckLimitContentRestrictedTable EntityIUserDeckLimitContentRestrictedTable { get; private set; }

        // 0x108
        public EntityIUserDeckPartsGroupTable EntityIUserDeckPartsGroupTable { get; private set; }

        // 0x110
        public EntityIUserDeckSubWeaponGroupTable EntityIUserDeckSubWeaponGroupTable { get; private set; }

        // 0x118
        public EntityIUserDeckTypeNoteTable EntityIUserDeckTypeNoteTable { get; private set; }

        // 0x120
        public EntityIUserDokanTable EntityIUserDokanTable { get; private set; }

        // 0x128
        public EntityIUserEventQuestDailyGroupCompleteRewardTable EntityIUserEventQuestDailyGroupCompleteRewardTable { get; private set; }

        // 0x130
        public EntityIUserEventQuestGuerrillaFreeOpenTable EntityIUserEventQuestGuerrillaFreeOpenTable { get; private set; }

        // 0x138
        public EntityIUserEventQuestLabyrinthSeasonTable EntityIUserEventQuestLabyrinthSeasonTable { get; private set; }

        // 0x140
        public EntityIUserEventQuestLabyrinthStageTable EntityIUserEventQuestLabyrinthStageTable { get; private set; }

        // 0x148
        public EntityIUserEventQuestProgressStatusTable EntityIUserEventQuestProgressStatusTable { get; private set; }

        // 0x150
        public EntityIUserEventQuestTowerAccumulationRewardTable EntityIUserEventQuestTowerAccumulationRewardTable { get; private set; }

        // 0x158
        public EntityIUserExploreTable EntityIUserExploreTable { get; private set; }

        // 0x160
        public EntityIUserExploreScoreTable EntityIUserExploreScoreTable { get; private set; }

        // 0x168
        public EntityIUserExtraQuestProgressStatusTable EntityIUserExtraQuestProgressStatusTable { get; private set; }

        // 0x170
        public EntityIUserFacebookTable EntityIUserFacebookTable { get; private set; }

        // 0x178
        public EntityIUserGemTable EntityIUserGemTable { get; private set; }

        // 0x180
        public EntityIUserGimmickTable EntityIUserGimmickTable { get; private set; }

        // 0x188
        public EntityIUserGimmickOrnamentProgressTable EntityIUserGimmickOrnamentProgressTable { get; private set; }

        // 0x190
        public EntityIUserGimmickSequenceTable EntityIUserGimmickSequenceTable { get; private set; }

        // 0x198
        public EntityIUserGimmickUnlockTable EntityIUserGimmickUnlockTable { get; private set; }

        // 0x1A0
        public EntityIUserImportantItemTable EntityIUserImportantItemTable { get; private set; }

        // 0x1A8
        public EntityIUserLimitedOpenTable EntityIUserLimitedOpenTable { get; private set; }

        // 0x1B0
        public EntityIUserLoginTable EntityIUserLoginTable { get; private set; }

        // 0x1B8
        public EntityIUserLoginBonusTable EntityIUserLoginBonusTable { get; private set; }

        // 0x1C0
        public EntityIUserMainQuestFlowStatusTable EntityIUserMainQuestFlowStatusTable { get; private set; }

        // 0x1C8
        public EntityIUserMainQuestMainFlowStatusTable EntityIUserMainQuestMainFlowStatusTable { get; private set; }

        // 0x1D0
        public EntityIUserMainQuestProgressStatusTable EntityIUserMainQuestProgressStatusTable { get; private set; }

        // 0x1D8
        public EntityIUserMainQuestReplayFlowStatusTable EntityIUserMainQuestReplayFlowStatusTable { get; private set; }

        // 0x1E0
        public EntityIUserMainQuestSeasonRouteTable EntityIUserMainQuestSeasonRouteTable { get; private set; }

        // 0x1E8
        public EntityIUserMaterialTable EntityIUserMaterialTable { get; private set; }

        // 0x1F0
        public EntityIUserMissionTable EntityIUserMissionTable { get; private set; }

        // 0x1F8
        public EntityIUserMissionCompletionProgressTable EntityIUserMissionCompletionProgressTable { get; private set; }

        // 0x200
        public EntityIUserMovieTable EntityIUserMovieTable { get; private set; }

        // 0x208
        public EntityIUserNaviCutInTable EntityIUserNaviCutInTable { get; private set; }

        // 0x210
        public EntityIUserOmikujiTable EntityIUserOmikujiTable { get; private set; }

        // 0x218
        public EntityIUserPartsTable EntityIUserPartsTable { get; private set; }

        // 0x220
        public EntityIUserPartsGroupNoteTable EntityIUserPartsGroupNoteTable { get; private set; }

        // 0x228
        public EntityIUserPartsPresetTable EntityIUserPartsPresetTable { get; private set; }

        // 0x230
        public EntityIUserPartsPresetTagTable EntityIUserPartsPresetTagTable { get; private set; }

        // 0x238
        public EntityIUserPartsStatusSubTable EntityIUserPartsStatusSubTable { get; private set; }

        // 0x240
        public EntityIUserPortalCageStatusTable EntityIUserPortalCageStatusTable { get; private set; }

        // 0x248
        public EntityIUserPossessionAutoConvertTable EntityIUserPossessionAutoConvertTable { get; private set; }

        // 0x250
        public EntityIUserProfileTable EntityIUserProfileTable { get; private set; }

        // 0x258
        public EntityIUserPvpDefenseDeckTable EntityIUserPvpDefenseDeckTable { get; private set; }

        // 0x260
        public EntityIUserPvpStatusTable EntityIUserPvpStatusTable { get; private set; }

        // 0x268
        public EntityIUserPvpWeeklyResultTable EntityIUserPvpWeeklyResultTable { get; private set; }

        // 0x270
        public EntityIUserQuestTable EntityIUserQuestTable { get; private set; }

        // 0x278
        public EntityIUserQuestAutoOrbitTable EntityIUserQuestAutoOrbitTable { get; private set; }

        // 0x280
        public EntityIUserQuestLimitContentStatusTable EntityIUserQuestLimitContentStatusTable { get; private set; }

        // 0x288
        public EntityIUserQuestMissionTable EntityIUserQuestMissionTable { get; private set; }

        // 0x290
        public EntityIUserQuestReplayFlowRewardGroupTable EntityIUserQuestReplayFlowRewardGroupTable { get; private set; }

        // 0x298
        public EntityIUserQuestSceneChoiceTable EntityIUserQuestSceneChoiceTable { get; private set; }

        // 0x2A0
        public EntityIUserQuestSceneChoiceHistoryTable EntityIUserQuestSceneChoiceHistoryTable { get; private set; }

        // 0x2A8
        public EntityIUserSettingTable EntityIUserSettingTable { get; private set; }

        // 0x2B0
        public EntityIUserShopItemTable EntityIUserShopItemTable { get; private set; }

        // 0x2B8
        public EntityIUserShopReplaceableTable EntityIUserShopReplaceableTable { get; private set; }

        // 0x2C0
        public EntityIUserShopReplaceableLineupTable EntityIUserShopReplaceableLineupTable { get; private set; }

        // 0x2C8
        public EntityIUserSideStoryQuestTable EntityIUserSideStoryQuestTable { get; private set; }

        // 0x2D0
        public EntityIUserSideStoryQuestSceneProgressStatusTable EntityIUserSideStoryQuestSceneProgressStatusTable { get; private set; }

        // 0x2D8
        public EntityIUserStatusTable EntityIUserStatusTable { get; private set; }

        // 0x2E0
        public EntityIUserThoughtTable EntityIUserThoughtTable { get; private set; }

        // 0x2E8
        public EntityIUserTripleDeckTable EntityIUserTripleDeckTable { get; private set; }

        // 0x2F0
        public EntityIUserTutorialProgressTable EntityIUserTutorialProgressTable { get; private set; }

        // 0x2F8
        public EntityIUserWeaponTable EntityIUserWeaponTable { get; private set; }

        // 0x300
        public EntityIUserWeaponAbilityTable EntityIUserWeaponAbilityTable { get; private set; }

        // 0x308
        public EntityIUserWeaponAwakenTable EntityIUserWeaponAwakenTable { get; private set; }

        // 0x310
        public EntityIUserWeaponNoteTable EntityIUserWeaponNoteTable { get; private set; }

        // 0x318
        public EntityIUserWeaponSkillTable EntityIUserWeaponSkillTable { get; private set; }

        // 0x320
        public EntityIUserWeaponStoryTable EntityIUserWeaponStoryTable { get; private set; }

        // 0x328
        public EntityIUserWebviewPanelMissionTable EntityIUserWebviewPanelMissionTable { get; private set; }

        public DarkUserMemoryDatabase(byte[] databaseBinary, bool internString = true, IFormatterResolver formatterResolver = null) :
            base(databaseBinary, internString, formatterResolver)
        {
        }

        protected override void Init(Dictionary<string, (int, int)> header, ReadOnlyMemory<byte> databaseBinary, MessagePackSerializerOptions options)
        {
            EntityIUserTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUser[], EntityIUserTable>(users => new EntityIUserTable(users)));
            EntityIUserAppleTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserApple[], EntityIUserAppleTable>(data => new EntityIUserAppleTable(data)));
            EntityIUserAutoSaleSettingDetailTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserAutoSaleSettingDetail[], EntityIUserAutoSaleSettingDetailTable>(data => new EntityIUserAutoSaleSettingDetailTable(data)));
            EntityIUserBeginnerCampaignTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserBeginnerCampaign[], EntityIUserBeginnerCampaignTable>(campaigns => new EntityIUserBeginnerCampaignTable(campaigns)));
            EntityIUserBigHuntMaxScoreTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserBigHuntMaxScore[], EntityIUserBigHuntMaxScoreTable>(scores => new EntityIUserBigHuntMaxScoreTable(scores)));
            EntityIUserBigHuntProgressStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserBigHuntProgressStatus[], EntityIUserBigHuntProgressStatusTable>(statuses => new EntityIUserBigHuntProgressStatusTable(statuses)));
            EntityIUserBigHuntScheduleMaxScoreTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserBigHuntScheduleMaxScore[], EntityIUserBigHuntScheduleMaxScoreTable>(scores => new EntityIUserBigHuntScheduleMaxScoreTable(scores)));
            EntityIUserBigHuntStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserBigHuntStatus[], EntityIUserBigHuntStatusTable>(statuses => new EntityIUserBigHuntStatusTable(statuses)));
            EntityIUserBigHuntWeeklyMaxScoreTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserBigHuntWeeklyMaxScore[], EntityIUserBigHuntWeeklyMaxScoreTable>(scores => new EntityIUserBigHuntWeeklyMaxScoreTable(scores)));
            EntityIUserBigHuntWeeklyStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserBigHuntWeeklyStatus[], EntityIUserBigHuntWeeklyStatusTable>(data => new EntityIUserBigHuntWeeklyStatusTable(data)));
            EntityIUserCageOrnamentRewardTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserCageOrnamentReward[], EntityIUserCageOrnamentRewardTable>(rewards => new EntityIUserCageOrnamentRewardTable(rewards)));
            EntityIUserCharacterBoardAbilityTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserCharacterBoardAbility[], EntityIUserCharacterBoardAbilityTable>(abilities => new EntityIUserCharacterBoardAbilityTable(abilities)));
            EntityIUserCharacterBoardCompleteRewardTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserCharacterBoardCompleteReward[], EntityIUserCharacterBoardCompleteRewardTable>(data => new EntityIUserCharacterBoardCompleteRewardTable(data)));
            EntityIUserCharacterBoardStatusUpTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserCharacterBoardStatusUp[], EntityIUserCharacterBoardStatusUpTable>(ups => new EntityIUserCharacterBoardStatusUpTable(ups)));
            EntityIUserCharacterBoardTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserCharacterBoard[], EntityIUserCharacterBoardTable>(data => new EntityIUserCharacterBoardTable(data)));
            EntityIUserCharacterCostumeLevelBonusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserCharacterCostumeLevelBonus[], EntityIUserCharacterCostumeLevelBonusTable>(bonuses => new EntityIUserCharacterCostumeLevelBonusTable(bonuses)));
            EntityIUserCharacterRebirthTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserCharacterRebirth[], EntityIUserCharacterRebirthTable>(rebirths => new EntityIUserCharacterRebirthTable(rebirths)));
            EntityIUserCharacterTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserCharacter[], EntityIUserCharacterTable>(characters => new EntityIUserCharacterTable(characters)));
            EntityIUserCharacterViewerFieldTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserCharacterViewerField[], EntityIUserCharacterViewerFieldTable>(data => new EntityIUserCharacterViewerFieldTable(data)));
            EntityIUserComebackCampaignTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserComebackCampaign[], EntityIUserComebackCampaignTable>(campaigns => new EntityIUserComebackCampaignTable(campaigns)));
            EntityIUserCompanionTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserCompanion[], EntityIUserCompanionTable>(companions => new EntityIUserCompanionTable(companions)));
            EntityIUserConsumableItemTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserConsumableItem[], EntityIUserConsumableItemTable>(items => new EntityIUserConsumableItemTable(items)));
            EntityIUserContentsStoryTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserContentsStory[], EntityIUserContentsStoryTable>(data => new EntityIUserContentsStoryTable(data)));
            EntityIUserCostumeActiveSkillTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserCostumeActiveSkill[], EntityIUserCostumeActiveSkillTable>(skills => new EntityIUserCostumeActiveSkillTable(skills)));
            EntityIUserCostumeAwakenStatusUpTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserCostumeAwakenStatusUp[], EntityIUserCostumeAwakenStatusUpTable>(data => new EntityIUserCostumeAwakenStatusUpTable(data)));
            EntityIUserCostumeLevelBonusReleaseStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserCostumeLevelBonusReleaseStatus[], EntityIUserCostumeLevelBonusReleaseStatusTable>(data => new EntityIUserCostumeLevelBonusReleaseStatusTable(data)));
            EntityIUserCostumeTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserCostume[], EntityIUserCostumeTable>(costumes => new EntityIUserCostumeTable(costumes)));
            EntityIUserDeckCharacterDressupCostumeTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserDeckCharacterDressupCostume[], EntityIUserDeckCharacterDressupCostumeTable>(costumes => new EntityIUserDeckCharacterDressupCostumeTable(costumes)));
            EntityIUserDeckCharacterTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserDeckCharacter[], EntityIUserDeckCharacterTable>(characters => new EntityIUserDeckCharacterTable(characters)));
            EntityIUserDeckLimitContentRestrictedTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserDeckLimitContentRestricted[], EntityIUserDeckLimitContentRestrictedTable>(data => new EntityIUserDeckLimitContentRestrictedTable(data)));
            EntityIUserDeckPartsGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserDeckPartsGroup[], EntityIUserDeckPartsGroupTable>(groups => new EntityIUserDeckPartsGroupTable(groups)));
            EntityIUserDeckSubWeaponGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserDeckSubWeaponGroup[], EntityIUserDeckSubWeaponGroupTable>(groups => new EntityIUserDeckSubWeaponGroupTable(groups)));
            EntityIUserDeckTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserDeck[], EntityIUserDeckTable>(decks => new EntityIUserDeckTable(decks)));
            EntityIUserDeckTypeNoteTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserDeckTypeNote[], EntityIUserDeckTypeNoteTable>(notes => new EntityIUserDeckTypeNoteTable(notes)));
            EntityIUserDokanTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserDokan[], EntityIUserDokanTable>(data => new EntityIUserDokanTable(data)));
            EntityIUserEventQuestDailyGroupCompleteRewardTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserEventQuestDailyGroupCompleteReward[], EntityIUserEventQuestDailyGroupCompleteRewardTable>(rewards => new EntityIUserEventQuestDailyGroupCompleteRewardTable(rewards)));
            EntityIUserEventQuestGuerrillaFreeOpenTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserEventQuestGuerrillaFreeOpen[], EntityIUserEventQuestGuerrillaFreeOpenTable>(opens => new EntityIUserEventQuestGuerrillaFreeOpenTable(opens)));
            EntityIUserEventQuestLabyrinthSeasonTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserEventQuestLabyrinthSeason[], EntityIUserEventQuestLabyrinthSeasonTable>(data => new EntityIUserEventQuestLabyrinthSeasonTable(data)));
            EntityIUserEventQuestLabyrinthStageTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserEventQuestLabyrinthStage[], EntityIUserEventQuestLabyrinthStageTable>(data => new EntityIUserEventQuestLabyrinthStageTable(data)));
            EntityIUserEventQuestProgressStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserEventQuestProgressStatus[], EntityIUserEventQuestProgressStatusTable>(statuses => new EntityIUserEventQuestProgressStatusTable(statuses)));
            EntityIUserEventQuestTowerAccumulationRewardTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserEventQuestTowerAccumulationReward[], EntityIUserEventQuestTowerAccumulationRewardTable>(data => new EntityIUserEventQuestTowerAccumulationRewardTable(data)));
            EntityIUserExploreScoreTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserExploreScore[], EntityIUserExploreScoreTable>(data => new EntityIUserExploreScoreTable(data)));
            EntityIUserExploreTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserExplore[], EntityIUserExploreTable>(data => new EntityIUserExploreTable(data)));
            EntityIUserExtraQuestProgressStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserExtraQuestProgressStatus[], EntityIUserExtraQuestProgressStatusTable>(statuses => new EntityIUserExtraQuestProgressStatusTable(statuses)));
            EntityIUserFacebookTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserFacebook[], EntityIUserFacebookTable>(data => new EntityIUserFacebookTable(data)));
            EntityIUserGemTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserGem[], EntityIUserGemTable>(gems => new EntityIUserGemTable(gems)));
            EntityIUserGimmickOrnamentProgressTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserGimmickOrnamentProgress[], EntityIUserGimmickOrnamentProgressTable>(progresses => new EntityIUserGimmickOrnamentProgressTable(progresses)));
            EntityIUserGimmickSequenceTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserGimmickSequence[], EntityIUserGimmickSequenceTable>(sequences => new EntityIUserGimmickSequenceTable(sequences)));
            EntityIUserGimmickTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserGimmick[], EntityIUserGimmickTable>(gimmicks => new EntityIUserGimmickTable(gimmicks)));
            EntityIUserGimmickUnlockTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserGimmickUnlock[], EntityIUserGimmickUnlockTable>(data => new EntityIUserGimmickUnlockTable(data)));
            EntityIUserImportantItemTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserImportantItem[], EntityIUserImportantItemTable>(data => new EntityIUserImportantItemTable(data)));
            EntityIUserLimitedOpenTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserLimitedOpen[], EntityIUserLimitedOpenTable>(opens => new EntityIUserLimitedOpenTable(opens)));
            EntityIUserLoginBonusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserLoginBonus[], EntityIUserLoginBonusTable>(data => new EntityIUserLoginBonusTable(data)));
            EntityIUserLoginTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserLogin[], EntityIUserLoginTable>(data => new EntityIUserLoginTable(data)));
            EntityIUserMainQuestFlowStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserMainQuestFlowStatus[], EntityIUserMainQuestFlowStatusTable>(data => new EntityIUserMainQuestFlowStatusTable(data)));
            EntityIUserMainQuestMainFlowStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserMainQuestMainFlowStatus[], EntityIUserMainQuestMainFlowStatusTable>(data => new EntityIUserMainQuestMainFlowStatusTable(data)));
            EntityIUserMainQuestProgressStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserMainQuestProgressStatus[], EntityIUserMainQuestProgressStatusTable>(statuses => new EntityIUserMainQuestProgressStatusTable(statuses)));
            EntityIUserMainQuestReplayFlowStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserMainQuestReplayFlowStatus[], EntityIUserMainQuestReplayFlowStatusTable>(data => new EntityIUserMainQuestReplayFlowStatusTable(data)));
            EntityIUserMainQuestSeasonRouteTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserMainQuestSeasonRoute[], EntityIUserMainQuestSeasonRouteTable>(routes => new EntityIUserMainQuestSeasonRouteTable(routes)));
            EntityIUserMaterialTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserMaterial[], EntityIUserMaterialTable>(materials => new EntityIUserMaterialTable(materials)));
            EntityIUserMissionCompletionProgressTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserMissionCompletionProgress[], EntityIUserMissionCompletionProgressTable>(data => new EntityIUserMissionCompletionProgressTable(data)));
            EntityIUserMissionTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserMission[], EntityIUserMissionTable>(data => new EntityIUserMissionTable(data)));
            EntityIUserMovieTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserMovie[], EntityIUserMovieTable>(data => new EntityIUserMovieTable(data)));
            EntityIUserNaviCutInTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserNaviCutIn[], EntityIUserNaviCutInTable>(data => new EntityIUserNaviCutInTable(data)));
            EntityIUserOmikujiTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserOmikuji[], EntityIUserOmikujiTable>(data => new EntityIUserOmikujiTable(data)));
            EntityIUserPartsGroupNoteTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserPartsGroupNote[], EntityIUserPartsGroupNoteTable>(data => new EntityIUserPartsGroupNoteTable(data)));
            EntityIUserPartsPresetTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserPartsPreset[], EntityIUserPartsPresetTable>(data => new EntityIUserPartsPresetTable(data)));
            EntityIUserPartsPresetTagTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserPartsPresetTag[], EntityIUserPartsPresetTagTable>(data => new EntityIUserPartsPresetTagTable(data)));
            EntityIUserPartsStatusSubTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserPartsStatusSub[], EntityIUserPartsStatusSubTable>(subs => new EntityIUserPartsStatusSubTable(subs)));
            EntityIUserPartsTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserParts[], EntityIUserPartsTable>(parts => new EntityIUserPartsTable(parts)));
            EntityIUserPortalCageStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserPortalCageStatus[], EntityIUserPortalCageStatusTable>(data => new EntityIUserPortalCageStatusTable(data)));
            EntityIUserPossessionAutoConvertTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserPossessionAutoConvert[], EntityIUserPossessionAutoConvertTable>(data => new EntityIUserPossessionAutoConvertTable(data)));
            EntityIUserProfileTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserProfile[], EntityIUserProfileTable>(profiles => new EntityIUserProfileTable(profiles)));
            EntityIUserPvpDefenseDeckTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserPvpDefenseDeck[], EntityIUserPvpDefenseDeckTable>(data => new EntityIUserPvpDefenseDeckTable(data)));
            EntityIUserPvpStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserPvpStatus[], EntityIUserPvpStatusTable>(data => new EntityIUserPvpStatusTable(data)));
            EntityIUserPvpWeeklyResultTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserPvpWeeklyResult[], EntityIUserPvpWeeklyResultTable>(data => new EntityIUserPvpWeeklyResultTable(data)));
            EntityIUserQuestAutoOrbitTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserQuestAutoOrbit[], EntityIUserQuestAutoOrbitTable>(data => new EntityIUserQuestAutoOrbitTable(data)));
            EntityIUserQuestLimitContentStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserQuestLimitContentStatus[], EntityIUserQuestLimitContentStatusTable>(statuses => new EntityIUserQuestLimitContentStatusTable(statuses)));
            EntityIUserQuestMissionTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserQuestMission[], EntityIUserQuestMissionTable>(missions => new EntityIUserQuestMissionTable(missions)));
            EntityIUserQuestReplayFlowRewardGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserQuestReplayFlowRewardGroup[], EntityIUserQuestReplayFlowRewardGroupTable>(data => new EntityIUserQuestReplayFlowRewardGroupTable(data)));
            EntityIUserQuestSceneChoiceHistoryTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserQuestSceneChoiceHistory[], EntityIUserQuestSceneChoiceHistoryTable>(data => new EntityIUserQuestSceneChoiceHistoryTable(data)));
            EntityIUserQuestSceneChoiceTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserQuestSceneChoice[], EntityIUserQuestSceneChoiceTable>(choices => new EntityIUserQuestSceneChoiceTable(choices)));
            EntityIUserQuestTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserQuest[], EntityIUserQuestTable>(quests => new EntityIUserQuestTable(quests)));
            EntityIUserSettingTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserSetting[], EntityIUserSettingTable>(data => new EntityIUserSettingTable(data)));
            EntityIUserShopItemTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserShopItem[], EntityIUserShopItemTable>(items => new EntityIUserShopItemTable(items)));
            EntityIUserShopReplaceableLineupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserShopReplaceableLineup[], EntityIUserShopReplaceableLineupTable>(data => new EntityIUserShopReplaceableLineupTable(data)));
            EntityIUserShopReplaceableTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserShopReplaceable[], EntityIUserShopReplaceableTable>(data => new EntityIUserShopReplaceableTable(data)));
            EntityIUserSideStoryQuestSceneProgressStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserSideStoryQuestSceneProgressStatus[], EntityIUserSideStoryQuestSceneProgressStatusTable>(data => new EntityIUserSideStoryQuestSceneProgressStatusTable(data)));
            EntityIUserSideStoryQuestTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserSideStoryQuest[], EntityIUserSideStoryQuestTable>(data => new EntityIUserSideStoryQuestTable(data)));
            EntityIUserStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserStatus[], EntityIUserStatusTable>(statuses => new EntityIUserStatusTable(statuses)));
            EntityIUserThoughtTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserThought[], EntityIUserThoughtTable>(thoughts => new EntityIUserThoughtTable(thoughts)));
            EntityIUserTripleDeckTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserTripleDeck[], EntityIUserTripleDeckTable>(data => new EntityIUserTripleDeckTable(data)));
            EntityIUserTutorialProgressTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserTutorialProgress[], EntityIUserTutorialProgressTable>(data => new EntityIUserTutorialProgressTable(data)));
            EntityIUserWeaponAbilityTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserWeaponAbility[], EntityIUserWeaponAbilityTable>(abilities => new EntityIUserWeaponAbilityTable(abilities)));
            EntityIUserWeaponAwakenTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserWeaponAwaken[], EntityIUserWeaponAwakenTable>(data => new EntityIUserWeaponAwakenTable(data)));
            EntityIUserWeaponNoteTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserWeaponNote[], EntityIUserWeaponNoteTable>(notes => new EntityIUserWeaponNoteTable(notes)));
            EntityIUserWeaponSkillTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserWeaponSkill[], EntityIUserWeaponSkillTable>(skills => new EntityIUserWeaponSkillTable(skills)));
            EntityIUserWeaponStoryTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserWeaponStory[], EntityIUserWeaponStoryTable>(data => new EntityIUserWeaponStoryTable(data)));
            EntityIUserWeaponTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserWeapon[], EntityIUserWeaponTable>(weapons => new EntityIUserWeaponTable(weapons)));
            EntityIUserWebviewPanelMissionTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserWebviewPanelMission[], EntityIUserWebviewPanelMissionTable>(data => new EntityIUserWebviewPanelMissionTable(data)));
        }
    }
}
