namespace NierReincarnation.Core.Dark.Networking
{
    // Dark.Networking.Config
    public static class Config
    {
        private static readonly string ConsumableItemIdForGoldKey = "CONSUMABLE_ITEM_ID_FOR_GOLD";
        private static readonly string ConsumableItemIdForMedalKey = "CONSUMABLE_ITEM_ID_FOR_MEDAL";
        private static readonly string ConsumableItemIdForRareMedalKey = "CONSUMABLE_ITEM_ID_FOR_RARE_MEDAL";
        private static readonly string ConsumableItemIdForArenaCoinKey = "CONSUMABLE_ITEM_ID_FOR_ARENA_COIN";
        private static readonly string ConsumableItemIdForExploreTicketKey = "CONSUMABLE_ITEM_ID_FOR_EXPLORE_TICKET";
        private static readonly string ConsumableItemIdForQuestSkipTicketKey = "CONSUMABLE_ITEM_ID_FOR_QUEST_SKIP_TICKET";
        private static readonly string PvpMaxBattlePointKey = "PVP_MAX_BATTLE_POINT";
        private static readonly string PvpBattleConsumeBattlePointKey = "PVP_BATTLE_CONSUME_BATTLE_POINT";
        private static readonly string PvpUpdateMatchingBattlePointKey = "PVP_UPDATE_MATCHING_CONSUME_BATTLE_POINT";
        private static readonly string StaminaRecoverySecondKey = "USER_STAMINA_RECOVERY_SECOND";
        private static readonly string BattlePointRecoverySecondKey = "USER_BATTLE_POINT_RECOVERY_SECOND";
        private static readonly string CostumeLimitBreakAvailableCountKey = "COSTUME_LIMIT_BREAK_AVAILABLE_COUNT";
        private static readonly string WeaponLimitBreakAvailableCountKey = "WEAPON_LIMIT_BREAK_AVAILABLE_COUNT";
        private static readonly string MaterialSameWeaponExpCoefficientPermilKey = "MATERIAL_SAME_WEAPON_EXP_COEFFICIENT_PERMIL";
        private static readonly string WeaponEnhanceCalcCoefficientPermilKey = "WEAPON_ENHANCE_CALC_COEFFICIENT_PERMIL";
        private static readonly string WeaponSellPriceCalcFixedValuePermilKey = "WEAPON_SELL_PRICE_CALC_FIXED_VALUE_PERMIL";
        private static readonly string GiftReceivedListTotalCountKey = "GIFT_RECEIVED_LIST_TOTAL_COUNT";
        private static readonly string UserNameMaxLength = "USER_NAME_MAX_LENGTH";
        private static readonly string UserNameMinLength = "USER_NAME_MIN_LENGTH";
        private static readonly string UserMessageMaxLength = "USER_MESSAGE_MAX_LENGTH";
        private static readonly string UserMessageMinLength = "USER_MESSAGE_MIN_LENGTH";
        private static readonly string DeckNameMaxLength = "DECK_NAME_MAX_LENGTH";
        private static readonly string DeckNameMinLength = "DECK_NAME_MIN_LENGTH";
        private static readonly string UserLevelExpNumericalParameterMapId = "USER_LEVEL_EXP_NUMERICAL_PARAMETER_MAP_ID";
        private static readonly string GrpcTimeoutMilliseconds = "GRPC_TIMEOUT_MILLISECONDS";
        private static readonly string ExplorePlayIntervalMinuteKey = "EXPLORE_PLAY_INTERVAL_MINUTE";
        private static readonly string HeaderNoticeCountApiInterval = "API_CALL_INTERVAL_SECOND_FOR_HEADER_NOTICE_COUNT";
        private static readonly string UnlockPvpQuestId = "FUNCTION_UNLOCK_QUEST_ID_FOR_PVP";
        private static readonly string UnlockPartsQuestId = "FUNCTION_UNLOCK_QUEST_ID_FOR_PARTS";
        private static readonly string UnlockMapQuestId = "FUNCTION_UNLOCK_QUEST_ID_FOR_MAP";
        private static readonly string UnlockMapItemFullQuestId = "FUNCTION_UNLOCK_QUEST_ID_FOR_MAP_ITEM_FULL";
        private static readonly string UnlockCompanionQuestId = "FUNCTION_UNLOCK_QUEST_ID_FOR_COMPANION";
        private static readonly string UnlockTutorialMenuChapterId = "FUNCTION_UNLOCK_CHAPTER_ID_FOR_MENU";
        private static readonly string UnlockEventQuestMenuQuestId = "FUNCTION_UNLOCK_QUEST_ID_FOR_EVENT_QUEST";
        private static readonly string UnlockCharacterBoardQuestId = "FUNCTION_UNLOCK_QUEST_ID_FOR_CHARACTER_BOARD";
        private static readonly string PortalCageSceneId = "PORTAL_CAGE_SCENE_ID";
        private static readonly string PortalCageFunctionUnlockQuestIdForPortalCage = "FUNCTION_UNLOCK_QUEST_ID_FOR_PORTAL_CAGE";
        private static readonly string MissionTapTargetActorId = "MISSION_TAP_TARGET_ACTOR_ID";
        private static readonly string MamaTapCountInterval = "MAMA_TAP_COUNT_INTERVAL";
        private static readonly string PurchaseAlertThresholdMoney = "PURCHASE_ALERT_THRESHOLD_MONEY";
        private static readonly string TutorialSortCharacterId = "TUTORIAL_SORT_CHARACTER_ID";
        private static readonly string TutorialSortWeaponId = "TUTORIAL_SORT_WEAPON_ID";
        private static readonly string InitialUserQuestSceneId = "INITIAL_USER_QUEST_SCENE_ID";
        private static readonly string EnhanceConsumableWeaponCountAtOnce = "ENHANCE_CONSUMABLE_WEAPON_COUNT_AT_ONCE";
        private static readonly string PossessionCountLimitMaterial = "POSSESSION_COUNT_LIMIT_MATERIAL";
        private static readonly string PossessionCountLimitConsumableItem = "POSSESSION_COUNT_LIMIT_CONSUMABLE_ITEM";
        private static readonly string PossessionCountLimitGoldAndCoin = "POSSESSION_COUNT_LIMIT_MONEY";
        private static readonly string PossessionCountLimitWeapon = "POSSESSION_COUNT_LIMIT_WEAPON";
        private static readonly string PossessionCountLimitParts = "POSSESSION_COUNT_LIMIT_PARTS";
        private static readonly string PossessionCountLimitImportantItem = "POSSESSION_COUNT_LIMIT_IMPORTANT_ITEM";
        private static readonly string PossessionCountLimitStamina = "POSSESSION_COUNT_LIMIT_STAMINA";
        private static readonly string PossessionCountLimitBp = "POSSESSION_COUNT_LIMIT_BP";
        private static readonly string PossessionCountGachaMedal = "POSSESSION_COUNT_LIMIT_GACHA_MEDAL";
        private static readonly string QuestRestartGraceTimeAfterEvent = "QUEST_RESTART_GRACE_TIME_AFTER_EVENT";
        private static readonly string UnlockHardQuestId = "FUNCTION_UNLOCK_QUEST_ID_FOR_HARDQUEST";
        private static readonly string UnlockVeryHardQuestId = "FUNCTION_UNLOCK_QUEST_ID_FOR_VERYHARDQUEST";
        private static readonly string UserFriendReceiveCheerMaxNumber = "USER_FRIEND_RECEIVE_CHEER_MAX_NUMBER";
        private static readonly string UserFriendSendCheerMaxNumber = "USER_FRIEND_SEND_CHEER_MAX_NUMBER";
        private static readonly string UseTierPriceFlag = "USE_TIER_PRICE_FLAG";
        private static readonly string LoseFirstThresholdQuestId = "LOSE_FIRST_THRESHOLD_QUEST_ID";
        private static readonly string LoseFirstMinimumThresholdQuestId = "LOSE_FIRST_MINIMUM_THRESHOLD_QUEST_ID";
        private static readonly string LoseFirstThresholdAfterChapterQuestId = "FUNCTION_LOSE_FIRST_THRESHOLD_AFTER_CHAPTER_QUEST_ID";
        private static readonly string QuestMissionBigWinBonusPower = "QUEST_MISSION_BIG_WIN_BONUS_POWER";
        private static readonly string UnlockBigHuntQuestId = "FUNCTION_UNLOCK_QUEST_ID_FOR_BIG_HUNT";
        private static readonly string QuestSkipMaxCountAtOnce = "QUEST_SKIP_MAX_COUNT_AT_ONCE";
        private static readonly string UnlockQuestSkipQuestId = "FUNCTION_UNLOCK_QUEST_ID_FOR_QUEST_SKIP";
        private static readonly string UnlockDailyGachaQuestId = "FUNCTION_UNLOCK_QUEST_ID_FOR_DAILY_GACHA";
        private static readonly string UnlockDailyQuestQuestId = "FUNCTION_UNLOCK_QUEST_ID_FOR_DAILY_QUEST";
        private static readonly string UnlockBrokenObeliskQuestId = "FUNCTION_UNLOCK_QUEST_ID_BROKEN_OBELISK";
        private static readonly string MemoryPresetNameMinLength = "PARTS_PRESET_NAME_MIN_LENGTH";
        private static readonly string MemoryPresetNameMaxLength = "PARTS_PRESET_NAME_MAX_LENGTH";
        private static readonly string MemoryPresetTagNameMinLength = "PARTS_PRESET_TAG_NAME_MIN_LENGTH";
        private static readonly string MemoryPresetTagNameMaxLength = "PARTS_PRESET_TAG_NAME_MAX_LENGTH";

