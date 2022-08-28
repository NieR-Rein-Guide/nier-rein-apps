using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_gimmick_group_event_log")]
    public class EntityMGimmickGroupEventLog
    {
        [Key(0)]
        public int GimmickGroupId { get; set; } // 0x10
        [Key(1)]
        public int EventLogTextId { get; set; } // 0x14
        [Key(2)]
        public int SortOrder { get; set; } // 0x18
    }
}