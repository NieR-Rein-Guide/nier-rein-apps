using System;
using System.Linq;
using ImGui.Forms.Controls;
using ImGui.Forms.Modals;
using ImGui.Forms.Modals.IO;
using nier_rein_gui.Extensions;
using NierReincarnation;
using System.Threading.Tasks;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;

namespace nier_rein_gui.Forms.SubForms
{
    partial class LoadoutPanel : Panel
    {
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
        }

        #region Events

        private void NextButton_Clicked(object sender, System.EventArgs e)
        {
            var nextDeckNumber = CurrentDeckNumber + 1;
            if (nextDeckNumber > 10)
                nextDeckNumber = 1;

            UpdateDeck(nextDeckNumber);
        }

        private void PreviousButton_Clicked(object sender, System.EventArgs e)
        {
            var previousDeckNumber = CurrentDeckNumber - 1;
            if (previousDeckNumber <= 0)
                previousDeckNumber = 10;

            UpdateDeck(previousDeckNumber);
        }

        private async void DeckNameButton_Clicked(object sender, System.EventArgs e)
        {
            if (CurrentDeck.IsEmpty)
            {
                await MessageBox.ShowInformationAsync("", "Cannot rename empty loadout.");
                return;
            }

            var name = await InputBox.ShowAsync("Change deck name", "New deck name", CurrentDeck.Name, "Name");
            if (name == null || name == CurrentDeck.Name)
                return;

            await RenameDeck(name);

            deckNameLabel.Caption = CurrentDeck.ToString();
        }

        private void Decks_AfterUnauthenticated(bool hasReauthorized)
        {
            if (!hasReauthorized)
                return;

            InitializeDecks();
            UpdateDeck(CurrentDeckNumber);
        }

        #endregion

        #region Deck operations

        private async Task RenameDeck(string name)
        {
            await _rein.Decks.Rename(CurrentDeck.UserDeckNumber, CurrentDeck.DeckType, name);

            CurrentDeck.Name = name;
        }

        internal DataDeckActorInfo CreateActor(int pos)
        {
            if (pos < 2)
            {
                var actorPanel = pos == 0 ? actor2 : actor3;
                actorPanel.Reset(true);
            }

            return CurrentDeck.UserDeckActors[pos] = new DataDeckActorInfo();
        }

        internal DataOutgameCostumeInfo[] GetOtherDeckCostumes(int pos)
        {
            return CurrentDeck?.UserDeckActors.Where((x, i) => i != pos).Select(x => x?.Costume).Where(x => x != null).ToArray() ?? Array.Empty<DataOutgameCostumeInfo>();
        }

        internal DataWeaponInfo[] GetOtherDeckWeapons(int pos)
        {
            return CurrentDeck?.UserDeckActors.Where((x, i) => i != pos).SelectMany(x => new[] { x?.MainWeapon, x?.SubWeapon01, x?.SubWeapon02 }).Where(x => x != null).ToArray() ?? Array.Empty<DataWeaponInfo>();
        }

        internal DataOutgameCompanionInfo[] GetDeckCompanions(int pos)
        {
            return CurrentDeck?.UserDeckActors.Where((x, i) => i != pos).Select(x => x?.Companion).Where(x => x != null).ToArray() ?? Array.Empty<DataOutgameCompanionInfo>();
        }

        internal DataOutgameThought[] GetDeckThoughts(int pos)
        {
            return CurrentDeck?.UserDeckActors.Where((x, i) => i != pos).Select(x => x?.Thought).Where(x => x != null).ToArray() ?? Array.Empty<DataOutgameThought>();
        }

        internal DataOutgameMemoryInfo[] GetDeckMemoirs(int pos)
        {
            return CurrentDeck?.UserDeckActors.Where((x, i) => i != pos).SelectMany(x => x?.Memories).Where(x => x != null).ToArray() ?? Array.Empty<DataOutgameMemoryInfo>();
        }

        internal async Task ReplaceDeck()
        {
            if (CurrentDeck.IsEmpty)
                return;

            await _rein.Decks.Replace(CurrentDeck);
        }

        #endregion
    }
}