        public static int GetConsumableIdForGold()
        {
            return GetConfigIntValue(ConsumableItemIdForGoldKey);
        }

        public static int GetConsumableIdForMedal()
        {
            return GetConfigIntValue(ConsumableItemIdForMedalKey);
        }

        public static int GetConsumableIdForRareMedal()
        {
            return GetConfigIntValue(ConsumableItemIdForRareMedalKey);
        }

        public static int GetConsumableIdForArenaCoin()
        {
            return GetConfigIntValue(ConsumableItemIdForArenaCoinKey);
        }

        public static int GetConsumableItemIdForExploreTicket()
        {
            return GetConfigIntValue(ConsumableItemIdForExploreTicketKey);
        }

        public static int GetConsumableItemIdForQuestSkipTicket()
        {
            return GetConfigIntValue(ConsumableItemIdForQuestSkipTicketKey);
        }

        public static int GetMaxBattlePoint()
        {
            return GetConfigIntValue(PvpMaxBattlePointKey);
        }

        public static int GetBattleConsumeBattlePoint()
        {
            return GetConfigIntValue(PvpBattleConsumeBattlePointKey);
        }

        public static int GetUpdateMatchingConsumeBattlePoint()
        {
            return GetConfigIntValue(PvpUpdateMatchingBattlePointKey);
        }

