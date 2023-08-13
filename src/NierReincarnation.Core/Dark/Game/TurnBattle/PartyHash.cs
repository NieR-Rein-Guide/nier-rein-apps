namespace NierReincarnation.Core.Dark.Game.TurnBattle;

[MessagePackObject]
public class PartyHash
{
    [Key(0)]
    public int Hash { get; set; }

    public PartyHash()
    { }

    public PartyHash(TeamHash teamHash, int waveNumber)
    {
        Hash = waveNumber + (teamHash.Hash * 4) - 3;
    }
}
