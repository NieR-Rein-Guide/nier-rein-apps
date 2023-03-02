using ImGui.Forms.Controls;
using NierReincarnation.App.Controls.Base;
using System.Collections.Generic;

namespace NierReincarnation.App.Forms.Panels.SubQuests.Characters.Base
{
    internal abstract partial class ButtonListPanel<TChapterData, TPanel> : Panel
        where TPanel : Panel, IClosablePanel
    {
        protected ButtonListPanel()
        {
            InitializeComponent();
        }

        protected abstract IList<TChapterData> GetDataElements();

        protected abstract string GetText(TChapterData chapter);

        protected abstract bool IsButtonEnabled(TChapterData chapter);

        protected abstract TPanel CreatePanel(TChapterData chapter, IList<TChapterData> chapters);
    }
}
