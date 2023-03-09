using ImGui.Forms.Controls;
using NierReincarnation.App.Forms.Panels.SubQuests;

namespace NierReincarnation.App.Forms.Panels
{
    internal partial class SubQuestPanel : Panel
    {
        private readonly NierReinContexts _rein;
        private readonly MainForm _main;

        public SubQuestPanel(NierReinContexts rein, MainForm main)
        {
            _rein = rein;
            _main = main;

            InitializeComponent();

            mainQuestButton.Clicked += MainQuestButton_Clicked;
            subQuestButton.Clicked += SubQuestButton_Clicked;
            exQuestButton.Clicked += ExQuestButton_Clicked;
            bigHuntButton.Clicked += BigHuntButton_Clicked;
        }

        private void MainQuestButton_Clicked(object sender, System.EventArgs e)
        {
            _main.SetMenuContent(new MainQuestSeasonPanel(_rein));
        }

        private void SubQuestButton_Clicked(object sender, System.EventArgs e)
        {
            _main.SetMenuContent(new EventQuestChapterPanel(_rein));
        }

        private void ExQuestButton_Clicked(object sender, System.EventArgs e)
        {
            _main.SetMenuContent(new ExQuestChapterPanel(_rein));
        }

        private void BigHuntButton_Clicked(object sender, System.EventArgs e)
        {
            _main.SetMenuContent(new BigHuntPanel(_rein));
        }
    }
}
