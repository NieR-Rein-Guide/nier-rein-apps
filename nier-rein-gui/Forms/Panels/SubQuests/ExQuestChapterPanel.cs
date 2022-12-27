using System;
using System.Collections.Generic;
using ImGui.Forms.Controls;
using nier_rein_gui.Forms.Panels.SubQuests.Base;
using nier_rein_gui.Forms.Panels.SubQuests.Characters;
using NierReincarnation;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface;
using NierReincarnation.Core.Dark.View.UserInterface.Text;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;

namespace nier_rein_gui.Forms.Panels.SubQuests
{
    class ExQuestChapterPanel : ChapterPanel<EventQuestChapterData>
    {
        private Panel subMenu;

        public ExQuestChapterPanel(NierReinContexts rein) : base(rein, GetEventChapters())
        {
        }

        private static IList<EventQuestChapterData> GetEventChapters()
        {
            var chapters = new List<EventQuestChapterData>
            {
                new EventQuestChapterData
                {
                    EventQuestType = EventQuestType.END_CONTENTS,
                    EndDatetime = CalculatorDateTime.UnixTimeNow() + 1000,
                    EventQuestName = UserInterfaceTextKey.Quest.kEventQuestEndContents.Localize()
                },
                new EventQuestChapterData
                {
                    EventQuestType = EventQuestType.LIMIT_CONTENT,
                    EndDatetime = CalculatorDateTime.UnixTimeNow() + 1000,
                    EventQuestName = UserInterfaceTextKey.Quest.kEventLimitContent.Localize()
                }
            };

            return chapters;
        }

        protected override string GetChapterName(EventQuestChapterData chapter)
        {
            return chapter.EventQuestName;
        }

        protected override bool IsUnlocked(EventQuestChapterData chapter)
        {
            return chapter.EventQuestType != EventQuestType.DUNGEON;
        }

        protected override Panel GetQuestListPanel(NierReinContexts rein, EventQuestChapterData chapter)
        {
            switch (chapter.EventQuestType)
            {
                case EventQuestType.END_CONTENTS:
                    if (subMenu is EndQuestPanel)
                        return subMenu;

                    return subMenu = new EndQuestPanel(rein);

                case EventQuestType.LIMIT_CONTENT:
                    if (subMenu is LimitQuestPanel)
                        return subMenu;

                    return subMenu = new LimitQuestPanel(rein);

                default:
                    throw new InvalidOperationException($"Unsupported quest type {chapter.EventQuestType}.");
            }
        }
    }
}
