using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using NierReincarnation.Core.UnityEngine;

namespace nier_rein_gui.Resources
{
    static class LocalizationResources
    {
        private const string ResourceName_ = "nier-rein-gui.Resources.Localizations.{0}.json";

        private const string TitleText_ = "General.Title";
        private const string GameVersionText_ = "General.GameVersion";
        private const string ClearText_ = "General.Clear";
        private const string ClearOnceText_ = "General.ClearOnce";
        private const string CancelText_ = "General.Cancel";
        private const string StartText_ = "General.Start";
        private const string SelectText_ = "General.Select";

        private const string CooldownText_ = "General.Cooldown";
        private const string CooldownTitleText_ = "General.Cooldown.Title";
        private const string CooldownDescriptionText_ = "General.Cooldown.Description";

        private const string CostumesTitleText_ = "Dialog.Title.Costumes";
        private const string WeaponsTitleText_ = "Dialog.Title.Weapons";
        private const string CompanionsTitleText_ = "Dialog.Title.Companions";
        private const string MemoirsTitleText_ = "Dialog.Title.Memoirs";
        private const string DebrisTitleText_ = "Dialog.Title.Debris";

        private const string DeckCostumeTitleText_ = "Dialog.Deck.Costume";
        private const string DeckWeaponTitleText_ = "Dialog.Deck.Weapon";
        private const string DeckCompanionTitleText_ = "Dialog.Deck.Companion";
        private const string DeckMemoirTitleText_ = "Dialog.Deck.Memoir";
        private const string DeckDebrisTitleText_ = "Dialog.Deck.Debris";
        private const string DeckDeleteDescriptionText_ = "Dialog.Deck.Delete.Description";
        private const string DeckRenameTitleText_ = "Dialog.Deck.Rename.Title";
        private const string DeckRenameDescriptionText_ = "Dialog.Deck.Rename.Description";
        private const string DeckRenamePlaceholderText_ = "Dialog.Deck.Rename.Placeholder";
        private const string DeckRenameErrorText_ = "Dialog.Deck.Rename.Error";

        private const string ItemChosenText_ = "Dialog.Item.Chosen";
        private const string ItemInDeckText_ = "Dialog.Item.InDeck";

        private const string WeaponsNoneText_ = "Dialog.Weapons.None";

        private const string AuthTitleText_ = "Dialog.Auth.Title";
        private const string AuthDescriptionText_ = "Dialog.Auth.Description";

        private const string StartupTitleText_ = "Dialog.Startup.Title";
        private const string SetupDescriptionText_ = "Dialog.Startup.Setup.Description";
        private const string LoginTitleText_ = "Dialog.Startup.Login.Title";
        private const string LoginUsernameText_ = "Dialog.Startup.Login.Username";
        private const string LoginPasswordText_ = "Dialog.Startup.Login.Password";
        private const string LoginButtonText_ = "Dialog.Startup.Login.Button";
        private const string LoginErrorText_ = "Dialog.Startup.Login.Error";
        private const string OtpTitleText_ = "Dialog.Startup.OTP.Title";
        private const string OtpDescriptionText_ = "Dialog.Startup.OTP.Description";
        private const string DataDescriptionText_ = "Dialog.Startup.Data.Description";
        private const string MissingDataTitleText_ = "Dialog.Startup.MissingData.Title";
        private const string MissingDataDescriptionText_ = "Dialog.Startup.MissingData.Description";
        private const string DownloadDescriptionText_ = "Dialog.Startup.Download.Description";
        private const string DownloadTextsText_ = "Dialog.Startup.Download.Texts";
        private const string DownloadIconsText_ = "Dialog.Startup.Download.Icons";

        private const string VersionMaintenanceTitleText_ = "Dialog.VersionMaintenance.Title";
        private const string VersionMaintenanceWarningText_ = "Dialog.VersionMaintenance.Warning";
        private const string VersionMaintenanceManualWarningText_ = "Dialog.VersionMaintenance.ManualWarning";
        private const string VersionMaintenanceChangeVersionText_ = "Dialog.VersionMaintenance.ChangeVersion";
        private const string VersionMaintenanceChangeVersionTitleText_ = "Dialog.VersionMaintenance.ChangeVersion.Title";
        private const string VersionMaintenanceChangeVersionDescriptionText_ = "Dialog.VersionMaintenance.ChangeVersion.Description";
        private const string VersionMaintenanceChangeVersionPlaceholderText_ = "Dialog.VersionMaintenance.ChangeVersion.Placeholder";
        private const string VersionMaintenanceChangeVersionErrorTitleText_ = "Dialog.VersionMaintenance.ChangeVersion.Error.Title";
        private const string VersionMaintenanceChangeVersionErrorDescriptionText_ = "Dialog.VersionMaintenance.ChangeVersion.Error.Description";
        private const string VersionMaintenanceQuitText_ = "Dialog.VersionMaintenance.Quit";

