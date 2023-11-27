using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMEventQuestLimitContentDeckRestrictionTarget))]
public class EntityMEventQuestLimitContentDeckRestrictionTarget
{
    [Key(0)]
    public int EventQuestLimitContentDeckRestrictionTargetId { get; set; }

    [Key(1)]
    public LimitContentDeckRestrictionType LimitContentDeckRestrictionType { get; set; }
}
