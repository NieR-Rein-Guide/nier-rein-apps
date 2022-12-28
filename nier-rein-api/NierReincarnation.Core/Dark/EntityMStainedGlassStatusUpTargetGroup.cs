using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_stained_glass_status_up_target_group")]
    public class EntityMStainedGlassStatusUpTargetGroup
    {
        [Key(0)]
        public int StainedGlassStatusUpTargetGroupId { get; set; } // 0x10
        [Key(1)]
        public int GroupIndex { get; set; } // 0x14
        [Key(2)]
        public int StatusUpTargetType { get; set; } // 0x18
        [Key(3)]
        public int TargetValue { get; set; } // 0x1C
    }
}