using Newtonsoft.Json.Linq;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

// CUSTOM: Mostly custom code on basis of the original to better utilize logic
public static class DarkUserDataDatabaseBuilderAppendHelper
{
    private static readonly Dictionary<string, Func<IEnumerable<object>, IEnumerable<object>>> parsers;
    private static readonly Dictionary<string, Action<DarkUserDatabaseBuilder, IEnumerable<object>>> appenders;
    private static readonly Dictionary<string, Action<DarkUserMemoryDatabase, object, bool>> differs;

    static DarkUserDataDatabaseBuilderAppendHelper()
    {
        parsers = new Dictionary<string, Func<IEnumerable<object>, IEnumerable<object>>>
        {
            ["IUser"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUser>()),
            ["IUserApple"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserApple>()),
            ["IUserAutoSaleSettingDetail"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserAutoSaleSettingDetail>()),
            ["IUserBeginnerCampaign"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserBeginnerCampaign>()),
            ["IUserBigHuntMaxScore"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserBigHuntMaxScore>()),
            ["IUserBigHuntProgressStatus"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserBigHuntProgressStatus>()),
            ["IUserBigHuntScheduleMaxScore"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserBigHuntScheduleMaxScore>()),
            ["IUserBigHuntStatus"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserBigHuntStatus>()),
            ["IUserBigHuntWeeklyMaxScore"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserBigHuntWeeklyMaxScore>()),
            ["IUserBigHuntWeeklyStatus"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserBigHuntWeeklyStatus>()),
            ["IUserCageOrnamentReward"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserCageOrnamentReward>()),
            ["IUserCharacter"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserCharacter>()),
            ["IUserCharacterBoard"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserCharacterBoard>()),
            ["IUserCharacterBoardAbility"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserCharacterBoardAbility>()),
            ["IUserCharacterBoardCompleteReward"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserCharacterBoardCompleteReward>()),
            ["IUserCharacterBoardStatusUp"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserCharacterBoardStatusUp>()),
            ["IUserCharacterCostumeLevelBonus"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserCharacterCostumeLevelBonus>()),
            ["IUserCharacterRebirth"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserCharacterRebirth>()),
            ["IUserCharacterViewerField"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserCharacterViewerField>()),
            ["IUserComebackCampaign"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserComebackCampaign>()),
            ["IUserCompanion"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserCompanion>()),
            ["IUserConsumableItem"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserConsumableItem>()),
            ["IUserContentsStory"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserContentsStory>()),
            ["IUserCostume"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserCostume>()),
            ["IUserCostumeActiveSkill"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserCostumeActiveSkill>()),
            ["IUserCostumeAwakenStatusUp"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserCostumeAwakenStatusUp>()),
            ["IUserCostumeLevelBonusReleaseStatus"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserCostumeLevelBonusReleaseStatus>()),
            ["IUserCostumeLotteryEffect"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserCostumeLotteryEffect>()),
            ["IUserCostumeLotteryEffectAbility"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserCostumeLotteryEffectAbility>()),
            ["IUserCostumeLotteryEffectPending"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserCostumeLotteryEffectPending>()),
            ["IUserCostumeLotteryEffectStatusUp"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserCostumeLotteryEffectStatusUp>()),
            ["IUserDeck"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserDeck>()),
            ["IUserDeckCharacter"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserDeckCharacter>()),
            ["IUserDeckCharacterDressupCostume"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserDeckCharacterDressupCostume>()),
            ["IUserDeckLimitContentRestricted"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserDeckLimitContentRestricted>()),
            ["IUserDeckPartsGroup"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserDeckPartsGroup>()),
            ["IUserDeckSubWeaponGroup"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserDeckSubWeaponGroup>()),
            ["IUserDeckTypeNote"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserDeckTypeNote>()),
            ["IUserDokan"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserDokan>()),
            ["IUserEventQuestDailyGroupCompleteReward"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserEventQuestDailyGroupCompleteReward>()),
            ["IUserEventQuestGuerrillaFreeOpen"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserEventQuestGuerrillaFreeOpen>()),
            ["IUserEventQuestLabyrinthSeason"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserEventQuestLabyrinthSeason>()),
            ["IUserEventQuestLabyrinthStage"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserEventQuestLabyrinthStage>()),
            ["IUserEventQuestProgressStatus"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserEventQuestProgressStatus>()),
            ["IUserEventQuestTowerAccumulationReward"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserEventQuestTowerAccumulationReward>()),
            ["IUserExplore"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserExplore>()),
            ["IUserExploreScore"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserExploreScore>()),
            ["IUserExtraQuestProgressStatus"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserExtraQuestProgressStatus>()),
            ["IUserFacebook"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserFacebook>()),
            ["IUserGem"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserGem>()),
            ["IUserGimmick"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserGimmick>()),
            ["IUserGimmickOrnamentProgress"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserGimmickOrnamentProgress>()),
            ["IUserGimmickSequence"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserGimmickSequence>()),
            ["IUserGimmickUnlock"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserGimmickUnlock>()),
            ["IUserImportantItem"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserImportantItem>()),
            ["IUserLimitedOpen"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserLimitedOpen>()),
            ["IUserLogin"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserLogin>()),
            ["IUserLoginBonus"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserLoginBonus>()),
            ["IUserMainQuestFlowStatus"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserMainQuestFlowStatus>()),
            ["IUserMainQuestMainFlowStatus"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserMainQuestMainFlowStatus>()),
            ["IUserMainQuestProgressStatus"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserMainQuestProgressStatus>()),
            ["IUserMainQuestReplayFlowStatus"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserMainQuestReplayFlowStatus>()),
            ["IUserMainQuestSeasonRoute"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserMainQuestSeasonRoute>()),
            ["IUserMaterial"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserMaterial>()),
            ["IUserMission"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserMission>()),
            ["IUserMissionCompletionProgress"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserMissionCompletionProgress>()),
            ["IUserMissionPassPoint"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserMissionPassPoint>()),
            ["IUserMovie"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserMovie>()),
            ["IUserNaviCutIn"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserNaviCutIn>()),
            ["IUserOmikuji"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserOmikuji>()),
            ["IUserParts"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserParts>()),
            ["IUserPartsGroupNote"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserPartsGroupNote>()),
            ["IUserPartsPreset"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserPartsPreset>()),
            ["IUserPartsPresetTag"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserPartsPresetTag>()),
            ["IUserPartsStatusSub"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserPartsStatusSub>()),
            ["IUserPortalCageStatus"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserPortalCageStatus>()),
            ["IUserPossessionAutoConvert"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserPossessionAutoConvert>()),
            ["IUserPremiumItem"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserPremiumItem>()),
            ["IUserProfile"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserProfile>()),
            ["IUserPvpDefenseDeck"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserPvpDefenseDeck>()),
            ["IUserPvpStatus"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserPvpStatus>()),
            ["IUserPvpWeeklyResult"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserPvpWeeklyResult>()),
            ["IUserQuest"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserQuest>()),
            ["IUserQuestAutoOrbit"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserQuestAutoOrbit>()),
            ["IUserQuestLimitContentStatus"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserQuestLimitContentStatus>()),
            ["IUserQuestMission"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserQuestMission>()),
            ["IUserQuestReplayFlowRewardGroup"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserQuestReplayFlowRewardGroup>()),
            ["IUserQuestSceneChoice"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserQuestSceneChoice>()),
            ["IUserQuestSceneChoiceHistory"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserQuestSceneChoiceHistory>()),
            ["IUserSetting"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserSetting>()),
            ["IUserShopItem"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserShopItem>()),
            ["IUserShopReplaceable"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserShopReplaceable>()),
            ["IUserShopReplaceableLineup"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserShopReplaceableLineup>()),
            ["IUserSideStoryQuest"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserSideStoryQuest>()),
            ["IUserSideStoryQuestSceneProgressStatus"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserSideStoryQuestSceneProgressStatus>()),
            ["IUserStatus"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserStatus>()),
            ["IUserThought"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserThought>()),
            ["IUserTripleDeck"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserTripleDeck>()),
            ["IUserTutorialProgress"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserTutorialProgress>()),
            ["IUserWeapon"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserWeapon>()),
            ["IUserWeaponAbility"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserWeaponAbility>()),
            ["IUserWeaponAwaken"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserWeaponAwaken>()),
            ["IUserWeaponNote"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserWeaponNote>()),
            ["IUserWeaponSkill"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserWeaponSkill>()),
            ["IUserWeaponStory"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserWeaponStory>()),
            ["IUserWebviewPanelMission"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserWebviewPanelMission>())
        };
        appenders = new Dictionary<string, Action<DarkUserDatabaseBuilder, IEnumerable<object>>>
        {
            ["IUser"] = (builder, records) => builder.Append(records.Cast<EntityIUser>()),
            ["IUserApple"] = (builder, records) => builder.Append(records.Cast<EntityIUserApple>()),
            ["IUserAutoSaleSettingDetail"] = (builder, records) => builder.Append(records.Cast<EntityIUserAutoSaleSettingDetail>()),
            ["IUserBeginnerCampaign"] = (builder, records) => builder.Append(records.Cast<EntityIUserBeginnerCampaign>()),
            ["IUserBigHuntMaxScore"] = (builder, records) => builder.Append(records.Cast<EntityIUserBigHuntMaxScore>()),
            ["IUserBigHuntProgressStatus"] = (builder, records) => builder.Append(records.Cast<EntityIUserBigHuntProgressStatus>()),
            ["IUserBigHuntScheduleMaxScore"] = (builder, records) => builder.Append(records.Cast<EntityIUserBigHuntScheduleMaxScore>()),
            ["IUserBigHuntStatus"] = (builder, records) => builder.Append(records.Cast<EntityIUserBigHuntStatus>()),
            ["IUserBigHuntWeeklyMaxScore"] = (builder, records) => builder.Append(records.Cast<EntityIUserBigHuntWeeklyMaxScore>()),
            ["IUserBigHuntWeeklyStatus"] = (builder, records) => builder.Append(records.Cast<EntityIUserBigHuntWeeklyStatus>()),
            ["IUserCageOrnamentReward"] = (builder, records) => builder.Append(records.Cast<EntityIUserCageOrnamentReward>()),
            ["IUserCharacter"] = (builder, records) => builder.Append(records.Cast<EntityIUserCharacter>()),
            ["IUserCharacterBoard"] = (builder, records) => builder.Append(records.Cast<EntityIUserCharacterBoard>()),
            ["IUserCharacterBoardAbility"] = (builder, records) => builder.Append(records.Cast<EntityIUserCharacterBoardAbility>()),
            ["IUserCharacterBoardCompleteReward"] = (builder, records) => builder.Append(records.Cast<EntityIUserCharacterBoardCompleteReward>()),
            ["IUserCharacterBoardStatusUp"] = (builder, records) => builder.Append(records.Cast<EntityIUserCharacterBoardStatusUp>()),
            ["IUserCharacterCostumeLevelBonus"] = (builder, records) => builder.Append(records.Cast<EntityIUserCharacterCostumeLevelBonus>()),
            ["IUserCharacterRebirth"] = (builder, records) => builder.Append(records.Cast<EntityIUserCharacterRebirth>()),
            ["IUserCharacterViewerField"] = (builder, records) => builder.Append(records.Cast<EntityIUserCharacterViewerField>()),
            ["IUserComebackCampaign"] = (builder, records) => builder.Append(records.Cast<EntityIUserComebackCampaign>()),
            ["IUserCompanion"] = (builder, records) => builder.Append(records.Cast<EntityIUserCompanion>()),
            ["IUserConsumableItem"] = (builder, records) => builder.Append(records.Cast<EntityIUserConsumableItem>()),
            ["IUserContentsStory"] = (builder, records) => builder.Append(records.Cast<EntityIUserContentsStory>()),
            ["IUserCostume"] = (builder, records) => builder.Append(records.Cast<EntityIUserCostume>()),
            ["IUserCostumeActiveSkill"] = (builder, records) => builder.Append(records.Cast<EntityIUserCostumeActiveSkill>()),
            ["IUserCostumeAwakenStatusUp"] = (builder, records) => builder.Append(records.Cast<EntityIUserCostumeAwakenStatusUp>()),
            ["IUserCostumeLevelBonusReleaseStatus"] = (builder, records) => builder.Append(records.Cast<EntityIUserCostumeLevelBonusReleaseStatus>()),
            ["IUserCostumeLotteryEffect"] = (builder, records) => builder.Append(records.Cast<EntityIUserCostumeLotteryEffect>()),
            ["IUserCostumeLotteryEffectAbility"] = (builder, records) => builder.Append(records.Cast<EntityIUserCostumeLotteryEffectAbility>()),
            ["IUserCostumeLotteryEffectPending"] = (builder, records) => builder.Append(records.Cast<EntityIUserCostumeLotteryEffectPending>()),
            ["IUserCostumeLotteryEffectStatusUp"] = (builder, records) => builder.Append(records.Cast<EntityIUserCostumeLotteryEffectStatusUp>()),
            ["IUserDeck"] = (builder, records) => builder.Append(records.Cast<EntityIUserDeck>()),
            ["IUserDeckCharacter"] = (builder, records) => builder.Append(records.Cast<EntityIUserDeckCharacter>()),
            ["IUserDeckCharacterDressupCostume"] = (builder, records) => builder.Append(records.Cast<EntityIUserDeckCharacterDressupCostume>()),
            ["IUserDeckLimitContentRestricted"] = (builder, records) => builder.Append(records.Cast<EntityIUserDeckLimitContentRestricted>()),
            ["IUserDeckPartsGroup"] = (builder, records) => builder.Append(records.Cast<EntityIUserDeckPartsGroup>()),
            ["IUserDeckSubWeaponGroup"] = (builder, records) => builder.Append(records.Cast<EntityIUserDeckSubWeaponGroup>()),
            ["IUserDeckTypeNote"] = (builder, records) => builder.Append(records.Cast<EntityIUserDeckTypeNote>()),
            ["IUserDokan"] = (builder, records) => builder.Append(records.Cast<EntityIUserDokan>()),
            ["IUserEventQuestDailyGroupCompleteReward"] = (builder, records) => builder.Append(records.Cast<EntityIUserEventQuestDailyGroupCompleteReward>()),
            ["IUserEventQuestGuerrillaFreeOpen"] = (builder, records) => builder.Append(records.Cast<EntityIUserEventQuestGuerrillaFreeOpen>()),
            ["IUserEventQuestLabyrinthSeason"] = (builder, records) => builder.Append(records.Cast<EntityIUserEventQuestLabyrinthSeason>()),
            ["IUserEventQuestLabyrinthStage"] = (builder, records) => builder.Append(records.Cast<EntityIUserEventQuestLabyrinthStage>()),
            ["IUserEventQuestProgressStatus"] = (builder, records) => builder.Append(records.Cast<EntityIUserEventQuestProgressStatus>()),
            ["IUserEventQuestTowerAccumulationReward"] = (builder, records) => builder.Append(records.Cast<EntityIUserEventQuestTowerAccumulationReward>()),
            ["IUserExplore"] = (builder, records) => builder.Append(records.Cast<EntityIUserExplore>()),
            ["IUserExploreScore"] = (builder, records) => builder.Append(records.Cast<EntityIUserExploreScore>()),
            ["IUserExtraQuestProgressStatus"] = (builder, records) => builder.Append(records.Cast<EntityIUserExtraQuestProgressStatus>()),
            ["IUserFacebook"] = (builder, records) => builder.Append(records.Cast<EntityIUserFacebook>()),
            ["IUserGem"] = (builder, records) => builder.Append(records.Cast<EntityIUserGem>()),
            ["IUserGimmick"] = (builder, records) => builder.Append(records.Cast<EntityIUserGimmick>()),
            ["IUserGimmickOrnamentProgress"] = (builder, records) => builder.Append(records.Cast<EntityIUserGimmickOrnamentProgress>()),
            ["IUserGimmickSequence"] = (builder, records) => builder.Append(records.Cast<EntityIUserGimmickSequence>()),
            ["IUserGimmickUnlock"] = (builder, records) => builder.Append(records.Cast<EntityIUserGimmickUnlock>()),
            ["IUserImportantItem"] = (builder, records) => builder.Append(records.Cast<EntityIUserImportantItem>()),
            ["IUserLimitedOpen"] = (builder, records) => builder.Append(records.Cast<EntityIUserLimitedOpen>()),
            ["IUserLogin"] = (builder, records) => builder.Append(records.Cast<EntityIUserLogin>()),
            ["IUserLoginBonus"] = (builder, records) => builder.Append(records.Cast<EntityIUserLoginBonus>()),
            ["IUserMainQuestFlowStatus"] = (builder, records) => builder.Append(records.Cast<EntityIUserMainQuestFlowStatus>()),
            ["IUserMainQuestMainFlowStatus"] = (builder, records) => builder.Append(records.Cast<EntityIUserMainQuestMainFlowStatus>()),
            ["IUserMainQuestProgressStatus"] = (builder, records) => builder.Append(records.Cast<EntityIUserMainQuestProgressStatus>()),
            ["IUserMainQuestReplayFlowStatus"] = (builder, records) => builder.Append(records.Cast<EntityIUserMainQuestReplayFlowStatus>()),
            ["IUserMainQuestSeasonRoute"] = (builder, records) => builder.Append(records.Cast<EntityIUserMainQuestSeasonRoute>()),
            ["IUserMaterial"] = (builder, records) => builder.Append(records.Cast<EntityIUserMaterial>()),
            ["IUserMission"] = (builder, records) => builder.Append(records.Cast<EntityIUserMission>()),
            ["IUserMissionCompletionProgress"] = (builder, records) => builder.Append(records.Cast<EntityIUserMissionCompletionProgress>()),
            ["IUserMissionPassPoint"] = (builder, records) => builder.Append(records.Cast<EntityIUserMissionPassPoint>()),
            ["IUserMovie"] = (builder, records) => builder.Append(records.Cast<EntityIUserMovie>()),
            ["IUserNaviCutIn"] = (builder, records) => builder.Append(records.Cast<EntityIUserNaviCutIn>()),
            ["IUserOmikuji"] = (builder, records) => builder.Append(records.Cast<EntityIUserOmikuji>()),
            ["IUserParts"] = (builder, records) => builder.Append(records.Cast<EntityIUserParts>()),
            ["IUserPartsGroupNote"] = (builder, records) => builder.Append(records.Cast<EntityIUserPartsGroupNote>()),
            ["IUserPartsPreset"] = (builder, records) => builder.Append(records.Cast<EntityIUserPartsPreset>()),
            ["IUserPartsPresetTag"] = (builder, records) => builder.Append(records.Cast<EntityIUserPartsPresetTag>()),
            ["IUserPartsStatusSub"] = (builder, records) => builder.Append(records.Cast<EntityIUserPartsStatusSub>()),
            ["IUserPortalCageStatus"] = (builder, records) => builder.Append(records.Cast<EntityIUserPortalCageStatus>()),
            ["IUserPossessionAutoConvert"] = (builder, records) => builder.Append(records.Cast<EntityIUserPossessionAutoConvert>()),
            ["IUserPremiumItem"] = (builder, records) => builder.Append(records.Cast<EntityIUserPremiumItem>()),
            ["IUserProfile"] = (builder, records) => builder.Append(records.Cast<EntityIUserProfile>()),
            ["IUserPvpDefenseDeck"] = (builder, records) => builder.Append(records.Cast<EntityIUserPvpDefenseDeck>()),
            ["IUserPvpStatus"] = (builder, records) => builder.Append(records.Cast<EntityIUserPvpStatus>()),
            ["IUserPvpWeeklyResult"] = (builder, records) => builder.Append(records.Cast<EntityIUserPvpWeeklyResult>()),
            ["IUserQuest"] = (builder, records) => builder.Append(records.Cast<EntityIUserQuest>()),
            ["IUserQuestAutoOrbit"] = (builder, records) => builder.Append(records.Cast<EntityIUserQuestAutoOrbit>()),
            ["IUserQuestLimitContentStatus"] = (builder, records) => builder.Append(records.Cast<EntityIUserQuestLimitContentStatus>()),
            ["IUserQuestMission"] = (builder, records) => builder.Append(records.Cast<EntityIUserQuestMission>()),
            ["IUserQuestReplayFlowRewardGroup"] = (builder, records) => builder.Append(records.Cast<EntityIUserQuestReplayFlowRewardGroup>()),
            ["IUserQuestSceneChoice"] = (builder, records) => builder.Append(records.Cast<EntityIUserQuestSceneChoice>()),
            ["IUserQuestSceneChoiceHistory"] = (builder, records) => builder.Append(records.Cast<EntityIUserQuestSceneChoiceHistory>()),
            ["IUserSetting"] = (builder, records) => builder.Append(records.Cast<EntityIUserSetting>()),
            ["IUserShopItem"] = (builder, records) => builder.Append(records.Cast<EntityIUserShopItem>()),
            ["IUserShopReplaceable"] = (builder, records) => builder.Append(records.Cast<EntityIUserShopReplaceable>()),
            ["IUserShopReplaceableLineup"] = (builder, records) => builder.Append(records.Cast<EntityIUserShopReplaceableLineup>()),
            ["IUserSideStoryQuest"] = (builder, records) => builder.Append(records.Cast<EntityIUserSideStoryQuest>()),
            ["IUserSideStoryQuestSceneProgressStatus"] = (builder, records) => builder.Append(records.Cast<EntityIUserSideStoryQuestSceneProgressStatus>()),
            ["IUserStatus"] = (builder, records) => builder.Append(records.Cast<EntityIUserStatus>()),
            ["IUserThought"] = (builder, records) => builder.Append(records.Cast<EntityIUserThought>()),
            ["IUserTripleDeck"] = (builder, records) => builder.Append(records.Cast<EntityIUserTripleDeck>()),
            ["IUserTutorialProgress"] = (builder, records) => builder.Append(records.Cast<EntityIUserTutorialProgress>()),
            ["IUserWeapon"] = (builder, records) => builder.Append(records.Cast<EntityIUserWeapon>()),
            ["IUserWeaponAbility"] = (builder, records) => builder.Append(records.Cast<EntityIUserWeaponAbility>()),
            ["IUserWeaponAwaken"] = (builder, records) => builder.Append(records.Cast<EntityIUserWeaponAwaken>()),
            ["IUserWeaponNote"] = (builder, records) => builder.Append(records.Cast<EntityIUserWeaponNote>()),
            ["IUserWeaponSkill"] = (builder, records) => builder.Append(records.Cast<EntityIUserWeaponSkill>()),
            ["IUserWeaponStory"] = (builder, records) => builder.Append(records.Cast<EntityIUserWeaponStory>()),
            ["IUserWebviewPanelMission"] = (builder, records) => builder.Append(records.Cast<EntityIUserWebviewPanelMission>())
        };
        differs = new Dictionary<string, Action<DarkUserMemoryDatabase, object, bool>>
        {
            ["IUser"] = (db, record, mode) => ApplyData(mode, (EntityIUser)record, db.EntityIUserTable, r => db.EntityIUserTable.FindByUserId(r.UserId)),
            ["IUserApple"] = (db, record, mode) => ApplyData(mode, (EntityIUserApple)record, db.EntityIUserAppleTable, r => db.EntityIUserAppleTable.FindByUserId(r.UserId)),
            ["IUserAutoSaleSettingDetail"] = (db, record, mode) => ApplyData(mode, (EntityIUserAutoSaleSettingDetail)record, db.EntityIUserAutoSaleSettingDetailTable, r => { db.EntityIUserAutoSaleSettingDetailTable.TryFindByUserIdAndPossessionAutoSaleItemType((r.UserId, r.PossessionAutoSaleItemType), out var element); return element; }),
            ["IUserBeginnerCampaign"] = (db, record, mode) => ApplyData(mode, (EntityIUserBeginnerCampaign)record, db.EntityIUserBeginnerCampaignTable, r => db.EntityIUserBeginnerCampaignTable.FindByUserId(r.UserId)),
            ["IUserBigHuntMaxScore"] = (db, record, mode) => ApplyData(mode, (EntityIUserBigHuntMaxScore)record, db.EntityIUserBigHuntMaxScoreTable, r => db.EntityIUserBigHuntMaxScoreTable.FindByUserIdAndBigHuntBossId((r.UserId, r.BigHuntBossId))),
            ["IUserBigHuntProgressStatus"] = (db, record, mode) => ApplyData(mode, (EntityIUserBigHuntProgressStatus)record, db.EntityIUserBigHuntProgressStatusTable, r => db.EntityIUserBigHuntProgressStatusTable.FindByUserId(r.UserId)),
            ["IUserBigHuntScheduleMaxScore"] = (db, record, mode) => ApplyData(mode, (EntityIUserBigHuntScheduleMaxScore)record, db.EntityIUserBigHuntScheduleMaxScoreTable, r => db.EntityIUserBigHuntScheduleMaxScoreTable.FindByUserIdAndBigHuntScheduleIdAndBigHuntBossId((r.UserId, r.BigHuntScheduleId, r.BigHuntBossId))),
            ["IUserBigHuntStatus"] = (db, record, mode) => ApplyData(mode, (EntityIUserBigHuntStatus)record, db.EntityIUserBigHuntStatusTable, r => db.EntityIUserBigHuntStatusTable.FindByUserIdAndBigHuntBossQuestId((r.UserId, r.BigHuntBossQuestId))),
            ["IUserBigHuntWeeklyMaxScore"] = (db, record, mode) => ApplyData(mode, (EntityIUserBigHuntWeeklyMaxScore)record, db.EntityIUserBigHuntWeeklyMaxScoreTable, r => { db.EntityIUserBigHuntWeeklyMaxScoreTable.TryFindByUserIdAndBigHuntWeeklyVersionAndAttributeType((r.UserId, r.BigHuntWeeklyVersion, r.AttributeType), out var element); return element; }),
            ["IUserBigHuntWeeklyStatus"] = (db, record, mode) => ApplyData(mode, (EntityIUserBigHuntWeeklyStatus)record, db.EntityIUserBigHuntWeeklyStatusTable, r => db.EntityIUserBigHuntWeeklyStatusTable.All.FirstOrDefault(x => x.UserId == r.UserId && x.BigHuntWeeklyVersion == r.BigHuntWeeklyVersion)),
            ["IUserCageOrnamentReward"] = (db, record, mode) => ApplyData(mode, (EntityIUserCageOrnamentReward)record, db.EntityIUserCageOrnamentRewardTable, r => db.EntityIUserCageOrnamentRewardTable.FindByUserIdAndCageOrnamentId((r.UserId, r.CageOrnamentId))),
            ["IUserCharacter"] = (db, record, mode) => ApplyData(mode, (EntityIUserCharacter)record, db.EntityIUserCharacterTable, r => db.EntityIUserCharacterTable.FindByUserIdAndCharacterId((r.UserId, r.CharacterId))),
            ["IUserCharacterBoard"] = (db, record, mode) => ApplyData(mode, (EntityIUserCharacterBoard)record, db.EntityIUserCharacterBoardTable, r => db.EntityIUserCharacterBoardTable.FindByUserIdAndCharacterBoardId((r.UserId, r.CharacterBoardId))),
            ["IUserCharacterBoardAbility"] = (db, record, mode) => ApplyData(mode, (EntityIUserCharacterBoardAbility)record, db.EntityIUserCharacterBoardAbilityTable, r => { db.EntityIUserCharacterBoardAbilityTable.TryFindByUserIdAndCharacterIdAndAbilityId((r.UserId, r.CharacterId, r.AbilityId), out var element); return element; }),
            ["IUserCharacterBoardCompleteReward"] = (db, record, mode) => ApplyData(mode, (EntityIUserCharacterBoardCompleteReward)record, db.EntityIUserCharacterBoardCompleteRewardTable, r => db.EntityIUserCharacterBoardCompleteRewardTable.All.FirstOrDefault(x => x.UserId == r.UserId && x.CharacterBoardCompleteRewardId == r.CharacterBoardCompleteRewardId)),
            ["IUserCharacterBoardStatusUp"] = (db, record, mode) => ApplyData(mode, (EntityIUserCharacterBoardStatusUp)record, db.EntityIUserCharacterBoardStatusUpTable, r => db.EntityIUserCharacterBoardStatusUpTable.FindByUserIdAndCharacterIdAndStatusCalculationType((r.UserId, r.CharacterId, r.StatusCalculationType))),
            ["IUserCharacterCostumeLevelBonus"] = (db, record, mode) => ApplyData(mode, (EntityIUserCharacterCostumeLevelBonus)record, db.EntityIUserCharacterCostumeLevelBonusTable, r => { db.EntityIUserCharacterCostumeLevelBonusTable.TryFindByUserIdAndCharacterIdAndStatusCalculationType((r.UserId, r.CharacterId, r.StatusCalculationType), out var element); return element; }),
            ["IUserCharacterRebirth"] = (db, record, mode) => ApplyData(mode, (EntityIUserCharacterRebirth)record, db.EntityIUserCharacterRebirthTable, r => db.EntityIUserCharacterRebirthTable.FindByUserIdAndCharacterId((r.UserId, r.CharacterId))),
            ["IUserCharacterViewerField"] = (db, record, mode) => ApplyData(mode, (EntityIUserCharacterViewerField)record, db.EntityIUserCharacterViewerFieldTable, r => db.EntityIUserCharacterViewerFieldTable.All.FirstOrDefault(x => x.UserId == r.UserId && x.CharacterViewerFieldId == r.CharacterViewerFieldId)),
            ["IUserComebackCampaign"] = (db, record, mode) => ApplyData(mode, (EntityIUserComebackCampaign)record, db.EntityIUserComebackCampaignTable, r => db.EntityIUserComebackCampaignTable.FindByUserId(r.UserId)),
            ["IUserCompanion"] = (db, record, mode) => ApplyData(mode, (EntityIUserCompanion)record, db.EntityIUserCompanionTable, r => db.EntityIUserCompanionTable.FindByUserIdAndUserCompanionUuid((r.UserId, r.UserCompanionUuid))),
            ["IUserConsumableItem"] = (db, record, mode) => ApplyData(mode, (EntityIUserConsumableItem)record, db.EntityIUserConsumableItemTable, r => { db.EntityIUserConsumableItemTable.TryFindByUserIdAndConsumableItemId((r.UserId, r.ConsumableItemId), out var element); return element; }),
            ["IUserContentsStory"] = (db, record, mode) => ApplyData(mode, (EntityIUserContentsStory)record, db.EntityIUserContentsStoryTable, r => db.EntityIUserContentsStoryTable.FindByUserIdAndContentsStoryId((r.UserId, r.ContentsStoryId))),
            ["IUserCostume"] = (db, record, mode) => ApplyData(mode, (EntityIUserCostume)record, db.EntityIUserCostumeTable, r => db.EntityIUserCostumeTable.FindByUserIdAndUserCostumeUuid((r.UserId, r.UserCostumeUuid))),
            ["IUserCostumeActiveSkill"] = (db, record, mode) => ApplyData(mode, (EntityIUserCostumeActiveSkill)record, db.EntityIUserCostumeActiveSkillTable, r => db.EntityIUserCostumeActiveSkillTable.FindByUserIdAndUserCostumeUuid((r.UserId, r.UserCostumeUuid))),
            ["IUserCostumeAwakenStatusUp"] = (db, record, mode) => ApplyData(mode, (EntityIUserCostumeAwakenStatusUp)record, db.EntityIUserCostumeAwakenStatusUpTable, r => { db.EntityIUserCostumeAwakenStatusUpTable.TryFindByUserIdAndUserCostumeUuidAndStatusCalculationType((r.UserId, r.UserCostumeUuid, r.StatusCalculationType), out var element); return element; }),
            ["IUserCostumeLevelBonusReleaseStatus"] = (db, record, mode) => ApplyData(mode, (EntityIUserCostumeLevelBonusReleaseStatus)record, db.EntityIUserCostumeLevelBonusReleaseStatusTable, r => { db.EntityIUserCostumeLevelBonusReleaseStatusTable.TryFindByUserIdAndCostumeId((r.UserId, r.CostumeId), out var element); return element; }),
            ["EntityIUserCostumeLotteryEffect"] = (db, record, mode) => ApplyData(mode, (EntityIUserCostumeLotteryEffect)record, db.EntityIUserCostumeLotteryEffectTable, r => { db.EntityIUserCostumeLotteryEffectTable.TryFindByUserIdAndUserCostumeUuidAndSlotNumber((r.UserId, r.UserCostumeUuid, r.SlotNumber), out var element); return element; }),
            ["EntityIUserCostumeLotteryEffectAbility"] = (db, record, mode) => ApplyData(mode, (EntityIUserCostumeLotteryEffectAbility)record, db.EntityIUserCostumeLotteryEffectAbilityTable, r => db.EntityIUserCostumeLotteryEffectAbilityTable.All.FirstOrDefault(x => x.UserId == r.UserId && x.UserCostumeUuid == r.UserCostumeUuid && x.SlotNumber == r.SlotNumber)),
            ["EntityIUserCostumeLotteryEffectPending"] = (db, record, mode) => ApplyData(mode, (EntityIUserCostumeLotteryEffectPending)record, db.EntityIUserCostumeLotteryEffectPendingTable, r => { db.EntityIUserCostumeLotteryEffectPendingTable.TryFindByUserIdAndUserCostumeUuid((r.UserId, r.UserCostumeUuid), out var element); return element; }),
            ["EntityIUserCostumeLotteryEffectStatusUp"] = (db, record, mode) => ApplyData(mode, (EntityIUserCostumeLotteryEffectStatusUp)record, db.EntityIUserCostumeLotteryEffectStatusUpTable, r => { db.EntityIUserCostumeLotteryEffectStatusUpTable.TryFindByUserIdAndUserCostumeUuidAndStatusCalculationType((r.UserId, r.UserCostumeUuid, r.StatusCalculationType), out var element); return element; }),
            ["IUserDeck"] = (db, record, mode) => ApplyData(mode, (EntityIUserDeck)record, db.EntityIUserDeckTable, r => db.EntityIUserDeckTable.FindByUserIdAndDeckTypeAndUserDeckNumber((r.UserId, r.DeckType, r.UserDeckNumber))),
            ["IUserDeckCharacter"] = (db, record, mode) => ApplyData(mode, (EntityIUserDeckCharacter)record, db.EntityIUserDeckCharacterTable, r => db.EntityIUserDeckCharacterTable.FindByUserIdAndUserDeckCharacterUuid((r.UserId, r.UserDeckCharacterUuid))),
            ["IUserDeckCharacterDressupCostume"] = (db, record, mode) => ApplyData(mode, (EntityIUserDeckCharacterDressupCostume)record, db.EntityIUserDeckCharacterDressupCostumeTable, r => { db.EntityIUserDeckCharacterDressupCostumeTable.TryFindByUserIdAndUserDeckCharacterUuid((r.UserId, r.UserDeckCharacterUuid), out var element); return element; }),
            ["IUserDeckLimitContentRestricted"] = (db, record, mode) => ApplyData(mode, (EntityIUserDeckLimitContentRestricted)record, db.EntityIUserDeckLimitContentRestrictedTable, r => db.EntityIUserDeckLimitContentRestrictedTable.All.FirstOrDefault(x => x.UserId == r.UserId && x.EventQuestChapterId == r.EventQuestChapterId && x.QuestId == r.QuestId && x.DeckRestrictedUuid == r.DeckRestrictedUuid)),
            ["IUserDeckPartsGroup"] = (db, record, mode) => ApplyData(mode, (EntityIUserDeckPartsGroup)record, db.EntityIUserDeckPartsGroupTable, r => db.EntityIUserDeckPartsGroupTable.FindByUserIdAndUserDeckCharacterUuidAndUserPartsUuid((r.UserId, r.UserDeckCharacterUuid, r.UserPartsUuid))),
            ["IUserDeckSubWeaponGroup"] = (db, record, mode) => ApplyData(mode, (EntityIUserDeckSubWeaponGroup)record, db.EntityIUserDeckSubWeaponGroupTable, r => db.EntityIUserDeckSubWeaponGroupTable.FindByUserIdAndUserDeckCharacterUuidAndUserWeaponUuid((r.UserId, r.UserDeckCharacterUuid, r.UserWeaponUuid))),
            ["IUserDeckTypeNote"] = (db, record, mode) => ApplyData(mode, (EntityIUserDeckTypeNote)record, db.EntityIUserDeckTypeNoteTable, r => db.EntityIUserDeckTypeNoteTable.FindByUserIdAndDeckType((r.UserId, r.DeckType))),
            ["IUserDokan"] = (db, record, mode) => ApplyData(mode, (EntityIUserDokan)record, db.EntityIUserDokanTable, r => { db.EntityIUserDokanTable.TryFindByUserIdAndDokanId((r.UserId, r.DokanId), out var element); return element; }),
            ["IUserEventQuestDailyGroupCompleteReward"] = (db, record, mode) => ApplyData(mode, (EntityIUserEventQuestDailyGroupCompleteReward)record, db.EntityIUserEventQuestDailyGroupCompleteRewardTable, r => { db.EntityIUserEventQuestDailyGroupCompleteRewardTable.TryFindByUserId(r.UserId, out var element); return element; }),
            ["IUserEventQuestGuerrillaFreeOpen"] = (db, record, mode) => ApplyData(mode, (EntityIUserEventQuestGuerrillaFreeOpen)record, db.EntityIUserEventQuestGuerrillaFreeOpenTable, r => { db.EntityIUserEventQuestGuerrillaFreeOpenTable.TryFindByUserId(r.UserId, out var element); return element; }),
            ["IUserEventQuestLabyrinthSeason"] = (db, record, mode) => ApplyData(mode, (EntityIUserEventQuestLabyrinthSeason)record, db.EntityIUserEventQuestLabyrinthSeasonTable, r => db.EntityIUserEventQuestLabyrinthSeasonTable.FindByUserIdAndEventQuestChapterId((r.UserId, r.EventQuestChapterId))),
            ["IUserEventQuestLabyrinthStage"] = (db, record, mode) => ApplyData(mode, (EntityIUserEventQuestLabyrinthStage)record, db.EntityIUserEventQuestLabyrinthStageTable, r => db.EntityIUserEventQuestLabyrinthStageTable.FindByUserIdAndEventQuestChapterIdAndStageOrder((r.UserId, r.EventQuestChapterId, r.StageOrder))),
            ["IUserEventQuestProgressStatus"] = (db, record, mode) => ApplyData(mode, (EntityIUserEventQuestProgressStatus)record, db.EntityIUserEventQuestProgressStatusTable, r => db.EntityIUserEventQuestProgressStatusTable.FindByUserId(r.UserId)),
            ["IUserEventQuestTowerAccumulationReward"] = (db, record, mode) => ApplyData(mode, (EntityIUserEventQuestTowerAccumulationReward)record, db.EntityIUserEventQuestTowerAccumulationRewardTable, r => db.EntityIUserEventQuestTowerAccumulationRewardTable.FindByUserIdAndEventQuestChapterId((r.UserId, r.EventQuestChapterId))),
            ["EntityIUserExplore"] = (db, record, mode) => ApplyData(mode, (EntityIUserExplore)record, db.EntityIUserExploreTable, r => db.EntityIUserExploreTable.FindByUserId(r.UserId)),
            ["IUserExploreScore"] = (db, record, mode) => ApplyData(mode, (EntityIUserExploreScore)record, db.EntityIUserExploreScoreTable, r => db.EntityIUserExploreScoreTable.FindByUserIdAndExploreId((r.UserId, r.ExploreId))),
            ["IUserExtraQuestProgressStatus"] = (db, record, mode) => ApplyData(mode, (EntityIUserExtraQuestProgressStatus)record, db.EntityIUserExtraQuestProgressStatusTable, r => db.EntityIUserExtraQuestProgressStatusTable.FindByUserId(r.UserId)),
            ["IUserFacebook"] = (db, record, mode) => ApplyData(mode, (EntityIUserFacebook)record, db.EntityIUserFacebookTable, r => db.EntityIUserFacebookTable.FindByUserId(r.UserId)),
            ["IUserGem"] = (db, record, mode) => ApplyData(mode, (EntityIUserGem)record, db.EntityIUserGemTable, r => db.EntityIUserGemTable.FindByUserId(r.UserId)),
            ["IUserGimmick"] = (db, record, mode) => ApplyData(mode, (EntityIUserGimmick)record, db.EntityIUserGimmickTable, r => db.EntityIUserGimmickTable.FindByUserId((r.UserId, r.GimmickSequenceScheduleId, r.GimmickSequenceId, r.GimmickId))),
            ["IUserGimmickOrnamentProgress"] = (db, record, mode) => ApplyData(mode, (EntityIUserGimmickOrnamentProgress)record, db.EntityIUserGimmickOrnamentProgressTable, r => db.EntityIUserGimmickOrnamentProgressTable.FindByUserId((r.UserId, r.GimmickSequenceScheduleId, r.GimmickSequenceId, r.GimmickId, r.GimmickOrnamentIndex))),
            ["IUserGimmickSequence"] = (db, record, mode) => ApplyData(mode, (EntityIUserGimmickSequence)record, db.EntityIUserGimmickSequenceTable, r => db.EntityIUserGimmickSequenceTable.FindByUserId((r.UserId, r.GimmickSequenceScheduleId))),
            ["IUserGimmickUnlock"] = (db, record, mode) => ApplyData(mode, (EntityIUserGimmickUnlock)record, db.EntityIUserGimmickUnlockTable, r => { db.EntityIUserGimmickUnlockTable.TryFindByUserIdAndGimmickSequenceScheduleIdAndGimmickSequenceIdAndGimmickId((r.UserId, r.GimmickSequenceScheduleId, r.GimmickSequenceId, r.GimmickId), out var element); return element; }),
            ["IUserImportantItem"] = (db, record, mode) => ApplyData(mode, (EntityIUserImportantItem)record, db.EntityIUserImportantItemTable, r => db.EntityIUserImportantItemTable.FindByUserIdAndImportantItemId((r.UserId, r.ImportantItemId))),
            ["IUserLimitedOpen"] = (db, record, mode) => ApplyData(mode, (EntityIUserLimitedOpen)record, db.EntityIUserLimitedOpenTable, r => db.EntityIUserLimitedOpenTable.FindByUserIdAndLimitedOpenTargetTypeAndTargetId((r.UserId, r.LimitedOpenTargetType, r.TargetId))),
            ["IUserLogin"] = (db, record, mode) => ApplyData(mode, (EntityIUserLogin)record, db.EntityIUserLoginTable, r => db.EntityIUserLoginTable.All.FirstOrDefault(x => x.UserId == r.UserId)),
            ["IUserLoginBonus"] = (db, record, mode) => ApplyData(mode, (EntityIUserLoginBonus)record, db.EntityIUserLoginBonusTable, r => db.EntityIUserLoginBonusTable.FindByUserIdAndLoginBonusId((r.UserId, r.LoginBonusId))),
            ["IUserMainQuestFlowStatus"] = (db, record, mode) => ApplyData(mode, (EntityIUserMainQuestFlowStatus)record, db.EntityIUserMainQuestFlowStatusTable, r => db.EntityIUserMainQuestFlowStatusTable.FindByUserId(r.UserId)),
            ["IUserMainQuestMainFlowStatus"] = (db, record, mode) => ApplyData(mode, (EntityIUserMainQuestMainFlowStatus)record, db.EntityIUserMainQuestMainFlowStatusTable, r => db.EntityIUserMainQuestMainFlowStatusTable.FindByUserId(r.UserId)),
            ["IUserMainQuestProgressStatus"] = (db, record, mode) => ApplyData(mode, (EntityIUserMainQuestProgressStatus)record, db.EntityIUserMainQuestProgressStatusTable, r => db.EntityIUserMainQuestProgressStatusTable.FindByUserId(r.UserId)),
            ["IUserMainQuestReplayFlowStatus"] = (db, record, mode) => ApplyData(mode, (EntityIUserMainQuestReplayFlowStatus)record, db.EntityIUserMainQuestReplayFlowStatusTable, r => db.EntityIUserMainQuestReplayFlowStatusTable.FindByUserId(r.UserId)),
            ["IUserMainQuestSeasonRoute"] = (db, record, mode) => ApplyData(mode, (EntityIUserMainQuestSeasonRoute)record, db.EntityIUserMainQuestSeasonRouteTable, r => db.EntityIUserMainQuestSeasonRouteTable.FindByUserIdAndMainQuestSeasonId((r.UserId, r.MainQuestSeasonId))),
            ["IUserMaterial"] = (db, record, mode) => ApplyData(mode, (EntityIUserMaterial)record, db.EntityIUserMaterialTable, r => db.EntityIUserMaterialTable.FindByUserIdAndMaterialId((r.UserId, r.MaterialId))),
            ["IUserMission"] = (db, record, mode) => ApplyData(mode, (EntityIUserMission)record, db.EntityIUserMissionTable, r => db.EntityIUserMissionTable.FindByUserIdAndMissionId((r.UserId, r.MissionId))),
            ["IUserMissionCompletionProgress"] = (db, record, mode) => ApplyData(mode, (EntityIUserMissionCompletionProgress)record, db.EntityIUserMissionCompletionProgressTable, r => db.EntityIUserMissionCompletionProgressTable.All.FirstOrDefault(x => x.UserId == r.UserId && x.MissionId == r.MissionId)),
            ["IUserMissionPassPoint"] = (db, record, mode) => ApplyData(mode, (EntityIUserMissionPassPoint)record, db.EntityIUserMissionPassPointTable, r => db.EntityIUserMissionPassPointTable.FindByUserIdAndMissionPassId((r.UserId, r.MissionPassId))),
            ["IUserMovie"] = (db, record, mode) => ApplyData(mode, (EntityIUserMovie)record, db.EntityIUserMovieTable, r => { db.EntityIUserMovieTable.TryFindByUserIdAndMovieId((r.UserId, r.MovieId), out var element); return element; }),
            ["IUserNaviCutIn"] = (db, record, mode) => ApplyData(mode, (EntityIUserNaviCutIn)record, db.EntityIUserNaviCutInTable, r => { db.EntityIUserNaviCutInTable.TryFindByUserIdAndNaviCutInId((r.UserId, r.NaviCutInId), out var element); return element; }),
            ["IUserOmikuji"] = (db, record, mode) => ApplyData(mode, (EntityIUserOmikuji)record, db.EntityIUserOmikujiTable, r => db.EntityIUserOmikujiTable.FindByUserIdAndOmikujiId((r.UserId, r.OmikujiId))),
            ["IUserParts"] = (db, record, mode) => ApplyData(mode, (EntityIUserParts)record, db.EntityIUserPartsTable, r => db.EntityIUserPartsTable.FindByUserIdAndUserPartsUuid((r.UserId, r.UserPartsUuid))),
            ["IUserPartsGroupNote"] = (db, record, mode) => ApplyData(mode, (EntityIUserPartsGroupNote)record, db.EntityIUserPartsGroupNoteTable, r => { db.EntityIUserPartsGroupNoteTable.TryFindByUserIdAndPartsGroupId((r.UserId, r.PartsGroupId), out var element); return element; }),
            ["IUserPartsPreset"] = (db, record, mode) => ApplyData(mode, (EntityIUserPartsPreset)record, db.EntityIUserPartsPresetTable, r => db.EntityIUserPartsPresetTable.FindByUserIdAndUserPartsPresetNumber((r.UserId, r.UserPartsPresetNumber))),
            ["IUserPartsPresetTag"] = (db, record, mode) => ApplyData(mode, (EntityIUserPartsPresetTag)record, db.EntityIUserPartsPresetTagTable, r => db.EntityIUserPartsPresetTagTable.FindByUserIdAndUserPartsPresetTagNumber((r.UserId, r.UserPartsPresetTagNumber))),
            ["IUserPartsStatusSub"] = (db, record, mode) => ApplyData(mode, (EntityIUserPartsStatusSub)record, db.EntityIUserPartsStatusSubTable, r => db.EntityIUserPartsStatusSubTable.FindByUserIdAndUserPartsUuidAndStatusIndex((r.UserId, r.UserPartsUuid, r.StatusIndex))),
            ["IUserPortalCageStatus"] = (db, record, mode) => ApplyData(mode, (EntityIUserPortalCageStatus)record, db.EntityIUserPortalCageStatusTable, r => db.EntityIUserPortalCageStatusTable.FindByUserId(r.UserId)),
            ["IUserPossessionAutoConvert"] = (db, record, mode) => ApplyData(mode, (EntityIUserPossessionAutoConvert)record, db.EntityIUserPossessionAutoConvertTable, r => db.EntityIUserPossessionAutoConvertTable.All.FirstOrDefault(x => x.UserId == r.UserId && x.PossessionType == r.PossessionType && x.PossessionId == r.PossessionId)),
            ["IUserPremiumItem"] = (db, record, mode) => ApplyData(mode, (EntityIUserPremiumItem)record, db.EntityIUserPremiumItemTable, r => db.EntityIUserPremiumItemTable.FindByUserIdAndPremiumItemId((r.UserId, r.PremiumItemId))),
            ["IUserProfile"] = (db, record, mode) => ApplyData(mode, (EntityIUserProfile)record, db.EntityIUserProfileTable, r => db.EntityIUserProfileTable.FindByUserId(r.UserId)),
            ["IUserPvpDefenseDeck"] = (db, record, mode) => ApplyData(mode, (EntityIUserPvpDefenseDeck)record, db.EntityIUserPvpDefenseDeckTable, r => db.EntityIUserPvpDefenseDeckTable.FindByUserId(r.UserId)),
            ["IUserPvpStatus"] = (db, record, mode) => ApplyData(mode, (EntityIUserPvpStatus)record, db.EntityIUserPvpStatusTable, r => db.EntityIUserPvpStatusTable.FindByUserId(r.UserId)),
            ["IUserPvpWeeklyResult"] = (db, record, mode) => ApplyData(mode, (EntityIUserPvpWeeklyResult)record, db.EntityIUserPvpWeeklyResultTable, r => db.EntityIUserPvpWeeklyResultTable.All.FirstOrDefault(x => x.UserId == r.UserId && x.PvpWeeklyVersion == r.PvpWeeklyVersion)),
            ["IUserQuest"] = (db, record, mode) => ApplyData(mode, (EntityIUserQuest)record, db.EntityIUserQuestTable, r => db.EntityIUserQuestTable.FindByUserIdAndQuestId((r.UserId, r.QuestId))),
            ["IUserQuestAutoOrbit"] = (db, record, mode) => ApplyData(mode, (EntityIUserQuestAutoOrbit)record, db.EntityIUserQuestAutoOrbitTable, r => db.EntityIUserQuestAutoOrbitTable.FindByUserId(r.UserId)),
            ["IUserQuestLimitContentStatus"] = (db, record, mode) => ApplyData(mode, (EntityIUserQuestLimitContentStatus)record, db.EntityIUserQuestLimitContentStatusTable, r => db.EntityIUserQuestLimitContentStatusTable.FindByUserIdAndQuestId((r.UserId, r.QuestId))),
            ["IUserQuestMission"] = (db, record, mode) => ApplyData(mode, (EntityIUserQuestMission)record, db.EntityIUserQuestMissionTable, r => db.EntityIUserQuestMissionTable.FindByUserIdAndQuestIdAndQuestMissionId((r.UserId, r.QuestId, r.QuestMissionId))),
            ["IUserQuestReplayFlowRewardGroup"] = (db, record, mode) => ApplyData(mode, (EntityIUserQuestReplayFlowRewardGroup)record, db.EntityIUserQuestReplayFlowRewardGroupTable, r => { db.EntityIUserQuestReplayFlowRewardGroupTable.TryFindByUserIdAndQuestReplayFlowRewardGroupId((r.UserId, r.QuestReplayFlowRewardGroupId), out var element); return element; }),
            ["IUserQuestSceneChoice"] = (db, record, mode) => ApplyData(mode, (EntityIUserQuestSceneChoice)record, db.EntityIUserQuestSceneChoiceTable, r => { db.EntityIUserQuestSceneChoiceTable.TryFindByUserIdAndQuestSceneChoiceGroupingId((r.UserId, r.QuestSceneChoiceGroupingId), out var element); return element; }),
            ["IUserQuestSceneChoiceHistory"] = (db, record, mode) => ApplyData(mode, (EntityIUserQuestSceneChoiceHistory)record, db.EntityIUserQuestSceneChoiceHistoryTable, r => { db.EntityIUserQuestSceneChoiceHistoryTable.TryFindByUserIdAndQuestSceneChoiceEffectId((r.UserId, r.QuestSceneChoiceEffectId), out var element); return element; }),
            ["IUserSetting"] = (db, record, mode) => ApplyData(mode, (EntityIUserSetting)record, db.EntityIUserSettingTable, r => { db.EntityIUserSettingTable.TryFindByUserId(r.UserId, out var element); return element; }),
            ["IUserShopItem"] = (db, record, mode) => ApplyData(mode, (EntityIUserShopItem)record, db.EntityIUserShopItemTable, r => db.EntityIUserShopItemTable.FindByUserIdAndShopItemId((r.UserId, r.ShopItemId))),
            ["IUserShopReplaceable"] = (db, record, mode) => ApplyData(mode, (EntityIUserShopReplaceable)record, db.EntityIUserShopReplaceableTable, r => db.EntityIUserShopReplaceableTable.FindByUserId(r.UserId)),
            ["IUserShopReplaceableLineup"] = (db, record, mode) => ApplyData(mode, (EntityIUserShopReplaceableLineup)record, db.EntityIUserShopReplaceableLineupTable, r => db.EntityIUserShopReplaceableLineupTable.All.FirstOrDefault(x => x.UserId == r.UserId && x.SlotNumber == r.SlotNumber)),
            ["IUserSideStoryQuest"] = (db, record, mode) => ApplyData(mode, (EntityIUserSideStoryQuest)record, db.EntityIUserSideStoryQuestTable, r => db.EntityIUserSideStoryQuestTable.All.FirstOrDefault(x => x.UserId == r.UserId && x.SideStoryQuestId == r.SideStoryQuestId)),
            ["IUserSideStoryQuestSceneProgressStatus"] = (db, record, mode) => ApplyData(mode, (EntityIUserSideStoryQuestSceneProgressStatus)record, db.EntityIUserSideStoryQuestSceneProgressStatusTable, r => db.EntityIUserSideStoryQuestSceneProgressStatusTable.FindByUserId(r.UserId)),
            ["IUserStatus"] = (db, record, mode) => ApplyData(mode, (EntityIUserStatus)record, db.EntityIUserStatusTable, r => db.EntityIUserStatusTable.FindByUserId(r.UserId)),
            ["IUserThought"] = (db, record, mode) => ApplyData(mode, (EntityIUserThought)record, db.EntityIUserThoughtTable, r => { db.EntityIUserThoughtTable.TryFindByUserIdAndUserThoughtUuid((r.UserId, r.UserThoughtUuid), out var element); return element; }),
            ["IUserTripleDeck"] = (db, record, mode) => ApplyData(mode, (EntityIUserTripleDeck)record, db.EntityIUserTripleDeckTable, r => db.EntityIUserTripleDeckTable.FindByUserIdAndDeckTypeAndUserDeckNumber((r.UserId, r.DeckType, r.UserDeckNumber))),
            ["IUserTutorialProgress"] = (db, record, mode) => ApplyData(mode, (EntityIUserTutorialProgress)record, db.EntityIUserTutorialProgressTable, r => { db.EntityIUserTutorialProgressTable.TryFindByUserIdAndTutorialType((r.UserId, r.TutorialType), out var element); return element; }),
            ["IUserWeapon"] = (db, record, mode) => ApplyData(mode, (EntityIUserWeapon)record, db.EntityIUserWeaponTable, r => db.EntityIUserWeaponTable.FindByUserIdAndUserWeaponUuid((r.UserId, r.UserWeaponUuid))),
            ["IUserWeaponAbility"] = (db, record, mode) => ApplyData(mode, (EntityIUserWeaponAbility)record, db.EntityIUserWeaponAbilityTable, r => { db.EntityIUserWeaponAbilityTable.TryFindByUserIdAndUserWeaponUuidAndSlotNumber((r.UserId, r.UserWeaponUuid, r.SlotNumber), out var element); return element; }),
            ["IUserWeaponAwaken"] = (db, record, mode) => ApplyData(mode, (EntityIUserWeaponAwaken)record, db.EntityIUserWeaponAwakenTable, r => { db.EntityIUserWeaponAwakenTable.TryFindByUserIdAndUserWeaponUuid((r.UserId, r.UserWeaponUuid), out var element); return element; }),
            ["IUserWeaponNote"] = (db, record, mode) => ApplyData(mode, (EntityIUserWeaponNote)record, db.EntityIUserWeaponNoteTable, r => { db.EntityIUserWeaponNoteTable.TryFindByUserIdAndWeaponId((r.UserId, r.WeaponId), out var element); return element; }),
            ["IUserWeaponSkill"] = (db, record, mode) => ApplyData(mode, (EntityIUserWeaponSkill)record, db.EntityIUserWeaponSkillTable, r => { db.EntityIUserWeaponSkillTable.TryFindByUserIdAndUserWeaponUuidAndSlotNumber((r.UserId, r.UserWeaponUuid, r.SlotNumber), out var element); return element; }),
            ["IUserWeaponStory"] = (db, record, mode) => ApplyData(mode, (EntityIUserWeaponStory)record, db.EntityIUserWeaponStoryTable, r => db.EntityIUserWeaponStoryTable.FindByUserIdAndWeaponId((r.UserId, r.WeaponId))),
            ["IUserWebviewPanelMission"] = (db, record, mode) => ApplyData(mode, (EntityIUserWebviewPanelMission)record, db.EntityIUserWebviewPanelMissionTable, r => db.EntityIUserWebviewPanelMissionTable.FindByUserIdAndWebviewPanelMissionPageId((r.UserId, r.WebviewPanelMissionPageId)))
        };
    }

