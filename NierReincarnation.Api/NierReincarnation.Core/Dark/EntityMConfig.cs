using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    // Dark.EntityMConfig
    [MessagePackObject]
    [MemoryTable("m_config")]
    public class EntityMConfig
    {
        [Key(0)]
        public string ConfigKey { get; set; } // 0x10

        [Key(1)]
        public string Value { get; set; } // 0x18
    }
}
