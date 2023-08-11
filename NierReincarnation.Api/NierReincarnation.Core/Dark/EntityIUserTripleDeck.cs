using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("i_user_triple_deck")]
public class EntityIUserTripleDeck
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public DeckType DeckType { get; set; }

    [Key(2)]
    public int UserDeckNumber { get; set; }

    [Key(3)]
    public string Name { get; set; }

    [Key(4)]
    public int DeckNumber01 { get; set; }

    [Key(5)]
    public int DeckNumber02 { get; set; }

    [Key(6)]
    public int DeckNumber03 { get; set; }

    [Key(7)]
    public long LatestVersion { get; set; }
}
