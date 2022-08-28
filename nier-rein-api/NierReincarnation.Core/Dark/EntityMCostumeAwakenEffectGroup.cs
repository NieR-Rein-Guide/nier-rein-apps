using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_costume_awaken_effect_group")]
    public class EntityMCostumeAwakenEffectGroup
    {
        [Key(0)]
        public int CostumeAwakenEffectGroupId { get; set; } // 0x10
        [Key(1)]
        public int AwakenStep { get; set; } // 0x14
        [Key(2)]
        public int CostumeAwakenEffectType { get; set; } // 0x18
        [Key(3)]
        public int CostumeAwakenEffectId { get; set; } // 0x1C
    }
}