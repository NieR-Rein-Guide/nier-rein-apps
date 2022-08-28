using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_headup_display_view")]
    public class EntityMHeadupDisplayView
    {
        [Key(0)]
        public int HeadupDisplayViewId { get; set; } // 0x10
        [Key(1)]
        public int ViewSkillButtonType { get; set; } // 0x14
        [Key(2)]
        public int HpBarDisplayType { get; set; } // 0x18
        [Key(3)]
        public int ViewNameTextType { get; set; } // 0x1C
        [Key(4)]
        public int ViewBuffAbnormalType { get; set; } // 0x20
        [Key(5)]
        public int ViewLevelTextType { get; set; } // 0x24
    }
}