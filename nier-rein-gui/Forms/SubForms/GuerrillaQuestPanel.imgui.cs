using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Controls.Lists;
using ImGui.Forms.Models;
using nier_rein_gui.Controls.Buttons;
using nier_rein_gui.Dialogs.FarmDialogs;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;

namespace nier_rein_gui.Forms.SubForms
{
    partial class GuerrillaQuestPanel
    {
        private Label timeLabel;
        private NierButton unlockButton;

        private Panel timePanel;
        private Panel questPanel;

        private void InitializeComponent()
        {
            timeLabel = new Label();
            unlockButton = new NierButton();

            timePanel = new Panel
            {
                Content = new StackLayout
                {
                    Alignment = Alignment.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Size = Size.Content,
                    ItemSpacing = 5,
                    Items =
                    {
                        timeLabel,
                        //new StackItem(unlockButton){HorizontalAlignment = HorizontalAlignment.Center}
                    }
                }
            };

            questPanel = new Panel();
        }

        private void UpdateTimeTable(string timeTable)
        {
            timeLabel.Caption = timeTable;
        }

        private void UpdateFreeUnlocks()
        {
            var remainCount = CalculatorGuerrillaQuest.GetFreeOpenRemainCount(CalculatorStateUser.GetUserId());
            var maxCount = CalculatorGuerrillaQuest.GetFreeOpenMaxCount();

            unlockButton.Caption = $"Unlock {remainCount}/{maxCount}";
            if (remainCount <= 0)
                unlockButton.Enabled = false;
        }

        private void UpdateQuestList(List<EventQuestData> quests, List<Term> timeTable)
        {
            var btnList = new List { ItemSpacing = 5 };

            foreach (var quest in quests)
            {
                var campaigns = CalculatorCampaign.CreateDataQuestCampaignAll(quest.Quest);
                var stamCampaign = campaigns.TotalCampaignList.FirstOrDefault(x => (x as DataQuestCampaign).QuestCampaignEffectType == QuestCampaignEffectType.STAMINA_CONSUME_AMOUNT);

                var btn = new NierQuestButton
                {
                    Padding = new Vector2(2, 2),
                    Width = 1f,
                    Caption = quest.QuestName,
                    Stamina = quest.Quest.EntityQuest.Stamina,
                    SuggestedPower = quest.RecommendPower,
                    IsClear = quest.IsClearQuest,
                    Enabled = !quest.IsLock,
                    IsDaily = quest.Quest.EntityQuest.DailyClearableCount > 0,
                    StaminaCampaign = stamCampaign as DataQuestCampaign,
                    Attribute = quest.AttributeType
                };
                btn.Clicked += async (s, e) => await FightAsync(quest.Quest.ChapterId, quests, quest, timeTable);

                btnList.Items.Add(btn);
            }

            questPanel.Content = btnList;
        }

        private async Task FightAsync(int chapterId, IList<EventQuestData> quests, EventQuestData quest, List<Term> timeTable)
        {
            var farmDlg = new TimedQuestFarmDialog(_rein, chapterId, quests, quest, timeTable);
            await farmDlg.ShowAsync();

            UpdateContent();
        }
    }
}
