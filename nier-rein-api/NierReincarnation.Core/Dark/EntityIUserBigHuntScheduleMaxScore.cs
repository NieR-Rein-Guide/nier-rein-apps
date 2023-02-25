using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_big_hunt_schedule_max_score")]
    public class EntityIUserBigHuntScheduleMaxScore
    {
        [Key(0)] // RVA: 0x226D264 Offset: 0x226D264 VA: 0x226D264
        public long UserId { get; set; }
        [Key(1)] // RVA: 0x226D2A4 Offset: 0x226D2A4 VA: 0x226D2A4
        public int BigHuntScheduleId { get; set; }
        [Key(2)] // RVA: 0x226D2E4 Offset: 0x226D2E4 VA: 0x226D2E4
        public int BigHuntBossId { get; set; }
        [Key(3)] // RVA: 0x226D324 Offset: 0x226D324 VA: 0x226D324
        public long MaxScore { get; set; } // 0x20
        [Key(4)] // RVA: 0x226D338 Offset: 0x226D338 VA: 0x226D338
        public long MaxScoreUpdateDatetime { get; set; }
        [Key(5)] // RVA: 0x226D34C Offset: 0x226D34C VA: 0x226D34C
        public long LatestVersion { get; set; }
    }
}
