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
        public int HeadupDisplayViewId { get; set; }

        [Key(1)]
        public ViewSkillButtonType ViewSkillButtonType { get; set; }

        [Key(2)]
        public HpBarDisplayType HpBarDisplayType { get; set; }

        [Key(3)]
        public ViewNameTextType ViewNameTextType { get; set; }

        [Key(4)]
        public ViewBuffAbnormalType ViewBuffAbnormalType { get; set; }

        [Key(5)]
        public ViewLevelTextType ViewLevelTextType { get; set; }
    }
}
