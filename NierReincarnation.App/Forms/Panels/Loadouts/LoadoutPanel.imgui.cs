using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Models;
using ImGuiNET;
using NierReincarnation.App.Controls.Buttons;
using NierReincarnation.App.Resources;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Text;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NierReincarnation.App.Forms.Panels.Loadouts
{
    internal partial class LoadoutPanel
    {
        private readonly IList<DeckType> _deckTypes = new List<DeckType>
        {
            DeckType.QUEST,
            DeckType.RESTRICTED_QUEST,
            DeckType.RESTRICTED_LIMIT_CONTENT_QUEST
        };

        private ArrowButton previousButton;
        private ArrowButton nextButton;

        private ComboBox<DeckType> deckTypeBox;
        private Label deckNameLabel;
        private ImageButton deckNameButton;
        private LoadoutActorPanel actor1;
        private LoadoutActorPanel actor2;
        private LoadoutActorPanel actor3;
        private NierButton deleteButton;

        protected DataDeckInfo[] Decks { get; private set; }

        protected int CurrentDeckNumber { get; private set; }

        protected DeckType CurrentDeckType { get; private set; } = DeckType.QUEST;

        private void InitializeComponent()
        {
            previousButton = new ArrowButton { Direction = ImGuiDir.Left };
            nextButton = new ArrowButton { Direction = ImGuiDir.Right };

            deckTypeBox = new ComboBox<DeckType>();
            deckNameLabel = new Label();
            deckNameButton = new ImageButton { Image = NierResources.LoadEditIcon(), ImageSize = NierResources.RarityStarSize };
            actor1 = new LoadoutActorPanel(_rein, this, 0);
            actor2 = new LoadoutActorPanel(_rein, this, 1);
            actor3 = new LoadoutActorPanel(_rein, this, 2);
            deleteButton = new NierButton { Text = UserInterfaceTextKey.Deck.kDeleteDeck.Localize() };

            foreach (var deckType in _deckTypes)
            {
                if (GetMaxDeckCount(deckType) > 0)
                    deckTypeBox.Items.Add(new ComboBoxItem<DeckType>(deckType, GetDeckTypeName(deckType)));
            }
            deckTypeBox.SelectedItem = deckTypeBox.Items[0];

            Content = new StackLayout
            {
                Alignment = Alignment.Vertical,
                ItemSpacing = 5,
                Items =
                {
                    new StackLayout
                    {
                        Alignment = Alignment.Horizontal,
                        Size = Size.WidthAlign,
                        ItemSpacing = 5,
                        Items =
                        {
                            new Label {Font = FontResources.FotRodin(20), Text = UserInterfaceTextKey.Deck.kOrganization.Localize()},
                            new StackItem(deckTypeBox){Size = Size.WidthAlign,HorizontalAlignment = HorizontalAlignment.Right}
                        }
                    },
                    new StackLayout
                    {
                        Alignment = Alignment.Horizontal,
                        ItemSpacing = 5,
                        Items =
                        {
                            new StackItem(previousButton) {VerticalAlignment = VerticalAlignment.Center},
                            new StackLayout
                            {
                                Alignment = Alignment.Vertical,
                                ItemSpacing = 5,
                                Items =
                                {
                                    new StackLayout
                                    {
                                        Alignment = Alignment.Horizontal,
                                        ItemSpacing = 5,
                                        Size = Size.WidthAlign,
                                        Items =
                                        {
                                            new StackItem(deckNameLabel){VerticalAlignment = VerticalAlignment.Center},
                                            deckNameButton
                                        }
                                    },
                                    new StackLayout
                                    {
                                        Alignment = Alignment.Horizontal,
                                        ItemSpacing = 5,
                                        Items =
                                        {
                                            actor2,
                                            actor1,
                                            actor3
                                        }
                                    },
                                    deleteButton
                                }
                            },
                            new StackItem(nextButton) {VerticalAlignment = VerticalAlignment.Center}
                        }
                    }
                }
            };

            InitializeDecks(CurrentDeckType);
            UpdateDeck(0);
        }

        private static string GetDeckTypeName(DeckType deckType)
        {
            return deckType switch
            {
                DeckType.QUEST => UserInterfaceTextKey.Deck.kTypeQuest.Localize(),
                DeckType.RESTRICTED_QUEST => UserInterfaceTextKey.Deck.kRestrictionDeck.Localize(),
                DeckType.RESTRICTED_LIMIT_CONTENT_QUEST => UserInterfaceTextKey.Deck.kRestrictionDeck.Localize() + " " + LocalizationResources.DeckDuskExtra,
                _ => null,
            };
        }

        private static string GetDefaultDeckName(int deckNumber, DeckType deckType)
        {
            switch (deckType)
            {
                case DeckType.QUEST:
                    return UserInterfaceTextKey.Deck.kTypeQuest.Localize() + $"{deckNumber}";

                case DeckType.RESTRICTED_QUEST:
                    return UserInterfaceTextKey.Deck.kRestrictionDeck.Localize() + $"{deckNumber}";

                case DeckType.RESTRICTED_LIMIT_CONTENT_QUEST:
                    var quests = CalculatorLimitContent.CreateDataLimitContentCharacters().OrderBy(x => x.SortOrder).ToArray();
                    var questIndex = (deckNumber - 101) / 100;

                    return UserInterfaceTextKey.Deck.kRestrictionDeck.Localize() + $" {quests[questIndex].Costume.CharacterName}{deckNumber % 100}";

                default:
                    return null;
            }
        }

        private void UpdateDeck(int index)
        {
            CurrentDeckNumber = GetDeckNumber(index, CurrentDeckType);
            var currentDeck = GetCurrentDeck();

            if (currentDeck?.IsEmpty ?? true)
            {
                actor1.Reset(true);
                actor2.Reset(false);
                actor3.Reset(false);

                deckNameLabel.Text = GetDefaultDeckName(CurrentDeckNumber, CurrentDeckType);
                deleteButton.Enabled = false;

                return;
            }

            deckNameLabel.Text = currentDeck.ToString();
            deleteButton.Enabled = CurrentDeckType != DeckType.RESTRICTED_QUEST || !currentDeck.IsMinimal;

            for (var i = 0; i < currentDeck.UserDeckActors.Length; i++)
            {
                var actorPanel = i == 0 ? actor1 : i == 1 ? actor2 : actor3;
                if (currentDeck.UserDeckActors[i] == null)
                {
                    actorPanel.Reset(i == 0 || currentDeck.UserDeckActors[i - 1]?.Costume != null);
                    continue;
                }

                actorPanel.Update(currentDeck.UserDeckActors[i]);
            }
        }

        private void InitializeDecks(DeckType deckType)
        {
            Decks = new DataDeckInfo[GetMaxDeckCount(CurrentDeckType)];
            foreach (var deck in CalculatorDeck.EnumerateDeckInfo(CalculatorStateUser.GetUserId(), deckType))
                Decks[GetDeckIndex(deck.UserDeckNumber, deckType)] = deck;

            for (var i = 0; i < Decks.Length; i++)
                Decks[i] ??= new DataDeckInfo(deckType, GetDeckNumber(i, deckType));
        }

        protected static int GetMaxDeckCount(DeckType deckType)
        {
            return deckType switch
            {
                DeckType.QUEST => CalculatorDeck.kMaxDeckCount,
                DeckType.RESTRICTED_QUEST => CalculatorDeck.EnumerateDeckInfo(CalculatorStateUser.GetUserId(), DeckType.RESTRICTED_QUEST).Count(),
                DeckType.RESTRICTED_LIMIT_CONTENT_QUEST => CalculatorLimitContent.CreateDataLimitContentCharacters().Count * CalculatorDeck.kMaxLimitContentDeckCount,
                _ => throw new InvalidOperationException("Unknown deck type."),
            };
        }

        protected static int GetDeckIndex(int deckNumber, DeckType deckType)
        {
            switch (deckType)
            {
                case DeckType.QUEST:
                case DeckType.RESTRICTED_QUEST:
                    return deckNumber - 1;

                case DeckType.RESTRICTED_LIMIT_CONTENT_QUEST:
                    var batch = (deckNumber / 100) - 1;
                    return (batch * CalculatorDeck.kMaxLimitContentDeckCount) + (deckNumber % 100) - 1;

                default:
                    throw new InvalidOperationException("Unknown deck type.");
            }
        }

        protected static int GetDeckNumber(int index, DeckType deckType)
        {
            switch (deckType)
            {
                case DeckType.QUEST:
                case DeckType.RESTRICTED_QUEST:
                    return index + 1;

                case DeckType.RESTRICTED_LIMIT_CONTENT_QUEST:
                    var batch = (index / CalculatorDeck.kMaxLimitContentDeckCount) + 1;
                    return (batch * 100) + (index % CalculatorDeck.kMaxLimitContentDeckCount) + 1;

                default:
                    throw new InvalidOperationException("Unknown deck type.");
            }
        }

        protected DataDeckInfo GetCurrentDeck()
        {
            var index = GetDeckIndex(CurrentDeckNumber, CurrentDeckType);
            if (index >= Decks.Length)
                return null;

            return Decks[index];
        }

        protected void SetCurrentDeck(DataDeckInfo deck)
        {
            var index = GetDeckIndex(CurrentDeckNumber, CurrentDeckType);
            if (index >= Decks.Length)
                return;

            Decks[index] = deck;
        }
    }
}
