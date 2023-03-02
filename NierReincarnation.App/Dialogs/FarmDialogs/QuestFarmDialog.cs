using ImGui.Forms;
using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Controls.Lists;
using ImGui.Forms.Modals;
using ImGuiNET;
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
using Serilog;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace NierReincarnation.App.Dialogs.FarmDialogs
{
    internal abstract class QuestFarmDialog<TQuestData> : Modal
    {
        private readonly IDictionary<int, int> _rewardCache;
        private readonly IDictionary<int, Costume> _costumeCache;

        private readonly IList<TQuestData> _quests;
        private readonly DeckType _deckType;

        private TQuestData _currentQuest;
        private bool _isRental;
        private bool _isFarming;
        private bool _isCancel;

        private readonly Label roundTextLabel;
        private readonly Label roundLabel;
        private readonly ArrowButton previousButton;
        private readonly ArrowButton nextButton;
        private readonly Label TextLabel;
        private readonly Label limitLabel;
        private readonly Label restrictionLabel;
        private readonly ComboBox<DataDeckInfo> decks;
        private readonly DataTable<Reward> rewards;
        private readonly DataTable<Costume> costumes;
        private readonly NierButton singleButton;
        private readonly NierButton cancelButton;
        private readonly NierButton startButton;

        protected QuestBattleContext BattleContext { get; }

        protected QuestFarmDialog(NierReinContexts rein, IList<TQuestData> quests, TQuestData currentQuest, DeckType deckType)
        {
            BattleContext = rein.Battles.CreateQuestContext();

            _rewardCache = new Dictionary<int, int>();
            _costumeCache = new Dictionary<int, Costume>();

            _quests = quests;
            _deckType = deckType;

            BattleContext.SetupReAuthorization(null, null);

            roundTextLabel = new Label { Text = LocalizationResources.RoundCounter };
            roundLabel = new Label();

            previousButton = new ArrowButton { Direction = ImGuiDir.Left };
            previousButton.Clicked += PreviousButton_Clicked;

            nextButton = new ArrowButton { Direction = ImGuiDir.Right };
            nextButton.Clicked += NextButton_Clicked;

            TextLabel = new Label();
            limitLabel = new Label
            {
                Text = string.Empty,
                TextColor = Color.Firebrick
            };
            restrictionLabel = new Label { Text = LocalizationResources.DeckRestrictions };

            decks = new ComboBox<DataDeckInfo>();

            rewards = new DataTable<Reward>
            {
                IsSelectable = false,
                IsResizable = true,
                Columns =
                {
                    new DataTableColumn<Reward>(reward => reward.Name, LocalizationResources.RewardsColumnName),
                    new DataTableColumn<Reward>(reward => $"{reward.Count}", LocalizationResources.RewardsColumnCount)
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
                    new DataTableColumn<Costume>(costume => costume.Name, LocalizationResources.CostumesColumnName),
                    new DataTableColumn<Costume>(costume => $"{costume.Level}", LocalizationResources.CostumesColumnLevel),
                    new DataTableColumn<Costume>(costume => $"{costume.Rank}", LocalizationResources.CostumesColumnRank)
                },
                Rows = new List<DataTableRow<Costume>>()
            };

            singleButton = new NierButton { Text = LocalizationResources.ClearOnce, Padding = new Vector2(2, 2) };
            singleButton.Clicked += SingleButton_Clicked;

            cancelButton = new NierButton { Text = LocalizationResources.Cancel, Padding = new Vector2(2, 2), Enabled = false };
            cancelButton.Clicked += CancelButton_Clicked;

            startButton = new NierButton { Text = LocalizationResources.Start, Padding = new Vector2(2, 2) };
            startButton.Clicked += StartButton_Clicked;

            Caption = LocalizationResources.TitleFarmingGeneral;
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
                        Size = ImGui.Forms.Models.Size.WidthAlign,
                        ItemSpacing = 5,
                        Items =
                        {
                            previousButton,
                            new StackItem(TextLabel){Size = ImGui.Forms.Models.Size.WidthAlign},
                            nextButton
                        }
                    },
                    new StackItem(null){Size = ImGui.Forms.Models.Size.Empty},
                    new StackItem(null){Size = ImGui.Forms.Models.Size.Empty},
                    new StackLayout
                    {
                        Size = ImGui.Forms.Models.Size.WidthAlign,
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
                                    roundTextLabel,
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

            UpdateQuest(currentQuest, true);

            if (CooldownTimer.IsRunning)
            {
                SetLimitLabelText(CooldownTimer.CurrentCooldown);
                SetLimitLabel(limitLabel);
            }

            CooldownTimer.CooldownStart += CooldownTimer_CooldownStart;
            CooldownTimer.CooldownFinish += CooldownTimer_CooldownFinish;
            CooldownTimer.Elapsed += CooldownTimer_Elapsed;
        }

        protected abstract int GetQuestId(TQuestData data);

        protected abstract string GetQuestName(TQuestData data);

        protected abstract int GetQuestDailyCount(TQuestData data);

        protected abstract bool IsQuestLocked(TQuestData data);

        protected abstract void SetQuestLocked(TQuestData data, bool isLock);

        protected abstract Task<BattleResult> ExecuteQuest(TQuestData quest, DataDeck deck);

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

        private TQuestData GetNextQuest()
        {
            var start = _quests.IndexOf(_currentQuest);
            for (var i = start + 1; i < start + _quests.Count; i++)
            {
                var quest = _quests[i % _quests.Count];
                if (IsQuestLocked(quest))
                    continue;

                _currentQuest = quest;
                SetQuestLocked(quest, false);

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
                SetQuestLocked(quest, false);

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

            SetRestrictionLabel(decks.Items.Count == 0 ? restrictionLabel : null);
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
            TextLabel.Text = string.Format(LocalizationResources.QuestName, GetQuestName(quest));

            // Update restrictions
            restrictionLabel.Text = LocalizationResources.DeckRestrictions;

            var restrictionText = GetRestrictionText(GetQuestId(quest));
            if (!string.IsNullOrEmpty(restrictionText))
                restrictionLabel.Text += Environment.NewLine + restrictionText;

            // Update decks
            UpdateDecks(GetQuestId(quest), forceDeckUpdate);

            // Clear rewards and costumes
            rewards.Rows.Clear();
            costumes.Rows.Clear();

            // Activate start button for non-daily quests
            startButton.Enabled = GetQuestDailyCount(quest) <= 0;
        }

        private string GetRestrictionText(int questId)
        {
            var restrictions = CalculatorQuest.CreateDeckRestrictionList(questId);
            if (restrictions == null || restrictions.Length == 0)
                return string.Empty;

            return string.Join(Environment.NewLine, restrictions.Select(GetRestrictionText).Where(x => !string.IsNullOrEmpty(x)));
        }

        private string GetRestrictionText(DataDeckRestriction restriction)
        {
            return restriction.QuestDeckRestrictionType switch
            {
                QuestDeckRestrictionType.CHARACTER_ID => string.Format(LocalizationResources.DeckRestrictionsCharacter, GetRestrictionSlotName(restriction.SlotNumber), CalculatorCharacter.GetCharacterName(restriction.RestrictionValue)),
                QuestDeckRestrictionType.COSTUME_ID => string.Format(LocalizationResources.DeckRestrictionsCostume, GetRestrictionSlotName(restriction.SlotNumber), CalculatorCostume.CostumeName(restriction.RestrictionValue)),
                _ => string.Empty,
            };
        }

        private static string GetRestrictionSlotName(int slotNumber)
        {
            return slotNumber switch
            {
                1 => LocalizationResources.DeckRestrictionsSlot1,
                2 => LocalizationResources.DeckRestrictionsSlot2,
                3 => LocalizationResources.DeckRestrictionsSlot3,
                _ => throw new InvalidOperationException("Invalid restriction slot."),
            };
        }

        private async Task BattleContext_GeneralError(Grpc.Core.RpcException e)
        {
            Log.Fatal(e, "Exception executing quest.");
            await MessageBox.ShowInformationAsync(LocalizationResources.ErrorTitle, LocalizationResources.ErrorDescription);
        }

        private void InitializeDecks(ComboBox<DataDeckInfo> deckBox, int questId)
        {
            var selectedIndex = deckBox.Items.IndexOf(deckBox.SelectedItem);

            deckBox.Items.Clear();
            deckBox.SelectedItem = null;

            var validDecks = GetValidDecks(CalculatorQuest.CreateDeckRestrictionList(questId)).ToArray();
            if (validDecks.Length == 0)
                return;

            foreach (var deck in validDecks)
                deckBox.Items.Add(deck);

            deckBox.SelectedItem = selectedIndex < deckBox.Items.Count && selectedIndex >= 0 ? deckBox.Items[selectedIndex] : deckBox.Items[0];
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

        private static bool IsValidDeckRestriction(DataDeckInfo deck, DataDeckRestriction[] restrictions)
        {
            if (restrictions == null)
                return true;

            foreach (var restriction in restrictions)
            {
                if (deck.UserDeckActors[restriction.SlotNumber - 1] == null)
                    return false;
                var result = restriction.QuestDeckRestrictionType switch
                {
                    QuestDeckRestrictionType.CHARACTER_ID => deck.UserDeckActors[restriction.SlotNumber - 1].Costume.CharacterId == restriction.RestrictionValue,
                    QuestDeckRestrictionType.COSTUME_ID => deck.UserDeckActors[restriction.SlotNumber - 1].Costume.CostumeId == restriction.RestrictionValue,
                    _ => true,
                };
                if (!result)
                    return false;
            }

            return true;
        }

        private async void SingleButton_Clicked(object sender, EventArgs e)
        {
            await ExecuteBattle(1, false);
        }

        private async void StartButton_Clicked(object sender, EventArgs e)
        {
            await ExecuteBattle(-1, true);
        }

        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            _isCancel = true;
            cancelButton.Enabled = false;
        }

        protected override bool ShouldCancelClose()
        {
            return _isFarming;
        }

        private async Task ExecuteBattle(int rounds, bool cancellable)
        {
            if (await CooldownHelper.IsOnCooldown())
                return;

            _costumeCache.Clear();
            _rewardCache.Clear();
            costumes.Rows.Clear();
            rewards.Rows.Clear();

            _isCancel = false;
            _isFarming = true;

            // HINT: Necessary to keep state of UpdateQuest for startButton
            var startBtnValue = startButton.Enabled;

            previousButton.Enabled = false;
            nextButton.Enabled = false;
            cancelButton.Enabled = cancellable;
            singleButton.Enabled = false;
            startButton.Enabled = false;

            var roundCount = await Farm(rounds);

            cancelButton.Enabled = false;
            previousButton.Enabled = true;
            nextButton.Enabled = true;
            singleButton.Enabled = true;
            startButton.Enabled = startBtnValue;

            _isFarming = false;

            var dailyCount = GetQuestDailyCount(_currentQuest);
            if (dailyCount > 0 && roundCount >= dailyCount)
                Close(DialogResult.Ok);
        }

        private async Task<int> Farm(int rounds = -1)
        {
            // Prepare battle events
            BattleContext.BattleFinished += Battles_BattleFinished;
            BattleContext.GeneralError += BattleContext_GeneralError;

            // Prepare deck
            var deck = _isRental ?
                CalculatorDeck.CreateRentalDeck(GetQuestId(_currentQuest)) :
                CalculatorDeck.CreateDataDeck(CalculatorStateUser.GetUserId(), decks.SelectedItem.Content.UserDeckNumber, _deckType);

            // Prepare costume table
            foreach (var actor in deck.UserDeckActors)
            {
                if (actor != null)
                {
                    _costumeCache[actor.Costume.CostumeId] = new Costume
                    {
                        CostumeId = actor.Costume.CostumeId,
                        Uuid = actor.Costume.UserCostumeUuid,
                        Name = actor.Costume.CharacterName,
                        Level = actor.Costume.CostumeStatus.Level,
                        Rank = CalculatorCharacterRank.GetCharacterRank(actor.Costume.CharacterId)
                    };
                }
            }

            foreach (var costume in _costumeCache)
                costumes.Rows.Add(new DataTableRow<Costume>(costume.Value));

            // Set rounds
            var roundCount = 0;
            SetRound(roundCount);

            // Execute farming
            //var isCancelled = false;
            while (!_isCancel && (rounds < 0 || roundCount < rounds))
            {
                var battleResult = await ExecuteQuest(_currentQuest, deck);

                (Application.Instance.MainForm as MainForm)?.UpdateUser();
                (Application.Instance.MainForm as MainForm)?.UpdateStamina();

                if (battleResult.Status == BattleStatus.ForceShutdown)
                    break;

                if (battleResult.Status == BattleStatus.OutOfStamina)
                {
                    await MessageBox.ShowErrorAsync(LocalizationResources.StaminaTitle, LocalizationResources.StaminaDescription);
                    break;
                }

                // Update round count only after successful battle round
                SetRound(++roundCount);

                // TODO: Create ending conditions based on rewards
            }

            BattleContext.BattleFinished -= Battles_BattleFinished;
            BattleContext.GeneralError -= BattleContext_GeneralError;

            //if (_isCancel)
            //    isCancelled = true;

            return roundCount;
        }

        private void Battles_BattleFinished(object sender, FinishBattleEventArgs e)
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

        private void SetRestrictionLabel(Label label)
        {
            if (label == null)
                (Content as StackLayout).Items[2] = new StackItem(null) { Size = ImGui.Forms.Models.Size.Empty };
            else
                (Content as StackLayout).Items[2] = new StackItem(label) { Size = ImGui.Forms.Models.Size.WidthAlign, HorizontalAlignment = HorizontalAlignment.Center };
        }

        private void SetDeckBox(ComboBox<DataDeckInfo> deckBox)
        {
            if (deckBox == null)
                ((Content as StackLayout).Items[3].Content as StackLayout).Items[0] = new StackItem(null) { Size = ImGui.Forms.Models.Size.Empty };
            else
                ((Content as StackLayout).Items[3].Content as StackLayout).Items[0] = new StackItem(deckBox) { Size = ImGui.Forms.Models.Size.Content };
        }

        private void SetRound(int rounds)
        {
            roundLabel.Text = $"{rounds}";
        }

        private class Reward
        {
            public string Name { get; set; }

            public int Count { get; set; }
        }

        private class Costume
        {
            public int CostumeId { get; set; }

            public string Uuid { get; set; }

            public string Name { get; set; }

            public int Level { get; set; }

            public int Rank { get; set; }
        }
    }
}
