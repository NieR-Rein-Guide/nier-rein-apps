using System;
using System.Collections.Generic;
using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Models;
using ImGuiNET;
using nier_rein_gui.Controls.Buttons;
using nier_rein_gui.Resources;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Text;

namespace nier_rein_gui.Forms.Panels.Loadouts
{
    partial class LoadoutPanel
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
        private DataDeckInfo CurrentDeck
        {
            get => Decks[GetDeckIndex(CurrentDeckNumber, CurrentDeckType)];
            set => Decks[GetDeckIndex(CurrentDeckNumber, CurrentDeckType)] = value;
        }

        private void InitializeComponent()
        {
            previousButton = new ArrowButton { Direction = ImGuiDir.Left };
            nextButton = new ArrowButton { Direction = ImGuiDir.Right };

            deckTypeBox = new ComboBox<DeckType>();
            deckNameLabel = new Label();
            deckNameButton = new ImageButton { Image = NierResources.LoadEditIcon() };
            actor1 = new LoadoutActorPanel(_rein, this, 0);
            actor2 = new LoadoutActorPanel(_rein, this, 1);
            actor3 = new LoadoutActorPanel(_rein, this, 2);
            deleteButton = new NierButton { Caption = UserInterfaceTextKey.Deck.kDeleteDeck.Localize() };

            foreach (var deckType in _deckTypes)
                deckTypeBox.Items.Add(new ComboBoxItem<DeckType>(deckType, GetDeckTypeName(deckType)));
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
                        Size = new Size(1f,-1),
                        ItemSpacing = 5,
                        Items =
                        {
                            new Label {Font = FontResources.FotRodin(20), Caption = UserInterfaceTextKey.Deck.kOrganization.Localize()},
                            new StackItem(deckTypeBox){Size = new Size(1f,-1),HorizontalAlignment = HorizontalAlignment.Right}
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
                                        Size = new Size(1f,-1),
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

        private string GetDeckTypeName(DeckType deckType)
        {
            switch (deckType)
            {
                case DeckType.QUEST:
                    return UserInterfaceTextKey.Deck.kTypeQuest.Localize();

                case DeckType.RESTRICTED_QUEST:
                    return UserInterfaceTextKey.Deck.kRestrictionDeck.Localize();

                case DeckType.RESTRICTED_LIMIT_CONTENT_QUEST:
                    return UserInterfaceTextKey.Deck.kRestrictionDeck.Localize() + " Rec.o.Dusk";

                default:
                    return null;
            }
        }

        private string GetDefaultDeckName(int deckNumber, DeckType deckType)
        {
            switch (deckType)
            {
                case DeckType.QUEST:
                    return UserInterfaceTextKey.Deck.kTypeQuest.Localize() + $"{deckNumber}";

                case DeckType.RESTRICTED_QUEST:
                    return UserInterfaceTextKey.Deck.kRestrictionDeck.Localize();

                case DeckType.RESTRICTED_LIMIT_CONTENT_QUEST:
                    return UserInterfaceTextKey.Deck.kRestrictionDeck.Localize();

                default:
                    return null;
            }
        }

        private void UpdateDeck(int index)
        {
            CurrentDeckNumber = GetDeckNumber(index, CurrentDeckType);

            if (CurrentDeck.IsEmpty)
            {
                actor1.Reset(true);
                actor2.Reset(false);
                actor3.Reset(false);

                deckNameLabel.Caption = GetDefaultDeckName(CurrentDeckNumber, CurrentDeckType);
                deleteButton.Enabled = false;

                return;
            }

            deckNameLabel.Caption = CurrentDeck.ToString();
            deleteButton.Enabled = CurrentDeckType != DeckType.RESTRICTED_QUEST || !CurrentDeck.IsMinimal;

            for (var i = 0; i < CurrentDeck.UserDeckActors.Length; i++)
            {
                var actorPanel = i == 0 ? actor1 : i == 1 ? actor2 : actor3;
                if (CurrentDeck.UserDeckActors[i] == null)
                {
                    actorPanel.Reset(i == 0 || CurrentDeck.UserDeckActors[i - 1]?.Costume != null);
                    continue;
                }

                actorPanel.Update(CurrentDeck.UserDeckActors[i]);
            }
        }

        private void InitializeDecks(DeckType deckType)
        {
            Decks = new DataDeckInfo[GetMaxDeckCount(CurrentDeckType) + 1];
            foreach (var deck in CalculatorDeck.EnumerateDeckInfo(CalculatorStateUser.GetUserId(), deckType))
                Decks[GetDeckIndex(deck.UserDeckNumber, deckType)] = deck;

            for (var i = 0; i < Decks.Length; i++)
                Decks[i] ??= new DataDeckInfo(deckType, GetDeckNumber(i, deckType));
        }

        protected int GetMaxDeckCount(DeckType deckType)
        {
            switch (deckType)
            {
                case DeckType.QUEST:
                    return CalculatorDeck.kMaxDeckCount;

                case DeckType.RESTRICTED_QUEST:
                    return 1;

                case DeckType.RESTRICTED_LIMIT_CONTENT_QUEST:
                    return 5;

                default:
                    throw new InvalidOperationException("Unknown deck type.");
            }
        }

        protected int GetDeckIndex(int deckNumber, DeckType deckType)
        {
            switch (deckType)
            {
                case DeckType.QUEST:
                case DeckType.RESTRICTED_QUEST:
                    return deckNumber - 1;

                case DeckType.RESTRICTED_LIMIT_CONTENT_QUEST:
                    return deckNumber - 101;

                default:
                    throw new InvalidOperationException("Unknown deck type.");
            }
        }

        protected int GetDeckNumber(int index, DeckType deckType)
        {
            switch (deckType)
            {
                case DeckType.QUEST:
                case DeckType.RESTRICTED_QUEST:
                    return index + 1;

                case DeckType.RESTRICTED_LIMIT_CONTENT_QUEST:
                    return index + 101;

                default:
                    throw new InvalidOperationException("Unknown deck type.");
            }
        }
    }
}
