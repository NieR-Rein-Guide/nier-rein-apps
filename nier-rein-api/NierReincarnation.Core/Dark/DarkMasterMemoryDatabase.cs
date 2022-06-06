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
        // 0xF8
        public EntityMEventQuestLinkTable EntityMEventQuestLinkTable { get; private set; }
        // 0x170
        public EntityMBattleGroupTable EntityMBattleGroupTable { get; private set; }
        // 0x1B0
        public EntityMBattleNpcCompanionTable EntityMBattleNpcCompanionTable { get; private set; }
        // 0x1B8
        public EntityMBattleNpcCostumeTable EntityMBattleNpcCostumeTable { get; private set; }
        // 0x1C0
        public EntityMBattleNpcCostumeActiveSkillTable EntityMBattleNpcCostumeActiveSkillTable { get; private set; }
        // 0x1D8
        public EntityMBattleNpcDeckTable EntityMBattleNpcDeckTable { get; private set; }
        // 0x1E0
        public EntityMBattleNpcDeckCharacterTable EntityMBattleNpcDeckCharacterTable { get; private set; }
        // 0x240
        public EntityMBattleNpcWeaponTable EntityMBattleNpcWeaponTable { get; private set; }
        // 0x270
        public EntityMBattleQuestSceneBgmTable EntityMBattleQuestSceneBgmTable { get; private set; }
        // 0x280
        public EntityMBattleRentalDeckTable EntityMBattleRentalDeckTable { get; private set; }
        // 0x290
        public EntityMBigHuntBossTable EntityMBigHuntBossTable { get; private set; }
        // 0x298
        public EntityMBigHuntBossGradeGroupTable EntityMBigHuntBossGradeGroupTable { get; private set; }
        // 0x2A8
        public EntityMBigHuntBossQuestTable EntityMBigHuntBossQuestTable { get; private set; } 
        // 0x2C8
        public EntityMBigHuntQuestTable EntityMBigHuntQuestTable { get; private set; }
        // 0x2D0
        public EntityMBigHuntQuestGroupTable EntityMBigHuntQuestGroupTable { get; private set; }
        // 0x2D8
        public EntityMBigHuntQuestScoreCoefficientTable EntityMBigHuntQuestScoreCoefficientTable { get; private set; }
        // 0x328
        public EntityMCatalogCompanionTable EntityMCatalogCompanionTable { get; private set; }
        // 0x330
        public EntityMCatalogCostumeTable EntityMCatalogCostumeTable { get; private set; }
        // 0x338
        public EntityMCatalogPartsGroupTable EntityMCatalogPartsGroupTable { get; private set; }
        // 0x340
        public EntityMCatalogTermTable EntityMCatalogTermTable { get; private set; }
        // 0x348
        public EntityMCatalogWeaponTable EntityMCatalogWeaponTable { get; private set; }
        // 0x350
        public EntityMCharacterTable EntityMCharacterTable { get; private set; }
        // 0x3E8
        public EntityMCharacterDisplaySwitchTable EntityMCharacterDisplaySwitchTable { get; private set; }
        // 0x3F0
        public EntityMCharacterLevelBonusAbilityGroupTable EntityMCharacterLevelBonusAbilityGroupTable { get; private set; }
        // 0x428
        public EntityMCompanionTable EntityMCompanionTable { get; private set; }
        // 0x430
        public EntityMCompanionAbilityGroupTable EntityMCompanionAbilityGroupTable { get; private set; }
        // 0x438
        public EntityMCompanionAbilityLevelTable EntityMCompanionAbilityLevelTable { get; private set; }
        // 0x440
        public EntityMCompanionBaseStatusTable EntityMCompanionBaseStatusTable { get; private set; }
        // 0x448
        public EntityMCompanionCategoryTable EntityMCompanionCategoryTable { get; private set; }
        // 0x450
        public EntityMConfigTable EntityMConfigTable { get; private set; }
        // 0x458
        public EntityMCompanionEnhancedTable EntityMCompanionEnhancedTable { get; private set; }
        // 0x468
        public EntityMCompanionSkillLevelTable EntityMCompanionSkillLevelTable { get; private set; }
        // 0x470
        public EntityMCompanionStatusCalculationTable EntityMCompanionStatusCalculationTable { get; private set; }
        // 0x488
        public EntityMConsumableItemTable EntityMConsumableItemTable { get; private set; }
        // 0x4A8
        public EntityMCostumeTable EntityMCostumeTable { get; private set; }
        // 0x4B0
        public EntityMCostumeAbilityGroupTable EntityMCostumeAbilityGroupTable { get; private set; }
        // 0x4B8
        public EntityMCostumeAbilityLevelGroupTable EntityMCostumeAbilityLevelGroupTable { get; private set; }
        // 0x4C8
        public EntityMCostumeActiveSkillGroupTable EntityMCostumeActiveSkillGroupTable { get; private set; }
        // 0x4D8
        public EntityMCostumeBaseStatusTable EntityMCostumeBaseStatusTable { get; private set; }
        // 0x510
        public EntityMCostumeEmblemTable EntityMCostumeEmblemTable { get; private set; }
        // 0x518
        public EntityMCostumeEnhancedTable EntityMCostumeEnhancedTable { get; private set; }
        // 0x540
        public EntityMCostumeRarityTable EntityMCostumeRarityTable { get; private set; }
        // 0x550
        public EntityMCostumeStatusCalculationTable EntityMCostumeStatusCalculationTable { get; private set; }
        // 0x5B0
        public EntityMEventQuestChapterCharacterTable EntityMEventQuestChapterCharacterTable { get; private set; }
        // 0x5C8
        public EntityMEventQuestSequenceTable EntityMEventQuestSequenceTable { get; private set; }
        // 0x6A0
        public EntityMImportantItemTable EntityMImportantItemTable { get; private set; }
        // 0x720
        public EntityMMainQuestChapterTable EntityMMainQuestChapterTable { get; private set; }
        // 0x730
        public EntityMMainQuestRouteTable EntityMMainQuestRouteTable { get; private set; }
        // 0x738
        public EntityMMainQuestSeasonTable EntityMMainQuestSeasonTable { get; private set; }
        // 0x740
        public EntityMMainQuestSequenceTable EntityMMainQuestSequenceTable { get; private set; }
        // 0x748
        public EntityMMainQuestSequenceGroupTable EntityMMainQuestSequenceGroupTable { get; private set; }
        // 0x770
        public EntityMMaterialTable EntityMMaterialTable { get; private set; }
        // 0x7C8
        public EntityMNumericalFunctionTable EntityMNumericalFunctionTable { get; private set; }
        // 0x7D0
        public EntityMNumericalFunctionParameterGroupTable EntityMNumericalFunctionParameterGroupTable { get; private set; }
        // 0x800
        public EntityMEventQuestSequenceGroupTable EntityMEventQuestSequenceGroupTable { get; private set; }
        // 0x810
        public EntityMPartsEnhancedTable EntityMPartsEnhancedTable { get; private set; }
        // 0x818
        public EntityMPartsTable EntityMPartsTable { get; private set; }
        // 0x820
        public EntityMPartsGroupTable EntityMPartsGroupTable { get; private set; }
        // 0x840
        public EntityMPartsSeriesTable EntityMPartsSeriesTable { get; private set; }
        // 0x848
        public EntityMPartsSeriesBonusAbilityGroupTable EntityMPartsSeriesBonusAbilityGroupTable { get; private set; }
        // 0x850
        public EntityMPartsStatusMainTable EntityMPartsStatusMainTable { get; private set; }
        // 0x858
        public EntityMPlatformPaymentTable EntityMPlatformPaymentTable { get; private set; }
        // 0x8A0
        public EntityMPowerCalculationConstantValueTable EntityMPowerCalculationConstantValueTable { get; private set; }
        // 0x8A8
        public EntityMPowerReferenceStatusGroupTable EntityMPowerReferenceStatusGroupTable { get; private set; }
        // 0x918
        public EntityMQuestTable EntityMQuestTable { get; private set; }
        // 0x960
        public EntityMQuestCampaignTable EntityMQuestCampaignTable { get; private set; }
        // 0x968
        public EntityMQuestCampaignEffectGroupTable EntityMQuestCampaignEffectGroupTable { get; private set; }
        // 0x970
        public EntityMQuestCampaignTargetGroupTable EntityMQuestCampaignTargetGroupTable { get; private set; }
        // 0x988
        public EntityMQuestDisplayAttributeGroupTable EntityMQuestDisplayAttributeGroupTable { get; private set; }
        // 0x990
        public EntityMQuestFirstClearRewardGroupTable EntityMQuestFirstClearRewardGroupTable { get; private set; }
        // 0x998
        public EntityMQuestMissionTable EntityMQuestMissionTable { get; private set; }
        // 0x9A0
        public EntityMQuestMissionConditionValueGroupTable EntityMQuestMissionConditionValueGroupTable { get; private set; }
        // 0x9A8
        public EntityMQuestMissionGroupTable EntityMQuestMissionGroupTable { get; private set; }
        // 0x9C8
        public EntityMQuestReleaseConditionBigHuntScoreTable EntityMQuestReleaseConditionBigHuntScoreTable { get; private set; }
        // 0x9D0
        public EntityMQuestReleaseConditionCharacterLevelTable EntityMQuestReleaseConditionCharacterLevelTable { get; private set; }
        // 0x9D8
        public EntityMQuestReleaseConditionDeckPowerTable EntityMQuestReleaseConditionDeckPowerTable { get; private set; }
        // 0x9E0
        public EntityMQuestReleaseConditionGroupTable EntityMQuestReleaseConditionGroupTable { get; private set; }
        // 0x9E8
        public EntityMQuestReleaseConditionListTable EntityMQuestReleaseConditionListTable { get; private set; }
        // 0x9F0
        public EntityMQuestReleaseConditionQuestClearTable EntityMQuestReleaseConditionQuestClearTable { get; private set; }
        // 0x9F8
        public EntityMQuestReleaseConditionUserLevelTable EntityMQuestReleaseConditionUserLevelTable { get; private set; }
        // 0xA00
        public EntityMQuestReleaseConditionWeaponAcquisitionTable EntityMQuestReleaseConditionWeaponAcquisitionTable { get; private set; }
        // 0xA10
        public EntityMQuestSceneTable EntityMQuestSceneTable { get; private set; }
        // 0xA18
        public EntityMQuestSceneBattleTable EntityMQuestSceneBattleTable { get; private set; }
        // 0xA30
        public EntityMQuestScheduleTable EntityMQuestScheduleTable { get; private set; }
        // 0xA38
        public EntityMQuestScheduleCorrespondenceTable EntityMQuestScheduleCorrespondenceTable { get; private set; }
        // 0xA48
        public EntityMShopTable EntityMShopTable { get; private set; }
        // 0xA58
        public EntityMShopItemTable EntityMShopItemTable { get; private set; }
        // 0xA68
        public EntityMShopItemCellTable EntityMShopItemCellTable { get; private set; }
        // 0xA70
        public EntityMShopItemCellGroupTable EntityMShopItemCellGroupTable { get; private set; }
        // 0xA78
        public EntityMShopItemCellTermTable EntityMShopItemCellTermTable { get; private set; }
        // 0xAB0
        public EntityMSkillTable EntityMSkillTable { get; private set; }
        // 0xB80
        public EntityMSkillBehaviourTable EntityMSkillBehaviourTable { get; private set; }
        // 0xC50
        public EntityMSkillBehaviourActivationMethodTable EntityMSkillBehaviourActivationMethodTable { get; private set; }
        // 0xC58
        public EntityMSkillBehaviourGroupTable EntityMSkillBehaviourGroupTable { get; private set; }
        // 0xD08
        public EntityMSkillDetailTable EntityMSkillDetailTable { get; private set; }
        // 0xD10
        public EntityMSkillLevelGroupTable EntityMSkillLevelGroupTable { get; private set; }
        // 0xDC0
        public EntityMWeaponTable EntityMWeaponTable { get; private set; }
        // 0xDD0
        public EntityMWeaponAbilityGroupTable EntityMWeaponAbilityGroupTable { get; private set; }
        // 0xDD8
        public EntityMWeaponBaseStatusTable EntityMWeaponBaseStatusTable { get; private set; }
        // 0xDE8
        public EntityMEventQuestChapterTable EntityMEventQuestChapterTable { get; private set; }
        // 0xE00
        public EntityMWeaponEvolutionGroupTable EntityMWeaponEvolutionGroupTable { get; private set; }
        // 0xE10
        public EntityMWeaponRarityTable EntityMWeaponRarityTable { get; private set; }
        // 0xE18
        public EntityMWeaponEnhancedTable EntityMWeaponEnhancedTable { get; private set; }
        // 0xE28
        public EntityMWeaponSkillGroupTable EntityMWeaponSkillGroupTable { get; private set; }
        // 0xE30
        public EntityMWeaponSpecificEnhanceTable EntityMWeaponSpecificEnhanceTable { get; private set; }
        // 0xE40
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
            EntityMQuestTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuest[], EntityMQuestTable>(quests => new EntityMQuestTable(quests)));
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
        }
    }
}
