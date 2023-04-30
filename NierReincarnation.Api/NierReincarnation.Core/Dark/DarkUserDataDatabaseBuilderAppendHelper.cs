using Newtonsoft.Json.Linq;
using NierReincarnation.Core.Dark.Tables;
using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NierReincarnation.Core.Dark
{
    // CUSTOM: Mostly custom code on basis of the original to better utilize logic
    internal static class DarkUserDataDatabaseBuilderAppendHelper
    {
        private static readonly Dictionary<string, Func<IEnumerable<object>, IEnumerable<object>>> parsers; // 0x0
        private static readonly Dictionary<string, Action<DarkUserDatabaseBuilder, IEnumerable<object>>> appenders; // 0x0
        private static readonly Dictionary<string, Action<DarkUserMemoryDatabase, object, bool>> differs; // 0x0

        static DarkUserDataDatabaseBuilderAppendHelper()
        {
            parsers = new Dictionary<string, Func<IEnumerable<object>, IEnumerable<object>>>
            {
                ["IUser"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUser>()),
                ["IUserBeginnerCampaign"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserBeginnerCampaign>()),
                ["IUserBigHuntMaxScore"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserBigHuntMaxScore>()),
                ["IUserBigHuntProgressStatus"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserBigHuntProgressStatus>()),
                ["IUserBigHuntScheduleMaxScore"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserBigHuntScheduleMaxScore>()),
                ["IUserBigHuntStatus"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserBigHuntStatus>()),
                ["IUserBigHuntWeeklyMaxScore"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserBigHuntWeeklyMaxScore>()),
                ["IUserCageOrnamentReward"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserCageOrnamentReward>()),
                ["IUserCharacter"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserCharacter>()),
                ["IUserCharacterCostumeLevelBonus"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserCharacterCostumeLevelBonus>()),
                ["IUserCharacterRebirth"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserCharacterRebirth>()),
                ["IUserComebackCampaign"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserComebackCampaign>()),
                ["IUserCharacterBoardAbility"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserCharacterBoardAbility>()),
                ["IUserCharacterBoardStatusUp"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserCharacterBoardStatusUp>()),
                ["IUserConsumableItem"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserConsumableItem>()),
                ["IUserCostume"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserCostume>()),
                ["IUserCostumeActiveSkill"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserCostumeActiveSkill>()),
                ["IUserCompanion"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserCompanion>()),
                ["IUserDeck"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserDeck>()),
                ["IUserDeckCharacter"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserDeckCharacter>()),
                ["IUserDeckCharacterDressupCostume"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserDeckCharacterDressupCostume>()),
                ["IUserDeckSubWeaponGroup"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserDeckSubWeaponGroup>()),
                ["IUserDeckPartsGroup"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserDeckPartsGroup>()),
                ["IUserDeckTypeNote"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserDeckTypeNote>()),
                ["IUserEventQuestDailyGroupCompleteReward"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserEventQuestDailyGroupCompleteReward>()),
                ["IUserEventQuestGuerrillaFreeOpen"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserEventQuestGuerrillaFreeOpen>()),
                ["IUserEventQuestProgressStatus"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserEventQuestProgressStatus>()),
                ["IUserExtraQuestProgressStatus"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserExtraQuestProgressStatus>()),
                ["IUserGem"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserGem>()),
                ["IUserGimmick"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserGimmick>()),
                ["IUserGimmickOrnamentProgress"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserGimmickOrnamentProgress>()),
                ["IUserGimmickSequence"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserGimmickSequence>()),
                ["IUserMainQuestProgressStatus"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserMainQuestProgressStatus>()),
                ["IUserLimitedOpen"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserLimitedOpen>()),
                ["IUserMainQuestSeasonRoute"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserMainQuestSeasonRoute>()),
                ["IUserMaterial"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserMaterial>()),
                ["IUserParts"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserParts>()),
                ["IUserPartsStatusSub"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserPartsStatusSub>()),
                ["IUserProfile"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserProfile>()),
                ["IUserQuest"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserQuest>()),
                ["IUserQuestMission"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserQuestMission>()),
                ["IUserQuestSceneChoice"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserQuestSceneChoice>()),
                ["IUserQuestLimitContentStatusTable"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserQuestLimitContentStatusTable>()),
                ["IUserShopItem"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserShopItem>()),
                ["IUserStatus"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserStatus>()),
                ["IUserThought"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserThought>()),
                ["IUserWeapon"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserWeapon>()),
                ["IUserWeaponAbility"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserWeaponAbility>()),
                ["IUserWeaponNote"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserWeaponNote>()),
                ["IUserWeaponSkill"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserWeaponSkill>()),
            };
            appenders = new Dictionary<string, Action<DarkUserDatabaseBuilder, IEnumerable<object>>>
            {
                ["IUser"] = (builder, records) => builder.Append(records.Cast<EntityIUser>()),
                ["IUserBeginnerCampaign"] = (builder, records) => builder.Append(records.Cast<EntityIUserBeginnerCampaign>()),
                ["IUserBigHuntMaxScore"] = (builder, records) => builder.Append(records.Cast<EntityIUserBigHuntMaxScore>()),
                ["IUserBigHuntProgressStatus"] = (builder, records) => builder.Append(records.Cast<EntityIUserBigHuntProgressStatus>()),
                ["IUserBigHuntScheduleMaxScore"] = (builder, records) => builder.Append(records.Cast<EntityIUserBigHuntScheduleMaxScore>()),
                ["IUserBigHuntStatus"] = (builder, records) => builder.Append(records.Cast<EntityIUserBigHuntStatus>()),
                ["IUserBigHuntWeeklyMaxScore"] = (builder, records) => builder.Append(records.Cast<EntityIUserBigHuntWeeklyMaxScore>()),
                ["IUserCageOrnamentReward"] = (builder, records) => builder.Append(records.Cast<EntityIUserCageOrnamentReward>()),
                ["IUserCharacter"] = (builder, records) => builder.Append(records.Cast<EntityIUserCharacter>()),
                ["IUserCharacterCostumeLevelBonus"] = (builder, records) => builder.Append(records.Cast<EntityIUserCharacterCostumeLevelBonus>()),
                ["IUserCharacterRebirth"] = (builder, records) => builder.Append(records.Cast<EntityIUserCharacterRebirth>()),
                ["IUserComebackCampaign"] = (builder, records) => builder.Append(records.Cast<EntityIUserComebackCampaign>()),
                ["IUserCharacterBoardAbility"] = (builder, records) => builder.Append(records.Cast<EntityIUserCharacterBoardAbility>()),
                ["IUserCharacterBoardStatusUp"] = (builder, records) => builder.Append(records.Cast<EntityIUserCharacterBoardStatusUp>()),
                ["IUserConsumableItem"] = (builder, records) => builder.Append(records.Cast<EntityIUserConsumableItem>()),
                ["IUserCostume"] = (builder, records) => builder.Append(records.Cast<EntityIUserCostume>()),
                ["IUserCostumeActiveSkill"] = (builder, records) => builder.Append(records.Cast<EntityIUserCostumeActiveSkill>()),
                ["IUserCompanion"] = (builder, records) => builder.Append(records.Cast<EntityIUserCompanion>()),
                ["IUserDeck"] = (builder, records) => builder.Append(records.Cast<EntityIUserDeck>()),
                ["IUserDeckCharacter"] = (builder, records) => builder.Append(records.Cast<EntityIUserDeckCharacter>()),
                ["IUserDeckCharacterDressupCostume"] = (builder, records) => builder.Append(records.Cast<EntityIUserDeckCharacterDressupCostume>()),
                ["IUserDeckSubWeaponGroup"] = (builder, records) => builder.Append(records.Cast<EntityIUserDeckSubWeaponGroup>()),
                ["IUserDeckPartsGroup"] = (builder, records) => builder.Append(records.Cast<EntityIUserDeckPartsGroup>()),
                ["IUserDeckTypeNote"] = (builder, records) => builder.Append(records.Cast<EntityIUserDeckTypeNote>()),
                ["IUserEventQuestDailyGroupCompleteReward"] = (builder, records) => builder.Append(records.Cast<EntityIUserEventQuestDailyGroupCompleteReward>()),
                ["IUserEventQuestGuerrillaFreeOpen"] = (builder, records) => builder.Append(records.Cast<EntityIUserEventQuestGuerrillaFreeOpen>()),
                ["IUserEventQuestProgressStatus"] = (builder, records) => builder.Append(records.Cast<EntityIUserEventQuestProgressStatus>()),
                ["IUserExtraQuestProgressStatus"] = (builder, records) => builder.Append(records.Cast<EntityIUserExtraQuestProgressStatus>()),
                ["IUserGem"] = (builder, records) => builder.Append(records.Cast<EntityIUserGem>()),
                ["IUserGimmick"] = (builder, records) => builder.Append(records.Cast<EntityIUserGimmick>()),
                ["IUserGimmickOrnamentProgress"] = (builder, records) => builder.Append(records.Cast<EntityIUserGimmickOrnamentProgress>()),
                ["IUserGimmickSequence"] = (builder, records) => builder.Append(records.Cast<EntityIUserGimmickSequence>()),
                ["IUserMainQuestProgressStatus"] = (builder, records) => builder.Append(records.Cast<EntityIUserMainQuestProgressStatus>()),
                ["IUserLimitedOpen"] = (builder, records) => builder.Append(records.Cast<EntityIUserLimitedOpen>()),
                ["IUserMainQuestSeasonRoute"] = (builder, records) => builder.Append(records.Cast<EntityIUserMainQuestSeasonRoute>()),
                ["IUserMaterial"] = (builder, records) => builder.Append(records.Cast<EntityIUserMaterial>()),
                ["IUserParts"] = (builder, records) => builder.Append(records.Cast<EntityIUserParts>()),
                ["IUserPartsStatusSub"] = (builder, records) => builder.Append(records.Cast<EntityIUserPartsStatusSub>()),
                ["IUserProfile"] = (builder, records) => builder.Append(records.Cast<EntityIUserProfile>()),
                ["IUserQuest"] = (builder, records) => builder.Append(records.Cast<EntityIUserQuest>()),
                ["IUserQuestMission"] = (builder, records) => builder.Append(records.Cast<EntityIUserQuestMission>()),
                ["IUserQuestSceneChoice"] = (builder, records) => builder.Append(records.Cast<EntityIUserQuestSceneChoice>()),
                ["IUserQuestLimitContentStatusTable"] = (builder, records) => builder.Append(records.Cast<EntityIUserQuestLimitContentStatus>()),
                ["IUserShopItem"] = (builder, records) => builder.Append(records.Cast<EntityIUserShopItem>()),
                ["IUserStatus"] = (builder, records) => builder.Append(records.Cast<EntityIUserStatus>()),
                ["IUserThought"] = (builder, records) => builder.Append(records.Cast<EntityIUserThought>()),
                ["IUserWeapon"] = (builder, records) => builder.Append(records.Cast<EntityIUserWeapon>()),
                ["IUserWeaponAbility"] = (builder, records) => builder.Append(records.Cast<EntityIUserWeaponAbility>()),
                ["IUserWeaponNote"] = (builder, records) => builder.Append(records.Cast<EntityIUserWeaponNote>()),
                ["IUserWeaponSkill"] = (builder, records) => builder.Append(records.Cast<EntityIUserWeaponSkill>()),
            };
            differs = new Dictionary<string, Action<DarkUserMemoryDatabase, object, bool>>
            {
                ["IUser"] = (db, record, mode) => ApplyData(mode, (EntityIUser)record, db.EntityIUserTable, r => db.EntityIUserTable.FindByUserId(r.UserId)),
                ["IUserBeginnerCampaign"] = (db, record, mode) => ApplyData(mode, (EntityIUserBeginnerCampaign)record, db.EntityIUserBeginnerCampaignTable, r => db.EntityIUserBeginnerCampaignTable.FindByUserId(r.UserId)),
                ["IUserBigHuntMaxScore"] = (db, record, mode) => ApplyData(mode, (EntityIUserBigHuntMaxScore)record, db.EntityIUserBigHuntMaxScoreTable, r => db.EntityIUserBigHuntMaxScoreTable.FindByUserIdAndBigHuntBossId((r.UserId, r.BigHuntBossId))),
                ["IUserBigHuntProgressStatus"] = (db, record, mode) => ApplyData(mode, (EntityIUserBigHuntProgressStatus)record, db.EntityIUserBigHuntProgressStatusTable, r => db.EntityIUserBigHuntProgressStatusTable.FindByUserId(r.UserId)),
                ["IUserBigHuntScheduleMaxScore"] = (db, record, mode) => ApplyData(mode, (EntityIUserBigHuntScheduleMaxScore)record, db.EntityIUserBigHuntScheduleMaxScoreTable, r => db.EntityIUserBigHuntScheduleMaxScoreTable.FindByUserIdAndBigHuntScheduleIdAndBigHuntBossId((r.UserId, r.BigHuntScheduleId, r.BigHuntBossId))),
                ["IUserBigHuntStatus"] = (db, record, mode) => ApplyData(mode, (EntityIUserBigHuntStatus)record, db.EntityIUserBigHuntStatusTable, r => db.EntityIUserBigHuntStatusTable.FindByUserIdAndBigHuntBossQuestId((r.UserId, r.BigHuntBossQuestId))),
                ["IUserBigHuntWeeklyMaxScore"] = (db, record, mode) => ApplyData(mode, (EntityIUserBigHuntWeeklyMaxScore)record, db.EntityIUserBigHuntWeeklyMaxScoreTable, r => { db.EntityIUserBigHuntWeeklyMaxScoreTable.TryFindByUserIdAndBigHuntWeeklyVersionAndAttributeType((r.UserId, r.BigHuntWeeklyVersion, r.AttributeType), out var element); return element; }),
                ["IUserCageOrnamentReward"] = (db, record, mode) => ApplyData(mode, (EntityIUserCageOrnamentReward)record, db.EntityIUserCageOrnamentRewardTable, r => db.EntityIUserCageOrnamentRewardTable.FindByUserIdAndCageOrnamentId((r.UserId, r.CageOrnamentId))),
                ["IUserCharacter"] = (db, record, mode) => ApplyData(mode, (EntityIUserCharacter)record, db.EntityIUserCharacterTable, r => db.EntityIUserCharacterTable.FindByUserIdAndCharacterId((r.UserId, r.CharacterId))),
                ["IUserCharacterCostumeLevelBonus"] = (db, record, mode) => ApplyData(mode, (EntityIUserCharacterCostumeLevelBonus)record, db.EntityIUserCharacterCostumeLevelBonusTable, r => { db.EntityIUserCharacterCostumeLevelBonusTable.TryFindByUserIdAndCharacterIdAndStatusCalculationType((r.UserId, r.CharacterId, r.StatusCalculationType), out var element); return element; }),
                ["IUserCharacterRebirth"] = (db, record, mode) => ApplyData(mode, (EntityIUserCharacterRebirth)record, db.EntityIUserCharacterRebirthTable, r => db.EntityIUserCharacterRebirthTable.FindByUserIdAndCharacterId((r.UserId, r.CharacterId))),
                ["IUserComebackCampaign"] = (db, record, mode) => ApplyData(mode, (EntityIUserComebackCampaign)record, db.EntityIUserComebackCampaignTable, r => db.EntityIUserComebackCampaignTable.FindByUserId(r.UserId)),
                ["IUserCharacterBoardAbility"] = (db, record, mode) => ApplyData(mode, (EntityIUserCharacterBoardAbility)record, db.EntityIUserCharacterBoardAbilityTable, r => { db.EntityIUserCharacterBoardAbilityTable.TryFindByUserIdAndCharacterIdAndAbilityId((r.UserId, r.CharacterId, r.AbilityId), out var element); return element; }),
                ["IUserCharacterBoardStatusUp"] = (db, record, mode) => ApplyData(mode, (EntityIUserCharacterBoardStatusUp)record, db.EntityIUserCharacterBoardStatusUpTable, r => db.EntityIUserCharacterBoardStatusUpTable.FindByUserIdAndCharacterIdAndStatusCalculationType((r.UserId, r.CharacterId, r.StatusCalculationType))),
                ["IUserConsumableItem"] = (db, record, mode) => ApplyData(mode, (EntityIUserConsumableItem)record, db.EntityIUserConsumableItemTable, r => { db.EntityIUserConsumableItemTable.TryFindByUserIdAndConsumableItemId((r.UserId, r.ConsumableItemId), out var element); return element; }),
                ["IUserCostume"] = (db, record, mode) => ApplyData(mode, (EntityIUserCostume)record, db.EntityIUserCostumeTable, r => db.EntityIUserCostumeTable.FindByUserIdAndUserCostumeUuid((r.UserId, r.UserCostumeUuid))),
                ["IUserCostumeActiveSkill"] = (db, record, mode) => ApplyData(mode, (EntityIUserCostumeActiveSkill)record, db.EntityIUserCostumeActiveSkillTable, r => db.EntityIUserCostumeActiveSkillTable.FindByUserIdAndUserCostumeUuid((r.UserId, r.UserCostumeUuid))),
                ["IUserCompanion"] = (db, record, mode) => ApplyData(mode, (EntityIUserCompanion)record, db.EntityIUserCompanionTable, r => db.EntityIUserCompanionTable.FindByUserIdAndUserCompanionUuid((r.UserId, r.UserCompanionUuid))),
                ["IUserDeck"] = (db, record, mode) => ApplyData(mode, (EntityIUserDeck)record, db.EntityIUserDeckTable, r => db.EntityIUserDeckTable.FindByUserIdAndDeckTypeAndUserDeckNumber((r.UserId, r.DeckType, r.UserDeckNumber))),
                ["IUserDeckCharacter"] = (db, record, mode) => ApplyData(mode, (EntityIUserDeckCharacter)record, db.EntityIUserDeckCharacterTable, r => db.EntityIUserDeckCharacterTable.FindByUserIdAndUserDeckCharacterUuid((r.UserId, r.UserDeckCharacterUuid))),
                ["IUserDeckCharacterDressupCostume"] = (db, record, mode) => ApplyData(mode, (EntityIUserDeckCharacterDressupCostume)record, db.EntityIUserDeckCharacterDressupCostumeTable, r => { db.EntityIUserDeckCharacterDressupCostumeTable.TryFindByUserIdAndUserDeckCharacterUuid((r.UserId, r.UserDeckCharacterUuid), out var element); return element; }),
                ["IUserDeckSubWeaponGroup"] = (db, record, mode) => ApplyData(mode, (EntityIUserDeckSubWeaponGroup)record, db.EntityIUserDeckSubWeaponGroupTable, r => db.EntityIUserDeckSubWeaponGroupTable.FindByUserIdAndUserDeckCharacterUuidAndUserWeaponUuid((r.UserId, r.UserDeckCharacterUuid, r.UserWeaponUuid))),
                ["IUserDeckPartsGroup"] = (db, record, mode) => ApplyData(mode, (EntityIUserDeckPartsGroup)record, db.EntityIUserDeckPartsGroupTable, r => db.EntityIUserDeckPartsGroupTable.FindByUserIdAndUserDeckCharacterUuidAndUserPartsUuid((r.UserId, r.UserDeckCharacterUuid, r.UserPartsUuid))),
                ["IUserDeckTypeNote"] = (db, record, mode) => ApplyData(mode, (EntityIUserDeckTypeNote)record, db.EntityIUserDeckTypeNoteTable, r => db.EntityIUserDeckTypeNoteTable.FindByUserIdAndDeckType((r.UserId, r.DeckType))),
                ["IUserEventQuestDailyGroupCompleteReward"] = (db, record, mode) => ApplyData(mode, (EntityIUserEventQuestDailyGroupCompleteReward)record, db.EntityIUserEventQuestDailyGroupCompleteRewardTable, r => { db.EntityIUserEventQuestDailyGroupCompleteRewardTable.TryFindByUserId(r.UserId, out var element); return element; }),
                ["IUserEventQuestGuerrillaFreeOpen"] = (db, record, mode) => ApplyData(mode, (EntityIUserEventQuestGuerrillaFreeOpen)record, db.EntityIUserEventQuestGuerrillaFreeOpenTable, r => { db.EntityIUserEventQuestGuerrillaFreeOpenTable.TryFindByUserId(r.UserId, out var element); return element; }),
                ["IUserEventQuestProgressStatus"] = (db, record, mode) => ApplyData(mode, (EntityIUserEventQuestProgressStatus)record, db.EntityIUserEventQuestProgressStatusTable, r => db.EntityIUserEventQuestProgressStatusTable.FindByUserId(r.UserId)),
                ["IUserExtraQuestProgressStatus"] = (db, record, mode) => ApplyData(mode, (EntityIUserExtraQuestProgressStatus)record, db.EntityIUserExtraQuestProgressStatusTable, r => db.EntityIUserExtraQuestProgressStatusTable.FindByUserId(r.UserId)),
                ["IUserGem"] = (db, record, mode) => ApplyData(mode, (EntityIUserGem)record, db.EntityIUserGemTable, r => db.EntityIUserGemTable.FindByUserId(r.UserId)),
                ["IUserGimmick"] = (db, record, mode) => ApplyData(mode, (EntityIUserGimmick)record, db.EntityIUserGimmickTable, r => db.EntityIUserGimmickTable.FindByUserId((r.UserId, r.GimmickSequenceScheduleId, r.GimmickSequenceId, r.GimmickId))),
                ["IUserGimmickOrnamentProgress"] = (db, record, mode) => ApplyData(mode, (EntityIUserGimmickOrnamentProgress)record, db.EntityIUserGimmickOrnamentProgressTable, r => db.EntityIUserGimmickOrnamentProgressTable.FindByUserId((r.UserId, r.GimmickSequenceScheduleId, r.GimmickSequenceId, r.GimmickId, r.GimmickOrnamentIndex))),
                ["IUserGimmickSequence"] = (db, record, mode) => ApplyData(mode, (EntityIUserGimmickSequence)record, db.EntityIUserGimmickSequenceTable, r => db.EntityIUserGimmickSequenceTable.FindByUserId((r.UserId, r.GimmickSequenceScheduleId))),
                ["IUserMainQuestProgressStatus"] = (db, record, mode) => ApplyData(mode, (EntityIUserMainQuestProgressStatus)record, db.EntityIUserMainQuestProgressStatusTable, r => db.EntityIUserMainQuestProgressStatusTable.FindByUserId(r.UserId)),
                ["IUserLimitedOpen"] = (db, record, mode) => ApplyData(mode, (EntityIUserLimitedOpen)record, db.EntityIUserLimitedOpenTable, r => db.EntityIUserLimitedOpenTable.FindByUserIdAndLimitedOpenTargetTypeAndTargetId((r.UserId, r.LimitedOpenTargetType, r.TargetId))),
                ["IUserMainQuestSeasonRoute"] = (db, record, mode) => ApplyData(mode, (EntityIUserMainQuestSeasonRoute)record, db.EntityIUserMainQuestSeasonRouteTable, r => db.EntityIUserMainQuestSeasonRouteTable.FindByUserIdAndMainQuestSeasonId((r.UserId, r.MainQuestSeasonId))),
                ["IUserMaterial"] = (db, record, mode) => ApplyData(mode, (EntityIUserMaterial)record, db.EntityIUserMaterialTable, r => db.EntityIUserMaterialTable.FindByUserIdAndMaterialId((r.UserId, r.MaterialId))),
                ["IUserParts"] = (db, record, mode) => ApplyData(mode, (EntityIUserParts)record, db.EntityIUserPartsTable, r => db.EntityIUserPartsTable.FindByUserIdAndUserPartsUuid((r.UserId, r.UserPartsUuid))),
                ["IUserPartsStatusSub"] = (db, record, mode) => ApplyData(mode, (EntityIUserPartsStatusSub)record, db.EntityIUserPartsStatusSubTable, r => db.EntityIUserPartsStatusSubTable.FindByUserIdAndUserPartsUuidAndStatusIndex((r.UserId, r.UserPartsUuid, r.StatusIndex))),
                ["IUserProfile"] = (db, record, mode) => ApplyData(mode, (EntityIUserProfile)record, db.EntityIUserProfileTable, r => db.EntityIUserProfileTable.FindByUserId(r.UserId)),
                ["IUserQuest"] = (db, record, mode) => ApplyData(mode, (EntityIUserQuest)record, db.EntityIUserQuestTable, r => db.EntityIUserQuestTable.FindByUserIdAndQuestId((r.UserId, r.QuestId))),
                ["IUserQuestMission"] = (db, record, mode) => ApplyData(mode, (EntityIUserQuestMission)record, db.EntityIUserQuestMissionTable, r => db.EntityIUserQuestMissionTable.FindByUserIdAndQuestIdAndQuestMissionId((r.UserId, r.QuestId, r.QuestMissionId))),
                ["IUserQuestSceneChoice"] = (db, record, mode) => ApplyData(mode, (EntityIUserQuestSceneChoice)record, db.EntityIUserQuestSceneChoiceTable, r => { db.EntityIUserQuestSceneChoiceTable.TryFindByUserIdAndQuestSceneChoiceGroupingId((r.UserId, r.QuestSceneChoiceGroupingId), out var element); return element; }),
                ["IUserQuestLimitContentStatusTable"] = (db, record, mode) => ApplyData(mode, (EntityIUserQuestLimitContentStatus)record, db.EntityIUserQuestLimitContentStatusTable, r => db.EntityIUserQuestLimitContentStatusTable.FindByUserIdAndQuestId((r.UserId, r.QuestId))),
                ["IUserShopItem"] = (db, record, mode) => ApplyData(mode, (EntityIUserShopItem)record, db.EntityIUserShopItemTable, r => db.EntityIUserShopItemTable.FindByUserIdAndShopItemId((r.UserId, r.ShopItemId))),
                ["IUserStatus"] = (db, record, mode) => ApplyData(mode, (EntityIUserStatus)record, db.EntityIUserStatusTable, r => db.EntityIUserStatusTable.FindByUserId(r.UserId)),
                ["IUserThought"] = (db, record, mode) => ApplyData(mode, (EntityIUserThought)record, db.EntityIUserThoughtTable, r => { db.EntityIUserThoughtTable.TryFindByUserIdAndUserThoughtUuid((r.UserId, r.UserThoughtUuid), out var element); return element; }),
                ["IUserWeapon"] = (db, record, mode) => ApplyData(mode, (EntityIUserWeapon)record, db.EntityIUserWeaponTable, r => db.EntityIUserWeaponTable.FindByUserIdAndUserWeaponUuid((r.UserId, r.UserWeaponUuid))),
                ["IUserWeaponAbility"] = (db, record, mode) => ApplyData(mode, (EntityIUserWeaponAbility)record, db.EntityIUserWeaponAbilityTable, r => { db.EntityIUserWeaponAbilityTable.TryFindByUserIdAndUserWeaponUuidAndSlotNumber((r.UserId, r.UserWeaponUuid, r.SlotNumber), out var element); return element; }),
                ["IUserWeaponNote"] = (db, record, mode) => ApplyData(mode, (EntityIUserWeaponNote)record, db.EntityIUserWeaponNoteTable, r => { db.EntityIUserWeaponNoteTable.TryFindByUserIdAndWeaponId((r.UserId, r.WeaponId), out var element); return element; }),
                ["IUserWeaponSkill"] = (db, record, mode) => ApplyData(mode, (EntityIUserWeaponSkill)record, db.EntityIUserWeaponSkillTable, r => { db.EntityIUserWeaponSkillTable.TryFindByUserIdAndUserWeaponUuidAndSlotNumber((r.UserId, r.UserWeaponUuid, r.SlotNumber), out var element); return element; }),
            };
        }

        public static void Append(this DarkUserDatabaseBuilder builder, string tableName, IEnumerable<object> records)
        {
            // CUSTOM: Don't throw if a certain user data was not found
            if (!parsers.TryGetValue(tableName, out var parser))
                return; //throw new ArgumentNullException();
            if (!appenders.TryGetValue(tableName, out var appender))
                return; //throw new ArgumentNullException();

            appender(builder, parser(records));
        }

        public static void Diff(this DarkUserMemoryDatabase db, string tableName, IEnumerable<object> records)
        {
            if (!parsers.TryGetValue(tableName, out var parser))
                return; //throw new ArgumentNullException();
            if (!differs.TryGetValue(tableName, out var differ))
                return; //throw new ArgumentNullException();

            foreach (var element in parser(records))
                differ(db, element, true);
        }

        public static void Delete(this DarkUserMemoryDatabase db, string tableName, IEnumerable<object> records)
        {
            if (!parsers.TryGetValue(tableName, out var parser))
                return; //throw new ArgumentNullException();
            if (!differs.TryGetValue(tableName, out var differ))
                return; //throw new ArgumentNullException();

            foreach (var element in parser(records))
                differ(db, element, false);
        }

        private static void ApplyData<T>(bool shouldUpdate, T updateRecord, TableBase<T> table, Func<T, T> findCurrentRecord)
        {
            if (shouldUpdate)
                SetData(updateRecord, table, findCurrentRecord);
            else
                RemoveData(updateRecord, table, findCurrentRecord);
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
}
