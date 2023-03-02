namespace NierReincarnation.Datamine.Model;

public class Debris
{
    public string Name { get; init; }

    public string Description { get; init; }

    public DebrisSourceType SourceType { get; set; }

    public string UnlockCondition { get; set; }
}
