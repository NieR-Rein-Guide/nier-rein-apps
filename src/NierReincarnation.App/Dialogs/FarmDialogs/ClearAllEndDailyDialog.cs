using ImGui.Forms;
using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Controls.Lists;
using ImGui.Forms.Modals;
using NierReincarnation.App.Controls.Buttons;
using NierReincarnation.App.Forms;
using NierReincarnation.App.Resources;
using NierReincarnation.App.Support;
using NierReincarnation.Context.Models;
using NierReincarnation.Context.Support;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using DataDeckInfo = NierReincarnation.Core.Dark.DataDeckInfo;

namespace NierReincarnation.App.Dialogs.FarmDialogs
{
    internal class ClearAllEndDailyDialog : Modal
    {
        private readonly NierReinContexts _rein;
        private readonly IList<EventQuestData> _quests;
        private readonly IDictionary<(PossessionType, int), (string, int)> _rewardsDict = new Dictionary<(PossessionType, int), (string, int)>();

        private bool _isRunning;

        private readonly ComboBox<DataDeckInfo> deckBox;
        private readonly Label countLabel;
        private readonly Label limitLabel;
        private readonly NierButton cancelBtn;
        private readonly NierButton startBtn;
        private readonly DataTable<(string, int)> rewards;

        public ClearAllEndDailyDialog(NierReinContexts rein)
        {
            _rein = rein;
            _quests = GetDailyQuests().ToArray();

            deckBox = new ComboBox<DataDeckInfo>();
            countLabel = new Label();
            limitLabel = new Label { TextColor = Color.Firebrick };
            startBtn = new NierButton { Text = LocalizationResources.Start };
            cancelBtn = new NierButton { Text = LocalizationResources.Cancel, Enabled = false };

            rewards = new DataTable<(string, int)>
            {
                IsSelectable = false,
                IsResizable = true,
                Columns =
                {
                    new DataTableColumn<(string, int)>(reward => reward.Item1, LocalizationResources.RewardsColumnName),
                    new DataTableColumn<(string, int)>(reward => $"{reward.Item2}", LocalizationResources.RewardsColumnCount)
                }
            };

            Caption = LocalizationResources.TitleAllDaily;
            Size = new Vector2(270, 200);
            Content = new StackLayout
            {
                Alignment = Alignment.Vertical,
                ItemSpacing = 5,
                Items =
                {
                    null,
                    null,
                    new StackLayout
                    {
                        Alignment = Alignment.Horizontal,
                        ItemSpacing = 5,
                        Size = ImGui.Forms.Models.Size.Content,
                        Items =
                        {
                            new StackItem(deckBox){VerticalAlignment = VerticalAlignment.Center},
                            new StackItem(cancelBtn){Size = ImGui.Forms.Models.Size.WidthAlign,HorizontalAlignment = HorizontalAlignment.Right},
                            new StackItem(startBtn){HorizontalAlignment = HorizontalAlignment.Right}
                        }
                    },
                    rewards
                }
            };

            InitializeDecks();

            startBtn.Clicked += StartBtn_Clicked;
            cancelBtn.Clicked += CancelBtn_Clicked;

            if (CooldownTimer.IsRunning)
            {
                SetLimitLabelText(CooldownTimer.CurrentCooldown);
                SetLimitLabel(limitLabel);
            }

            CooldownTimer.CooldownStart += CooldownTimer_CooldownStart;
            CooldownTimer.CooldownFinish += CooldownTimer_CooldownFinish;
            CooldownTimer.Elapsed += CooldownTimer_Elapsed;
        }

        public static bool HasDailyQuests()
        {
            return GetDailyQuests().Any();
        }

        protected override Task CloseInternal()
        {
            CooldownTimer.CooldownStart -= CooldownTimer_CooldownStart;
            CooldownTimer.CooldownFinish -= CooldownTimer_CooldownFinish;
            CooldownTimer.Elapsed -= CooldownTimer_Elapsed;

            return Task.CompletedTask;
        }

        #region Cooldown events

        private void CooldownTimer_Elapsed(object sender, TimeSpan e)
        {
            SetLimitLabelText(e);
        }

        private void CooldownTimer_CooldownFinish(object sender, EventArgs e)
        {
            SetLimitLabelText(TimeSpan.Zero);
            SetLimitLabel(null);
        }

