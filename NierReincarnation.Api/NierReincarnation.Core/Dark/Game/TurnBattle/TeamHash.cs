namespace NierReincarnation.Core.Dark.Game.TurnBattle
{
    public class TeamHash
    {
        public static readonly TeamHash InvalidHash = new TeamHash(0);
        public static readonly TeamHash OwnTeamHash = new TeamHash(1);
        public static readonly TeamHash IntercessionTeamHash = new TeamHash(2);

        public int Hash { get; }

        public TeamHash(int hashValue)
        {
            Hash = hashValue;
        }
    }
}
