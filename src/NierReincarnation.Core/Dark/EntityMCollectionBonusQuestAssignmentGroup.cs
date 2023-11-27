using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCollectionBonusQuestAssignmentGroup))]
public class EntityMCollectionBonusQuestAssignmentGroup
{
    [Key(0)]
    public int CollectionBonusQuestAssignmentGroupId { get; set; }

    [Key(1)]
    public int CollectionBonusQuestAssignmentId { get; set; }
}
