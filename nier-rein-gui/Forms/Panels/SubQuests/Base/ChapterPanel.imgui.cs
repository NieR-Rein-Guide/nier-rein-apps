using System.Collections.Generic;
using System.Numerics;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Controls.Lists;
using ImGui.Forms.Models;
using nier_rein_gui.Controls.Buttons;
using NierReincarnation;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.View.UserInterface;

namespace nier_rein_gui.Forms.Panels.SubQuests.Base
{
    abstract partial class ChapterPanel<TChapterData>
    {
        private StackLayout chapterLayout;
        private List chapterList;

        protected TChapterData CurrentChapter { get; set; }

        private void InitializeComponent()
        {
            chapterList = new List { ItemSpacing = 5 };

            Content = chapterLayout = new StackLayout
            {
                Alignment = Alignment.Horizontal,
                ItemSpacing = 5,
                Items =
                {
                    new StackItem(chapterList) {Size = new Size(.35f, 1f)}
                }
            };
        }

        private void UpdateChapterList(IList<TChapterData> chapters)
        {
            CurrentChapter = _chapters[0];

            // Clear list
            chapterList.Items.Clear();

            // Add chapters
            foreach (var chapter in chapters)
                chapterList.Items.Add(CreateChapterButton(chapter));
        }

        private void UpdateQuestList(NierReinContexts rein, TChapterData chapter)
        {
            var questList = GetQuestListPanel(rein, chapter);

            var items = chapterLayout.Items;
            var item = new StackItem(questList) { Size = new Size(.65f, 1f) };

            if (items.Count < 2)
                items.Add(item);
            else
                items[1] = item;
        }

        private NierButton CreateChapterButton(TChapterData chapter)
        {
            var result = new NierButton
            {
                Caption = GetChapterName(chapter),
                Active = CurrentChapter.Equals(chapter),
                Enabled = IsUnlocked(chapter),
                IsClickActive = true,
                Width = 1f,
                Padding = new Vector2(0, 2)
            };
            result.Clicked += (s, e) => ChapterBtn_Clicked((NierButton)s, chapter);

            return result;
        }

        private void ChapterBtn_Clicked(NierButton sender, TChapterData chapter)
        {
            foreach (var chapterBtn in chapterList.Items)
                (chapterBtn as NierButton).Active = chapterBtn == sender;

            CurrentChapter = chapter;
            UpdateQuestList(_rein, chapter);
        }
    }
}
