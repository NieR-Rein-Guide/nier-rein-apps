using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMSkillAbnormalDamageMultiplyDetailAbnormalTable : TableBase<EntityMSkillAbnormalDamageMultiplyDetailAbnormal>
{
    private readonly Func<EntityMSkillAbnormalDamageMultiplyDetailAbnormal, int> primaryIndexSelector;

    public EntityMSkillAbnormalDamageMultiplyDetailAbnormalTable(EntityMSkillAbnormalDamageMultiplyDetailAbnormal[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.DamageMultiplyAbnormalDetailId;
    }

    public bool TryFindByDamageMultiplyAbnormalDetailId(int key, out EntityMSkillAbnormalDamageMultiplyDetailAbnormal result) =>
        TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result);
}
