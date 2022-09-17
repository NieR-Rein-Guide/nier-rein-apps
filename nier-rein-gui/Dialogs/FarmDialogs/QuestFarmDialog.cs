using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using System.Timers;
using ImGui.Forms;
using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Controls.Lists;
using ImGui.Forms.Modals;
using ImGuiNET;
using nier_rein_gui.Controls.Buttons;
using nier_rein_gui.Extensions;
using nier_rein_gui.Forms;
using NierReincarnation;
using NierReincarnation.Context;
using NierReincarnation.Context.Models;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using Serilog;

namespace nier_rein_gui.Dialogs.FarmDialogs
{
    abstract class QuestFarmDialog<TQuestData> : Modal
    {
        private static readonly TimeSpan TimerInterval = TimeSpan.FromSeconds(1);

        private const string LimitText_ = "Request limit reached. Waiting {0:m\\:ss}...";
        private const string RestrictionText_ = "Restrictions apply:";

        private readonly IDictionary<int, int> _rewardCache;
        private readonly IDictionary<int, Costume> _costumeCache;

        private readonly IList<TQuestData> _quests;
        private readonly DeckType _deckType;

        private TQuestData _currentQuest;
        private bool _isRental;
        private bool _isFarming;
        private bool _isCancel;

        private Label roundCaptionLabel;
        private Label roundLabel;
        private ArrowButton previousButton;
        private ArrowButton nextButton;
        private Label captionLabel;
        private Label limitLabel;
        private Label restrictionLabel;
        private ComboBox<DataDeckInfo> decks;
        private DataTable<Reward> rewards;
        private DataTable<Costume> costumes;
        private Button singleButton;
        private Button cancelButton;
        private Button startButton;

        private TimeSpan _currentLimitTime;
        private Timer _timer;

        protected QuestBattleContext BattleContext { get; }

        protected QuestFarmDialog(NierReinContexts rein, IList<TQuestData> quests, TQuestData currentQuest, DeckType deckType)
        {
            BattleContext = rein.Battles.CreateQuestContext();

            _rewardCache = new Dictionary<int, int>();
            _costumeCache = new Dictionary<int, Costume>();

            _quests = quests;
            _deckType = deckType;

            _timer = new Timer(TimerInterval.TotalMilliseconds);
            _timer.Elapsed += _timer_Elapsed;

            BattleContext.SetupReAuthorization(null, null);

            roundCaptionLabel = new Label { Caption = "Rounds:" };
            roundLabel = new Label();

            previousButton = new ArrowButton { Direction = ImGuiDir.Left };
            previousButton.Clicked += PreviousButton_Clicked;

            nextButton = new ArrowButton { Direction = ImGuiDir.Right };
            nextButton.Clicked += NextButton_Clicked;

            captionLabel = new Label();
            limitLabel = new Label { Caption = string.Empty, TextColor = Color.Firebrick };
            restrictionLabel = new Label { Caption = RestrictionText_ };

            decks = new ComboBox<DataDeckInfo>();

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
                    new StackItem(null){Size = new ImGui.Forms.Models.Size(0,0)},
                    new StackLayout
                    {
                        Size = new ImGui.Forms.Models.Size(1f,-1),
                        ItemSpacing = 5,
                        Alignment = Alignment.Horizontal,
                        Items =
                        {
                            new StackItem(null),
                            new StackLayout
                            {
                                Alignment = Alignment.Horizontal,
                                Size = ImGui.Forms.Models.Size.Content,
                                ItemSpacing = 5,
                                Items =
                                {
                                    roundCaptionLabel,
                                    new StackItem(roundLabel){Size = new ImGui.Forms.Models.Size(60,-1)}
                                }
                            }
                        }
                    },
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

            UpdateQuest(currentQuest, true);
        }

        protected abstract int GetQuestId(TQuestData data);
        protected abstract string GetQuestName(TQuestData data);
        protected abstract bool IsQuestLocked(TQuestData data);
        protected abstract void SetLock(TQuestData data, bool isLock);

        protected abstract Task<BattleResult> ExecuteQuest(TQuestData quest, DataDeck deck);

        private TQuestData GetNextQuest()
        {
            var start = _quests.IndexOf(_currentQuest);
            for (var i = start + 1; i < start + _quests.Count; i++)
            {
                var quest = _quests[i % _quests.Count];
                if (IsQuestLocked(quest))
                    continue;

                _currentQuest = quest;
                SetLock(quest, false);

                return quest;
            }

            return _currentQuest;
        }

        private TQuestData GetPreviousQuest()
        {
            var start = _quests.IndexOf(_currentQuest);
            for (var i = start - 1; i >= start - _quests.Count; i--)
            {
                var quest = _quests[i < 0 ? _quests.Count + i : i];
                if (IsQuestLocked(quest))
                    continue;

                _currentQuest = quest;
                SetLock(quest, false);

                return quest;
            }

            return _currentQuest;
        }

