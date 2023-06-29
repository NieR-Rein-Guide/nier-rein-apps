namespace NierReincarnation.Core.Dark.Networking
{
    // Dark.Networking.Config
    public static class Config
    {
        private const string ConsumableItemIdForGoldKey = "CONSUMABLE_ITEM_ID_FOR_GOLD"; // 0x0
        private const string ConsumableItemIdForMedalKey = "CONSUMABLE_ITEM_ID_FOR_MEDAL"; // 0x8
        private const string ConsumableItemIdForRareMedalKey = "CONSUMABLE_ITEM_ID_FOR_RARE_MEDAL"; // 0x10
        private const string ConsumableItemIdForArenaCoinKey = "CONSUMABLE_ITEM_ID_FOR_ARENA_COIN"; // 0x18
        private const string ConsumableItemIdForExploreTicketKey = "CONSUMABLE_ITEM_ID_FOR_EXPLORE_TICKET"; // 0x20
        private const string ConsumableItemIdForQuestSkipTicketKey = "CONSUMABLE_ITEM_ID_FOR_QUEST_SKIP_TICKET"; // 0x28
        private const string PvpMaxBattlePointKey = "PVP_MAX_BATTLE_POINT"; // 0x30
        private const string PvpBattleConsumeBattlePointKey = "PVP_BATTLE_CONSUME_BATTLE_POINT"; // 0x38
        private const string PvpUpdateMatchingBattlePointKey = "PVP_UPDATE_MATCHING_CONSUME_BATTLE_POINT"; // 0x40
        private const string StaminaRecoverySecondKey = "USER_STAMINA_RECOVERY_SECOND"; // 0x48
        private const string BattlePointRecoverySecondKey = "USER_BATTLE_POINT_RECOVERY_SECOND"; // 0x50
        private const string CostumeLimitBreakAvailableCountKey = "COSTUME_LIMIT_BREAK_AVAILABLE_COUNT"; // 0x58
        private const string WeaponLimitBreakAvailableCountKey = "WEAPON_LIMIT_BREAK_AVAILABLE_COUNT"; // 0x60
        private const string CostumeAwakenAvailableCount = "COSTUME_AWAKEN_AVAILABLE_COUNT"; // 0x68
        private const string MaterialSameWeaponExpCoefficientPermilKey = "MATERIAL_SAME_WEAPON_EXP_COEFFICIENT_PERMIL"; // 0x70
        private const string WeaponEnhanceCalcCoefficientPermilKey = "WEAPON_ENHANCE_CALC_COEFFICIENT_PERMIL"; // 0x78
        private const string WeaponSellPriceCalcFixedValuePermilKey = "WEAPON_SELL_PRICE_CALC_FIXED_VALUE_PERMIL"; // 0x80
        private const string GiftReceivedListTotalCountKey = "GIFT_RECEIVED_LIST_TOTAL_COUNT"; // 0x88
        private const string UserNameMaxLength = "USER_NAME_MAX_LENGTH"; // 0x90
        private const string UserNameMinLength = "USER_NAME_MIN_LENGTH"; // 0x98
        private const string UserMessageMaxLength = "USER_MESSAGE_MAX_LENGTH"; // 0xA0
        private const string UserMessageMinLength = "USER_MESSAGE_MIN_LENGTH"; // 0xA8
        private const string DeckNameMaxLength = "DECK_NAME_MAX_LENGTH"; // 0xB0
        private const string DeckNameMinLength = "DECK_NAME_MIN_LENGTH"; // 0xB8
        private const string UserLevelExpNumericalParameterMapId = "USER_LEVEL_EXP_NUMERICAL_PARAMETER_MAP_ID"; // 0xC0
        private const string GrpcTimeoutMilliseconds = "GRPC_TIMEOUT_MILLISECONDS"; // 0xC8
        private const string ExplorePlayIntervalMinuteKey = "EXPLORE_PLAY_INTERVAL_MINUTE"; // 0xD0
        private const string HeaderNoticeCountApiInterval = "API_CALL_INTERVAL_SECOND_FOR_HEADER_NOTICE_COUNT"; // 0xD8
        private const string UnlockPvpQuestId = "FUNCTION_UNLOCK_QUEST_ID_FOR_PVP"; // 0xE0
        private const string UnlockPartsQuestId = "FUNCTION_UNLOCK_QUEST_ID_FOR_PARTS"; // 0xE8
        private const string UnlockMapQuestId = "FUNCTION_UNLOCK_QUEST_ID_FOR_MAP"; // 0xF0
        private const string UnlockMapItemFullQuestId = "FUNCTION_UNLOCK_QUEST_ID_FOR_MAP_ITEM_FULL"; // 0xF8
        private const string UnlockCompanionQuestId = "FUNCTION_UNLOCK_QUEST_ID_FOR_COMPANION"; // 0x100
        private const string UnlockTutorialMenuChapterId = "FUNCTION_UNLOCK_CHAPTER_ID_FOR_MENU"; // 0x108
        private const string UnlockEventQuestMenuQuestId = "FUNCTION_UNLOCK_QUEST_ID_FOR_EVENT_QUEST"; // 0x110
        private const string UnlockCharacterBoardQuestId = "FUNCTION_UNLOCK_QUEST_ID_FOR_CHARACTER_BOARD"; // 0x118
        private const string UnlockCharacterViewerQuestId = "FUNCTION_UNLOCK_QUEST_ID_FOR_CHARACTER_VIEWER"; // 0x120
        private const string PortalCageSceneId = "PORTAL_CAGE_SCENE_ID"; // 0x128
        private const string PortalCageFunctionUnlockQuestIdForPortalCage = "FUNCTION_UNLOCK_QUEST_ID_FOR_PORTAL_CAGE"; // 0x130
        private const string MissionTapTargetActorId = "MISSION_TAP_TARGET_ACTOR_ID"; // 0x138
        private const string MamaTapCountInterval = "MAMA_TAP_COUNT_INTERVAL"; // 0x140
        private const string PurchaseAlertThresholdMoney = "PURCHASE_ALERT_THRESHOLD_MONEY"; // 0x148
        private const string TutorialSortCharacterId = "TUTORIAL_SORT_CHARACTER_ID"; // 0x150
        private const string TutorialSortWeaponId = "TUTORIAL_SORT_WEAPON_ID"; // 0x158
        private const string InitialUserQuestSceneId = "INITIAL_USER_QUEST_SCENE_ID"; // 0x160
        private const string EnhanceConsumableWeaponCountAtOnce = "ENHANCE_CONSUMABLE_WEAPON_COUNT_AT_ONCE"; // 0x168
        private const string PossessionCountLimitMaterial = "POSSESSION_COUNT_LIMIT_MATERIAL"; // 0x170
        private const string PossessionCountLimitConsumableItem = "POSSESSION_COUNT_LIMIT_CONSUMABLE_ITEM"; // 0x178
        private const string PossessionCountLimitGoldAndCoin = "POSSESSION_COUNT_LIMIT_MONEY"; // 0x180
        private const string PossessionCountLimitWeapon = "POSSESSION_COUNT_LIMIT_WEAPON"; // 0x188
        private const string PossessionCountLimitParts = "POSSESSION_COUNT_LIMIT_PARTS"; // 0x190
        private const string PossessionCountLimitImportantItem = "POSSESSION_COUNT_LIMIT_IMPORTANT_ITEM"; // 0x198
        private const string PossessionCountLimitStamina = "POSSESSION_COUNT_LIMIT_STAMINA"; // 0x1A0
        private const string PossessionCountLimitBp = "POSSESSION_COUNT_LIMIT_BP"; // 0x1A8
        private const string PossessionCountGachaMedal = "POSSESSION_COUNT_LIMIT_GACHA_MEDAL"; // 0x1B0
        private const string QuestRestartGraceTimeAfterEvent = "QUEST_RESTART_GRACE_TIME_AFTER_EVENT"; // 0x1B8
        private const string UnlockHardQuestId = "FUNCTION_UNLOCK_QUEST_ID_FOR_HARDQUEST"; // 0x1C0
        private const string UnlockVeryHardQuestId = "FUNCTION_UNLOCK_QUEST_ID_FOR_VERYHARDQUEST"; // 0x1C8
        private const string UserFriendReceiveCheerMaxNumber = "USER_FRIEND_RECEIVE_CHEER_MAX_NUMBER"; // 0x1D0
        private const string UserFriendSendCheerMaxNumber = "USER_FRIEND_SEND_CHEER_MAX_NUMBER"; // 0x1D8
        private const string UseTierPriceFlag = "USE_TIER_PRICE_FLAG"; // 0x1E0
        private const string LoseFirstThresholdQuestId = "LOSE_FIRST_THRESHOLD_QUEST_ID"; // 0x1E8
        private const string LoseFirstMinimumThresholdQuestId = "LOSE_FIRST_MINIMUM_THRESHOLD_QUEST_ID"; // 0x1F0
        private const string LoseFirstThresholdAfterChapterQuestId = "FUNCTION_LOSE_FIRST_THRESHOLD_AFTER_CHAPTER_QUEST_ID"; // 0x1F8
        private const string QuestMissionBigWinBonusPower = "QUEST_MISSION_BIG_WIN_BONUS_POWER"; // 0x200
        private const string UnlockBigHuntQuestId = "FUNCTION_UNLOCK_QUEST_ID_FOR_BIG_HUNT"; // 0x208
        private const string QuestSkipMaxCountAtOnce = "QUEST_SKIP_MAX_COUNT_AT_ONCE"; // 0x210
        private const string UnlockQuestSkipQuestId = "FUNCTION_UNLOCK_QUEST_ID_FOR_QUEST_SKIP"; // 0x218
        private const string UnlockDailyGachaQuestId = "FUNCTION_UNLOCK_QUEST_ID_FOR_DAILY_GACHA"; // 0x220
        private const string UnlockDailyQuestQuestId = "FUNCTION_UNLOCK_QUEST_ID_FOR_DAILY_QUEST"; // 0x228
        private const string UnlockBrokenObeliskQuestId = "FUNCTION_UNLOCK_QUEST_ID_BROKEN_OBELISK"; // 0x230
        private const string MemoryPresetNameMinLength = "PARTS_PRESET_NAME_MIN_LENGTH"; // 0x238
        private const string MemoryPresetNameMaxLength = "PARTS_PRESET_NAME_MAX_LENGTH"; // 0x240
        private const string MemoryPresetTagNameMinLength = "PARTS_PRESET_TAG_NAME_MIN_LENGTH"; // 0x248
        private const string MemoryPresetTagNameMaxLength = "PARTS_PRESET_TAG_NAME_MAX_LENGTH"; // 0x250
        private const string UnlockBigHuntBoardEvaluateConditionId = "FUNCTION_UNLOCK_EVALUATE_CONDITION_ID_FOR_BIG_HUNT_BOARD"; // 0x258
        private const string NecessaryGemCountForGuerrillaOpen = "NECESSARY_GEM_COUNT_FOR_GUERRILLA_OPEN"; // 0x260
        private const string PossessionSellCountLimitAtOnce = "POSSESSION_SELL_COUNT_LIMIT_AT_ONCE"; // 0x268
        private const string MaterialMaxSalableCountAtOnce = "MATERIAL_MAX_SALABLE_COUNT_AT_ONCE"; // 0x270
        private const string ConsumableItemMaxSalableCountAtOnce = "CONSUMABLE_ITEM_MAX_SALABLE_COUNT_AT_ONCE"; // 0x278
        private const string LimitedShopId = "LIMITED_SHOP_ID"; // 0x280
        private const string UnlockDressupCostumeQuestId = "FUNCTION_UNLOCK_QUEST_ID_FOR_DRESSUP_COSTUME"; // 0x288
        private const string EndQuestTutorialWebViewPlayGuideId = "END_QUEST_TUTORIAL_WEB_VIEW_PLAY_GUIDE_ID"; // 0x290
        private const string LimitQuestTutorialWebViewPlayGuideId = "LIMIT_QUEST_TUTORIAL_WEB_VIEW_PLAY_GUIDE_ID"; // 0x298
        private const string UnDailyMissionV2 = "FUNCTION_UNLOCK_QUEST_ID_FOR_DAILY_MISSION_V2"; // 0x2A0
        private const string SwitchRewardReceiveFlowDateMilliSecondForBigHunt = "SWITCH_REWARD_RECEIVE_FLOW_DATE_MILLI_SECOND_FOR_BIG_HUNT"; // 0x2A8
        private const string SwitchRewardReceiveFlowDateMilliSecondForPvp = "SWITCH_REWARD_RECEIVE_FLOW_DATE_MILLI_SECOND_FOR_PVP"; // 0x2B0
        private const string ConsumableItemIdForMomPointKey = "CONSUMABLE_ITEM_ID_FOR_MOM_POINT"; // 0x2B8
        private const string MomPointShopId = "MOM_POINT_SHOP_ID"; // 0x2C0
        private const string MomPointOpenDateMilliSecond = "MOM_POINT_OPEN_DATE_MILLI_SECOND"; // 0x2C8
        private const string ConsumableItemIdForPremiumGachaTicket = "CONSUMABLE_ITEM_ID_FOR_PREMIUM_GACHA_TICKET"; // 0x2D0
        private const string CharacterRebirthAvailableCount = "CHARACTER_REBIRTH_AVAILABLE_COUNT"; // 0x2D8
        private const string CharacterRebirthConsumeGold = "CHARACTER_REBIRTH_CONSUME_GOLD"; // 0x2E0
        private const string CostumeGrowthCurveCoefficientThreshold = "COSTUME_STATUS_FUNCTION_THRESHOLD_LEVEL"; // 0x2E8
        private const string CostumeGrowthCurveCoefficient = "COSTUME_STATUS_FUNCTION_THRESHOLD_OVER_COEFFICIENT"; // 0x2F0
        private const string WeaponGrowthCurveCoefficientThreshold = "WEAPON_STATUS_FUNCTION_THRESHOLD_LEVEL"; // 0x2F8
        private const string WeaponGrowthCurveCoefficient = "WEAPON_STATUS_FUNCTION_THRESHOLD_OVER_COEFFICIENT"; // 0x300
        private const string AutoOrganizationBlessAdditionalCoefficientApplyThreshold = "AUTO_ORGANIZATION_BRESS_ADDITIONAL_COEFFICIENT_APPLY_THRESHOLD"; // 0x300
        private const string AutoOrganizationBlessAdditionalCoefficient = "AUTO_ORGANIZATION_BRESS_ADDITIONAL_COEFFICIENT_PERMIL"; // 0x300

        // RVA: 0x298DDAC Offset: 0x298DDAC VA: 0x298DDAC
        public static int GetConsumableIdForGold()
        {
            return GetConfigIntValue(ConsumableItemIdForGoldKey);
        }

        // RVA: 0x298DEB8 Offset: 0x298DEB8 VA: 0x298DEB8
        public static int GetConsumableIdForMedal()
        {
            return GetConfigIntValue(ConsumableItemIdForMedalKey);
        }

        // RVA: 0x298DF20 Offset: 0x298DF20 VA: 0x298DF20
        public static int GetConsumableIdForRareMedal()
        {
            return GetConfigIntValue(ConsumableItemIdForRareMedalKey);
        }

        // RVA: 0x298DF88 Offset: 0x298DF88 VA: 0x298DF88
        public static int GetConsumableIdForArenaCoin()
        {
            return GetConfigIntValue(ConsumableItemIdForArenaCoinKey);
        }

        // RVA: 0x298DFF0 Offset: 0x298DFF0 VA: 0x298DFF0
        public static int GetConsumableItemIdForExploreTicket()
        {
            return GetConfigIntValue(ConsumableItemIdForExploreTicketKey);
        }

        // RVA: 0x298E058 Offset: 0x298E058 VA: 0x298E058
        public static int GetConsumableItemIdForQuestSkipTicket()
        {
            return GetConfigIntValue(ConsumableItemIdForQuestSkipTicketKey);
        }

        // RVA: 0x298E0C0 Offset: 0x298E0C0 VA: 0x298E0C0
        public static int GetMaxBattlePoint()
        {
            return GetConfigIntValue(PvpMaxBattlePointKey);
        }

        // RVA: 0x298E128 Offset: 0x298E128 VA: 0x298E128
        public static int GetBattleConsumeBattlePoint()
        {
            return GetConfigIntValue(PvpBattleConsumeBattlePointKey);
        }

        // RVA: 0x298E190 Offset: 0x298E190 VA: 0x298E190
        public static int GetUpdateMatchingConsumeBattlePoint()
        {
            return GetConfigIntValue(PvpUpdateMatchingBattlePointKey);
        }

        // RVA: 0x298E1F8 Offset: 0x298E1F8 VA: 0x298E1F8
        public static int GetStaminaRecoverySecond()
        {
            return GetConfigIntValue(StaminaRecoverySecondKey);
        }

        // RVA: 0x298E260 Offset: 0x298E260 VA: 0x298E260
        public static int GetBattlePointRecoverySecond()
        {
            return GetConfigIntValue(BattlePointRecoverySecondKey);
        }

        // RVA: 0x298E2C8 Offset: 0x298E2C8 VA: 0x298E2C8
        public static int GetCostumeLimitBreakAvailableCount()
        {
            return GetConfigIntValue(CostumeLimitBreakAvailableCountKey);
        }

        // RVA: 0x298E330 Offset: 0x298E330 VA: 0x298E330
        public static int GetWeaponLimitBreakAvailableCount()
        {
            return GetConfigIntValue(WeaponLimitBreakAvailableCountKey);
        }

        // RVA: 0x298E398 Offset: 0x298E398 VA: 0x298E398
        public static int GetCostumeAwakenAvailableCount()
        {
            return GetConfigIntValue(CostumeAwakenAvailableCount);
        }

        // RVA: 0x298E400 Offset: 0x298E400 VA: 0x298E400
        public static int GetMaterialSameWeaponExpCoefficientPermil()
        {
            return GetConfigIntValue(MaterialSameWeaponExpCoefficientPermilKey);
        }

        // RVA: 0x298E468 Offset: 0x298E468 VA: 0x298E468
        public static int GetWeaponEnhanceCalcCoefficientPermil()
        {
            return GetConfigIntValue(WeaponEnhanceCalcCoefficientPermilKey);
        }

        // RVA: 0x298E4D0 Offset: 0x298E4D0 VA: 0x298E4D0
        public static int GetGrpcTimeoutMilliseconds()
        {
            return GetConfigIntValue(GrpcTimeoutMilliseconds);
        }

        // RVA: 0x298E538 Offset: 0x298E538 VA: 0x298E538
        public static int GetUserNameMinLength()
        {
            return GetConfigIntValue(UserNameMinLength);
        }

        // RVA: 0x298E5A0 Offset: 0x298E5A0 VA: 0x298E5A0
        public static int GetUserNameMaxLength()
        {
            return GetConfigIntValue(UserNameMaxLength);
        }

        // RVA: 0x298E608 Offset: 0x298E608 VA: 0x298E608
        public static int GetUserMessageMinLength()
        {
            return GetConfigIntValue(UserMessageMinLength);
        }

        // RVA: 0x298E670 Offset: 0x298E670 VA: 0x298E670
        public static int GetUserMessageMaxLength()
        {
            return GetConfigIntValue(UserMessageMaxLength);
        }

        // RVA: 0x298E6D8 Offset: 0x298E6D8 VA: 0x298E6D8
        public static int GetDeckNameMinLength()
        {
            return GetConfigIntValue(DeckNameMinLength);
        }

        // RVA: 0x298E740 Offset: 0x298E740 VA: 0x298E740
        public static int GetDeckNameMaxLength()
        {
            return GetConfigIntValue(DeckNameMaxLength);
        }

        // RVA: 0x298E7A8 Offset: 0x298E7A8 VA: 0x298E7A8
        public static int GetUserLevelExpNumericalParameterMapId()
        {
            return GetConfigIntValue(UserLevelExpNumericalParameterMapId);
        }

        // RVA: 0x298E810 Offset: 0x298E810 VA: 0x298E810
        public static int GetExplorePlayIntervalMinute()
        {
            return GetConfigIntValue(ExplorePlayIntervalMinuteKey);
        }

        // RVA: 0x298E878 Offset: 0x298E878 VA: 0x298E878
        public static int GetHeaderNoticeCountApiInterval()
        {
            return GetConfigIntValue(HeaderNoticeCountApiInterval);
        }

        // RVA: 0x298E8E0 Offset: 0x298E8E0 VA: 0x298E8E0
        public static int GetUnlockPvpQuestId()
        {
            return GetConfigIntValue(UnlockPvpQuestId);
        }

        // RVA: 0x298E948 Offset: 0x298E948 VA: 0x298E948
        public static int GetUnlockPartsQuestId()
        {
            return GetConfigIntValue(UnlockPartsQuestId);
        }

        // RVA: 0x298E9B0 Offset: 0x298E9B0 VA: 0x298E9B0
        public static int GetUnlockMapQuestId()
        {
            return GetConfigIntValue(UnlockMapQuestId);
        }

        // RVA: 0x298EA18 Offset: 0x298EA18 VA: 0x298EA18
        public static int GetUnlockTutorialMenuChapterId()
        {
            return GetConfigIntValue(UnlockTutorialMenuChapterId);
        }

        // RVA: 0x298EA80 Offset: 0x298EA80 VA: 0x298EA80
        public static int GetUnlockEventQuestMenuQuestId()
        {
            return GetConfigIntValue(UnlockEventQuestMenuQuestId);
        }

        // RVA: 0x298EAE8 Offset: 0x298EAE8 VA: 0x298EAE8
        public static int GetUnlockCharacterBoardQuestId()
        {
            return GetConfigIntValue(UnlockCharacterBoardQuestId);
        }

        // RVA: 0x298EB50 Offset: 0x298EB50 VA: 0x298EB50
        public static int GetUnlockCharacterViewerQuestId()
        {
            return GetConfigIntValue(UnlockCharacterViewerQuestId);
        }

        // RVA: 0x298EBB8 Offset: 0x298EBB8 VA: 0x298EBB8
        public static int GetPortalCageSceneId()
        {
            return GetConfigIntValue(PortalCageSceneId);
        }

        // RVA: 0x298EC20 Offset: 0x298EC20 VA: 0x298EC20
        public static int GetPortalCageFunctionUnlockQuestIdForPortalCage()
        {
            return GetConfigIntValue(PortalCageFunctionUnlockQuestIdForPortalCage);
        }

        // RVA: 0x298EC88 Offset: 0x298EC88 VA: 0x298EC88
        public static int GetMomTapCountInterval()
        {
            return GetConfigIntValue(MamaTapCountInterval);
        }

        // RVA: 0x298ECF0 Offset: 0x298ECF0 VA: 0x298ECF0
        public static int GetPurchaseAlertThresholdMoney()
        {
            return GetConfigIntValue(PurchaseAlertThresholdMoney);
        }

        // RVA: 0x298ED58 Offset: 0x298ED58 VA: 0x298ED58
        public static int GetTutorialSortCharacterId()
        {
            return GetConfigIntValue(TutorialSortCharacterId);
        }

        // RVA: 0x298EDC0 Offset: 0x298EDC0 VA: 0x298EDC0
        public static int GetTutorialSortWeaponId()
        {
            return GetConfigIntValue(TutorialSortWeaponId);
        }

        // RVA: 0x298EE28 Offset: 0x298EE28 VA: 0x298EE28
        public static int GetInitialUserQuestSceneId()
        {
            return GetConfigIntValue(InitialUserQuestSceneId);
        }

        // RVA: 0x298EE90 Offset: 0x298EE90 VA: 0x298EE90
        public static int GetEnhanceConsumableWeaponCountAtOnce()
        {
            return GetConfigIntValue(EnhanceConsumableWeaponCountAtOnce);
        }

        // RVA: 0x298EEF8 Offset: 0x298EEF8 VA: 0x298EEF8
        public static int GetQuestRestartGraceTimeAfterEvent()
        {
            return GetConfigIntValue(QuestRestartGraceTimeAfterEvent);
        }

        // RVA: 0x298EF60 Offset: 0x298EF60 VA: 0x298EF60
        public static int GetUnlockHardQuestQuestId()
        {
            return GetConfigIntValue(UnlockHardQuestId);
        }

        // RVA: 0x298EFC8 Offset: 0x298EFC8 VA: 0x298EFC8
        public static int GetUnlockVeryHardQuestQuestId()
        {
            return GetConfigIntValue(UnlockVeryHardQuestId);
        }

        // RVA: 0x298F030 Offset: 0x298F030 VA: 0x298F030
        public static int GetLoseFirstThresholdQuestId()
        {
            return GetConfigIntValue(LoseFirstThresholdQuestId);
        }

        // RVA: 0x298F098 Offset: 0x298F098 VA: 0x298F098
        public static int GetLoseFirstMinimumThresholdQuestId()
        {
            return GetConfigIntValue(LoseFirstMinimumThresholdQuestId);
        }

        // RVA: 0x298F100 Offset: 0x298F100 VA: 0x298F100
        public static int GetLoseFirstThresholdAfterChapterQuestId()
        {
            return GetConfigIntValue(LoseFirstThresholdAfterChapterQuestId);
        }

        // RVA: 0x298F168 Offset: 0x298F168 VA: 0x298F168
        public static int GetUnlockBigHuntQuestId()
        {
            return GetConfigIntValue(UnlockBigHuntQuestId);
        }

        // RVA: 0x298F1D0 Offset: 0x298F1D0 VA: 0x298F1D0
        public static int GetQuestSkipMaxCountAtOnce()
        {
            return GetConfigIntValue(QuestSkipMaxCountAtOnce);
        }

        // RVA: 0x298F238 Offset: 0x298F238 VA: 0x298F238
        public static int GetUnlockQuestSkipQuestId()
        {
            return GetConfigIntValue(UnlockQuestSkipQuestId);
        }

        // RVA: 0x298F2A0 Offset: 0x298F2A0 VA: 0x298F2A0
        public static int GetUnlockDailyGachaId()
        {
            return GetConfigIntValue(UnlockDailyGachaQuestId);
        }

        // RVA: 0x298F308 Offset: 0x298F308 VA: 0x298F308
        public static int GetUnlockDailyQuestId()
        {
            return GetConfigIntValue(UnlockDailyQuestQuestId);
        }

        // RVA: 0x298F370 Offset: 0x298F370 VA: 0x298F370
        public static int GetPossessionCountLimitMaterial()
        {
            return GetConfigIntValue(PossessionCountLimitMaterial);
        }

        // RVA: 0x298F3D8 Offset: 0x298F3D8 VA: 0x298F3D8
        public static int GetPossessionCountLimitConsumableItem()
        {
            return GetConfigIntValue(PossessionCountLimitConsumableItem);
        }

        // RVA: 0x298F440 Offset: 0x298F440 VA: 0x298F440
        public static int GetPossessionCountLimitGoldAndCoin()
        {
            return GetConfigIntValue(PossessionCountLimitGoldAndCoin);
        }

        // RVA: 0x298F4A8 Offset: 0x298F4A8 VA: 0x298F4A8
        public static int GetPossessionCountLimitWeapon()
        {
            return GetConfigIntValue(PossessionCountLimitWeapon);
        }

        // RVA: 0x298F510 Offset: 0x298F510 VA: 0x298F510
        public static int GetPossessionCountLimitParts()
        {
            return GetConfigIntValue(PossessionCountLimitParts);
        }

        // RVA: 0x298F578 Offset: 0x298F578 VA: 0x298F578
        public static int GetPossessionCountLimitStamina()
        {
            return GetConfigIntValue(PossessionCountLimitStamina);
        }

        // RVA: 0x298F5E0 Offset: 0x298F5E0 VA: 0x298F5E0
        public static int GetPossessionCountLimitBp()
        {
            return GetConfigIntValue(PossessionCountLimitBp);
        }

        // RVA: 0x298F648 Offset: 0x298F648 VA: 0x298F648
        public static int GetPossessionCountGachaMedal()
        {
            return GetConfigIntValue(PossessionCountGachaMedal);
        }

        // RVA: 0x298F6B0 Offset: 0x298F6B0 VA: 0x298F6B0
        public static int GetUserFriendReceiveCheerMaxNumber()
        {
            return GetConfigIntValue(UserFriendReceiveCheerMaxNumber);
        }

        // RVA: 0x298F718 Offset: 0x298F718 VA: 0x298F718
        public static int GeUserFriendSendCheerMaxNumber()
        {
            return GetConfigIntValue(UserFriendSendCheerMaxNumber);
        }

        // RVA: 0x298F780 Offset: 0x298F780 VA: 0x298F780
        public static bool IsUseTierPrice()
        {
            return GetConfigBoolValue(UseTierPriceFlag);
        }

        // RVA: 0x298F890 Offset: 0x298F890 VA: 0x298F890
        public static int GetQuestMissionBigWinBonusPower()
        {
            return GetConfigIntValue(QuestMissionBigWinBonusPower);
        }

        // RVA: 0x298F8F8 Offset: 0x298F8F8 VA: 0x298F8F8
        public static int GetMemoryPresetNameMinLength()
        {
            return GetConfigIntValue(MemoryPresetNameMinLength);
        }

        // RVA: 0x298F960 Offset: 0x298F960 VA: 0x298F960
        public static int GetMemoryPresetNameMaxLength()
        {
            return GetConfigIntValue(MemoryPresetNameMaxLength);
        }

        // RVA: 0x298F9C8 Offset: 0x298F9C8 VA: 0x298F9C8
        public static int GetMemoryPresetTagNameMinLength()
        {
            return GetConfigIntValue(MemoryPresetTagNameMinLength);
        }

        // RVA: 0x298FA30 Offset: 0x298FA30 VA: 0x298FA30
        public static int GetMemoryPresetTagNameMaxLength()
        {
            return GetConfigIntValue(MemoryPresetTagNameMaxLength);
        }

        // RVA: 0x298FA98 Offset: 0x298FA98 VA: 0x298FA98
        public static int GetUnlockBigHuntBoardEvaluateConditionId()
        {
            return GetConfigIntValue(UnlockBigHuntBoardEvaluateConditionId);
        }

        // RVA: 0x298FB00 Offset: 0x298FB00 VA: 0x298FB00
        public static int GetNecessaryGemCountForGuerrillaOpen()
        {
            return GetConfigIntValue(NecessaryGemCountForGuerrillaOpen);
        }

        // RVA: 0x298FB68 Offset: 0x298FB68 VA: 0x298FB68
        public static int GetPossessionSellCountLimitAtOnce()
        {
            return GetConfigIntValue(PossessionSellCountLimitAtOnce);
        }

        // RVA: 0x298FBD0 Offset: 0x298FBD0 VA: 0x298FBD0
        public static int GetMaterialMaxSalableCountAtOnce()
        {
            return GetConfigIntValue(MaterialMaxSalableCountAtOnce);
        }

        // RVA: 0x298FC38 Offset: 0x298FC38 VA: 0x298FC38
        public static int GetConsumableItemMaxSalableCountAtOnce()
        {
            return GetConfigIntValue(ConsumableItemMaxSalableCountAtOnce);
        }

        // RVA: 0x298FCA0 Offset: 0x298FCA0 VA: 0x298FCA0
        public static int GetLimitedShopId()
        {
            return GetConfigIntValue(LimitedShopId);
        }

        // RVA: 0x298FD08 Offset: 0x298FD08 VA: 0x298FD08
        public static int GetUnlockDressupCostumeQuestId()
        {
            return GetConfigIntValue(UnlockDressupCostumeQuestId);
        }

        // RVA: 0x298FD70 Offset: 0x298FD70 VA: 0x298FD70
        public static int GetEndQuestTutorialWebViewPlayGuideId()
        {
            return GetConfigIntValue(EndQuestTutorialWebViewPlayGuideId);
        }

        // RVA: 0x298FDD8 Offset: 0x298FDD8 VA: 0x298FDD8
        public static int GetLimitQuestTutorialWebViewPlayGuideId()
        {
            return GetConfigIntValue(LimitQuestTutorialWebViewPlayGuideId);
        }

        // RVA: 0x298FE40 Offset: 0x298FE40 VA: 0x298FE40
        public static int GetUnlockDailyMissionV2Id()
        {
            return GetConfigIntValue(UnDailyMissionV2);
        }

        // RVA: 0x298FEA8 Offset: 0x298FEA8 VA: 0x298FEA8
        public static long GetSwitchRewardReceiveFlowDateMilliSecondForBigHunt()
        {
            return GetConfigIntValue(SwitchRewardReceiveFlowDateMilliSecondForBigHunt);
        }

        // RVA: 0x298FFB4 Offset: 0x298FFB4 VA: 0x298FFB4
        public static long GetSwitchRewardReceiveFlowDateMilliSecondForPvp()
        {
            return GetConfigIntValue(SwitchRewardReceiveFlowDateMilliSecondForPvp);
        }

        // RVA: 0x299001C Offset: 0x299001C VA: 0x299001C
        public static int GetConsumableIdForMomPoint()
        {
            return GetConfigIntValue(ConsumableItemIdForMomPointKey);
        }

        // RVA: 0x2990084 Offset: 0x2990084 VA: 0x2990084
        public static int GetMomPointShopId()
        {
            return GetConfigIntValue(MomPointShopId);
        }

        // RVA: 0x29900EC Offset: 0x29900EC VA: 0x29900EC
        public static long GetMomPointOpenDateMilliSecond()
        {
            return GetConfigIntValue(MomPointOpenDateMilliSecond);
        }

        // RVA: 0x2990154 Offset: 0x2990154 VA: 0x2990154
        public static int GetConsumableItemIdForPremiumGachaTicket()
        {
            return GetConfigIntValue(ConsumableItemIdForPremiumGachaTicket);
        }

        // RVA: 0x29901BC Offset: 0x29901BC VA: 0x29901BC
        public static int GetCharacterRebirthAvailableCount()
        {
            return GetConfigIntValue(CharacterRebirthAvailableCount);
        }

        // RVA: 0x2990224 Offset: 0x2990224 VA: 0x2990224
        public static int GetCharacterRebirthConsumeGold()
        {
            return GetConfigIntValue(CharacterRebirthConsumeGold);
        }

        // RVA: 0x299028C Offset: 0x299028C VA: 0x299028C
        public static int GetCostumeGrowthCoefficientThreshold()
        {
            return GetConfigIntValue(CostumeGrowthCurveCoefficientThreshold);
        }

        // RVA: 0x29902F4 Offset: 0x29902F4 VA: 0x29902F4
        public static int GetCostumeGrowthCoefficient()
        {
            return GetConfigIntValue(CostumeGrowthCurveCoefficient);
        }

        // RVA: 0x299035C Offset: 0x299035C VA: 0x299035C
        public static int GetWeaponGrowthCoefficientThreshold()
        {
            return GetConfigIntValue(WeaponGrowthCurveCoefficientThreshold);
        }

        // RVA: 0x29903C4 Offset: 0x29903C4 VA: 0x29903C4
        public static int GetWeaponGrowthCoefficient()
        {
            return GetConfigIntValue(WeaponGrowthCurveCoefficient);
        }

        // RVA: 0x27F2BB8 Offset: 0x27F2BB8 VA: 0x27F2BB8
        public static int GetAutoOrganizationBlessAdditionalCoefficientApplyThreshold()
        {
            return GetConfigIntValue(AutoOrganizationBlessAdditionalCoefficientApplyThreshold);
        }

        // RVA: 0x27F2C20 Offset: 0x27F2C20 VA: 0x27F2C20
        public static int GetAutoOrganizationBlessAdditionalCoefficient()
        {
            return GetConfigIntValue(AutoOrganizationBlessAdditionalCoefficient);
        }

        // RVA: 0x298DE14 Offset: 0x298DE14 VA: 0x298DE14
        private static int GetConfigIntValue(string key)
        {
            if (DatabaseDefine.Master == null)
                return 0;

            if (int.TryParse(DatabaseDefine.Master.EntityMConfigTable.FindByConfigKey(key).Value, out var configValue))
                return configValue;

            return 0;
        }

        // RVA: 0x298FF10 Offset: 0x298FF10 VA: 0x298FF10
        private static long GetConfigLongValue(string key)
        {
            if (DatabaseDefine.Master == null)
                return 0;

            if (long.TryParse(DatabaseDefine.Master.EntityMConfigTable.FindByConfigKey(key).Value, out var configValue))
                return configValue;

            return 0;
        }

        // RVA: 0x298F7E8 Offset: 0x298F7E8 VA: 0x298F7E8
        private static bool GetConfigBoolValue(string key)
        {
            if (DatabaseDefine.Master == null)
                return false;

            if (int.TryParse(DatabaseDefine.Master.EntityMConfigTable.FindByConfigKey(key).Value, out var configValue))
                return configValue == 1;

            return false;
        }
    }
}
