using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMAbilityBehaviourTable : TableBase<EntityMAbilityBehaviour>
{
    private readonly Func<EntityMAbilityBehaviour, int> primaryIndexSelector;

    public EntityMAbilityBehaviourTable(EntityMAbilityBehaviour[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.AbilityBehaviourId;
    }

    public EntityMAbilityBehaviour FindByAbilityBehaviourId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
