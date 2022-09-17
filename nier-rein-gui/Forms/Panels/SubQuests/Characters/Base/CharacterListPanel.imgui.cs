using ImGui.Forms.Controls.Lists;
using nier_rein_gui.Controls.Buttons;
using NierReincarnation.Core.Dark.Calculator.Outgame;

namespace nier_rein_gui.Forms.Panels.SubQuests.Characters.Base
{
    abstract partial class CharacterListPanel<TChapterData, TPanel>
    {
        private List characterList;

        private void InitializeComponent()
        {
            characterList = new List
            {
                ItemSpacing = 5
            };

            UpdateCharacterList();
        }

        protected void UpdateCharacterList()
        {
            characterList.Items.Clear();

            var chapters = GetCharacters();
            foreach (var chapter in chapters)
            {
                var charButton = new NierButton
                {
                    Width = 1f,
                    Caption = CalculatorCharacter.CharacterName(GetCharacterId(chapter), true),
                    Enabled = !IsChapterLocked(chapter)
                };
                charButton.Clicked += (s, e) =>
                {
                    var panel = CreateCharacterPanel(chapter, chapters);
                    panel.Closed += Panel_Closed;

                    Content = panel;
                };

                characterList.Items.Add(charButton);
            }

            Content = characterList;
        }

        private void Panel_Closed(object sender, System.EventArgs e)
        {
            UpdateCharacterList();
        }
    }
}
