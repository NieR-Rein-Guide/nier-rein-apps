using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMQuestDeckRestrictionGroupUnlock))]
public class EntityMQuestDeckRestrictionGroupUnlock
{
    [Key(0)]
    public int QuestDeckRestrictionGroupId { get; set; }

    [Key(1)]
    public int UnlockEvaluateConditionId { get; set; }
}
