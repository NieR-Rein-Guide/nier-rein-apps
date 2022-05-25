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
using nier_rein_gui.Controls;
using nier_rein_gui.Forms;
using NierReincarnation;
using NierReincarnation.Context;
using NierReincarnation.Context.Models;
using NierReincarnation.Context.Models.Events;
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

        private readonly NierReinContexts _rein;
        private readonly int _chapterId;
        private readonly EventQuestData _quest;

        private bool _isFarming;
        private bool _isCancel;

        private Label limitLabel;
        private ComboBox<DeckInfo> decks;
        private CheckBox battleCheck;
        private Label countLabel;
        private Label timeLabel;
        private Label staminaLabel;
        private Button cancelButton;
        private Button startButton;

        private TimeSpan _currentLimitTime;
        private Timer _timer;

        public RetreatFarmDialog(NierReinContexts rein, int chapterId, EventQuestData quest)
        {
            _rein = rein;
            _chapterId = chapterId;
            _quest = quest;

            _timer = new Timer(TimerInterval_.TotalMilliseconds);
            _timer.Elapsed += _timer_Elapsed;

            limitLabel = new Label { Caption = string.Empty, TextColor = Color.Firebrick };

            decks = new ComboBox<DeckInfo>();
            InitializeComboBox(decks);

            battleCheck = new CheckBox { Caption = "Do not battle", Checked = true };
            countLabel = new Label();
            timeLabel = new Label();
            staminaLabel = new Label();

            cancelButton = new NierButton { Caption = "Cancel", Padding = new Vector2(2,2), Enabled = false };
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
            };
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            limitLabel.Caption = string.Format(LimitText_, _currentLimitTime);
            _currentLimitTime -= TimerInterval_;

            if (_currentLimitTime.TotalMilliseconds == 0)
                _timer.Start();
        }

        private void InitializeComboBox(ComboBox<DeckInfo> deckBox)
        {
            foreach (var deck in _rein.Decks.GetQuestDeckInfo())
            {
                deckBox.Items.Add(new ComboBoxItem<DeckInfo>(new DeckInfo
                {
                    DeckId = deck.UserDeckNumber,
                    DeckName = deck.Name
                }));
            }

            deckBox.SelectedItem = deckBox.Items[0];
        }

        private async void StartButton_Clicked(object sender, EventArgs e)
        {
            cancelButton.Enabled = true;
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
        }

        protected override bool ShouldCancelClose()
        {
            return _isFarming;
        }

        private async Task<bool> RetreatFarm(int chapterId, EventQuestData quest)
        {
            _rein.Battles.RequestRatioReached += (s, e) => {
                (Content as StackLayout).Items[1] = new StackItem(limitLabel) { Size = new Size(1f, -1), HorizontalAlignment = HorizontalAlignment.Center };

                _currentLimitTime = BattleContext.RateTimeout;
                _timer.Start();
            };

            var deckNumber = decks.SelectedItem.Content.DeckId;
            var deck = _rein.Decks.GetQuestDeck(deckNumber, DeckType.QUEST);

            _rein.Battles.BattleStarted += Battles_BattleStarted;

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var isCancelled = false;
            var repeats = 0;
            while (!_isCancel)
            {
                (Content as StackLayout).Items[1] = new StackItem(null) {Size = new Size(0, 0)};

                staminaLabel.Caption = $"{repeats * quest.Quest.EntityQuest.Stamina}";
                countLabel.Caption = $"{repeats}";
                timeLabel.Caption = $"{stopwatch.Elapsed}";

                var battleResult = await _rein.Battles.ExecuteEventQuest(chapterId, quest, deck);
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

        class DeckInfo
        {
            public int DeckId { get; set; }
            public DeckType DeckType { get; set; }
            public string DeckName { get; set; }

            public override string ToString()
            {
                return DeckName ?? $"Quest {DeckId}";
            }
        }
    }
}
