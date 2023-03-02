using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_big_hunt_max_score")]
    public class EntityIUserBigHuntMaxScore
    {
        [Key(0)] // RVA: 0x1DE7A9C Offset: 0x1DE7A9C VA: 0x1DE7A9C
        public long UserId { get; set; }
        [Key(1)] // RVA: 0x1DE7ADC Offset: 0x1DE7ADC VA: 0x1DE7ADC
        public int BigHuntBossId { get; set; }
        [Key(2)] // RVA: 0x1DE7B1C Offset: 0x1DE7B1C VA: 0x1DE7B1C
        public long MaxScore { get; set; }
        [Key(3)] // RVA: 0x1DE7B30 Offset: 0x1DE7B30 VA: 0x1DE7B30
        public long MaxScoreUpdateDatetime { get; set; }
        [Key(4)] // RVA: 0x1DE7B44 Offset: 0x1DE7B44 VA: 0x1DE7B44
        public long LatestVersion { get; set; }
	}
}
