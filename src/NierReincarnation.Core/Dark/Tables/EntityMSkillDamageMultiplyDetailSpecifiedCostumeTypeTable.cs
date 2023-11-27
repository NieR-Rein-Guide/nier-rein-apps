using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMSkillDamageMultiplyDetailSpecifiedCostumeTypeTable : TableBase<EntityMSkillDamageMultiplyDetailSpecifiedCostumeType>
{
    private readonly Func<EntityMSkillDamageMultiplyDetailSpecifiedCostumeType, int> primaryIndexSelector;

    public EntityMSkillDamageMultiplyDetailSpecifiedCostumeTypeTable(EntityMSkillDamageMultiplyDetailSpecifiedCostumeType[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.SkillDamageMultiplyDetailId;
    }

    public bool TryFindBySkillDamageMultiplyDetailId(int key, out EntityMSkillDamageMultiplyDetailSpecifiedCostumeType result) =>
        TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result);
}
