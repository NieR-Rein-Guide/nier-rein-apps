using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Models;
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
        private ImageButton deckNameButton;
        private LoadoutActorPanel actor1;
        private LoadoutActorPanel actor2;
        private LoadoutActorPanel actor3;

        protected DataDeckInfo[] Decks { get; private set; }

        protected int CurrentDeckNumber { get; private set; }
        private DataDeckInfo CurrentDeck => Decks[CurrentDeckNumber - 1];

        private void InitializeComponent()
        {
            previousButton = new ArrowButton { Direction = ImGuiDir.Left };
            nextButton = new ArrowButton { Direction = ImGuiDir.Right };

            deckNameLabel = new Label();
            deckNameButton = new ImageButton { Image = NierResources.LoadEditIcon() };
            actor1 = new LoadoutActorPanel(_rein, this, 0);
            actor2 = new LoadoutActorPanel(_rein, this, 1);
            actor3 = new LoadoutActorPanel(_rein, this, 2);

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
                                    }
                                }
                            },
                            new StackItem(nextButton) {VerticalAlignment = VerticalAlignment.Center}
                        }
                    }
                }
            };

            InitializeDecks();
            UpdateDeck(1);
        }

        private void UpdateDeck(int deckNumber)
        {
            CurrentDeckNumber = deckNumber;

            if (CurrentDeck.IsEmpty)
            {
                actor1.Reset(true);
                actor2.Reset(false);
                actor3.Reset(false);

                deckNameLabel.Caption = UserInterfaceTextKey.Deck.kTypeQuest.Localize() + $"{deckNumber}";

                return;
            }

            deckNameLabel.Caption = string.IsNullOrEmpty(CurrentDeck.Name) ? UserInterfaceTextKey.Deck.kTypeQuest.Localize() + $"{deckNumber}" : CurrentDeck.Name;

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

        private void InitializeDecks()
        {
            Decks = new DataDeckInfo[10];
            foreach (var deck in CalculatorDeck.EnumerateDeckInfo(CalculatorStateUser.GetUserId(), DeckType.QUEST))
                Decks[deck.UserDeckNumber - 1] = deck;

            for (var i = 0; i < Decks.Length; i++)
                Decks[i] ??= new DataDeckInfo(DeckType.QUEST, i + 1);
        }
    }
}
