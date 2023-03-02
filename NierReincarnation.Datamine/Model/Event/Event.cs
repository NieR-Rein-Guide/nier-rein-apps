using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Datamine.Model;

public class Event
{
    public string Name { get; init; }

    public EventQuestType EventType { get; init; }

    public DateTimeOffset StartDateTimeOffset { get; init; }

    public DateTimeOffset EndDateTimeOffset { get; init; }

    public List<EventDifficulty> Difficulties { get; init; }

    public bool HasMultiDifficulties => Difficulties?.Count > 1;
}
