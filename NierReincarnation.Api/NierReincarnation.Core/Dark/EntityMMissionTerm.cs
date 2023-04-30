using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_mission_term")]
    public class EntityMMissionTerm
    {
        [Key(0)]
        public int MissionTermId { get; set; } // 0x10

        [Key(1)]
        public long StartDatetime { get; set; } // 0x18

        [Key(2)]
        public long EndDatetime { get; set; } // 0x20
    }
}
