using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMSkillBuffTable : TableBase<EntityMSkillBuff>
{
    private readonly Func<EntityMSkillBuff, int> primaryIndexSelector;

    public EntityMSkillBuffTable(EntityMSkillBuff[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.SkillBuffId;
    }

    public EntityMSkillBuff FindBySkillBuffId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
