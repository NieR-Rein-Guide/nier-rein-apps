using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_buff")]
    public class EntityMSkillBuff
    {
        [Key(0)]
        public int SkillBuffId { get; set; } // 0x10
        [Key(1)]
        public string BuffKey { get; set; } // 0x18
        [Key(2)]
        public int BuffType { get; set; } // 0x20
        [Key(3)]
        public int Power { get; set; } // 0x24
        [Key(4)]
        public int CooltimeFrameCount { get; set; } // 0x28
        [Key(5)]
        public int IconId { get; set; } // 0x2C
    }
}