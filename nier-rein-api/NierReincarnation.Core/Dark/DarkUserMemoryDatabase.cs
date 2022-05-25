using System;
using System.Collections.Generic;
using MessagePack;
using NierReincarnation.Core.Dark.Tables;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    public class DarkUserMemoryDatabase : MemoryDatabaseBase
    {
        public EntityIUserTable EntityIUserTable { get; private set; } // 0x10
        public EntityIUserBigHuntMaxScoreTable EntityIUserBigHuntMaxScoreTable { get; private set; } // 0x28
        public EntityIUserBigHuntProgressStatusTable EntityIUserBigHuntProgressStatusTable { get; private set; } // 0x30
        public EntityIUserCharacterTable EntityIUserCharacterTable { get; private set; } // 0x48
        public EntityIUserCharacterBoardAbilityTable EntityIUserCharacterBoardAbilityTable { get; private set; } // 0x58
        public EntityIUserCharacterBoardStatusUpTable EntityIUserCharacterBoardStatusUpTable { get; private set; } // 0x68
        public EntityIUserCharacterCostumeLevelBonusTable EntityIUserCharacterCostumeLevelBonusTable { get; private set; } // 0x70
        public EntityIUserCompanionTable EntityIUserCompanionTable { get; private set; } // 0x80
        public EntityIUserConsumableItemTable EntityIUserConsumableItemTable { get; private set; } // 0x88
        public EntityIUserCostumeTable EntityIUserCostumeTable { get; private set; } // 0x98
        public EntityIUserCostumeActiveSkillTable EntityIUserCostumeActiveSkillTable { get; private set; } // 0xA0
        public EntityIUserDeckTable EntityIUserDeckTable { get; private set; } // 0xB0
        public EntityIUserDeckCharacterTable EntityIUserDeckCharacterTable { get; private set; } // 0xB8
        public EntityIUserDeckPartsGroupTable EntityIUserDeckPartsGroupTable { get; private set; } // 0xC0
        public EntityIUserDeckSubWeaponGroupTable EntityIUserDeckSubWeaponGroupTable { get; private set; } // 0xC8
        public EntityIUserDeckTypeNoteTable EntityIUserDeckTypeNoteTable { get; private set; } // 0xD0
        public EntityIUserEventQuestProgressStatusTable EntityIUserEventQuestProgressStatusTable { get; private set; } // 0xE0
        public EntityIUserExtraQuestProgressStatusTable EntityIUserExtraQuestProgressStatusTable { get; private set; } // 0x100
        public EntityIUserGemTable EntityIUserGemTable { get; private set; } // 0x110
        public EntityIUserLimitedOpenTable EntityIUserLimitedOpenTable { get; private set; } // 0x140
        public EntityIUserMainQuestProgressStatusTable EntityIUserMainQuestProgressStatusTable { get; private set; } // 0x168
        public EntityIUserMaterialTable EntityIUserMaterialTable { get; private set; } // 0x180
        public EntityIUserPartsTable EntityIUserPartsTable { get; private set; } // 0x1B0
        public EntityIUserPartsStatusSubTable EntityIUserPartsStatusSubTable { get; private set; } // 0x1D0
        public EntityIUserProfileTable EntityIUserProfileTable { get; private set; } // 0x1E8
        public EntityIUserQuestTable EntityIUserQuestTable { get; private set; }  // 0x200
        public EntityIUserQuestMissionTable EntityIUserQuestMissionTable { get; private set; } // 0x210
        public EntityIUserStatusTable EntityIUserStatusTable { get; private set; } // 0x240
        public EntityIUserWeaponTable EntityIUserWeaponTable { get; private set; } // 0x258
        public EntityIUserWeaponAbilityTable EntityIUserWeaponAbilityTable { get; private set; } // 0x260
        public EntityIUserWeaponNoteTable EntityIUserWeaponNoteTable { get; private set; } // 0x268
        public EntityIUserWeaponSkillTable EntityIUserWeaponSkillTable { get; private set; } // 0x270

        public DarkUserMemoryDatabase(byte[] databaseBinary, bool internString = true, IFormatterResolver formatterResolver = null) :
            base(databaseBinary, internString, formatterResolver)
        {
        }

        protected override void Init(Dictionary<string, (int, int)> header, ReadOnlyMemory<byte> databaseBinary, MessagePackSerializerOptions options)
        {
            EntityIUserTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUser[], EntityIUserTable>(users => new EntityIUserTable(users)));
            EntityIUserBigHuntMaxScoreTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserBigHuntMaxScore[], EntityIUserBigHuntMaxScoreTable>(scores => new EntityIUserBigHuntMaxScoreTable(scores)));
            EntityIUserBigHuntProgressStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserBigHuntProgressStatus[], EntityIUserBigHuntProgressStatusTable>(statuses => new EntityIUserBigHuntProgressStatusTable(statuses)));
            EntityIUserCharacterTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserCharacter[], EntityIUserCharacterTable>(characters => new EntityIUserCharacterTable(characters)));
            EntityIUserCharacterBoardAbilityTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserCharacterBoardAbility[], EntityIUserCharacterBoardAbilityTable>(abilities => new EntityIUserCharacterBoardAbilityTable(abilities)));
            EntityIUserCharacterBoardStatusUpTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserCharacterBoardStatusUp[], EntityIUserCharacterBoardStatusUpTable>(ups => new EntityIUserCharacterBoardStatusUpTable(ups)));
            EntityIUserCharacterCostumeLevelBonusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserCharacterCostumeLevelBonus[], EntityIUserCharacterCostumeLevelBonusTable>(bonuses => new EntityIUserCharacterCostumeLevelBonusTable(bonuses)));
            EntityIUserCompanionTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserCompanion[], EntityIUserCompanionTable>(companions => new EntityIUserCompanionTable(companions)));
            EntityIUserConsumableItemTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserConsumableItem[], EntityIUserConsumableItemTable>(items => new EntityIUserConsumableItemTable(items)));
            EntityIUserCostumeTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserCostume[], EntityIUserCostumeTable>(costumes => new EntityIUserCostumeTable(costumes)));
            EntityIUserCostumeActiveSkillTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserCostumeActiveSkill[], EntityIUserCostumeActiveSkillTable>(skills => new EntityIUserCostumeActiveSkillTable(skills)));
            EntityIUserDeckTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserDeck[], EntityIUserDeckTable>(decks => new EntityIUserDeckTable(decks)));
            EntityIUserDeckCharacterTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserDeckCharacter[], EntityIUserDeckCharacterTable>(characters => new EntityIUserDeckCharacterTable(characters)));
            EntityIUserDeckPartsGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserDeckPartsGroup[], EntityIUserDeckPartsGroupTable>(groups => new EntityIUserDeckPartsGroupTable(groups)));
            EntityIUserDeckSubWeaponGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserDeckSubWeaponGroup[], EntityIUserDeckSubWeaponGroupTable>(groups => new EntityIUserDeckSubWeaponGroupTable(groups)));
            EntityIUserDeckTypeNoteTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserDeckTypeNote[], EntityIUserDeckTypeNoteTable>(notes => new EntityIUserDeckTypeNoteTable(notes)));
            EntityIUserEventQuestProgressStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserEventQuestProgressStatus[], EntityIUserEventQuestProgressStatusTable>(statuses => new EntityIUserEventQuestProgressStatusTable(statuses)));
            EntityIUserExtraQuestProgressStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserExtraQuestProgressStatus[], EntityIUserExtraQuestProgressStatusTable>(statuses => new EntityIUserExtraQuestProgressStatusTable(statuses)));
            EntityIUserGemTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserGem[], EntityIUserGemTable>(gems => new EntityIUserGemTable(gems)));
            EntityIUserLimitedOpenTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserLimitedOpen[], EntityIUserLimitedOpenTable>(opens => new EntityIUserLimitedOpenTable(opens)));
            EntityIUserMainQuestProgressStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserMainQuestProgressStatus[], EntityIUserMainQuestProgressStatusTable>(statuses => new EntityIUserMainQuestProgressStatusTable(statuses)));
            EntityIUserMaterialTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserMaterial[], EntityIUserMaterialTable>(materials => new EntityIUserMaterialTable(materials)));
            EntityIUserPartsTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserParts[], EntityIUserPartsTable>(parts => new EntityIUserPartsTable(parts)));
            EntityIUserPartsStatusSubTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserPartsStatusSub[], EntityIUserPartsStatusSubTable>(subs => new EntityIUserPartsStatusSubTable(subs)));
            EntityIUserProfileTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserProfile[], EntityIUserProfileTable>(profiles => new EntityIUserProfileTable(profiles)));
            EntityIUserQuestTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserQuest[], EntityIUserQuestTable>(quests => new EntityIUserQuestTable(quests)));
            EntityIUserQuestMissionTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserQuestMission[], EntityIUserQuestMissionTable>(missions => new EntityIUserQuestMissionTable(missions)));
            EntityIUserStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserStatus[], EntityIUserStatusTable>(statuses => new EntityIUserStatusTable(statuses)));
            EntityIUserWeaponTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserWeapon[], EntityIUserWeaponTable>(weapons => new EntityIUserWeaponTable(weapons)));
            EntityIUserWeaponAbilityTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserWeaponAbility[], EntityIUserWeaponAbilityTable>(abilities => new EntityIUserWeaponAbilityTable(abilities)));
            EntityIUserWeaponNoteTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserWeaponNote[], EntityIUserWeaponNoteTable>(notes => new EntityIUserWeaponNoteTable(notes)));
            EntityIUserWeaponSkillTable = ExtractTableData(header, databaseBinary, options,new Func<EntityIUserWeaponSkill[],EntityIUserWeaponSkillTable>(skills => new EntityIUserWeaponSkillTable(skills)));
        }
    }
}
