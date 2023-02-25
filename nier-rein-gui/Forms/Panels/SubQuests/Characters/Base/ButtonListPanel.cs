using System.Collections.Generic;
using ImGui.Forms.Controls;
using nier_rein_gui.Controls.Base;
using nier_rein_gui.Forms.Panels.SubQuests.Quests.Base;

namespace nier_rein_gui.Forms.Panels.SubQuests.Characters.Base
{
    abstract partial class ButtonListPanel<TChapterData, TPanel> : Panel 
        where TPanel : Panel, IClosablePanel
    {
        public ButtonListPanel()
        {
            InitializeComponent();
        }

        protected abstract IList<TChapterData> GetDataElements();

        protected abstract string GetText(TChapterData chapter);

        protected abstract bool IsButtonEnabled(TChapterData chapter);

        protected abstract TPanel CreatePanel(TChapterData chapter, IList<TChapterData> chapters);
    }
}
