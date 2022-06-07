using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Threading.Tasks;
using System.Timers;
using ImGui.Forms;
using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Controls.Lists;
using ImGui.Forms.Modals;
using ImGui.Forms.Models;
using ImGuiNET;
using nier_rein_gui.Controls;
using nier_rein_gui.Forms;
using NierReincarnation;
using NierReincarnation.Context;
using NierReincarnation.Context.Models;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;

namespace nier_rein_gui.Dialogs
{
    abstract class QuestFarmDialog : Modal
    {
        private static readonly TimeSpan TimerInterval_ = TimeSpan.FromSeconds(1);
        private const string LimitText_ = "Request limit reached. Waiting {0:m\\:ss}...";

        private readonly IDictionary<int, int> _rewardCache;
        private readonly IDictionary<int, Costume> _costumeCache;

        private int _questId;
        private bool _isRental;
        private bool _isFarming;
        private bool _isCancel;

        private ArrowButton previousButton;
        private ArrowButton nextButton;
        private Label captionLabel;
        private Label limitLabel;
        private ComboBox<DeckInfo> decks;
        private DataTable<Reward> rewards;
        private DataTable<Costume> costumes;
        private Button singleButton;
        private Button cancelButton;
        private Button startButton;

        private TimeSpan _currentLimitTime;
        private Timer _timer;

        protected QuestBattleContext BattleContext { get; }

