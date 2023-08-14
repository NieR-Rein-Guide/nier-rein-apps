using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMSkillDamageMultiplyDetailCriticalTable : TableBase<EntityMSkillDamageMultiplyDetailCritical>
{
    private readonly Func<EntityMSkillDamageMultiplyDetailCritical, int> primaryIndexSelector;

    public EntityMSkillDamageMultiplyDetailCriticalTable(EntityMSkillDamageMultiplyDetailCritical[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.SkillDamageMultiplyDetailId;
    }

    public EntityMSkillDamageMultiplyDetailCritical FindBySkillDamageMultiplyDetailId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
