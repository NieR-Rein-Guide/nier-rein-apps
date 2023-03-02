﻿using ImGui.Forms;
using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Modals;
using NierReincarnation.App.Controls.Buttons;
using NierReincarnation.App.Extensions;
using NierReincarnation.App.Forms;
using NierReincarnation.App.Resources;
using NierReincarnation.App.Support;
using NierReincarnation.Context;
using NierReincarnation.Context.Models;
using NierReincarnation.Context.Models.Events;
using NierReincarnation.Context.Support;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Size = ImGui.Forms.Models.Size;

namespace NierReincarnation.App.Dialogs.FarmDialogs
{
    internal class RetreatFarmDialog : Modal
    {
        private readonly QuestBattleContext _questBattleContext;
        private readonly EventQuestData _quest;

        private bool _isFarming;
        private bool _isCancel;

        private readonly Label limitLabel;
        private readonly ComboBox<DataDeckInfo> decks;
        private readonly CheckBox battleCheck;
        private readonly Label countLabel;
        private readonly Label timeLabel;
        private readonly Label staminaLabel;
        private readonly NierButton singleButton;
        private readonly NierButton cancelButton;
        private readonly NierButton startButton;

        public RetreatFarmDialog(NierReinContexts rein, EventQuestData quest)
        {
            _questBattleContext = rein.Battles.CreateQuestContext();
            _quest = quest;

            _questBattleContext.SetupReAuthorization(null, null);

            limitLabel = new Label
            {
                Text = string.Empty,
                TextColor = Color.Firebrick,
                Visible = false
            };

            decks = new ComboBox<DataDeckInfo>();
            InitializeDecks(decks);

            battleCheck = new CheckBox { Text = LocalizationResources.DoNotBattle, Checked = true };
            countLabel = new Label();
            timeLabel = new Label();
            staminaLabel = new Label();

            singleButton = new NierButton { Text = LocalizationResources.ClearOnce, Padding = new Vector2(2, 2) };
            singleButton.Clicked += SingleButton_Clicked;

            cancelButton = new NierButton { Text = LocalizationResources.Cancel, Padding = new Vector2(2, 2), Enabled = false };
            cancelButton.Clicked += CancelButton_Clicked;

            startButton = new NierButton { Text = LocalizationResources.Start, Padding = new Vector2(2, 2) };
            startButton.Clicked += StartButton_Clicked;

            Caption = LocalizationResources.TitleFarmingRetreat;
            Size = new Vector2(300, 150);
            Content = new StackLayout
            {
                Alignment = Alignment.Vertical,
                ItemSpacing = 5,
                Items =
                {
                    new Label {Text = string.Format(LocalizationResources.QuestName,quest.QuestName)},
                    new StackItem(null){Size = new Size(0,0)},
                    new StackLayout
                    {
                        Alignment = Alignment.Horizontal,
                        ItemSpacing = 5,
                        ShowBorder = true,
                        Items =
                        {
                            new StackItem(decks){Size = new Size(.2f, 1f)},
                            new TableLayout
                            {
                                HorizontalAlignment = HorizontalAlignment.Left,
                                Size = new Size(.8f, 1f),
                                Spacing = new Vector2(3,2),
                                Rows =
                                {
                                    new TableRow
                                    {
                                        Cells =
                                        {
                                            new Label {Text = LocalizationResources.RoundCounter},
                                            countLabel
                                        }
                                    },
                                    new TableRow
                                    {
                                        Cells =
                                        {
                                            new Label {Text = LocalizationResources.RetreatTimer},
                                            timeLabel
                                        }
                                    },
                                    new TableRow
                                    {
                                        Cells =
                                        {
                                            new Label {Text = LocalizationResources.RetreatStamina},
                                            staminaLabel
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new StackItem(battleCheck){HorizontalAlignment = HorizontalAlignment.Right},
                    new StackLayout
                    {
                        Alignment = Alignment.Horizontal,
                        Size = ImGui.Forms.Models.Size.WidthAlign,
                        Items =
                        {
                            singleButton,
                            new StackLayout
                            {
                                Alignment = Alignment.Horizontal,
                                HorizontalAlignment = HorizontalAlignment.Right,
                                ItemSpacing = 5,
                                Size = ImGui.Forms.Models.Size.WidthAlign,
                                Items =
                                {
                                    cancelButton,
                                    startButton
                                }
                            }
                        }
                    }
                }
            };

            if (CooldownTimer.IsRunning)
            {
                SetLimitLabelText(CooldownTimer.CurrentCooldown);
                SetLimitLabel(limitLabel);
            }

            CooldownTimer.CooldownStart += CooldownTimer_CooldownStart;
            CooldownTimer.CooldownFinish += CooldownTimer_CooldownFinish;
            CooldownTimer.Elapsed += CooldownTimer_Elapsed;
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
                (Content as StackLayout).Items[1] = new StackItem(null) { Size = ImGui.Forms.Models.Size.Empty };
            else
                (Content as StackLayout).Items[1] = new StackItem(label) { Size = ImGui.Forms.Models.Size.WidthAlign, HorizontalAlignment = HorizontalAlignment.Center };
        }

        private void SetLimitLabelText(TimeSpan time)
        {
            limitLabel.Text = string.Format(LocalizationResources.LimitTimer, time);
        }

        #endregion Cooldown events

        private static void InitializeDecks(ComboBox<DataDeckInfo> deckBox)
        {
            foreach (var deck in CalculatorDeck.EnumerateDeckInfo(CalculatorStateUser.GetUserId(), DeckType.QUEST))
            {
                deckBox.Items.Add(deck);
            }

            deckBox.SelectedItem = deckBox.Items[0];
        }

        private async void SingleButton_Clicked(object sender, EventArgs e)
        {
            if (await CooldownHelper.IsOnCooldown())
                return;

            cancelButton.Enabled = false;
            singleButton.Enabled = false;
            startButton.Enabled = false;
            battleCheck.Enabled = false;
            _isFarming = true;

            await SingleFarm(_quest);
            _isFarming = false;

            Close();
        }

        private async void StartButton_Clicked(object sender, EventArgs e)
        {
            if (await CooldownHelper.IsOnCooldown())
                return;

            cancelButton.Enabled = true;
            singleButton.Enabled = false;
            startButton.Enabled = false;
            battleCheck.Enabled = false;
            _isFarming = true;

            var isSuccessful = await RetreatFarm(_quest);
            _isFarming = false;

            if (isSuccessful)
            {
                Close();
                return;
            }

            _isCancel = false;
            battleCheck.Enabled = true;
            cancelButton.Enabled = false;
        }

        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            _isCancel = true;
            _isFarming = false;

            cancelButton.Enabled = false;
            startButton.Enabled = true;
            battleCheck.Enabled = true;
            singleButton.Enabled = true;
        }

        protected override bool ShouldCancelClose()
        {
            return _isFarming;
        }

        private async Task SingleFarm(EventQuestData quest)
        {
            var deckNumber = decks.SelectedItem.Content.UserDeckNumber;
            var deck = CalculatorDeck.CreateDataDeck(CalculatorStateUser.GetUserId(), deckNumber, DeckType.QUEST);

            var battleResult = await _questBattleContext.ExecuteEventQuest(quest.Quest.ChapterId, quest, deck);

            (Application.Instance.MainForm as MainForm)?.UpdateUser();
            (Application.Instance.MainForm as MainForm)?.UpdateStamina();

            if (battleResult.Status == BattleStatus.Win)
            {
                var purpleDrop = Array.Find(battleResult.Rewards.DropRewards, x => x.RewardCategory == RewardCategory.SS_RARE);
                if (purpleDrop != null)
                    await MessageBox.ShowInformationAsync(LocalizationResources.RetreatFinishedTitle, string.Format(LocalizationResources.RetreatFinishedDescription1, purpleDrop.PossessionName));
            }
        }

        private async Task<bool> RetreatFarm(EventQuestData quest)
        {
            var deckNumber = decks.SelectedItem.Content.UserDeckNumber;
            var deck = CalculatorDeck.CreateDataDeck(CalculatorStateUser.GetUserId(), deckNumber, DeckType.QUEST);

            _questBattleContext.BattleStarted += Battles_BattleStarted;

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var isCancelled = false;
            var repeats = 0;
            while (!_isCancel)
            {
                (Content as StackLayout).Items[1] = new StackItem(null) { Size = new Size(0, 0) };

                staminaLabel.Text = $"{repeats * quest.Quest.EntityQuest.Stamina}";
                countLabel.Text = $"{repeats}";
                timeLabel.Text = $"{stopwatch.Elapsed}";

                var battleResult = await _questBattleContext.ExecuteEventQuest(quest.Quest.ChapterId, quest, deck);

                (Application.Instance.MainForm as MainForm)?.UpdateUser();
                (Application.Instance.MainForm as MainForm)?.UpdateStamina();

                if (battleResult.Status == BattleStatus.OutOfStamina)
                {
                    await MessageBox.ShowErrorAsync(LocalizationResources.StaminaTitle, LocalizationResources.StaminaDescription);
                    break;
                }

                if (battleResult.Status == BattleStatus.ForceShutdown)
                {
                    await MessageBox.ShowInformationAsync(LocalizationResources.RetreatFinishedTitle, LocalizationResources.RetreatFinishedDescription2);
                    break;
                }

                if (battleResult.Status == BattleStatus.Win)
                {
                    var purpleDrop = Array.Find(battleResult.Rewards.DropRewards, x => x.RewardCategory == RewardCategory.SS_RARE);
                    await MessageBox.ShowInformationAsync(LocalizationResources.RetreatFinishedTitle, string.Format(LocalizationResources.RetreatFinishedDescription1, purpleDrop.PossessionName));
                    break;
                }

                repeats++;
            }

            if (_isCancel)
                isCancelled = true;

            stopwatch.Stop();

            _questBattleContext.BattleStarted -= Battles_BattleStarted;

            staminaLabel.Text = $"{repeats * quest.Quest.EntityQuest.Stamina}";
            countLabel.Text = $"{repeats}";
            timeLabel.Text = $"{stopwatch.Elapsed}";

            return !isCancelled;
        }

        private void Battles_BattleStarted(object sender, StartBattleEventArgs e)
        {
            e.ShouldQuitBattle = !e.RewardCategories.Contains(RewardCategory.SS_RARE);
            e.ForceShutdown = battleCheck.Checked && !e.ShouldQuitBattle;
        }
    }
}