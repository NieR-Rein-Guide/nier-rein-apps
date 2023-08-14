namespace NierReincarnation.Core.Dark.Game.TurnBattle;

public class TeamHash
{
    public static readonly TeamHash InvalidHash = new(0);
    public static readonly TeamHash OwnTeamHash = new(1);
    public static readonly TeamHash IntercessionTeamHash = new(2);

    public int Hash { get; }

    public TeamHash(int hashValue)
    {
        Hash = hashValue;
    }
}
