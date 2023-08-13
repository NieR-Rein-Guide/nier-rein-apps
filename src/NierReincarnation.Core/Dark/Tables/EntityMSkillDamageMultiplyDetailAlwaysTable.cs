using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMSkillDamageMultiplyDetailAlwaysTable : TableBase<EntityMSkillDamageMultiplyDetailAlways>
{
    private readonly Func<EntityMSkillDamageMultiplyDetailAlways, int> primaryIndexSelector;

    public EntityMSkillDamageMultiplyDetailAlwaysTable(EntityMSkillDamageMultiplyDetailAlways[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.SkillDamageMultiplyDetailId;
    }

    public EntityMSkillDamageMultiplyDetailAlways FindBySkillDamageMultiplyDetailId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
