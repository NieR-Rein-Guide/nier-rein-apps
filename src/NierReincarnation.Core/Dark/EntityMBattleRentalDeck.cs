using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_battle_rental_deck")]
public class EntityMBattleRentalDeck
{
    [Key(0)]
    public int BattleGroupId { get; set; }

    [Key(1)]
    public long BattleNpcId { get; set; }

    [Key(2)]
    public DeckType DeckType { get; set; }

    [Key(3)]
    public int BattleNpcDeckNumber { get; set; }
}
