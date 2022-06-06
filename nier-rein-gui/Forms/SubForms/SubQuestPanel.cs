using ImGui.Forms.Controls;
using NierReincarnation;

namespace nier_rein_gui.Forms.SubForms
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
        }

        private void MainQuestButton_Clicked(object sender, System.EventArgs e)
        {
            _main.SetMenuContent(new MainQuestPanel(_rein));
        }

        private void SubQuestButton_Clicked(object sender, System.EventArgs e)
        {
            _main.SetMenuContent(new EventChapterPanel(_rein));
        }

        private void BigHuntButton_Clicked(object sender, System.EventArgs e)
        {
            _main.SetMenuContent(new BigHuntPanel(_rein));
        }
    }
}
