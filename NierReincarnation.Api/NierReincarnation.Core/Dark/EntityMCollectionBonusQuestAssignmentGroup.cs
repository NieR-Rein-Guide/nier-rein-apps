using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_collection_bonus_quest_assignment_group")]
public class EntityMCollectionBonusQuestAssignmentGroup
{
    [Key(0)]
    public int CollectionBonusQuestAssignmentGroupId { get; set; }

    [Key(1)]
    public int CollectionBonusQuestAssignmentId { get; set; }
}
