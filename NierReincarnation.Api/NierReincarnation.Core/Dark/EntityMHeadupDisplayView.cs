using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
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
        public ViewSkillButtonType ViewSkillButtonType { get; set; } // 0x14

        [Key(2)]
        public HpBarDisplayType HpBarDisplayType { get; set; } // 0x18

        [Key(3)]
        public ViewNameTextType ViewNameTextType { get; set; } // 0x1C

        [Key(4)]
        public ViewBuffAbnormalType ViewBuffAbnormalType { get; set; } // 0x20

        [Key(5)]
        public ViewLevelTextType ViewLevelTextType { get; set; } // 0x24
    }
}
