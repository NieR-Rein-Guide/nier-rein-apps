namespace NierReincarnation.Core.Dark.Networking;

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

    public static int GetConsumableIdForGold() => GetConfigIntValue(ConsumableItemIdForGoldKey);

    public static int GetConsumableIdForMedal() => GetConfigIntValue(ConsumableItemIdForMedalKey);

    public static int GetConsumableIdForRareMedal() => GetConfigIntValue(ConsumableItemIdForRareMedalKey);

    public static int GetConsumableIdForArenaCoin() => GetConfigIntValue(ConsumableItemIdForArenaCoinKey);

    public static int GetConsumableItemIdForExploreTicket() => GetConfigIntValue(ConsumableItemIdForExploreTicketKey);

    public static int GetConsumableItemIdForQuestSkipTicket() => GetConfigIntValue(ConsumableItemIdForQuestSkipTicketKey);

    public static int GetMaxBattlePoint() => GetConfigIntValue(PvpMaxBattlePointKey);

    public static int GetBattleConsumeBattlePoint() => GetConfigIntValue(PvpBattleConsumeBattlePointKey);

    public static int GetUpdateMatchingConsumeBattlePoint() => GetConfigIntValue(PvpUpdateMatchingBattlePointKey);

    public static int GetStaminaRecoverySecond() => GetConfigIntValue(StaminaRecoverySecondKey);

    public static int GetBattlePointRecoverySecond() => GetConfigIntValue(BattlePointRecoverySecondKey);

    public static int GetCostumeLimitBreakAvailableCount() => GetConfigIntValue(CostumeLimitBreakAvailableCountKey);

    public static int GetWeaponLimitBreakAvailableCount() => GetConfigIntValue(WeaponLimitBreakAvailableCountKey);

    public static int GetCostumeAwakenAvailableCount() => GetConfigIntValue(CostumeAwakenAvailableCount);

    public static int GetMaterialSameWeaponExpCoefficientPermil() => GetConfigIntValue(MaterialSameWeaponExpCoefficientPermilKey);

    public static int GetWeaponEnhanceCalcCoefficientPermil() => GetConfigIntValue(WeaponEnhanceCalcCoefficientPermilKey);

    public static int GetGrpcTimeoutMilliseconds() => GetConfigIntValue(GrpcTimeoutMilliseconds);

    public static int GetUserNameMinLength() => GetConfigIntValue(UserNameMinLength);

    public static int GetUserNameMaxLength() => GetConfigIntValue(UserNameMaxLength);

    public static int GetUserMessageMinLength() => GetConfigIntValue(UserMessageMinLength);

    public static int GetUserMessageMaxLength() => GetConfigIntValue(UserMessageMaxLength);

    public static int GetDeckNameMinLength() => GetConfigIntValue(DeckNameMinLength);

    public static int GetDeckNameMaxLength() => GetConfigIntValue(DeckNameMaxLength);

    public static int GetUserLevelExpNumericalParameterMapId() => GetConfigIntValue(UserLevelExpNumericalParameterMapId);

    public static int GetExplorePlayIntervalMinute() => GetConfigIntValue(ExplorePlayIntervalMinuteKey);

    public static int GetHeaderNoticeCountApiInterval() => GetConfigIntValue(HeaderNoticeCountApiInterval);

    public static int GetUnlockPvpQuestId() => GetConfigIntValue(UnlockPvpQuestId);

    public static int GetUnlockPartsQuestId() => GetConfigIntValue(UnlockPartsQuestId);

    public static int GetUnlockMapQuestId() => GetConfigIntValue(UnlockMapQuestId);

    public static int GetUnlockTutorialMenuChapterId() => GetConfigIntValue(UnlockTutorialMenuChapterId);

    public static int GetUnlockEventQuestMenuQuestId() => GetConfigIntValue(UnlockEventQuestMenuQuestId);

    public static int GetUnlockCharacterBoardQuestId() => GetConfigIntValue(UnlockCharacterBoardQuestId);

    public static int GetUnlockCharacterViewerQuestId() => GetConfigIntValue(UnlockCharacterViewerQuestId);

    public static int GetPortalCageSceneId() => GetConfigIntValue(PortalCageSceneId);

    public static int GetPortalCageFunctionUnlockQuestIdForPortalCage() => GetConfigIntValue(PortalCageFunctionUnlockQuestIdForPortalCage);

    public static int GetMomTapCountInterval() => GetConfigIntValue(MamaTapCountInterval);

    public static int GetPurchaseAlertThresholdMoney() => GetConfigIntValue(PurchaseAlertThresholdMoney);

    public static int GetTutorialSortCharacterId() => GetConfigIntValue(TutorialSortCharacterId);

    public static int GetTutorialSortWeaponId() => GetConfigIntValue(TutorialSortWeaponId);

    public static int GetInitialUserQuestSceneId() => GetConfigIntValue(InitialUserQuestSceneId);

    public static int GetEnhanceConsumableWeaponCountAtOnce() => GetConfigIntValue(EnhanceConsumableWeaponCountAtOnce);

    public static int GetQuestRestartGraceTimeAfterEvent() => GetConfigIntValue(QuestRestartGraceTimeAfterEvent);

    public static int GetUnlockHardQuestQuestId() => GetConfigIntValue(UnlockHardQuestId);

    public static int GetUnlockVeryHardQuestQuestId() => GetConfigIntValue(UnlockVeryHardQuestId);

    public static int GetLoseFirstThresholdQuestId() => GetConfigIntValue(LoseFirstThresholdQuestId);

    public static int GetLoseFirstMinimumThresholdQuestId() => GetConfigIntValue(LoseFirstMinimumThresholdQuestId);

    public static int GetLoseFirstThresholdAfterChapterQuestId() => GetConfigIntValue(LoseFirstThresholdAfterChapterQuestId);

    public static int GetUnlockBigHuntQuestId() => GetConfigIntValue(UnlockBigHuntQuestId);

    public static int GetQuestSkipMaxCountAtOnce() => GetConfigIntValue(QuestSkipMaxCountAtOnce);

    public static int GetUnlockQuestSkipQuestId() => GetConfigIntValue(UnlockQuestSkipQuestId);

    public static int GetUnlockDailyGachaId() => GetConfigIntValue(UnlockDailyGachaQuestId);

    public static int GetUnlockDailyQuestId() => GetConfigIntValue(UnlockDailyQuestQuestId);

    public static int GetPossessionCountLimitMaterial() => GetConfigIntValue(PossessionCountLimitMaterial);

    public static int GetPossessionCountLimitConsumableItem() => GetConfigIntValue(PossessionCountLimitConsumableItem);

    public static int GetPossessionCountLimitGoldAndCoin() => GetConfigIntValue(PossessionCountLimitGoldAndCoin);

    public static int GetPossessionCountLimitWeapon() => GetConfigIntValue(PossessionCountLimitWeapon);

    public static int GetPossessionCountLimitParts() => GetConfigIntValue(PossessionCountLimitParts);

    public static int GetPossessionCountLimitStamina() => GetConfigIntValue(PossessionCountLimitStamina);

    public static int GetPossessionCountLimitBp() => GetConfigIntValue(PossessionCountLimitBp);

    public static int GetPossessionCountGachaMedal() => GetConfigIntValue(PossessionCountGachaMedal);

    public static int GetUserFriendReceiveCheerMaxNumber() => GetConfigIntValue(UserFriendReceiveCheerMaxNumber);

    public static int GeUserFriendSendCheerMaxNumber() => GetConfigIntValue(UserFriendSendCheerMaxNumber);

    public static bool IsUseTierPrice() => GetConfigBoolValue(UseTierPriceFlag);

    public static int GetQuestMissionBigWinBonusPower() => GetConfigIntValue(QuestMissionBigWinBonusPower);

    public static int GetMemoryPresetNameMinLength() => GetConfigIntValue(MemoryPresetNameMinLength);

    public static int GetMemoryPresetNameMaxLength() => GetConfigIntValue(MemoryPresetNameMaxLength);

    public static int GetMemoryPresetTagNameMinLength() => GetConfigIntValue(MemoryPresetTagNameMinLength);

    public static int GetMemoryPresetTagNameMaxLength() => GetConfigIntValue(MemoryPresetTagNameMaxLength);

    public static int GetUnlockBigHuntBoardEvaluateConditionId() => GetConfigIntValue(UnlockBigHuntBoardEvaluateConditionId);

    public static int GetNecessaryGemCountForGuerrillaOpen() => GetConfigIntValue(NecessaryGemCountForGuerrillaOpen);

    public static int GetPossessionSellCountLimitAtOnce() => GetConfigIntValue(PossessionSellCountLimitAtOnce);

    public static int GetMaterialMaxSalableCountAtOnce() => GetConfigIntValue(MaterialMaxSalableCountAtOnce);

    public static int GetConsumableItemMaxSalableCountAtOnce() => GetConfigIntValue(ConsumableItemMaxSalableCountAtOnce);

    public static int GetLimitedShopId() => GetConfigIntValue(LimitedShopId);

    public static int GetUnlockDressupCostumeQuestId() => GetConfigIntValue(UnlockDressupCostumeQuestId);

    public static int GetEndQuestTutorialWebViewPlayGuideId() => GetConfigIntValue(EndQuestTutorialWebViewPlayGuideId);

    public static int GetLimitQuestTutorialWebViewPlayGuideId() => GetConfigIntValue(LimitQuestTutorialWebViewPlayGuideId);

    public static int GetUnlockDailyMissionV2Id() => GetConfigIntValue(UnDailyMissionV2);

    public static long GetSwitchRewardReceiveFlowDateMilliSecondForBigHunt() => GetConfigIntValue(SwitchRewardReceiveFlowDateMilliSecondForBigHunt);

    public static long GetSwitchRewardReceiveFlowDateMilliSecondForPvp() => GetConfigIntValue(SwitchRewardReceiveFlowDateMilliSecondForPvp);

    public static int GetConsumableIdForMomPoint() => GetConfigIntValue(ConsumableItemIdForMomPointKey);

    public static int GetMomPointShopId() => GetConfigIntValue(MomPointShopId);

    public static long GetMomPointOpenDateMilliSecond() => GetConfigIntValue(MomPointOpenDateMilliSecond);

    public static int GetConsumableItemIdForPremiumGachaTicket() => GetConfigIntValue(ConsumableItemIdForPremiumGachaTicket);

    public static int GetCharacterRebirthAvailableCount() => GetConfigIntValue(CharacterRebirthAvailableCount);

    public static int GetCharacterRebirthConsumeGold() => GetConfigIntValue(CharacterRebirthConsumeGold);

    public static int GetCostumeGrowthCoefficientThreshold() => GetConfigIntValue(CostumeGrowthCurveCoefficientThreshold);

    public static int GetCostumeGrowthCoefficient() => GetConfigIntValue(CostumeGrowthCurveCoefficient);

    public static int GetWeaponGrowthCoefficientThreshold() => GetConfigIntValue(WeaponGrowthCurveCoefficientThreshold);

    public static int GetWeaponGrowthCoefficient() => GetConfigIntValue(WeaponGrowthCurveCoefficient);

    public static int GetAutoOrganizationBlessAdditionalCoefficientApplyThreshold() => GetConfigIntValue(AutoOrganizationBlessAdditionalCoefficientApplyThreshold);

    public static int GetAutoOrganizationBlessAdditionalCoefficient() => GetConfigIntValue(AutoOrganizationBlessAdditionalCoefficient);

    private static int GetConfigIntValue(string key)
    {
        if (DatabaseDefine.Master == null)
            return 0;

        if (int.TryParse(DatabaseDefine.Master.EntityMConfigTable.FindByConfigKey(key).Value, out var configValue))
            return configValue;

        return 0;
    }

    private static long GetConfigLongValue(string key)
    {
        if (DatabaseDefine.Master == null)
            return 0;

        if (long.TryParse(DatabaseDefine.Master.EntityMConfigTable.FindByConfigKey(key).Value, out var configValue))
            return configValue;

        return 0;
    }

    private static bool GetConfigBoolValue(string key)
    {
        if (DatabaseDefine.Master == null)
            return false;

        if (int.TryParse(DatabaseDefine.Master.EntityMConfigTable.FindByConfigKey(key).Value, out var configValue))
            return configValue == 1;

        return false;
    }
}