        private void UpdateDecks(int questId, bool forceUpdate)
        {
            // Do not list any decks if quest uses a rental deck
            var wasRental = _isRental;
            _isRental = CalculatorDeck.IsRentalDeck(questId);

            if (_isRental)
            {
                SetDeckBox(null);
                SetRestrictionLabel(null);

                startButton.Enabled = singleButton.Enabled = true;
                return;
            }

            if (!wasRental && !forceUpdate)
            {
                SetRestrictionLabel(null);
                return;
            }

            // List decks that have correct restrictions, if any
            InitializeDecks(decks, questId);

            SetRestrictionLabel(decks.Items.Count <= 0 ? restrictionLabel : null);
            SetDeckBox(decks.Items.Count > 0 ? decks : null);

            startButton.Enabled = singleButton.Enabled = decks.Items.Count > 0;
        }

        private void NextButton_Clicked(object sender, EventArgs e)
        {
            var nextQuest = GetNextQuest();
            UpdateQuest(nextQuest, true);
        }

        private void PreviousButton_Clicked(object sender, EventArgs e)
        {
            var previousQuest = GetPreviousQuest();
            UpdateQuest(previousQuest, true);
        }

        private void UpdateQuest(TQuestData quest, bool forceDeckUpdate = false)
        {
            // Update quest information
            _currentQuest = quest;
            captionLabel.Caption = $"Quest: {GetQuestName(quest)}";

            // Update restrictions
            restrictionLabel.Caption = RestrictionText_;

            var restrictionText = GetRestrictionText(GetQuestId(quest));
            if (!string.IsNullOrEmpty(restrictionText))
                restrictionLabel.Caption += Environment.NewLine + restrictionText;

            // Update decks
            UpdateDecks(GetQuestId(quest), forceDeckUpdate);

            // Clear rewards and costumes
            rewards.Rows.Clear();
            costumes.Rows.Clear();
        }

        private string GetRestrictionText(int questId)
        {
            var restrictions = CalculatorQuest.CreateDeckRestrictionList(questId);
            if (restrictions == null || restrictions.Length <= 0)
                return string.Empty;

            return string.Join(Environment.NewLine, restrictions.Select(GetRestrictionText).Where(x => !string.IsNullOrEmpty(x)));
        }

        private string GetRestrictionText(DataDeckRestriction restriction)
        {
            switch (restriction.QuestDeckRestrictionType)
            {
                case QuestDeckRestrictionType.CHARACTER_ID:
                    return $"Character: {CalculatorCharacter.GetCharacterName(restriction.RestrictionValue)}";

                case QuestDeckRestrictionType.COSTUME_ID:
                    return $"Costume: {CalculatorCostume.CostumeName(restriction.RestrictionValue)}";

                default:
                    return string.Empty;
            }
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            limitLabel.Caption = string.Format(LimitText_, _currentLimitTime);
            _currentLimitTime -= TimerInterval;

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

            SetRound(0);

            // Prepare deck
            var deck = _isRental ?
                CalculatorDeck.CreateRentalDeck(GetQuestId(_currentQuest)) :
                CalculatorDeck.CreateDataDeck(CalculatorStateUser.GetUserId(), decks.SelectedItem.Content.UserDeckNumber, _deckType);

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
            BattleContext.RequestRatioReached += RequestRatioReached;
            BattleContext.GeneralError += BattleContext_GeneralError;

            await ExecuteQuest(_currentQuest, deck);

            BattleContext.BattleFinished -= Battles_BattleFinished;
            BattleContext.RequestRatioReached -= RequestRatioReached;
            BattleContext.GeneralError -= BattleContext_GeneralError;

            SetRound(1);

            (Application.Instance.MainForm as MainForm).UpdateUser();
            (Application.Instance.MainForm as MainForm).UpdateStamina();

            _isFarming = false;
            cancelButton.Enabled = false;
            singleButton.Enabled = true;
            startButton.Enabled = true;
            previousButton.Enabled = true;
            nextButton.Enabled = true;
        }

        private async Task BattleContext_GeneralError(Grpc.Core.RpcException e)
        {
            Log.Fatal(e, "Exception executing quest.");
            await MessageBox.ShowInformationAsync("General Error", "An error occurred executing this quest.\nSee the log for more info.");
        }

        private void RequestRatioReached(TimeSpan timeout)
        {
            SetLimitLabel(limitLabel);

            _currentLimitTime = timeout;
            _timer.Start();
        }

