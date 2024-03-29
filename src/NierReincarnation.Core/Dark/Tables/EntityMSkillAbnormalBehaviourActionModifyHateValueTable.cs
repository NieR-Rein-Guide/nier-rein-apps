using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMSkillAbnormalBehaviourActionModifyHateValueTable : TableBase<EntityMSkillAbnormalBehaviourActionModifyHateValue>
{
    private readonly Func<EntityMSkillAbnormalBehaviourActionModifyHateValue, int> primaryIndexSelector;

    public EntityMSkillAbnormalBehaviourActionModifyHateValueTable(EntityMSkillAbnormalBehaviourActionModifyHateValue[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.SkillAbnormalBehaviourActionId;
    }

    public EntityMSkillAbnormalBehaviourActionModifyHateValue FindBySkillAbnormalBehaviourActionId(int key) =>
        FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
