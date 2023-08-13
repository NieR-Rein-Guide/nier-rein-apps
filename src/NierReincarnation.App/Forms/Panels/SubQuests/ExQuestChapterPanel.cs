using ImGui.Forms.Controls;
using NierReincarnation.App.Forms.Panels.SubQuests.Base;
using NierReincarnation.App.Forms.Panels.SubQuests.Characters;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface;
using NierReincarnation.Core.Dark.View.UserInterface.Text;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using System;
using System.Collections.Generic;

namespace NierReincarnation.App.Forms.Panels.SubQuests
{
    internal class ExQuestChapterPanel : ChapterPanel<EventQuestChapterData>
    {
        private Panel subMenu;

        public ExQuestChapterPanel(NierReinContexts rein) : base(rein, GetEventChapters())
        {
        }

        private static IList<EventQuestChapterData> GetEventChapters()
        {
            return new List<EventQuestChapterData>
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