        private void CooldownTimer_CooldownStart(object sender, TimeSpan e)
        {
            SetLimitLabelText(e);
            SetLimitLabel(limitLabel);
        }

        private void SetLimitLabel(Label label)
        {
            if (label == null)
                (Content as StackLayout).Items[0] = new StackItem(null) { Size = ImGui.Forms.Models.Size.Empty };
            else
                (Content as StackLayout).Items[0] = new StackItem(label) { Size = ImGui.Forms.Models.Size.WidthAlign, HorizontalAlignment = HorizontalAlignment.Center };
        }

        private void SetLimitLabelText(TimeSpan time)
        {
            limitLabel.Text = string.Format(LocalizationResources.LimitTimer, time);
        }

        #endregion Cooldown events

        protected override bool ShouldCancelClose()
        {
            return _isRunning;
        }

        private static IEnumerable<EventQuestData> GetDailyQuests()
        {
            foreach (var character in CalculatorQuest.GetEndQuestChapters())
            {
                var quests = CalculatorQuest.GenerateEventQuestData(character.EventQuestChapterId, DifficultyType.NORMAL);

                var dailies = quests.Where(x => x.Quest.EntityQuest.DailyClearableCount > 0 && !CalculatorQuest.IsQuestLocked(x.Quest.QuestId));
                foreach (var daily in dailies)
                    yield return daily;
            }
        }

        private void InitializeDecks()
        {
            foreach (var deck in CalculatorDeck.EnumerateDeckInfo(CalculatorStateUser.GetUserId(), DeckType.QUEST))
                deckBox.Items.Add(deck);

            if (deckBox.Items.Count >= 1)
                deckBox.SelectedItem = deckBox.Items[0];
        }

        private async void StartBtn_Clicked(object sender, System.EventArgs e)
        {
            if (await CooldownHelper.IsOnCooldown())
                return;

            startBtn.Enabled = false;
            cancelBtn.Enabled = true;
            _isRunning = true;

            SetCountLabel(countLabel);

            var questContext = _rein.Battles.CreateQuestContext();
            var deck = CalculatorDeck.CreateDataDeck(CalculatorStateUser.GetUserId(), deckBox.SelectedItem.Content.UserDeckNumber, DeckType.QUEST);

            SetCountLabelText(0);

            var didAll = _quests.Count == 0;
            for (var i = 0; i < _quests.Count; i++)
            {
                if (!_isRunning)
                    break;

                SetCountLabelText(i);
                var result = await questContext.ExecuteEventQuest(_quests[i].Quest.ChapterId, _quests[i], deck);

                (Application.Instance.MainForm as MainForm).UpdateUser();
                (Application.Instance.MainForm as MainForm).UpdateStamina();

                AddRewards(result.Rewards);

                didAll = i + 1 == _quests.Count;
            }

            if (didAll)
                SetCountLabelText(_quests.Count);

            startBtn.Enabled = !didAll;
            cancelBtn.Enabled = false;
            _isRunning = false;

            if (didAll)
                Result = DialogResult.Ok;
        }

        private void CancelBtn_Clicked(object sender, System.EventArgs e)
        {
            _isRunning = false;
        }

        private void AddRewards(BattleDrops drops)
        {
            foreach (var drop in drops.EnumerateAll())
            {
                if (!_rewardsDict.TryGetValue((drop.PossessionType, drop.PossessionId), out var element))
                    element = (string.Empty, 0);

                _rewardsDict[(drop.PossessionType, drop.PossessionId)] = (drop.PossessionName, element.Item2 + drop.Count);
            }

            rewards.Rows.Clear();
            foreach (var drop in _rewardsDict)
                rewards.Rows.Add(new DataTableRow<(string, int)>((drop.Value.Item1, drop.Value.Item2)));
        }

        private void SetCountLabel(Label label)
        {
            if (label == null)
                (Content as StackLayout).Items[1] = new StackItem(null) { Size = ImGui.Forms.Models.Size.Empty };
            else
                (Content as StackLayout).Items[1] = new StackItem(label) { Size = ImGui.Forms.Models.Size.WidthAlign, HorizontalAlignment = HorizontalAlignment.Center };
        }

        private void SetCountLabelText(int count)
        {
            countLabel.Text = string.Format(LocalizationResources.ClearQuestsHeader, count, _quests.Count);
        }
    }
}