        private const string AbyssTitleText_ = "Dialog.Abyss.Title";
        private const string LabyrinthTitleText_ = "Dialog.Labyrinth.Title";

        private const string StaminaPreferenceText_ = "Dialog.StaminaPreferenceTitle.Title";

        private const string ButtonDailyText_ = "Button.Daily";
        private const string ButtonClearText_ = "Button.Clear";

        private const string TitleGeneralText_ = "Farming.Title.General";
        private const string TitleRetreatText_ = "Farming.Title.Retreat";
        private const string TitleAllDailyText_ = "Farming.Title.AllDaily";
        private const string TitleAllMapItemsText_ = "Farming.Title.AllMapItems";

        private const string QuestNameText_ = "Farming.Header.QuestName";
        private const string ClearQuestsText_ = "Farming.Header.ClearQuests";
        private const string CollectItemsText_ = "Farming.Header.CollectItems";

        private const string ErrorTitleText_ = "Farming.Error.Title";
        private const string ErrorDescriptionText_ = "Farming.Error.Description";

        private const string StaminaTitleText_ = "Farming.Stamina.Title";
        private const string StaminaDescriptionText_ = "Farming.Stamina.Description";

        private const string RetreatTimerText_ = "Farming.Retreat.Timer";
        private const string RetreatStaminaText_ = "Farming.Retreat.Stamina";
        private const string RetreatDoNotBattleText_ = "Farming.Retreat.DoNotBattle";
        private const string RetreatFinishedTitleText_ = "Farming.Retreat.Finished.Title";
        private const string RetreatFinishedDescription1Text_ = "Farming.Retreat.Finished.Description.1";
        private const string RetreatFinishedDescription2Text_ = "Farming.Retreat.Finished.Description.2";

        private const string LimitTimerText_ = "Farming.LimitTimer";
        private const string RoundCounterText_ = "Farming.RoundCounter";

        private const string DeckRestrictionsText_ = "Farming.DeckRestrictions.Title";
        private const string DeckRestrictionsCharacterText_ = "Farming.DeckRestrictions.Kind.Character";
        private const string DeckRestrictionsCostumeText_ = "Farming.DeckRestrictions.Kind.Costume";
        private const string DeckRestrictionsSlot1Text_ = "Farming.DeckRestrictions.Slot.1";
        private const string DeckRestrictionsSlot2Text_ = "Farming.DeckRestrictions.Slot.2";
        private const string DeckRestrictionsSlot3Text_ = "Farming.DeckRestrictions.Slot.3";

        private const string RewardsColumnNameText_ = "Farming.Rewards.ColumnName";
        private const string RewardsColumnCountText_ = "Farming.Rewards.ColumnCount";

        private const string CostumesColumnNameText_ = "Farming.Costumes.ColumnName";
        private const string CostumesColumnLevelText_ = "Farming.Costumes.ColumnLevel";
        private const string CostumesColumnRankText_ = "Farming.Costumes.ColumnRank";

        private const string DungeonUnavailableTitleText_ = "Farming.Dungeons.Unavailable.Title";
        private const string DungeonUnavailableDescriptionText_ = "Farming.Dungeons.Unavailable.Description";

        private const string ClearAllDailiesText_ = "Farming.ClearAllDailies";
        private const string CollectAllItemsText_ = "Farming.CollectAllItems";

        private const string MapCollectText_ = "Map.Collect";
        private const string MapCollectedText_ = "Map.Collected";
        private const string MapLostItemsText_ = "Map.LostItems";
        private const string MapBlackBirdsText_ = "Map.BlackBirds";
        private const string MapFickleBlackBirdsText_ = "Map.FickleBlackBirds";
        private const string MapHiddenStoriesText_ = "Map.HiddenStories";
        private const string MapLostArchivesText_ = "Map.LostArchives";
        private const string MapStrayScarecrowsText_ = "Map.StrayScarecrows";

        private const string DeckDuskExtraText_ = "Deck.Dusk.Extra";

        private static IDictionary<string, string> _localizations;

        public static string Title => GetLocalization(TitleText_);
        public static string GameVersion => GetLocalization(GameVersionText_);
        public static string Clear => GetLocalization(ClearText_);
        public static string ClearOnce => GetLocalization(ClearOnceText_);
        public static string Cancel => GetLocalization(CancelText_);
        public static string Start => GetLocalization(StartText_);
        public static string Select => GetLocalization(SelectText_);

