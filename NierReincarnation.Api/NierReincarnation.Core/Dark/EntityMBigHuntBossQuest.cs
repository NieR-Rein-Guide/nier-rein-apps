using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_big_hunt_boss_quest")]
    public class EntityMBigHuntBossQuest
    {
        [Key(0)] // RVA: 0x1DD62AC Offset: 0x1DD62AC VA: 0x1DD62AC
        public int BigHuntBossQuestId { get; set; } // 0x10

        [Key(1)] // RVA: 0x1DD62EC Offset: 0x1DD62EC VA: 0x1DD62EC
        public int BigHuntBossId { get; set; } // 0x14

        [Key(2)] // RVA: 0x1DD6300 Offset: 0x1DD6300 VA: 0x1DD6300
        public int BigHuntQuestGroupId { get; set; } // 0x18

        [Key(3)] // RVA: 0x1DD6314 Offset: 0x1DD6314 VA: 0x1DD6314
        public int BigHuntBossQuestScoreCoefficientId { get; set; } // 0x1C

        [Key(4)] // RVA: 0x1DD6328 Offset: 0x1DD6328 VA: 0x1DD6328
        public int BigHuntScoreRewardGroupScheduleId { get; set; } // 0x20

        [Key(5)] // RVA: 0x1DD633C Offset: 0x1DD633C VA: 0x1DD633C
        public int BigHuntLinkId { get; set; } // 0x24

        [Key(6)] // RVA: 0x1DD6350 Offset: 0x1DD6350 VA: 0x1DD6350
        public int DailyChallengeCount { get; set; } // 0x28
    }
}
