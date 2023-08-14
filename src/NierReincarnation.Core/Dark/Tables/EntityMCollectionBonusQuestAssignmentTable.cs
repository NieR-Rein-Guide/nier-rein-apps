using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMCollectionBonusQuestAssignmentTable : TableBase<EntityMCollectionBonusQuestAssignment>
{
    private readonly Func<EntityMCollectionBonusQuestAssignment, int> primaryIndexSelector;

    public EntityMCollectionBonusQuestAssignmentTable(EntityMCollectionBonusQuestAssignment[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.CollectionBonusQuestAssignmentId;
    }

    public EntityMCollectionBonusQuestAssignment FindByCollectionBonusQuestAssignmentId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
