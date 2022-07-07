using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using System.Timers;
using ImGui.Forms;
using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Modals;
using nier_rein_gui.Controls.Buttons;
using nier_rein_gui.Extensions;
using nier_rein_gui.Forms;
using NierReincarnation;
using NierReincarnation.Context;
using NierReincarnation.Context.Models;
using NierReincarnation.Context.Models.Events;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using Size = ImGui.Forms.Models.Size;

namespace nier_rein_gui.Dialogs
{
    class RetreatFarmDialog : Modal
    {
        private static readonly TimeSpan TimerInterval_ = TimeSpan.FromSeconds(1);
        private const string LimitText_ = "Request limit reached. Waiting {0:m\\:ss}...";

        private const string RetreatCount_ = "Rounds:";
        private const string RetreatTime_ = "Time:";
        private const string RetreatStamina_ = "Stamina used:";

        private readonly QuestBattleContext _questBattleContext;
        private readonly int _chapterId;
        private readonly EventQuestData _quest;

        private bool _isFarming;
        private bool _isCancel;

        private Label limitLabel;
        private ComboBox<DataDeckInfo> decks;
        private CheckBox battleCheck;
        private Label countLabel;
        private Label timeLabel;
        private Label staminaLabel;
        private Button singleButton;
        private Button cancelButton;
        private Button startButton;

        private TimeSpan _currentLimitTime;
        private Timer _timer;

