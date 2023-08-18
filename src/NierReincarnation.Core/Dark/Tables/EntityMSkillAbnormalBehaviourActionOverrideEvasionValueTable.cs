using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMSkillAbnormalBehaviourActionOverrideEvasionValueTable : TableBase<EntityMSkillAbnormalBehaviourActionOverrideEvasionValue>
{
    private readonly Func<EntityMSkillAbnormalBehaviourActionOverrideEvasionValue, int> primaryIndexSelector;

    public EntityMSkillAbnormalBehaviourActionOverrideEvasionValueTable(EntityMSkillAbnormalBehaviourActionOverrideEvasionValue[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.SkillAbnormalBehaviourActionId;
    }

    public EntityMSkillAbnormalBehaviourActionOverrideEvasionValue FindBySkillAbnormalBehaviourActionId(int key) =>
        FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
