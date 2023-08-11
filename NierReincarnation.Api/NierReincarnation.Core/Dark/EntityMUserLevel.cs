using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_user_level")]
    public class EntityMUserLevel
    {
        [Key(0)]
        public int UserLevel { get; set; }

        [Key(1)]
        public int MaxStamina { get; set; }
    }
}
