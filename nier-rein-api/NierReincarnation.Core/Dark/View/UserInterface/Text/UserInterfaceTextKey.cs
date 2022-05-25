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
            public static readonly string kRentalDeck = "ui.Outgame.Deck.RentalDeck"; // 0xB8
        }

        public static class Organization
        {
            public static readonly string kMemoryBonusLockSmall = "ui.Outgame.Organization.MemoryBonus.Lock.Small"; // 0x28
            public static readonly string kMemoryBonusLockLarge = "ui.Outgame.Organization.MemoryBonus.Lock.Large"; // 0x30
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
            public static readonly string kName = kCostumePrefix + CommonKeyParts.kName; // 0x8
            public static readonly string kDescription = kCostumePrefix + "description.{0}"; // 0x10
            public static readonly string kEmblemName = kCostumePrefix + "emblem." + CommonKeyParts.kName; // 0x18
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
            public static readonly string kConfirmErrorEditDeckLock= "ui.Outgame.Quest.Confirmation.Error.Edit.Deck.Lock"; // 0x0
            public static readonly string kConfirmStartErrorAutoSettingNG= "ui.Outgame.Quest.Confirmation.Start.Error.AutoSettingNG"; // 0x8
            public static readonly string kConfirmStartErrorRestrictionCharacter= "ui.Outgame.Quest.Confirmation.Start.Error.RestrictionCharacter"; // 0x10
            public static readonly string kConfirmationErrorStaminaLack= "ui.Outgame.Quest.Confirmation.Error.Stamina.Lack"; // 0x18
            public static readonly string kConfirmStartErrorQuestDifficultyUnopened= "ui.Outgame.Quest.Confirmation.Error.QuestDifficulty.Unopened"; // 0x20
            public static readonly string kEventQuestHoldTermTemplate= "ui.Outgame.Quest.Event.HoldTerm.Template"; // 0x28
            public static readonly string kEventQuestPlayCountOver= "ui.Outgame.Quest.PlayCount.Over"; // 0x30
            public static readonly string kEventQuestTitle= "ui.Outgame.Quest.Event"; // 0x38
            public static readonly string kEventQuestDayOfTheWeek= "ui.Unlock.Event.04"; // 0x40
            public static readonly string kEventQuestGuerrilla= "ui.Unlock.Event.05"; // 0x48
            public static readonly string kEventQuestCharacter= "ui.Outgame.Quest.CharacterQuest"; // 0x50
            public static readonly string kEventQuestEndContents= "ui.Outgame.EndContents.Tab.Menu"; // 0x58
            public static readonly string kEventQuestBoss= "ui.Outgame.Quest.Confirmation.Boss"; // 0x60
            public static readonly string kEventQuestEnemy= "ui.Outgame.Quest.Confirmation.Enemy"; // 0x68
            public static readonly string kMainQuest= "ui.Outgame.Quest.Main"; // 0x70
            public static readonly string kQuestStory= "ui.Outgame.Quest.Story"; // 0x78
            public static readonly string kEventQuestClose= "ui.Outgame.Quest.Event.Close"; // 0x80
            public static readonly string kQuestDifficulty= "ui.Outgame.Quest.Difficulty.{0}"; // 0x88
            public static readonly string kQuestDifficultyTitle= "ui.Outgame.Quest.DifficultyTitle"; // 0x90
            public static readonly string kPortalDisable= "ui.Outgame.Quest.Portal.Disable"; // 0x98
            public static readonly string kPortal= "ui.Outgame.Quest.Portal"; // 0xA0
            public static readonly string kLockOrTextKey= "ui.Outgame.Quest.Lock.Or"; // 0xA8
            public static readonly string kLockAndTextKey= "ui.Outgame.Quest.Lock.And"; // 0xB0
            public static readonly string kEventTermFormat= "ui.Outgame.Quest.EventTerm.Format"; // 0xB8
            public static readonly string kEventRemainLong= "ui.Outgame.Quest.Event.Remain.Long"; // 0xC0
            public static readonly string kEventRemainShort= "ui.Outgame.Quest.Event.Remain.Short"; // 0xC8
            public static readonly string kDeckPowerLock= "ui.Outgame.Quest.DeckPower.Lock"; // 0xD0
            public static readonly string kUserLevelLock= "ui.Outgame.Quest.UserLevel.Lock"; // 0xD8
            public static readonly string kCharacterLevelLock= "ui.Outgame.Quest.CharacterLevel.Lock"; // 0xE0
            public static readonly string kAcquisitionCount= "ui.Outgame.Quest.Acquisition.Count"; // 0xE8
            public static readonly string kConfirmationTitle= "ui.Outgame.Quest.Confirmation.Title"; // 0xF0
            public static readonly string kDifficulty= kQuestDifficulty; // 0xF8
            public static readonly string kRoundAutoNext= "ui.Outgame.Quest.Round.AutoNext"; // 0x100
            public static readonly string kRoundNext= "ui.Outgame.Quest.Round.Next"; // 0x108
            public static readonly string kRoundEnd= "ui.Outgame.Quest.Round.End"; // 0x110
            public static readonly string kBonusTitle= "ui.Outgame.Quest.Bonus.Title"; // 0x118
            public static readonly string kConfirmationAuto= "ui.Outgame.Quest.Confirmation.Auto"; // 0x120
            public static readonly string kConfirmationAutoNG= "ui.Outgame.Quest.Confirmation.AutoNG"; // 0x128
            public static readonly string kConfirmationBattleOnlyOffNGAuto= "ui.Outgame.Quest.Confirmation.BattleOnly.OffNG.Auto"; // 0x130
            public static readonly string kConfirmationBattleOnlyOffNGBattleOnlyQuest= "ui.Outgame.Quest.Confirmation.BattleOnly.OffNG.BattleOnlyQuest"; // 0x138
            public static readonly string kEventBoxGacha= "ui.Outgame.Quest.Event.BoxGacha"; // 0x140
            public static readonly string kEventExchange= "ui.Outgame.Quest.Event.Exchange"; // 0x148
            public static readonly string kExPlayCount= "ui.Outgame.Quest.ExPlay.Count"; // 0x150
            public static readonly string kBonusLimitBreakNone= "ui.Outgame.Quest.Bonus.LimitBreak.None"; // 0x158
            public static readonly string kBonusLimitBreakStage= "ui.Outgame.Quest.Bonus.LimitBreak.Stage"; // 0x160
            public static readonly string kAttentionDailyLimitedCount= "ui.Outgame.Quest.Attention.DailyLimited.Count"; // 0x168
            public static readonly string kInvalidTermError= "ui.Outgame.Quest.InvalidTerm.Error"; // 0x170
            public static readonly string kBonusCampaignTitle= "ui.Outgame.Quest.Bonus.Campaign.Title"; // 0x178
            public static readonly string kBonusDeckTitle= "ui.Outgame.Quest.Bonus.Deck.Title"; // 0x180
            public static readonly string kBonusGohobiTitle= "ui.Outgame.Quest.Bonus.Gohobi.Title"; // 0x188
            public static readonly string kCommonHeldCount= "ui.Outgame.Common.HeldCount"; // 0x190
            public static readonly string kBonusCollectionTitle= "ui.Outgame.Quest.Bonus.collection.Title"; // 0x198
            public static readonly string kQuestNameTextKey= "quest." + CommonKeyParts.kName; // 0x1A0
            public static readonly string kQuestBossInfoTitle= "ui.Outgame.Quest.BossInformation.Title"; // 0x1A8
            public static readonly string kQuestDescriptionItemization= "ui.Outgame.Quest.Description.Itemization"; // 0x1B0
            public static readonly string kMissionMainTitleTextKey= "quest.Mission.Main.Title.{0}"; // 0x1B8
            public static readonly string kMissionMainTitleLimitedTextKeySuffix= ".limited"; // 0x1C0
            public static readonly string kBonusDropTextKey= "quest.Bonus.Drop"; // 0x1C8
            public static readonly string kBonusExpTextKey= "quest.Bonus.Exp"; // 0x1D0
            public static readonly string kMainSeasonTitle= "quest.main.season_title.{0}"; // 0x1D8
            public static readonly string kMainChapterNumber= "quest.main.chapter_number.{0}.{1}.{2}"; // 0x1E0
            public static readonly string kMainChapterTitle= "quest.main.chapter_title.{0}.{1}.{2}"; // 0x1E8
            public static readonly string kEventChapterTitle= "quest.event.chapter_title.{0}"; // 0x1F0
            public static readonly string kBossName= "quest.boss."+ CommonKeyParts.kName; // 0x1F8
            public static readonly string kBossDescription= "quest.boss.description.{0}"; // 0x200
            public static readonly string kTowerRewardPrgoressDetail= "ui.Outgame.Quest.Event.Tower.Reward.ProgressDetail"; // 0x208
            public static readonly string kTowerRewardPrgoressComplete= "ui.Outgame.Quest.Event.Tower.Reward.ProgressComplete"; // 0x210
            public static readonly string kTowerMissionDialogTitle= "ui.Outgame.Quest.Event.Tower.MissionDialog.Title"; // 0x218
            public static readonly string kTowerMissionDialogDescription= "ui.Outgame.Quest.Event.Tower.MissionDialog.Description"; // 0x220
            public static readonly string kQuestMissionAnd= "ui.Outgame.Quest.Mission.And"; // 0x228
            public static readonly string kQuestMissionOr= "ui.Outgame.Quest.Mission.Or"; // 0x230
            public static readonly string kSkipDisableNotPossession= "ui.Outgame.Quest.Skip.Disable.NotPossession"; // 0x238
            public static readonly string kSkipConfirmation= "ui.Outgame.Quest.Skip.Confirmation"; // 0x240
            public static readonly string kSkipResult= "ui.Outgame.Quest.Skip.Result"; // 0x248
            public static readonly string kSkipStartDisableLackStamina= "ui.Outgame.Quest.Skip.Start.Disable.LackStamina"; // 0x250
            public static readonly string kConfirmationSettingTitle= "ui.Outgame.Quest.Confirmation.Setting.Title"; // 0x258

            public static readonly string kBigHuntQuest = "ui.Outgame.Quest.BigHunt";
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

        private static class CommonKeyParts
        {
            public static readonly string kName = "name.{0}"; // 0x0
        }
    }
}