    public static void Append(this DarkUserDatabaseBuilder builder, string tableName, IEnumerable<object> records)
    {
        // CUSTOM: Don't throw if a certain user data was not found
        if (!parsers.TryGetValue(tableName, out var parser))
        {
            return; //throw new ArgumentNullException();
        }

        if (!appenders.TryGetValue(tableName, out var appender))
        {
            return; //throw new ArgumentNullException();
        }

        appender(builder, parser(records));
    }

    public static void Diff(this DarkUserMemoryDatabase db, string tableName, IEnumerable<object> records)
    {
        if (!parsers.TryGetValue(tableName, out var parser))
        {
            return; //throw new ArgumentNullException();
        }

        if (!differs.TryGetValue(tableName, out var differ))
        {
            return; //throw new ArgumentNullException();
        }

        foreach (var element in parser(records))
        {
            differ(db, element, true);
        }
    }

    public static void Remove(this DarkUserMemoryDatabase db, string tableName, IEnumerable<object> records)
    {
        if (!parsers.TryGetValue(tableName, out var parser))
        {
            return; //throw new ArgumentNullException();
        }

        if (!differs.TryGetValue(tableName, out var differ))
        {
            return; //throw new ArgumentNullException();
        }

        foreach (var element in parser(records))
        {
            differ(db, element, false);
        }
    }

