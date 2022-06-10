using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    // CUSTOM: Mostly custom code on basis of the original to better utilize logic
    static class DarkUserDataDatabaseBuilderAppendHelper
    {
        private static readonly Dictionary<string, Func<IEnumerable<object>, IEnumerable<object>>> parsers; // 0x0
        private static readonly Dictionary<string, Action<DarkUserDatabaseBuilder, IEnumerable<object>>> appenders; // 0x0
        private static readonly Dictionary<string, Action<DarkUserMemoryDatabase, object>> differs; // 0x0

        static DarkUserDataDatabaseBuilderAppendHelper()
        {
            parsers = new Dictionary<string, Func<IEnumerable<object>, IEnumerable<object>>>
            {
                ["IUser"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUser>()),
                ["IUserBigHuntMaxScore"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserBigHuntMaxScore>()),
                ["IUserBigHuntProgressStatus"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserBigHuntProgressStatus>()),
                ["IUserBigHuntStatus"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserBigHuntStatus>()),
                ["IUserCharacter"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserCharacter>()),
                ["IUserCharacterCostumeLevelBonus"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserCharacterCostumeLevelBonus>()),
                ["IUserCharacterBoardAbility"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserCharacterBoardAbility>()),
                ["IUserCharacterBoardStatusUp"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserCharacterBoardStatusUp>()),
                ["IUserConsumableItem"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserConsumableItem>()),
                ["IUserCostume"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserCostume>()),
                ["IUserCostumeActiveSkill"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserCostumeActiveSkill>()),
                ["IUserCompanion"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserCompanion>()),
                ["IUserDeck"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserDeck>()),
                ["IUserDeckCharacter"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserDeckCharacter>()),
                ["IUserDeckSubWeaponGroup"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserDeckSubWeaponGroup>()),
                ["IUserDeckPartsGroup"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserDeckPartsGroup>()),
                ["IUserDeckTypeNote"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserDeckTypeNote>()),
                ["IUserEventQuestProgressStatus"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserEventQuestProgressStatus>()),
                ["IUserExtraQuestProgressStatus"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserExtraQuestProgressStatus>()),
                ["IUserGem"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserGem>()),
                ["IUserMainQuestProgressStatus"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserMainQuestProgressStatus>()),
                ["IUserLimitedOpen"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserLimitedOpen>()),
                ["IUserMaterial"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserMaterial>()),
                ["IUserParts"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserParts>()),
                ["IUserPartsStatusSub"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserPartsStatusSub>()),
                ["IUserProfile"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserProfile>()),
                ["IUserQuest"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserQuest>()),
                ["IUserQuestMission"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserQuestMission>()),
                ["IUserShopItem"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserShopItem>()),
                ["IUserStatus"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserStatus>()),
                ["IUserWeapon"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserWeapon>()),
                ["IUserWeaponAbility"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserWeaponAbility>()),
                ["IUserWeaponNote"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserWeaponNote>()),
                ["IUserWeaponSkill"] = records => records.Select(r => ((JObject)r).ToObject<EntityIUserWeaponSkill>()),
            };
            appenders = new Dictionary<string, Action<DarkUserDatabaseBuilder, IEnumerable<object>>>
            {
                ["IUser"] = (builder, records) => builder.Append(records.Cast<EntityIUser>()),
                ["IUserBigHuntMaxScore"] = (builder, records) => builder.Append(records.Cast<EntityIUserBigHuntMaxScore>()),
                ["IUserBigHuntProgressStatus"] = (builder, records) => builder.Append(records.Cast<EntityIUserBigHuntProgressStatus>()),
                ["IUserBigHuntStatus"] = (builder, records) => builder.Append(records.Cast<EntityIUserBigHuntStatus>()),
                ["IUserCharacter"] = (builder, records) => builder.Append(records.Cast<EntityIUserCharacter>()),
                ["IUserCharacterCostumeLevelBonus"] = (builder, records) => builder.Append(records.Cast<EntityIUserCharacterCostumeLevelBonus>()),
                ["IUserCharacterBoardAbility"] = (builder, records) => builder.Append(records.Cast<EntityIUserCharacterBoardAbility>()),
                ["IUserCharacterBoardStatusUp"] = (builder, records) => builder.Append(records.Cast<EntityIUserCharacterBoardStatusUp>()),
                ["IUserConsumableItem"] = (builder, records) => builder.Append(records.Cast<EntityIUserConsumableItem>()),
                ["IUserCostume"] = (builder, records) => builder.Append(records.Cast<EntityIUserCostume>()),
                ["IUserCostumeActiveSkill"] = (builder, records) => builder.Append(records.Cast<EntityIUserCostumeActiveSkill>()),
                ["IUserCompanion"] = (builder, records) => builder.Append(records.Cast<EntityIUserCompanion>()),
                ["IUserDeck"] = (builder, records) => builder.Append(records.Cast<EntityIUserDeck>()),
                ["IUserDeckCharacter"] = (builder, records) => builder.Append(records.Cast<EntityIUserDeckCharacter>()),
                ["IUserDeckSubWeaponGroup"] = (builder, records) => builder.Append(records.Cast<EntityIUserDeckSubWeaponGroup>()),
                ["IUserDeckPartsGroup"] = (builder, records) => builder.Append(records.Cast<EntityIUserDeckPartsGroup>()),
                ["IUserDeckTypeNote"] = (builder, records) => builder.Append(records.Cast<EntityIUserDeckTypeNote>()),
                ["IUserEventQuestProgressStatus"] = (builder, records) => builder.Append(records.Cast<EntityIUserEventQuestProgressStatus>()),
                ["IUserExtraQuestProgressStatus"] = (builder, records) => builder.Append(records.Cast<EntityIUserExtraQuestProgressStatus>()),
                ["IUserGem"] = (builder, records) => builder.Append(records.Cast<EntityIUserGem>()),
                ["IUserMainQuestProgressStatus"] = (builder, records) => builder.Append(records.Cast<EntityIUserMainQuestProgressStatus>()),
                ["IUserLimitedOpen"] = (builder, records) => builder.Append(records.Cast<EntityIUserLimitedOpen>()),
                ["IUserMaterial"] = (builder, records) => builder.Append(records.Cast<EntityIUserMaterial>()),
                ["IUserParts"] = (builder, records) => builder.Append(records.Cast<EntityIUserParts>()),
                ["IUserPartsStatusSub"] = (builder, records) => builder.Append(records.Cast<EntityIUserPartsStatusSub>()),
                ["IUserProfile"] = (builder, records) => builder.Append(records.Cast<EntityIUserProfile>()),
                ["IUserQuest"] = (builder, records) => builder.Append(records.Cast<EntityIUserQuest>()),
                ["IUserQuestMission"] = (builder, records) => builder.Append(records.Cast<EntityIUserQuestMission>()),
                ["IUserShopItem"] = (builder, records) => builder.Append(records.Cast<EntityIUserShopItem>()),
                ["IUserStatus"] = (builder, records) => builder.Append(records.Cast<EntityIUserStatus>()),
                ["IUserWeapon"] = (builder, records) => builder.Append(records.Cast<EntityIUserWeapon>()),
                ["IUserWeaponAbility"] = (builder, records) => builder.Append(records.Cast<EntityIUserWeaponAbility>()),
                ["IUserWeaponNote"] = (builder, records) => builder.Append(records.Cast<EntityIUserWeaponNote>()),
                ["IUserWeaponSkill"] = (builder, records) => builder.Append(records.Cast<EntityIUserWeaponSkill>()),
            };
            differs = new Dictionary<string, Action<DarkUserMemoryDatabase, object>>
            {
                ["IUser"] = (db, record) => SetData(db, (EntityIUser)record, d => d.EntityIUserTable, (d, r) => d.EntityIUserTable.FindByUserId(r.UserId)),
                ["IUserBigHuntMaxScore"] = (db, record) => SetData(db, (EntityIUserBigHuntMaxScore)record, d => d.EntityIUserBigHuntMaxScoreTable, (d, r) => d.EntityIUserBigHuntMaxScoreTable.FindByUserIdAndBigHuntBossId((r.UserId, r.BigHuntBossId))),
                ["IUserBigHuntProgressStatus"] = (db, record) => SetData(db, (EntityIUserBigHuntProgressStatus)record, d => d.EntityIUserBigHuntProgressStatusTable, (d, r) => d.EntityIUserBigHuntProgressStatusTable.FindByUserId(r.UserId)),
                ["IUserBigHuntStatus"] = (db, record) => SetData(db, (EntityIUserBigHuntStatus)record, d => d.EntityIUserBigHuntStatusTable, (d, r) => d.EntityIUserBigHuntStatusTable.FindByUserIdAndBigHuntBossQuestId((r.UserId, r.BigHuntBossQuestId))),
                ["IUserCharacter"] = (db, record) => SetData(db, (EntityIUserCharacter)record, d => d.EntityIUserCharacterTable, (d, r) => d.EntityIUserCharacterTable.FindByUserIdAndCharacterId((r.UserId, r.CharacterId))),
                ["IUserCharacterCostumeLevelBonus"] = (db, record) => SetData(db, (EntityIUserCharacterCostumeLevelBonus)record, d => d.EntityIUserCharacterCostumeLevelBonusTable, (d, r) => d.EntityIUserCharacterCostumeLevelBonusTable.FindByUserIdAndCharacterIdAndStatusCalculationType((r.UserId, r.CharacterId, r.StatusCalculationType))),
                ["IUserCharacterBoardAbility"] = (db, record) => SetData(db, (EntityIUserCharacterBoardAbility)record, d => d.EntityIUserCharacterBoardAbilityTable, (d, r) => d.EntityIUserCharacterBoardAbilityTable.FindByUserIdAndCharacterIdAndAbilityId((r.UserId, r.CharacterId, r.AbilityId))),
                ["IUserCharacterBoardStatusUp"] = (db, record) => SetData(db, (EntityIUserCharacterBoardStatusUp)record, d => d.EntityIUserCharacterBoardStatusUpTable, (d, r) => d.EntityIUserCharacterBoardStatusUpTable.FindByUserIdAndCharacterIdAndStatusCalculationType((r.UserId, r.CharacterId, r.StatusCalculationType))),
                ["IUserConsumableItem"] = (db, record) => SetData(db, (EntityIUserConsumableItem)record, d => d.EntityIUserConsumableItemTable, (d, r) => d.EntityIUserConsumableItemTable.FindByUserIdAndConsumableItemId((r.UserId, r.ConsumableItemId))),
                ["IUserCostume"] = (db, record) => SetData(db, (EntityIUserCostume)record, d => d.EntityIUserCostumeTable, (d, r) => d.EntityIUserCostumeTable.FindByUserIdAndUserCostumeUuid((r.UserId, r.UserCostumeUuid))),
                ["IUserCostumeActiveSkill"] = (db, record) => SetData(db, (EntityIUserCostumeActiveSkill)record, d => d.EntityIUserCostumeActiveSkillTable, (d, r) => d.EntityIUserCostumeActiveSkillTable.FindByUserIdAndUserCostumeUuid((r.UserId, r.UserCostumeUuid))),
                ["IUserCompanion"] = (db, record) => SetData(db, (EntityIUserCompanion)record, d => d.EntityIUserCompanionTable, (d, r) => d.EntityIUserCompanionTable.FindByUserIdAndUserCompanionUuid((r.UserId, r.UserCompanionUuid))),
                ["IUserDeck"] = (db, record) => SetData(db, (EntityIUserDeck)record, d => d.EntityIUserDeckTable, (d, r) => d.EntityIUserDeckTable.FindByUserIdAndDeckTypeAndUserDeckNumber((r.UserId, r.DeckType, r.UserDeckNumber))),
                ["IUserDeckCharacter"] = (db, record) => SetData(db, (EntityIUserDeckCharacter)record, d => d.EntityIUserDeckCharacterTable, (d, r) => d.EntityIUserDeckCharacterTable.FindByUserIdAndUserDeckCharacterUuid((r.UserId, r.UserDeckCharacterUuid))),
                ["IUserDeckSubWeaponGroup"] = (db, record) => SetData(db, (EntityIUserDeckSubWeaponGroup)record, d => d.EntityIUserDeckSubWeaponGroupTable, (d, r) => d.EntityIUserDeckSubWeaponGroupTable.FindByUserIdAndUserDeckCharacterUuidAndUserWeaponUuid((r.UserId, r.UserDeckCharacterUuid, r.UserWeaponUuid))),
                ["IUserDeckPartsGroup"] = (db, record) => SetData(db, (EntityIUserDeckPartsGroup)record, d => d.EntityIUserDeckPartsGroupTable, (d, r) => d.EntityIUserDeckPartsGroupTable.FindByUserIdAndUserDeckCharacterUuidAndUserPartsUuid((r.UserId, r.UserDeckCharacterUuid, r.UserPartsUuid))),
                ["IUserDeckTypeNote"] = (db, record) => SetData(db, (EntityIUserDeckTypeNote)record, d => d.EntityIUserDeckTypeNoteTable, (d, r) => d.EntityIUserDeckTypeNoteTable.FindByUserIdAndDeckType((r.UserId, r.DeckType))),
                ["IUserEventQuestProgressStatus"] = (db, record) => SetData(db, (EntityIUserEventQuestProgressStatus)record, d => d.EntityIUserEventQuestProgressStatusTable, (d, r) => d.EntityIUserEventQuestProgressStatusTable.FindByUserId(r.UserId)),
                ["IUserExtraQuestProgressStatus"] = (db, record) => SetData(db, (EntityIUserExtraQuestProgressStatus)record, d => d.EntityIUserExtraQuestProgressStatusTable, (d, r) => d.EntityIUserExtraQuestProgressStatusTable.FindByUserId(r.UserId)),
                ["IUserGem"] = (db, record) => SetData(db, (EntityIUserGem)record, d => d.EntityIUserGemTable, (d, r) => d.EntityIUserGemTable.FindByUserId(r.UserId)),
                ["IUserMainQuestProgressStatus"] = (db, record) => SetData(db, (EntityIUserMainQuestProgressStatus)record, d => d.EntityIUserMainQuestProgressStatusTable, (d, r) => d.EntityIUserMainQuestProgressStatusTable.FindByUserId(r.UserId)),
                ["IUserLimitedOpen"] = (db, record) => SetData(db, (EntityIUserLimitedOpen)record, d => d.EntityIUserLimitedOpenTable, (d, r) => d.EntityIUserLimitedOpenTable.FindByUserIdAndLimitedOpenTargetTypeAndTargetId((r.UserId, r.LimitedOpenTargetType, r.TargetId))),
                ["IUserMaterial"] = (db, record) => SetData(db, (EntityIUserMaterial)record, d => d.EntityIUserMaterialTable, (d, r) => d.EntityIUserMaterialTable.FindByUserIdAndMaterialId((r.UserId, r.MaterialId))),
                ["IUserParts"] = (db, record) => SetData(db, (EntityIUserParts)record, d => d.EntityIUserPartsTable, (d, r) => d.EntityIUserPartsTable.FindByUserIdAndUserPartsUuid((r.UserId, r.UserPartsUuid))),
                ["IUserPartsStatusSub"] = (db, record) => SetData(db, (EntityIUserPartsStatusSub)record, d => d.EntityIUserPartsStatusSubTable, (d, r) => d.EntityIUserPartsStatusSubTable.FindByUserIdAndUserPartsUuidAndStatusIndex((r.UserId, r.UserPartsUuid, r.StatusIndex))),
                ["IUserProfile"] = (db, record) => SetData(db, (EntityIUserProfile)record, d => d.EntityIUserProfileTable, (d, r) => d.EntityIUserProfileTable.FindByUserId(r.UserId)),
                ["IUserQuest"] = (db, record) => SetData(db, (EntityIUserQuest)record, d => d.EntityIUserQuestTable, (d, r) => d.EntityIUserQuestTable.FindByUserIdAndQuestId((r.UserId, r.QuestId))),
                ["IUserQuestMission"] = (db, record) => SetData(db, (EntityIUserQuestMission)record, d => d.EntityIUserQuestMissionTable, (d, r) => d.EntityIUserQuestMissionTable.FindByUserIdAndQuestIdAndQuestMissionId((r.UserId, r.QuestId, r.QuestMissionId))),
                ["IUserShopItem"] = (db, record) => SetData(db, (EntityIUserShopItem)record, d => d.EntityIUserShopItemTable, (d, r) => d.EntityIUserShopItemTable.FindByUserIdAndShopItemId((r.UserId, r.ShopItemId))),
                ["IUserStatus"] = (db, record) => SetData(db, (EntityIUserStatus)record, d => d.EntityIUserStatusTable, (d, r) => d.EntityIUserStatusTable.FindByUserId(r.UserId)),
                ["IUserWeapon"] = (db, record) => SetData(db, (EntityIUserWeapon)record, d => d.EntityIUserWeaponTable, (d, r) => d.EntityIUserWeaponTable.FindByUserIdAndUserWeaponUuid((r.UserId, r.UserWeaponUuid))),
                ["IUserWeaponAbility"] = (db, record) => SetData(db, (EntityIUserWeaponAbility)record, d => d.EntityIUserWeaponAbilityTable, (d, r) => d.EntityIUserWeaponAbilityTable.FindByUserIdAndUserWeaponUuidAndSlotNumber((r.UserId, r.UserWeaponUuid, r.SlotNumber))),
                ["IUserWeaponNote"] = (db, record) => SetData(db, (EntityIUserWeaponNote)record, d => d.EntityIUserWeaponNoteTable, (d, r) => d.EntityIUserWeaponNoteTable.FindByUserIdAndWeaponId((r.UserId, r.WeaponId))),
                ["IUserWeaponSkill"] = (db, record) => SetData(db, (EntityIUserWeaponSkill)record, d => d.EntityIUserWeaponSkillTable, (d, r) => d.EntityIUserWeaponSkillTable.FindByUserIdAndUserWeaponUuidAndSlotNumber((r.UserId, r.UserWeaponUuid, r.SlotNumber))),
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
                differ(db, element);
        }

        private static void SetData<T>(DarkUserMemoryDatabase db, T record, Func<DarkUserMemoryDatabase, TableBase<T>> getTable, Func<DarkUserMemoryDatabase, T, T> findElement)
        {
            var table = getTable(db);
            var rawTable = table.GetRawDataUnsafe();
            var element = findElement(db, record);

            // TODO: Can this happen?
            if (element == null)
            {
                Array.Resize(ref rawTable, rawTable.Length + 1);
                rawTable[^1] = record;

                table.SetRawDataUnsafe(rawTable);

                return;
            }

            var index = Array.IndexOf(rawTable, element);
            rawTable[index] = record;
        }
    }
}
