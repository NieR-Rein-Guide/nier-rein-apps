namespace NierReincarnation.Datamine.Model;

public class MissionGroup
{
    public string Name { get; init; }

    public DateTimeOffset StartDateTimeOffset { get; init; }

    public DateTimeOffset EndDateTimeOffset { get; init; }

    public List<Mission> Missions { get; init; }
}
