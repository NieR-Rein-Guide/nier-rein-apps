namespace NierReincarnation.Core.Dark.Game.TurnBattle
{
    public class TeamHash
    {
        public static readonly TeamHash InvalidHash = new TeamHash(0); // 0x0
        public static readonly TeamHash OwnTeamHash = new TeamHash(1); // 0x8
        public static readonly TeamHash IntercessionTeamHash = new TeamHash(2); // 0x10

        public int Hash { get; }

        public TeamHash(int hashValue)
        {
            Hash = hashValue;
        }
    }
}
