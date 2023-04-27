using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_mission_pass_mission_group")]
    public class EntityMMissionPassMissionGroup
    {
        [Key(0)]
        public int MissionPassId { get; set; } // 0x10

        [Key(1)]
        public int MissionGroupId { get; set; } // 0x14
    }
}