        public RetreatFarmDialog(NierReinContexts rein, int chapterId, EventQuestData quest)
        {
            _questBattleContext = rein.Battles.CreateQuestContext();
            _chapterId = chapterId;
            _quest = quest;

            _timer = new Timer(TimerInterval_.TotalMilliseconds);
            _timer.Elapsed += _timer_Elapsed;

            _questBattleContext.SetupReAuthorization(null, null);

            limitLabel = new Label { Caption = string.Empty, TextColor = Color.Firebrick };

            decks = new ComboBox<DataDeckInfo>();
            InitializeDecks(decks);

            battleCheck = new CheckBox { Caption = "Do not battle", Checked = true };
            countLabel = new Label();
            timeLabel = new Label();
            staminaLabel = new Label();

            singleButton = new NierButton { Caption = "Clear x1", Padding = new Vector2(2, 2) };
            singleButton.Clicked += SingleButton_Clicked;

            cancelButton = new NierButton { Caption = "Cancel", Padding = new Vector2(2, 2), Enabled = false };
            cancelButton.Clicked += CancelButton_Clicked;

            startButton = new NierButton { Caption = "Start", Padding = new Vector2(2, 2) };
            startButton.Clicked += StartButton_Clicked;

            Caption = "Retreat farm";
            Size = new Vector2(300, 150);
            Content = new StackLayout
            {
                Alignment = Alignment.Vertical,
                ItemSpacing = 5,
                Items =
                {
                    new Label {Caption = $"Quest: {quest.QuestName}"},
                    new StackItem(null){Size = new Size(0,0)},
                    new StackLayout
                    {
                        Alignment = Alignment.Horizontal,
                        ItemSpacing = 5,
                        HasBorder = true,
                        Items =
                        {
                            new StackLayout
                            {
                                Alignment = Alignment.Vertical,
                                ItemSpacing = 5,
                                Size = new Size(.2f, 1f),
                                Items =
                                {
                                    new Label {Caption = "Decks:"},
                                    decks
                                }
                            },
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
                                            new Label {Caption = RetreatCount_},
                                            countLabel
                                        }
                                    },
                                    new TableRow
                                    {
                                        Cells =
                                        {
                                            new Label {Caption = RetreatTime_},
                                            timeLabel
                                        }
                                    },
                                    new TableRow
                                    {
                                        Cells =
                                        {
                                            new Label {Caption = RetreatStamina_},
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
                        Size = new Size(1f, -1),
                        Items =
                        {
                            singleButton,
                            new StackLayout
                            {
                                Alignment = Alignment.Horizontal,
                                HorizontalAlignment = HorizontalAlignment.Right,
                                ItemSpacing = 5,
                                Size = new Size(1f, -1),
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
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            limitLabel.Caption = string.Format(LimitText_, _currentLimitTime);
            _currentLimitTime -= TimerInterval_;

            if (_currentLimitTime.TotalMilliseconds == 0)
                _timer.Start();
        }

        private void InitializeDecks(ComboBox<DataDeckInfo> deckBox)
        {
            foreach (var deck in CalculatorDeck.EnumerateDeckInfo(CalculatorStateUser.GetUserId(), DeckType.QUEST))
            {
                deckBox.Items.Add(deck);
            }

            deckBox.SelectedItem = deckBox.Items[0];
        }

        private async void SingleButton_Clicked(object sender, EventArgs e)
        {
            cancelButton.Enabled = false;
            singleButton.Enabled = false;
            startButton.Enabled = false;
            battleCheck.Enabled = false;
            _isFarming = true;

            await SingleFarm(_chapterId, _quest);
            _isFarming = false;

            Close();
        }

        private async void StartButton_Clicked(object sender, EventArgs e)
        {
            cancelButton.Enabled = true;
            singleButton.Enabled = false;
            startButton.Enabled = false;
            battleCheck.Enabled = false;
            _isFarming = true;

            var isSuccessful = await RetreatFarm(_chapterId, _quest);
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

        private async Task SingleFarm(int chapterId, EventQuestData quest)
        {
            var deckNumber = decks.SelectedItem.Content.UserDeckNumber;
            var deck = CalculatorDeck.CreateDataDeck(CalculatorStateUser.GetUserId(), deckNumber, DeckType.QUEST);

            _questBattleContext.RequestRatioReached += RequestRatioReached;

            var battleResult = await _questBattleContext.ExecuteEventQuest(chapterId, quest, deck);

            (Application.Instance.MainForm as MainForm).UpdateUser();
            (Application.Instance.MainForm as MainForm).UpdateStamina();

            if (battleResult.Status == BattleStatus.Win)
            {
                var purpleDrop = battleResult.Rewards.DropRewards.FirstOrDefault(x => x.RewardCategory == RewardCategory.SS_RARE);
                if (purpleDrop != null)
                    await MessageBox.ShowInformationAsync("Finished", $"Farmed '{purpleDrop.PossessionName}'!");
            }

            _questBattleContext.RequestRatioReached -= RequestRatioReached;
        }

        private async Task<bool> RetreatFarm(int chapterId, EventQuestData quest)
        {
            var deckNumber = decks.SelectedItem.Content.UserDeckNumber;
            var deck = CalculatorDeck.CreateDataDeck(CalculatorStateUser.GetUserId(), deckNumber, DeckType.QUEST);

            _questBattleContext.BattleStarted += Battles_BattleStarted;
            _questBattleContext.RequestRatioReached += RequestRatioReached;

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var isCancelled = false;
            var repeats = 0;
            while (!_isCancel)
            {
                (Content as StackLayout).Items[1] = new StackItem(null) { Size = new Size(0, 0) };

                staminaLabel.Caption = $"{repeats * quest.Quest.EntityQuest.Stamina}";
                countLabel.Caption = $"{repeats}";
                timeLabel.Caption = $"{stopwatch.Elapsed}";

                var battleResult = await _questBattleContext.ExecuteEventQuest(chapterId, quest, deck);

                (Application.Instance.MainForm as MainForm).UpdateUser();
                (Application.Instance.MainForm as MainForm).UpdateStamina();

                if (battleResult.Status == BattleStatus.OutOfStamina)
                {
                    await MessageBox.ShowErrorAsync("Out of Stamina", "You're out of stamina!");
                    break;
                }

                if (battleResult.Status == BattleStatus.ForceShutdown)
                {
                    await MessageBox.ShowInformationAsync("Finished", "Purple drop encountered. Go into the game and finish the quest!");
                    break;
                }

                if (battleResult.Status == BattleStatus.Win)
                {
                    var purpleDrop = battleResult.Rewards.DropRewards.FirstOrDefault(x => x.RewardCategory == RewardCategory.SS_RARE);
                    await MessageBox.ShowInformationAsync("Finished", $"Farmed '{purpleDrop.PossessionName}'!");
                    break;
                }

                repeats++;
            }

            if (_isCancel)
                isCancelled = true;

            stopwatch.Stop();

            _questBattleContext.BattleStarted -= Battles_BattleStarted;
            _questBattleContext.RequestRatioReached -= RequestRatioReached;

            staminaLabel.Caption = $"{repeats * quest.Quest.EntityQuest.Stamina}";
            countLabel.Caption = $"{repeats}";
            timeLabel.Caption = $"{stopwatch.Elapsed}";

            return !isCancelled;
        }

        private void Battles_BattleStarted(object sender, StartBattleEventArgs e)
        {
            e.ShouldQuitBattle = !e.RewardCategories.Contains(RewardCategory.SS_RARE);
            e.ForceShutdown = battleCheck.Checked && !e.ShouldQuitBattle;
        }

        private void RequestRatioReached(TimeSpan timeout)
        {
            SetLimitLabel(limitLabel);

            _currentLimitTime = timeout;
            _timer.Start();
        }

        private void SetLimitLabel(Label label)
        {
            if (label == null)
                (Content as StackLayout).Items[1] = new StackItem(null) { Size = new Size(0, 0) };
            else
                (Content as StackLayout).Items[1] = new StackItem(label) { Size = new Size(1f, -1), HorizontalAlignment = HorizontalAlignment.Center };
        }
    }
}
