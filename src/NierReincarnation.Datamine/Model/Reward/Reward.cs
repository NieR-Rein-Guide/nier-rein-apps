namespace NierReincarnation.Datamine.Model;

public class Reward
{
    public string Name { get; init; }

    public int Count { get; init; }

    public override bool Equals(object obj) => Name == ((Reward)obj).Name && Count == ((Reward)obj).Count;

    public override int GetHashCode() => base.GetHashCode();

    public override string ToString() => $"{Name} x{Count}";
}
