using ImGui.Forms.Controls;
using NierReincarnation;

namespace nier_rein_gui.Forms.SubForms
{
    class MapPanel : Panel
    {
        private readonly NierReinContexts _rein;
        private readonly MainForm _main;

        public MapPanel(NierReinContexts rein, MainForm main)
        {
            _rein = rein;
            _main = main;
        }
    }
}