        public static int GetStaminaRecoverySecond()
        {
            return GetConfigIntValue(StaminaRecoverySecondKey);
        }

        public static int GetBattlePointRecoverySecond()
        {
            return GetConfigIntValue(BattlePointRecoverySecondKey);
        }

        public static int GetCostumeLimitBreakAvailableCount()
        {
            return GetConfigIntValue(CostumeLimitBreakAvailableCountKey);
        }

        public static int GetWeaponLimitBreakAvailableCount()
        {
            return GetConfigIntValue(WeaponLimitBreakAvailableCountKey);
        }

        public static int GetMaterialSameWeaponExpCoefficientPermil()
        {
            return GetConfigIntValue(MaterialSameWeaponExpCoefficientPermilKey);
        }

        public static int GetWeaponEnhanceCalcCoefficientPermil()
        {
            return GetConfigIntValue(WeaponEnhanceCalcCoefficientPermilKey);
        }

        public static int GetGrpcTimeoutMilliseconds()
        {
            return GetConfigIntValue(GrpcTimeoutMilliseconds);
        }

        public static int GetUserNameMinLength()
        {
            return GetConfigIntValue(UserNameMinLength);
        }

        public static int GetUserNameMaxLength()
        {
            return GetConfigIntValue(UserNameMaxLength);
        }

