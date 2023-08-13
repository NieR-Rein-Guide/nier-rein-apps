using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Controls.Lists;
using NierReincarnation.App.Controls.Buttons;

namespace NierReincarnation.App.Forms.Panels.SubQuests.Characters.Base
{
    internal abstract partial class ButtonListPanel<TChapterData, TPanel>
    {
        private StackLayout mainLayout;
        private List characterList;

        private void InitializeComponent()
        {
            characterList = new List
            {
                ItemSpacing = 5
            };

            UpdateCharacterList();
            UpdateLayout(mainLayout);
        }

        protected virtual void UpdateLayout(StackLayout layout)
        { }

        private void UpdateCharacterList()
        {
            characterList.Items.Clear();

            var chapters = GetDataElements();
            foreach (var chapter in chapters)
            {
                var charButton = new NierButton
                {
                    Width = 1f,
                    Text = GetText(chapter),
                    Enabled = IsButtonEnabled(chapter)
                };
                charButton.Clicked += (s, e) =>
                {
                    var panel = CreatePanel(chapter, chapters);
                    panel.Closed += Panel_Closed;

                    Content = panel;
                };

                characterList.Items.Add(charButton);
            }

            Content = mainLayout = new StackLayout
            {
                Alignment = Alignment.Vertical,
                ItemSpacing = 5,
                Items =
                {
                    characterList
                }
            };
        }

        private void Panel_Closed(object sender, System.EventArgs e)
        {
            UpdateCharacterList();
            UpdateLayout(mainLayout);
        }
    }
}
