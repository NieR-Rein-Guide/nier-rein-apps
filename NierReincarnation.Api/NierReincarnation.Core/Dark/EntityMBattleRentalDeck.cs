using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
	[MessagePackObject]
	[MemoryTable("m_battle_rental_deck")]
    public class EntityMBattleRentalDeck
    {
	    [Key(0)] // RVA: 0x1DD5FE4 Offset: 0x1DD5FE4 VA: 0x1DD5FE4
	    public int BattleGroupId { get; set; } // 0x10
	    [Key(1)] // RVA: 0x1DD6024 Offset: 0x1DD6024 VA: 0x1DD6024
	    public long BattleNpcId { get; set; } // 0x18
	    [Key(2)] // RVA: 0x1DD6038 Offset: 0x1DD6038 VA: 0x1DD6038
	    public DeckType DeckType { get; set; } // 0x20
	    [Key(3)] // RVA: 0x1DD604C Offset: 0x1DD604C VA: 0x1DD604C
	    public int BattleNpcDeckNumber { get; set; } // 0x24
	}
}
