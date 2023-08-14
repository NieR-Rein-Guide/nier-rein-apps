namespace NierReincarnation.Datamine.Model;

public class Mission
{
    public string Name { get; init; }

    public DateTimeOffset StartDateTimeOffset { get; init; }

    public DateTimeOffset EndDateTimeOffset { get; init; }

    public Reward Reward { get; init; }
}
