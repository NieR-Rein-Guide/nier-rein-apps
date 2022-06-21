using System.Linq;
using ImGui.Forms.Controls;
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
    }
}
