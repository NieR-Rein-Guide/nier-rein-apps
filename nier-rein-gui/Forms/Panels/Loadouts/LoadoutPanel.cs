using System;
using System.Linq;
using ImGui.Forms.Controls;
using ImGui.Forms.Modals;
using ImGui.Forms.Modals.IO;
using nier_rein_gui.Extensions;
using NierReincarnation;
using System.Threading.Tasks;
using nier_rein_gui.Resources;
using nier_rein_gui.Support;
using NierReincarnation.Context.Support;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using NierReincarnation.Core.Dark.View.UserInterface.Text;

namespace nier_rein_gui.Forms.Panels.Loadouts
{
    partial class LoadoutPanel : Panel
    {
        private const int MaxDeckCharacters_ = 10;

        private readonly NierReinContexts _rein;
        private readonly MainForm _mainForm;

        public LoadoutPanel(NierReinContexts rein, MainForm mainForm)
        {
            _rein = rein;
            _mainForm = mainForm;

            InitializeComponent();

            _rein.Decks.SetupReAuthorization(null, Decks_AfterUnauthenticated);

            deckNameButton.Clicked += DeckNameButton_Clicked;
            previousButton.Clicked += PreviousButton_Clicked;
            nextButton.Clicked += NextButton_Clicked;

            deleteButton.Clicked += DeleteButton_Clicked;
            deckTypeBox.SelectedItemChanged += DeckTypeBox_SelectedItemChanged;
        }

        #region Events

        private void DeckTypeBox_SelectedItemChanged(object sender, EventArgs e)
        {
            CurrentDeckType = deckTypeBox.SelectedItem.Content;

            deckNameButton.Enabled = CurrentDeckType != DeckType.RESTRICTED_QUEST &&
                                     CurrentDeckType != DeckType.RESTRICTED_LIMIT_CONTENT_QUEST;

            InitializeDecks(CurrentDeckType);
            UpdateDeck(0);
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            if (await CooldownHelper.IsOnCooldown())
                return;

            var currentDeck = GetCurrentDeck();
            if (currentDeck == null)
                return;

            var result = await MessageBox.ShowYesNoAsync(UserInterfaceTextKey.Deck.kDeleteTitleTextKey.Localize(), string.Format(LocalizationResources.DeckDeleteDescription, currentDeck));
            if (result != DialogResult.Yes)
                return;

            await _rein.Decks.Remove(CurrentDeckNumber, currentDeck.DeckType);

            SetCurrentDeck(CurrentDeckType == DeckType.RESTRICTED_QUEST ?
                CalculatorDeck.CreateDataDeckInfo(CalculatorStateUser.GetUserId(), CurrentDeckNumber, CurrentDeckType) :
                new DataDeckInfo(CurrentDeckType, CurrentDeckNumber));

            UpdateDeck(GetDeckIndex(CurrentDeckNumber, CurrentDeckType));
        }

        private void NextButton_Clicked(object sender, EventArgs e)
        {
            var nextDeckIndex = GetDeckIndex(CurrentDeckNumber, CurrentDeckType) + 1;
            if (nextDeckIndex >= GetMaxDeckCount(CurrentDeckType))
                nextDeckIndex = 0;

            UpdateDeck(nextDeckIndex);
        }

        private void PreviousButton_Clicked(object sender, EventArgs e)
        {
            var previousDeckIndex = GetDeckIndex(CurrentDeckNumber, CurrentDeckType) - 1;
            if (previousDeckIndex < 0)
                previousDeckIndex = GetMaxDeckCount(CurrentDeckType) - 1;

            UpdateDeck(previousDeckIndex);
        }

        private async void DeckNameButton_Clicked(object sender, EventArgs e)
        {
            if (await CooldownHelper.IsOnCooldown())
                return;

            var currentDeck = GetCurrentDeck();
            if (currentDeck?.IsEmpty ?? true)
            {
                await MessageBox.ShowInformationAsync(string.Empty, LocalizationResources.DeckRenameError);
                return;
            }

            var name = await InputBox.ShowAsync(LocalizationResources.DeckRenameTitle, LocalizationResources.DeckRenameDescription, currentDeck.Name, LocalizationResources.DeckRenamePlaceholder, MaxDeckCharacters_);
            if (name == null || name == currentDeck.Name)
                return;

            await RenameDeck(name);

            deckNameLabel.Text = currentDeck.ToString();
        }

        private void Decks_AfterUnauthenticated(bool hasReauthorized)
        {
            if (!hasReauthorized)
                return;

            InitializeDecks(CurrentDeckType);
            UpdateDeck(GetDeckIndex(CurrentDeckNumber, CurrentDeckType));
        }

        #endregion

        #region Deck operations

        private async Task RenameDeck(string name)
        {
            var currentDeck = GetCurrentDeck();
            if (currentDeck == null)
                return;

            await _rein.Decks.Rename(currentDeck.UserDeckNumber, currentDeck.DeckType, name);

            currentDeck.Name = name;
        }

        internal DataDeckActorInfo CreateActor(int pos)
        {
            var currentDeck = GetCurrentDeck();
            if (currentDeck == null)
                return null;

            if (pos < 2)
            {
                var actorPanel = pos == 0 ? actor2 : actor3;
                actorPanel.Reset(true);
            }

            deleteButton.Enabled = true;

            return currentDeck.UserDeckActors[pos] = new DataDeckActorInfo();
        }

        internal DataOutgameCostumeInfo[] GetOtherDeckCostumes(int pos)
        {
            return GetCurrentDeck()?.UserDeckActors.Where((x, i) => i != pos).Select(x => x?.Costume).Where(x => x != null).ToArray() ?? Array.Empty<DataOutgameCostumeInfo>();
        }

        internal DataWeaponInfo[] GetOtherDeckWeapons(int pos)
        {
            return GetCurrentDeck()?.UserDeckActors.Where((x, i) => i != pos).SelectMany(x => new[] { x?.MainWeapon, x?.SubWeapon01, x?.SubWeapon02 }).Where(x => x != null).ToArray() ?? Array.Empty<DataWeaponInfo>();
        }

        internal DataOutgameCompanionInfo[] GetDeckCompanions(int pos)
        {
            return GetCurrentDeck()?.UserDeckActors.Where((x, i) => i != pos).Select(x => x?.Companion).Where(x => x != null).ToArray() ?? Array.Empty<DataOutgameCompanionInfo>();
        }

        internal DataOutgameThoughtInfo[] GetDeckThoughts(int pos)
        {
            return GetCurrentDeck()?.UserDeckActors.Where((x, i) => i != pos).Select(x => x?.Thought).Where(x => x != null).ToArray() ?? Array.Empty<DataOutgameThoughtInfo>();
        }

        internal DataOutgameMemoryInfo[] GetDeckMemoirs(int pos)
        {
            return GetCurrentDeck()?.UserDeckActors.Where((x, i) => i != pos).SelectMany(x => x?.Memories).Where(x => x != null).ToArray() ?? Array.Empty<DataOutgameMemoryInfo>();
        }

        internal void UpdateActor(int pos)
        {
            var currentDeck = GetCurrentDeck();

            deleteButton.Enabled = currentDeck?.DeckType != DeckType.RESTRICTED_QUEST
                ? !currentDeck?.IsEmpty ?? false
                : !currentDeck?.IsMinimal ?? false;
        }

        internal async Task ReplaceDeck()
        {
            var currentDeck = GetCurrentDeck();
            if (currentDeck?.IsEmpty ?? true)
                return;

            await _rein.Decks.Replace(currentDeck);
        }

        #endregion
    }
}
