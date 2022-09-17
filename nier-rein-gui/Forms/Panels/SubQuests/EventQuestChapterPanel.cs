using System;
using System.Collections.Generic;
using System.Linq;
using ImGui.Forms.Controls;
using nier_rein_gui.Forms.Panels.SubQuests.Base;
using nier_rein_gui.Forms.Panels.SubQuests.Characters;
using nier_rein_gui.Forms.Panels.SubQuests.Quests;
using nier_rein_gui.Forms.Panels.SubQuests.Quests.Base;
using NierReincarnation;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface;
using NierReincarnation.Core.Dark.View.UserInterface.Text;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;

namespace nier_rein_gui.Forms.Panels.SubQuests
{
    class EventQuestChapterPanel : ChapterPanel<EventQuestChapterData>
    {
        private Panel subMenu;

        public EventQuestChapterPanel(NierReinContexts rein) : base(rein,GetEventChapters())
        {
        }

        private static IList<EventQuestChapterData> GetEventChapters()
        {
            var chapters = CalculatorQuest.GetEventQuestChapters(EventQuestType.MARATHON, EventQuestType.HUNT, EventQuestType.SPECIAL, EventQuestType.TOWER, EventQuestType.DUNGEON);
            chapters.Add(new EventQuestChapterData { EventQuestType = EventQuestType.DAY_OF_THE_WEEK, EndDatetime = CalculatorDateTime.UnixTimeNow()+1000, EventQuestName = UserInterfaceTextKey.Quest.kEventQuestDayOfTheWeek.Localize() });
            chapters.Add(new EventQuestChapterData { EventQuestType = EventQuestType.GUERRILLA, EndDatetime = CalculatorDateTime.UnixTimeNow() + 1000, EventQuestName = UserInterfaceTextKey.Quest.kEventQuestGuerrilla.Localize() });
            chapters.Add(new EventQuestChapterData { EventQuestType = EventQuestType.CHARACTER, EndDatetime = CalculatorDateTime.UnixTimeNow() + 1000, EventQuestName = UserInterfaceTextKey.Quest.kEventQuestCharacter.Localize() });
            chapters.Add(new EventQuestChapterData { EventQuestType = EventQuestType.END_CONTENTS, EndDatetime = CalculatorDateTime.UnixTimeNow() + 1000, EventQuestName = UserInterfaceTextKey.Quest.kEventQuestEndContents.Localize() });
            chapters.Add(new EventQuestChapterData { EventQuestType = EventQuestType.LIMIT_CONTENT, EndDatetime = CalculatorDateTime.UnixTimeNow() + 1000, EventQuestName = UserInterfaceTextKey.Quest.kEventLimitContent.Localize() });

            var chapterLookup = chapters.GroupBy(x => x.EventQuestType).ToDictionary(x => x.Key, y => y.ToArray());

            var typeOrder = new[]
            {
                EventQuestType.MARATHON, EventQuestType.HUNT, EventQuestType.SPECIAL, EventQuestType.TOWER,
                EventQuestType.DAY_OF_THE_WEEK, EventQuestType.GUERRILLA,
                EventQuestType.DUNGEON,
                EventQuestType.CHARACTER,
                EventQuestType.END_CONTENTS,
                EventQuestType.LIMIT_CONTENT
            };

            var result = new List<EventQuestChapterData>();
            foreach (var type in typeOrder)
            {
                if(!chapterLookup.ContainsKey(type))
                    continue;

                result.AddRange(chapterLookup[type].Where(x => x.IsCurrent()).OrderByDescending(x => x.StartDatetime));
            }

            return result;
        }

        protected override string GetChapterName(EventQuestChapterData chapter)
        {
            return chapter.EventQuestName;
        }

        protected override bool IsUnlocked(EventQuestChapterData chapter)
        {
            return chapter.EventQuestType != EventQuestType.DUNGEON;
        }

        protected override Panel GetQuestListPanel(NierReinContexts rein,EventQuestChapterData chapter)
        {
            switch (chapter.EventQuestType)
            {
                case EventQuestType.DAY_OF_THE_WEEK:
                    if (subMenu is DailyQuestListPanel)
                        return subMenu;

                    return subMenu = new DailyQuestListPanel(rein);

                case EventQuestType.GUERRILLA:
                    if (subMenu is GuerrillaQuestPanel)
                        return subMenu;

                    return subMenu = new GuerrillaQuestPanel(rein);

                case EventQuestType.CHARACTER:
                    if (subMenu is CharacterQuestPanel)
                        return subMenu;

                    return subMenu = new CharacterQuestPanel(rein);

                case EventQuestType.END_CONTENTS:
                    if (subMenu is EndQuestPanel)
                        return subMenu;

                    return subMenu = new EndQuestPanel(rein);

                case EventQuestType.LIMIT_CONTENT:
                    if (subMenu is LimitQuestPanel)
                        return subMenu;

                    return subMenu = new LimitQuestPanel(rein);

                default:
                    if (subMenu is EventQuestListPanel panel && panel.ChapterId == chapter.EventQuestChapterId)
                        return subMenu;

                    return subMenu = new EventQuestListPanel(rein, chapter);
            }
        }
    }
}
