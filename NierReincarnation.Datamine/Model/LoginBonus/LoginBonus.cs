namespace NierReincarnation.Datamine.Model;

public class LoginBonus
{
    public string Name { get; init; }

    public DateTimeOffset StartDateTimeOffset { get; init; }

    public DateTimeOffset EndDateTimeOffset { get; init; }

    public List<Reward> Rewards { get; init; }

    public bool CanGroupRewards => Rewards?.All(x => x.Name == Rewards[0].Name) == true;
}
