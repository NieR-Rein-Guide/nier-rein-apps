using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_big_hunt_quest_score_coefficient")]
public class EntityMBigHuntQuestScoreCoefficient
{
    [Key(0)]
    public int BigHuntQuestScoreCoefficientId { get; set; }

    [Key(1)]
    public int ScoreDifficultBonusPermil { get; set; }
}
