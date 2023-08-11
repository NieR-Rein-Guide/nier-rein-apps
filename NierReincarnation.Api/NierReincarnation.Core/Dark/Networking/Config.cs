namespace NierReincarnation.Core.Dark.Networking;

// Dark.Networking.Config
public static class Config
{
    private const string ConsumableItemIdForGoldKey = "CONSUMABLE_ITEM_ID_FOR_GOLD";
    private const string ConsumableItemIdForMedalKey = "CONSUMABLE_ITEM_ID_FOR_MEDAL";
    private const string ConsumableItemIdForRareMedalKey = "CONSUMABLE_ITEM_ID_FOR_RARE_MEDAL";
    private const string ConsumableItemIdForArenaCoinKey = "CONSUMABLE_ITEM_ID_FOR_ARENA_COIN";
    private const string ConsumableItemIdForExploreTicketKey = "CONSUMABLE_ITEM_ID_FOR_EXPLORE_TICKET";
    private const string ConsumableItemIdForQuestSkipTicketKey = "CONSUMABLE_ITEM_ID_FOR_QUEST_SKIP_TICKET";
    private const string PvpMaxBattlePointKey = "PVP_MAX_BATTLE_POINT";
    private const string PvpBattleConsumeBattlePointKey = "PVP_BATTLE_CONSUME_BATTLE_POINT";
    private const string PvpUpdateMatchingBattlePointKey = "PVP_UPDATE_MATCHING_CONSUME_BATTLE_POINT";
    private const string StaminaRecoverySecondKey = "USER_STAMINA_RECOVERY_SECOND";
    private const string BattlePointRecoverySecondKey = "USER_BATTLE_POINT_RECOVERY_SECOND";
    private const string CostumeLimitBreakAvailableCountKey = "COSTUME_LIMIT_BREAK_AVAILABLE_COUNT";
    private const string WeaponLimitBreakAvailableCountKey = "WEAPON_LIMIT_BREAK_AVAILABLE_COUNT";
    private const string CostumeAwakenAvailableCount = "COSTUME_AWAKEN_AVAILABLE_COUNT";
    private const string MaterialSameWeaponExpCoefficientPermilKey = "MATERIAL_SAME_WEAPON_EXP_COEFFICIENT_PERMIL";
    private const string WeaponEnhanceCalcCoefficientPermilKey = "WEAPON_ENHANCE_CALC_COEFFICIENT_PERMIL";
    private const string WeaponSellPriceCalcFixedValuePermilKey = "WEAPON_SELL_PRICE_CALC_FIXED_VALUE_PERMIL";
    private const string GiftReceivedListTotalCountKey = "GIFT_RECEIVED_LIST_TOTAL_COUNT";
    private const string UserNameMaxLength = "USER_NAME_MAX_LENGTH";
    private const string UserNameMinLength = "USER_NAME_MIN_LENGTH";
    private const string UserMessageMaxLength = "USER_MESSAGE_MAX_LENGTH";
    private const string UserMessageMinLength = "USER_MESSAGE_MIN_LENGTH";
    private const string DeckNameMaxLength = "DECK_NAME_MAX_LENGTH";
    private const string DeckNameMinLength = "DECK_NAME_MIN_LENGTH";
    private const string UserLevelExpNumericalParameterMapId = "USER_LEVEL_EXP_NUMERICAL_PARAMETER_MAP_ID";
    private const string GrpcTimeoutMilliseconds = "GRPC_TIMEOUT_MILLISECONDS";
    private const string ExplorePlayIntervalMinuteKey = "EXPLORE_PLAY_INTERVAL_MINUTE";
    private const string HeaderNoticeCountApiInterval = "API_CALL_INTERVAL_SECOND_FOR_HEADER_NOTICE_COUNT";
    private const string UnlockPvpQuestId = "FUNCTION_UNLOCK_QUEST_ID_FOR_PVP";
    private const string UnlockPartsQuestId = "FUNCTION_UNLOCK_QUEST_ID_FOR_PARTS";
    private const string UnlockMapQuestId = "FUNCTION_UNLOCK_QUEST_ID_FOR_MAP";
    private const string UnlockMapItemFullQuestId = "FUNCTION_UNLOCK_QUEST_ID_FOR_MAP_ITEM_FULL";
    private const string UnlockCompanionQuestId = "FUNCTION_UNLOCK_QUEST_ID_FOR_COMPANION";
    private const string UnlockTutorialMenuChapterId = "FUNCTION_UNLOCK_CHAPTER_ID_FOR_MENU";
    private const string UnlockEventQuestMenuQuestId = "FUNCTION_UNLOCK_QUEST_ID_FOR_EVENT_QUEST";
    private const string UnlockCharacterBoardQuestId = "FUNCTION_UNLOCK_QUEST_ID_FOR_CHARACTER_BOARD";
    private const string UnlockCharacterViewerQuestId = "FUNCTION_UNLOCK_QUEST_ID_FOR_CHARACTER_VIEWER";
    private const string PortalCageSceneId = "PORTAL_CAGE_SCENE_ID";
    private const string PortalCageFunctionUnlockQuestIdForPortalCage = "FUNCTION_UNLOCK_QUEST_ID_FOR_PORTAL_CAGE";
    private const string MissionTapTargetActorId = "MISSION_TAP_TARGET_ACTOR_ID";
    private const string MamaTapCountInterval = "MAMA_TAP_COUNT_INTERVAL";
    private const string PurchaseAlertThresholdMoney = "PURCHASE_ALERT_THRESHOLD_MONEY";
    private const string TutorialSortCharacterId = "TUTORIAL_SORT_CHARACTER_ID";
    private const string TutorialSortWeaponId = "TUTORIAL_SORT_WEAPON_ID";
    private const string InitialUserQuestSceneId = "INITIAL_USER_QUEST_SCENE_ID";
    private const string EnhanceConsumableWeaponCountAtOnce = "ENHANCE_CONSUMABLE_WEAPON_COUNT_AT_ONCE";
    private const string PossessionCountLimitMaterial = "POSSESSION_COUNT_LIMIT_MATERIAL";
    private const string PossessionCountLimitConsumableItem = "POSSESSION_COUNT_LIMIT_CONSUMABLE_ITEM";
    private const string PossessionCountLimitGoldAndCoin = "POSSESSION_COUNT_LIMIT_MONEY";
    private const string PossessionCountLimitWeapon = "POSSESSION_COUNT_LIMIT_WEAPON";
    private const string PossessionCountLimitParts = "POSSESSION_COUNT_LIMIT_PARTS";
    private const string PossessionCountLimitImportantItem = "POSSESSION_COUNT_LIMIT_IMPORTANT_ITEM";
    private const string PossessionCountLimitStamina = "POSSESSION_COUNT_LIMIT_STAMINA";
    private const string PossessionCountLimitBp = "POSSESSION_COUNT_LIMIT_BP";
    private const string PossessionCountGachaMedal = "POSSESSION_COUNT_LIMIT_GACHA_MEDAL";
    private const string QuestRestartGraceTimeAfterEvent = "QUEST_RESTART_GRACE_TIME_AFTER_EVENT";
    private const string UnlockHardQuestId = "FUNCTION_UNLOCK_QUEST_ID_FOR_HARDQUEST";
    private const string UnlockVeryHardQuestId = "FUNCTION_UNLOCK_QUEST_ID_FOR_VERYHARDQUEST";
    private const string UserFriendReceiveCheerMaxNumber = "USER_FRIEND_RECEIVE_CHEER_MAX_NUMBER";
    private const string UserFriendSendCheerMaxNumber = "USER_FRIEND_SEND_CHEER_MAX_NUMBER";
    private const string UseTierPriceFlag = "USE_TIER_PRICE_FLAG";
    private const string LoseFirstThresholdQuestId = "LOSE_FIRST_THRESHOLD_QUEST_ID";
    private const string LoseFirstMinimumThresholdQuestId = "LOSE_FIRST_MINIMUM_THRESHOLD_QUEST_ID";
    private const string LoseFirstThresholdAfterChapterQuestId = "FUNCTION_LOSE_FIRST_THRESHOLD_AFTER_CHAPTER_QUEST_ID";
    private const string QuestMissionBigWinBonusPower = "QUEST_MISSION_BIG_WIN_BONUS_POWER";
    private const string UnlockBigHuntQuestId = "FUNCTION_UNLOCK_QUEST_ID_FOR_BIG_HUNT";
    private const string QuestSkipMaxCountAtOnce = "QUEST_SKIP_MAX_COUNT_AT_ONCE";
    private const string UnlockQuestSkipQuestId = "FUNCTION_UNLOCK_QUEST_ID_FOR_QUEST_SKIP";
    private const string UnlockDailyGachaQuestId = "FUNCTION_UNLOCK_QUEST_ID_FOR_DAILY_GACHA";
    private const string UnlockDailyQuestQuestId = "FUNCTION_UNLOCK_QUEST_ID_FOR_DAILY_QUEST";
    private const string UnlockBrokenObeliskQuestId = "FUNCTION_UNLOCK_QUEST_ID_BROKEN_OBELISK";
    private const string MemoryPresetNameMinLength = "PARTS_PRESET_NAME_MIN_LENGTH";
    private const string MemoryPresetNameMaxLength = "PARTS_PRESET_NAME_MAX_LENGTH";
    private const string MemoryPresetTagNameMinLength = "PARTS_PRESET_TAG_NAME_MIN_LENGTH";
    private const string MemoryPresetTagNameMaxLength = "PARTS_PRESET_TAG_NAME_MAX_LENGTH";
    private const string UnlockBigHuntBoardEvaluateConditionId = "FUNCTION_UNLOCK_EVALUATE_CONDITION_ID_FOR_BIG_HUNT_BOARD";
    private const string NecessaryGemCountForGuerrillaOpen = "NECESSARY_GEM_COUNT_FOR_GUERRILLA_OPEN";
    private const string PossessionSellCountLimitAtOnce = "POSSESSION_SELL_COUNT_LIMIT_AT_ONCE";
    private const string MaterialMaxSalableCountAtOnce = "MATERIAL_MAX_SALABLE_COUNT_AT_ONCE";
    private const string ConsumableItemMaxSalableCountAtOnce = "CONSUMABLE_ITEM_MAX_SALABLE_COUNT_AT_ONCE";
    private const string LimitedShopId = "LIMITED_SHOP_ID";
    private const string UnlockDressupCostumeQuestId = "FUNCTION_UNLOCK_QUEST_ID_FOR_DRESSUP_COSTUME";
    private const string EndQuestTutorialWebViewPlayGuideId = "END_QUEST_TUTORIAL_WEB_VIEW_PLAY_GUIDE_ID";
    private const string LimitQuestTutorialWebViewPlayGuideId = "LIMIT_QUEST_TUTORIAL_WEB_VIEW_PLAY_GUIDE_ID";
    private const string UnDailyMissionV2 = "FUNCTION_UNLOCK_QUEST_ID_FOR_DAILY_MISSION_V2";
    private const string SwitchRewardReceiveFlowDateMilliSecondForBigHunt = "SWITCH_REWARD_RECEIVE_FLOW_DATE_MILLI_SECOND_FOR_BIG_HUNT";
    private const string SwitchRewardReceiveFlowDateMilliSecondForPvp = "SWITCH_REWARD_RECEIVE_FLOW_DATE_MILLI_SECOND_FOR_PVP";
    private const string ConsumableItemIdForMomPointKey = "CONSUMABLE_ITEM_ID_FOR_MOM_POINT";
    private const string MomPointShopId = "MOM_POINT_SHOP_ID";
    private const string MomPointOpenDateMilliSecond = "MOM_POINT_OPEN_DATE_MILLI_SECOND";
    private const string ConsumableItemIdForPremiumGachaTicket = "CONSUMABLE_ITEM_ID_FOR_PREMIUM_GACHA_TICKET";
    private const string CharacterRebirthAvailableCount = "CHARACTER_REBIRTH_AVAILABLE_COUNT";
    private const string CharacterRebirthConsumeGold = "CHARACTER_REBIRTH_CONSUME_GOLD";
    private const string CostumeGrowthCurveCoefficientThreshold = "COSTUME_STATUS_FUNCTION_THRESHOLD_LEVEL";
    private const string CostumeGrowthCurveCoefficient = "COSTUME_STATUS_FUNCTION_THRESHOLD_OVER_COEFFICIENT";
    private const string WeaponGrowthCurveCoefficientThreshold = "WEAPON_STATUS_FUNCTION_THRESHOLD_LEVEL";
    private const string WeaponGrowthCurveCoefficient = "WEAPON_STATUS_FUNCTION_THRESHOLD_OVER_COEFFICIENT";
    private const string AutoOrganizationBlessAdditionalCoefficientApplyThreshold = "AUTO_ORGANIZATION_BRESS_ADDITIONAL_COEFFICIENT_APPLY_THRESHOLD";
    private const string AutoOrganizationBlessAdditionalCoefficient = "AUTO_ORGANIZATION_BRESS_ADDITIONAL_COEFFICIENT_PERMIL";

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
