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

        private const string TitleCaption_ = "General.Title";
        private const string GameVersionCaption_ = "General.GameVersion";
        private const string ClearCaption_ = "General.Clear";
        private const string ClearOnceCaption_ = "General.ClearOnce";
        private const string CancelCaption_ = "General.Cancel";
        private const string StartCaption_ = "General.Start";
        private const string SelectCaption_ = "General.Select";

        private const string CooldownCaption_ = "General.Cooldown";
        private const string CooldownTitleCaption_ = "General.Cooldown.Title";
        private const string CooldownDescriptionCaption_ = "General.Cooldown.Description";

        private const string CostumesTitleCaption_ = "Dialog.Title.Costumes";
        private const string WeaponsTitleCaption_ = "Dialog.Title.Weapons";
        private const string CompanionsTitleCaption_ = "Dialog.Title.Companions";
        private const string MemoirsTitleCaption_ = "Dialog.Title.Memoirs";
        private const string DebrisTitleCaption_ = "Dialog.Title.Debris";

        private const string DeckCostumeTitleCaption_ = "Dialog.Deck.Costume";
        private const string DeckWeaponTitleCaption_ = "Dialog.Deck.Weapon";
        private const string DeckCompanionTitleCaption_ = "Dialog.Deck.Companion";
        private const string DeckMemoirTitleCaption_ = "Dialog.Deck.Memoir";
        private const string DeckDebrisTitleCaption_ = "Dialog.Deck.Debris";
        private const string DeckDeleteDescriptionCaption_ = "Dialog.Deck.Delete.Description";
        private const string DeckRenameTitleCaption_ = "Dialog.Deck.Rename.Title";
        private const string DeckRenameDescriptionCaption_ = "Dialog.Deck.Rename.Description";
        private const string DeckRenamePlaceholderCaption_ = "Dialog.Deck.Rename.Placeholder";
        private const string DeckRenameErrorCaption_ = "Dialog.Deck.Rename.Error";

        private const string ItemChosenCaption_ = "Dialog.Item.Chosen";
        private const string ItemInDeckCaption_ = "Dialog.Item.InDeck";

        private const string WeaponsNoneCaption_ = "Dialog.Weapons.None";

        private const string AuthTitleCaption_ = "Dialog.Auth.Title";
        private const string AuthDescriptionCaption_ = "Dialog.Auth.Description";

        private const string StartupTitleCaption_ = "Dialog.Startup.Title";
        private const string SetupDescriptionCaption_ = "Dialog.Startup.Setup.Description";
        private const string LoginTitleCaption_ = "Dialog.Startup.Login.Title";
        private const string LoginUsernameCaption_ = "Dialog.Startup.Login.Username";
        private const string LoginPasswordCaption_ = "Dialog.Startup.Login.Password";
        private const string LoginButtonCaption_ = "Dialog.Startup.Login.Button";
        private const string LoginErrorCaption_ = "Dialog.Startup.Login.Error";
        private const string OtpTitleCaption_ = "Dialog.Startup.OTP.Title";
        private const string OtpDescriptionCaption_ = "Dialog.Startup.OTP.Description";
        private const string DataDescriptionCaption_ = "Dialog.Startup.Data.Description";
        private const string MissingDataTitleCaption_ = "Dialog.Startup.MissingData.Title";
        private const string MissingDataDescriptionCaption_ = "Dialog.Startup.MissingData.Description";
        private const string DownloadDescriptionCaption_ = "Dialog.Startup.Download.Description";
        private const string DownloadTextsCaption_ = "Dialog.Startup.Download.Texts";
        private const string DownloadIconsCaption_ = "Dialog.Startup.Download.Icons";

        private const string VersionMaintenanceTitleCaption_ = "Dialog.VersionMaintenance.Title";
        private const string VersionMaintenanceWarningCaption_ = "Dialog.VersionMaintenance.Warning";
        private const string VersionMaintenanceManualWarningCaption_ = "Dialog.VersionMaintenance.ManualWarning";
        private const string VersionMaintenanceChangeVersionCaption_ = "Dialog.VersionMaintenance.ChangeVersion";
        private const string VersionMaintenanceChangeVersionTitleCaption_ = "Dialog.VersionMaintenance.ChangeVersion.Title";
        private const string VersionMaintenanceChangeVersionDescriptionCaption_ = "Dialog.VersionMaintenance.ChangeVersion.Description";
        private const string VersionMaintenanceChangeVersionPlaceholderCaption_ = "Dialog.VersionMaintenance.ChangeVersion.Placeholder";
        private const string VersionMaintenanceChangeVersionErrorTitleCaption_ = "Dialog.VersionMaintenance.ChangeVersion.Error.Title";
        private const string VersionMaintenanceChangeVersionErrorDescriptionCaption_ = "Dialog.VersionMaintenance.ChangeVersion.Error.Description";
        private const string VersionMaintenanceQuitCaption_ = "Dialog.VersionMaintenance.Quit";

        private const string AbyssTitleCaption_ = "Dialog.Abyss.Title";

        private const string StaminaPreferenceCaption_ = "Dialog.StaminaPreferenceTitle.Title";

        private const string ButtonDailyCaption_ = "Button.Daily";
        private const string ButtonClearCaption_ = "Button.Clear";

        private const string TitleGeneralCaption_ = "Farming.Title.General";
        private const string TitleRetreatCaption_ = "Farming.Title.Retreat";
        private const string TitleAllDailyCaption_ = "Farming.Title.AllDaily";
        private const string TitleAllMapItemsCaption_ = "Farming.Title.AllMapItems";

        private const string QuestNameCaption_ = "Farming.Header.QuestName";
        private const string ClearQuestsCaption_ = "Farming.Header.ClearQuests";
        private const string CollectItemsCaption_ = "Farming.Header.CollectItems";

        private const string ErrorTitleCaption_ = "Farming.Error.Title";
        private const string ErrorDescriptionCaption_ = "Farming.Error.Description";

        private const string StaminaTitleCaption_ = "Farming.Stamina.Title";
        private const string StaminaDescriptionCaption_ = "Farming.Stamina.Description";

        private const string RetreatTimerCaption_ = "Farming.Retreat.Timer";
        private const string RetreatStaminaCaption_ = "Farming.Retreat.Stamina";
        private const string RetreatDoNotBattleCaption_ = "Farming.Retreat.DoNotBattle";
        private const string RetreatFinishedTitleCaption_ = "Farming.Retreat.Finished.Title";
        private const string RetreatFinishedDescription1Caption_ = "Farming.Retreat.Finished.Description.1";
        private const string RetreatFinishedDescription2Caption_ = "Farming.Retreat.Finished.Description.2";

        private const string LimitTimerCaption_ = "Farming.LimitTimer";
        private const string RoundCounterCaption_ = "Farming.RoundCounter";

        private const string DeckRestrictionsCaption_ = "Farming.DeckRestrictions.Title";
        private const string DeckRestrictionsCharacterCaption_ = "Farming.DeckRestrictions.Kind.Character";
        private const string DeckRestrictionsCostumeCaption_ = "Farming.DeckRestrictions.Kind.Costume";
        private const string DeckRestrictionsSlot1Caption_ = "Farming.DeckRestrictions.Slot.1";
        private const string DeckRestrictionsSlot2Caption_ = "Farming.DeckRestrictions.Slot.2";
        private const string DeckRestrictionsSlot3Caption_ = "Farming.DeckRestrictions.Slot.3";

        private const string RewardsColumnNameCaption_ = "Farming.Rewards.ColumnName";
        private const string RewardsColumnCountCaption_ = "Farming.Rewards.ColumnCount";

        private const string CostumesColumnNameCaption_ = "Farming.Costumes.ColumnName";
        private const string CostumesColumnLevelCaption_ = "Farming.Costumes.ColumnLevel";
        private const string CostumesColumnRankCaption_ = "Farming.Costumes.ColumnRank";

        private const string DungeonUnavailableTitleCaption_ = "Farming.Dungeons.Unavailable.Title";
        private const string DungeonUnavailableDescriptionCaption_ = "Farming.Dungeons.Unavailable.Description";

        private const string ClearAllDailiesCaption_ = "Farming.ClearAllDailies";
        private const string CollectAllItemsCaption_ = "Farming.CollectAllItems";

        private const string MapCollectCaption_ = "Map.Collect";
        private const string MapCollectedCaption_ = "Map.Collected";
        private const string MapLostItemsCaption_ = "Map.LostItems";
        private const string MapBlackBirdsCaption_ = "Map.BlackBirds";
        private const string MapFickleBlackBirdsCaption_ = "Map.FickleBlackBirds";
        private const string MapHiddenStoriesCaption_ = "Map.HiddenStories";
        private const string MapLostArchivesCaption_ = "Map.LostArchives";
        private const string MapStrayScarecrowsCaption_ = "Map.StrayScarecrows";

        private const string DeckDuskExtraCaption_ = "Deck.Dusk.Extra";

        private static IDictionary<string, string> _localizations;

        public static string Title => GetLocalization(TitleCaption_);
        public static string GameVersion => GetLocalization(GameVersionCaption_);
        public static string Clear => GetLocalization(ClearCaption_);
        public static string ClearOnce => GetLocalization(ClearOnceCaption_);
        public static string Cancel => GetLocalization(CancelCaption_);
        public static string Start => GetLocalization(StartCaption_);
        public static string Select => GetLocalization(SelectCaption_);

        public static string Cooldown => GetLocalization(CooldownCaption_);
        public static string CooldownTitle => GetLocalization(CooldownTitleCaption_);
        public static string CooldownDescription => GetLocalization(CooldownDescriptionCaption_);

        public static string CostumesTitle => GetLocalization(CostumesTitleCaption_);
        public static string WeaponsTitle => GetLocalization(WeaponsTitleCaption_);
        public static string CompanionsTitle => GetLocalization(CompanionsTitleCaption_);
        public static string MemoirsTitle => GetLocalization(MemoirsTitleCaption_);
        public static string DebrisTitle => GetLocalization(DebrisTitleCaption_);

        public static string DeckCostumeTitle => GetLocalization(DeckCostumeTitleCaption_);
        public static string DeckWeaponTitle => GetLocalization(DeckWeaponTitleCaption_);
        public static string DeckCompanionTitle => GetLocalization(DeckCompanionTitleCaption_);
        public static string DeckMemoirTitle => GetLocalization(DeckMemoirTitleCaption_);
        public static string DeckDebrisTitle => GetLocalization(DeckDebrisTitleCaption_);
        public static string DeckDeleteDescription => GetLocalization(DeckDeleteDescriptionCaption_);
        public static string DeckRenameTitle => GetLocalization(DeckRenameTitleCaption_);
        public static string DeckRenameDescription => GetLocalization(DeckRenameDescriptionCaption_);
        public static string DeckRenamePlaceholder => GetLocalization(DeckRenamePlaceholderCaption_);
        public static string DeckRenameError => GetLocalization(DeckRenameErrorCaption_);

        public static string ItemChosen => GetLocalization(ItemChosenCaption_);
        public static string ItemInDeck => GetLocalization(ItemInDeckCaption_);

        public static string WeaponsNone => GetLocalization(WeaponsNoneCaption_);

        public static string AuthTitle => GetLocalization(AuthTitleCaption_);
        public static string AuthDescription => GetLocalization(AuthDescriptionCaption_);

        public static string StartupTitle => GetLocalization(StartupTitleCaption_);
        public static string SetupDescription => GetLocalization(SetupDescriptionCaption_);
        public static string LoginTitle => GetLocalization(LoginTitleCaption_);
        public static string LoginUsername => GetLocalization(LoginUsernameCaption_);
        public static string LoginPassword => GetLocalization(LoginPasswordCaption_);
        public static string LoginButton => GetLocalization(LoginButtonCaption_);
        public static string LoginError => GetLocalization(LoginErrorCaption_);
        public static string OtpTitle => GetLocalization(OtpTitleCaption_);
        public static string OtpDescription => GetLocalization(OtpDescriptionCaption_);
        public static string DataDescription => GetLocalization(DataDescriptionCaption_);
        public static string MissingDataTitle => GetLocalization(MissingDataTitleCaption_);
        public static string MissingDataDescription => GetLocalization(MissingDataDescriptionCaption_);
        public static string DownloadDescription => GetLocalization(DownloadDescriptionCaption_);
        public static string DownloadTexts => GetLocalization(DownloadTextsCaption_);
        public static string DownloadIcons => GetLocalization(DownloadIconsCaption_);

        public static string VersionMaintenanceTitle => GetLocalization(VersionMaintenanceTitleCaption_);
        public static string VersionMaintenanceWarning => GetLocalization(VersionMaintenanceWarningCaption_);
        public static string VersionMaintenanceManualWarning => GetLocalization(VersionMaintenanceManualWarningCaption_);
        public static string VersionMaintenanceChangeVersion => GetLocalization(VersionMaintenanceChangeVersionCaption_);
        public static string VersionMaintenanceChangeVersionTitle => GetLocalization(VersionMaintenanceChangeVersionTitleCaption_);
        public static string VersionMaintenanceChangeVersionDescription => GetLocalization(VersionMaintenanceChangeVersionDescriptionCaption_);
        public static string VersionMaintenanceChangeVersionPlaceholder => GetLocalization(VersionMaintenanceChangeVersionPlaceholderCaption_);
        public static string VersionMaintenanceChangeVersionErrorTitle => GetLocalization(VersionMaintenanceChangeVersionErrorTitleCaption_);
        public static string VersionMaintenanceChangeVersionErrorDescription => GetLocalization(VersionMaintenanceChangeVersionErrorDescriptionCaption_);
        public static string VersionMaintenanceQuit => GetLocalization(VersionMaintenanceQuitCaption_);

        public static string AbyssTitle => GetLocalization(AbyssTitleCaption_);

        public static string StaminaPreferenceTitle => GetLocalization(StaminaPreferenceCaption_);

        public static string ButtonDaily => GetLocalization(ButtonDailyCaption_);
        public static string ButtonClear => GetLocalization(ButtonClearCaption_);

        public static string TitleFarmingGeneral => GetLocalization(TitleGeneralCaption_);
        public static string TitleFarmingRetreat => GetLocalization(TitleRetreatCaption_);
        public static string TitleAllDaily => GetLocalization(TitleAllDailyCaption_);
        public static string TitleAllMapItems => GetLocalization(TitleAllMapItemsCaption_);

        public static string QuestName => GetLocalization(QuestNameCaption_);
        public static string ClearQuestsHeader => GetLocalization(ClearQuestsCaption_);
        public static string CollectItemsHeader => GetLocalization(CollectItemsCaption_);

        public static string ErrorTitle => GetLocalization(ErrorTitleCaption_);
        public static string ErrorDescription => GetLocalization(ErrorDescriptionCaption_);

        public static string StaminaTitle => GetLocalization(StaminaTitleCaption_);
        public static string StaminaDescription => GetLocalization(StaminaDescriptionCaption_);

        public static string RetreatTimer => GetLocalization(RetreatTimerCaption_);
        public static string RetreatStamina => GetLocalization(RetreatStaminaCaption_);
        public static string DoNotBattle => GetLocalization(RetreatDoNotBattleCaption_);
        public static string RetreatFinishedTitle => GetLocalization(RetreatFinishedTitleCaption_);
        public static string RetreatFinishedDescription1 => GetLocalization(RetreatFinishedDescription1Caption_);
        public static string RetreatFinishedDescription2 => GetLocalization(RetreatFinishedDescription2Caption_);

        public static string LimitTimer => GetLocalization(LimitTimerCaption_);
        public static string RoundCounter => GetLocalization(RoundCounterCaption_);

        public static string DeckRestrictions => GetLocalization(DeckRestrictionsCaption_);
        public static string DeckRestrictionsCharacter => GetLocalization(DeckRestrictionsCharacterCaption_);
        public static string DeckRestrictionsCostume => GetLocalization(DeckRestrictionsCostumeCaption_);
        public static string DeckRestrictionsSlot1=> GetLocalization(DeckRestrictionsSlot1Caption_);
        public static string DeckRestrictionsSlot2 => GetLocalization(DeckRestrictionsSlot2Caption_);
        public static string DeckRestrictionsSlot3 => GetLocalization(DeckRestrictionsSlot3Caption_);

        public static string RewardsColumnName => GetLocalization(RewardsColumnNameCaption_);
        public static string RewardsColumnCount => GetLocalization(RewardsColumnCountCaption_);

        public static string CostumesColumnName => GetLocalization(CostumesColumnNameCaption_);
        public static string CostumesColumnLevel => GetLocalization(CostumesColumnLevelCaption_);
        public static string CostumesColumnRank => GetLocalization(CostumesColumnRankCaption_);

        public static string DungeonUnavailableTitle => GetLocalization(DungeonUnavailableTitleCaption_);
        public static string DungeonUnavailableDescription => GetLocalization(DungeonUnavailableDescriptionCaption_);

        public static string ClearAllDailies => GetLocalization(ClearAllDailiesCaption_);
        public static string CollectAllItems => GetLocalization(CollectAllItemsCaption_);

        public static string MapCollect => GetLocalization(MapCollectCaption_);
        public static string MapCollected => GetLocalization(MapCollectedCaption_);
        public static string MapLostItems => GetLocalization(MapLostItemsCaption_);
        public static string MapBlackBirds => GetLocalization(MapBlackBirdsCaption_);
        public static string MapFickleBlackBirds => GetLocalization(MapFickleBlackBirdsCaption_);
        public static string MapHiddenStories => GetLocalization(MapHiddenStoriesCaption_);
        public static string MapLostArchives => GetLocalization(MapLostArchivesCaption_);
        public static string MapStrayScarecrows => GetLocalization(MapStrayScarecrowsCaption_);

        public static string DeckDuskExtra => GetLocalization(DeckDuskExtraCaption_);

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
