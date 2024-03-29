using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMOverrideHitEffectConditionSkillExecutorTable : TableBase<EntityMOverrideHitEffectConditionSkillExecutor>
{
    private readonly Func<EntityMOverrideHitEffectConditionSkillExecutor, int> primaryIndexSelector;

    public EntityMOverrideHitEffectConditionSkillExecutorTable(EntityMOverrideHitEffectConditionSkillExecutor[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.OverrideHitEffectConditionId;
    }

    public EntityMOverrideHitEffectConditionSkillExecutor FindByOverrideHitEffectConditionId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
