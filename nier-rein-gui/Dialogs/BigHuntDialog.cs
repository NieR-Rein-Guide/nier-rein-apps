using System.Numerics;
using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Modals;
using ImGui.Forms.Models;
using nier_rein_gui.Controls;
using NierReincarnation;
using NierReincarnation.Context;
using NierReincarnation.Context.Models;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;

namespace nier_rein_gui.Dialogs
{
    class BigHuntDialog : Modal
    {
        private readonly BigHuntBattleContext _bigHuntBattleContext;
        private readonly BigHuntQuestData _quest;

        private ComboBox<DataDeckInfo> decks;
        private ComboBox<SubjugationGrade> grades;
        private NierButton clearButton;

        private bool _cancelClose;

        public BigHuntDialog(NierReinContexts rein, BigHuntQuestData quest)
        {
            _bigHuntBattleContext = rein.Battles.CreateBigHuntContext();
            _quest = quest;

            decks = new ComboBox<DataDeckInfo>();
            InitializeDecks(decks);

            grades = new ComboBox<SubjugationGrade>();
            InitializeGrades(grades);

            clearButton = new NierButton { Caption = "Clear", Padding = new Vector2(2, 2) };
            clearButton.Clicked += ClearButton_Clicked;

            Size = new Vector2(250, 100);
            Content = new StackLayout
            {
                Alignment = Alignment.Vertical,
                ItemSpacing = 5,
                Items =
                {
                    new Label { Caption = $"{CalculatorBigHuntQuest.GetBigHuntBossNameByBigHuntBossQuestId(quest.BigHuntBossQuestId)}:\n{quest.QuestName}" },
                    new StackItem(null){Size = new Size(0,0)},
                    new StackLayout
                    {
                        Alignment = Alignment.Horizontal,
                        ItemSpacing = 5,
                        Items =
                        {
                            new StackItem(decks){Size = new Size(.5f,-1)},
                            new StackItem(grades){Size = new Size(.5f,-1)}
                        }
                    },
                    new StackLayout
                    {
                        Alignment = Alignment.Horizontal,
                        Size = new Size(1f, -1),
                        Items =
                        {
                            new StackItem(clearButton){Size = new Size(1f,-1),HorizontalAlignment = HorizontalAlignment.Right}
                        }
                    }
                }
            };
        }

        private async void ClearButton_Clicked(object sender, System.EventArgs e)
        {
            clearButton.Enabled = false;
            _cancelClose = true;

            await _bigHuntBattleContext.ExecuteBigHuntQuest(_quest, decks.SelectedItem.Content.UserDeckNumber - 100, grades.SelectedItem.Content);

            _cancelClose = false;
            clearButton.Enabled = true;
        }

        protected override bool ShouldCancelClose()
        {
            return _cancelClose;
        }

        private void InitializeDecks(ComboBox<DataDeckInfo> decks)
        {
            foreach (var deck in CalculatorDeck.EnumerateDeckInfo(CalculatorStateUser.GetUserId(), DeckType.BIG_HUNT))
                decks.Items.Add(deck);

            decks.SelectedItem = decks.Items[0];
        }

        private void InitializeGrades(ComboBox<SubjugationGrade> grades)
        {
            var maxOrder = new SubjugationGrade
            {
                Grade = Grade.SSS,
                Rank = 1
            }.GetOrder();

            for (var order = 0; order <= maxOrder; order++)
                grades.Items.Add(new ComboBoxItem<SubjugationGrade>(new SubjugationGrade
                {
                    Grade = (Grade)(order / 10),
                    Rank = order % 10 + 1
                }));

            grades.SelectedItem = grades.Items[0];
        }
    }
}
