using System;
using System.Collections.Generic;
using MessagePack;
using NierReincarnation.Core.Dark.Tables;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    // Dark.DarkMasterMemoryDatabase
    public sealed class DarkMasterMemoryDatabase : MemoryDatabaseBase
    {
        // 0x10
        public EntityMAbilityTable EntityMAbilityTable { get; private set; }
        // 0x18
        public EntityMAbilityBehaviourTable EntityMAbilityBehaviourTable { get; private set; }
        // 0x20
        public EntityMAbilityBehaviourActionPassiveSkillTable EntityMAbilityBehaviourActionPassiveSkillTable { get; private set; }
        // 0x28
        public EntityMAbilityBehaviourActionStatusTable EntityMAbilityBehaviourActionStatusTable { get; private set; }
        // 0x30
        public EntityMAbilityBehaviourGroupTable EntityMAbilityBehaviourGroupTable { get; private set; }
        // 0x38
        public EntityMAbilityDetailTable EntityMAbilityDetailTable { get; private set; }
        // 0x40
        public EntityMAbilityLevelGroupTable EntityMAbilityLevelGroupTable { get; private set; }
        // 0x48
        public EntityMAbilityStatusTable EntityMAbilityStatusTable { get; private set; }

        // 0xB0
        public EntityMBattleTable EntityMBattleTable { get; private set; }

        // 0x178
        public EntityMBattleGroupTable EntityMBattleGroupTable { get; private set; }

        // 0x1B8
        public EntityMBattleNpcCompanionTable EntityMBattleNpcCompanionTable { get; private set; }
        // 0x1C0
        public EntityMBattleNpcCostumeTable EntityMBattleNpcCostumeTable { get; private set; }
        // 0x1C8
        public EntityMBattleNpcCostumeActiveSkillTable EntityMBattleNpcCostumeActiveSkillTable { get; private set; }

        // 0x1E8
        public EntityMBattleNpcDeckTable EntityMBattleNpcDeckTable { get; private set; }
        // 0x1F0
        public EntityMBattleNpcDeckCharacterTable EntityMBattleNpcDeckCharacterTable { get; private set; }

        // 0x258
        public EntityMBattleNpcWeaponTable EntityMBattleNpcWeaponTable { get; private set; }

        // 0x290
        public EntityMBattleQuestSceneBgmTable EntityMBattleQuestSceneBgmTable { get; private set; }

        // 0x2A0
        public EntityMBattleRentalDeckTable EntityMBattleRentalDeckTable { get; private set; }

        // 0x2B8
        public EntityMBigHuntBossTable EntityMBigHuntBossTable { get; private set; }
        // 0x2C0
        public EntityMBigHuntBossGradeGroupTable EntityMBigHuntBossGradeGroupTable { get; private set; }

        // 0x2D0
        public EntityMBigHuntBossQuestTable EntityMBigHuntBossQuestTable { get; private set; } 

        // 0x2F0
        public EntityMBigHuntQuestTable EntityMBigHuntQuestTable { get; private set; }
        // 0x2F8
        public EntityMBigHuntQuestGroupTable EntityMBigHuntQuestGroupTable { get; private set; }
        // 0x300
        public EntityMBigHuntQuestScoreCoefficientTable EntityMBigHuntQuestScoreCoefficientTable { get; private set; }

        // 0x358
        public EntityMCatalogCompanionTable EntityMCatalogCompanionTable { get; private set; }
        // 0x360
        public EntityMCatalogCostumeTable EntityMCatalogCostumeTable { get; private set; }
        // 0x368
        public EntityMCatalogPartsGroupTable EntityMCatalogPartsGroupTable { get; private set; }
        // 0x370
        public EntityMCatalogTermTable EntityMCatalogTermTable { get; private set; }

        // 0x380
        public EntityMCatalogWeaponTable EntityMCatalogWeaponTable { get; private set; }
        // 0x388
        public EntityMCharacterTable EntityMCharacterTable { get; private set; }

        // 0x420
        public EntityMCharacterDisplaySwitchTable EntityMCharacterDisplaySwitchTable { get; private set; }
        // 0x428
        public EntityMCharacterLevelBonusAbilityGroupTable EntityMCharacterLevelBonusAbilityGroupTable { get; private set; }

        // 0x460
        public EntityMCompanionTable EntityMCompanionTable { get; private set; }
        // 0x468
        public EntityMCompanionAbilityGroupTable EntityMCompanionAbilityGroupTable { get; private set; }
        // 0x470
        public EntityMCompanionAbilityLevelTable EntityMCompanionAbilityLevelTable { get; private set; }
        // 0x478
        public EntityMCompanionBaseStatusTable EntityMCompanionBaseStatusTable { get; private set; }
        // 0x480
        public EntityMCompanionCategoryTable EntityMCompanionCategoryTable { get; private set; }

        // 0x4B8
        public EntityMConfigTable EntityMConfigTable { get; private set; }

        // 0x490
        public EntityMCompanionEnhancedTable EntityMCompanionEnhancedTable { get; private set; }

        // 0x4A0
        public EntityMCompanionSkillLevelTable EntityMCompanionSkillLevelTable { get; private set; }
        // 0x4A8
        public EntityMCompanionStatusCalculationTable EntityMCompanionStatusCalculationTable { get; private set; }

        // 0x4C0
        public EntityMConsumableItemTable EntityMConsumableItemTable { get; private set; }
        // 0x4C8
        public EntityMConsumableItemEffectTable EntityMConsumableItemEffectTable { get; private set; }
        // 0x4D0
        public EntityMConsumableItemTermTable EntityMConsumableItemTermTable { get; private set; }

        // 0x4E0
        public EntityMCostumeTable EntityMCostumeTable { get; private set; }
        // 0x4E8
        public EntityMCostumeAbilityGroupTable EntityMCostumeAbilityGroupTable { get; private set; }
        // 0x4F0
        public EntityMCostumeAbilityLevelGroupTable EntityMCostumeAbilityLevelGroupTable { get; private set; }

        // 0x500
        public EntityMCostumeActiveSkillGroupTable EntityMCostumeActiveSkillGroupTable { get; private set; }

        // 0x510
        public EntityMCostumeAwakenTable EntityMCostumeAwakenTable { get; private set; }

        // 0x550
        public EntityMCostumeBaseStatusTable EntityMCostumeBaseStatusTable { get; private set; }

        // 0x588
        public EntityMCostumeEmblemTable EntityMCostumeEmblemTable { get; private set; }
        // 0x590
        public EntityMCostumeEnhancedTable EntityMCostumeEnhancedTable { get; private set; }

        // 0x5B8
        public EntityMCostumeRarityTable EntityMCostumeRarityTable { get; private set; }

        // 0x5C8
        public EntityMCostumeStatusCalculationTable EntityMCostumeStatusCalculationTable { get; private set; }

        // 0x620
        public EntityMEventQuestChapterTable EntityMEventQuestChapterTable { get; private set; }
        // 0x628
        public EntityMEventQuestChapterCharacterTable EntityMEventQuestChapterCharacterTable { get; private set; }

        // 0x648
        public EntityMEventQuestLinkTable EntityMEventQuestLinkTable { get; private set; }
        // 0x650
        public EntityMEventQuestSequenceTable EntityMEventQuestSequenceTable { get; private set; }
        // 0x658
        public EntityMEventQuestSequenceGroupTable EntityMEventQuestSequenceGroupTable { get; private set; }

        // 0x750
        public EntityMImportantItemTable EntityMImportantItemTable { get; private set; }

        // 0x7D0
        public EntityMMainQuestChapterTable EntityMMainQuestChapterTable { get; private set; }

        // 0x7E0
        public EntityMMainQuestRouteTable EntityMMainQuestRouteTable { get; private set; }
        // 0x7E8
        public EntityMMainQuestSeasonTable EntityMMainQuestSeasonTable { get; private set; }
        // 0x7F0
        public EntityMMainQuestSequenceTable EntityMMainQuestSequenceTable { get; private set; }
        // 0x7F8
        public EntityMMainQuestSequenceGroupTable EntityMMainQuestSequenceGroupTable { get; private set; }

        // 0x810
        public EntityMMaterialTable EntityMMaterialTable { get; private set; }

        // 0x878
        public EntityMNumericalFunctionTable EntityMNumericalFunctionTable { get; private set; }
        // 0x880
        public EntityMNumericalFunctionParameterGroupTable EntityMNumericalFunctionParameterGroupTable { get; private set; }

        // 0x8B8
        public EntityMPartsTable EntityMPartsTable { get; private set; }
        // 0x8C0
        public EntityMPartsEnhancedTable EntityMPartsEnhancedTable { get; private set; }

        // 0x8D0
        public EntityMPartsGroupTable EntityMPartsGroupTable { get; private set; }

        // 0x8F0
        public EntityMPartsSeriesTable EntityMPartsSeriesTable { get; private set; }
        // 0x8F8
        public EntityMPartsSeriesBonusAbilityGroupTable EntityMPartsSeriesBonusAbilityGroupTable { get; private set; }
        // 0x900
        public EntityMPartsStatusMainTable EntityMPartsStatusMainTable { get; private set; }
        // 0x908
        public EntityMPlatformPaymentTable EntityMPlatformPaymentTable { get; private set; }

        // 0x950
        public EntityMPowerCalculationConstantValueTable EntityMPowerCalculationConstantValueTable { get; private set; }
        // 0x958
        public EntityMPowerReferenceStatusGroupTable EntityMPowerReferenceStatusGroupTable { get; private set; }

        // 0x9E8
        public EntityMQuestTable EntityMQuestTable { get; private set; }
        // 0x9F0
        public EntityMQuestBonusTable EntityMQuestBonusTable { get; private set; }

        // 0xA00
        public EntityMQuestBonusCharacterGroupTable EntityMQuestBonusCharacterGroupTable { get; private set; }

        // 0xA10
        public EntityMQuestBonusCostumeSettingGroupTable EntityMQuestBonusCostumeSettingGroupTable { get; private set; }

        // 0xA30
        public EntityMQuestBonusTermGroupTable EntityMQuestBonusTermGroupTable { get; private set; }
        // 0xA38
        public EntityMQuestBonusWeaponGroupTable EntityMQuestBonusWeaponGroupTable { get; private set; }

        // 0xA40
        public EntityMQuestCampaignTable EntityMQuestCampaignTable { get; private set; }
        // 0xA48
        public EntityMQuestCampaignEffectGroupTable EntityMQuestCampaignEffectGroupTable { get; private set; }
        // 0xA50
        public EntityMQuestCampaignTargetGroupTable EntityMQuestCampaignTargetGroupTable { get; private set; }

        // 0xA60
        public EntityMQuestDeckRestrictionGroupTable EntityMQuestDeckRestrictionGroupTable { get; private set; }
        // 0xA68
        public EntityMQuestDisplayAttributeGroupTable EntityMQuestDisplayAttributeGroupTable { get; private set; }
        // 0xA70
        public EntityMQuestFirstClearRewardGroupTable EntityMQuestFirstClearRewardGroupTable { get; private set; }
        // 0xA78
        public EntityMQuestMissionTable EntityMQuestMissionTable { get; private set; }
        // 0xA80
        public EntityMQuestMissionConditionValueGroupTable EntityMQuestMissionConditionValueGroupTable { get; private set; }
        // 0xA88
        public EntityMQuestMissionGroupTable EntityMQuestMissionGroupTable { get; private set; }

        // 0xAA8
        public EntityMQuestReleaseConditionBigHuntScoreTable EntityMQuestReleaseConditionBigHuntScoreTable { get; private set; }
        // 0xAB0
        public EntityMQuestReleaseConditionCharacterLevelTable EntityMQuestReleaseConditionCharacterLevelTable { get; private set; }
        // 0xAB8
        public EntityMQuestReleaseConditionDeckPowerTable EntityMQuestReleaseConditionDeckPowerTable { get; private set; }
        // 0xAC0
        public EntityMQuestReleaseConditionGroupTable EntityMQuestReleaseConditionGroupTable { get; private set; }
        // 0xAC8
        public EntityMQuestReleaseConditionListTable EntityMQuestReleaseConditionListTable { get; private set; }
        // 0xAD0
        public EntityMQuestReleaseConditionQuestClearTable EntityMQuestReleaseConditionQuestClearTable { get; private set; }
        // 0xAD8
        public EntityMQuestReleaseConditionUserLevelTable EntityMQuestReleaseConditionUserLevelTable { get; private set; }
        // 0xAE0
        public EntityMQuestReleaseConditionWeaponAcquisitionTable EntityMQuestReleaseConditionWeaponAcquisitionTable { get; private set; }

        // 0xAF0
        public EntityMQuestSceneTable EntityMQuestSceneTable { get; private set; }
        // 0xAF8
        public EntityMQuestSceneBattleTable EntityMQuestSceneBattleTable { get; private set; }

        // 0xB10
        public EntityMQuestScheduleTable EntityMQuestScheduleTable { get; private set; }
        // 0xB18
        public EntityMQuestScheduleCorrespondenceTable EntityMQuestScheduleCorrespondenceTable { get; private set; }

        // 0xB28
        public EntityMShopTable EntityMShopTable { get; private set; }

        // 0xB38
        public EntityMShopItemTable EntityMShopItemTable { get; private set; }

        // 0xB48
        public EntityMShopItemCellTable EntityMShopItemCellTable { get; private set; }
        // 0xB50
        public EntityMShopItemCellGroupTable EntityMShopItemCellGroupTable { get; private set; }

        // 0xB60
        public EntityMShopItemCellTermTable EntityMShopItemCellTermTable { get; private set; }

        // 0xB78
        public EntityMShopItemContentPossessionTable EntityMShopItemContentPossessionTable { get; private set; }
        // 0xB80
        public EntityMShopItemLimitedStockTable EntityMShopItemLimitedStockTable { get; private set; }

        // 0xB98
        public EntityMSkillTable EntityMSkillTable { get; private set; }

        // 0xC70
        public EntityMSkillBehaviourTable EntityMSkillBehaviourTable { get; private set; }

        // 0xD58
        public EntityMSkillBehaviourActivationMethodTable EntityMSkillBehaviourActivationMethodTable { get; private set; }
        // 0xD60
        public EntityMSkillBehaviourGroupTable EntityMSkillBehaviourGroupTable { get; private set; }

        // 0xE18
        public EntityMSkillDetailTable EntityMSkillDetailTable { get; private set; }
        // 0xE20
        public EntityMSkillLevelGroupTable EntityMSkillLevelGroupTable { get; private set; }

        // 0xE58
        public EntityMThoughtTable EntityMThoughtTable { get; private set; }

        // 0xEE0
        public EntityMWeaponTable EntityMWeaponTable { get; private set; }

        // 0xEF0
        public EntityMWeaponAbilityGroupTable EntityMWeaponAbilityGroupTable { get; private set; }
        // 0xEF8
        public EntityMWeaponBaseStatusTable EntityMWeaponBaseStatusTable { get; private set; }

        // 0xF08
        public EntityMWeaponEnhancedTable EntityMWeaponEnhancedTable { get; private set; }

        // 0xF20
        public EntityMWeaponEvolutionGroupTable EntityMWeaponEvolutionGroupTable { get; private set; }

        // 0xF30
        public EntityMWeaponRarityTable EntityMWeaponRarityTable { get; private set; }

        // 0xF48
        public EntityMWeaponSkillGroupTable EntityMWeaponSkillGroupTable { get; private set; }
        // 0xF50
        public EntityMWeaponSpecificEnhanceTable EntityMWeaponSpecificEnhanceTable { get; private set; }

        // 0xF60
        public EntityMWeaponStatusCalculationTable EntityMWeaponStatusCalculationTable { get; private set; }

        public DarkMasterMemoryDatabase(byte[] databaseBinary, bool internString = true, IFormatterResolver formatterResolver = null) :
            base(databaseBinary, internString, formatterResolver)
        {
        }

        protected override void Init(Dictionary<string, (int, int)> header, ReadOnlyMemory<byte> databaseBinary, MessagePackSerializerOptions options)
        {
            EntityMAbilityTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMAbility[], EntityMAbilityTable>(abilities => new EntityMAbilityTable(abilities)));
            EntityMAbilityBehaviourTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMAbilityBehaviour[], EntityMAbilityBehaviourTable>(behaviours => new EntityMAbilityBehaviourTable(behaviours)));
            EntityMAbilityBehaviourActionPassiveSkillTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMAbilityBehaviourActionPassiveSkill[], EntityMAbilityBehaviourActionPassiveSkillTable>(skills => new EntityMAbilityBehaviourActionPassiveSkillTable(skills)));
            EntityMAbilityBehaviourActionStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMAbilityBehaviourActionStatus[], EntityMAbilityBehaviourActionStatusTable>(statuses => new EntityMAbilityBehaviourActionStatusTable(statuses)));
            EntityMAbilityBehaviourGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMAbilityBehaviourGroup[], EntityMAbilityBehaviourGroupTable>(groups => new EntityMAbilityBehaviourGroupTable(groups)));
            EntityMAbilityDetailTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMAbilityDetail[], EntityMAbilityDetailTable>(details => new EntityMAbilityDetailTable(details)));
            EntityMAbilityLevelGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMAbilityLevelGroup[], EntityMAbilityLevelGroupTable>(groups => new EntityMAbilityLevelGroupTable(groups)));
            EntityMAbilityStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMAbilityStatus[], EntityMAbilityStatusTable>(statuses => new EntityMAbilityStatusTable(statuses)));
            // ...
            EntityMBattleTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattle[], EntityMBattleTable>(battles => new EntityMBattleTable(battles)));
            // ...
            EntityMEventQuestLinkTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMEventQuestLink[], EntityMEventQuestLinkTable>(links => new EntityMEventQuestLinkTable(links)));
            // ...
            EntityMBattleGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleGroup[], EntityMBattleGroupTable>(groups => new EntityMBattleGroupTable(groups)));
            // ...
            EntityMBattleNpcCompanionTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleNpcCompanion[], EntityMBattleNpcCompanionTable>(companions => new EntityMBattleNpcCompanionTable(companions)));
            EntityMBattleNpcCostumeTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleNpcCostume[], EntityMBattleNpcCostumeTable>(costumes => new EntityMBattleNpcCostumeTable(costumes)));
            EntityMBattleNpcCostumeActiveSkillTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleNpcCostumeActiveSkill[], EntityMBattleNpcCostumeActiveSkillTable>(skills => new EntityMBattleNpcCostumeActiveSkillTable(skills)));
            // ...
            EntityMBattleNpcDeckTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleNpcDeck[], EntityMBattleNpcDeckTable>(decks => new EntityMBattleNpcDeckTable(decks)));
            EntityMBattleNpcDeckCharacterTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleNpcDeckCharacter[], EntityMBattleNpcDeckCharacterTable>(characters => new EntityMBattleNpcDeckCharacterTable(characters)));
            // ...
            EntityMBattleNpcWeaponTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleNpcWeapon[], EntityMBattleNpcWeaponTable>(weapons => new EntityMBattleNpcWeaponTable(weapons)));
            // ...
            EntityMBattleQuestSceneBgmTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleQuestSceneBgm[], EntityMBattleQuestSceneBgmTable>(bgms => new EntityMBattleQuestSceneBgmTable(bgms)));
            // ...
            EntityMBattleRentalDeckTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleRentalDeck[], EntityMBattleRentalDeckTable>(decks => new EntityMBattleRentalDeckTable(decks)));
            // ...
            EntityMBigHuntBossTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBigHuntBoss[], EntityMBigHuntBossTable>(bosses => new EntityMBigHuntBossTable(bosses)));
            EntityMBigHuntBossGradeGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBigHuntBossGradeGroup[], EntityMBigHuntBossGradeGroupTable>(groups => new EntityMBigHuntBossGradeGroupTable(groups)));
            // ...
            EntityMBigHuntBossQuestTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBigHuntBossQuest[], EntityMBigHuntBossQuestTable>(quests => new EntityMBigHuntBossQuestTable(quests)));
            // ...
            EntityMBigHuntQuestTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBigHuntQuest[], EntityMBigHuntQuestTable>(quests => new EntityMBigHuntQuestTable(quests)));
            EntityMBigHuntQuestGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBigHuntQuestGroup[], EntityMBigHuntQuestGroupTable>(groups => new EntityMBigHuntQuestGroupTable(groups)));
            EntityMBigHuntQuestScoreCoefficientTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBigHuntQuestScoreCoefficient[], EntityMBigHuntQuestScoreCoefficientTable>(coefficients => new EntityMBigHuntQuestScoreCoefficientTable(coefficients)));
            // ...
            EntityMCatalogCompanionTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCatalogCompanion[], EntityMCatalogCompanionTable>(companions => new EntityMCatalogCompanionTable(companions)));
            EntityMCatalogCostumeTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCatalogCostume[], EntityMCatalogCostumeTable>(costumes => new EntityMCatalogCostumeTable(costumes)));
            EntityMCatalogPartsGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCatalogPartsGroup[], EntityMCatalogPartsGroupTable>(groups => new EntityMCatalogPartsGroupTable(groups)));
            EntityMCatalogTermTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCatalogTerm[], EntityMCatalogTermTable>(terms => new EntityMCatalogTermTable(terms)));
            EntityMCatalogWeaponTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCatalogWeapon[], EntityMCatalogWeaponTable>(weapons => new EntityMCatalogWeaponTable(weapons)));
            EntityMCharacterTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCharacter[], EntityMCharacterTable>(characters => new EntityMCharacterTable(characters)));
            // ...
            EntityMCharacterDisplaySwitchTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCharacterDisplaySwitch[], EntityMCharacterDisplaySwitchTable>(switches => new EntityMCharacterDisplaySwitchTable(switches)));
            // ...
            EntityMCharacterLevelBonusAbilityGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCharacterLevelBonusAbilityGroup[], EntityMCharacterLevelBonusAbilityGroupTable>(groups => new EntityMCharacterLevelBonusAbilityGroupTable(groups)));
            // ...
            EntityMCompanionTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCompanion[], EntityMCompanionTable>(companions => new EntityMCompanionTable(companions)));
            EntityMCompanionAbilityGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCompanionAbilityGroup[], EntityMCompanionAbilityGroupTable>(groups => new EntityMCompanionAbilityGroupTable(groups)));
            EntityMCompanionAbilityLevelTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCompanionAbilityLevel[], EntityMCompanionAbilityLevelTable>(levels => new EntityMCompanionAbilityLevelTable(levels)));
            EntityMCompanionBaseStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCompanionBaseStatus[], EntityMCompanionBaseStatusTable>(statuses => new EntityMCompanionBaseStatusTable(statuses)));
            EntityMCompanionCategoryTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCompanionCategory[], EntityMCompanionCategoryTable>(categories => new EntityMCompanionCategoryTable(categories)));
            EntityMConfigTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMConfig[], EntityMConfigTable>(configs => new EntityMConfigTable(configs)));
            EntityMCompanionEnhancedTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCompanionEnhanced[], EntityMCompanionEnhancedTable>(enhanceds => new EntityMCompanionEnhancedTable(enhanceds)));
            // ...
            EntityMCompanionSkillLevelTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCompanionSkillLevel[], EntityMCompanionSkillLevelTable>(levels => new EntityMCompanionSkillLevelTable(levels)));
            EntityMCompanionStatusCalculationTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCompanionStatusCalculation[], EntityMCompanionStatusCalculationTable>(calculations => new EntityMCompanionStatusCalculationTable(calculations)));
            // ...
            EntityMConsumableItemTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMConsumableItem[], EntityMConsumableItemTable>(items => new EntityMConsumableItemTable(items)));
            EntityMConsumableItemEffectTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMConsumableItemEffect[], EntityMConsumableItemEffectTable>(effects => new EntityMConsumableItemEffectTable(effects)));
            EntityMConsumableItemTermTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMConsumableItemTerm[], EntityMConsumableItemTermTable>(terms => new EntityMConsumableItemTermTable(terms)));
            // ...
            EntityMCostumeTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCostume[], EntityMCostumeTable>(costumes => new EntityMCostumeTable(costumes)));
            EntityMCostumeAbilityGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCostumeAbilityGroup[], EntityMCostumeAbilityGroupTable>(groups => new EntityMCostumeAbilityGroupTable(groups)));
            EntityMCostumeAbilityLevelGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCostumeAbilityLevelGroup[], EntityMCostumeAbilityLevelGroupTable>(groups => new EntityMCostumeAbilityLevelGroupTable(groups)));
            // ...
            EntityMCostumeActiveSkillGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCostumeActiveSkillGroup[], EntityMCostumeActiveSkillGroupTable>(groups => new EntityMCostumeActiveSkillGroupTable(groups)));
            // ...
            EntityMCostumeBaseStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCostumeBaseStatus[], EntityMCostumeBaseStatusTable>(statuses => new EntityMCostumeBaseStatusTable(statuses)));
            // ...
            EntityMCostumeEmblemTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCostumeEmblem[], EntityMCostumeEmblemTable>(emblems => new EntityMCostumeEmblemTable(emblems)));
            EntityMCostumeEnhancedTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCostumeEnhanced[], EntityMCostumeEnhancedTable>(enhanceds => new EntityMCostumeEnhancedTable(enhanceds)));
            // ...
            EntityMCostumeRarityTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCostumeRarity[], EntityMCostumeRarityTable>(rarities => new EntityMCostumeRarityTable(rarities)));
            // ...
            EntityMCostumeStatusCalculationTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCostumeStatusCalculation[], EntityMCostumeStatusCalculationTable>(calculations => new EntityMCostumeStatusCalculationTable(calculations)));
            // ...
            EntityMEventQuestSequenceTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMEventQuestSequence[], EntityMEventQuestSequenceTable>(sequences => new EntityMEventQuestSequenceTable(sequences)));
            // ...
            EntityMImportantItemTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMImportantItem[], EntityMImportantItemTable>(items => new EntityMImportantItemTable(items)));
            // ...
            EntityMMainQuestChapterTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMMainQuestChapter[], EntityMMainQuestChapterTable>(chapters => new EntityMMainQuestChapterTable(chapters)));
            // ...
            EntityMMainQuestRouteTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMMainQuestRoute[], EntityMMainQuestRouteTable>(routes => new EntityMMainQuestRouteTable(routes)));
            EntityMMainQuestSeasonTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMMainQuestSeason[], EntityMMainQuestSeasonTable>(seasons => new EntityMMainQuestSeasonTable(seasons)));
            EntityMMainQuestSequenceTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMMainQuestSequence[], EntityMMainQuestSequenceTable>(sequences => new EntityMMainQuestSequenceTable(sequences)));
            EntityMMainQuestSequenceGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMMainQuestSequenceGroup[], EntityMMainQuestSequenceGroupTable>(groups => new EntityMMainQuestSequenceGroupTable(groups)));
            // ...
            EntityMMaterialTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMMaterial[], EntityMMaterialTable>(materials => new EntityMMaterialTable(materials)));
            // ...
            EntityMQuestTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuest[], EntityMQuestTable>(quests => new EntityMQuestTable(quests)));
            EntityMQuestBonusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuestBonus[], EntityMQuestBonusTable>(bonuses => new EntityMQuestBonusTable(bonuses)));
            // ...
            EntityMNumericalFunctionTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMNumericalFunction[], EntityMNumericalFunctionTable>(functions => new EntityMNumericalFunctionTable(functions)));
            EntityMNumericalFunctionParameterGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMNumericalFunctionParameterGroup[], EntityMNumericalFunctionParameterGroupTable>(groups => new EntityMNumericalFunctionParameterGroupTable(groups)));
            // ...
            EntityMEventQuestChapterCharacterTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMEventQuestChapterCharacter[], EntityMEventQuestChapterCharacterTable>(characters => new EntityMEventQuestChapterCharacterTable(characters)));
            // ...
            EntityMEventQuestSequenceGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMEventQuestSequenceGroup[], EntityMEventQuestSequenceGroupTable>(groups => new EntityMEventQuestSequenceGroupTable(groups)));
            // ...
            EntityMPartsEnhancedTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMPartsEnhanced[], EntityMPartsEnhancedTable>(enhanceds => new EntityMPartsEnhancedTable(enhanceds)));
            EntityMPartsTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMParts[], EntityMPartsTable>(partses => new EntityMPartsTable(partses)));
            // ...
            EntityMPartsGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMPartsGroup[], EntityMPartsGroupTable>(groups => new EntityMPartsGroupTable(groups)));
            // ...
            EntityMPartsSeriesTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMPartsSeries[], EntityMPartsSeriesTable>(series => new EntityMPartsSeriesTable(series)));
            EntityMPartsSeriesBonusAbilityGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMPartsSeriesBonusAbilityGroup[], EntityMPartsSeriesBonusAbilityGroupTable>(groups => new EntityMPartsSeriesBonusAbilityGroupTable(groups)));
            EntityMPartsStatusMainTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMPartsStatusMain[], EntityMPartsStatusMainTable>(mains => new EntityMPartsStatusMainTable(mains)));
            EntityMPlatformPaymentTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMPlatformPayment[], EntityMPlatformPaymentTable>(payments => new EntityMPlatformPaymentTable(payments)));
            // ...
            EntityMPowerCalculationConstantValueTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMPowerCalculationConstantValue[], EntityMPowerCalculationConstantValueTable>(values => new EntityMPowerCalculationConstantValueTable(values)));
            EntityMPowerReferenceStatusGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMPowerReferenceStatusGroup[], EntityMPowerReferenceStatusGroupTable>(groups => new EntityMPowerReferenceStatusGroupTable(groups)));
            // ...
            EntityMQuestCampaignTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuestCampaign[], EntityMQuestCampaignTable>(campaigns => new EntityMQuestCampaignTable(campaigns)));
            EntityMQuestCampaignEffectGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuestCampaignEffectGroup[], EntityMQuestCampaignEffectGroupTable>(groups => new EntityMQuestCampaignEffectGroupTable(groups)));
            EntityMQuestCampaignTargetGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuestCampaignTargetGroup[], EntityMQuestCampaignTargetGroupTable>(groups => new EntityMQuestCampaignTargetGroupTable(groups)));
            // ...
            EntityMQuestDeckRestrictionGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuestDeckRestrictionGroup[], EntityMQuestDeckRestrictionGroupTable>(groups => new EntityMQuestDeckRestrictionGroupTable(groups)));
            EntityMQuestDisplayAttributeGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuestDisplayAttributeGroup[], EntityMQuestDisplayAttributeGroupTable>(groups => new EntityMQuestDisplayAttributeGroupTable(groups)));
            EntityMQuestFirstClearRewardGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuestFirstClearRewardGroup[], EntityMQuestFirstClearRewardGroupTable>(groups => new EntityMQuestFirstClearRewardGroupTable(groups)));
            EntityMQuestMissionTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuestMission[], EntityMQuestMissionTable>(missions => new EntityMQuestMissionTable(missions)));
            EntityMQuestMissionConditionValueGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuestMissionConditionValueGroup[], EntityMQuestMissionConditionValueGroupTable>(groups => new EntityMQuestMissionConditionValueGroupTable(groups)));
            EntityMQuestMissionGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuestMissionGroup[], EntityMQuestMissionGroupTable>(groups => new EntityMQuestMissionGroupTable(groups)));
            // ...
            EntityMQuestReleaseConditionBigHuntScoreTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuestReleaseConditionBigHuntScore[], EntityMQuestReleaseConditionBigHuntScoreTable>(scores => new EntityMQuestReleaseConditionBigHuntScoreTable(scores)));
            EntityMQuestReleaseConditionCharacterLevelTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuestReleaseConditionCharacterLevel[], EntityMQuestReleaseConditionCharacterLevelTable>(levels => new EntityMQuestReleaseConditionCharacterLevelTable(levels)));
            EntityMQuestReleaseConditionDeckPowerTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuestReleaseConditionDeckPower[], EntityMQuestReleaseConditionDeckPowerTable>(powers => new EntityMQuestReleaseConditionDeckPowerTable(powers)));
            EntityMQuestReleaseConditionGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuestReleaseConditionGroup[], EntityMQuestReleaseConditionGroupTable>(groups => new EntityMQuestReleaseConditionGroupTable(groups)));
            EntityMQuestReleaseConditionListTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuestReleaseConditionList[], EntityMQuestReleaseConditionListTable>(lists => new EntityMQuestReleaseConditionListTable(lists)));
            EntityMQuestReleaseConditionQuestClearTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuestReleaseConditionQuestClear[], EntityMQuestReleaseConditionQuestClearTable>(clears => new EntityMQuestReleaseConditionQuestClearTable(clears)));
            EntityMQuestReleaseConditionUserLevelTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuestReleaseConditionUserLevel[], EntityMQuestReleaseConditionUserLevelTable>(levels => new EntityMQuestReleaseConditionUserLevelTable(levels)));
            EntityMQuestReleaseConditionWeaponAcquisitionTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuestReleaseConditionWeaponAcquisition[], EntityMQuestReleaseConditionWeaponAcquisitionTable>(acquisitions => new EntityMQuestReleaseConditionWeaponAcquisitionTable(acquisitions)));
            // ...
            EntityMQuestSceneTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuestScene[], EntityMQuestSceneTable>(scenes => new EntityMQuestSceneTable(scenes)));
            EntityMQuestSceneBattleTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuestSceneBattle[], EntityMQuestSceneBattleTable>(battles => new EntityMQuestSceneBattleTable(battles)));
            // ...
            EntityMQuestScheduleTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuestSchedule[], EntityMQuestScheduleTable>(schedules => new EntityMQuestScheduleTable(schedules)));
            EntityMQuestScheduleCorrespondenceTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuestScheduleCorrespondence[], EntityMQuestScheduleCorrespondenceTable>(correspondences => new EntityMQuestScheduleCorrespondenceTable(correspondences)));
            // ...
            EntityMShopTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMShop[], EntityMShopTable>(shops => new EntityMShopTable(shops)));
            // ...
            EntityMShopItemTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMShopItem[], EntityMShopItemTable>(items => new EntityMShopItemTable(items)));
            // ...
            EntityMShopItemCellTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMShopItemCell[], EntityMShopItemCellTable>(cells => new EntityMShopItemCellTable(cells)));
            EntityMShopItemCellGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMShopItemCellGroup[], EntityMShopItemCellGroupTable>(groups => new EntityMShopItemCellGroupTable(groups)));
            EntityMShopItemCellTermTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMShopItemCellTerm[], EntityMShopItemCellTermTable>(terms => new EntityMShopItemCellTermTable(terms)));
            // ...
            EntityMShopItemContentPossessionTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMShopItemContentPossession[], EntityMShopItemContentPossessionTable>(possessions => new EntityMShopItemContentPossessionTable(possessions)));
            EntityMShopItemLimitedStockTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMShopItemLimitedStock[], EntityMShopItemLimitedStockTable>(stocks => new EntityMShopItemLimitedStockTable(stocks)));
            // ...
            EntityMSkillTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkill[], EntityMSkillTable>(skills => new EntityMSkillTable(skills)));
            // ...
            EntityMSkillBehaviourTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillBehaviour[], EntityMSkillBehaviourTable>(behaviours => new EntityMSkillBehaviourTable(behaviours)));
            // ...
            EntityMSkillBehaviourActivationMethodTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillBehaviourActivationMethod[], EntityMSkillBehaviourActivationMethodTable>(methods => new EntityMSkillBehaviourActivationMethodTable(methods)));
            EntityMSkillBehaviourGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillBehaviourGroup[], EntityMSkillBehaviourGroupTable>(groups => new EntityMSkillBehaviourGroupTable(groups)));
            // ...
            EntityMSkillDetailTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillDetail[], EntityMSkillDetailTable>(details => new EntityMSkillDetailTable(details)));
            EntityMSkillLevelGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillLevelGroup[], EntityMSkillLevelGroupTable>(groups => new EntityMSkillLevelGroupTable(groups)));
            // ...
            EntityMWeaponTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMWeapon[], EntityMWeaponTable>(weapons => new EntityMWeaponTable(weapons)));
            // ...
            EntityMWeaponAbilityGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMWeaponAbilityGroup[], EntityMWeaponAbilityGroupTable>(groups => new EntityMWeaponAbilityGroupTable(groups)));
            EntityMWeaponBaseStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMWeaponBaseStatus[], EntityMWeaponBaseStatusTable>(statuses => new EntityMWeaponBaseStatusTable(statuses)));
            // ...
            EntityMEventQuestChapterTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMEventQuestChapter[], EntityMEventQuestChapterTable>(elements => new EntityMEventQuestChapterTable(elements)));
            // ...
            EntityMWeaponEvolutionGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMWeaponEvolutionGroup[], EntityMWeaponEvolutionGroupTable>(groups => new EntityMWeaponEvolutionGroupTable(groups)));
            // ...
            EntityMWeaponRarityTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMWeaponRarity[], EntityMWeaponRarityTable>(rarities => new EntityMWeaponRarityTable(rarities)));
            EntityMWeaponEnhancedTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMWeaponEnhanced[], EntityMWeaponEnhancedTable>(enhanceds => new EntityMWeaponEnhancedTable(enhanceds)));
            // ...
            EntityMWeaponStatusCalculationTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMWeaponStatusCalculation[], EntityMWeaponStatusCalculationTable>(calculations => new EntityMWeaponStatusCalculationTable(calculations)));
            // ...
            EntityMWeaponSkillGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMWeaponSkillGroup[], EntityMWeaponSkillGroupTable>(groups => new EntityMWeaponSkillGroupTable(groups)));
            EntityMWeaponSpecificEnhanceTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMWeaponSpecificEnhance[], EntityMWeaponSpecificEnhanceTable>(enhances => new EntityMWeaponSpecificEnhanceTable(enhances)));
            // ...

            EntityMQuestBonusCharacterGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuestBonusCharacterGroup[], EntityMQuestBonusCharacterGroupTable>(groups => new EntityMQuestBonusCharacterGroupTable(groups)));
            EntityMQuestBonusCostumeSettingGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuestBonusCostumeSettingGroup[], EntityMQuestBonusCostumeSettingGroupTable>(groups => new EntityMQuestBonusCostumeSettingGroupTable(groups)));
            EntityMQuestBonusTermGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuestBonusTermGroup[], EntityMQuestBonusTermGroupTable>(groups => new EntityMQuestBonusTermGroupTable(groups)));
            EntityMQuestBonusWeaponGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuestBonusWeaponGroup[], EntityMQuestBonusWeaponGroupTable>(groups => new EntityMQuestBonusWeaponGroupTable(groups)));

            EntityMThoughtTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMThought[], EntityMThoughtTable>(thoughts => new EntityMThoughtTable(thoughts)));

            EntityMCostumeAwakenTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCostumeAwaken[], EntityMCostumeAwakenTable>(awakens => new EntityMCostumeAwakenTable(awakens)));
        }
    }
}