        public static string Cooldown => GetLocalization(CooldownText_);
        public static string CooldownTitle => GetLocalization(CooldownTitleText_);
        public static string CooldownDescription => GetLocalization(CooldownDescriptionText_);

        public static string CostumesTitle => GetLocalization(CostumesTitleText_);
        public static string WeaponsTitle => GetLocalization(WeaponsTitleText_);
        public static string CompanionsTitle => GetLocalization(CompanionsTitleText_);
        public static string MemoirsTitle => GetLocalization(MemoirsTitleText_);
        public static string DebrisTitle => GetLocalization(DebrisTitleText_);

        public static string DeckCostumeTitle => GetLocalization(DeckCostumeTitleText_);
        public static string DeckWeaponTitle => GetLocalization(DeckWeaponTitleText_);
        public static string DeckCompanionTitle => GetLocalization(DeckCompanionTitleText_);
        public static string DeckMemoirTitle => GetLocalization(DeckMemoirTitleText_);
        public static string DeckDebrisTitle => GetLocalization(DeckDebrisTitleText_);
        public static string DeckDeleteDescription => GetLocalization(DeckDeleteDescriptionText_);
        public static string DeckRenameTitle => GetLocalization(DeckRenameTitleText_);
        public static string DeckRenameDescription => GetLocalization(DeckRenameDescriptionText_);
        public static string DeckRenamePlaceholder => GetLocalization(DeckRenamePlaceholderText_);
        public static string DeckRenameError => GetLocalization(DeckRenameErrorText_);

        public static string ItemChosen => GetLocalization(ItemChosenText_);
        public static string ItemInDeck => GetLocalization(ItemInDeckText_);

        public static string WeaponsNone => GetLocalization(WeaponsNoneText_);

        public static string AuthTitle => GetLocalization(AuthTitleText_);
        public static string AuthDescription => GetLocalization(AuthDescriptionText_);

        public static string StartupTitle => GetLocalization(StartupTitleText_);
        public static string SetupDescription => GetLocalization(SetupDescriptionText_);
        public static string LoginTitle => GetLocalization(LoginTitleText_);
        public static string LoginUsername => GetLocalization(LoginUsernameText_);
        public static string LoginPassword => GetLocalization(LoginPasswordText_);
        public static string LoginButton => GetLocalization(LoginButtonText_);
        public static string LoginError => GetLocalization(LoginErrorText_);
        public static string OtpTitle => GetLocalization(OtpTitleText_);
        public static string OtpDescription => GetLocalization(OtpDescriptionText_);
        public static string DataDescription => GetLocalization(DataDescriptionText_);
        public static string MissingDataTitle => GetLocalization(MissingDataTitleText_);
        public static string MissingDataDescription => GetLocalization(MissingDataDescriptionText_);
        public static string DownloadDescription => GetLocalization(DownloadDescriptionText_);
        public static string DownloadTexts => GetLocalization(DownloadTextsText_);
        public static string DownloadIcons => GetLocalization(DownloadIconsText_);

        public static string VersionMaintenanceTitle => GetLocalization(VersionMaintenanceTitleText_);
        public static string VersionMaintenanceWarning => GetLocalization(VersionMaintenanceWarningText_);
        public static string VersionMaintenanceManualWarning => GetLocalization(VersionMaintenanceManualWarningText_);
        public static string VersionMaintenanceChangeVersion => GetLocalization(VersionMaintenanceChangeVersionText_);
        public static string VersionMaintenanceChangeVersionTitle => GetLocalization(VersionMaintenanceChangeVersionTitleText_);
        public static string VersionMaintenanceChangeVersionDescription => GetLocalization(VersionMaintenanceChangeVersionDescriptionText_);
        public static string VersionMaintenanceChangeVersionPlaceholder => GetLocalization(VersionMaintenanceChangeVersionPlaceholderText_);
        public static string VersionMaintenanceChangeVersionErrorTitle => GetLocalization(VersionMaintenanceChangeVersionErrorTitleText_);
        public static string VersionMaintenanceChangeVersionErrorDescription => GetLocalization(VersionMaintenanceChangeVersionErrorDescriptionText_);
        public static string VersionMaintenanceQuit => GetLocalization(VersionMaintenanceQuitText_);

        public static string AbyssTitle => GetLocalization(AbyssTitleText_);
        public static string LabyrinthTitle => GetLocalization(LabyrinthTitleText_);

        public static string StaminaPreferenceTitle => GetLocalization(StaminaPreferenceText_);

