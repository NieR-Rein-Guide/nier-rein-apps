using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMQuestReleaseConditionDeckPower))]
public class EntityMQuestReleaseConditionDeckPower
{
    [Key(0)]
    public int QuestReleaseConditionId { get; set; }

    [Key(1)]
    public int MaxDeckPower { get; set; }
}
