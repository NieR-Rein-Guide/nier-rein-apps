namespace NierReincarnation.Core.Dark.View.UserInterface.Text
{
    public static class UserInterfaceTextKey
    {
        public static class Footer
        {
            public static readonly string kTop = "ui.Outgame.Footer.Top";
            public static readonly string kEnhance = "ui.Outgame.Footer.Enhance";
            public static readonly string kLoadout = "ui.Outgame.Footer.Organization";
            public static readonly string kQuests = "ui.Outgame.Footer.Quest";
            public static readonly string kMap = "ui.Outgame.Footer.Map";
            public static readonly string kLibrary = "ui.Outgame.Footer.Library";
            public static readonly string kSummons = "ui.Outgame.Footer.Gacha";
            public static readonly string kMenu = "ui.Outgame.Footer.Menu";
        }

        public static class Deck
        {
            public static readonly string kTypeQuest = "ui.Outgame.Deck.Type.Quest"; // 0x0
            public static readonly string kTypeMulti = "ui.Outgame.Deck.Type.Multi"; // 0x8
            public static readonly string kTypePvp = "ui.Outgame.Deck.Type.Pvp"; // 0x10
            public static readonly string kTypeBigHunt = "ui.Outgame.Deck.Type.BigHunt"; // 0x18
            public static readonly string kModeSelectTextKey = "ui.Outgame.Deck.Mode.Select"; // 0x20
            public static readonly string kModeCopyTextKey = "ui.Outgame.Deck.Mode.Copy"; // 0x28
            public static readonly string kSelect = "ui.Outgame.Deck.Select"; // 0x30
            public static readonly string kSelectErrorCopyTextKey = "ui.Outgame.Deck.Select.Error.Copy"; // 0x38
            public static readonly string kCopyErrorEmptyTextKey = "ui.Outgame.Deck.Copy.Error.Empty"; // 0x40
            public static readonly string kPasteErrorNoOriginalTextKey = "ui.Outgame.Deck.Paste.Error.NoOriginal"; // 0x48
            public static readonly string kOverwriteTextKey = "ui.Outgame.Deck.Overwrite"; // 0x50
            public static readonly string kDeleteTitleTextKey = "ui.Outgame.Deck.DeleteTitle"; // 0x58
            public static readonly string kDeleteDetailTextKey = "ui.Outgame.Deck.DeleteDetail"; // 0x60
            public static readonly string kCopyTitleTextKey = "ui.Outgame.Deck.CopyTitle"; // 0x68
            public static readonly string kCopyDetailSuccessTextKey = "ui.Outgame.Deck.CopyDetail.Success"; // 0x70
            public static readonly string kCopyDetailFailTextKey = "ui.Outgame.Deck.CopyDetail.Fail"; // 0x78
            public static readonly string kCopyDetailFailAttentionTextKey = "ui.Outgame.Deck.CopyDetail.Fail.Attention"; // 0x80
            public static readonly string kEditNameErrorNullOrWhiteSpace = "ui.Outgame.Deck.EditName.Error.NullOrWhiteSpace"; // 0x88
            public static readonly string kEditNameErrorOverLength = "ui.Outgame.Deck.EditName.Error.OverLength"; // 0x90
            public static readonly string kEditNameTitle = "ui.Outgame.Deck.EditName.Title"; // 0x98
            public static readonly string kList = "ui.Outgame.Deck.List"; // 0xA0
            public static readonly string kDeleteError = "ui.Outgame.Deck.DeleteError"; // 0xA8
            public static readonly string kDeleteErrorDefence = "ui.Outgame.Deck.DeleteError.Defence"; // 0xB0
            public static readonly string kRentalDeck = "ui.Outgame.Deck.RentalDeck"; // 0xB8
            public static readonly string kRestrictionDeck = "ui.Outgame.Deck.RestrictionDeck"; // 0xC0
            public static readonly string kItemAdd = "ui.Outgame.Quest.Deck.Item.Add"; // 0xC8
            public static readonly string kWave = "ui.Outgame.Deck.Wave"; // 0xD0

            public static readonly string kOrganization = "ui.Outgame.Deck.Organization";
            public static readonly string kDeleteDeck = "ui.Outgame.Deck.Delete";
        }

        public static class Organization
        {
            public static readonly string kMemoryBonusLockSmall = "ui.Outgame.Organization.MemoryBonus.Lock.Small"; // 0x28
            public static readonly string kMemoryBonusLockLarge = "ui.Outgame.Organization.MemoryBonus.Lock.Large"; // 0x30

            public static readonly string kAll = "ui.Outgame.Organization.All";
            public static readonly string kRemove = "ui.Outgame.Organization.Remove";
        }

        public static class Ability
        {
            private static readonly string kBasePrefix = "ability."; // 0x0
            public static readonly string kName = kBasePrefix + CommonKeyParts.kName; // 0x8
            public static readonly string kDescriptionLong = kBasePrefix + "description.long.{0}"; // 0x10
            public static readonly string kDescriptionShort = kBasePrefix + "description.short.{0}"; // 0x18
        }

        public static class Header
        {
            public static readonly string kQuestEvent = "ui.Outgame.Header.Quest.Event"; // 0x60
            public static readonly string kOrganization = "ui.Outgame.Header.Organization"; // 0x50

            public static readonly string kUserLevel = "ui.Outgame.Header.UserLevel";
            public static readonly string kStamina = "ui.Outgame.Header.Stamina";
        }

        public static class Skill
        {
            public static readonly string GaugeRiseSpeedPrefix = "ui.Outgame.Skill.GaugeRiseSpeed."; // 0x28
            public static readonly string GaugeRiseSpeedA = GaugeRiseSpeedPrefix + "A"; // 0x30
            public static readonly string GaugeRiseSpeedB = GaugeRiseSpeedPrefix + "B"; // 0x38
            public static readonly string GaugeRiseSpeedC = GaugeRiseSpeedPrefix + "C"; // 0x40
            public static readonly string GaugeRiseSpeedD = GaugeRiseSpeedPrefix + "D"; // 0x48
            public static readonly string GaugeRiseSpeedE = GaugeRiseSpeedPrefix + "E"; // 0x50
        }

        public static class Costume
        {
            private static readonly string kCostumePrefix = "costume."; // 0x0
            private static readonly string kCostumeReplacePrefix = "replace."; // 0x8
            public static readonly string kName = kCostumePrefix + CommonKeyParts.kName; // 0x10
            public static readonly string kNameReplace = kCostumePrefix + "name." + kCostumeReplacePrefix + Common.kOneValueFormat; // 0x18
            public static readonly string kDescription = kCostumePrefix + "description." + Common.kOneValueFormat; // 0x20
            public static readonly string kDescriptionReplace = kCostumePrefix + "description." + kCostumeReplacePrefix + Common.kOneValueFormat; // 0x28
            public static readonly string kEmblemName = kCostumePrefix + "emblem." + CommonKeyParts.kName; // 0x30
        }

        public static class Weapon
        {
            public static readonly string kLock = "ui.Outgame.Weapon.Lock.{0}"; // 0x0
            public static readonly string kName = "weapon.name.{0}.{1}"; // 0x8
        }

        public static class Companion
        {
            public static readonly string kName = "companion." + CommonKeyParts.kName; // 0x0
            public static readonly string kDescription = "companion.description.{0}"; // 0x8
            public static readonly string kCategoryName = "companion.category.{0:D3}"; // 0x10
        }

        public static class Memory
        {
            public static readonly string kSeriesBonusNone = "ui.Outgame.Memory.SeriesBonus.None"; // 0x0
            public static readonly string kSeriesBonusSmall = "ui.Outgame.Memory.SeriesBonus.Small"; // 0x8
            public static readonly string kSeriesBonusLarge = "ui.Outgame.Memory.SeriesBonus.Large"; // 0x10
            public static readonly string kGroupName = "parts.group." + CommonKeyParts.kName; // 0x18
            public static readonly string kGroupDescription = "parts.group.description.{0}"; // 0x20
            public static readonly string kSeriesName = "parts.series." + CommonKeyParts.kName; // 0x28
        }

        public static class Quest
        {
            public static readonly string kConfirmErrorEditDeckLock = "ui.Outgame.Quest.Confirmation.Error.Edit.Deck.Lock"; // 0x0
            public static readonly string kConfirmErrorClearLimitQuestLock = "ui.Outgame.Quest.Confirmation.Error.Clear.Limit.Quest.Lock"; // 0x8
            public static readonly string kConfirmStartErrorAutoSettingNG = "ui.Outgame.Quest.Confirmation.Start.Error.AutoSettingNG"; // 0x10
            public static readonly string kConfirmStartErrorRestrictionCharacter = "ui.Outgame.Quest.Confirmation.Start.Error.RestrictionCharacter"; // 0x18
            public static readonly string kConfirmationErrorStaminaLack = "ui.Outgame.Quest.Confirmation.Error.Stamina.Lack"; // 0x20
            public static readonly string kConfirmStartErrorQuestDifficultyUnopened = "ui.Outgame.Quest.Confirmation.Error.QuestDifficulty.Unopened"; // 0x28
            public static readonly string kEventQuestHoldTermTemplate = "ui.Outgame.Quest.Event.HoldTerm.Template"; // 0x30
            public static readonly string kEventQuestPlayCountOver = "ui.Outgame.Quest.PlayCount.Over"; // 0x38
            public static readonly string kEventQuestTitle = "ui.Outgame.Quest.Event"; // 0x40
            public static readonly string kEventQuestDayOfTheWeek = "ui.Unlock.Event.04"; // 0x48
            public static readonly string kEventQuestGuerrilla = "ui.Unlock.Event.05"; // 0x50
            public static readonly string kEventQuestCharacter = "ui.Outgame.Quest.CharacterQuest"; // 0x58
            public static readonly string kEventQuestEndContents = "ui.Outgame.EndContents.Tab.Menu"; // 0x60
            public static readonly string kEventQuestLimitContent = "ui.Outgame.LimitContent.Tab.Menu"; // 0x68
            public static readonly string kEventQuestDungeon = "ui.Outgame.Dungeon.Tab.Menu"; // 0x70
            public static readonly string kEventQuestTower = "ui.Outgame.Tower.Tab.Menu"; // 0x78
            public static readonly string kEventQuestLimitDailyQuest = "ui.Outgame.LimitDailyQuest.Tab.Menu"; // 0x80
            public static readonly string kEventQuestBoss = "ui.Outgame.Quest.Confirmation.Boss"; // 0x88
            public static readonly string kEventQuestEnemy = "ui.Outgame.Quest.Confirmation.Enemy"; // 0x90
            public static readonly string kMainQuest = "ui.Outgame.Quest.Main"; // 0x98
            public static readonly string kQuestStory = "ui.Outgame.Quest.Story"; // 0xA0
            public static readonly string kEventQuestClose = "ui.Outgame.Quest.Event.Close"; // 0xA8
            public static readonly string kEventQuestNotHolding = "ui.Outgame.Quest.Event.NotHolding"; // 0xB0
            public static readonly string kQuestDifficulty = "ui.Outgame.Quest.Difficulty.{0}"; // 0xB8
            public static readonly string kQuestDifficultyTitle = "ui.Outgame.Quest.DifficultyTitle"; // 0xC0
            public static readonly string kPortalDisable = "ui.Outgame.Quest.Portal.Disable"; // 0xC8
            public static readonly string kPortal = "ui.Outgame.Quest.Portal"; // 0xD0
            public static readonly string kLockOrTextKey = "ui.Outgame.Quest.Lock.Or"; // 0xD8
            public static readonly string kLockAndTextKey = "ui.Outgame.Quest.Lock.And"; // 0xE0
            public static readonly string kEventTermFormat = "ui.Outgame.Quest.EventTerm.Format"; // 0xE8
            public static readonly string kEventRemainLong = "ui.Outgame.Quest.Event.Remain.Long"; // 0xF0
            public static readonly string kEventRemainShort = "ui.Outgame.Quest.Event.Remain.Short"; // 0xF8
            public static readonly string kDeckPowerLock = "ui.Outgame.Quest.DeckPower.Lock"; // 0x100
            public static readonly string kUserLevelLock = "ui.Outgame.Quest.UserLevel.Lock"; // 0x108
            public static readonly string kCharacterLevelLock = "ui.Outgame.Quest.CharacterLevel.Lock"; // 0x110
            public static readonly string kAcquisitionCount = "ui.Outgame.Quest.Acquisition.Count"; // 0x118
            public static readonly string kConfirmationTitle = "ui.Outgame.Quest.Confirmation.Title"; // 0x120
            public static readonly string kDifficulty = "ui.Outgame.Quest.Difficulty.{0}"; // 0x128
            public static readonly string kRoundAutoNext = "ui.Outgame.Quest.Round.AutoNext"; // 0x130
            public static readonly string kRoundNext = "ui.Outgame.Quest.Round.Next"; // 0x138
            public static readonly string kRoundEnd = "ui.Outgame.Quest.Round.End"; // 0x140
            public static readonly string kBonusTitle = "ui.Outgame.Quest.Bonus.Title"; // 0x148
            public static readonly string kConfirmationAuto = "ui.Outgame.Quest.Confirmation.Auto"; // 0x150
            public static readonly string kConfirmationAutoNG = "ui.Outgame.Quest.Confirmation.AutoNG"; // 0x158
            public static readonly string kConfirmationBattleOnlyOffNGAuto = "ui.Outgame.Quest.Confirmation.BattleOnly.OffNG.Auto"; // 0x160
            public static readonly string kConfirmationBattleOnlyOffNGBattleOnlyQuest = "ui.Outgame.Quest.Confirmation.BattleOnly.OffNG.BattleOnlyQuest"; // 0x168
            public static readonly string kEventBoxGacha = "ui.Outgame.Quest.Event.BoxGacha"; // 0x170
            public static readonly string kEventExchange = "ui.Outgame.Quest.Event.Exchange"; // 0x178
            public static readonly string kEventOpen = "ui.Outgame.Quest.Event.Open"; // 0x180
            public static readonly string kEventFreeOpenCount = "ui.Outgame.Quest.Event.FreeOpenCount"; // 0x188
            public static readonly string kEventFreeOpenConfirmationTitle = "ui.Outgame.Quest.Event.ForceOpen.Confirmation.Title"; // 0x190
            public static readonly string kEventFreeOpenConfirmationMessagePaymentOpen = "ui.Outgame.Quest.Event.ForceOpen.Confirmation.Message.PaymentOpen"; // 0x198
            public static readonly string kEventFreeOpenConfirmationNotifyFreeOpen = "ui.Outgame.Quest.Event.ForceOpen.Confirmation.Notify.FreeOpen"; // 0x1A0
            public static readonly string kEventFreeOpenConfirmationNotifyReset = "ui.Outgame.Quest.Event.ForceOpen.Confirmation.Notify.Reset"; // 0x1A8
            public static readonly string kEventFreeOpenConfirmationNotifyTern = "ui.Outgame.Quest.Event.ForceOpen.Confirmation.Notify.Tern"; // 0x1B0
            public static readonly string kExPlayCount = "ui.Outgame.Quest.ExPlay.Count"; // 0x1B8
            public static readonly string kBonusLimitBreakNone = "ui.Outgame.Quest.Bonus.LimitBreak.None"; // 0x1C0
            public static readonly string kBonusLimitBreakStage = "ui.Outgame.Quest.Bonus.LimitBreak.Stage"; // 0x1C8
            public static readonly string kAttentionDailyLimitedCount = "ui.Outgame.Quest.Attention.DailyLimited.Count"; // 0x1D0
            public static readonly string kInvalidTermError = "ui.Outgame.Quest.InvalidTerm.Error"; // 0x1D8
            public static readonly string kBonusCampaignTitle = "ui.Outgame.Quest.Bonus.Campaign.Title"; // 0x1E0
            public static readonly string kBonusDeckTitle = "ui.Outgame.Quest.Bonus.Deck.Title"; // 0x1E8
            public static readonly string kBonusGohobiTitle = "ui.Outgame.Quest.Bonus.Gohobi.Title"; // 0x1F0
            public static readonly string kCommonHeldCount = "ui.Outgame.Common.HeldCount"; // 0x1F8
            public static readonly string kBonusCollectionTitle = "ui.Outgame.Quest.Bonus.collection.Title"; // 0x200
            public static readonly string kQuestNameTextKey = "quest." + CommonKeyParts.kName; // 0x208
            public static readonly string kQuestBossInfoTitle = "ui.Outgame.Quest.BossInformation.Title"; // 0x210
            public static readonly string kQuestDescriptionItemization = "ui.Outgame.Quest.Description.Itemization"; // 0x218
            public static readonly string kMissionMainTitleTextKey = "quest.Mission.Main.Title.{0}"; // 0x220
            public static readonly string kMissionMainTitleLimitedTextKeySuffix = ".limited"; // 0x228
            public static readonly string kBonusDropTextKey = "quest.Bonus.Drop"; // 0x230
            public static readonly string kBonusExpTextKey = "quest.Bonus.Exp"; // 0x238
            public static readonly string kMainSeasonTitle = "quest.main.season_title.{0}"; // 0x240
            public static readonly string kMainChapterNumber = "quest.main.chapter_number.{0}.{1}.{2}"; // 0x248
            public static readonly string kMainChapterTitle = "quest.main.chapter_title.{0}.{1}.{2}"; // 0x250
            public static readonly string kEventChapterTitle = "quest.event.chapter_title.{0}"; // 0x258
            public static readonly string kEventChapterTitleDungeon = "quest.event.dungeon.chapter_title.{0}"; // 0x260
            public static readonly string kEventDailyMessage = "quest.event.daily.message.{0}"; // 0x268
            public static readonly string kBossName = "quest.boss." + CommonKeyParts.kName; // 0x270
            public static readonly string kBossDescription = "quest.boss.description.{0}"; // 0x278
            public static readonly string kTowerRewardPrgoressDetail = "ui.Outgame.Quest.Event.Tower.Reward.ProgressDetail"; // 0x280
            public static readonly string kTowerRewardPrgoressComplete = "ui.Outgame.Quest.Event.Tower.Reward.ProgressComplete"; // 0x288
            public static readonly string kTowerMissionDialogTitle = "ui.Outgame.Quest.Event.Tower.MissionDialog.Title"; // 0x290
            public static readonly string kTowerMissionDialogDescription = "ui.Outgame.Quest.Event.Tower.MissionDialog.Description"; // 0x298
            public static readonly string kQuestMissionAnd = "ui.Outgame.Quest.Mission.And"; // 0x2A0
            public static readonly string kQuestMissionOr = "ui.Outgame.Quest.Mission.Or"; // 0x2A8
            public static readonly string kSkipDisableNotPossession = "ui.Outgame.Quest.Skip.Disable.NotPossession"; // 0x2B0
            public static readonly string kSkipConfirmation = "ui.Outgame.Quest.Skip.Confirmation"; // 0x2B8
            public static readonly string kSkipResult = "ui.Outgame.Quest.Skip.Result"; // 0x2C0
            public static readonly string kSkipStartDisableLackStamina = "ui.Outgame.Quest.Skip.Start.Disable.LackStamina"; // 0x2C8
            public static readonly string kConfirmationSettingTitle = "ui.Outgame.Quest.Confirmation.Setting.Title"; // 0x2D0
            public static readonly string kFieldEffectTitle = "ui.Outgame.Quest.FieldEffect.Title"; // 0x2D8
            public static readonly string kFieldEffectTargetAll = "ui.Outgame.Quest.FieldEffect.Target.All"; // 0x2E0
            public static readonly string kFieldEffectTargetSelf = "ui.Outgame.Quest.FieldEffect.Target.Self"; // 0x2E8
            public static readonly string kFieldEffectDecreaseTitle = "ui.Outgame.Quest.FieldEffect.Decrease"; // 0x2F0
            public static readonly string kEventQuestLimitContentConfirmationTitle = "ui.Outgame.LimitContent.Confirmation.Title"; // 0x2F8
            public static readonly string kEventQuestLimitContentConfirmationMessage = "ui.Outgame.LimitContent.Confirmation.Message"; // 0x300
            public static readonly string kEventQuestRewardReceive = "ui.Outgame.Quest.Reward.Receive"; // 0x308
            public static readonly string kEventQuestRewardReceived = "ui.Outgame.Quest.Reward.Received"; // 0x310
            public static readonly string kEventQuestRewardReceiveErrorExpired = "ui.Outgame.Quest.Reward.Receive.Error.Expired"; // 0x318
            public static readonly string kEventQuestRewardReceiveErrorNotClear = "ui.Outgame.Quest.Reward.Receive.Error.NotClear"; // 0x320
            public static readonly string kEventQuestRewardReceiveErrorReceived = "ui.Outgame.Quest.Reward.Receive.Error.Received"; // 0x328
            public static readonly string kQuestBonusRemainTime = "ui.Outgame.Quest.Bonus.RemainTime"; // 0x330
            public static readonly string kMainChapterTitleWithTextAssetId = "quest.main.chapter_title.{0}.{1}.{2}.{3}"; // 0x338
            public static readonly string kEventQuestQuestEffectTitle = "ui.Outgame.Quest.Event.Quest.Effect.Title"; // 0x340
            public static readonly string kEventQuestQuestEffectDescriptionFree = "quest.event.quest.effect.description.free.{0}"; // 0x348
            public static readonly string kEventQuestLabyrinthMobMessage = "quest.event.labyrinth.mob.message.{0}"; // 0x350
            public static readonly string kLabyrinthQuestMissionRewardProgressDetail = "ui.Outgame.Quest.Event.Labyrinth.QuestMissionReward.ProgressDetail"; // 0x358
            public static readonly string kLabyrinthQuestMissionRewardProgressComplete = "ui.Outgame.Quest.Event.Labyrinth.QuestMissionReward.ProgressComplete"; // 0x360
            public static readonly string kLabyrinthStage = "ui.Outgame.Quest.Event.Labyrinth.Stage"; // 0x368

            public static class Labyrinth
            {
                public static readonly string kQuestListTitle = "ui.Outgame.Quest.Event.Labyrinth.QuestList.Title"; // 0x0
                public static readonly string KQuestListStageName = "ui.Outgame.Quest.Event.Labyrinth.QuestList.Stage"; // 0x8
                public static readonly string kMissionRewardTitle = "ui.Outgame.Quest.Event.Labyrinth.MissionReward.Title"; // 0x10
                public static readonly string kMissionRewardSubtitle = "ui.Outgame.Quest.Event.Labyrinth.MissionReward.Subtitle"; // 0x18
                public static readonly string kMissionDescription = "ui.Outgame.Quest.Event.Labyrinth.MissionReward.Description"; // 0x20
                public static readonly string kReachRewardTitle = "ui.Outgame.Quest.Event.Labyrinth.ReachReward.Title"; // 0x28
                public static readonly string kReachRewardReachQuest = "ui.Outgame.Quest.Event.Labyrinth.ReachReward.ReachQuest"; // 0x30
                public static readonly string kReachRewardStage = "ui.Outgame.Quest.Event.Labyrinth.ReachReward.Stage"; // 0x38
                public static readonly string kReachRewardResultTitle = "ui.Outgame.Quest.Event.Labyrinth.ReachRewardResult.Title"; // 0x40
                public static readonly string kReachRewardResultReachDetail = "ui.Outgame.Quest.Event.Labyrinth.ReachRewardResult.ReachDetail"; // 0x48
            }
        }

        public static class Material
        {
            public static readonly string kName = "material.name.{0:D3}{1:D3}"; // 0x0
            public static readonly string kDescription = "material.description.{0:D3}{1:D3}"; // 0x8
        }

        public static class ConsumableItem
        {
            public static readonly string kName = "consumable_item.name.{0:D3}{1:D3}"; // 0x0
            public static readonly string kDescription = "consumable_item.description.{0:D3}{1:D3}"; // 0x8
        }

        public static class Gem
        {
            public static readonly string kNameTextKey = "gem.name"; // 0x0
            public static readonly string kPaidNameTextKey = "gem.paid.name"; // 0x8
            public static readonly string kFreeNameTextKey = "gem.free.name"; // 0x10
            public static readonly string kDescriptionTextKey = "gem.description"; // 0x18
            public static readonly string kCounterSuffix = "gem.CounterSuffix"; // 0x20
        }

        public static class ImportantItem
        {
            public static readonly string kName = "important_item.name.{0:D6}"; // 0x0
            public static readonly string kDescription = "important_item.description.{0:D6}"; // 0x8
        }

        public static class Shop
        {
            public static readonly string kPurchaseErrorRefund = "ui.Outgame.Shop.Purchase.Error.Refund"; // 0x1E8
            public static readonly string kPurchaseErrorRetry = "ui.Outgame.Shop.Purchase.Error.Retry"; // 0x1F0
        }

        public static class Flow
        {
            public static readonly string kRetryTitleTextKey = "ui.Flow.Retry.Title"; // 0x0
            public static readonly string kRetrySelectTextKey = "ui.Flow.Retry.Select"; // 0x8
            public static readonly string kRetryCancelTextKey = "ui.Flow.Retry.Cancel"; // 0x10
            public static readonly string kRetryQuestDescription = "ui.Flow.Retry.Quest.Description"; // 0x18
            public static readonly string kRetryMinigameDescription = "ui.Flow.Retry.Minigame.Description"; // 0x20
            public static readonly string kRetryMinigameResultDescription = kRetryMinigameDescription + ".Result"; // 0x28
            public static readonly string kRetryQuestWarning = "ui.Flow.Retry.Quest.Warning"; // 0x30
            public static readonly string kRetryQuestWarningAuto = "ui.Flow.Retry.Quest.Warning.Auto"; // 0x38
            public static readonly string kRetryMinigameWarning = "ui.Flow.Retry.Minigame.Warning"; // 0x40
            public static readonly string kRetryMinigameResultWarning = kRetryMinigameWarning + ".Result"; // 0x48
        }

        public static class Unlock
        {
            public static readonly string kUnlockReachedMainQuest; // 0x0
            public static readonly string kUnlockMemory; // 0x8
            public static readonly string kUnlockArena; // 0x10
            public static readonly string kUnlockOrnamentStill; // 0x18
            public static readonly string kUnlockWeaponStory; // 0x20
            public static readonly string kUnlockDifficultyMainQuestFirstHard; // 0x28
            public static readonly string kUnlockDifficultyMainQuestChapter; // 0x30
            public static readonly string kUnlockDifficultySubQuestHard; // 0x38
            public static readonly string kUnlockDifficultySubQuestVeryHard; // 0x40
            public static readonly string kUnlockDifficultySubQuestExtraHard; // 0x48
            public static readonly string kUnLockBy = "ui.Unlock.UnLockBy"; // 0x50
            public static readonly string kEventFormat; // 0x58
            public static readonly string kUnlockBigHunt; // 0x60
            public static readonly string kUnlockCharacterBoard; // 0x68
            public static readonly string kUnlockCharacterBoardBigHunt; // 0x70
            public static readonly string kDailyGacha; // 0x78
            public static readonly string kDailyQuest; // 0x80
            public static readonly string kTitle; // 0x88
            public static readonly string kUnLockSmartphone; // 0x90
        }

        public static class BigHunt
        {
            public static readonly string kBigHuntLockScore = "ui.Outgame.BigHunt.Lock.Score"; // 0x0
            public static readonly string kStartErrorInvalidDeck = "ui.Outgame.BigHunt.Start.Error.InvalidDeck"; // 0x8
            public static readonly string kRewardDetail = "ui.Outgame.BigHunt.RewardDetail"; // 0x10
            public static readonly string kDisableInterval = "ui.Outgame.BigHunt.Disable.Interval"; // 0x18
            public static readonly string kBattleReport = "ui.Outgame.BigHunt.BattleReport"; // 0x20
            public static readonly string kTodayReceived = "ui.Outgame.BigHunt.Today.Received"; // 0x28
            public static readonly string kReceive = "ui.Outgame.BigHunt.Receive"; // 0x30
            public static readonly string kReceived = "ui.Outgame.BigHunt.Received"; // 0x38
            public static readonly string kDailyReward = "ui.Outgame.BigHunt.DailyReward"; // 0x40
            public static readonly string kWeeklyResult = "ui.Outgame.BigHunt.WeeklyResult"; // 0x48
            public static readonly string kNeedScore = "ui.Outgame.BigHunt.NeedScore"; // 0x50
            public static readonly string kBossNameFormat = "bigHunt.boss.name.{0}"; // 0x58
            public static readonly string kRandomDisplayValueTypeFormat = "bigHunt.RandomDisplayValueType.{0}"; // 0x60
        }

        public static class Common
        {
            public static readonly string kCommonEmptyTextKey = "ui.Outgame.Common.Empty"; // 0x0
            public static readonly string kCommonOkTextKey = "ui.Outgame.Common.Ok"; // 0x8
            public static readonly string kCommonCancelTextKey = "ui.Outgame.Common.Cancel"; // 0x10
            public static readonly string kCommonYesTextKey = "ui.Outgame.Common.Yes"; // 0x18
            public static readonly string kCommonNoTextKey = "ui.Outgame.Common.No"; // 0x20
            public static readonly string kCommonFractionTextKey = "ui.Outgame.Common.Fraction"; // 0x28
            public static readonly string kCommonDecideTextKey = "ui.Outgame.Common.Decide"; // 0x30
            public static readonly string kCommonCloseTextKey = "ui.Outgame.Common.Close"; // 0x38
            public static readonly string kMinCountTextKey = "ui.Outgame.Common.MinCount"; // 0x40
            public static readonly string kMaxCountTextKey = "ui.Outgame.Common.MaxCount"; // 0x48
            public static readonly string kQuestionMarksKey = "ui.Outgame.Common.QuestionMarks"; // 0x50
            public static readonly string kNotPossessionTextKey = "ui.Outgame.Common.NotPossession"; // 0x58
            public static readonly string kPossessionWithCount = "ui.Outgame.Common.Possession.WithCount"; // 0x60
            public static readonly string kPassedDateTimeYear = "ui.Outgame.Common.Passed.DateTime.Year"; // 0x68
            public static readonly string kPassedDateTimeDay = "ui.Outgame.Common.Passed.DateTime.Day"; // 0x70
            public static readonly string kPassedDateTimeHour = "ui.Outgame.Common.Passed.DateTime.Hour"; // 0x78
            public static readonly string kPassedDateTimeMinute = "ui.Outgame.Common.Passed.DateTime.Minute"; // 0x80
            public static readonly string kLevelWithMax = "ui.Outgame.Common.LevelWithMax"; // 0x88
            public static readonly string kLevel = "ui.Outgame.Common.Level"; // 0x90
            public static readonly string kPercent = "ui.Outgame.Common.Percent"; // 0x98
            public static readonly string kItemAndCount = "ui.Outgame.Common.ItemAndCount"; // 0xA0
            public static readonly string kTerm = "ui.Outgame.Common.Term"; // 0xA8
            public static readonly string kStart = "ui.Outgame.Common.Start"; // 0xB0
            public static readonly string kContinue = "ui.Outgame.Common.Continue"; // 0xB8
            public static readonly string kLevelWithMaxEmphasisLevel = "ui.Outgame.Common.LevelWithMax.Emphasis.Level"; // 0xC0
            public static readonly string kLevelWithMaxEmphasisLevelAndMaxLevel = "ui.Outgame.Common.LevelWithMax.Emphasis.LevelAndMaxLevel"; // 0xC8
            public static readonly string kLevelWithMaxEmphasisMaxLevel = "ui.Outgame.Common.LevelWithMax.Emphasis.MaxLevel"; // 0xD0
            public static readonly string kChange = "ui.Outgame.Common.Change"; // 0xD8
            public static readonly string kCommonGemLackWarningTextKey = "ui.Outgame.Common.Gem.Lack.Warning.ver2"; // 0xE0
            public static readonly string kCommonGemConsumeWarningTextKey = "ui.Outgame.Common.Gem.Consume.Warning"; // 0xE8
            public static readonly string kLevelTextEnd = "ui.Outgame.Common.LevelTextEnd"; // 0xF0
            public static readonly string kNotEnoughGold = "ui.Outgame.Common.NotEnoughGold"; // 0xF8
            public static readonly string kNoneAcquisitionRouteKey = "ui.Outgame.Common.NoneAcquisitionRoute"; // 0x100
            public static readonly string kNotAvailableTextKey = "ui.Common.NotAvailable"; // 0x108
            public static readonly string kOmittedDigitNumber = "ui.Outgame.Common.OmittedDigitNumber"; // 0x110
            public static readonly string kTime = "ui.Outgame.Common.Time"; // 0x118
            public static readonly string kTimeDay = "ui.Outgame.Common.Time.Day"; // 0x120
            public static readonly string kTimeHour = "ui.Outgame.Common.Time.Hour"; // 0x128
            public static readonly string kTimeMinute = "ui.Outgame.Common.Time.Minute"; // 0x130
            public static readonly string kTimeDigital = "ui.Outgame.Common.Time.Digital"; // 0x138
            public static readonly string kLack = "ui.Outgame.Common.Lack"; // 0x140
            public static readonly string kUnlockTiming = "ui.Outgame.Common.Unlock.Timing"; // 0x148
            public static readonly string kValue = "ui.Outgame.Common.Value"; // 0x150
            public static readonly string kRarityName = "ui.Outgame.Common.Rarity.Name.{0:D2}"; // 0x158
            public static readonly string kPlus = "ui.Outgame.Common.Plus"; // 0x160
            public static readonly string kEmphasis = "ui.Outgame.Common.Emphasis"; // 0x168
            public static readonly string kOthers = "ui.Outgame.Common.Others"; // 0x170
            public static readonly string kLackWarning = "ui.Outgame.Common.Lack.Warning"; // 0x178
            public static readonly string kClearQuestEventDefault = "ui.Outgame.Common.Clear.Quest.Event.Default"; // 0x180
            public static readonly string kClearQuestEventDifficulty = "ui.Outgame.Common.Clear.Quest.Event.Difficulty"; // 0x188
            public static readonly string kClearQuestMainDefault = "ui.Outgame.Common.Clear.Quest.Main.Default"; // 0x190
            public static readonly string kClearQuestMainDifficulty = "ui.Outgame.Common.Clear.Quest.Main.Difficulty"; // 0x198
            public static readonly string kClearQuestMainChapter = "ui.Outgame.Common.Clear.Quest.Main.Chapter"; // 0x1A0
            public static readonly string kClear = "ui.Outgame.Common.Clear"; // 0x1A8
            public static readonly string kMaintenanceUndecided = "ui.Outgame.Common.Maintenance.Undecided"; // 0x1B0
            public static readonly string kMaintenance = "ui.Outgame.Common.Maintenance.Parts"; // 0x1B8
            public static readonly string kMaintenancePartMessage = "ui.Outgame.Common.maintenance.Part.Message"; // 0x1C0
            public static readonly string kPreviousNote = "ui.Outgame.Common.PreviousNote"; // 0x1C8
            public static readonly string kAttributeTextKey = "ui.Outgame.Attribute.{0}"; // 0x1D0
            public static readonly string kWeaponTypeTextKey = "ui.Outgame.WeaponType.{0}"; // 0x1D8
            public static readonly string kOneValueFormat = "{0}"; // 0x1E0
            public static readonly string kThreeKeyValueFormat = "{0}.{1}.{2}."; // 0x1E8
        }

        private static class CommonKeyParts
        {
            public static readonly string kName = "name.{0}"; // 0x0
        }

        public static class EndContents
        {
            public static readonly string kUnlockQuest = "ui.Outgame.EndContents.Unlock.Quest"; // 0x0
        }

        public static class Date
        {
            public static readonly string kYearMonthDate = "ui.Outgame.Date.YearMonthDate"; // 0x0
            public static readonly string kYearMonthDateTime = kYearMonthDate + "Time"; // 0x8
        }

        public static class Search
        {
            public static readonly string kErrorCool = "ui.Outgame.Search.Error.Cool"; // 0x0
            public static readonly string kUnlockHighScore = "ui.Outgame.Search.Unlock.HighScore"; // 0x8
        }
    }
}
