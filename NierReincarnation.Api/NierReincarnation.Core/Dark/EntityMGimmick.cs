using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_gimmick")]
    public class EntityMGimmick
    {
        [Key(0)]
        public int GimmickId { get; set; } // 0x10
        [Key(1)]
        public GimmickType GimmickType { get; set; } // 0x14
        [Key(2)]
        public int GimmickOrnamentGroupId { get; set; } // 0x18
        [Key(3)]
        public int ClearEvaluateConditionId { get; set; } // 0x1C
        [Key(4)]
        public int ReleaseEvaluateConditionId { get; set; } // 0x20
    }
}