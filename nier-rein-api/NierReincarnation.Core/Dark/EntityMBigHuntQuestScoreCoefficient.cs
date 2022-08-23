using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_big_hunt_quest_score_coefficient")]
    public class EntityMBigHuntQuestScoreCoefficient
    {
        [Key(0)] // RVA: 0x1DD6618 Offset: 0x1DD6618 VA: 0x1DD6618
        public int BigHuntQuestScoreCoefficientId { get; set; } // 0x10
        [Key(1)] // RVA: 0x1DD6658 Offset: 0x1DD6658 VA: 0x1DD6658
        public int ScoreDifficultBonusPermil { get; set; } // 0x14
    }
}