        public static int GetUserMessageMinLength()
        {
            return GetConfigIntValue(UserMessageMinLength);
        }

        public static int GetUserMessageMaxLength()
        {
            return GetConfigIntValue(UserMessageMaxLength);
        }

        public static int GetDeckNameMinLength()
        {
            return GetConfigIntValue(DeckNameMinLength);
        }

        public static int GetDeckNameMaxLength()
        {
            return GetConfigIntValue(DeckNameMaxLength);
        }

        public static int GetUserLevelExpNumericalParameterMapId()
        {
            return GetConfigIntValue(UserLevelExpNumericalParameterMapId);
        }

        public static int GetExplorePlayIntervalMinute()
        {
            return GetConfigIntValue(ExplorePlayIntervalMinuteKey);
        }

        public static int GetHeaderNoticeCountApiInterval()
        {
            return GetConfigIntValue(HeaderNoticeCountApiInterval);
        }

        public static int GetUnlockPvpQuestId()
        {
            return GetConfigIntValue(UnlockPvpQuestId);
        }

        public static int GetUnlockPartsQuestId()
        {
            return GetConfigIntValue(UnlockPartsQuestId);
        }

        public static int GetUnlockMapQuestId()
        {
            return GetConfigIntValue(UnlockMapQuestId);
        }

        public static int GetUnlockTutorialMenuChapterId()
        {
            return GetConfigIntValue(UnlockTutorialMenuChapterId);
        }

        public static int GetUnlockEventQuestMenuQuestId()
        {
            return GetConfigIntValue(UnlockEventQuestMenuQuestId);
        }

        public static int GetUnlockCharacterBoardQuestId()
        {
            return GetConfigIntValue(UnlockCharacterBoardQuestId);
        }

        public static int GetPortalCageSceneId()
        {
            return GetConfigIntValue(PortalCageSceneId);
        }

        public static int GetPortalCageFunctionUnlockQuestIdForPortalCage()
        {
            return GetConfigIntValue(PortalCageFunctionUnlockQuestIdForPortalCage);
        }

        public static int GetMomTapCountInterval()
        {
            return GetConfigIntValue(MamaTapCountInterval);
        }

        public static int GetPurchaseAlertThresholdMoney()
        {
            return GetConfigIntValue(PurchaseAlertThresholdMoney);
        }

        public static int GetTutorialSortCharacterId()
        {
            return GetConfigIntValue(TutorialSortCharacterId);
        }

        public static int GetTutorialSortWeaponId()
        {
            return GetConfigIntValue(TutorialSortWeaponId);
        }

        public static int GetInitialUserQuestSceneId()
        {
            return GetConfigIntValue(InitialUserQuestSceneId);
        }

        public static int GetEnhanceConsumableWeaponCountAtOnce()
        {
            return GetConfigIntValue(EnhanceConsumableWeaponCountAtOnce);
        }

        public static int GetQuestRestartGraceTimeAfterEvent()
        {
            return GetConfigIntValue(QuestRestartGraceTimeAfterEvent);
        }

