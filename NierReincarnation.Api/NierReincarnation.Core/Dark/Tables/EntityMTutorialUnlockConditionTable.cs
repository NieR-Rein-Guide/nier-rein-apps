using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMTutorialUnlockConditionTable : TableBase<EntityMTutorialUnlockCondition>
{
    private readonly Func<EntityMTutorialUnlockCondition, TutorialType> primaryIndexSelector;

    public EntityMTutorialUnlockConditionTable(EntityMTutorialUnlockCondition[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.TutorialType;
    }

    public EntityMTutorialUnlockCondition FindByTutorialType(TutorialType key) => FindUniqueCore(data, primaryIndexSelector, Comparer<TutorialType>.Default, key);
}
