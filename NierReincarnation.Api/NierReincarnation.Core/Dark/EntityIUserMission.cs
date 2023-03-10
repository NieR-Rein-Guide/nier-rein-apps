using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_mission")]
    public class EntityIUserMission
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10
        [Key(1)]
        public int MissionId { get; set; } // 0x18
        [Key(2)]
        public long StartDatetime { get; set; } // 0x20
        [Key(3)]
        public int ProgressValue { get; set; } // 0x28
        [Key(4)]
        public int MissionProgressStatusType { get; set; } // 0x2C
        [Key(5)]
        public long ClearDatetime { get; set; } // 0x30
        [Key(6)]
        public long LatestVersion { get; set; } // 0x38
    }
}