        public static int GetUnlockHardQuestQuestId()
        {
            return GetConfigIntValue(UnlockHardQuestId);
        }

        public static int GetUnlockVeryHardQuestQuestId()
        {
            return GetConfigIntValue(UnlockVeryHardQuestId);
        }

        public static int GetLoseFirstThresholdQuestId()
        {
            return GetConfigIntValue(LoseFirstThresholdQuestId);
        }

        public static int GetLoseFirstMinimumThresholdQuestId()
        {
            return GetConfigIntValue(LoseFirstMinimumThresholdQuestId);
        }

        public static int GetLoseFirstThresholdAfterChapterQuestId()
        {
            return GetConfigIntValue(LoseFirstThresholdAfterChapterQuestId);
        }

        public static int GetUnlockBigHuntQuestId()
        {
            return GetConfigIntValue(UnlockBigHuntQuestId);
        }

        public static int GetQuestSkipMaxCountAtOnce()
        {
            return GetConfigIntValue(QuestSkipMaxCountAtOnce);
        }

        public static int GetUnlockQuestSkipQuestId()
        {
            return GetConfigIntValue(UnlockQuestSkipQuestId);
        }

        public static int GetUnlockDailyGachaId()
        {
            return GetConfigIntValue(UnlockDailyGachaQuestId);
        }

        public static int GetUnlockDailyQuestId()
        {
            return GetConfigIntValue(UnlockDailyQuestQuestId);
        }

        public static int GetPossessionCountLimitMaterial()
        {
            return GetConfigIntValue(PossessionCountLimitMaterial);
        }

        public static int GetPossessionCountLimitConsumableItem()
        {
            return GetConfigIntValue(PossessionCountLimitConsumableItem);
        }

        public static int GetPossessionCountLimitGoldAndCoin()
        {
            return GetConfigIntValue(PossessionCountLimitGoldAndCoin);
        }

        public static int GetPossessionCountLimitWeapon()
        {
            return GetConfigIntValue(PossessionCountLimitWeapon);
        }

        public static int GetPossessionCountLimitParts()
        {
            return GetConfigIntValue(PossessionCountLimitParts);
        }

        public static int GetPossessionCountLimitStamina()
        {
            return GetConfigIntValue(PossessionCountLimitStamina);
        }

        public static int GetPossessionCountLimitBp()
        {
            return GetConfigIntValue(PossessionCountLimitBp);
        }

        public static int GetPossessionCountGachaMedal()
        {
            return GetConfigIntValue(PossessionCountGachaMedal);
        }

        public static int GetUserFriendReceiveCheerMaxNumber()
        {
            return GetConfigIntValue(UserFriendReceiveCheerMaxNumber);
        }

        public static int GeUserFriendSendCheerMaxNumber()
        {
            return GetConfigIntValue(UserFriendSendCheerMaxNumber);
        }

        public static bool IsUseTierPrice()
        {
            return GetConfigBoolValue(UseTierPriceFlag);
        }

        public static int GetQuestMissionBigWinBonusPower()
        {
            return GetConfigIntValue(QuestMissionBigWinBonusPower);
        }

        public static int GetMemoryPresetNameMinLength()
        {
            return GetConfigIntValue(MemoryPresetNameMinLength);
        }

        public static int GetMemoryPresetNameMaxLength()
        {
            return GetConfigIntValue(MemoryPresetNameMaxLength);
        }

        public static int GetMemoryPresetTagNameMinLength()
        {
            return GetConfigIntValue(MemoryPresetTagNameMinLength);
        }

        public static int GetMemoryPresetTagNameMaxLength()
        {
            return GetConfigIntValue(MemoryPresetTagNameMaxLength);
        }

        private static int GetConfigIntValue(string key)
        {
            if (DatabaseDefine.Master == null)
                return 0;

            if (int.TryParse(DatabaseDefine.Master.EntityMConfigTable.FindByConfigKey(key).Value, out var configValue))
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
}
