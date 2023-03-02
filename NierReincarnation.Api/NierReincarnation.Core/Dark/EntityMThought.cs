using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_thought")]
    public class EntityMThought
    {
        [Key(0)] // RVA: 0x1EA8C58 Offset: 0x1EA8C58 VA: 0x1EA8C58
        public int ThoughtId { get; set; } // 0x10
        [Key(1)] // RVA: 0x1EA8C98 Offset: 0x1EA8C98 VA: 0x1EA8C98
        public RarityType RarityType { get; set; } // 0x14
        [Key(2)] // RVA: 0x1EA8CAC Offset: 0x1EA8CAC VA: 0x1EA8CAC
        public int AbilityId { get; set; } // 0x18
        [Key(3)] // RVA: 0x1EA8CC0 Offset: 0x1EA8CC0 VA: 0x1EA8CC0
        public int AbilityLevel { get; set; } // 0x1C
        [Key(4)] // RVA: 0x1EA8CD4 Offset: 0x1EA8CD4 VA: 0x1EA8CD4
        public int ThoughtAssetId { get; set; } // 0x20
	}
}
