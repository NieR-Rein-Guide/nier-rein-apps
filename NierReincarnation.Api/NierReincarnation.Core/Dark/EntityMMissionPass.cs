using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_mission_pass")]
    public class EntityMMissionPass
    {
        [Key(0)]
        public int MissionPassId { get; set; } // 0x10

        [Key(1)]
        public long StartDatetime { get; set; } // 0x18

        [Key(2)]
        public long EndDatetime { get; set; } // 0x20

        [Key(3)]
        public int PremiumItemId { get; set; } // 0x28

        [Key(4)]
        public int MissionPassLevelGroupId { get; set; } // 0x2C

        [Key(5)]
        public int MissionPassRewardGroupId { get; set; } // 0x30
    }
}
