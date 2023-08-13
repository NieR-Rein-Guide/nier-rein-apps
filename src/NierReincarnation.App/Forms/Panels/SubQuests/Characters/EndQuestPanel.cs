using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Modals;
using ImGui.Forms.Models;
using NierReincarnation.App.Controls.Buttons;
using NierReincarnation.App.Dialogs.FarmDialogs;
using NierReincarnation.App.Forms.Panels.SubQuests.Characters.Base;
using NierReincarnation.App.Forms.Panels.SubQuests.Quests.Base;
using NierReincarnation.App.Resources;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.View.UserInterface;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using System.Collections.Generic;

namespace NierReincarnation.App.Forms.Panels.SubQuests.Characters
{
    internal class EndQuestPanel : ButtonListPanel<CharacterQuestChapterData, ClosableQuestListPanel<EventQuestData>>
    {
        private readonly NierReinContexts _rein;

        public EndQuestPanel(NierReinContexts rein)
        {
            _rein = rein;
        }

        protected override IList<CharacterQuestChapterData> GetDataElements()
        {
            return CalculatorQuest.GetEndQuestChapters();
        }

        protected override string GetText(CharacterQuestChapterData chapter)
        {
            return CalculatorCharacter.CharacterName(chapter.CharacterId, true);
        }

        protected override bool IsButtonEnabled(CharacterQuestChapterData chapter)
        {
            return !chapter.IsLock;
        }

        protected override ClosableQuestListPanel<EventQuestData> CreatePanel(CharacterQuestChapterData chapter, IList<CharacterQuestChapterData> chapters)
        {
            return new CharacterQuestListPanel(_rein, chapter, chapters, true);
        }

        protected override void UpdateLayout(StackLayout layout)
        {
            NierButton clearAllButton = new()
            {
                Text = LocalizationResources.ClearAllDailies,
                Enabled = ClearAllEndDailyDialog.HasDailyQuests()
            };
            clearAllButton.Clicked += ClearAllButton_Clicked;

            layout.Items.Insert(0, new StackItem(clearAllButton) { Size = Size.WidthAlign, HorizontalAlignment = HorizontalAlignment.Right });
        }

        private async void ClearAllButton_Clicked(object sender, System.EventArgs e)
        {
            ((NierButton)sender).Enabled = false;

            var res = await new ClearAllEndDailyDialog(_rein).ShowAsync();

            if (res != DialogResult.Ok)
            {
                ((NierButton)sender).Enabled = true;
            }
        }
    }
}
