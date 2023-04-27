using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_mission_pass_level_group")]
    public class EntityMMissionPassLevelGroup
    {
        [Key(0)]
        public int MissionPassLevelGroupId { get; set; } // 0x10

        [Key(1)]
        public int Level { get; set; } // 0x14

        [Key(2)]
        public int NecessaryPoint { get; set; } // 0x18
    }
}
