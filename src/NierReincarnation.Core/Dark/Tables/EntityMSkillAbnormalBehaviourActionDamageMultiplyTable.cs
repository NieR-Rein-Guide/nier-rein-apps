using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMSkillAbnormalBehaviourActionDamageMultiplyTable : TableBase<EntityMSkillAbnormalBehaviourActionDamageMultiply>
{
    private readonly Func<EntityMSkillAbnormalBehaviourActionDamageMultiply, int> primaryIndexSelector;

    public EntityMSkillAbnormalBehaviourActionDamageMultiplyTable(EntityMSkillAbnormalBehaviourActionDamageMultiply[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.SkillAbnormalBehaviourActionId;
    }

    public EntityMSkillAbnormalBehaviourActionDamageMultiply FindBySkillAbnormalBehaviourActionId(int key) =>
        FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
