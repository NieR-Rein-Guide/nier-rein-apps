using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMAbilityBehaviourActionStatusDownTable : TableBase<EntityMAbilityBehaviourActionStatusDown>
{
    private readonly Func<EntityMAbilityBehaviourActionStatusDown, int> primaryIndexSelector;

    public EntityMAbilityBehaviourActionStatusDownTable(EntityMAbilityBehaviourActionStatusDown[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.AbilityBehaviourActionId;
    }

    public EntityMAbilityBehaviourActionStatusDown FindByAbilityBehaviourActionId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
