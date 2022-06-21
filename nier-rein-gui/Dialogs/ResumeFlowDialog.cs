using System.Numerics;
using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Modals;
using ImGui.Forms.Models;
using nier_rein_gui.Controls;
using nier_rein_gui.Controls.Buttons;
using NierReincarnation;
using NierReincarnation.Context;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Text;

namespace nier_rein_gui.Dialogs
{
    class ResumeFlowDialog : Modal
    {
        private readonly QuestBattleContext _questBattleContext;
        private readonly BigHuntBattleContext _bigHuntBattleContext;

        private NierButton quitButton;
        private NierButton continueButton;

        public ResumeFlowDialog(NierReinContexts rein)
        {
            _questBattleContext = rein.Battles.CreateQuestContext();
            _bigHuntBattleContext = rein.Battles.CreateBigHuntContext();

            quitButton = new NierButton { Caption = UserInterfaceTextKey.Flow.kRetryCancelTextKey.Localize(), Width = 80 };
            continueButton = new NierButton { Caption = UserInterfaceTextKey.Flow.kRetrySelectTextKey.Localize(), Width = 80, Enabled = false };

            quitButton.Clicked += QuitButton_Clicked;
            continueButton.Clicked += ContinueButton_Clicked;

            Size = new Vector2(300, 60);
            Caption = UserInterfaceTextKey.Flow.kRetryTitleTextKey.Localize();
            Content = new StackLayout
            {
                Alignment = Alignment.Vertical,
                ItemSpacing = 5,
                Items =
                {
                    new StackItem(new Label{Caption = UserInterfaceTextKey.Flow.kRetryQuestDescription.Localize()}){Size = ImGui.Forms.Models.Size.Parent},
                    new StackItem(new StackLayout
                    {
                        Alignment = Alignment.Horizontal,
                        Size = ImGui.Forms.Models.Size.Content,
                        ItemSpacing = 5,
                        Items =
                        {
                            quitButton,
                            continueButton
                        }
                    }){Size = new Size(1f,-1),HorizontalAlignment = HorizontalAlignment.Center}
                }
            };
        }

        private async void QuitButton_Clicked(object sender, System.EventArgs e)
        {
            if (QuestBattleContext.HasRunningEventQuest())
            {
                var runningEventQuest = DatabaseDefine.User.EntityIUserEventQuestProgressStatusTable.FindByUserId(CalculatorStateUser.GetUserId());
                await _questBattleContext.QuitEventQuest(runningEventQuest.CurrentEventQuestChapterId, CalculatorQuest.CreateEventQuestData(runningEventQuest.CurrentQuestId));

                Close(DialogResult.Ok);
                return;
            }

            if (QuestBattleContext.HasRunningMainQuest())
            {
                var runningMainQuest = DatabaseDefine.User.EntityIUserMainQuestProgressStatusTable.FindByUserId(CalculatorStateUser.GetUserId());
                await _questBattleContext.QuitMainQuest(CalculatorQuest.GenerateMainQuestData(runningMainQuest.CurrentQuestSceneId));

                Close(DialogResult.Ok);
                return;
            }

            if (BigHuntBattleContext.HasRunningBigHuntQuest())
            {
                var runningBigHunt = DatabaseDefine.User.EntityIUserBigHuntProgressStatusTable.FindByUserId(CalculatorStateUser.GetUserId());
                await _bigHuntBattleContext.QuitBigHuntQuest(CalculatorBigHuntQuest.GenerateBigHuntQuestData(runningBigHunt.CurrentBigHuntBossQuestId, runningBigHunt.CurrentBigHuntQuestId));

                Close(DialogResult.Ok);
                return; 
            }

            // TODO: Implement other quest types

            Close(DialogResult.Cancel);
        }

        private void ContinueButton_Clicked(object sender, System.EventArgs e)
        {

        }
    }
}
