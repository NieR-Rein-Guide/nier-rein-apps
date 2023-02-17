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
        public EntityMAbilityBehaviourActionBlessTable EntityMAbilityBehaviourActionBlessTable { get; private set; }
        // 0x28
        public EntityMAbilityBehaviourActionPassiveSkillTable EntityMAbilityBehaviourActionPassiveSkillTable { get; private set; }
        // 0x30
        public EntityMAbilityBehaviourActionStatusTable EntityMAbilityBehaviourActionStatusTable { get; private set; }
        // 0x38
        public EntityMAbilityBehaviourGroupTable EntityMAbilityBehaviourGroupTable { get; private set; }
        // 0x40
        public EntityMAbilityDetailTable EntityMAbilityDetailTable { get; private set; }
        // 0x48
        public EntityMAbilityLevelGroupTable EntityMAbilityLevelGroupTable { get; private set; }
        // 0x50
        public EntityMAbilityStatusTable EntityMAbilityStatusTable { get; private set; }

        // 0x58
        public EntityMActorTable EntityMActorTable { get; private set; }
        // 0x60
        public EntityMActorAnimationTable EntityMActorAnimationTable { get; private set; }
        // 0x68
        public EntityMActorAnimationCategoryTable EntityMActorAnimationCategoryTable { get; private set; }
        // 0x70
        public EntityMActorAnimationControllerTable EntityMActorAnimationControllerTable { get; private set; }
        // 0x78
        public EntityMActorObjectTable EntityMActorObjectTable { get; private set; }
        // 0x80
        public EntityMAppealDialogTable EntityMAppealDialogTable { get; private set; }
        // 0x88
        public EntityMAssetBackgroundTable EntityMAssetBackgroundTable { get; private set; }
        // 0x90
        public EntityMAssetCalculatorTable EntityMAssetCalculatorTable { get; private set; }
        // 0x98
        public EntityMAssetDataSettingTable EntityMAssetDataSettingTable { get; private set; }
        // 0xA0
        public EntityMAssetEffectTable EntityMAssetEffectTable { get; private set; }
        // 0xA8
        public EntityMAssetGradeIconTable EntityMAssetGradeIconTable { get; private set; }
        // 0xB0
        public EntityMAssetTimelineTable EntityMAssetTimelineTable { get; private set; }
        // 0xB8
        public EntityMAssetTurnbattlePrefabTable EntityMAssetTurnbattlePrefabTable { get; private set; }
        // 0xC0
        public EntityMBattleTable EntityMBattleTable { get; private set; }

        // 0xC8
        public EntityMBattleActorAiTable EntityMBattleActorAiTable { get; private set; }
        // 0xD0
        public EntityMBattleActorSkillAiGroupTable EntityMBattleActorSkillAiGroupTable { get; private set; }
        // 0xD8
        public EntityMBattleAdditionalAbilityTable EntityMBattleAdditionalAbilityTable { get; private set; }
        // 0xE0
        public EntityMBattleAttributeDamageCoefficientDefineTable EntityMBattleAttributeDamageCoefficientDefineTable { get; private set; }
        // 0xE8
        public EntityMBattleAttributeDamageCoefficientGroupTable EntityMBattleAttributeDamageCoefficientGroupTable { get; private set; }
        // 0xF0
        public EntityMBattleBgmSetTable EntityMBattleBgmSetTable { get; private set; }
        // 0xF8
        public EntityMBattleBgmSetGroupTable EntityMBattleBgmSetGroupTable { get; private set; }
        // 0x100
        public EntityMBattleBigHuntTable EntityMBattleBigHuntTable { get; private set; }
        // 0x108
        public EntityMBattleBigHuntDamageThresholdGroupTable EntityMBattleBigHuntDamageThresholdGroupTable { get; private set; }
        // 0x110
        public EntityMBattleBigHuntKnockDownGaugeValueConfigGroupTable EntityMBattleBigHuntKnockDownGaugeValueConfigGroupTable { get; private set; }
        // 0x118
        public EntityMBattleBigHuntPhaseGroupTable EntityMBattleBigHuntPhaseGroupTable { get; private set; }
        // 0x120
        public EntityMBattleCompanionSkillAiGroupTable EntityMBattleCompanionSkillAiGroupTable { get; private set; }
        // 0x128
        public EntityMBattleCostumeSkillFireActTable EntityMBattleCostumeSkillFireActTable { get; private set; }
        // 0x130
        public EntityMBattleCostumeSkillSeTable EntityMBattleCostumeSkillSeTable { get; private set; }
        // 0x138
        public EntityMBattleDropRewardTable EntityMBattleDropRewardTable { get; private set; }
        // 0x140
        public EntityMBattleEnemySizeTypeConfigTable EntityMBattleEnemySizeTypeConfigTable { get; private set; }
        // 0x148
        public EntityMBattleEventTable EntityMBattleEventTable { get; private set; }
        // 0x150
        public EntityMBattleEventGroupTable EntityMBattleEventGroupTable { get; private set; }
        // 0x158
        public EntityMBattleEventReceiverBehaviourGroupTable EntityMBattleEventReceiverBehaviourGroupTable { get; private set; }
        // 0x160
        public EntityMBattleEventReceiverBehaviourHudActSequenceTable EntityMBattleEventReceiverBehaviourHudActSequenceTable { get; private set; }
        // 0x168
        public EntityMBattleEventReceiverBehaviourRadioMessageTable EntityMBattleEventReceiverBehaviourRadioMessageTable { get; private set; }
        // 0x170
        public EntityMBattleEventTriggerBehaviourBattleStartTable EntityMBattleEventTriggerBehaviourBattleStartTable { get; private set; }
        // 0x178
        public EntityMBattleEventTriggerBehaviourGroupTable EntityMBattleEventTriggerBehaviourGroupTable { get; private set; }
        // 0x180
        public EntityMBattleEventTriggerBehaviourWaveStartTable EntityMBattleEventTriggerBehaviourWaveStartTable { get; private set; }
        // 0x188
        public EntityMBattleGeneralViewConfigurationTable EntityMBattleGeneralViewConfigurationTable { get; private set; }
        // 0x190
        public EntityMBattleGroupTable EntityMBattleGroupTable { get; private set; }

        // 0x198
        public EntityMBattleNpcTable EntityMBattleNpcTable { get; private set; }
        // 0x1A0
        public EntityMBattleNpcCharacterTable EntityMBattleNpcCharacterTable { get; private set; }
        // 0x1A8
        public EntityMBattleNpcCharacterBoardTable EntityMBattleNpcCharacterBoardTable { get; private set; }
        // 0x1B0
        public EntityMBattleNpcCharacterBoardAbilityTable EntityMBattleNpcCharacterBoardAbilityTable { get; private set; }
        // 0x1B8
        public EntityMBattleNpcCharacterBoardCompleteRewardTable EntityMBattleNpcCharacterBoardCompleteRewardTable { get; private set; }
        // 0x1C0
        public EntityMBattleNpcCharacterBoardStatusUpTable EntityMBattleNpcCharacterBoardStatusUpTable { get; private set; }
        // 0x1C8
        public EntityMBattleNpcCharacterCostumeLevelBonusTable EntityMBattleNpcCharacterCostumeLevelBonusTable { get; private set; }
        // 0x1D0
        public EntityMBattleNpcCharacterRebirthTable EntityMBattleNpcCharacterRebirthTable { get; private set; }
        // 0x1D8
        public EntityMBattleNpcCharacterViewerFieldTable EntityMBattleNpcCharacterViewerFieldTable { get; private set; }
        // 0x1E0
        public EntityMBattleNpcCompanionTable EntityMBattleNpcCompanionTable { get; private set; }
        // 0x1E8
        public EntityMBattleNpcCostumeTable EntityMBattleNpcCostumeTable { get; private set; }
        // 0x1F0
        public EntityMBattleNpcCostumeActiveSkillTable EntityMBattleNpcCostumeActiveSkillTable { get; private set; }

        // 0x1F8
        public EntityMBattleNpcCostumeAwakenStatusUpTable EntityMBattleNpcCostumeAwakenStatusUpTable { get; private set; }
        // 0x200
        public EntityMBattleNpcCostumeLevelBonusReevaluateTable EntityMBattleNpcCostumeLevelBonusReevaluateTable { get; private set; }
        // 0x208
        public EntityMBattleNpcCostumeLevelBonusReleaseStatusTable EntityMBattleNpcCostumeLevelBonusReleaseStatusTable { get; private set; }
        // 0x210
        public EntityMBattleNpcDeckTable EntityMBattleNpcDeckTable { get; private set; }
        // 0x218
        public EntityMBattleNpcDeckCharacterTable EntityMBattleNpcDeckCharacterTable { get; private set; }

        // 0x220
        public EntityMBattleNpcDeckCharacterDressupCostumeTable EntityMBattleNpcDeckCharacterDressupCostumeTable { get; private set; }
        // 0x228
        public EntityMBattleNpcDeckCharacterDropCategoryTable EntityMBattleNpcDeckCharacterDropCategoryTable { get; private set; }
        // 0x230
        public EntityMBattleNpcDeckCharacterTypeTable EntityMBattleNpcDeckCharacterTypeTable { get; private set; }
        // 0x238
        public EntityMBattleNpcDeckLimitContentRestrictedTable EntityMBattleNpcDeckLimitContentRestrictedTable { get; private set; }
        // 0x240
        public EntityMBattleNpcDeckPartsGroupTable EntityMBattleNpcDeckPartsGroupTable { get; private set; }
        // 0x248
        public EntityMBattleNpcDeckSubWeaponGroupTable EntityMBattleNpcDeckSubWeaponGroupTable { get; private set; }
        // 0x250
        public EntityMBattleNpcDeckTypeNoteTable EntityMBattleNpcDeckTypeNoteTable { get; private set; }
        // 0x258
        public EntityMBattleNpcPartsTable EntityMBattleNpcPartsTable { get; private set; }
        // 0x260
        public EntityMBattleNpcPartsGroupNoteTable EntityMBattleNpcPartsGroupNoteTable { get; private set; }
        // 0x268
        public EntityMBattleNpcPartsPresetTable EntityMBattleNpcPartsPresetTable { get; private set; }
        // 0x270
        public EntityMBattleNpcPartsPresetTagTable EntityMBattleNpcPartsPresetTagTable { get; private set; }
        // 0x278
        public EntityMBattleNpcPartsStatusSubTable EntityMBattleNpcPartsStatusSubTable { get; private set; }
        // 0x280
        public EntityMBattleNpcSpecialEndActTable EntityMBattleNpcSpecialEndActTable { get; private set; }
        // 0x288
        public EntityMBattleNpcWeaponTable EntityMBattleNpcWeaponTable { get; private set; }

        // 0x290
        public EntityMBattleNpcWeaponAbilityTable EntityMBattleNpcWeaponAbilityTable { get; private set; }
        // 0x298
        public EntityMBattleNpcWeaponAbilityReevaluateTable EntityMBattleNpcWeaponAbilityReevaluateTable { get; private set; }
        // 0x2A0
        public EntityMBattleNpcWeaponAwakenTable EntityMBattleNpcWeaponAwakenTable { get; private set; }
        // 0x2A8
        public EntityMBattleNpcWeaponNoteTable EntityMBattleNpcWeaponNoteTable { get; private set; }
        // 0x2B0
        public EntityMBattleNpcWeaponNoteReevaluateTable EntityMBattleNpcWeaponNoteReevaluateTable { get; private set; }
        // 0x2B8
        public EntityMBattleNpcWeaponSkillTable EntityMBattleNpcWeaponSkillTable { get; private set; }
        // 0x2C0
        public EntityMBattleNpcWeaponStoryTable EntityMBattleNpcWeaponStoryTable { get; private set; }
        // 0x2C8
        public EntityMBattleNpcWeaponStoryReevaluateTable EntityMBattleNpcWeaponStoryReevaluateTable { get; private set; }
        // 0x2D0
        public EntityMBattleProgressUiTypeTable EntityMBattleProgressUiTypeTable { get; private set; }
        // 0x2D8
        public EntityMBattleQuestSceneBgmTable EntityMBattleQuestSceneBgmTable { get; private set; }

        // 0x2E0
        public EntityMBattleQuestSceneBgmSetGroupTable EntityMBattleQuestSceneBgmSetGroupTable { get; private set; }
        // 0x2E8
        public EntityMBattleRentalDeckTable EntityMBattleRentalDeckTable { get; private set; }

        // 0x2F0
        public EntityMBattleSkillBehaviourHitDamageConfigurationTable EntityMBattleSkillBehaviourHitDamageConfigurationTable { get; private set; }
        // 0x2F8
        public EntityMBattleSkillFireActTable EntityMBattleSkillFireActTable { get; private set; }
        // 0x300
        public EntityMBattleSkillFireActConditionAttributeTypeTable EntityMBattleSkillFireActConditionAttributeTypeTable { get; private set; }
        // 0x308
        public EntityMBattleSkillFireActConditionGroupTable EntityMBattleSkillFireActConditionGroupTable { get; private set; }
        // 0x310
        public EntityMBattleSkillFireActConditionSkillCategoryTypeTable EntityMBattleSkillFireActConditionSkillCategoryTypeTable { get; private set; }
        // 0x318
        public EntityMBattleSkillFireActConditionWeaponTypeTable EntityMBattleSkillFireActConditionWeaponTypeTable { get; private set; }
        // 0x320
        public EntityMBeginnerCampaignTable EntityMBeginnerCampaignTable { get; private set; }
        // 0x328
        public EntityMBigHuntBossTable EntityMBigHuntBossTable { get; private set; }
        // 0x330
        public EntityMBigHuntBossGradeGroupTable EntityMBigHuntBossGradeGroupTable { get; private set; }

        // 0x338
        public EntityMBigHuntBossGradeGroupAttributeTable EntityMBigHuntBossGradeGroupAttributeTable { get; private set; }
        // 0x340
        public EntityMBigHuntBossQuestTable EntityMBigHuntBossQuestTable { get; private set; } 

        // 0x348
        public EntityMBigHuntBossQuestGroupTable EntityMBigHuntBossQuestGroupTable { get; private set; }
        // 0x350
        public EntityMBigHuntBossQuestGroupChallengeCategoryTable EntityMBigHuntBossQuestGroupChallengeCategoryTable { get; private set; }
        // 0x358
        public EntityMBigHuntLinkTable EntityMBigHuntLinkTable { get; private set; }
        // 0x360
        public EntityMBigHuntQuestTable EntityMBigHuntQuestTable { get; private set; }
        // 0x368
        public EntityMBigHuntQuestGroupTable EntityMBigHuntQuestGroupTable { get; private set; }
        // 0x370
        public EntityMBigHuntQuestScoreCoefficientTable EntityMBigHuntQuestScoreCoefficientTable { get; private set; }

        // 0x378
        public EntityMBigHuntRewardGroupTable EntityMBigHuntRewardGroupTable { get; private set; }
        // 0x380
        public EntityMBigHuntScheduleTable EntityMBigHuntScheduleTable { get; private set; }
        // 0x388
        public EntityMBigHuntScoreRewardGroupTable EntityMBigHuntScoreRewardGroupTable { get; private set; }
        // 0x390
        public EntityMBigHuntScoreRewardGroupScheduleTable EntityMBigHuntScoreRewardGroupScheduleTable { get; private set; }
        // 0x398
        public EntityMBigHuntWeeklyAttributeScoreRewardGroupScheduleTable EntityMBigHuntWeeklyAttributeScoreRewardGroupScheduleTable { get; private set; }
        // 0x3A0
        public EntityMCageMemoryTable EntityMCageMemoryTable { get; private set; }
        // 0x3A8
        public EntityMCageOrnamentTable EntityMCageOrnamentTable { get; private set; }
        // 0x3B0
        public EntityMCageOrnamentMainQuestChapterStillTable EntityMCageOrnamentMainQuestChapterStillTable { get; private set; }
        // 0x3B8
        public EntityMCageOrnamentRewardTable EntityMCageOrnamentRewardTable { get; private set; }
        // 0x3C0
        public EntityMCageOrnamentStillReleaseConditionTable EntityMCageOrnamentStillReleaseConditionTable { get; private set; }
        // 0x3C8
        public EntityMCatalogCompanionTable EntityMCatalogCompanionTable { get; private set; }
        // 0x3D0
        public EntityMCatalogCostumeTable EntityMCatalogCostumeTable { get; private set; }
        // 0x3D8
        public EntityMCatalogPartsGroupTable EntityMCatalogPartsGroupTable { get; private set; }
        // 0x3E0
        public EntityMCatalogTermTable EntityMCatalogTermTable { get; private set; }
        // 0x3E8
        public EntityMCatalogThoughtTable EntityMCatalogThoughtTable { get; private set; }

        // 0x3F0
        public EntityMCatalogWeaponTable EntityMCatalogWeaponTable { get; private set; }
        // 0x3F8
        public EntityMCharacterTable EntityMCharacterTable { get; private set; }

        // 0x400
        public EntityMCharacterBoardTable EntityMCharacterBoardTable { get; private set; }
        // 0x408
        public EntityMCharacterBoardAbilityTable EntityMCharacterBoardAbilityTable { get; private set; }
        // 0x410
        public EntityMCharacterBoardAbilityMaxLevelTable EntityMCharacterBoardAbilityMaxLevelTable { get; private set; }
        // 0x418
        public EntityMCharacterBoardAssignmentTable EntityMCharacterBoardAssignmentTable { get; private set; }
        // 0x420
        public EntityMCharacterBoardCategoryTable EntityMCharacterBoardCategoryTable { get; private set; }
        // 0x428
        public EntityMCharacterBoardCompleteRewardTable EntityMCharacterBoardCompleteRewardTable { get; private set; }
        // 0x430
        public EntityMCharacterBoardCompleteRewardGroupTable EntityMCharacterBoardCompleteRewardGroupTable { get; private set; }
        // 0x438
        public EntityMCharacterBoardConditionTable EntityMCharacterBoardConditionTable { get; private set; }
        // 0x440
        public EntityMCharacterBoardConditionDetailTable EntityMCharacterBoardConditionDetailTable { get; private set; }
        // 0x448
        public EntityMCharacterBoardConditionGroupTable EntityMCharacterBoardConditionGroupTable { get; private set; }
        // 0x450
        public EntityMCharacterBoardConditionIgnoreTable EntityMCharacterBoardConditionIgnoreTable { get; private set; }
        // 0x458
        public EntityMCharacterBoardEffectTargetGroupTable EntityMCharacterBoardEffectTargetGroupTable { get; private set; }
        // 0x460
        public EntityMCharacterBoardGroupTable EntityMCharacterBoardGroupTable { get; private set; }
        // 0x468
        public EntityMCharacterBoardPanelTable EntityMCharacterBoardPanelTable { get; private set; }
        // 0x470
        public EntityMCharacterBoardPanelReleaseEffectGroupTable EntityMCharacterBoardPanelReleaseEffectGroupTable { get; private set; }
        // 0x478
        public EntityMCharacterBoardPanelReleasePossessionGroupTable EntityMCharacterBoardPanelReleasePossessionGroupTable { get; private set; }
        // 0x480
        public EntityMCharacterBoardPanelReleaseRewardGroupTable EntityMCharacterBoardPanelReleaseRewardGroupTable { get; private set; }
        // 0x488
        public EntityMCharacterBoardStatusUpTable EntityMCharacterBoardStatusUpTable { get; private set; }
        // 0x490
        public EntityMCharacterDisplaySwitchTable EntityMCharacterDisplaySwitchTable { get; private set; }
        // 0x498
        public EntityMCharacterLevelBonusAbilityGroupTable EntityMCharacterLevelBonusAbilityGroupTable { get; private set; }

        // 0x4A0
        public EntityMCharacterRebirthTable EntityMCharacterRebirthTable { get; private set; }
        // 0x4A8
        public EntityMCharacterRebirthMaterialGroupTable EntityMCharacterRebirthMaterialGroupTable { get; private set; }
        // 0x4B0
        public EntityMCharacterRebirthStepGroupTable EntityMCharacterRebirthStepGroupTable { get; private set; }
        // 0x4B8
        public EntityMCharacterViewerActorIconTable EntityMCharacterViewerActorIconTable { get; private set; }
        // 0x4C0
        public EntityMCharacterViewerFieldTable EntityMCharacterViewerFieldTable { get; private set; }
        // 0x4C8
        public EntityMCharacterViewerFieldSettingsTable EntityMCharacterViewerFieldSettingsTable { get; private set; }
        // 0x4D0
        public EntityMCharacterVoiceUnlockConditionTable EntityMCharacterVoiceUnlockConditionTable { get; private set; }
        // 0x4D8
        public EntityMCollectionBonusEffectTable EntityMCollectionBonusEffectTable { get; private set; }
        // 0x4E0
        public EntityMCollectionBonusQuestAssignmentTable EntityMCollectionBonusQuestAssignmentTable { get; private set; }
        // 0x4E8
        public EntityMCollectionBonusQuestAssignmentGroupTable EntityMCollectionBonusQuestAssignmentGroupTable { get; private set; }
        // 0x4F0
        public EntityMComboCalculationSettingTable EntityMComboCalculationSettingTable { get; private set; }
        // 0x4F8
        public EntityMComebackCampaignTable EntityMComebackCampaignTable { get; private set; }
        // 0x500
        public EntityMCompanionTable EntityMCompanionTable { get; private set; }
        // 0x508
        public EntityMCompanionAbilityGroupTable EntityMCompanionAbilityGroupTable { get; private set; }
        // 0x510
        public EntityMCompanionAbilityLevelTable EntityMCompanionAbilityLevelTable { get; private set; }
        // 0x518
        public EntityMCompanionBaseStatusTable EntityMCompanionBaseStatusTable { get; private set; }
        // 0x520
        public EntityMCompanionCategoryTable EntityMCompanionCategoryTable { get; private set; }

        // 0x528
        public EntityMCompanionDuplicationExchangePossessionGroupTable EntityMCompanionDuplicationExchangePossessionGroupTable { get; private set; }
        // 0x558
        public EntityMConfigTable EntityMConfigTable { get; private set; }

        // 0x530
        public EntityMCompanionEnhancedTable EntityMCompanionEnhancedTable { get; private set; }

        // 0x538
        public EntityMCompanionEnhancementMaterialTable EntityMCompanionEnhancementMaterialTable { get; private set; }
        // 0x540
        public EntityMCompanionSkillLevelTable EntityMCompanionSkillLevelTable { get; private set; }
        // 0x548
        public EntityMCompanionStatusCalculationTable EntityMCompanionStatusCalculationTable { get; private set; }

        // 0x550
        public EntityMCompleteMissionGroupTable EntityMCompleteMissionGroupTable { get; private set; }
        // 0x560
        public EntityMConsumableItemTable EntityMConsumableItemTable { get; private set; }
        // 0x568
        public EntityMConsumableItemEffectTable EntityMConsumableItemEffectTable { get; private set; }
        // 0x570
        public EntityMConsumableItemTermTable EntityMConsumableItemTermTable { get; private set; }

        // 0x578
        public EntityMContentsStoryTable EntityMContentsStoryTable { get; private set; }
        // 0x580
        public EntityMCostumeTable EntityMCostumeTable { get; private set; }
        // 0x588
        public EntityMCostumeAbilityGroupTable EntityMCostumeAbilityGroupTable { get; private set; }
        // 0x590
        public EntityMCostumeAbilityLevelGroupTable EntityMCostumeAbilityLevelGroupTable { get; private set; }

        // 0x598
        public EntityMCostumeActiveSkillEnhancementMaterialTable EntityMCostumeActiveSkillEnhancementMaterialTable { get; private set; }
        // 0x5A0
        public EntityMCostumeActiveSkillGroupTable EntityMCostumeActiveSkillGroupTable { get; private set; }

        // 0x5A8
        public EntityMCostumeAnimationStepTable EntityMCostumeAnimationStepTable { get; private set; }
        // 0x5B0
        public EntityMCostumeAwakenTable EntityMCostumeAwakenTable { get; private set; }

        // 0x5B8
        public EntityMCostumeAwakenAbilityTable EntityMCostumeAwakenAbilityTable { get; private set; }
        // 0x5C0
        public EntityMCostumeAwakenEffectGroupTable EntityMCostumeAwakenEffectGroupTable { get; private set; }
        // 0x5C8
        public EntityMCostumeAwakenItemAcquireTable EntityMCostumeAwakenItemAcquireTable { get; private set; }
        // 0x5D0
        public EntityMCostumeAwakenMaterialGroupTable EntityMCostumeAwakenMaterialGroupTable { get; private set; }
        // 0x5D8
        public EntityMCostumeAwakenPriceGroupTable EntityMCostumeAwakenPriceGroupTable { get; private set; }
        // 0x5E0
        public EntityMCostumeAwakenStatusUpGroupTable EntityMCostumeAwakenStatusUpGroupTable { get; private set; }
        // 0x5E8
        public EntityMCostumeAwakenStepMaterialGroupTable EntityMCostumeAwakenStepMaterialGroupTable { get; private set; }
        // 0x5F0
        public EntityMCostumeBaseStatusTable EntityMCostumeBaseStatusTable { get; private set; }

        // 0x5F8
        public EntityMCostumeCollectionBonusTable EntityMCostumeCollectionBonusTable { get; private set; }
        // 0x600
        public EntityMCostumeCollectionBonusGroupTable EntityMCostumeCollectionBonusGroupTable { get; private set; }
        // 0x608
        public EntityMCostumeDefaultSkillGroupTable EntityMCostumeDefaultSkillGroupTable { get; private set; }
        // 0x610
        public EntityMCostumeDefaultSkillLotteryGroupTable EntityMCostumeDefaultSkillLotteryGroupTable { get; private set; }
        // 0x618
        public EntityMCostumeDisplayCoordinateAdjustmentTable EntityMCostumeDisplayCoordinateAdjustmentTable { get; private set; }
        // 0x620
        public EntityMCostumeDuplicationExchangePossessionGroupTable EntityMCostumeDuplicationExchangePossessionGroupTable { get; private set; }
        // 0x628
        public EntityMCostumeEmblemTable EntityMCostumeEmblemTable { get; private set; }
        // 0x630
        public EntityMCostumeEnhancedTable EntityMCostumeEnhancedTable { get; private set; }

        // 0x638
        public EntityMCostumeLevelBonusTable EntityMCostumeLevelBonusTable { get; private set; }
        // 0x640
        public EntityMCostumeLimitBreakMaterialGroupTable EntityMCostumeLimitBreakMaterialGroupTable { get; private set; }
        // 0x648
        public EntityMCostumeLimitBreakMaterialRarityGroupTable EntityMCostumeLimitBreakMaterialRarityGroupTable { get; private set; }
        // 0x650
        public EntityMCostumeOverflowExchangePossessionGroupTable EntityMCostumeOverflowExchangePossessionGroupTable { get; private set; }
        // 0x658
        public EntityMCostumeRarityTable EntityMCostumeRarityTable { get; private set; }

        // 0x660
        public EntityMCostumeSpecialActActiveSkillTable EntityMCostumeSpecialActActiveSkillTable { get; private set; }
        // 0x668
        public EntityMCostumeSpecialActActiveSkillConditionAttributeTable EntityMCostumeSpecialActActiveSkillConditionAttributeTable { get; private set; }
        // 0x670
        public EntityMCostumeStatusCalculationTable EntityMCostumeStatusCalculationTable { get; private set; }

        // 0x678
        public EntityMDeckEntrustCoefficientAttributeTable EntityMDeckEntrustCoefficientAttributeTable { get; private set; }
        // 0x680
        public EntityMDeckEntrustCoefficientPartsSeriesBonusCountTable EntityMDeckEntrustCoefficientPartsSeriesBonusCountTable { get; private set; }
        // 0x688
        public EntityMDeckEntrustCoefficientStatusTable EntityMDeckEntrustCoefficientStatusTable { get; private set; }
        // 0x690
        public EntityMDokanTable EntityMDokanTable { get; private set; }
        // 0x698
        public EntityMDokanContentGroupTable EntityMDokanContentGroupTable { get; private set; }
        // 0x6A0
        public EntityMDokanTextTable EntityMDokanTextTable { get; private set; }
        // 0x6A8
        public EntityMEnhanceCampaignTable EntityMEnhanceCampaignTable { get; private set; }
        // 0x6B0
        public EntityMEnhanceCampaignTargetGroupTable EntityMEnhanceCampaignTargetGroupTable { get; private set; }
        // 0x6B8
        public EntityMEvaluateConditionTable EntityMEvaluateConditionTable { get; private set; }
        // 0x6C0
        public EntityMEvaluateConditionValueGroupTable EntityMEvaluateConditionValueGroupTable { get; private set; }
        // 0x6C8
        public EntityMEventQuestChapterTable EntityMEventQuestChapterTable { get; private set; }
        // 0x6D0
        public EntityMEventQuestChapterCharacterTable EntityMEventQuestChapterCharacterTable { get; private set; }

        // 0x6D8
        public EntityMEventQuestChapterDifficultyLimitContentUnlockTable EntityMEventQuestChapterDifficultyLimitContentUnlockTable { get; private set; }
        // 0x6E0
        public EntityMEventQuestChapterLimitContentRelationTable EntityMEventQuestChapterLimitContentRelationTable { get; private set; }
        // 0x6E8
        public EntityMEventQuestDailyGroupTable EntityMEventQuestDailyGroupTable { get; private set; }
        // 0x6F0
        public EntityMEventQuestDailyGroupCompleteRewardTable EntityMEventQuestDailyGroupCompleteRewardTable { get; private set; }
        // 0x6F8
        public EntityMEventQuestDailyGroupMessageTable EntityMEventQuestDailyGroupMessageTable { get; private set; }
        // 0x700
        public EntityMEventQuestDailyGroupTargetChapterTable EntityMEventQuestDailyGroupTargetChapterTable { get; private set; }
        // 0x708
        public EntityMEventQuestDisplayItemGroupTable EntityMEventQuestDisplayItemGroupTable { get; private set; }
        // 0x710
        public EntityMEventQuestGuerrillaFreeOpenTable EntityMEventQuestGuerrillaFreeOpenTable { get; private set; }

        // 0x718
        public EntityMEventQuestGuerrillaFreeOpenScheduleCorrespondenceTable EntityMEventQuestGuerrillaFreeOpenScheduleCorrespondenceTable { get; private set; }
        // 0x720
        public EntityMEventQuestLabyrinthMobTable EntityMEventQuestLabyrinthMobTable { get; private set; }
        // 0x728
        public EntityMEventQuestLabyrinthQuestDisplayTable EntityMEventQuestLabyrinthQuestDisplayTable { get; private set; }
        // 0x730
        public EntityMEventQuestLabyrinthQuestEffectDescriptionAbilityTable EntityMEventQuestLabyrinthQuestEffectDescriptionAbilityTable { get; private set; }
        // 0x738
        public EntityMEventQuestLabyrinthQuestEffectDescriptionFreeTable EntityMEventQuestLabyrinthQuestEffectDescriptionFreeTable { get; private set; }
        // 0x740
        public EntityMEventQuestLabyrinthQuestEffectDisplayTable EntityMEventQuestLabyrinthQuestEffectDisplayTable { get; private set; }
        // 0x748
        public EntityMEventQuestLabyrinthRewardGroupTable EntityMEventQuestLabyrinthRewardGroupTable { get; private set; }
        // 0x750
        public EntityMEventQuestLabyrinthSeasonTable EntityMEventQuestLabyrinthSeasonTable { get; private set; }
        // 0x758
        public EntityMEventQuestLabyrinthSeasonRewardGroupTable EntityMEventQuestLabyrinthSeasonRewardGroupTable { get; private set; }
        // 0x760
        public EntityMEventQuestLabyrinthStageTable EntityMEventQuestLabyrinthStageTable { get; private set; }
        // 0x768
        public EntityMEventQuestLabyrinthStageAccumulationRewardGroupTable EntityMEventQuestLabyrinthStageAccumulationRewardGroupTable { get; private set; }
        // 0x770
        public EntityMEventQuestLimitContentTable EntityMEventQuestLimitContentTable { get; private set; }
        // 0x778
        public EntityMEventQuestLinkTable EntityMEventQuestLinkTable { get; private set; }
        // 0x780
        public EntityMEventQuestSequenceTable EntityMEventQuestSequenceTable { get; private set; }
        // 0x788
        public EntityMEventQuestSequenceGroupTable EntityMEventQuestSequenceGroupTable { get; private set; }

        // 0x790
        public EntityMEventQuestTowerAccumulationRewardTable EntityMEventQuestTowerAccumulationRewardTable { get; private set; }
        // 0x798
        public EntityMEventQuestTowerAccumulationRewardGroupTable EntityMEventQuestTowerAccumulationRewardGroupTable { get; private set; }
        // 0x7A0
        public EntityMEventQuestTowerAssetTable EntityMEventQuestTowerAssetTable { get; private set; }
        // 0x7A8
        public EntityMEventQuestTowerRewardGroupTable EntityMEventQuestTowerRewardGroupTable { get; private set; }
        // 0x7B0
        public EntityMEventQuestUnlockConditionTable EntityMEventQuestUnlockConditionTable { get; private set; }
        // 0x7B8
        public EntityMExploreTable EntityMExploreTable { get; private set; }
        // 0x7C0
        public EntityMExploreGradeAssetTable EntityMExploreGradeAssetTable { get; private set; }
        // 0x7C8
        public EntityMExploreGradeScoreTable EntityMExploreGradeScoreTable { get; private set; }
        // 0x7D0
        public EntityMExploreGroupTable EntityMExploreGroupTable { get; private set; }
        // 0x7D8
        public EntityMExploreUnlockConditionTable EntityMExploreUnlockConditionTable { get; private set; }
        // 0x7E0
        public EntityMExtraQuestGroupTable EntityMExtraQuestGroupTable { get; private set; }
        // 0x7E8
        public EntityMExtraQuestGroupInMainQuestChapterTable EntityMExtraQuestGroupInMainQuestChapterTable { get; private set; }
        // 0x7F0
        public EntityMFieldEffectBlessRelationTable EntityMFieldEffectBlessRelationTable { get; private set; }
        // 0x7F8
        public EntityMFieldEffectDecreasePointTable EntityMFieldEffectDecreasePointTable { get; private set; }
        // 0x800
        public EntityMFieldEffectGroupTable EntityMFieldEffectGroupTable { get; private set; }
        // 0x808
        public EntityMGachaMedalTable EntityMGachaMedalTable { get; private set; }
        // 0x810
        public EntityMGiftTextTable EntityMGiftTextTable { get; private set; }
        // 0x818
        public EntityMGimmickTable EntityMGimmickTable { get; private set; }
        // 0x820
        public EntityMGimmickAdditionalAssetTable EntityMGimmickAdditionalAssetTable { get; private set; }
        // 0x828
        public EntityMGimmickExtraQuestTable EntityMGimmickExtraQuestTable { get; private set; }
        // 0x830
        public EntityMGimmickGroupTable EntityMGimmickGroupTable { get; private set; }
        // 0x838
        public EntityMGimmickGroupEventLogTable EntityMGimmickGroupEventLogTable { get; private set; }
        // 0x840
        public EntityMGimmickIntervalTable EntityMGimmickIntervalTable { get; private set; }
        // 0x848
        public EntityMGimmickOrnamentTable EntityMGimmickOrnamentTable { get; private set; }
        // 0x850
        public EntityMGimmickSequenceTable EntityMGimmickSequenceTable { get; private set; }
        // 0x858
        public EntityMGimmickSequenceGroupTable EntityMGimmickSequenceGroupTable { get; private set; }
        // 0x860
        public EntityMGimmickSequenceRewardGroupTable EntityMGimmickSequenceRewardGroupTable { get; private set; }
        // 0x868
        public EntityMGimmickSequenceScheduleTable EntityMGimmickSequenceScheduleTable { get; private set; }
        // 0x870
        public EntityMHeadupDisplayViewTable EntityMHeadupDisplayViewTable { get; private set; }
        // 0x878
        public EntityMHelpTable EntityMHelpTable { get; private set; }
        // 0x880
        public EntityMHelpCategoryTable EntityMHelpCategoryTable { get; private set; }
        // 0x888
        public EntityMHelpItemTable EntityMHelpItemTable { get; private set; }
        // 0x890
        public EntityMHelpPageGroupTable EntityMHelpPageGroupTable { get; private set; }
        // 0x898
        public EntityMImportantItemTable EntityMImportantItemTable { get; private set; }

        // 0x8A0
        public EntityMImportantItemEffectTable EntityMImportantItemEffectTable { get; private set; }
        // 0x8A8
        public EntityMImportantItemEffectDropCountTable EntityMImportantItemEffectDropCountTable { get; private set; }
        // 0x8B0
        public EntityMImportantItemEffectDropRateTable EntityMImportantItemEffectDropRateTable { get; private set; }
        // 0x8B8
        public EntityMImportantItemEffectTargetItemGroupTable EntityMImportantItemEffectTargetItemGroupTable { get; private set; }
        // 0x8C0
        public EntityMImportantItemEffectTargetQuestGroupTable EntityMImportantItemEffectTargetQuestGroupTable { get; private set; }
        // 0x8C8
        public EntityMImportantItemEffectUnlockFunctionTable EntityMImportantItemEffectUnlockFunctionTable { get; private set; }
        // 0x8D0
        public EntityMLibraryEventQuestStoryGroupingTable EntityMLibraryEventQuestStoryGroupingTable { get; private set; }
        // 0x8D8
        public EntityMLibraryMainQuestGroupTable EntityMLibraryMainQuestGroupTable { get; private set; }
        // 0x8E0
        public EntityMLibraryMainQuestStoryTable EntityMLibraryMainQuestStoryTable { get; private set; }
        // 0x8E8
        public EntityMLibraryMovieTable EntityMLibraryMovieTable { get; private set; }
        // 0x8F0
        public EntityMLibraryMovieCategoryTable EntityMLibraryMovieCategoryTable { get; private set; }
        // 0x8F8
        public EntityMLibraryMovieUnlockConditionTable EntityMLibraryMovieUnlockConditionTable { get; private set; }
        // 0x900
        public EntityMLibraryRecordGroupingTable EntityMLibraryRecordGroupingTable { get; private set; }
        // 0x908
        public EntityMLimitedOpenTextTable EntityMLimitedOpenTextTable { get; private set; }
        // 0x910
        public EntityMLimitedOpenTextGroupTable EntityMLimitedOpenTextGroupTable { get; private set; }
        // 0x918
        public EntityMListSettingAbilityGroupTable EntityMListSettingAbilityGroupTable { get; private set; }
        // 0x920
        public EntityMListSettingAbilityGroupTargetTable EntityMListSettingAbilityGroupTargetTable { get; private set; }
        // 0x928
        public EntityMLoginBonusTable EntityMLoginBonusTable { get; private set; }
        // 0x930
        public EntityMLoginBonusStampTable EntityMLoginBonusStampTable { get; private set; }
        // 0x938
        public EntityMMainQuestChapterTable EntityMMainQuestChapterTable { get; private set; }

        // 0x940
        public EntityMMainQuestPortalCageCharacterTable EntityMMainQuestPortalCageCharacterTable { get; private set; }
        // 0x948
        public EntityMMainQuestRouteTable EntityMMainQuestRouteTable { get; private set; }
        // 0x950
        public EntityMMainQuestSeasonTable EntityMMainQuestSeasonTable { get; private set; }
        // 0x958
        public EntityMMainQuestSequenceTable EntityMMainQuestSequenceTable { get; private set; }
        // 0x960
        public EntityMMainQuestSequenceGroupTable EntityMMainQuestSequenceGroupTable { get; private set; }

        // 0x968
        public EntityMMaintenanceTable EntityMMaintenanceTable { get; private set; }
        // 0x970
        public EntityMMaintenanceGroupTable EntityMMaintenanceGroupTable { get; private set; }
        // 0x978
        public EntityMMaterialTable EntityMMaterialTable { get; private set; }

        // 0x980
        public EntityMMaterialSaleObtainPossessionTable EntityMMaterialSaleObtainPossessionTable { get; private set; }
        // 0x988
        public EntityMMissionTable EntityMMissionTable { get; private set; }
        // 0x990
        public EntityMMissionClearConditionValueViewTable EntityMMissionClearConditionValueViewTable { get; private set; }
        // 0x998
        public EntityMMissionGroupTable EntityMMissionGroupTable { get; private set; }
        // 0x9A0
        public EntityMMissionLinkTable EntityMMissionLinkTable { get; private set; }
        // 0x9A8
        public EntityMMissionRewardTable EntityMMissionRewardTable { get; private set; }
        // 0x9B0
        public EntityMMissionSubCategoryTextTable EntityMMissionSubCategoryTextTable { get; private set; }
        // 0x9B8
        public EntityMMissionTermTable EntityMMissionTermTable { get; private set; }
        // 0x9C0
        public EntityMMissionUnlockConditionTable EntityMMissionUnlockConditionTable { get; private set; }
        // 0x9C8
        public EntityMMomBannerTable EntityMMomBannerTable { get; private set; }
        // 0x9D0
        public EntityMMomPointBannerTable EntityMMomPointBannerTable { get; private set; }
        // 0x9D8
        public EntityMMovieTable EntityMMovieTable { get; private set; }
        // 0x9E0
        public EntityMNaviCutInTable EntityMNaviCutInTable { get; private set; }
        // 0x9E8
        public EntityMNaviCutInContentGroupTable EntityMNaviCutInContentGroupTable { get; private set; }
        // 0x9F0
        public EntityMNaviCutInTextTable EntityMNaviCutInTextTable { get; private set; }
        // 0x9F8
        public EntityMNumericalFunctionTable EntityMNumericalFunctionTable { get; private set; }
        // 0xA00
        public EntityMNumericalFunctionParameterGroupTable EntityMNumericalFunctionParameterGroupTable { get; private set; }

        // 0xA08
        public EntityMNumericalParameterMapTable EntityMNumericalParameterMapTable { get; private set; }
        // 0xA10
        public EntityMOmikujiTable EntityMOmikujiTable { get; private set; }
        // 0xA18
        public EntityMOverrideHitEffectConditionCriticalTable EntityMOverrideHitEffectConditionCriticalTable { get; private set; }
        // 0xA20
        public EntityMOverrideHitEffectConditionDamageAttributeTable EntityMOverrideHitEffectConditionDamageAttributeTable { get; private set; }
        // 0xA28
        public EntityMOverrideHitEffectConditionGroupTable EntityMOverrideHitEffectConditionGroupTable { get; private set; }
        // 0xA30
        public EntityMOverrideHitEffectConditionSkillExecutorTable EntityMOverrideHitEffectConditionSkillExecutorTable { get; private set; }
        // 0xA38
        public EntityMPartsTable EntityMPartsTable { get; private set; }
        // 0xA40
        public EntityMPartsEnhancedTable EntityMPartsEnhancedTable { get; private set; }

        // 0xA48
        public EntityMPartsEnhancedSubStatusTable EntityMPartsEnhancedSubStatusTable { get; private set; }
        // 0xA50
        public EntityMPartsGroupTable EntityMPartsGroupTable { get; private set; }

        // 0xA58
        public EntityMPartsLevelUpPriceGroupTable EntityMPartsLevelUpPriceGroupTable { get; private set; }
        // 0xA60
        public EntityMPartsLevelUpRateGroupTable EntityMPartsLevelUpRateGroupTable { get; private set; }
        // 0xA68
        public EntityMPartsRarityTable EntityMPartsRarityTable { get; private set; }
        // 0xA70
        public EntityMPartsSeriesTable EntityMPartsSeriesTable { get; private set; }
        // 0xA78
        public EntityMPartsSeriesBonusAbilityGroupTable EntityMPartsSeriesBonusAbilityGroupTable { get; private set; }
        // 0xA80
        public EntityMPartsStatusMainTable EntityMPartsStatusMainTable { get; private set; }
        // 0xA88
        public EntityMPlatformPaymentTable EntityMPlatformPaymentTable { get; private set; }

        // 0xA90
        public EntityMPlatformPaymentPriceTable EntityMPlatformPaymentPriceTable { get; private set; }
        // 0xA98
        public EntityMPortalCageAccessPointFunctionGroupTable EntityMPortalCageAccessPointFunctionGroupTable { get; private set; }
        // 0xAA0
        public EntityMPortalCageAccessPointFunctionGroupScheduleTable EntityMPortalCageAccessPointFunctionGroupScheduleTable { get; private set; }
        // 0xAA8
        public EntityMPortalCageCharacterGroupTable EntityMPortalCageCharacterGroupTable { get; private set; }
        // 0xAB0
        public EntityMPortalCageGateTable EntityMPortalCageGateTable { get; private set; }
        // 0xAB8
        public EntityMPortalCageSceneTable EntityMPortalCageSceneTable { get; private set; }
        // 0xAC0
        public EntityMPossessionAcquisitionRouteTable EntityMPossessionAcquisitionRouteTable { get; private set; }
        // 0xAC8
        public EntityMPowerCalculationConstantValueTable EntityMPowerCalculationConstantValueTable { get; private set; }
        // 0xAD0
        public EntityMPowerReferenceStatusGroupTable EntityMPowerReferenceStatusGroupTable { get; private set; }

        // 0xAD8
        public EntityMPvpBackgroundTable EntityMPvpBackgroundTable { get; private set; }
        // 0xAE0
        public EntityMPvpGradeTable EntityMPvpGradeTable { get; private set; }
        // 0xAE8
        public EntityMPvpGradeGroupTable EntityMPvpGradeGroupTable { get; private set; }
        // 0xAF0
        public EntityMPvpGradeOneMatchRewardTable EntityMPvpGradeOneMatchRewardTable { get; private set; }
        // 0xAF8
        public EntityMPvpGradeOneMatchRewardGroupTable EntityMPvpGradeOneMatchRewardGroupTable { get; private set; }
        // 0xB00
        public EntityMPvpGradeWeeklyRewardGroupTable EntityMPvpGradeWeeklyRewardGroupTable { get; private set; }
        // 0xB08
        public EntityMPvpRewardTable EntityMPvpRewardTable { get; private set; }
        // 0xB10
        public EntityMPvpSeasonTable EntityMPvpSeasonTable { get; private set; }
        // 0xB18
        public EntityMPvpSeasonGradeTable EntityMPvpSeasonGradeTable { get; private set; }
        // 0xB20
        public EntityMPvpSeasonGroupingTable EntityMPvpSeasonGroupingTable { get; private set; }
        // 0xB28
        public EntityMPvpSeasonRankRewardTable EntityMPvpSeasonRankRewardTable { get; private set; }
        // 0xB30
        public EntityMPvpSeasonRankRewardGroupTable EntityMPvpSeasonRankRewardGroupTable { get; private set; }
        // 0xB38
        public EntityMPvpSeasonRankRewardPerSeasonTable EntityMPvpSeasonRankRewardPerSeasonTable { get; private set; }
        // 0xB40
        public EntityMPvpSeasonRankRewardRankGroupTable EntityMPvpSeasonRankRewardRankGroupTable { get; private set; }
        // 0xB48
        public EntityMPvpWeeklyRankRewardGroupTable EntityMPvpWeeklyRankRewardGroupTable { get; private set; }
        // 0xB50
        public EntityMPvpWeeklyRankRewardRankGroupTable EntityMPvpWeeklyRankRewardRankGroupTable { get; private set; }
        // 0xB58
        public EntityMPvpWinStreakCountEffectTable EntityMPvpWinStreakCountEffectTable { get; private set; }
        // 0xB60
        public EntityMQuestTable EntityMQuestTable { get; private set; }
        // 0xB68
        public EntityMQuestBonusTable EntityMQuestBonusTable { get; private set; }

        // 0xB70
        public EntityMQuestBonusAbilityTable EntityMQuestBonusAbilityTable { get; private set; }
        // 0xB78
        public EntityMQuestBonusAllyCharacterTable EntityMQuestBonusAllyCharacterTable { get; private set; }
        // 0xB80
        public EntityMQuestBonusCharacterGroupTable EntityMQuestBonusCharacterGroupTable { get; private set; }

        // 0xB88
        public EntityMQuestBonusCostumeGroupTable EntityMQuestBonusCostumeGroupTable { get; private set; }
        // 0xB90
        public EntityMQuestBonusCostumeSettingGroupTable EntityMQuestBonusCostumeSettingGroupTable { get; private set; }

        // 0xB98
        public EntityMQuestBonusDropRewardTable EntityMQuestBonusDropRewardTable { get; private set; }
        // 0xBA0
        public EntityMQuestBonusEffectGroupTable EntityMQuestBonusEffectGroupTable { get; private set; }
        // 0xBA8
        public EntityMQuestBonusExpTable EntityMQuestBonusExpTable { get; private set; }
        // 0xBB0
        public EntityMQuestBonusTermGroupTable EntityMQuestBonusTermGroupTable { get; private set; }
        // 0xBB8
        public EntityMQuestBonusWeaponGroupTable EntityMQuestBonusWeaponGroupTable { get; private set; }

        // 0xBC0
        public EntityMQuestCampaignTable EntityMQuestCampaignTable { get; private set; }
        // 0xBC8
        public EntityMQuestCampaignEffectGroupTable EntityMQuestCampaignEffectGroupTable { get; private set; }
        // 0xBD0
        public EntityMQuestCampaignTargetGroupTable EntityMQuestCampaignTargetGroupTable { get; private set; }

        // 0xBD8
        public EntityMQuestCampaignTargetItemGroupTable EntityMQuestCampaignTargetItemGroupTable { get; private set; }
        // 0xBE0
        public EntityMQuestDeckRestrictionGroupTable EntityMQuestDeckRestrictionGroupTable { get; private set; }
        // 0xBE8
        public EntityMQuestDeckRestrictionGroupUnlockTable EntityMQuestDeckRestrictionGroupUnlockTable { get; private set; }
        // 0xBF0
        public EntityMQuestDisplayAttributeGroupTable EntityMQuestDisplayAttributeGroupTable { get; private set; }
        // 0xBF8
        public EntityMQuestFirstClearRewardGroupTable EntityMQuestFirstClearRewardGroupTable { get; private set; }
        // 0xC00
        public EntityMQuestMissionTable EntityMQuestMissionTable { get; private set; }
        // 0xC08
        public EntityMQuestMissionConditionValueGroupTable EntityMQuestMissionConditionValueGroupTable { get; private set; }
        // 0xC10
        public EntityMQuestMissionGroupTable EntityMQuestMissionGroupTable { get; private set; }

        // 0xC18
        public EntityMQuestMissionRewardTable EntityMQuestMissionRewardTable { get; private set; }
        // 0xC20
        public EntityMQuestPickupRewardGroupTable EntityMQuestPickupRewardGroupTable { get; private set; }
        // 0xC28
        public EntityMQuestRelationMainFlowTable EntityMQuestRelationMainFlowTable { get; private set; }
        // 0xC30
        public EntityMQuestReleaseConditionBigHuntScoreTable EntityMQuestReleaseConditionBigHuntScoreTable { get; private set; }
        // 0xC38
        public EntityMQuestReleaseConditionCharacterLevelTable EntityMQuestReleaseConditionCharacterLevelTable { get; private set; }
        // 0xC40
        public EntityMQuestReleaseConditionDeckPowerTable EntityMQuestReleaseConditionDeckPowerTable { get; private set; }
        // 0xC48
        public EntityMQuestReleaseConditionGroupTable EntityMQuestReleaseConditionGroupTable { get; private set; }
        // 0xC50
        public EntityMQuestReleaseConditionListTable EntityMQuestReleaseConditionListTable { get; private set; }
        // 0xC58
        public EntityMQuestReleaseConditionQuestChallengeTable EntityMQuestReleaseConditionQuestChallengeTable { get; private set; }
        // 0xC60
        public EntityMQuestReleaseConditionQuestClearTable EntityMQuestReleaseConditionQuestClearTable { get; private set; }
        // 0xC68
        public EntityMQuestReleaseConditionUserLevelTable EntityMQuestReleaseConditionUserLevelTable { get; private set; }
        // 0xC70
        public EntityMQuestReleaseConditionWeaponAcquisitionTable EntityMQuestReleaseConditionWeaponAcquisitionTable { get; private set; }

        // 0xC78
        public EntityMQuestReplayFlowRewardGroupTable EntityMQuestReplayFlowRewardGroupTable { get; private set; }
        // 0xC80
        public EntityMQuestSceneTable EntityMQuestSceneTable { get; private set; }
        // 0xC88
        public EntityMQuestSceneBattleTable EntityMQuestSceneBattleTable { get; private set; }

        // 0xC90
        public EntityMQuestSceneChoiceTable EntityMQuestSceneChoiceTable { get; private set; }
        // 0xC98
        public EntityMQuestSceneChoiceCostumeEffectGroupTable EntityMQuestSceneChoiceCostumeEffectGroupTable { get; private set; }
        // 0xCA0
        public EntityMQuestSceneChoiceEffectTable EntityMQuestSceneChoiceEffectTable { get; private set; }
        // 0xCA8
        public EntityMQuestSceneChoiceWeaponEffectGroupTable EntityMQuestSceneChoiceWeaponEffectGroupTable { get; private set; }
        // 0xCB0
        public EntityMQuestSceneNotConfirmTitleDialogTable EntityMQuestSceneNotConfirmTitleDialogTable { get; private set; }
        // 0xCB8
        public EntityMQuestSceneOutgameBlendshapeMotionTable EntityMQuestSceneOutgameBlendshapeMotionTable { get; private set; }
        // 0xCC0
        public EntityMQuestScheduleTable EntityMQuestScheduleTable { get; private set; }
        // 0xCC8
        public EntityMQuestScheduleCorrespondenceTable EntityMQuestScheduleCorrespondenceTable { get; private set; }

        // 0xCD0
        public EntityMReportTable EntityMReportTable { get; private set; }
        // 0xCD8
        public EntityMShopTable EntityMShopTable { get; private set; }

        // 0xCE0
        public EntityMShopDisplayPriceTable EntityMShopDisplayPriceTable { get; private set; }
        // 0xCE8
        public EntityMShopItemTable EntityMShopItemTable { get; private set; }

        // 0xCF0
        public EntityMShopItemAdditionalContentTable EntityMShopItemAdditionalContentTable { get; private set; }
        // 0xCF8
        public EntityMShopItemCellTable EntityMShopItemCellTable { get; private set; }
        // 0xD00
        public EntityMShopItemCellGroupTable EntityMShopItemCellGroupTable { get; private set; }

        // 0xD08
        public EntityMShopItemCellLimitedOpenTable EntityMShopItemCellLimitedOpenTable { get; private set; }
        // 0xD10
        public EntityMShopItemCellTermTable EntityMShopItemCellTermTable { get; private set; }

        // 0xD18
        public EntityMShopItemContentEffectTable EntityMShopItemContentEffectTable { get; private set; }
        // 0xD20
        public EntityMShopItemContentMissionTable EntityMShopItemContentMissionTable { get; private set; }
        // 0xD28
        public EntityMShopItemContentPossessionTable EntityMShopItemContentPossessionTable { get; private set; }
        // 0xD30
        public EntityMShopItemLimitedStockTable EntityMShopItemLimitedStockTable { get; private set; }

        // 0xD38
        public EntityMShopItemUserLevelConditionTable EntityMShopItemUserLevelConditionTable { get; private set; }
        // 0xD40
        public EntityMShopReplaceableGemTable EntityMShopReplaceableGemTable { get; private set; }
        // 0xD48
        public EntityMSideStoryQuestTable EntityMSideStoryQuestTable { get; private set; }
        // 0xD50
        public EntityMSideStoryQuestLimitContentTable EntityMSideStoryQuestLimitContentTable { get; private set; }
        // 0xD58
        public EntityMSideStoryQuestSceneTable EntityMSideStoryQuestSceneTable { get; private set; }
        // 0xD60
        public EntityMSkillTable EntityMSkillTable { get; private set; }

        // 0xD68
        public EntityMSkillAbnormalTable EntityMSkillAbnormalTable { get; private set; }
        // 0xD70
        public EntityMSkillAbnormalBehaviourTable EntityMSkillAbnormalBehaviourTable { get; private set; }
        // 0xD78
        public EntityMSkillAbnormalBehaviourActionAbnormalResistanceTable EntityMSkillAbnormalBehaviourActionAbnormalResistanceTable { get; private set; }
        // 0xD80
        public EntityMSkillAbnormalBehaviourActionAttributeDamageCorrectionTable EntityMSkillAbnormalBehaviourActionAttributeDamageCorrectionTable { get; private set; }
        // 0xD88
        public EntityMSkillAbnormalBehaviourActionBuffResistanceTable EntityMSkillAbnormalBehaviourActionBuffResistanceTable { get; private set; }
        // 0xD90
        public EntityMSkillAbnormalBehaviourActionDamageTable EntityMSkillAbnormalBehaviourActionDamageTable { get; private set; }
        // 0xD98
        public EntityMSkillAbnormalBehaviourActionDamageMultiplyTable EntityMSkillAbnormalBehaviourActionDamageMultiplyTable { get; private set; }
        // 0xDA0
        public EntityMSkillAbnormalBehaviourActionDamageMultiplyDetailAlwaysTable EntityMSkillAbnormalBehaviourActionDamageMultiplyDetailAlwaysTable { get; private set; }
        // 0xDA8
        public EntityMSkillAbnormalBehaviourActionDefaultSkillLotteryTable EntityMSkillAbnormalBehaviourActionDefaultSkillLotteryTable { get; private set; }
        // 0xDB0
        public EntityMSkillAbnormalBehaviourActionHitRatioDownTable EntityMSkillAbnormalBehaviourActionHitRatioDownTable { get; private set; }
        // 0xDB8
        public EntityMSkillAbnormalBehaviourActionModifyHateValueTable EntityMSkillAbnormalBehaviourActionModifyHateValueTable { get; private set; }
        // 0xDC0
        public EntityMSkillAbnormalBehaviourActionOverrideHitEffectTable EntityMSkillAbnormalBehaviourActionOverrideHitEffectTable { get; private set; }
        // 0xDC8
        public EntityMSkillAbnormalBehaviourActionRecoveryTable EntityMSkillAbnormalBehaviourActionRecoveryTable { get; private set; }
        // 0xDD0
        public EntityMSkillAbnormalBehaviourActionTurnRestrictionTable EntityMSkillAbnormalBehaviourActionTurnRestrictionTable { get; private set; }
        // 0xDD8
        public EntityMSkillAbnormalBehaviourGroupTable EntityMSkillAbnormalBehaviourGroupTable { get; private set; }
        // 0xDE0
        public EntityMSkillAbnormalDamageMultiplyDetailAbnormalTable EntityMSkillAbnormalDamageMultiplyDetailAbnormalTable { get; private set; }
        // 0xDE8
        public EntityMSkillAbnormalDamageMultiplyDetailBuffAttachedTable EntityMSkillAbnormalDamageMultiplyDetailBuffAttachedTable { get; private set; }
        // 0xDF0
        public EntityMSkillAbnormalDamageMultiplyDetailCriticalTable EntityMSkillAbnormalDamageMultiplyDetailCriticalTable { get; private set; }
        // 0xDF8
        public EntityMSkillAbnormalDamageMultiplyDetailHitIndexTable EntityMSkillAbnormalDamageMultiplyDetailHitIndexTable { get; private set; }
        // 0xE00
        public EntityMSkillAbnormalDamageMultiplyDetailSkillfulWeaponTable EntityMSkillAbnormalDamageMultiplyDetailSkillfulWeaponTable { get; private set; }
        // 0xE08
        public EntityMSkillAbnormalLifetimeTable EntityMSkillAbnormalLifetimeTable { get; private set; }
        // 0xE10
        public EntityMSkillAbnormalLifetimeBehaviourActivateCountTable EntityMSkillAbnormalLifetimeBehaviourActivateCountTable { get; private set; }
        // 0xE18
        public EntityMSkillAbnormalLifetimeBehaviourFrameCountTable EntityMSkillAbnormalLifetimeBehaviourFrameCountTable { get; private set; }
        // 0xE20
        public EntityMSkillAbnormalLifetimeBehaviourGroupTable EntityMSkillAbnormalLifetimeBehaviourGroupTable { get; private set; }
        // 0xE28
        public EntityMSkillAbnormalLifetimeBehaviourReceiveDamageCountTable EntityMSkillAbnormalLifetimeBehaviourReceiveDamageCountTable { get; private set; }
        // 0xE30
        public EntityMSkillAbnormalLifetimeBehaviourTurnCountTable EntityMSkillAbnormalLifetimeBehaviourTurnCountTable { get; private set; }
        // 0xE38
        public EntityMSkillBehaviourTable EntityMSkillBehaviourTable { get; private set; }

        // 0xE40
        public EntityMSkillBehaviourActionAbnormalTable EntityMSkillBehaviourActionAbnormalTable { get; private set; }
        // 0xE48
        public EntityMSkillBehaviourActionActiveSkillDamageCorrectionTable EntityMSkillBehaviourActionActiveSkillDamageCorrectionTable { get; private set; }
        // 0xE50
        public EntityMSkillBehaviourActionAdvanceActiveSkillCooltimeTable EntityMSkillBehaviourActionAdvanceActiveSkillCooltimeTable { get; private set; }
        // 0xE58
        public EntityMSkillBehaviourActionAdvanceActiveSkillCooltimeImmediateTable EntityMSkillBehaviourActionAdvanceActiveSkillCooltimeImmediateTable { get; private set; }
        // 0xE60
        public EntityMSkillBehaviourActionAttackTable EntityMSkillBehaviourActionAttackTable { get; private set; }
        // 0xE68
        public EntityMSkillBehaviourActionAttackClampHpTable EntityMSkillBehaviourActionAttackClampHpTable { get; private set; }
        // 0xE70
        public EntityMSkillBehaviourActionAttackComboTable EntityMSkillBehaviourActionAttackComboTable { get; private set; }
        // 0xE78
        public EntityMSkillBehaviourActionAttackFixedDamageTable EntityMSkillBehaviourActionAttackFixedDamageTable { get; private set; }
        // 0xE80
        public EntityMSkillBehaviourActionAttackHpRatioTable EntityMSkillBehaviourActionAttackHpRatioTable { get; private set; }
        // 0xE88
        public EntityMSkillBehaviourActionAttackIgnoreVitalityTable EntityMSkillBehaviourActionAttackIgnoreVitalityTable { get; private set; }
        // 0xE90
        public EntityMSkillBehaviourActionAttackMainWeaponAttributeTable EntityMSkillBehaviourActionAttackMainWeaponAttributeTable { get; private set; }
        // 0xE98
        public EntityMSkillBehaviourActionAttackSkillfulMainWeaponTypeTable EntityMSkillBehaviourActionAttackSkillfulMainWeaponTypeTable { get; private set; }
        // 0xEA0
        public EntityMSkillBehaviourActionAttackVitalityTable EntityMSkillBehaviourActionAttackVitalityTable { get; private set; }
        // 0xEA8
        public EntityMSkillBehaviourActionAttributeDamageCorrectionTable EntityMSkillBehaviourActionAttributeDamageCorrectionTable { get; private set; }
        // 0xEB0
        public EntityMSkillBehaviourActionBuffTable EntityMSkillBehaviourActionBuffTable { get; private set; }
        // 0xEB8
        public EntityMSkillBehaviourActionChangestepTable EntityMSkillBehaviourActionChangestepTable { get; private set; }
        // 0xEC0
        public EntityMSkillBehaviourActionDamageCorrectionHpRatioTable EntityMSkillBehaviourActionDamageCorrectionHpRatioTable { get; private set; }
        // 0xEC8
        public EntityMSkillBehaviourActionDamageMultiplyTable EntityMSkillBehaviourActionDamageMultiplyTable { get; private set; }
        // 0xED0
        public EntityMSkillBehaviourActionDefaultSkillLotteryTable EntityMSkillBehaviourActionDefaultSkillLotteryTable { get; private set; }
        // 0xED8
        public EntityMSkillBehaviourActionHpRatioDamageTable EntityMSkillBehaviourActionHpRatioDamageTable { get; private set; }
        // 0xEE0
        public EntityMSkillBehaviourActionRecoveryTable EntityMSkillBehaviourActionRecoveryTable { get; private set; }
        // 0xEE8
        public EntityMSkillBehaviourActionRemoveAbnormalTable EntityMSkillBehaviourActionRemoveAbnormalTable { get; private set; }
        // 0xEF0
        public EntityMSkillBehaviourActionRemoveBuffTable EntityMSkillBehaviourActionRemoveBuffTable { get; private set; }
        // 0xEF8
        public EntityMSkillBehaviourActionShortenActiveSkillCooltimeTable EntityMSkillBehaviourActionShortenActiveSkillCooltimeTable { get; private set; }
        // 0xF00
        public EntityMSkillBehaviourActionSkillRecoveryPowerCorrectionTable EntityMSkillBehaviourActionSkillRecoveryPowerCorrectionTable { get; private set; }
        // 0xF08
        public EntityMSkillBehaviourActivationConditionActivationUpperCountTable EntityMSkillBehaviourActivationConditionActivationUpperCountTable { get; private set; }
        // 0xF10
        public EntityMSkillBehaviourActivationConditionAttributeTable EntityMSkillBehaviourActivationConditionAttributeTable { get; private set; }
        // 0xF18
        public EntityMSkillBehaviourActivationConditionGroupTable EntityMSkillBehaviourActivationConditionGroupTable { get; private set; }
        // 0xF20
        public EntityMSkillBehaviourActivationConditionHpRatioTable EntityMSkillBehaviourActivationConditionHpRatioTable { get; private set; }
        // 0xF28
        public EntityMSkillBehaviourActivationConditionInSkillFlowTable EntityMSkillBehaviourActivationConditionInSkillFlowTable { get; private set; }
        // 0xF30
        public EntityMSkillBehaviourActivationConditionWaveNumberTable EntityMSkillBehaviourActivationConditionWaveNumberTable { get; private set; }
        // 0xF38
        public EntityMSkillBehaviourActivationMethodTable EntityMSkillBehaviourActivationMethodTable { get; private set; }
        // 0xF40
        public EntityMSkillBehaviourGroupTable EntityMSkillBehaviourGroupTable { get; private set; }

        // 0xF48
        public EntityMSkillBuffTable EntityMSkillBuffTable { get; private set; }
        // 0xF50
        public EntityMSkillCasttimeTable EntityMSkillCasttimeTable { get; private set; }
        // 0xF58
        public EntityMSkillCasttimeBehaviourTable EntityMSkillCasttimeBehaviourTable { get; private set; }
        // 0xF60
        public EntityMSkillCasttimeBehaviourActionOnFrameUpdateTable EntityMSkillCasttimeBehaviourActionOnFrameUpdateTable { get; private set; }
        // 0xF68
        public EntityMSkillCasttimeBehaviourActionOnSkillDamageConditionTable EntityMSkillCasttimeBehaviourActionOnSkillDamageConditionTable { get; private set; }
        // 0xF70
        public EntityMSkillCasttimeBehaviourGroupTable EntityMSkillCasttimeBehaviourGroupTable { get; private set; }
        // 0xF78
        public EntityMSkillCooltimeAdvanceValueOnDefaultSkillGroupTable EntityMSkillCooltimeAdvanceValueOnDefaultSkillGroupTable { get; private set; }
        // 0xF80
        public EntityMSkillCooltimeBehaviourTable EntityMSkillCooltimeBehaviourTable { get; private set; }
        // 0xF88
        public EntityMSkillCooltimeBehaviourGroupTable EntityMSkillCooltimeBehaviourGroupTable { get; private set; }
        // 0xF90
        public EntityMSkillCooltimeBehaviourOnExecuteActiveSkillTable EntityMSkillCooltimeBehaviourOnExecuteActiveSkillTable { get; private set; }
        // 0xF98
        public EntityMSkillCooltimeBehaviourOnExecuteCompanionSkillTable EntityMSkillCooltimeBehaviourOnExecuteCompanionSkillTable { get; private set; }
        // 0xFA0
        public EntityMSkillCooltimeBehaviourOnExecuteDefaultSkillTable EntityMSkillCooltimeBehaviourOnExecuteDefaultSkillTable { get; private set; }
        // 0xFA8
        public EntityMSkillCooltimeBehaviourOnFrameUpdateTable EntityMSkillCooltimeBehaviourOnFrameUpdateTable { get; private set; }
        // 0xFB0
        public EntityMSkillCooltimeBehaviourOnSkillDamageTable EntityMSkillCooltimeBehaviourOnSkillDamageTable { get; private set; }
        // 0xFB8
        public EntityMSkillDamageMultiplyAbnormalAttachedValueGroupTable EntityMSkillDamageMultiplyAbnormalAttachedValueGroupTable { get; private set; }
        // 0xFC0
        public EntityMSkillDamageMultiplyDetailAbnormalAttachedTable EntityMSkillDamageMultiplyDetailAbnormalAttachedTable { get; private set; }
        // 0xFC8
        public EntityMSkillDamageMultiplyDetailAlwaysTable EntityMSkillDamageMultiplyDetailAlwaysTable { get; private set; }
        // 0xFD0
        public EntityMSkillDamageMultiplyDetailBuffAttachedTable EntityMSkillDamageMultiplyDetailBuffAttachedTable { get; private set; }
        // 0xFD8
        public EntityMSkillDamageMultiplyDetailCriticalTable EntityMSkillDamageMultiplyDetailCriticalTable { get; private set; }
        // 0xFE0
        public EntityMSkillDamageMultiplyDetailHitIndexTable EntityMSkillDamageMultiplyDetailHitIndexTable { get; private set; }
        // 0xFE8
        public EntityMSkillDamageMultiplyDetailSkillfulWeaponTypeTable EntityMSkillDamageMultiplyDetailSkillfulWeaponTypeTable { get; private set; }
        // 0xFF0
        public EntityMSkillDamageMultiplyHitIndexValueGroupTable EntityMSkillDamageMultiplyHitIndexValueGroupTable { get; private set; }
        // 0xFF8
        public EntityMSkillDetailTable EntityMSkillDetailTable { get; private set; }
        // 0x1000
        public EntityMSkillLevelGroupTable EntityMSkillLevelGroupTable { get; private set; }

        // 0x1008
        public EntityMSkillRemoveAbnormalTargetAbnormalGroupTable EntityMSkillRemoveAbnormalTargetAbnormalGroupTable { get; private set; }
        // 0x1010
        public EntityMSkillRemoveBuffFilterStatusKindTable EntityMSkillRemoveBuffFilterStatusKindTable { get; private set; }
        // 0x1018
        public EntityMSkillReserveUiTypeTable EntityMSkillReserveUiTypeTable { get; private set; }
        // 0x1020
        public EntityMSmartphoneChatGroupTable EntityMSmartphoneChatGroupTable { get; private set; }
        // 0x1028
        public EntityMSmartphoneChatGroupMessageTable EntityMSmartphoneChatGroupMessageTable { get; private set; }
        // 0x1030
        public EntityMSpeakerTable EntityMSpeakerTable { get; private set; }
        // 0x1038
        public EntityMStainedGlassTable EntityMStainedGlassTable { get; private set; }
        // 0x1040
        public EntityMStainedGlassStatusUpGroupTable EntityMStainedGlassStatusUpGroupTable { get; private set; }
        // 0x1048
        public EntityMStainedGlassStatusUpTargetGroupTable EntityMStainedGlassStatusUpTargetGroupTable { get; private set; }
        // 0x1050
        public EntityMThoughtTable EntityMThoughtTable { get; private set; }

        // 0x1058
        public EntityMTipTable EntityMTipTable { get; private set; }
        // 0x1060
        public EntityMTipBackgroundAssetTable EntityMTipBackgroundAssetTable { get; private set; }
        // 0x1068
        public EntityMTipDisplayConditionGroupTable EntityMTipDisplayConditionGroupTable { get; private set; }
        // 0x1070
        public EntityMTipGroupTable EntityMTipGroupTable { get; private set; }
        // 0x1078
        public EntityMTipGroupBackgroundAssetTable EntityMTipGroupBackgroundAssetTable { get; private set; }
        // 0x1080
        public EntityMTipGroupBackgroundAssetRelationTable EntityMTipGroupBackgroundAssetRelationTable { get; private set; }
        // 0x1088
        public EntityMTipGroupSelectionTable EntityMTipGroupSelectionTable { get; private set; }
        // 0x1090
        public EntityMTipGroupSituationTable EntityMTipGroupSituationTable { get; private set; }
        // 0x1098
        public EntityMTipGroupSituationSeasonTable EntityMTipGroupSituationSeasonTable { get; private set; }
        // 0x10A0
        public EntityMTitleFlowMovieTable EntityMTitleFlowMovieTable { get; private set; }
        // 0x10A8
        public EntityMTitleStillTable EntityMTitleStillTable { get; private set; }
        // 0x10B0
        public EntityMTitleStillGroupTable EntityMTitleStillGroupTable { get; private set; }
        // 0x10B8
        public EntityMTutorialDialogTable EntityMTutorialDialogTable { get; private set; }
        // 0x10C0
        public EntityMTutorialUnlockConditionTable EntityMTutorialUnlockConditionTable { get; private set; }
        // 0x10C8
        public EntityMUserLevelTable EntityMUserLevelTable { get; private set; }
        // 0x10D0
        public EntityMUserQuestSceneGrantPossessionTable EntityMUserQuestSceneGrantPossessionTable { get; private set; }
        // 0x10D8
        public EntityMWeaponTable EntityMWeaponTable { get; private set; }

        // 0x10E0
        public EntityMWeaponAbilityEnhancementMaterialTable EntityMWeaponAbilityEnhancementMaterialTable { get; private set; }
        // 0x10E8
        public EntityMWeaponAbilityGroupTable EntityMWeaponAbilityGroupTable { get; private set; }
        // 0x10F0
        public EntityMWeaponAwakenTable EntityMWeaponAwakenTable { get; private set; }
        // 0x10F8
        public EntityMWeaponAwakenAbilityTable EntityMWeaponAwakenAbilityTable { get; private set; }
        // 0x1100
        public EntityMWeaponAwakenEffectGroupTable EntityMWeaponAwakenEffectGroupTable { get; private set; }
        // 0x1108
        public EntityMWeaponAwakenMaterialGroupTable EntityMWeaponAwakenMaterialGroupTable { get; private set; }
        // 0x1110
        public EntityMWeaponAwakenStatusUpGroupTable EntityMWeaponAwakenStatusUpGroupTable { get; private set; }
        // 0x1118
        public EntityMWeaponBaseStatusTable EntityMWeaponBaseStatusTable { get; private set; }

        // 0x1120
        public EntityMWeaponConsumeExchangeConsumableItemGroupTable EntityMWeaponConsumeExchangeConsumableItemGroupTable { get; private set; }
        // 0x1128
        public EntityMWeaponEnhancedTable EntityMWeaponEnhancedTable { get; private set; }

        // 0x1130
        public EntityMWeaponEnhancedAbilityTable EntityMWeaponEnhancedAbilityTable { get; private set; }
        // 0x1138
        public EntityMWeaponEnhancedSkillTable EntityMWeaponEnhancedSkillTable { get; private set; }
        // 0x1140
        public EntityMWeaponEvolutionGroupTable EntityMWeaponEvolutionGroupTable { get; private set; }

        // 0x1148
        public EntityMWeaponEvolutionMaterialGroupTable EntityMWeaponEvolutionMaterialGroupTable { get; private set; }
        // 0x1150
        public EntityMWeaponFieldEffectDecreasePointTable EntityMWeaponFieldEffectDecreasePointTable { get; private set; }
        // 0x1158
        public EntityMWeaponRarityTable EntityMWeaponRarityTable { get; private set; }

        // 0x1160
        public EntityMWeaponRarityLimitBreakMaterialGroupTable EntityMWeaponRarityLimitBreakMaterialGroupTable { get; private set; }
        // 0x1168
        public EntityMWeaponSkillEnhancementMaterialTable EntityMWeaponSkillEnhancementMaterialTable { get; private set; }
        // 0x1170
        public EntityMWeaponSkillGroupTable EntityMWeaponSkillGroupTable { get; private set; }
        // 0x1178
        public EntityMWeaponSpecificEnhanceTable EntityMWeaponSpecificEnhanceTable { get; private set; }

        // 0x1180
        public EntityMWeaponSpecificLimitBreakMaterialGroupTable EntityMWeaponSpecificLimitBreakMaterialGroupTable { get; private set; }
        // 0x1188
        public EntityMWeaponStatusCalculationTable EntityMWeaponStatusCalculationTable { get; private set; }

        // 0x1190
        public EntityMWeaponStoryReleaseConditionGroupTable EntityMWeaponStoryReleaseConditionGroupTable { get; private set; }
        // 0x1198
        public EntityMWeaponStoryReleaseConditionOperationTable EntityMWeaponStoryReleaseConditionOperationTable { get; private set; }
        // 0x11A0
        public EntityMWeaponStoryReleaseConditionOperationGroupTable EntityMWeaponStoryReleaseConditionOperationGroupTable { get; private set; }
        // 0x11A8
        public EntityMWebviewMissionTable EntityMWebviewMissionTable { get; private set; }
        // 0x11B0
        public EntityMWebviewMissionTitleTextTable EntityMWebviewMissionTitleTextTable { get; private set; }
        // 0x11B8
        public EntityMWebviewPanelMissionTable EntityMWebviewPanelMissionTable { get; private set; }
        // 0x11C0
        public EntityMWebviewPanelMissionCompleteFlavorTextTable EntityMWebviewPanelMissionCompleteFlavorTextTable { get; private set; }
        // 0x11C8
        public EntityMWebviewPanelMissionPageTable EntityMWebviewPanelMissionPageTable { get; private set; }
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
            EntityMEventQuestGuerrillaFreeOpenTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMEventQuestGuerrillaFreeOpen[], EntityMEventQuestGuerrillaFreeOpenTable>(opens => new EntityMEventQuestGuerrillaFreeOpenTable(opens)));
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
            EntityMBeginnerCampaignTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBeginnerCampaign[], EntityMBeginnerCampaignTable>(campaigns => new EntityMBeginnerCampaignTable(campaigns)));
            EntityMComebackCampaignTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMComebackCampaign[], EntityMComebackCampaignTable>(campaigns => new EntityMComebackCampaignTable(campaigns)));
            EntityMCatalogThoughtTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCatalogThought[], EntityMCatalogThoughtTable>(thoughts => new EntityMCatalogThoughtTable(thoughts)));
            EntityMAbilityBehaviourActionBlessTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMAbilityBehaviourActionBless[], EntityMAbilityBehaviourActionBlessTable>(data => new EntityMAbilityBehaviourActionBlessTable(data)));
            EntityMActorTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMActor[], EntityMActorTable>(data => new EntityMActorTable(data)));
            EntityMActorAnimationTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMActorAnimation[], EntityMActorAnimationTable>(data => new EntityMActorAnimationTable(data)));
            EntityMActorAnimationCategoryTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMActorAnimationCategory[], EntityMActorAnimationCategoryTable>(data => new EntityMActorAnimationCategoryTable(data)));
            EntityMActorAnimationControllerTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMActorAnimationController[], EntityMActorAnimationControllerTable>(data => new EntityMActorAnimationControllerTable(data)));
            EntityMActorObjectTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMActorObject[], EntityMActorObjectTable>(data => new EntityMActorObjectTable(data)));
            EntityMAssetBackgroundTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMAssetBackground[], EntityMAssetBackgroundTable>(data => new EntityMAssetBackgroundTable(data)));
            EntityMAssetCalculatorTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMAssetCalculator[], EntityMAssetCalculatorTable>(data => new EntityMAssetCalculatorTable(data)));
            EntityMAssetDataSettingTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMAssetDataSetting[], EntityMAssetDataSettingTable>(data => new EntityMAssetDataSettingTable(data)));
            EntityMAssetEffectTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMAssetEffect[], EntityMAssetEffectTable>(data => new EntityMAssetEffectTable(data)));
            EntityMAssetGradeIconTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMAssetGradeIcon[], EntityMAssetGradeIconTable>(data => new EntityMAssetGradeIconTable(data)));
            EntityMAssetTimelineTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMAssetTimeline[], EntityMAssetTimelineTable>(data => new EntityMAssetTimelineTable(data)));
            EntityMAssetTurnbattlePrefabTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMAssetTurnbattlePrefab[], EntityMAssetTurnbattlePrefabTable>(data => new EntityMAssetTurnbattlePrefabTable(data)));
            EntityMBattleActorAiTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleActorAi[], EntityMBattleActorAiTable>(data => new EntityMBattleActorAiTable(data)));
            EntityMBattleActorSkillAiGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleActorSkillAiGroup[], EntityMBattleActorSkillAiGroupTable>(data => new EntityMBattleActorSkillAiGroupTable(data)));
            EntityMBattleAdditionalAbilityTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleAdditionalAbility[], EntityMBattleAdditionalAbilityTable>(data => new EntityMBattleAdditionalAbilityTable(data)));
            EntityMBattleAttributeDamageCoefficientDefineTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleAttributeDamageCoefficientDefine[], EntityMBattleAttributeDamageCoefficientDefineTable>(data => new EntityMBattleAttributeDamageCoefficientDefineTable(data)));
            EntityMBattleAttributeDamageCoefficientGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleAttributeDamageCoefficientGroup[], EntityMBattleAttributeDamageCoefficientGroupTable>(data => new EntityMBattleAttributeDamageCoefficientGroupTable(data)));
            EntityMBattleBgmSetTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleBgmSet[], EntityMBattleBgmSetTable>(data => new EntityMBattleBgmSetTable(data)));
            EntityMBattleBgmSetGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleBgmSetGroup[], EntityMBattleBgmSetGroupTable>(data => new EntityMBattleBgmSetGroupTable(data)));
            EntityMBattleBigHuntTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleBigHunt[], EntityMBattleBigHuntTable>(data => new EntityMBattleBigHuntTable(data)));
            EntityMBattleBigHuntDamageThresholdGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleBigHuntDamageThresholdGroup[], EntityMBattleBigHuntDamageThresholdGroupTable>(data => new EntityMBattleBigHuntDamageThresholdGroupTable(data)));
            EntityMBattleBigHuntKnockDownGaugeValueConfigGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleBigHuntKnockDownGaugeValueConfigGroup[], EntityMBattleBigHuntKnockDownGaugeValueConfigGroupTable>(data => new EntityMBattleBigHuntKnockDownGaugeValueConfigGroupTable(data)));
            EntityMBattleBigHuntPhaseGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleBigHuntPhaseGroup[], EntityMBattleBigHuntPhaseGroupTable>(data => new EntityMBattleBigHuntPhaseGroupTable(data)));
            EntityMBattleCompanionSkillAiGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleCompanionSkillAiGroup[], EntityMBattleCompanionSkillAiGroupTable>(data => new EntityMBattleCompanionSkillAiGroupTable(data)));
            EntityMBattleCostumeSkillSeTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleCostumeSkillSe[], EntityMBattleCostumeSkillSeTable>(data => new EntityMBattleCostumeSkillSeTable(data)));
            EntityMBattleDropRewardTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleDropReward[], EntityMBattleDropRewardTable>(data => new EntityMBattleDropRewardTable(data)));
            EntityMBattleEnemySizeTypeConfigTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleEnemySizeTypeConfig[], EntityMBattleEnemySizeTypeConfigTable>(data => new EntityMBattleEnemySizeTypeConfigTable(data)));
            EntityMBattleEventTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleEvent[], EntityMBattleEventTable>(data => new EntityMBattleEventTable(data)));
            EntityMBattleEventGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleEventGroup[], EntityMBattleEventGroupTable>(data => new EntityMBattleEventGroupTable(data)));
            EntityMBattleEventReceiverBehaviourGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleEventReceiverBehaviourGroup[], EntityMBattleEventReceiverBehaviourGroupTable>(data => new EntityMBattleEventReceiverBehaviourGroupTable(data)));
            EntityMBattleEventReceiverBehaviourHudActSequenceTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleEventReceiverBehaviourHudActSequence[], EntityMBattleEventReceiverBehaviourHudActSequenceTable>(data => new EntityMBattleEventReceiverBehaviourHudActSequenceTable(data)));
            EntityMBattleEventReceiverBehaviourRadioMessageTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleEventReceiverBehaviourRadioMessage[], EntityMBattleEventReceiverBehaviourRadioMessageTable>(data => new EntityMBattleEventReceiverBehaviourRadioMessageTable(data)));
            EntityMBattleEventTriggerBehaviourBattleStartTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleEventTriggerBehaviourBattleStart[], EntityMBattleEventTriggerBehaviourBattleStartTable>(data => new EntityMBattleEventTriggerBehaviourBattleStartTable(data)));
            EntityMBattleEventTriggerBehaviourGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleEventTriggerBehaviourGroup[], EntityMBattleEventTriggerBehaviourGroupTable>(data => new EntityMBattleEventTriggerBehaviourGroupTable(data)));
            EntityMBattleEventTriggerBehaviourWaveStartTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleEventTriggerBehaviourWaveStart[], EntityMBattleEventTriggerBehaviourWaveStartTable>(data => new EntityMBattleEventTriggerBehaviourWaveStartTable(data)));
            EntityMBattleGeneralViewConfigurationTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleGeneralViewConfiguration[], EntityMBattleGeneralViewConfigurationTable>(data => new EntityMBattleGeneralViewConfigurationTable(data)));
            EntityMBattleNpcTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleNpc[], EntityMBattleNpcTable>(data => new EntityMBattleNpcTable(data)));
            EntityMBattleNpcCharacterTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleNpcCharacter[], EntityMBattleNpcCharacterTable>(data => new EntityMBattleNpcCharacterTable(data)));
            EntityMBattleNpcCharacterBoardTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleNpcCharacterBoard[], EntityMBattleNpcCharacterBoardTable>(data => new EntityMBattleNpcCharacterBoardTable(data)));
            EntityMBattleNpcCharacterBoardAbilityTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleNpcCharacterBoardAbility[], EntityMBattleNpcCharacterBoardAbilityTable>(data => new EntityMBattleNpcCharacterBoardAbilityTable(data)));
            EntityMBattleNpcCharacterBoardCompleteRewardTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleNpcCharacterBoardCompleteReward[], EntityMBattleNpcCharacterBoardCompleteRewardTable>(data => new EntityMBattleNpcCharacterBoardCompleteRewardTable(data)));
            EntityMBattleNpcCharacterBoardStatusUpTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleNpcCharacterBoardStatusUp[], EntityMBattleNpcCharacterBoardStatusUpTable>(data => new EntityMBattleNpcCharacterBoardStatusUpTable(data)));
            EntityMBattleNpcCharacterCostumeLevelBonusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleNpcCharacterCostumeLevelBonus[], EntityMBattleNpcCharacterCostumeLevelBonusTable>(data => new EntityMBattleNpcCharacterCostumeLevelBonusTable(data)));
            EntityMBattleNpcCharacterViewerFieldTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleNpcCharacterViewerField[], EntityMBattleNpcCharacterViewerFieldTable>(data => new EntityMBattleNpcCharacterViewerFieldTable(data)));
            EntityMBattleNpcCostumeAwakenStatusUpTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleNpcCostumeAwakenStatusUp[], EntityMBattleNpcCostumeAwakenStatusUpTable>(data => new EntityMBattleNpcCostumeAwakenStatusUpTable(data)));
            EntityMBattleNpcCostumeLevelBonusReevaluateTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleNpcCostumeLevelBonusReevaluate[], EntityMBattleNpcCostumeLevelBonusReevaluateTable>(data => new EntityMBattleNpcCostumeLevelBonusReevaluateTable(data)));
            EntityMBattleNpcCostumeLevelBonusReleaseStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleNpcCostumeLevelBonusReleaseStatus[], EntityMBattleNpcCostumeLevelBonusReleaseStatusTable>(data => new EntityMBattleNpcCostumeLevelBonusReleaseStatusTable(data)));
            EntityMBattleNpcDeckCharacterDressupCostumeTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleNpcDeckCharacterDressupCostume[], EntityMBattleNpcDeckCharacterDressupCostumeTable>(data => new EntityMBattleNpcDeckCharacterDressupCostumeTable(data)));
            EntityMBattleNpcDeckCharacterDropCategoryTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleNpcDeckCharacterDropCategory[], EntityMBattleNpcDeckCharacterDropCategoryTable>(data => new EntityMBattleNpcDeckCharacterDropCategoryTable(data)));
            EntityMBattleNpcDeckCharacterTypeTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleNpcDeckCharacterType[], EntityMBattleNpcDeckCharacterTypeTable>(data => new EntityMBattleNpcDeckCharacterTypeTable(data)));
            EntityMBattleNpcDeckLimitContentRestrictedTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleNpcDeckLimitContentRestricted[], EntityMBattleNpcDeckLimitContentRestrictedTable>(data => new EntityMBattleNpcDeckLimitContentRestrictedTable(data)));
            EntityMBattleNpcDeckPartsGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleNpcDeckPartsGroup[], EntityMBattleNpcDeckPartsGroupTable>(data => new EntityMBattleNpcDeckPartsGroupTable(data)));
            EntityMBattleNpcDeckSubWeaponGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleNpcDeckSubWeaponGroup[], EntityMBattleNpcDeckSubWeaponGroupTable>(data => new EntityMBattleNpcDeckSubWeaponGroupTable(data)));
            EntityMBattleNpcDeckTypeNoteTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleNpcDeckTypeNote[], EntityMBattleNpcDeckTypeNoteTable>(data => new EntityMBattleNpcDeckTypeNoteTable(data)));
            EntityMBattleNpcPartsTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleNpcParts[], EntityMBattleNpcPartsTable>(data => new EntityMBattleNpcPartsTable(data)));
            EntityMBattleNpcPartsGroupNoteTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleNpcPartsGroupNote[], EntityMBattleNpcPartsGroupNoteTable>(data => new EntityMBattleNpcPartsGroupNoteTable(data)));
            EntityMBattleNpcPartsPresetTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleNpcPartsPreset[], EntityMBattleNpcPartsPresetTable>(data => new EntityMBattleNpcPartsPresetTable(data)));
            EntityMBattleNpcPartsPresetTagTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleNpcPartsPresetTag[], EntityMBattleNpcPartsPresetTagTable>(data => new EntityMBattleNpcPartsPresetTagTable(data)));
            EntityMBattleNpcPartsStatusSubTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleNpcPartsStatusSub[], EntityMBattleNpcPartsStatusSubTable>(data => new EntityMBattleNpcPartsStatusSubTable(data)));
            EntityMBattleNpcSpecialEndActTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleNpcSpecialEndAct[], EntityMBattleNpcSpecialEndActTable>(data => new EntityMBattleNpcSpecialEndActTable(data)));
            EntityMBattleNpcWeaponAbilityTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleNpcWeaponAbility[], EntityMBattleNpcWeaponAbilityTable>(data => new EntityMBattleNpcWeaponAbilityTable(data)));
            EntityMBattleNpcWeaponNoteTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleNpcWeaponNote[], EntityMBattleNpcWeaponNoteTable>(data => new EntityMBattleNpcWeaponNoteTable(data)));
            EntityMBattleNpcWeaponSkillTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleNpcWeaponSkill[], EntityMBattleNpcWeaponSkillTable>(data => new EntityMBattleNpcWeaponSkillTable(data)));
            EntityMBattleNpcWeaponStoryTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleNpcWeaponStory[], EntityMBattleNpcWeaponStoryTable>(data => new EntityMBattleNpcWeaponStoryTable(data)));
            EntityMBattleNpcWeaponStoryReevaluateTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleNpcWeaponStoryReevaluate[], EntityMBattleNpcWeaponStoryReevaluateTable>(data => new EntityMBattleNpcWeaponStoryReevaluateTable(data)));
            EntityMBattleProgressUiTypeTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleProgressUiType[], EntityMBattleProgressUiTypeTable>(data => new EntityMBattleProgressUiTypeTable(data)));
            EntityMBattleQuestSceneBgmSetGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleQuestSceneBgmSetGroup[], EntityMBattleQuestSceneBgmSetGroupTable>(data => new EntityMBattleQuestSceneBgmSetGroupTable(data)));
            EntityMBattleSkillBehaviourHitDamageConfigurationTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleSkillBehaviourHitDamageConfiguration[], EntityMBattleSkillBehaviourHitDamageConfigurationTable>(data => new EntityMBattleSkillBehaviourHitDamageConfigurationTable(data)));
            EntityMBigHuntBossGradeGroupAttributeTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBigHuntBossGradeGroupAttribute[], EntityMBigHuntBossGradeGroupAttributeTable>(data => new EntityMBigHuntBossGradeGroupAttributeTable(data)));
            EntityMBigHuntBossQuestGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBigHuntBossQuestGroup[], EntityMBigHuntBossQuestGroupTable>(data => new EntityMBigHuntBossQuestGroupTable(data)));
            EntityMBigHuntBossQuestGroupChallengeCategoryTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBigHuntBossQuestGroupChallengeCategory[], EntityMBigHuntBossQuestGroupChallengeCategoryTable>(data => new EntityMBigHuntBossQuestGroupChallengeCategoryTable(data)));
            EntityMBigHuntLinkTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBigHuntLink[], EntityMBigHuntLinkTable>(data => new EntityMBigHuntLinkTable(data)));
            EntityMBigHuntRewardGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBigHuntRewardGroup[], EntityMBigHuntRewardGroupTable>(data => new EntityMBigHuntRewardGroupTable(data)));
            EntityMBigHuntScheduleTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBigHuntSchedule[], EntityMBigHuntScheduleTable>(data => new EntityMBigHuntScheduleTable(data)));
            EntityMBigHuntScoreRewardGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBigHuntScoreRewardGroup[], EntityMBigHuntScoreRewardGroupTable>(data => new EntityMBigHuntScoreRewardGroupTable(data)));
            EntityMBigHuntScoreRewardGroupScheduleTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBigHuntScoreRewardGroupSchedule[], EntityMBigHuntScoreRewardGroupScheduleTable>(data => new EntityMBigHuntScoreRewardGroupScheduleTable(data)));
            EntityMBigHuntWeeklyAttributeScoreRewardGroupScheduleTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBigHuntWeeklyAttributeScoreRewardGroupSchedule[], EntityMBigHuntWeeklyAttributeScoreRewardGroupScheduleTable>(data => new EntityMBigHuntWeeklyAttributeScoreRewardGroupScheduleTable(data)));
            EntityMCageMemoryTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCageMemory[], EntityMCageMemoryTable>(data => new EntityMCageMemoryTable(data)));
            EntityMCageOrnamentTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCageOrnament[], EntityMCageOrnamentTable>(data => new EntityMCageOrnamentTable(data)));
            EntityMCageOrnamentMainQuestChapterStillTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCageOrnamentMainQuestChapterStill[], EntityMCageOrnamentMainQuestChapterStillTable>(data => new EntityMCageOrnamentMainQuestChapterStillTable(data)));
            EntityMCageOrnamentRewardTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCageOrnamentReward[], EntityMCageOrnamentRewardTable>(data => new EntityMCageOrnamentRewardTable(data)));
            EntityMCageOrnamentStillReleaseConditionTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCageOrnamentStillReleaseCondition[], EntityMCageOrnamentStillReleaseConditionTable>(data => new EntityMCageOrnamentStillReleaseConditionTable(data)));
            EntityMCharacterBoardTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCharacterBoard[], EntityMCharacterBoardTable>(data => new EntityMCharacterBoardTable(data)));
            EntityMCharacterBoardAbilityTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCharacterBoardAbility[], EntityMCharacterBoardAbilityTable>(data => new EntityMCharacterBoardAbilityTable(data)));
            EntityMCharacterBoardAbilityMaxLevelTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCharacterBoardAbilityMaxLevel[], EntityMCharacterBoardAbilityMaxLevelTable>(data => new EntityMCharacterBoardAbilityMaxLevelTable(data)));
            EntityMCharacterBoardAssignmentTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCharacterBoardAssignment[], EntityMCharacterBoardAssignmentTable>(data => new EntityMCharacterBoardAssignmentTable(data)));
            EntityMCharacterBoardCategoryTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCharacterBoardCategory[], EntityMCharacterBoardCategoryTable>(data => new EntityMCharacterBoardCategoryTable(data)));
            EntityMCharacterBoardCompleteRewardTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCharacterBoardCompleteReward[], EntityMCharacterBoardCompleteRewardTable>(data => new EntityMCharacterBoardCompleteRewardTable(data)));
            EntityMCharacterBoardCompleteRewardGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCharacterBoardCompleteRewardGroup[], EntityMCharacterBoardCompleteRewardGroupTable>(data => new EntityMCharacterBoardCompleteRewardGroupTable(data)));
            EntityMCharacterBoardConditionTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCharacterBoardCondition[], EntityMCharacterBoardConditionTable>(data => new EntityMCharacterBoardConditionTable(data)));
            EntityMCharacterBoardConditionDetailTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCharacterBoardConditionDetail[], EntityMCharacterBoardConditionDetailTable>(data => new EntityMCharacterBoardConditionDetailTable(data)));
            EntityMCharacterBoardConditionGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCharacterBoardConditionGroup[], EntityMCharacterBoardConditionGroupTable>(data => new EntityMCharacterBoardConditionGroupTable(data)));
            EntityMCharacterBoardConditionIgnoreTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCharacterBoardConditionIgnore[], EntityMCharacterBoardConditionIgnoreTable>(data => new EntityMCharacterBoardConditionIgnoreTable(data)));
            EntityMCharacterBoardEffectTargetGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCharacterBoardEffectTargetGroup[], EntityMCharacterBoardEffectTargetGroupTable>(data => new EntityMCharacterBoardEffectTargetGroupTable(data)));
            EntityMCharacterBoardGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCharacterBoardGroup[], EntityMCharacterBoardGroupTable>(data => new EntityMCharacterBoardGroupTable(data)));
            EntityMCharacterBoardPanelTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCharacterBoardPanel[], EntityMCharacterBoardPanelTable>(data => new EntityMCharacterBoardPanelTable(data)));
            EntityMCharacterBoardPanelReleaseEffectGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCharacterBoardPanelReleaseEffectGroup[], EntityMCharacterBoardPanelReleaseEffectGroupTable>(data => new EntityMCharacterBoardPanelReleaseEffectGroupTable(data)));
            EntityMCharacterBoardPanelReleasePossessionGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCharacterBoardPanelReleasePossessionGroup[], EntityMCharacterBoardPanelReleasePossessionGroupTable>(data => new EntityMCharacterBoardPanelReleasePossessionGroupTable(data)));
            EntityMCharacterBoardPanelReleaseRewardGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCharacterBoardPanelReleaseRewardGroup[], EntityMCharacterBoardPanelReleaseRewardGroupTable>(data => new EntityMCharacterBoardPanelReleaseRewardGroupTable(data)));
            EntityMCharacterBoardStatusUpTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCharacterBoardStatusUp[], EntityMCharacterBoardStatusUpTable>(data => new EntityMCharacterBoardStatusUpTable(data)));
            EntityMCharacterViewerActorIconTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCharacterViewerActorIcon[], EntityMCharacterViewerActorIconTable>(data => new EntityMCharacterViewerActorIconTable(data)));
            EntityMCharacterViewerFieldTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCharacterViewerField[], EntityMCharacterViewerFieldTable>(data => new EntityMCharacterViewerFieldTable(data)));
            EntityMCharacterViewerFieldSettingsTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCharacterViewerFieldSettings[], EntityMCharacterViewerFieldSettingsTable>(data => new EntityMCharacterViewerFieldSettingsTable(data)));
            EntityMCharacterVoiceUnlockConditionTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCharacterVoiceUnlockCondition[], EntityMCharacterVoiceUnlockConditionTable>(data => new EntityMCharacterVoiceUnlockConditionTable(data)));
            EntityMCollectionBonusEffectTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCollectionBonusEffect[], EntityMCollectionBonusEffectTable>(data => new EntityMCollectionBonusEffectTable(data)));
            EntityMCollectionBonusQuestAssignmentTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCollectionBonusQuestAssignment[], EntityMCollectionBonusQuestAssignmentTable>(data => new EntityMCollectionBonusQuestAssignmentTable(data)));
            EntityMCollectionBonusQuestAssignmentGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCollectionBonusQuestAssignmentGroup[], EntityMCollectionBonusQuestAssignmentGroupTable>(data => new EntityMCollectionBonusQuestAssignmentGroupTable(data)));
            EntityMComboCalculationSettingTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMComboCalculationSetting[], EntityMComboCalculationSettingTable>(data => new EntityMComboCalculationSettingTable(data)));
            EntityMCompanionDuplicationExchangePossessionGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCompanionDuplicationExchangePossessionGroup[], EntityMCompanionDuplicationExchangePossessionGroupTable>(data => new EntityMCompanionDuplicationExchangePossessionGroupTable(data)));
            EntityMCompanionEnhancementMaterialTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCompanionEnhancementMaterial[], EntityMCompanionEnhancementMaterialTable>(data => new EntityMCompanionEnhancementMaterialTable(data)));
            EntityMCompleteMissionGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCompleteMissionGroup[], EntityMCompleteMissionGroupTable>(data => new EntityMCompleteMissionGroupTable(data)));
            EntityMContentsStoryTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMContentsStory[], EntityMContentsStoryTable>(data => new EntityMContentsStoryTable(data)));
            EntityMCostumeActiveSkillEnhancementMaterialTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCostumeActiveSkillEnhancementMaterial[], EntityMCostumeActiveSkillEnhancementMaterialTable>(data => new EntityMCostumeActiveSkillEnhancementMaterialTable(data)));
            EntityMCostumeAnimationStepTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCostumeAnimationStep[], EntityMCostumeAnimationStepTable>(data => new EntityMCostumeAnimationStepTable(data)));
            EntityMCostumeAwakenAbilityTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCostumeAwakenAbility[], EntityMCostumeAwakenAbilityTable>(data => new EntityMCostumeAwakenAbilityTable(data)));
            EntityMCostumeAwakenEffectGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCostumeAwakenEffectGroup[], EntityMCostumeAwakenEffectGroupTable>(data => new EntityMCostumeAwakenEffectGroupTable(data)));
            EntityMCostumeAwakenItemAcquireTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCostumeAwakenItemAcquire[], EntityMCostumeAwakenItemAcquireTable>(data => new EntityMCostumeAwakenItemAcquireTable(data)));
            EntityMCostumeAwakenMaterialGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCostumeAwakenMaterialGroup[], EntityMCostumeAwakenMaterialGroupTable>(data => new EntityMCostumeAwakenMaterialGroupTable(data)));
            EntityMCostumeAwakenPriceGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCostumeAwakenPriceGroup[], EntityMCostumeAwakenPriceGroupTable>(data => new EntityMCostumeAwakenPriceGroupTable(data)));
            EntityMCostumeAwakenStatusUpGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCostumeAwakenStatusUpGroup[], EntityMCostumeAwakenStatusUpGroupTable>(data => new EntityMCostumeAwakenStatusUpGroupTable(data)));
            EntityMCostumeAwakenStepMaterialGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCostumeAwakenStepMaterialGroup[], EntityMCostumeAwakenStepMaterialGroupTable>(data => new EntityMCostumeAwakenStepMaterialGroupTable(data)));
            EntityMCostumeCollectionBonusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCostumeCollectionBonus[], EntityMCostumeCollectionBonusTable>(data => new EntityMCostumeCollectionBonusTable(data)));
            EntityMCostumeCollectionBonusGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCostumeCollectionBonusGroup[], EntityMCostumeCollectionBonusGroupTable>(data => new EntityMCostumeCollectionBonusGroupTable(data)));
            EntityMCostumeDefaultSkillGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCostumeDefaultSkillGroup[], EntityMCostumeDefaultSkillGroupTable>(data => new EntityMCostumeDefaultSkillGroupTable(data)));
            EntityMCostumeDefaultSkillLotteryGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCostumeDefaultSkillLotteryGroup[], EntityMCostumeDefaultSkillLotteryGroupTable>(data => new EntityMCostumeDefaultSkillLotteryGroupTable(data)));
            EntityMCostumeDisplayCoordinateAdjustmentTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCostumeDisplayCoordinateAdjustment[], EntityMCostumeDisplayCoordinateAdjustmentTable>(data => new EntityMCostumeDisplayCoordinateAdjustmentTable(data)));
            EntityMCostumeDuplicationExchangePossessionGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCostumeDuplicationExchangePossessionGroup[], EntityMCostumeDuplicationExchangePossessionGroupTable>(data => new EntityMCostumeDuplicationExchangePossessionGroupTable(data)));
            EntityMCostumeLevelBonusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCostumeLevelBonus[], EntityMCostumeLevelBonusTable>(data => new EntityMCostumeLevelBonusTable(data)));
            EntityMCostumeLimitBreakMaterialGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCostumeLimitBreakMaterialGroup[], EntityMCostumeLimitBreakMaterialGroupTable>(data => new EntityMCostumeLimitBreakMaterialGroupTable(data)));
            EntityMCostumeLimitBreakMaterialRarityGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCostumeLimitBreakMaterialRarityGroup[], EntityMCostumeLimitBreakMaterialRarityGroupTable>(data => new EntityMCostumeLimitBreakMaterialRarityGroupTable(data)));
            EntityMCostumeOverflowExchangePossessionGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCostumeOverflowExchangePossessionGroup[], EntityMCostumeOverflowExchangePossessionGroupTable>(data => new EntityMCostumeOverflowExchangePossessionGroupTable(data)));
            EntityMCostumeSpecialActActiveSkillTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCostumeSpecialActActiveSkill[], EntityMCostumeSpecialActActiveSkillTable>(data => new EntityMCostumeSpecialActActiveSkillTable(data)));
            EntityMDeckEntrustCoefficientAttributeTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMDeckEntrustCoefficientAttribute[], EntityMDeckEntrustCoefficientAttributeTable>(data => new EntityMDeckEntrustCoefficientAttributeTable(data)));
            EntityMDeckEntrustCoefficientPartsSeriesBonusCountTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMDeckEntrustCoefficientPartsSeriesBonusCount[], EntityMDeckEntrustCoefficientPartsSeriesBonusCountTable>(data => new EntityMDeckEntrustCoefficientPartsSeriesBonusCountTable(data)));
            EntityMDeckEntrustCoefficientStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMDeckEntrustCoefficientStatus[], EntityMDeckEntrustCoefficientStatusTable>(data => new EntityMDeckEntrustCoefficientStatusTable(data)));
            EntityMDokanTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMDokan[], EntityMDokanTable>(data => new EntityMDokanTable(data)));
            EntityMDokanContentGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMDokanContentGroup[], EntityMDokanContentGroupTable>(data => new EntityMDokanContentGroupTable(data)));
            EntityMDokanTextTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMDokanText[], EntityMDokanTextTable>(data => new EntityMDokanTextTable(data)));
            EntityMEnhanceCampaignTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMEnhanceCampaign[], EntityMEnhanceCampaignTable>(data => new EntityMEnhanceCampaignTable(data)));
            EntityMEnhanceCampaignTargetGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMEnhanceCampaignTargetGroup[], EntityMEnhanceCampaignTargetGroupTable>(data => new EntityMEnhanceCampaignTargetGroupTable(data)));
            EntityMEvaluateConditionTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMEvaluateCondition[], EntityMEvaluateConditionTable>(data => new EntityMEvaluateConditionTable(data)));
            EntityMEvaluateConditionValueGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMEvaluateConditionValueGroup[], EntityMEvaluateConditionValueGroupTable>(data => new EntityMEvaluateConditionValueGroupTable(data)));
            EntityMEventQuestChapterDifficultyLimitContentUnlockTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMEventQuestChapterDifficultyLimitContentUnlock[], EntityMEventQuestChapterDifficultyLimitContentUnlockTable>(data => new EntityMEventQuestChapterDifficultyLimitContentUnlockTable(data)));
            EntityMEventQuestChapterLimitContentRelationTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMEventQuestChapterLimitContentRelation[], EntityMEventQuestChapterLimitContentRelationTable>(data => new EntityMEventQuestChapterLimitContentRelationTable(data)));
            EntityMEventQuestDisplayItemGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMEventQuestDisplayItemGroup[], EntityMEventQuestDisplayItemGroupTable>(data => new EntityMEventQuestDisplayItemGroupTable(data)));
            EntityMEventQuestGuerrillaFreeOpenScheduleCorrespondenceTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMEventQuestGuerrillaFreeOpenScheduleCorrespondence[], EntityMEventQuestGuerrillaFreeOpenScheduleCorrespondenceTable>(data => new EntityMEventQuestGuerrillaFreeOpenScheduleCorrespondenceTable(data)));
            EntityMEventQuestLimitContentTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMEventQuestLimitContent[], EntityMEventQuestLimitContentTable>(data => new EntityMEventQuestLimitContentTable(data)));
            EntityMEventQuestTowerAccumulationRewardTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMEventQuestTowerAccumulationReward[], EntityMEventQuestTowerAccumulationRewardTable>(data => new EntityMEventQuestTowerAccumulationRewardTable(data)));
            EntityMEventQuestTowerAccumulationRewardGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMEventQuestTowerAccumulationRewardGroup[], EntityMEventQuestTowerAccumulationRewardGroupTable>(data => new EntityMEventQuestTowerAccumulationRewardGroupTable(data)));
            EntityMEventQuestTowerAssetTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMEventQuestTowerAsset[], EntityMEventQuestTowerAssetTable>(data => new EntityMEventQuestTowerAssetTable(data)));
            EntityMEventQuestTowerRewardGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMEventQuestTowerRewardGroup[], EntityMEventQuestTowerRewardGroupTable>(data => new EntityMEventQuestTowerRewardGroupTable(data)));
            EntityMEventQuestUnlockConditionTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMEventQuestUnlockCondition[], EntityMEventQuestUnlockConditionTable>(data => new EntityMEventQuestUnlockConditionTable(data)));
            EntityMExploreTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMExplore[], EntityMExploreTable>(data => new EntityMExploreTable(data)));
            EntityMExploreGradeAssetTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMExploreGradeAsset[], EntityMExploreGradeAssetTable>(data => new EntityMExploreGradeAssetTable(data)));
            EntityMExploreGradeScoreTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMExploreGradeScore[], EntityMExploreGradeScoreTable>(data => new EntityMExploreGradeScoreTable(data)));
            EntityMExploreGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMExploreGroup[], EntityMExploreGroupTable>(data => new EntityMExploreGroupTable(data)));
            EntityMExploreUnlockConditionTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMExploreUnlockCondition[], EntityMExploreUnlockConditionTable>(data => new EntityMExploreUnlockConditionTable(data)));
            EntityMExtraQuestGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMExtraQuestGroup[], EntityMExtraQuestGroupTable>(data => new EntityMExtraQuestGroupTable(data)));
            EntityMExtraQuestGroupInMainQuestChapterTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMExtraQuestGroupInMainQuestChapter[], EntityMExtraQuestGroupInMainQuestChapterTable>(data => new EntityMExtraQuestGroupInMainQuestChapterTable(data)));
            EntityMFieldEffectBlessRelationTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMFieldEffectBlessRelation[], EntityMFieldEffectBlessRelationTable>(data => new EntityMFieldEffectBlessRelationTable(data)));
            EntityMFieldEffectDecreasePointTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMFieldEffectDecreasePoint[], EntityMFieldEffectDecreasePointTable>(data => new EntityMFieldEffectDecreasePointTable(data)));
            EntityMFieldEffectGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMFieldEffectGroup[], EntityMFieldEffectGroupTable>(data => new EntityMFieldEffectGroupTable(data)));
            EntityMGachaMedalTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMGachaMedal[], EntityMGachaMedalTable>(data => new EntityMGachaMedalTable(data)));
            EntityMGiftTextTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMGiftText[], EntityMGiftTextTable>(data => new EntityMGiftTextTable(data)));
            EntityMGimmickTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMGimmick[], EntityMGimmickTable>(data => new EntityMGimmickTable(data)));
            EntityMGimmickAdditionalAssetTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMGimmickAdditionalAsset[], EntityMGimmickAdditionalAssetTable>(data => new EntityMGimmickAdditionalAssetTable(data)));
            EntityMGimmickExtraQuestTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMGimmickExtraQuest[], EntityMGimmickExtraQuestTable>(data => new EntityMGimmickExtraQuestTable(data)));
            EntityMGimmickGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMGimmickGroup[], EntityMGimmickGroupTable>(data => new EntityMGimmickGroupTable(data)));
            EntityMGimmickGroupEventLogTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMGimmickGroupEventLog[], EntityMGimmickGroupEventLogTable>(data => new EntityMGimmickGroupEventLogTable(data)));
            EntityMGimmickIntervalTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMGimmickInterval[], EntityMGimmickIntervalTable>(data => new EntityMGimmickIntervalTable(data)));
            EntityMGimmickOrnamentTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMGimmickOrnament[], EntityMGimmickOrnamentTable>(data => new EntityMGimmickOrnamentTable(data)));
            EntityMGimmickSequenceTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMGimmickSequence[], EntityMGimmickSequenceTable>(data => new EntityMGimmickSequenceTable(data)));
            EntityMGimmickSequenceGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMGimmickSequenceGroup[], EntityMGimmickSequenceGroupTable>(data => new EntityMGimmickSequenceGroupTable(data)));
            EntityMGimmickSequenceRewardGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMGimmickSequenceRewardGroup[], EntityMGimmickSequenceRewardGroupTable>(data => new EntityMGimmickSequenceRewardGroupTable(data)));
            EntityMGimmickSequenceScheduleTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMGimmickSequenceSchedule[], EntityMGimmickSequenceScheduleTable>(data => new EntityMGimmickSequenceScheduleTable(data)));
            EntityMHeadupDisplayViewTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMHeadupDisplayView[], EntityMHeadupDisplayViewTable>(data => new EntityMHeadupDisplayViewTable(data)));
            EntityMHelpTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMHelp[], EntityMHelpTable>(data => new EntityMHelpTable(data)));
            EntityMHelpCategoryTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMHelpCategory[], EntityMHelpCategoryTable>(data => new EntityMHelpCategoryTable(data)));
            EntityMHelpItemTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMHelpItem[], EntityMHelpItemTable>(data => new EntityMHelpItemTable(data)));
            EntityMHelpPageGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMHelpPageGroup[], EntityMHelpPageGroupTable>(data => new EntityMHelpPageGroupTable(data)));
            EntityMImportantItemEffectTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMImportantItemEffect[], EntityMImportantItemEffectTable>(data => new EntityMImportantItemEffectTable(data)));
            EntityMImportantItemEffectDropCountTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMImportantItemEffectDropCount[], EntityMImportantItemEffectDropCountTable>(data => new EntityMImportantItemEffectDropCountTable(data)));
            EntityMImportantItemEffectDropRateTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMImportantItemEffectDropRate[], EntityMImportantItemEffectDropRateTable>(data => new EntityMImportantItemEffectDropRateTable(data)));
            EntityMImportantItemEffectTargetItemGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMImportantItemEffectTargetItemGroup[], EntityMImportantItemEffectTargetItemGroupTable>(data => new EntityMImportantItemEffectTargetItemGroupTable(data)));
            EntityMImportantItemEffectTargetQuestGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMImportantItemEffectTargetQuestGroup[], EntityMImportantItemEffectTargetQuestGroupTable>(data => new EntityMImportantItemEffectTargetQuestGroupTable(data)));
            EntityMImportantItemEffectUnlockFunctionTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMImportantItemEffectUnlockFunction[], EntityMImportantItemEffectUnlockFunctionTable>(data => new EntityMImportantItemEffectUnlockFunctionTable(data)));
            EntityMLibraryEventQuestStoryGroupingTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMLibraryEventQuestStoryGrouping[], EntityMLibraryEventQuestStoryGroupingTable>(data => new EntityMLibraryEventQuestStoryGroupingTable(data)));
            EntityMLibraryMovieTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMLibraryMovie[], EntityMLibraryMovieTable>(data => new EntityMLibraryMovieTable(data)));
            EntityMLibraryMovieCategoryTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMLibraryMovieCategory[], EntityMLibraryMovieCategoryTable>(data => new EntityMLibraryMovieCategoryTable(data)));
            EntityMLibraryMovieUnlockConditionTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMLibraryMovieUnlockCondition[], EntityMLibraryMovieUnlockConditionTable>(data => new EntityMLibraryMovieUnlockConditionTable(data)));
            EntityMLibraryRecordGroupingTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMLibraryRecordGrouping[], EntityMLibraryRecordGroupingTable>(data => new EntityMLibraryRecordGroupingTable(data)));
            EntityMLimitedOpenTextTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMLimitedOpenText[], EntityMLimitedOpenTextTable>(data => new EntityMLimitedOpenTextTable(data)));
            EntityMLimitedOpenTextGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMLimitedOpenTextGroup[], EntityMLimitedOpenTextGroupTable>(data => new EntityMLimitedOpenTextGroupTable(data)));
            EntityMLoginBonusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMLoginBonus[], EntityMLoginBonusTable>(data => new EntityMLoginBonusTable(data)));
            EntityMLoginBonusStampTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMLoginBonusStamp[], EntityMLoginBonusStampTable>(data => new EntityMLoginBonusStampTable(data)));
            EntityMMainQuestPortalCageCharacterTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMMainQuestPortalCageCharacter[], EntityMMainQuestPortalCageCharacterTable>(data => new EntityMMainQuestPortalCageCharacterTable(data)));
            EntityMMaintenanceTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMMaintenance[], EntityMMaintenanceTable>(data => new EntityMMaintenanceTable(data)));
            EntityMMaintenanceGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMMaintenanceGroup[], EntityMMaintenanceGroupTable>(data => new EntityMMaintenanceGroupTable(data)));
            EntityMMaterialSaleObtainPossessionTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMMaterialSaleObtainPossession[], EntityMMaterialSaleObtainPossessionTable>(data => new EntityMMaterialSaleObtainPossessionTable(data)));
            EntityMMissionTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMMission[], EntityMMissionTable>(data => new EntityMMissionTable(data)));
            EntityMMissionGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMMissionGroup[], EntityMMissionGroupTable>(data => new EntityMMissionGroupTable(data)));
            EntityMMissionLinkTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMMissionLink[], EntityMMissionLinkTable>(data => new EntityMMissionLinkTable(data)));
            EntityMMissionRewardTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMMissionReward[], EntityMMissionRewardTable>(data => new EntityMMissionRewardTable(data)));
            EntityMMissionTermTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMMissionTerm[], EntityMMissionTermTable>(data => new EntityMMissionTermTable(data)));
            EntityMMissionUnlockConditionTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMMissionUnlockCondition[], EntityMMissionUnlockConditionTable>(data => new EntityMMissionUnlockConditionTable(data)));
            EntityMMomBannerTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMMomBanner[], EntityMMomBannerTable>(data => new EntityMMomBannerTable(data)));
            EntityMMovieTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMMovie[], EntityMMovieTable>(data => new EntityMMovieTable(data)));
            EntityMNaviCutInTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMNaviCutIn[], EntityMNaviCutInTable>(data => new EntityMNaviCutInTable(data)));
            EntityMNaviCutInContentGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMNaviCutInContentGroup[], EntityMNaviCutInContentGroupTable>(data => new EntityMNaviCutInContentGroupTable(data)));
            EntityMNaviCutInTextTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMNaviCutInText[], EntityMNaviCutInTextTable>(data => new EntityMNaviCutInTextTable(data)));
            EntityMNumericalParameterMapTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMNumericalParameterMap[], EntityMNumericalParameterMapTable>(data => new EntityMNumericalParameterMapTable(data)));
            EntityMOmikujiTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMOmikuji[], EntityMOmikujiTable>(data => new EntityMOmikujiTable(data)));
            EntityMOverrideHitEffectConditionCriticalTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMOverrideHitEffectConditionCritical[], EntityMOverrideHitEffectConditionCriticalTable>(data => new EntityMOverrideHitEffectConditionCriticalTable(data)));
            EntityMOverrideHitEffectConditionDamageAttributeTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMOverrideHitEffectConditionDamageAttribute[], EntityMOverrideHitEffectConditionDamageAttributeTable>(data => new EntityMOverrideHitEffectConditionDamageAttributeTable(data)));
            EntityMOverrideHitEffectConditionGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMOverrideHitEffectConditionGroup[], EntityMOverrideHitEffectConditionGroupTable>(data => new EntityMOverrideHitEffectConditionGroupTable(data)));
            EntityMOverrideHitEffectConditionSkillExecutorTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMOverrideHitEffectConditionSkillExecutor[], EntityMOverrideHitEffectConditionSkillExecutorTable>(data => new EntityMOverrideHitEffectConditionSkillExecutorTable(data)));
            EntityMPartsEnhancedSubStatusTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMPartsEnhancedSubStatus[], EntityMPartsEnhancedSubStatusTable>(data => new EntityMPartsEnhancedSubStatusTable(data)));
            EntityMPartsLevelUpPriceGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMPartsLevelUpPriceGroup[], EntityMPartsLevelUpPriceGroupTable>(data => new EntityMPartsLevelUpPriceGroupTable(data)));
            EntityMPartsLevelUpRateGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMPartsLevelUpRateGroup[], EntityMPartsLevelUpRateGroupTable>(data => new EntityMPartsLevelUpRateGroupTable(data)));
            EntityMPartsRarityTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMPartsRarity[], EntityMPartsRarityTable>(data => new EntityMPartsRarityTable(data)));
            EntityMPlatformPaymentPriceTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMPlatformPaymentPrice[], EntityMPlatformPaymentPriceTable>(data => new EntityMPlatformPaymentPriceTable(data)));
            EntityMPortalCageAccessPointFunctionGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMPortalCageAccessPointFunctionGroup[], EntityMPortalCageAccessPointFunctionGroupTable>(data => new EntityMPortalCageAccessPointFunctionGroupTable(data)));
            EntityMPortalCageAccessPointFunctionGroupScheduleTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMPortalCageAccessPointFunctionGroupSchedule[], EntityMPortalCageAccessPointFunctionGroupScheduleTable>(data => new EntityMPortalCageAccessPointFunctionGroupScheduleTable(data)));
            EntityMPortalCageCharacterGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMPortalCageCharacterGroup[], EntityMPortalCageCharacterGroupTable>(data => new EntityMPortalCageCharacterGroupTable(data)));
            EntityMPortalCageGateTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMPortalCageGate[], EntityMPortalCageGateTable>(data => new EntityMPortalCageGateTable(data)));
            EntityMPortalCageSceneTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMPortalCageScene[], EntityMPortalCageSceneTable>(data => new EntityMPortalCageSceneTable(data)));
            EntityMPossessionAcquisitionRouteTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMPossessionAcquisitionRoute[], EntityMPossessionAcquisitionRouteTable>(data => new EntityMPossessionAcquisitionRouteTable(data)));
            EntityMPvpBackgroundTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMPvpBackground[], EntityMPvpBackgroundTable>(data => new EntityMPvpBackgroundTable(data)));
            EntityMPvpGradeTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMPvpGrade[], EntityMPvpGradeTable>(data => new EntityMPvpGradeTable(data)));
            EntityMPvpGradeGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMPvpGradeGroup[], EntityMPvpGradeGroupTable>(data => new EntityMPvpGradeGroupTable(data)));
            EntityMPvpGradeOneMatchRewardTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMPvpGradeOneMatchReward[], EntityMPvpGradeOneMatchRewardTable>(data => new EntityMPvpGradeOneMatchRewardTable(data)));
            EntityMPvpGradeOneMatchRewardGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMPvpGradeOneMatchRewardGroup[], EntityMPvpGradeOneMatchRewardGroupTable>(data => new EntityMPvpGradeOneMatchRewardGroupTable(data)));
            EntityMPvpGradeWeeklyRewardGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMPvpGradeWeeklyRewardGroup[], EntityMPvpGradeWeeklyRewardGroupTable>(data => new EntityMPvpGradeWeeklyRewardGroupTable(data)));
            EntityMPvpRewardTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMPvpReward[], EntityMPvpRewardTable>(data => new EntityMPvpRewardTable(data)));
            EntityMPvpSeasonTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMPvpSeason[], EntityMPvpSeasonTable>(data => new EntityMPvpSeasonTable(data)));
            EntityMPvpSeasonGradeTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMPvpSeasonGrade[], EntityMPvpSeasonGradeTable>(data => new EntityMPvpSeasonGradeTable(data)));
            EntityMPvpSeasonGroupingTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMPvpSeasonGrouping[], EntityMPvpSeasonGroupingTable>(data => new EntityMPvpSeasonGroupingTable(data)));
            EntityMPvpSeasonRankRewardTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMPvpSeasonRankReward[], EntityMPvpSeasonRankRewardTable>(data => new EntityMPvpSeasonRankRewardTable(data)));
            EntityMPvpSeasonRankRewardGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMPvpSeasonRankRewardGroup[], EntityMPvpSeasonRankRewardGroupTable>(data => new EntityMPvpSeasonRankRewardGroupTable(data)));
            EntityMPvpSeasonRankRewardPerSeasonTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMPvpSeasonRankRewardPerSeason[], EntityMPvpSeasonRankRewardPerSeasonTable>(data => new EntityMPvpSeasonRankRewardPerSeasonTable(data)));
            EntityMPvpSeasonRankRewardRankGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMPvpSeasonRankRewardRankGroup[], EntityMPvpSeasonRankRewardRankGroupTable>(data => new EntityMPvpSeasonRankRewardRankGroupTable(data)));
            EntityMPvpWeeklyRankRewardGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMPvpWeeklyRankRewardGroup[], EntityMPvpWeeklyRankRewardGroupTable>(data => new EntityMPvpWeeklyRankRewardGroupTable(data)));
            EntityMPvpWeeklyRankRewardRankGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMPvpWeeklyRankRewardRankGroup[], EntityMPvpWeeklyRankRewardRankGroupTable>(data => new EntityMPvpWeeklyRankRewardRankGroupTable(data)));
            EntityMPvpWinStreakCountEffectTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMPvpWinStreakCountEffect[], EntityMPvpWinStreakCountEffectTable>(data => new EntityMPvpWinStreakCountEffectTable(data)));
            EntityMQuestBonusAbilityTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuestBonusAbility[], EntityMQuestBonusAbilityTable>(data => new EntityMQuestBonusAbilityTable(data)));
            EntityMQuestBonusCostumeGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuestBonusCostumeGroup[], EntityMQuestBonusCostumeGroupTable>(data => new EntityMQuestBonusCostumeGroupTable(data)));
            EntityMQuestBonusDropRewardTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuestBonusDropReward[], EntityMQuestBonusDropRewardTable>(data => new EntityMQuestBonusDropRewardTable(data)));
            EntityMQuestBonusEffectGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuestBonusEffectGroup[], EntityMQuestBonusEffectGroupTable>(data => new EntityMQuestBonusEffectGroupTable(data)));
            EntityMQuestBonusExpTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuestBonusExp[], EntityMQuestBonusExpTable>(data => new EntityMQuestBonusExpTable(data)));
            EntityMQuestCampaignTargetItemGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuestCampaignTargetItemGroup[], EntityMQuestCampaignTargetItemGroupTable>(data => new EntityMQuestCampaignTargetItemGroupTable(data)));
            EntityMQuestDeckRestrictionGroupUnlockTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuestDeckRestrictionGroupUnlock[], EntityMQuestDeckRestrictionGroupUnlockTable>(data => new EntityMQuestDeckRestrictionGroupUnlockTable(data)));
            EntityMQuestMissionRewardTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuestMissionReward[], EntityMQuestMissionRewardTable>(data => new EntityMQuestMissionRewardTable(data)));
            EntityMQuestPickupRewardGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuestPickupRewardGroup[], EntityMQuestPickupRewardGroupTable>(data => new EntityMQuestPickupRewardGroupTable(data)));
            EntityMQuestRelationMainFlowTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuestRelationMainFlow[], EntityMQuestRelationMainFlowTable>(data => new EntityMQuestRelationMainFlowTable(data)));
            EntityMQuestReleaseConditionQuestChallengeTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuestReleaseConditionQuestChallenge[], EntityMQuestReleaseConditionQuestChallengeTable>(data => new EntityMQuestReleaseConditionQuestChallengeTable(data)));
            EntityMQuestReplayFlowRewardGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuestReplayFlowRewardGroup[], EntityMQuestReplayFlowRewardGroupTable>(data => new EntityMQuestReplayFlowRewardGroupTable(data)));
            EntityMQuestSceneNotConfirmTitleDialogTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuestSceneNotConfirmTitleDialog[], EntityMQuestSceneNotConfirmTitleDialogTable>(data => new EntityMQuestSceneNotConfirmTitleDialogTable(data)));
            EntityMQuestSceneOutgameBlendshapeMotionTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuestSceneOutgameBlendshapeMotion[], EntityMQuestSceneOutgameBlendshapeMotionTable>(data => new EntityMQuestSceneOutgameBlendshapeMotionTable(data)));
            EntityMReportTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMReport[], EntityMReportTable>(data => new EntityMReportTable(data)));
            EntityMShopDisplayPriceTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMShopDisplayPrice[], EntityMShopDisplayPriceTable>(data => new EntityMShopDisplayPriceTable(data)));
            EntityMShopItemAdditionalContentTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMShopItemAdditionalContent[], EntityMShopItemAdditionalContentTable>(data => new EntityMShopItemAdditionalContentTable(data)));
            EntityMShopItemCellLimitedOpenTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMShopItemCellLimitedOpen[], EntityMShopItemCellLimitedOpenTable>(data => new EntityMShopItemCellLimitedOpenTable(data)));
            EntityMShopItemContentEffectTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMShopItemContentEffect[], EntityMShopItemContentEffectTable>(data => new EntityMShopItemContentEffectTable(data)));
            EntityMShopItemContentMissionTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMShopItemContentMission[], EntityMShopItemContentMissionTable>(data => new EntityMShopItemContentMissionTable(data)));
            EntityMShopItemUserLevelConditionTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMShopItemUserLevelCondition[], EntityMShopItemUserLevelConditionTable>(data => new EntityMShopItemUserLevelConditionTable(data)));
            EntityMShopReplaceableGemTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMShopReplaceableGem[], EntityMShopReplaceableGemTable>(data => new EntityMShopReplaceableGemTable(data)));
            EntityMSideStoryQuestTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSideStoryQuest[], EntityMSideStoryQuestTable>(data => new EntityMSideStoryQuestTable(data)));
            EntityMSideStoryQuestLimitContentTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSideStoryQuestLimitContent[], EntityMSideStoryQuestLimitContentTable>(data => new EntityMSideStoryQuestLimitContentTable(data)));
            EntityMSideStoryQuestSceneTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSideStoryQuestScene[], EntityMSideStoryQuestSceneTable>(data => new EntityMSideStoryQuestSceneTable(data)));
            EntityMSkillAbnormalTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillAbnormal[], EntityMSkillAbnormalTable>(data => new EntityMSkillAbnormalTable(data)));
            EntityMSkillAbnormalBehaviourTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillAbnormalBehaviour[], EntityMSkillAbnormalBehaviourTable>(data => new EntityMSkillAbnormalBehaviourTable(data)));
            EntityMSkillAbnormalBehaviourActionAbnormalResistanceTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillAbnormalBehaviourActionAbnormalResistance[], EntityMSkillAbnormalBehaviourActionAbnormalResistanceTable>(data => new EntityMSkillAbnormalBehaviourActionAbnormalResistanceTable(data)));
            EntityMSkillAbnormalBehaviourActionAttributeDamageCorrectionTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillAbnormalBehaviourActionAttributeDamageCorrection[], EntityMSkillAbnormalBehaviourActionAttributeDamageCorrectionTable>(data => new EntityMSkillAbnormalBehaviourActionAttributeDamageCorrectionTable(data)));
            EntityMSkillAbnormalBehaviourActionBuffResistanceTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillAbnormalBehaviourActionBuffResistance[], EntityMSkillAbnormalBehaviourActionBuffResistanceTable>(data => new EntityMSkillAbnormalBehaviourActionBuffResistanceTable(data)));
            EntityMSkillAbnormalBehaviourActionDamageTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillAbnormalBehaviourActionDamage[], EntityMSkillAbnormalBehaviourActionDamageTable>(data => new EntityMSkillAbnormalBehaviourActionDamageTable(data)));
            EntityMSkillAbnormalBehaviourActionDamageMultiplyTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillAbnormalBehaviourActionDamageMultiply[], EntityMSkillAbnormalBehaviourActionDamageMultiplyTable>(data => new EntityMSkillAbnormalBehaviourActionDamageMultiplyTable(data)));
            EntityMSkillAbnormalBehaviourActionDamageMultiplyDetailAlwaysTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillAbnormalBehaviourActionDamageMultiplyDetailAlways[], EntityMSkillAbnormalBehaviourActionDamageMultiplyDetailAlwaysTable>(data => new EntityMSkillAbnormalBehaviourActionDamageMultiplyDetailAlwaysTable(data)));
            EntityMSkillAbnormalBehaviourActionDefaultSkillLotteryTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillAbnormalBehaviourActionDefaultSkillLottery[], EntityMSkillAbnormalBehaviourActionDefaultSkillLotteryTable>(data => new EntityMSkillAbnormalBehaviourActionDefaultSkillLotteryTable(data)));
            EntityMSkillAbnormalBehaviourActionHitRatioDownTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillAbnormalBehaviourActionHitRatioDown[], EntityMSkillAbnormalBehaviourActionHitRatioDownTable>(data => new EntityMSkillAbnormalBehaviourActionHitRatioDownTable(data)));
            EntityMSkillAbnormalBehaviourActionModifyHateValueTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillAbnormalBehaviourActionModifyHateValue[], EntityMSkillAbnormalBehaviourActionModifyHateValueTable>(data => new EntityMSkillAbnormalBehaviourActionModifyHateValueTable(data)));
            EntityMSkillAbnormalBehaviourActionOverrideHitEffectTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillAbnormalBehaviourActionOverrideHitEffect[], EntityMSkillAbnormalBehaviourActionOverrideHitEffectTable>(data => new EntityMSkillAbnormalBehaviourActionOverrideHitEffectTable(data)));
            EntityMSkillAbnormalBehaviourActionRecoveryTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillAbnormalBehaviourActionRecovery[], EntityMSkillAbnormalBehaviourActionRecoveryTable>(data => new EntityMSkillAbnormalBehaviourActionRecoveryTable(data)));
            EntityMSkillAbnormalBehaviourActionTurnRestrictionTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillAbnormalBehaviourActionTurnRestriction[], EntityMSkillAbnormalBehaviourActionTurnRestrictionTable>(data => new EntityMSkillAbnormalBehaviourActionTurnRestrictionTable(data)));
            EntityMSkillAbnormalBehaviourGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillAbnormalBehaviourGroup[], EntityMSkillAbnormalBehaviourGroupTable>(data => new EntityMSkillAbnormalBehaviourGroupTable(data)));
            EntityMSkillAbnormalDamageMultiplyDetailAbnormalTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillAbnormalDamageMultiplyDetailAbnormal[], EntityMSkillAbnormalDamageMultiplyDetailAbnormalTable>(data => new EntityMSkillAbnormalDamageMultiplyDetailAbnormalTable(data)));
            EntityMSkillAbnormalDamageMultiplyDetailBuffAttachedTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillAbnormalDamageMultiplyDetailBuffAttached[], EntityMSkillAbnormalDamageMultiplyDetailBuffAttachedTable>(data => new EntityMSkillAbnormalDamageMultiplyDetailBuffAttachedTable(data)));
            EntityMSkillAbnormalDamageMultiplyDetailCriticalTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillAbnormalDamageMultiplyDetailCritical[], EntityMSkillAbnormalDamageMultiplyDetailCriticalTable>(data => new EntityMSkillAbnormalDamageMultiplyDetailCriticalTable(data)));
            EntityMSkillAbnormalDamageMultiplyDetailHitIndexTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillAbnormalDamageMultiplyDetailHitIndex[], EntityMSkillAbnormalDamageMultiplyDetailHitIndexTable>(data => new EntityMSkillAbnormalDamageMultiplyDetailHitIndexTable(data)));
            EntityMSkillAbnormalDamageMultiplyDetailSkillfulWeaponTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillAbnormalDamageMultiplyDetailSkillfulWeapon[], EntityMSkillAbnormalDamageMultiplyDetailSkillfulWeaponTable>(data => new EntityMSkillAbnormalDamageMultiplyDetailSkillfulWeaponTable(data)));
            EntityMSkillAbnormalLifetimeTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillAbnormalLifetime[], EntityMSkillAbnormalLifetimeTable>(data => new EntityMSkillAbnormalLifetimeTable(data)));
            EntityMSkillAbnormalLifetimeBehaviourActivateCountTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillAbnormalLifetimeBehaviourActivateCount[], EntityMSkillAbnormalLifetimeBehaviourActivateCountTable>(data => new EntityMSkillAbnormalLifetimeBehaviourActivateCountTable(data)));
            EntityMSkillAbnormalLifetimeBehaviourFrameCountTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillAbnormalLifetimeBehaviourFrameCount[], EntityMSkillAbnormalLifetimeBehaviourFrameCountTable>(data => new EntityMSkillAbnormalLifetimeBehaviourFrameCountTable(data)));
            EntityMSkillAbnormalLifetimeBehaviourGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillAbnormalLifetimeBehaviourGroup[], EntityMSkillAbnormalLifetimeBehaviourGroupTable>(data => new EntityMSkillAbnormalLifetimeBehaviourGroupTable(data)));
            EntityMSkillAbnormalLifetimeBehaviourReceiveDamageCountTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillAbnormalLifetimeBehaviourReceiveDamageCount[], EntityMSkillAbnormalLifetimeBehaviourReceiveDamageCountTable>(data => new EntityMSkillAbnormalLifetimeBehaviourReceiveDamageCountTable(data)));
            EntityMSkillAbnormalLifetimeBehaviourTurnCountTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillAbnormalLifetimeBehaviourTurnCount[], EntityMSkillAbnormalLifetimeBehaviourTurnCountTable>(data => new EntityMSkillAbnormalLifetimeBehaviourTurnCountTable(data)));
            EntityMSkillBehaviourActionAbnormalTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillBehaviourActionAbnormal[], EntityMSkillBehaviourActionAbnormalTable>(data => new EntityMSkillBehaviourActionAbnormalTable(data)));
            EntityMSkillBehaviourActionActiveSkillDamageCorrectionTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillBehaviourActionActiveSkillDamageCorrection[], EntityMSkillBehaviourActionActiveSkillDamageCorrectionTable>(data => new EntityMSkillBehaviourActionActiveSkillDamageCorrectionTable(data)));
            EntityMSkillBehaviourActionAdvanceActiveSkillCooltimeTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillBehaviourActionAdvanceActiveSkillCooltime[], EntityMSkillBehaviourActionAdvanceActiveSkillCooltimeTable>(data => new EntityMSkillBehaviourActionAdvanceActiveSkillCooltimeTable(data)));
            EntityMSkillBehaviourActionAdvanceActiveSkillCooltimeImmediateTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillBehaviourActionAdvanceActiveSkillCooltimeImmediate[], EntityMSkillBehaviourActionAdvanceActiveSkillCooltimeImmediateTable>(data => new EntityMSkillBehaviourActionAdvanceActiveSkillCooltimeImmediateTable(data)));
            EntityMSkillBehaviourActionAttackTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillBehaviourActionAttack[], EntityMSkillBehaviourActionAttackTable>(data => new EntityMSkillBehaviourActionAttackTable(data)));
            EntityMSkillBehaviourActionAttackComboTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillBehaviourActionAttackCombo[], EntityMSkillBehaviourActionAttackComboTable>(data => new EntityMSkillBehaviourActionAttackComboTable(data)));
            EntityMSkillBehaviourActionAttackFixedDamageTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillBehaviourActionAttackFixedDamage[], EntityMSkillBehaviourActionAttackFixedDamageTable>(data => new EntityMSkillBehaviourActionAttackFixedDamageTable(data)));
            EntityMSkillBehaviourActionAttackHpRatioTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillBehaviourActionAttackHpRatio[], EntityMSkillBehaviourActionAttackHpRatioTable>(data => new EntityMSkillBehaviourActionAttackHpRatioTable(data)));
            EntityMSkillBehaviourActionAttackIgnoreVitalityTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillBehaviourActionAttackIgnoreVitality[], EntityMSkillBehaviourActionAttackIgnoreVitalityTable>(data => new EntityMSkillBehaviourActionAttackIgnoreVitalityTable(data)));
            EntityMSkillBehaviourActionAttackVitalityTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillBehaviourActionAttackVitality[], EntityMSkillBehaviourActionAttackVitalityTable>(data => new EntityMSkillBehaviourActionAttackVitalityTable(data)));
            EntityMSkillBehaviourActionAttributeDamageCorrectionTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillBehaviourActionAttributeDamageCorrection[], EntityMSkillBehaviourActionAttributeDamageCorrectionTable>(data => new EntityMSkillBehaviourActionAttributeDamageCorrectionTable(data)));
            EntityMSkillBehaviourActionBuffTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillBehaviourActionBuff[], EntityMSkillBehaviourActionBuffTable>(data => new EntityMSkillBehaviourActionBuffTable(data)));
            EntityMSkillBehaviourActionChangestepTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillBehaviourActionChangestep[], EntityMSkillBehaviourActionChangestepTable>(data => new EntityMSkillBehaviourActionChangestepTable(data)));
            EntityMSkillBehaviourActionDamageCorrectionHpRatioTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillBehaviourActionDamageCorrectionHpRatio[], EntityMSkillBehaviourActionDamageCorrectionHpRatioTable>(data => new EntityMSkillBehaviourActionDamageCorrectionHpRatioTable(data)));
            EntityMSkillBehaviourActionDamageMultiplyTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillBehaviourActionDamageMultiply[], EntityMSkillBehaviourActionDamageMultiplyTable>(data => new EntityMSkillBehaviourActionDamageMultiplyTable(data)));
            EntityMSkillBehaviourActionDefaultSkillLotteryTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillBehaviourActionDefaultSkillLottery[], EntityMSkillBehaviourActionDefaultSkillLotteryTable>(data => new EntityMSkillBehaviourActionDefaultSkillLotteryTable(data)));
            EntityMSkillBehaviourActionHpRatioDamageTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillBehaviourActionHpRatioDamage[], EntityMSkillBehaviourActionHpRatioDamageTable>(data => new EntityMSkillBehaviourActionHpRatioDamageTable(data)));
            EntityMSkillBehaviourActionRecoveryTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillBehaviourActionRecovery[], EntityMSkillBehaviourActionRecoveryTable>(data => new EntityMSkillBehaviourActionRecoveryTable(data)));
            EntityMSkillBehaviourActionRemoveAbnormalTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillBehaviourActionRemoveAbnormal[], EntityMSkillBehaviourActionRemoveAbnormalTable>(data => new EntityMSkillBehaviourActionRemoveAbnormalTable(data)));
            EntityMSkillBehaviourActionRemoveBuffTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillBehaviourActionRemoveBuff[], EntityMSkillBehaviourActionRemoveBuffTable>(data => new EntityMSkillBehaviourActionRemoveBuffTable(data)));
            EntityMSkillBehaviourActionShortenActiveSkillCooltimeTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillBehaviourActionShortenActiveSkillCooltime[], EntityMSkillBehaviourActionShortenActiveSkillCooltimeTable>(data => new EntityMSkillBehaviourActionShortenActiveSkillCooltimeTable(data)));
            EntityMSkillBehaviourActionSkillRecoveryPowerCorrectionTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillBehaviourActionSkillRecoveryPowerCorrection[], EntityMSkillBehaviourActionSkillRecoveryPowerCorrectionTable>(data => new EntityMSkillBehaviourActionSkillRecoveryPowerCorrectionTable(data)));
            EntityMSkillBehaviourActivationConditionActivationUpperCountTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillBehaviourActivationConditionActivationUpperCount[], EntityMSkillBehaviourActivationConditionActivationUpperCountTable>(data => new EntityMSkillBehaviourActivationConditionActivationUpperCountTable(data)));
            EntityMSkillBehaviourActivationConditionAttributeTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillBehaviourActivationConditionAttribute[], EntityMSkillBehaviourActivationConditionAttributeTable>(data => new EntityMSkillBehaviourActivationConditionAttributeTable(data)));
            EntityMSkillBehaviourActivationConditionGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillBehaviourActivationConditionGroup[], EntityMSkillBehaviourActivationConditionGroupTable>(data => new EntityMSkillBehaviourActivationConditionGroupTable(data)));
            EntityMSkillBehaviourActivationConditionHpRatioTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillBehaviourActivationConditionHpRatio[], EntityMSkillBehaviourActivationConditionHpRatioTable>(data => new EntityMSkillBehaviourActivationConditionHpRatioTable(data)));
            EntityMSkillBehaviourActivationConditionInSkillFlowTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillBehaviourActivationConditionInSkillFlow[], EntityMSkillBehaviourActivationConditionInSkillFlowTable>(data => new EntityMSkillBehaviourActivationConditionInSkillFlowTable(data)));
            EntityMSkillBehaviourActivationConditionWaveNumberTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillBehaviourActivationConditionWaveNumber[], EntityMSkillBehaviourActivationConditionWaveNumberTable>(data => new EntityMSkillBehaviourActivationConditionWaveNumberTable(data)));
            EntityMSkillBuffTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillBuff[], EntityMSkillBuffTable>(data => new EntityMSkillBuffTable(data)));
            EntityMSkillCasttimeTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillCasttime[], EntityMSkillCasttimeTable>(data => new EntityMSkillCasttimeTable(data)));
            EntityMSkillCasttimeBehaviourTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillCasttimeBehaviour[], EntityMSkillCasttimeBehaviourTable>(data => new EntityMSkillCasttimeBehaviourTable(data)));
            EntityMSkillCasttimeBehaviourActionOnFrameUpdateTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillCasttimeBehaviourActionOnFrameUpdate[], EntityMSkillCasttimeBehaviourActionOnFrameUpdateTable>(data => new EntityMSkillCasttimeBehaviourActionOnFrameUpdateTable(data)));
            EntityMSkillCasttimeBehaviourActionOnSkillDamageConditionTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillCasttimeBehaviourActionOnSkillDamageCondition[], EntityMSkillCasttimeBehaviourActionOnSkillDamageConditionTable>(data => new EntityMSkillCasttimeBehaviourActionOnSkillDamageConditionTable(data)));
            EntityMSkillCasttimeBehaviourGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillCasttimeBehaviourGroup[], EntityMSkillCasttimeBehaviourGroupTable>(data => new EntityMSkillCasttimeBehaviourGroupTable(data)));
            EntityMSkillCooltimeAdvanceValueOnDefaultSkillGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillCooltimeAdvanceValueOnDefaultSkillGroup[], EntityMSkillCooltimeAdvanceValueOnDefaultSkillGroupTable>(data => new EntityMSkillCooltimeAdvanceValueOnDefaultSkillGroupTable(data)));
            EntityMSkillCooltimeBehaviourTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillCooltimeBehaviour[], EntityMSkillCooltimeBehaviourTable>(data => new EntityMSkillCooltimeBehaviourTable(data)));
            EntityMSkillCooltimeBehaviourGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillCooltimeBehaviourGroup[], EntityMSkillCooltimeBehaviourGroupTable>(data => new EntityMSkillCooltimeBehaviourGroupTable(data)));
            EntityMSkillCooltimeBehaviourOnExecuteActiveSkillTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillCooltimeBehaviourOnExecuteActiveSkill[], EntityMSkillCooltimeBehaviourOnExecuteActiveSkillTable>(data => new EntityMSkillCooltimeBehaviourOnExecuteActiveSkillTable(data)));
            EntityMSkillCooltimeBehaviourOnExecuteCompanionSkillTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillCooltimeBehaviourOnExecuteCompanionSkill[], EntityMSkillCooltimeBehaviourOnExecuteCompanionSkillTable>(data => new EntityMSkillCooltimeBehaviourOnExecuteCompanionSkillTable(data)));
            EntityMSkillCooltimeBehaviourOnExecuteDefaultSkillTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillCooltimeBehaviourOnExecuteDefaultSkill[], EntityMSkillCooltimeBehaviourOnExecuteDefaultSkillTable>(data => new EntityMSkillCooltimeBehaviourOnExecuteDefaultSkillTable(data)));
            EntityMSkillCooltimeBehaviourOnFrameUpdateTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillCooltimeBehaviourOnFrameUpdate[], EntityMSkillCooltimeBehaviourOnFrameUpdateTable>(data => new EntityMSkillCooltimeBehaviourOnFrameUpdateTable(data)));
            EntityMSkillCooltimeBehaviourOnSkillDamageTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillCooltimeBehaviourOnSkillDamage[], EntityMSkillCooltimeBehaviourOnSkillDamageTable>(data => new EntityMSkillCooltimeBehaviourOnSkillDamageTable(data)));
            EntityMSkillDamageMultiplyAbnormalAttachedValueGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillDamageMultiplyAbnormalAttachedValueGroup[], EntityMSkillDamageMultiplyAbnormalAttachedValueGroupTable>(data => new EntityMSkillDamageMultiplyAbnormalAttachedValueGroupTable(data)));
            EntityMSkillDamageMultiplyDetailAbnormalAttachedTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillDamageMultiplyDetailAbnormalAttached[], EntityMSkillDamageMultiplyDetailAbnormalAttachedTable>(data => new EntityMSkillDamageMultiplyDetailAbnormalAttachedTable(data)));
            EntityMSkillDamageMultiplyDetailAlwaysTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillDamageMultiplyDetailAlways[], EntityMSkillDamageMultiplyDetailAlwaysTable>(data => new EntityMSkillDamageMultiplyDetailAlwaysTable(data)));
            EntityMSkillDamageMultiplyDetailBuffAttachedTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillDamageMultiplyDetailBuffAttached[], EntityMSkillDamageMultiplyDetailBuffAttachedTable>(data => new EntityMSkillDamageMultiplyDetailBuffAttachedTable(data)));
            EntityMSkillDamageMultiplyDetailCriticalTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillDamageMultiplyDetailCritical[], EntityMSkillDamageMultiplyDetailCriticalTable>(data => new EntityMSkillDamageMultiplyDetailCriticalTable(data)));
            EntityMSkillDamageMultiplyDetailHitIndexTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillDamageMultiplyDetailHitIndex[], EntityMSkillDamageMultiplyDetailHitIndexTable>(data => new EntityMSkillDamageMultiplyDetailHitIndexTable(data)));
            EntityMSkillDamageMultiplyDetailSkillfulWeaponTypeTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillDamageMultiplyDetailSkillfulWeaponType[], EntityMSkillDamageMultiplyDetailSkillfulWeaponTypeTable>(data => new EntityMSkillDamageMultiplyDetailSkillfulWeaponTypeTable(data)));
            EntityMSkillDamageMultiplyHitIndexValueGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillDamageMultiplyHitIndexValueGroup[], EntityMSkillDamageMultiplyHitIndexValueGroupTable>(data => new EntityMSkillDamageMultiplyHitIndexValueGroupTable(data)));
            EntityMSkillRemoveAbnormalTargetAbnormalGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillRemoveAbnormalTargetAbnormalGroup[], EntityMSkillRemoveAbnormalTargetAbnormalGroupTable>(data => new EntityMSkillRemoveAbnormalTargetAbnormalGroupTable(data)));
            EntityMSkillRemoveBuffFilterStatusKindTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillRemoveBuffFilterStatusKind[], EntityMSkillRemoveBuffFilterStatusKindTable>(data => new EntityMSkillRemoveBuffFilterStatusKindTable(data)));
            EntityMSkillReserveUiTypeTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillReserveUiType[], EntityMSkillReserveUiTypeTable>(data => new EntityMSkillReserveUiTypeTable(data)));
            EntityMSmartphoneChatGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSmartphoneChatGroup[], EntityMSmartphoneChatGroupTable>(data => new EntityMSmartphoneChatGroupTable(data)));
            EntityMSmartphoneChatGroupMessageTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSmartphoneChatGroupMessage[], EntityMSmartphoneChatGroupMessageTable>(data => new EntityMSmartphoneChatGroupMessageTable(data)));
            EntityMSpeakerTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSpeaker[], EntityMSpeakerTable>(data => new EntityMSpeakerTable(data)));
            EntityMTipTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMTip[], EntityMTipTable>(data => new EntityMTipTable(data)));
            EntityMTipBackgroundAssetTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMTipBackgroundAsset[], EntityMTipBackgroundAssetTable>(data => new EntityMTipBackgroundAssetTable(data)));
            EntityMTipDisplayConditionGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMTipDisplayConditionGroup[], EntityMTipDisplayConditionGroupTable>(data => new EntityMTipDisplayConditionGroupTable(data)));
            EntityMTipGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMTipGroup[], EntityMTipGroupTable>(data => new EntityMTipGroupTable(data)));
            EntityMTipGroupBackgroundAssetTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMTipGroupBackgroundAsset[], EntityMTipGroupBackgroundAssetTable>(data => new EntityMTipGroupBackgroundAssetTable(data)));
            EntityMTipGroupBackgroundAssetRelationTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMTipGroupBackgroundAssetRelation[], EntityMTipGroupBackgroundAssetRelationTable>(data => new EntityMTipGroupBackgroundAssetRelationTable(data)));
            EntityMTipGroupSelectionTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMTipGroupSelection[], EntityMTipGroupSelectionTable>(data => new EntityMTipGroupSelectionTable(data)));
            EntityMTipGroupSituationTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMTipGroupSituation[], EntityMTipGroupSituationTable>(data => new EntityMTipGroupSituationTable(data)));
            EntityMTipGroupSituationSeasonTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMTipGroupSituationSeason[], EntityMTipGroupSituationSeasonTable>(data => new EntityMTipGroupSituationSeasonTable(data)));
            EntityMTitleFlowMovieTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMTitleFlowMovie[], EntityMTitleFlowMovieTable>(data => new EntityMTitleFlowMovieTable(data)));
            EntityMTitleStillTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMTitleStill[], EntityMTitleStillTable>(data => new EntityMTitleStillTable(data)));
            EntityMTitleStillGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMTitleStillGroup[], EntityMTitleStillGroupTable>(data => new EntityMTitleStillGroupTable(data)));
            EntityMTutorialDialogTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMTutorialDialog[], EntityMTutorialDialogTable>(data => new EntityMTutorialDialogTable(data)));
            EntityMTutorialUnlockConditionTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMTutorialUnlockCondition[], EntityMTutorialUnlockConditionTable>(data => new EntityMTutorialUnlockConditionTable(data)));
            EntityMUserLevelTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMUserLevel[], EntityMUserLevelTable>(data => new EntityMUserLevelTable(data)));
            EntityMUserQuestSceneGrantPossessionTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMUserQuestSceneGrantPossession[], EntityMUserQuestSceneGrantPossessionTable>(data => new EntityMUserQuestSceneGrantPossessionTable(data)));
            EntityMWeaponAbilityEnhancementMaterialTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMWeaponAbilityEnhancementMaterial[], EntityMWeaponAbilityEnhancementMaterialTable>(data => new EntityMWeaponAbilityEnhancementMaterialTable(data)));
            EntityMWeaponConsumeExchangeConsumableItemGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMWeaponConsumeExchangeConsumableItemGroup[], EntityMWeaponConsumeExchangeConsumableItemGroupTable>(data => new EntityMWeaponConsumeExchangeConsumableItemGroupTable(data)));
            EntityMWeaponEnhancedAbilityTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMWeaponEnhancedAbility[], EntityMWeaponEnhancedAbilityTable>(data => new EntityMWeaponEnhancedAbilityTable(data)));
            EntityMWeaponEnhancedSkillTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMWeaponEnhancedSkill[], EntityMWeaponEnhancedSkillTable>(data => new EntityMWeaponEnhancedSkillTable(data)));
            EntityMWeaponEvolutionMaterialGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMWeaponEvolutionMaterialGroup[], EntityMWeaponEvolutionMaterialGroupTable>(data => new EntityMWeaponEvolutionMaterialGroupTable(data)));
            EntityMWeaponRarityLimitBreakMaterialGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMWeaponRarityLimitBreakMaterialGroup[], EntityMWeaponRarityLimitBreakMaterialGroupTable>(data => new EntityMWeaponRarityLimitBreakMaterialGroupTable(data)));
            EntityMWeaponSkillEnhancementMaterialTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMWeaponSkillEnhancementMaterial[], EntityMWeaponSkillEnhancementMaterialTable>(data => new EntityMWeaponSkillEnhancementMaterialTable(data)));
            EntityMWeaponSpecificLimitBreakMaterialGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMWeaponSpecificLimitBreakMaterialGroup[], EntityMWeaponSpecificLimitBreakMaterialGroupTable>(data => new EntityMWeaponSpecificLimitBreakMaterialGroupTable(data)));
            EntityMWeaponStoryReleaseConditionGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMWeaponStoryReleaseConditionGroup[], EntityMWeaponStoryReleaseConditionGroupTable>(data => new EntityMWeaponStoryReleaseConditionGroupTable(data)));
            EntityMWeaponStoryReleaseConditionOperationTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMWeaponStoryReleaseConditionOperation[], EntityMWeaponStoryReleaseConditionOperationTable>(data => new EntityMWeaponStoryReleaseConditionOperationTable(data)));
            EntityMWeaponStoryReleaseConditionOperationGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMWeaponStoryReleaseConditionOperationGroup[], EntityMWeaponStoryReleaseConditionOperationGroupTable>(data => new EntityMWeaponStoryReleaseConditionOperationGroupTable(data)));
            EntityMWebviewMissionTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMWebviewMission[], EntityMWebviewMissionTable>(data => new EntityMWebviewMissionTable(data)));
            EntityMWebviewMissionTitleTextTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMWebviewMissionTitleText[], EntityMWebviewMissionTitleTextTable>(data => new EntityMWebviewMissionTitleTextTable(data)));
            EntityMWebviewPanelMissionTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMWebviewPanelMission[], EntityMWebviewPanelMissionTable>(data => new EntityMWebviewPanelMissionTable(data)));
            EntityMWebviewPanelMissionCompleteFlavorTextTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMWebviewPanelMissionCompleteFlavorText[], EntityMWebviewPanelMissionCompleteFlavorTextTable>(data => new EntityMWebviewPanelMissionCompleteFlavorTextTable(data)));
            EntityMWebviewPanelMissionPageTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMWebviewPanelMissionPage[], EntityMWebviewPanelMissionPageTable>(data => new EntityMWebviewPanelMissionPageTable(data)));
            EntityMBattleCostumeSkillFireActTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleCostumeSkillFireAct[], EntityMBattleCostumeSkillFireActTable>(data => new EntityMBattleCostumeSkillFireActTable(data)));
            EntityMBattleNpcWeaponAbilityReevaluateTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleNpcWeaponAbilityReevaluate[], EntityMBattleNpcWeaponAbilityReevaluateTable>(data => new EntityMBattleNpcWeaponAbilityReevaluateTable(data)));
            EntityMBattleNpcWeaponNoteReevaluateTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleNpcWeaponNoteReevaluate[], EntityMBattleNpcWeaponNoteReevaluateTable>(data => new EntityMBattleNpcWeaponNoteReevaluateTable(data)));
            EntityMBattleSkillFireActTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleSkillFireAct[], EntityMBattleSkillFireActTable>(data => new EntityMBattleSkillFireActTable(data)));
            EntityMBattleSkillFireActConditionAttributeTypeTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleSkillFireActConditionAttributeType[], EntityMBattleSkillFireActConditionAttributeTypeTable>(data => new EntityMBattleSkillFireActConditionAttributeTypeTable(data)));
            EntityMBattleSkillFireActConditionGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleSkillFireActConditionGroup[], EntityMBattleSkillFireActConditionGroupTable>(data => new EntityMBattleSkillFireActConditionGroupTable(data)));
            EntityMBattleSkillFireActConditionSkillCategoryTypeTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleSkillFireActConditionSkillCategoryType[], EntityMBattleSkillFireActConditionSkillCategoryTypeTable>(data => new EntityMBattleSkillFireActConditionSkillCategoryTypeTable(data)));
            EntityMBattleSkillFireActConditionWeaponTypeTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleSkillFireActConditionWeaponType[], EntityMBattleSkillFireActConditionWeaponTypeTable>(data => new EntityMBattleSkillFireActConditionWeaponTypeTable(data)));
            EntityMCostumeSpecialActActiveSkillConditionAttributeTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCostumeSpecialActActiveSkillConditionAttribute[], EntityMCostumeSpecialActActiveSkillConditionAttributeTable>(data => new EntityMCostumeSpecialActActiveSkillConditionAttributeTable(data)));
            EntityMEventQuestDailyGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMEventQuestDailyGroup[], EntityMEventQuestDailyGroupTable>(data => new EntityMEventQuestDailyGroupTable(data)));
            EntityMEventQuestDailyGroupCompleteRewardTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMEventQuestDailyGroupCompleteReward[], EntityMEventQuestDailyGroupCompleteRewardTable>(data => new EntityMEventQuestDailyGroupCompleteRewardTable(data)));
            EntityMEventQuestDailyGroupMessageTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMEventQuestDailyGroupMessage[], EntityMEventQuestDailyGroupMessageTable>(data => new EntityMEventQuestDailyGroupMessageTable(data)));
            EntityMEventQuestDailyGroupTargetChapterTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMEventQuestDailyGroupTargetChapter[], EntityMEventQuestDailyGroupTargetChapterTable>(data => new EntityMEventQuestDailyGroupTargetChapterTable(data)));
            EntityMListSettingAbilityGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMListSettingAbilityGroup[], EntityMListSettingAbilityGroupTable>(data => new EntityMListSettingAbilityGroupTable(data)));
            EntityMListSettingAbilityGroupTargetTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMListSettingAbilityGroupTarget[], EntityMListSettingAbilityGroupTargetTable>(data => new EntityMListSettingAbilityGroupTargetTable(data)));
            EntityMMissionClearConditionValueViewTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMMissionClearConditionValueView[], EntityMMissionClearConditionValueViewTable>(data => new EntityMMissionClearConditionValueViewTable(data)));
            EntityMMissionSubCategoryTextTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMMissionSubCategoryText[], EntityMMissionSubCategoryTextTable>(data => new EntityMMissionSubCategoryTextTable(data)));
            EntityMMomPointBannerTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMMomPointBanner[], EntityMMomPointBannerTable>(data => new EntityMMomPointBannerTable(data)));
            EntityMSkillBehaviourActionAttackMainWeaponAttributeTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillBehaviourActionAttackMainWeaponAttribute[], EntityMSkillBehaviourActionAttackMainWeaponAttributeTable>(data => new EntityMSkillBehaviourActionAttackMainWeaponAttributeTable(data)));
            EntityMStainedGlassTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMStainedGlass[], EntityMStainedGlassTable>(data => new EntityMStainedGlassTable(data)));
            EntityMStainedGlassStatusUpGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMStainedGlassStatusUpGroup[], EntityMStainedGlassStatusUpGroupTable>(data => new EntityMStainedGlassStatusUpGroupTable(data)));
            EntityMStainedGlassStatusUpTargetGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMStainedGlassStatusUpTargetGroup[], EntityMStainedGlassStatusUpTargetGroupTable>(data => new EntityMStainedGlassStatusUpTargetGroupTable(data)));
            EntityMAppealDialogTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMAppealDialog[], EntityMAppealDialogTable>(data => new EntityMAppealDialogTable(data)));
            EntityMLibraryMainQuestGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMLibraryMainQuestGroup[], EntityMLibraryMainQuestGroupTable>(data => new EntityMLibraryMainQuestGroupTable(data)));
            EntityMLibraryMainQuestStoryTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMLibraryMainQuestStory[], EntityMLibraryMainQuestStoryTable>(data => new EntityMLibraryMainQuestStoryTable(data)));
            EntityMQuestSceneChoiceTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuestSceneChoice[], EntityMQuestSceneChoiceTable>(data => new EntityMQuestSceneChoiceTable(data)));
            EntityMQuestSceneChoiceCostumeEffectGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuestSceneChoiceCostumeEffectGroup[], EntityMQuestSceneChoiceCostumeEffectGroupTable>(data => new EntityMQuestSceneChoiceCostumeEffectGroupTable(data)));
            EntityMQuestSceneChoiceEffectTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuestSceneChoiceEffect[], EntityMQuestSceneChoiceEffectTable>(data => new EntityMQuestSceneChoiceEffectTable(data)));
            EntityMQuestSceneChoiceWeaponEffectGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuestSceneChoiceWeaponEffectGroup[], EntityMQuestSceneChoiceWeaponEffectGroupTable>(data => new EntityMQuestSceneChoiceWeaponEffectGroupTable(data)));
            EntityMSkillBehaviourActionAttackClampHpTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillBehaviourActionAttackClampHp[], EntityMSkillBehaviourActionAttackClampHpTable>(data => new EntityMSkillBehaviourActionAttackClampHpTable(data)));
            EntityMBattleNpcCharacterRebirthTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleNpcCharacterRebirth[], EntityMBattleNpcCharacterRebirthTable>(data => new EntityMBattleNpcCharacterRebirthTable(data)));
            EntityMBattleNpcWeaponAwakenTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMBattleNpcWeaponAwaken[], EntityMBattleNpcWeaponAwakenTable>(data => new EntityMBattleNpcWeaponAwakenTable(data)));
            EntityMCharacterRebirthTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCharacterRebirth[], EntityMCharacterRebirthTable>(data => new EntityMCharacterRebirthTable(data)));
            EntityMCharacterRebirthMaterialGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCharacterRebirthMaterialGroup[], EntityMCharacterRebirthMaterialGroupTable>(data => new EntityMCharacterRebirthMaterialGroupTable(data)));
            EntityMCharacterRebirthStepGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMCharacterRebirthStepGroup[], EntityMCharacterRebirthStepGroupTable>(data => new EntityMCharacterRebirthStepGroupTable(data)));
            EntityMEventQuestLabyrinthMobTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMEventQuestLabyrinthMob[], EntityMEventQuestLabyrinthMobTable>(data => new EntityMEventQuestLabyrinthMobTable(data)));
            EntityMEventQuestLabyrinthQuestDisplayTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMEventQuestLabyrinthQuestDisplay[], EntityMEventQuestLabyrinthQuestDisplayTable>(data => new EntityMEventQuestLabyrinthQuestDisplayTable(data)));
            EntityMEventQuestLabyrinthQuestEffectDescriptionAbilityTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMEventQuestLabyrinthQuestEffectDescriptionAbility[], EntityMEventQuestLabyrinthQuestEffectDescriptionAbilityTable>(data => new EntityMEventQuestLabyrinthQuestEffectDescriptionAbilityTable(data)));
            EntityMEventQuestLabyrinthQuestEffectDescriptionFreeTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMEventQuestLabyrinthQuestEffectDescriptionFree[], EntityMEventQuestLabyrinthQuestEffectDescriptionFreeTable>(data => new EntityMEventQuestLabyrinthQuestEffectDescriptionFreeTable(data)));
            EntityMEventQuestLabyrinthQuestEffectDisplayTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMEventQuestLabyrinthQuestEffectDisplay[], EntityMEventQuestLabyrinthQuestEffectDisplayTable>(data => new EntityMEventQuestLabyrinthQuestEffectDisplayTable(data)));
            EntityMEventQuestLabyrinthRewardGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMEventQuestLabyrinthRewardGroup[], EntityMEventQuestLabyrinthRewardGroupTable>(data => new EntityMEventQuestLabyrinthRewardGroupTable(data)));
            EntityMEventQuestLabyrinthSeasonTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMEventQuestLabyrinthSeason[], EntityMEventQuestLabyrinthSeasonTable>(data => new EntityMEventQuestLabyrinthSeasonTable(data)));
            EntityMEventQuestLabyrinthSeasonRewardGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMEventQuestLabyrinthSeasonRewardGroup[], EntityMEventQuestLabyrinthSeasonRewardGroupTable>(data => new EntityMEventQuestLabyrinthSeasonRewardGroupTable(data)));
            EntityMEventQuestLabyrinthStageTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMEventQuestLabyrinthStage[], EntityMEventQuestLabyrinthStageTable>(data => new EntityMEventQuestLabyrinthStageTable(data)));
            EntityMEventQuestLabyrinthStageAccumulationRewardGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMEventQuestLabyrinthStageAccumulationRewardGroup[], EntityMEventQuestLabyrinthStageAccumulationRewardGroupTable>(data => new EntityMEventQuestLabyrinthStageAccumulationRewardGroupTable(data)));
            EntityMQuestBonusAllyCharacterTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMQuestBonusAllyCharacter[], EntityMQuestBonusAllyCharacterTable>(data => new EntityMQuestBonusAllyCharacterTable(data)));
            EntityMSkillBehaviourActionAttackSkillfulMainWeaponTypeTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMSkillBehaviourActionAttackSkillfulMainWeaponType[], EntityMSkillBehaviourActionAttackSkillfulMainWeaponTypeTable>(data => new EntityMSkillBehaviourActionAttackSkillfulMainWeaponTypeTable(data)));
            EntityMWeaponAwakenTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMWeaponAwaken[], EntityMWeaponAwakenTable>(data => new EntityMWeaponAwakenTable(data)));
            EntityMWeaponAwakenAbilityTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMWeaponAwakenAbility[], EntityMWeaponAwakenAbilityTable>(data => new EntityMWeaponAwakenAbilityTable(data)));
            EntityMWeaponAwakenEffectGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMWeaponAwakenEffectGroup[], EntityMWeaponAwakenEffectGroupTable>(data => new EntityMWeaponAwakenEffectGroupTable(data)));
            EntityMWeaponAwakenMaterialGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMWeaponAwakenMaterialGroup[], EntityMWeaponAwakenMaterialGroupTable>(data => new EntityMWeaponAwakenMaterialGroupTable(data)));
            EntityMWeaponAwakenStatusUpGroupTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMWeaponAwakenStatusUpGroup[], EntityMWeaponAwakenStatusUpGroupTable>(data => new EntityMWeaponAwakenStatusUpGroupTable(data)));
            EntityMWeaponFieldEffectDecreasePointTable = ExtractTableData(header, databaseBinary, options, new Func<EntityMWeaponFieldEffectDecreasePoint[], EntityMWeaponFieldEffectDecreasePointTable>(data => new EntityMWeaponFieldEffectDecreasePointTable(data)));
        }
    }
}