        private void InitializeDecks(ComboBox<DataDeckInfo> deckBox, int questId)
        {
            var selectedIndex = deckBox.Items.IndexOf(deckBox.SelectedItem);

            deckBox.Items.Clear();
            deckBox.SelectedItem = null;

            var validDecks = GetValidDecks(CalculatorQuest.CreateDeckRestrictionList(questId)).ToArray();
            if (validDecks.Length <= 0)
                return;

            foreach (var deck in validDecks)
                deckBox.Items.Add(deck);

            deckBox.SelectedItem = selectedIndex < deckBox.Items.Count&&selectedIndex>=0 ? deckBox.Items[selectedIndex] : deckBox.Items[0];
        }

        private IEnumerable<DataDeckInfo> GetValidDecks(DataDeckRestriction[] restrictions)
        {
            foreach (var deck in EnumerateDecks(_quests, _currentQuest, _deckType))
            {
                if (!IsValidDeckRestriction(deck, restrictions))
                    continue;

                yield return deck;
            }
        }

        protected virtual IEnumerable<DataDeckInfo> EnumerateDecks(IList<TQuestData> quests, TQuestData quest, DeckType deckType)
        {
            return CalculatorDeck.EnumerateDeckInfo(CalculatorStateUser.GetUserId(), deckType);
        }

        private bool IsValidDeckRestriction(DataDeckInfo deck, DataDeckRestriction[] restrictions)
        {
            if (restrictions == null)
                return true;

            foreach (var restriction in restrictions)
            {
                if (deck.UserDeckActors[restriction.SlotNumber - 1] == null)
                    return false;

                bool result;
                switch (restriction.QuestDeckRestrictionType)
                {
                    case QuestDeckRestrictionType.CHARACTER_ID:
                        result = deck.UserDeckActors[restriction.SlotNumber - 1].Costume.CharacterId == restriction.RestrictionValue;
                        break;

                    case QuestDeckRestrictionType.COSTUME_ID:
                        result = deck.UserDeckActors[restriction.SlotNumber - 1].Costume.CostumeId == restriction.RestrictionValue;
                        break;

                    default:
                        result = true;
                        break;
                }

                if (!result)
                    return false;
            }

            return true;
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
            BattleContext.BattleFinished += Battles_BattleFinished;
            BattleContext.RequestRatioReached += RequestRatioReached;

            // Prepare deck
            var deck = _isRental ?
                CalculatorDeck.CreateRentalDeck(GetQuestId(_currentQuest)) :
                CalculatorDeck.CreateDataDeck(CalculatorStateUser.GetUserId(), decks.SelectedItem.Content.UserDeckNumber, _deckType);

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

            // Set rounds
            var rounds = 0;
            SetRound(rounds);

            // Execute farming
            var isCancelled = false;
            while (!_isCancel)
            {
                SetLimitLabel(null);

                var battleResult = await ExecuteQuest(_currentQuest, deck);

                (Application.Instance.MainForm as MainForm).UpdateUser();
                (Application.Instance.MainForm as MainForm).UpdateStamina();

                SetRound(++rounds);

                if (battleResult.Status == BattleStatus.ForceShutdown)
                    break;

                if (battleResult.Status == BattleStatus.OutOfStamina)
                {
                    await MessageBox.ShowErrorAsync("Out of Stamina", "You're out of stamina!");
                    break;
                }

                // TODO: Create ending conditions based on rewards
            }

            BattleContext.BattleFinished -= Battles_BattleFinished;
            BattleContext.RequestRatioReached -= RequestRatioReached;

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

        private void SetLimitLabel(Label label)
        {
            if (label == null)
                (Content as StackLayout).Items[1] = new StackItem(null) { Size = new ImGui.Forms.Models.Size(0, 0) };
            else
                (Content as StackLayout).Items[1] = new StackItem(label) { Size = new ImGui.Forms.Models.Size(1f, -1), HorizontalAlignment = HorizontalAlignment.Center };
        }

        private void SetRestrictionLabel(Label label)
        {
            if (label == null)
                (Content as StackLayout).Items[2] = new StackItem(null) { Size = new ImGui.Forms.Models.Size(0, 0) };
            else
                (Content as StackLayout).Items[2] = new StackItem(label) { Size = new ImGui.Forms.Models.Size(1f, -1), HorizontalAlignment = HorizontalAlignment.Center };
        }

        private void SetDeckBox(ComboBox<DataDeckInfo> deckBox)
        {
            if (deckBox == null)
                ((Content as StackLayout).Items[3].Content as StackLayout).Items[0] = new StackItem(null) { Size = new ImGui.Forms.Models.Size(0, 0) };
            else
                ((Content as StackLayout).Items[3].Content as StackLayout).Items[0] = new StackItem(deckBox) { Size = ImGui.Forms.Models.Size.Content };
        }

        private void SetRound(int rounds)
        {
            roundLabel.Caption = $"{rounds}";
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
