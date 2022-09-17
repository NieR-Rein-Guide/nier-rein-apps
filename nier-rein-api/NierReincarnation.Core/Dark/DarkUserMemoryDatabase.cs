using System;
using System.Collections.Generic;
using MessagePack;
using NierReincarnation.Core.Dark.Tables;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    public class DarkUserMemoryDatabase : MemoryDatabaseBase
    {
        // 0x10
        public EntityIUserTable EntityIUserTable { get; private set; }

        // 0x28
        public EntityIUserBeginnerCampaignTable EntityIUserBeginnerCampaignTable { get; private set; }
        // 0x30
        public EntityIUserBigHuntMaxScoreTable EntityIUserBigHuntMaxScoreTable { get; private set; }
        // 0x38
        public EntityIUserBigHuntProgressStatusTable EntityIUserBigHuntProgressStatusTable { get; private set; }

        // 0x48
        public EntityIUserBigHuntStatusTable EntityIUserBigHuntStatusTable { get; private set; }
        // 0x50
        public EntityIUserCageOrnamentRewardTable EntityIUserCageOrnamentRewardTable { get; private set; }
        // 0x58
        public EntityIUserCharacterTable EntityIUserCharacterTable { get; private set; }

        // 0x68
        public EntityIUserCharacterBoardAbilityTable EntityIUserCharacterBoardAbilityTable { get; private set; }

        // 0x78
        public EntityIUserCharacterBoardStatusUpTable EntityIUserCharacterBoardStatusUpTable { get; private set; }
        // 0x80
        public EntityIUserCharacterCostumeLevelBonusTable EntityIUserCharacterCostumeLevelBonusTable { get; private set; }

        // 0x90
        public EntityIUserComebackCampaignTable EntityIUserComebackCampaignTable { get; private set; }
        // 0x98
        public EntityIUserCompanionTable EntityIUserCompanionTable { get; private set; }
        // 0xA0
        public EntityIUserConsumableItemTable EntityIUserConsumableItemTable { get; private set; }

        // 0xB0
        public EntityIUserCostumeTable EntityIUserCostumeTable { get; private set; }
        // 0xB8
        public EntityIUserCostumeActiveSkillTable EntityIUserCostumeActiveSkillTable { get; private set; }

        // 0xD0
        public EntityIUserDeckTable EntityIUserDeckTable { get; private set; }
        // 0xD8
        public EntityIUserDeckCharacterTable EntityIUserDeckCharacterTable { get; private set; }
        // 0xE0
        public EntityIUserDeckCharacterDressupCostumeTable EntityIUserDeckCharacterDressupCostumeTable { get; private set; }

        // 0xF0
        public EntityIUserDeckPartsGroupTable EntityIUserDeckPartsGroupTable { get; private set; }
        // 0xF8
        public EntityIUserDeckSubWeaponGroupTable EntityIUserDeckSubWeaponGroupTable { get; private set; }
        // 0x100
        public EntityIUserDeckTypeNoteTable EntityIUserDeckTypeNoteTable { get; private set; }

        // 0x110
        public EntityIUserEventQuestGuerrillaFreeOpenTable EntityIUserEventQuestGuerrillaFreeOpenTable { get; private set; }
        // 0x118
        public EntityIUserEventQuestProgressStatusTable EntityIUserEventQuestProgressStatusTable { get; private set; }

        // 0x138
        public EntityIUserExtraQuestProgressStatusTable EntityIUserExtraQuestProgressStatusTable { get; private set; }

        // 0x148
        public EntityIUserGemTable EntityIUserGemTable { get; private set; }
        // 0x150
        public EntityIUserGimmickTable EntityIUserGimmickTable { get; private set; }
        // 0x158
        public EntityIUserGimmickOrnamentProgressTable EntityIUserGimmickOrnamentProgressTable { get; private set; }
        // 0x160
        public EntityIUserGimmickSequenceTable EntityIUserGimmickSequenceTable { get; private set; }

        // 0x178
        public EntityIUserLimitedOpenTable EntityIUserLimitedOpenTable { get; private set; }

        // 0x1A0
        public EntityIUserMainQuestProgressStatusTable EntityIUserMainQuestProgressStatusTable { get; private set; }

        // 0x1B0
        public EntityIUserMainQuestSeasonRouteTable EntityIUserMainQuestSeasonRouteTable { get; private set; }
        // 0x1B8
        public EntityIUserMaterialTable EntityIUserMaterialTable { get; private set; }

        // 0x1E8
        public EntityIUserPartsTable EntityIUserPartsTable { get; private set; }

        // 0x208
        public EntityIUserPartsStatusSubTable EntityIUserPartsStatusSubTable { get; private set; }

        // 0x220
        public EntityIUserProfileTable EntityIUserProfileTable { get; private set; }

        // 0x238
        public EntityIUserQuestTable EntityIUserQuestTable { get; private set; }

        // 0x248
        public EntityIUserQuestLimitContentStatusTable EntityIUserQuestLimitContentStatusTable { get; private set; }
        // 0x250
        public EntityIUserQuestMissionTable EntityIUserQuestMissionTable { get; private set; }

        // 0x268
        public EntityIUserShopItemTable EntityIUserShopItemTable { get; private set; }

        // 0x290
        public EntityIUserStatusTable EntityIUserStatusTable { get; private set; }
        // 0x298
        public EntityIUserThoughtTable EntityIUserThoughtTable { get; private set; }

        // 0x2B0
        public EntityIUserWeaponTable EntityIUserWeaponTable { get; private set; }
        // 0x2B8
        public EntityIUserWeaponAbilityTable EntityIUserWeaponAbilityTable { get; private set; }
        // 0x2C0
        public EntityIUserWeaponNoteTable EntityIUserWeaponNoteTable { get; private set; }
        // 0x2C8
        public EntityIUserWeaponSkillTable EntityIUserWeaponSkillTable { get; private set; }

        public DarkUserMemoryDatabase(byte[] databaseBinary, bool internString = true, IFormatterResolver formatterResolver = null) :
            base(databaseBinary, internString, formatterResolver)
        {
        }

        protected override void Init(Dictionary<string, (int, int)> header, ReadOnlyMemory<byte> databaseBinary, MessagePackSerializerOptions options)
        {
            EntityIUserTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUser[], EntityIUserTable>(users => new EntityIUserTable(users)));
            EntityIUserBigHuntMaxScoreTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserBigHuntMaxScore[], EntityIUserBigHuntMaxScoreTable>(scores => new EntityIUserBigHuntMaxScoreTable(scores)));
            EntityIUserBigHuntProgressStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserBigHuntProgressStatus[], EntityIUserBigHuntProgressStatusTable>(statuses => new EntityIUserBigHuntProgressStatusTable(statuses)));
            EntityIUserBigHuntStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserBigHuntStatus[], EntityIUserBigHuntStatusTable>(statuses => new EntityIUserBigHuntStatusTable(statuses)));
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
            EntityIUserShopItemTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserShopItem[], EntityIUserShopItemTable>(items => new EntityIUserShopItemTable(items)));
            EntityIUserStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserStatus[], EntityIUserStatusTable>(statuses => new EntityIUserStatusTable(statuses)));
            EntityIUserWeaponTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserWeapon[], EntityIUserWeaponTable>(weapons => new EntityIUserWeaponTable(weapons)));
            EntityIUserWeaponAbilityTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserWeaponAbility[], EntityIUserWeaponAbilityTable>(abilities => new EntityIUserWeaponAbilityTable(abilities)));
            EntityIUserWeaponNoteTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserWeaponNote[], EntityIUserWeaponNoteTable>(notes => new EntityIUserWeaponNoteTable(notes)));
            EntityIUserWeaponSkillTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserWeaponSkill[], EntityIUserWeaponSkillTable>(skills => new EntityIUserWeaponSkillTable(skills)));
            EntityIUserThoughtTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserThought[], EntityIUserThoughtTable>(thoughts => new EntityIUserThoughtTable(thoughts)));
            EntityIUserDeckCharacterDressupCostumeTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserDeckCharacterDressupCostume[], EntityIUserDeckCharacterDressupCostumeTable>(costumes => new EntityIUserDeckCharacterDressupCostumeTable(costumes)));
            EntityIUserBeginnerCampaignTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserBeginnerCampaign[], EntityIUserBeginnerCampaignTable>(campaigns => new EntityIUserBeginnerCampaignTable(campaigns)));
            EntityIUserComebackCampaignTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserComebackCampaign[], EntityIUserComebackCampaignTable>(campaigns => new EntityIUserComebackCampaignTable(campaigns)));
            EntityIUserEventQuestGuerrillaFreeOpenTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserEventQuestGuerrillaFreeOpen[], EntityIUserEventQuestGuerrillaFreeOpenTable>(opens => new EntityIUserEventQuestGuerrillaFreeOpenTable(opens)));
            EntityIUserMainQuestSeasonRouteTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserMainQuestSeasonRoute[], EntityIUserMainQuestSeasonRouteTable>(routes => new EntityIUserMainQuestSeasonRouteTable(routes)));
            EntityIUserQuestLimitContentStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserQuestLimitContentStatus[], EntityIUserQuestLimitContentStatusTable>(statuses => new EntityIUserQuestLimitContentStatusTable(statuses)));

            EntityIUserGimmickTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserGimmick[], EntityIUserGimmickTable>(gimmicks => new EntityIUserGimmickTable(gimmicks)));
            EntityIUserGimmickOrnamentProgressTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserGimmickOrnamentProgress[], EntityIUserGimmickOrnamentProgressTable>(progresses => new EntityIUserGimmickOrnamentProgressTable(progresses)));
            EntityIUserGimmickSequenceTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserGimmickSequence[], EntityIUserGimmickSequenceTable>(sequences => new EntityIUserGimmickSequenceTable(sequences)));
            EntityIUserCageOrnamentRewardTable = ExtractTableData(header, databaseBinary, options, new Func<EntityIUserCageOrnamentReward[], EntityIUserCageOrnamentRewardTable>(rewards => new EntityIUserCageOrnamentRewardTable(rewards)));
        }
    }
}
