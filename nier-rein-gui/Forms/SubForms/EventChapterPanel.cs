using System;
using System.Collections.Generic;
using System.Linq;
using ImGui.Forms.Controls;
using NierReincarnation;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.View.UserInterface;

namespace nier_rein_gui.Forms.SubForms
{
    partial class EventChapterPanel : Panel
    {
        private readonly NierReinContexts _rein;

        private Panel subMenu;

        public EventChapterPanel(NierReinContexts rein)
        {
            _rein = rein;

            InitializeComponent();

            dailyButton.Clicked += DailyButton_Clicked;
            guerrillaQuestButton.Clicked += GuerrillaQuestButton_Clicked;
            characterQuestButton.Clicked += CharacterQuestButton_Clicked;
            darkMemoryButton.Clicked += DarkMemoryButton_Clicked;

            foreach (var btn in eventButtons)
                btn.Item1.Clicked += ChapterBtn_Clicked;
        }

        private IList<EventQuestChapterData> GetEventChapters()
        {
            var eventQuests = CalculatorQuest.GetEventQuestChapters(EventQuestType.MARATHON, EventQuestType.HUNT, EventQuestType.SPECIAL, EventQuestType.TOWER);
            var eventChapters = eventQuests.Where(x => x.IsCurrent()).OrderByDescending(x => x.StartDatetime).ThenByDescending(x => x.EventQuestType);

            return eventChapters.ToArray();
        }

        private IList<EventQuestChapterData> GetDungeonChapters()
        {
            return CalculatorQuest.GetEventQuestChapters(EventQuestType.DUNGEON).Where(x => x.IsCurrent()).OrderBy(x => x.StartDatetime).ToArray();
        }

        private void ChapterBtn_Clicked(object sender, EventArgs e)
        {
            var chapter = eventButtons.FirstOrDefault(x => x.Item1 == sender).Item2;
            if (chapter == null)
                return;

            ToggleButtons(sender);

            if (subMenu is EventQuestPanel panel)
            {
                if (panel.ChapterId == chapter.EventQuestChapterId)
                    return;
            }

            SetMenuContent(subMenu = new EventQuestPanel(_rein, chapter));
        }

        private void DarkMemoryButton_Clicked(object sender, EventArgs e)
        {
            if (subMenu is EndQuestPanel)
                return;

            ToggleButtons(sender);

            SetMenuContent(subMenu = new EndQuestPanel(_rein));
        }

        private void CharacterQuestButton_Clicked(object sender, EventArgs e)
        {
            if (subMenu is CharacterQuestPanel)
                return;

            ToggleButtons(sender);

            SetMenuContent(subMenu = new CharacterQuestPanel(_rein));
        }

        private void GuerrillaQuestButton_Clicked(object sender, EventArgs e)
        {
            if (subMenu is GuerrillaQuestPanel)
                return;

            ToggleButtons(sender);

            SetMenuContent(subMenu = new GuerrillaQuestPanel(_rein));
        }

        private void DailyButton_Clicked(object sender, EventArgs e)
        {
            if (subMenu is DailyQuestPanel)
                return;

            ToggleButtons(sender);

            SetMenuContent(subMenu = new DailyQuestPanel(_rein));
        }

        private void ToggleButtons(object sender)
        {
            foreach (var btn in eventButtons)
                btn.Item1.Active = btn.Item1 == sender;

            dailyButton.Active = dailyButton == sender;
            guerrillaQuestButton.Active = guerrillaQuestButton == sender;
            characterQuestButton.Active = characterQuestButton == sender;
            darkMemoryButton.Active = darkMemoryButton == sender;
        }
    }
}
