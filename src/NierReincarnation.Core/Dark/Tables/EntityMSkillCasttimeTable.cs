using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMSkillCasttimeTable : TableBase<EntityMSkillCasttime>
{
    private readonly Func<EntityMSkillCasttime, int> primaryIndexSelector;

    public EntityMSkillCasttimeTable(EntityMSkillCasttime[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.SkillCasttimeId;
    }

    public EntityMSkillCasttime FindBySkillCasttimeId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
