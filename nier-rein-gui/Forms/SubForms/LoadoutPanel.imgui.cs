using System.Collections.Generic;
using System.Linq;
using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Layouts;
using ImGuiNET;
using nier_rein_gui.Resources;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Text;

namespace nier_rein_gui.Forms.SubForms
{
    partial class LoadoutPanel
    {
        private ArrowButton previousButton;
        private ArrowButton nextButton;

        private Label deckNameLabel;
        private LoadoutActorPanel actor1;
        private LoadoutActorPanel actor2;
        private LoadoutActorPanel actor3;

        private List<DataDeckInfo> decks;

        private int _currentDeckNumber;
        private DataDeckInfo _currentDeck;

        private void InitializeComponent()
        {
            previousButton = new ArrowButton { Direction = ImGuiDir.Left };
            nextButton = new ArrowButton { Direction = ImGuiDir.Right };

            deckNameLabel = new Label();
            actor1 = new LoadoutActorPanel(_rein);
            actor2 = new LoadoutActorPanel(_rein);
            actor3 = new LoadoutActorPanel(_rein);

            Content = new StackLayout
            {
                Alignment = Alignment.Vertical,
                ItemSpacing = 5,
                Items =
                {
                    new Label {Font = FontResources.FotRodin(20), Caption = UserInterfaceTextKey.Deck.kOrganization.Localize()},
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
                                    deckNameLabel,
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
                                    }
                                }
                            },
                            new StackItem(nextButton) {VerticalAlignment = VerticalAlignment.Center}
                        }
                    }
                }
            };

            InitializeDecks();
            UpdateDeck(decks[0].UserDeckNumber, decks[0]);
        }

        private void UpdateDeck(int deckNumber, DataDeckInfo deck)
        {
            _currentDeckNumber = deckNumber;
            _currentDeck = deck;

            if (deck == null)
            {
                actor1.Reset();
                actor2.Reset();
                actor3.Reset();

                deckNameLabel.Caption = UserInterfaceTextKey.Deck.kTypeQuest.Localize() + $"{deckNumber}";

                return;
            }

            deckNameLabel.Caption = string.IsNullOrEmpty(deck.Name) ? UserInterfaceTextKey.Deck.kTypeQuest.Localize() + $"{deckNumber}" : deck.Name;

            for (var i = 0; i < deck.UserDeckActors.Length; i++)
            {
                var actorPanel = i == 0 ? actor1 : i == 1 ? actor2 : actor3;
                if (deck.UserDeckActors[i] == null)
                {
                    actorPanel.Reset();
                    continue;
                }

                actorPanel.Update(deck, deck.UserDeckActors[i]);
            }
        }

        private void InitializeDecks()
        {
            decks = CalculatorDeck.EnumerateDeckInfo(CalculatorStateUser.GetUserId(), DeckType.QUEST).ToList();
        }
    }
}
