using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMSkillDetailTable : TableBase<EntityMSkillDetail>
{
    private readonly Func<EntityMSkillDetail, int> primaryIndexSelector;

    public EntityMSkillDetailTable(EntityMSkillDetail[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.SkillDetailId;
    }

    public EntityMSkillDetail FindBySkillDetailId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