    private static void ApplyData<T>(bool shouldUpdate, T updateRecord, TableBase<T> table, Func<T, T> findCurrentRecord)
    {
        if (shouldUpdate)
        {
            SetData(updateRecord, table, findCurrentRecord);
        }
        else
        {
            RemoveData(updateRecord, table, findCurrentRecord);
        }
    }

    private static void SetData<T>(T updateRecord, TableBase<T> table, Func<T, T> findCurrentRecord)
    {
        var rawTable = table.GetRawDataUnsafe();
        var currentRecord = findCurrentRecord(updateRecord);

        // TODO: Can this happen?
        if (currentRecord == null)
        {
            Array.Resize(ref rawTable, rawTable.Length + 1);
            rawTable[^1] = updateRecord;

            table.SetRawDataUnsafe(rawTable);

            return;
        }

        var index = Array.IndexOf(rawTable, currentRecord);
        rawTable[index] = updateRecord;
    }

    private static void RemoveData<T>(T deleteRecord, TableBase<T> table, Func<T, T> findCurrentRecord)
    {
        var rawTable = table.GetRawDataUnsafe();
        var currentRecord = findCurrentRecord(deleteRecord);

        var currentRecordIndex = Array.IndexOf(rawTable, currentRecord);
        Array.Copy(rawTable, currentRecordIndex + 1, rawTable, currentRecordIndex, rawTable.Length - currentRecordIndex - 1);
        Array.Resize(ref rawTable, rawTable.Length - 1);

        table.SetRawDataUnsafe(rawTable);
    }
}
