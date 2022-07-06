using System.Linq;
using System.Threading.Tasks;
using ImGui.Forms.Controls;
using ImGui.Forms.Modals.IO;
using NierReincarnation;

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
            SetupReAuthorization();

            deckNameButton.Clicked += DeckNameButton_Clicked;
            previousButton.Clicked += PreviousButton_Clicked;
            nextButton.Clicked += NextButton_Clicked;
        }

        private void NextButton_Clicked(object sender, System.EventArgs e)
        {
            var nextDeckNumber = _currentDeckNumber + 1;
            if (nextDeckNumber > 10)
                nextDeckNumber = 1;

            UpdateDeck(nextDeckNumber, decks.FirstOrDefault(x => x.UserDeckNumber == nextDeckNumber));
        }

        private void PreviousButton_Clicked(object sender, System.EventArgs e)
        {
            var previousDeckNumber = _currentDeckNumber - 1;
            if (previousDeckNumber <= 0)
                previousDeckNumber = 10;

            UpdateDeck(previousDeckNumber, decks.FirstOrDefault(x => x.UserDeckNumber == previousDeckNumber));
        }

        private async void DeckNameButton_Clicked(object sender, System.EventArgs e)
        {
            var name = await InputBox.ShowAsync("Change deck name", "New deck name", _currentDeck.Name, "Name");
            if (name == null || name == _currentDeck.Name)
                return;

            await RenameDeck(name);

            deckNameLabel.Caption = _currentDeck.ToString();
        }

        private async Task RenameDeck(string name)
        {
            if (_currentDeck == null)
                return;

            await _rein.Decks.Rename(_currentDeck, name);

            _currentDeck.Name = name;
        }

        private void SetupReAuthorization()
        {
            // HINT: Make sure the events were removed at least once
            _rein.Decks.BeforeUnauthenticated -= MainForm.BaseContext_BeforeUnauthenticated;
            _rein.Decks.AfterUnauthenticated -= MainForm.BaseContext_AfterUnauthenticated;
            _rein.Decks.AfterUnauthenticated -= Decks_AfterUnauthenticated;

            _rein.Decks.BeforeUnauthenticated += MainForm.BaseContext_BeforeUnauthenticated;
            _rein.Decks.AfterUnauthenticated += MainForm.BaseContext_AfterUnauthenticated;
            _rein.Decks.AfterUnauthenticated += Decks_AfterUnauthenticated;
        }

        private void Decks_AfterUnauthenticated(object sender, bool e)
        {
            InitializeDecks();
            UpdateDeck(_currentDeckNumber, decks.FirstOrDefault(x => x.UserDeckNumber == _currentDeckNumber));
        }
    }
}
