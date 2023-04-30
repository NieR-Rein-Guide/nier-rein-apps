using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_big_hunt_schedule")]
    public class EntityMBigHuntSchedule
    {
        [Key(0)]
        public int BigHuntScheduleId { get; set; } // 0x10

        [Key(1)]
        public long NoticeStartDatetime { get; set; } // 0x18

        [Key(2)]
        public long ChallengeStartDatetime { get; set; } // 0x20

        [Key(3)]
        public long ChallengeEndDatetime { get; set; } // 0x28

        [Key(4)]
        public int SeasonAssetId { get; set; } // 0x30
    }
}
