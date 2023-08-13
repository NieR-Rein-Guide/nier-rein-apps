using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Models;
using NierReincarnation.App.Controls.Buttons;
using NierReincarnation.App.Dialogs.FarmDialogs;
using NierReincarnation.App.Forms.Panels.SubQuests.Quests.Base;
using NierReincarnation.App.Support;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Component.Story;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using NierReincarnation.Core.Dark.View.UserInterface.Text;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NierReincarnation.App.Forms.Panels.SubQuests.Quests
{
    internal class LimitDailyQuestListPanel : QuestListPanel<LimitDailyQuestData>
    {
        private readonly NierReinContexts _rein;

        public LimitDailyQuestListPanel(NierReinContexts rein) : base(GetLimitDailyTitle(), new[] { DifficultyType.NORMAL })
        {
            _rein = rein;

            UpdateQuestList(DifficultyType.NORMAL);
        }

        protected override void InitializeComponent(StackLayout listLayout)
        {
            var receiveBtn = new NierButton
            {
                Text = UserInterfaceTextKey.Quest.kRewardReceive.Localize(),
                Enabled = CanReceiveReward()
            };
            receiveBtn.Clicked += ReceiveBtn_Clicked;

            (listLayout.Items[0].Content as StackLayout)?.Items.Add(new StackItem(receiveBtn) { Size = Size.WidthAlign, HorizontalAlignment = HorizontalAlignment.Right });
        }

        private async void ReceiveBtn_Clicked(object sender, System.EventArgs e)
        {
            if (await CooldownHelper.IsOnCooldown())
                return;

            ((NierButton)sender).Enabled = false;

            await _rein.Quests.ReceiveDailyRewards();

            ((NierButton)sender).Enabled = CanReceiveReward();
        }

        protected override IList<LimitDailyQuestData> GetQuestsByDifficulty(DifficultyType difficulty)
        {
            return GetLimitDailyGroup().Quests;
        }

        protected override IQuest GetBaseQuest(LimitDailyQuestData quest)
        {
            return quest.Quest;
        }

        protected override string GetQuestName(LimitDailyQuestData quest)
        {
            return string.Empty;
        }

        protected override async Task FightAsync(IList<LimitDailyQuestData> quests, LimitDailyQuestData quest)
        {
            var farmDlg = new LimitDailyFarmDialog(_rein, quests, quest);
            await farmDlg.ShowAsync();
        }

        private static bool CanReceiveReward()
        {
            var group = GetLimitDailyGroup();
            return group.IsQuestAllClear && !CalculatorEventQuest.IsLimitDailyGroupRewardReceived();
        }

        private static LimitDailyQuestGroupData GetLimitDailyGroup()
        {
            return CalculatorEventQuest.GenerateEventLimitDailyQuestData();
        }

        private static string GetLimitDailyTitle()
        {
            return UserInterfaceTextKey.Quest.kEventQuestLimitDailyQuest.Localize();
        }
    }
}
