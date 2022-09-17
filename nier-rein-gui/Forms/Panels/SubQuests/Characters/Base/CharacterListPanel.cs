using System.Collections.Generic;
using ImGui.Forms.Controls;
using nier_rein_gui.Controls.Base;
using nier_rein_gui.Forms.Panels.SubQuests.Quests.Base;

namespace nier_rein_gui.Forms.Panels.SubQuests.Characters.Base
{
    abstract partial class CharacterListPanel<TChapterData, TPanel> : Panel 
        where TPanel : Panel, IClosablePanel
    {
        public CharacterListPanel()
        {
            InitializeComponent();
        }

        protected abstract IList<TChapterData> GetCharacters();

        protected abstract int GetCharacterId(TChapterData chapter);

        protected abstract bool IsChapterLocked(TChapterData chapter);

        protected abstract TPanel CreateCharacterPanel(TChapterData chapter, IList<TChapterData> chapters);
    }
}
