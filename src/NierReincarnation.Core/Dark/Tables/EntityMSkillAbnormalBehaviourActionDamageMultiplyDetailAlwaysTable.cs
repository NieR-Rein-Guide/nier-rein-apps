using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMSkillAbnormalBehaviourActionDamageMultiplyDetailAlwaysTable : TableBase<EntityMSkillAbnormalBehaviourActionDamageMultiplyDetailAlways>
{
    private readonly Func<EntityMSkillAbnormalBehaviourActionDamageMultiplyDetailAlways, int> primaryIndexSelector;

    public EntityMSkillAbnormalBehaviourActionDamageMultiplyDetailAlwaysTable(EntityMSkillAbnormalBehaviourActionDamageMultiplyDetailAlways[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.DamageMultiplyAbnormalDetailId;
    }

    public EntityMSkillAbnormalBehaviourActionDamageMultiplyDetailAlways FindByDamageMultiplyAbnormalDetailId(int key) =>
        FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
