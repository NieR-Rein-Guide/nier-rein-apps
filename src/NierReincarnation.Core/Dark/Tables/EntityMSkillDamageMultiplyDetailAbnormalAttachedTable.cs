using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMSkillDamageMultiplyDetailAbnormalAttachedTable : TableBase<EntityMSkillDamageMultiplyDetailAbnormalAttached>
{
    private readonly Func<EntityMSkillDamageMultiplyDetailAbnormalAttached, int> primaryIndexSelector;

    public EntityMSkillDamageMultiplyDetailAbnormalAttachedTable(EntityMSkillDamageMultiplyDetailAbnormalAttached[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.SkillDamageMultiplyDetailId;
    }

    public EntityMSkillDamageMultiplyDetailAbnormalAttached FindBySkillDamageMultiplyDetailId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