        protected QuestFarmDialog(NierReinContexts rein, int questId, string questName)
        {
            BattleContext = rein.Battles.CreateQuestContext();

            _rewardCache = new Dictionary<int, int>();
            _costumeCache = new Dictionary<int, Costume>();

            _timer = new Timer(TimerInterval_.TotalMilliseconds);
            _timer.Elapsed += _timer_Elapsed;

            previousButton = new ArrowButton { Direction = ImGuiDir.Left };
            previousButton.Clicked += PreviousButton_Clicked;

            nextButton = new ArrowButton { Direction = ImGuiDir.Right };
            nextButton.Clicked += NextButton_Clicked;

            captionLabel = new Label();
            limitLabel = new Label { Caption = string.Empty, TextColor = Color.Firebrick };

            decks = new ComboBox<DeckInfo>();

            rewards = new DataTable<Reward>
            {
                IsSelectable = false,
                IsResizable = true,
                Columns =
                {
                    new DataTableColumn<Reward>(reward => reward.Name,nameof(Reward.Name)),
                    new DataTableColumn<Reward>(reward => $"{reward.Count}",nameof(Reward.Count))
                },
                Rows = new List<DataTableRow<Reward>>()
            };

            costumes = new DataTable<Costume>
            {
                IsSelectable = false,
                IsResizable = true,
                Size = new ImGui.Forms.Models.Size(1f, 75),
                Columns =
                {
                    new DataTableColumn<Costume>(costume => costume.Name, nameof(Costume.Name)),
                    new DataTableColumn<Costume>(costume => $"{costume.Level}", nameof(Costume.Level)),
                    new DataTableColumn<Costume>(costume => $"{costume.Rank}", nameof(Costume.Rank))
                },
                Rows = new List<DataTableRow<Costume>>()
            };

            singleButton = new NierButton { Caption = "Clear x1", Padding = new Vector2(2, 2) };
            singleButton.Clicked += SingleButton_Clicked;

            cancelButton = new NierButton { Caption = "Cancel", Padding = new Vector2(2, 2), Enabled = false };
            cancelButton.Clicked += CancelButton_Clicked;

            startButton = new NierButton { Caption = "Start", Padding = new Vector2(2, 2) };
            startButton.Clicked += StartButton_Clicked;

            Caption = "Farming";
            Size = new Vector2(270, 300);
            Content = new StackLayout
            {
                Alignment = Alignment.Vertical,
                ItemSpacing = 5,
                Items =
                {
                    new StackLayout
                    {
                        Alignment = Alignment.Horizontal,
                        Size = new ImGui.Forms.Models.Size(1f,-1),
                        ItemSpacing = 5,
                        Items =
                        {
                            previousButton,
                            new StackItem(captionLabel){Size = new ImGui.Forms.Models.Size(1f,-1)},
                            nextButton
                        }
                    },
                    new StackItem(null){Size = new ImGui.Forms.Models.Size(0,0)},
                    new StackItem(null),
                    rewards,
                    costumes,
                    new StackLayout
                    {
                        Alignment = Alignment.Horizontal,
                        Size = new ImGui.Forms.Models.Size(1f, -1),
                        Items =
                        {
                            singleButton,
                            new StackLayout
                            {
                                Alignment = Alignment.Horizontal,
                                HorizontalAlignment = HorizontalAlignment.Right,
                                ItemSpacing = 5,
                                Size = new ImGui.Forms.Models.Size(1f, -1),
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

            UpdateQuest(questId, questName);
        }

        protected abstract int NextQuest(out string questName);

        protected abstract int PreviousQuest(out string questName);

        protected abstract Task<BattleResult> ExecuteQuest(DataDeck deck);

        private void UpdateRentalDeck(int questId)
        {
            _isRental = CalculatorDeck.IsRentalDeck(questId);
            if (_isRental)
            {
                UpdateDeckContent(null);
                return;
            }

            InitializeComboBox(decks);
            UpdateDeckContent(decks);
        }

        private void NextButton_Clicked(object sender, EventArgs e)
        {
            NextQuestInternal();
        }

        private void PreviousButton_Clicked(object sender, EventArgs e)
        {
            PreviousQuestInternal();
        }

        private void NextQuestInternal()
        {
            var nextQuestId = NextQuest(out var nextName);
            UpdateQuest(nextQuestId, nextName);
        }

        private void PreviousQuestInternal()
        {
            var previousQuestId = PreviousQuest(out var previousName);
            UpdateQuest(previousQuestId, previousName);
        }

        private void UpdateQuest(int questId, string questName)
        {
            _questId = questId;
            captionLabel.Caption = $"Quest: {questName}";

            UpdateRentalDeck(questId);

            rewards.Rows.Clear();
            costumes.Rows.Clear();
        }

        private void UpdateDeckContent(ComboBox<DeckInfo> content)
        {
            (Content as StackLayout).Items[2] = new StackItem(content) { Size = ImGui.Forms.Models.Size.Content };
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            limitLabel.Caption = string.Format(LimitText_, _currentLimitTime);
            _currentLimitTime -= TimerInterval_;

            if (_currentLimitTime.TotalMilliseconds == 0)
                _timer.Start();
        }

        private async void SingleButton_Clicked(object sender, EventArgs e)
        {
            previousButton.Enabled = false;
            nextButton.Enabled = false;
            cancelButton.Enabled = false;
            singleButton.Enabled = false;
            startButton.Enabled = false;
            _isFarming = true;

            _costumeCache.Clear();
            _rewardCache.Clear();
            costumes.Rows.Clear();
            rewards.Rows.Clear();

            // Prepare deck
            var deck = _isRental ?
                CalculatorDeck.CreateRentalDeck(_questId) :
                CalculatorDeck.CreateDataDeck(CalculatorStateUser.GetUserId(), decks.SelectedItem.Content.DeckId, DeckType.QUEST);

            // Prepare costume table
            foreach (var actor in deck.UserDeckActors)
                if (actor != null)
                    _costumeCache[actor.Costume.CostumeId] = new Costume
                    {
                        CostumeId = actor.Costume.CostumeId,
                        Uuid = actor.Costume.UserCostumeUuid,
                        Name = actor.Costume.CharacterName,
                        Level = actor.Costume.CostumeStatus.Level,
                        Rank = CalculatorCharacterRank.GetCharacterRank(actor.Costume.CharacterId)
                    };

            foreach (var costume in _costumeCache)
                costumes.Rows.Add(new DataTableRow<Costume>(costume.Value));

            BattleContext.BattleFinished += Battles_BattleFinished;

            BattleContext.RequestRatioReached += (s, e) =>
            {
                (Content as StackLayout).Items[1] = new StackItem(limitLabel) { Size = new ImGui.Forms.Models.Size(1f, -1), HorizontalAlignment = HorizontalAlignment.Center };

                _currentLimitTime = QuestBattleContext.RateTimeout;
                _timer.Start();
            };

            await ExecuteQuest(deck);

            (Application.Instance.MainForm as MainForm).UpdateUser();
            (Application.Instance.MainForm as MainForm).UpdateStamina();

            _isFarming = false;
            cancelButton.Enabled = false;
            singleButton.Enabled = true;
            startButton.Enabled = true;
            previousButton.Enabled = true;
            nextButton.Enabled = true;
        }

        private void InitializeComboBox(ComboBox<DeckInfo> deckBox)
        {
            foreach (var deck in CalculatorDeck.EnumerateDeckInfo(CalculatorStateUser.GetUserId(), DeckType.QUEST))
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
            previousButton.Enabled = false;
            nextButton.Enabled = false;
            cancelButton.Enabled = true;
            singleButton.Enabled = false;
            startButton.Enabled = false;
            _isFarming = true;

            _costumeCache.Clear();
            _rewardCache.Clear();
            costumes.Rows.Clear();
            rewards.Rows.Clear();

            var isSuccessful = await Farm();
            _isFarming = false;

            if (isSuccessful)
            {
                Close();
                return;
            }

            _isCancel = false;
            cancelButton.Enabled = false;
            previousButton.Enabled = true;
            nextButton.Enabled = true;
        }

        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            _isCancel = true;
            _isFarming = false;

            cancelButton.Enabled = false;
            singleButton.Enabled = true;
            startButton.Enabled = true;
            previousButton.Enabled = true;
            nextButton.Enabled = true;
        }

        protected override bool ShouldCancelClose()
        {
            return _isFarming;
        }

        private async Task<bool> Farm()
        {
            // Prepare battle events
            BattleContext.RequestRatioReached += (s, e) =>
            {
                (Content as StackLayout).Items[1] = new StackItem(limitLabel) { Size = new ImGui.Forms.Models.Size(1f, -1), HorizontalAlignment = HorizontalAlignment.Center };

                _currentLimitTime = QuestBattleContext.RateTimeout;
                _timer.Start();
            };

            BattleContext.BattleFinished += Battles_BattleFinished;

            // Prepare deck
            var deck = _isRental ?
                CalculatorDeck.CreateRentalDeck(_questId) :
                CalculatorDeck.CreateDataDeck(CalculatorStateUser.GetUserId(), decks.SelectedItem.Content.DeckId, DeckType.QUEST);

            // Prepare costume table
            foreach (var actor in deck.UserDeckActors)
                if (actor != null)
                    _costumeCache[actor.Costume.CostumeId] = new Costume
                    {
                        CostumeId = actor.Costume.CostumeId,
                        Uuid = actor.Costume.UserCostumeUuid,
                        Name = actor.Costume.CharacterName,
                        Level = actor.Costume.CostumeStatus.Level,
                        Rank = CalculatorCharacterRank.GetCharacterRank(actor.Costume.CharacterId)
                    };

            foreach (var costume in _costumeCache)
                costumes.Rows.Add(new DataTableRow<Costume>(costume.Value));

            // Execute farming
            var isCancelled = false;
            while (!_isCancel)
            {
                (Content as StackLayout).Items[1] = new StackItem(null) { Size = new ImGui.Forms.Models.Size(0, 0) };

                var battleResult = await ExecuteQuest(deck);

                (Application.Instance.MainForm as MainForm).UpdateUser();
                (Application.Instance.MainForm as MainForm).UpdateStamina();

                if (battleResult.Status == BattleStatus.OutOfStamina)
                {
                    await MessageBox.ShowErrorAsync("Out of Stamina", "You're out of stamina!");
                    break;
                }

                // TODO: Create ending conditions based on rewards
            }

            if (_isCancel)
                isCancelled = true;

            return !isCancelled;
        }

        private void Battles_BattleFinished(object sender, NierReincarnation.Context.Models.Events.FinishBattleEventArgs e)
        {
            foreach (var dropReward in e.Rewards.DropRewards)
            {
                if (!_rewardCache.ContainsKey(dropReward.PossessionId))
                {
                    _rewardCache[dropReward.PossessionId] = rewards.Rows.Count;
                    rewards.Rows.Add(new DataTableRow<Reward>(new Reward { Name = dropReward.PossessionName }));
                }

                rewards.Rows[_rewardCache[dropReward.PossessionId]].Data.Count += dropReward.Count;
            }

            if (_isRental)
                return;

            foreach (var costume in _costumeCache)
            {
                costume.Value.Rank = CalculatorCharacterRank.GetCharacterRank(CalculatorCostume.GetCharacterId(costume.Key));
                costume.Value.Level = CalculatorCostume.GetCurrentLevel(costume.Value.Uuid);
            }
        }

        class DeckInfo
        {
            public int DeckId { get; set; }
            public DeckType DeckType { get; set; }
            public string DeckName { get; set; }

            public override string ToString()
            {
                return string.IsNullOrEmpty(DeckName) ? $"Quest{DeckId}" : DeckName;
            }
        }

        class Reward
        {
            public string Name { get; set; }
            public int Count { get; set; }
        }

        class Costume
        {
            public int CostumeId { get; set; }
            public string Uuid { get; set; }
            public string Name { get; set; }
            public int Level { get; set; }
            public int Rank { get; set; }
        }
    }
}
