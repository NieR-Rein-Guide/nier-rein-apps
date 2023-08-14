using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMAbilityBehaviourActionStatusTable : TableBase<EntityMAbilityBehaviourActionStatus>
{
    private readonly Func<EntityMAbilityBehaviourActionStatus, int> primaryIndexSelector;

    public EntityMAbilityBehaviourActionStatusTable(EntityMAbilityBehaviourActionStatus[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.AbilityBehaviourActionId;
    }

    public EntityMAbilityBehaviourActionStatus FindByAbilityBehaviourActionId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
