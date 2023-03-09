using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_big_hunt_weekly_max_score")]
    public class EntityIUserBigHuntWeeklyMaxScore
    {
        [Key(0)] // RVA: 0x226D41C Offset: 0x226D41C VA: 0x226D41C
        public long UserId { get; set; }
        [Key(1)] // RVA: 0x226D45C Offset: 0x226D45C VA: 0x226D45C
        public long BigHuntWeeklyVersion { get; set; }
        [Key(2)] // RVA: 0x226D49C Offset: 0x226D49C VA: 0x226D49C
        public int AttributeType { get; set; }
        [Key(3)] // RVA: 0x226D4DC Offset: 0x226D4DC VA: 0x226D4DC
        public long MaxScore { get; set; }
        [Key(4)] // RVA: 0x226D4F0 Offset: 0x226D4F0 VA: 0x226D4F0
        public long LatestVersion { get; set; }
    }
}
