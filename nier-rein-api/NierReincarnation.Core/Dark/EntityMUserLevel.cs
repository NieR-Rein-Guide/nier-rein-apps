using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_user_level")]
    public class EntityMUserLevel
    {
        [Key(0)]
        public int UserLevel { get; set; } // 0x10
        [Key(1)]
        public int MaxStamina { get; set; } // 0x14
    }
}