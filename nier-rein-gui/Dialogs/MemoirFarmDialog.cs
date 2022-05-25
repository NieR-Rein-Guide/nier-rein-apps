using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Modals;
using NierReincarnation;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;

namespace nier_rein_gui.Dialogs
{
    class MemoirFarmDialog : Modal
    {
        private readonly NierReinContexts _rein;
        private readonly EventQuestData _quest;

        public MemoirFarmDialog(NierReinContexts rein, EventQuestData quest)
        {
            _rein = rein;
            _quest = quest;

            Content=new StackLayout
            {

            };
        }
    }
}
