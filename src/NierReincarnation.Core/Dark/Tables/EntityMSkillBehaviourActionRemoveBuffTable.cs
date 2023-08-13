using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMSkillBehaviourActionRemoveBuffTable : TableBase<EntityMSkillBehaviourActionRemoveBuff>
{
    private readonly Func<EntityMSkillBehaviourActionRemoveBuff, int> primaryIndexSelector;

    public EntityMSkillBehaviourActionRemoveBuffTable(EntityMSkillBehaviourActionRemoveBuff[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.SkillBehaviourActionId;
    }

    public EntityMSkillBehaviourActionRemoveBuff FindBySkillBehaviourActionId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
