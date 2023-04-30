using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle")]
    public class EntityMBattle
    {
        [Key(0)] // RVA: 0x1DD6BF8 Offset: 0x1DD6BF8 VA: 0x1DD6BF8
        public int BattleId { get; set; } // 0x10

        [Key(1)] // RVA: 0x1DD6C38 Offset: 0x1DD6C38 VA: 0x1DD6C38
        public long BattleNpcId { get; set; } // 0x18

        [Key(2)] // RVA: 0x1DD6C4C Offset: 0x1DD6C4C VA: 0x1DD6C4C
        public DeckType DeckType { get; set; } // 0x20

        [Key(3)] // RVA: 0x1DD6C60 Offset: 0x1DD6C60 VA: 0x1DD6C60
        public int BattleNpcDeckNumber { get; set; } // 0x24
    }
}
