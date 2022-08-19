using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Lists;
using nier_rein_gui.Controls.Buttons;
using nier_rein_gui.Dialogs.FarmDialogs;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;

namespace nier_rein_gui.Forms.SubForms
{
    partial class DailyQuestPanel
    {
        private Panel questPanel;

        private void InitializeComponent()
        {
            Content = questPanel = new Panel();
        }

        private void UpdateQuestList()
        {
            var btnList = new List { ItemSpacing = 5 };

            var quests = GetTodayQuests();
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
                btn.Clicked += async (s, e) => await FightAsync(quest.Quest.ChapterId, quests, quest);

                btnList.Items.Add(btn);
            }

            questPanel.Content = btnList;
        }

        private async Task FightAsync(int chapterId, IList<EventQuestData> quests, EventQuestData quest)
        {
            var farmDlg = new TimedQuestFarmDialog(_rein, chapterId, quests, quest, new List<Term> { new Term(CalculatorDateTime.GetTodayChangeDateTime(), CalculatorDateTime.GetNextChangeDateTime()) });
            await farmDlg.ShowAsync();

            UpdateQuestList();
        }
    }
}
