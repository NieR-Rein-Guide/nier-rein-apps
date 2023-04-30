using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_gimmick_group")]
    public class EntityMGimmickGroup
    {
        [Key(0)]
        public int GimmickGroupId { get; set; } // 0x10

        [Key(1)]
        public int GroupIndex { get; set; } // 0x14

        [Key(2)]
        public int GimmickId { get; set; } // 0x18
    }
}
