using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMBattleCostumeSkillFireActTable : TableBase<EntityMBattleCostumeSkillFireAct>
{
    private readonly Func<EntityMBattleCostumeSkillFireAct, int> primaryIndexSelector;

    public EntityMBattleCostumeSkillFireActTable(EntityMBattleCostumeSkillFireAct[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.CostumeId;
    }

    public bool TryFindByCostumeId(int key, out EntityMBattleCostumeSkillFireAct result) => TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result);
}
