using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMSkillAbnormalDamageMultiplyDetailBuffAttachedTable : TableBase<EntityMSkillAbnormalDamageMultiplyDetailBuffAttached>
{
    private readonly Func<EntityMSkillAbnormalDamageMultiplyDetailBuffAttached, int> primaryIndexSelector;

    public EntityMSkillAbnormalDamageMultiplyDetailBuffAttachedTable(EntityMSkillAbnormalDamageMultiplyDetailBuffAttached[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.DamageMultiplyAbnormalDetailId;
    }

    public bool TryFindByDamageMultiplyAbnormalDetailId(int key, out EntityMSkillAbnormalDamageMultiplyDetailBuffAttached result) =>
        TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result);
}