        public static string ButtonDaily => GetLocalization(ButtonDailyText_);
        public static string ButtonClear => GetLocalization(ButtonClearText_);

        public static string TitleFarmingGeneral => GetLocalization(TitleGeneralText_);
        public static string TitleFarmingRetreat => GetLocalization(TitleRetreatText_);
        public static string TitleAllDaily => GetLocalization(TitleAllDailyText_);
        public static string TitleAllMapItems => GetLocalization(TitleAllMapItemsText_);

        public static string QuestName => GetLocalization(QuestNameText_);
        public static string ClearQuestsHeader => GetLocalization(ClearQuestsText_);
        public static string CollectItemsHeader => GetLocalization(CollectItemsText_);

        public static string ErrorTitle => GetLocalization(ErrorTitleText_);
        public static string ErrorDescription => GetLocalization(ErrorDescriptionText_);

        public static string StaminaTitle => GetLocalization(StaminaTitleText_);
        public static string StaminaDescription => GetLocalization(StaminaDescriptionText_);

        public static string RetreatTimer => GetLocalization(RetreatTimerText_);
        public static string RetreatStamina => GetLocalization(RetreatStaminaText_);
        public static string DoNotBattle => GetLocalization(RetreatDoNotBattleText_);
        public static string RetreatFinishedTitle => GetLocalization(RetreatFinishedTitleText_);
        public static string RetreatFinishedDescription1 => GetLocalization(RetreatFinishedDescription1Text_);
        public static string RetreatFinishedDescription2 => GetLocalization(RetreatFinishedDescription2Text_);

        public static string LimitTimer => GetLocalization(LimitTimerText_);
        public static string RoundCounter => GetLocalization(RoundCounterText_);

        public static string DeckRestrictions => GetLocalization(DeckRestrictionsText_);
        public static string DeckRestrictionsCharacter => GetLocalization(DeckRestrictionsCharacterText_);
        public static string DeckRestrictionsCostume => GetLocalization(DeckRestrictionsCostumeText_);
        public static string DeckRestrictionsSlot1=> GetLocalization(DeckRestrictionsSlot1Text_);
        public static string DeckRestrictionsSlot2 => GetLocalization(DeckRestrictionsSlot2Text_);
        public static string DeckRestrictionsSlot3 => GetLocalization(DeckRestrictionsSlot3Text_);

        public static string RewardsColumnName => GetLocalization(RewardsColumnNameText_);
        public static string RewardsColumnCount => GetLocalization(RewardsColumnCountText_);

        public static string CostumesColumnName => GetLocalization(CostumesColumnNameText_);
        public static string CostumesColumnLevel => GetLocalization(CostumesColumnLevelText_);
        public static string CostumesColumnRank => GetLocalization(CostumesColumnRankText_);

        public static string DungeonUnavailableTitle => GetLocalization(DungeonUnavailableTitleText_);
        public static string DungeonUnavailableDescription => GetLocalization(DungeonUnavailableDescriptionText_);

        public static string ClearAllDailies => GetLocalization(ClearAllDailiesText_);
        public static string CollectAllItems => GetLocalization(CollectAllItemsText_);

        public static string MapCollect => GetLocalization(MapCollectText_);
        public static string MapCollected => GetLocalization(MapCollectedText_);
        public static string MapLostItems => GetLocalization(MapLostItemsText_);
        public static string MapBlackBirds => GetLocalization(MapBlackBirdsText_);
        public static string MapFickleBlackBirds => GetLocalization(MapFickleBlackBirdsText_);
        public static string MapHiddenStories => GetLocalization(MapHiddenStoriesText_);
        public static string MapLostArchives => GetLocalization(MapLostArchivesText_);
        public static string MapStrayScarecrows => GetLocalization(MapStrayScarecrowsText_);

        public static string DeckDuskExtra => GetLocalization(DeckDuskExtraText_);

        private static string GetLocalization(string name)
        {
            _localizations ??= InitializeLocalizations();

            return _localizations.ContainsKey(name) ? _localizations[name] : string.Empty;
        }

        private static IDictionary<string, string> InitializeLocalizations()
        {
            switch (Application.Language)
            {
                case Language.English:
                    return FromResource("en");

                default:
                    throw new InvalidOperationException($"Unsupported language {Application.Language}.");
            }
        }

        private static IDictionary<string, string> FromResource(string name)
        {
            var resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(string.Format(ResourceName_, name));
            return resourceStream == null ? null : JsonConvert.DeserializeObject<Dictionary<string, string>>(new StreamReader(resourceStream).ReadToEnd());
        }
    }
}
