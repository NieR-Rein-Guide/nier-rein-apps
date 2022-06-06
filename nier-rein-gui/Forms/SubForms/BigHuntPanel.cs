using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Base;
using nier_rein_gui.Controls;
using NierReincarnation;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using System.Collections.Generic;
using nier_rein_gui.Dialogs;

namespace nier_rein_gui.Forms.SubForms
{
    partial class BigHuntPanel : Panel
    {
        private readonly NierReinContexts _rein;

        private List<BigHuntBossQuestData> _bossQuests;

        private BigHuntBossQuestData _currentBossQuest;

        public BigHuntPanel(NierReinContexts rein)
        {
            _rein = rein;

            InitializeComponent();

            UpdateBossQuests();
            UpdateQuest(0);

            _currentBossQuest = _bossQuests[0];
            (bossList.Items[0] as NierButton).Active = true;
        }

        private void UpdateBossQuests()
        {
            SetBossQuestList();

            foreach (var btn in bossList.Items)
                (btn as NierButton).Clicked += BossQuestButton_Clicked;
        }

        private void UpdateQuest(int bossIndex)
        {
            SetQuestList(bossIndex);

            foreach (var btn in questList.Items)
                (btn as NierButton).Clicked += QuestButton_Clicked;
        }

        private void BossQuestButton_Clicked(object sender, System.EventArgs e)
        {
            foreach (var btn in bossList.Items)
                (btn as NierButton).Active = btn == sender;

            var index = bossList.Items.IndexOf((Component)sender);
            _currentBossQuest = _bossQuests[index];

            UpdateQuest(index);
        }

        private async void QuestButton_Clicked(object sender, System.EventArgs e)
        {
            var questIndex = questList.Items.IndexOf((Component)sender);
            var quest = _currentBossQuest.BigHuntQuestDataList[questIndex];

            var dlg = new BigHuntDialog(_rein,quest);
            await dlg.ShowAsync();
        }

        private List<BigHuntBossQuestData> GetBossQuests()
        {
            return _bossQuests = CalculatorBigHuntQuest.GenerateBigHuntBossQuestDataList(CalculatorStateUser.GetUserId());
        }

        private List<BigHuntQuestData> GetQuests(int bossIndex)
        {
            return _bossQuests[bossIndex].BigHuntQuestDataList;
        }
    }
}
