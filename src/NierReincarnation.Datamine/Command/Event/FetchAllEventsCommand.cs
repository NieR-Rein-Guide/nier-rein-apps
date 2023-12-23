using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Text;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using NierReincarnation.Datamine.Model;

namespace NierReincarnation.Datamine.Command;

public class FetchAllEventsCommand : AbstractDbQueryCommand<FetchAllEventsCommandArg, List<Event>>
{
    public override async Task<List<Event>> ExecuteAsync(FetchAllEventsCommandArg arg)
    {
        List<Event> events = [];

        foreach (var darkEventChapter in MasterDb.EntityMEventQuestChapterTable.All.OrderBy(x => x.StartDatetime))
        {
            if (darkEventChapter.EventQuestType == EventQuestType.LABYRINTH) continue;
            if (arg.FromDate > CalculatorDateTime.FromUnixTime(darkEventChapter.StartDatetime)) continue;
            if (arg.ToDate < CalculatorDateTime.FromUnixTime(darkEventChapter.StartDatetime)) continue;

            Dictionary<DifficultyType, List<EventQuest>> eventQuestsByDifficulty = [];

            if (arg.IncludeQuests)
            {
                var darkDifficultyTypes = MasterDb.EntityMEventQuestSequenceGroupTable.All
                    .Where(x => x.EventQuestSequenceGroupId == darkEventChapter.EventQuestSequenceGroupId)
                    .Select(x => x.DifficultyType)
                    .ToList();

                foreach (var darkDifficulty in darkDifficultyTypes)
                {
                    var eventQuests = await new FetchEventQuestsCommand().ExecuteAsync(new FetchEventQuestsCommandArg
                    {
                        EventQuestChapterId = darkEventChapter.EventQuestChapterId,
                        DifficultyType = darkDifficulty
                    });

                    if (!arg.IncludeEmptyEvents && eventQuests.Count == 0) continue;

                    eventQuestsByDifficulty.Add(darkDifficulty, eventQuests);
                }
            }

            if (!arg.IncludeEmptyEvents && eventQuestsByDifficulty.Count == 0) continue;

            events.Add(new Event
            {
                Name = GetEventQuestChapterName(darkEventChapter.NameEventQuestTextId, darkEventChapter.EventQuestType)?.Replace("\\n", " "),
                EventType = darkEventChapter.EventQuestType,
                StartDateTimeOffset = CalculatorDateTime.FromUnixTime(darkEventChapter.StartDatetime),
                EndDateTimeOffset = CalculatorDateTime.FromUnixTime(darkEventChapter.EndDatetime),
                Difficulties = eventQuestsByDifficulty.Select(x => new EventDifficulty
                {
                    DifficultyType = x.Key,
                    Quests = x.Value
                }).ToList()
            });
        }

        return events;
    }

    private static string GetEventQuestChapterName(int nameTextId, EventQuestType eventQuestType)
    {
        return eventQuestType switch
        {
            EventQuestType.DAY_OF_THE_WEEK => UserInterfaceTextKey.Quest.kEventQuestDayOfTheWeek.Localize(),
            EventQuestType.GUERRILLA => UserInterfaceTextKey.Quest.kEventQuestGuerrilla.Localize(),
            EventQuestType.CHARACTER => UserInterfaceTextKey.Quest.kEventQuestCharacter.Localize(),
            EventQuestType.END_CONTENTS => UserInterfaceTextKey.Quest.kEventQuestEndContents.Localize(),
            _ when nameTextId != 0 => string.Format(UserInterfaceTextKey.Quest.kEventChapterTitle, nameTextId).Localize(),
            _ => string.Empty
        };
    }
}

public class FetchAllEventsCommandArg : AbstractCommandWithDatesArg
{
    public bool IncludeQuests { get; init; }

    public bool IncludeEmptyEvents { get; init; }
}
