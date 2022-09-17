using ImGui.Forms.Controls;
using nier_rein_gui.Forms.Panels.SubQuests;
using NierReincarnation;

namespace nier_rein_gui.Forms.Panels
{
    partial class SubQuestPanel : Panel
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
            bigHuntButton.Clicked += BigHuntButton_Clicked;
            explorationButton.Clicked += ExplorationButton_Clicked;
        }

        private void MainQuestButton_Clicked(object sender, System.EventArgs e)
        {
            _main.SetMenuContent(new MainQuestSeasonPanel(_rein));
        }

        private void SubQuestButton_Clicked(object sender, System.EventArgs e)
        {
            _main.SetMenuContent(new EventQuestChapterPanel(_rein));
        }

        private void BigHuntButton_Clicked(object sender, System.EventArgs e)
        {
            _main.SetMenuContent(new BigHuntPanel(_rein));
        }

        private void ExplorationButton_Clicked(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
