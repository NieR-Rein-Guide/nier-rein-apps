using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Modals;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;

namespace NierReincarnation.App.Dialogs.FarmDialogs
{
    // TODO: Implement!
    internal class MemoirFarmDialog : Modal
    {
        private readonly NierReinContexts _rein;
        private readonly EventQuestData _quest;

        public MemoirFarmDialog(NierReinContexts rein, EventQuestData quest)
        {
            _rein = rein;
            _quest = quest;

            Content = new StackLayout();
        }
    }
}
