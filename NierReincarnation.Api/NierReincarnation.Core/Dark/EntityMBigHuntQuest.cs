using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_big_hunt_quest")]
public class EntityMBigHuntQuest
{
    [Key(0)]
    public int BigHuntQuestId { get; set; }

    [Key(1)]
    public int QuestId { get; set; }

    [Key(2)]
    public int BigHuntQuestScoreCoefficientId { get; set; }
}
