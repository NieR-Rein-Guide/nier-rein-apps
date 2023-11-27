using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserDeck))]
public class EntityIUserDeck
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public DeckType DeckType { get; set; }

    [Key(2)]
    public int UserDeckNumber { get; set; }

    [Key(3)]
    public string UserDeckCharacterUuid01 { get; set; }

    [Key(4)]
    public string UserDeckCharacterUuid02 { get; set; }

    [Key(5)]
    public string UserDeckCharacterUuid03 { get; set; }

    [Key(6)]
    public string Name { get; set; }

    [Key(7)]
    public int Power { get; set; }

    [Key(8)]
    public long LatestVersion { get; set; }

    public EntityIUserDeck(long UserId, DeckType DeckType, int UserDeckNumber, string UserDeckCharacterUuid01,
        string UserDeckCharacterUuid02, string UserDeckCharacterUuid03, string Name, int Power, long LatestVersion)
    {
        this.UserId = UserId;
        this.DeckType = DeckType;
        this.UserDeckNumber = UserDeckNumber;
        this.UserDeckCharacterUuid01 = UserDeckCharacterUuid01;
        this.UserDeckCharacterUuid02 = UserDeckCharacterUuid02;
        this.UserDeckCharacterUuid03 = UserDeckCharacterUuid03;
        this.Name = Name;
        this.Power = Power;
        this.LatestVersion = LatestVersion;
    }
}
