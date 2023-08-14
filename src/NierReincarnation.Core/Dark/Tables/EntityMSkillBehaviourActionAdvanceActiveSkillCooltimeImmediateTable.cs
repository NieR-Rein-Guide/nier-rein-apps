using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMSkillBehaviourActionAdvanceActiveSkillCooltimeImmediateTable : TableBase<EntityMSkillBehaviourActionAdvanceActiveSkillCooltimeImmediate>
{
    private readonly Func<EntityMSkillBehaviourActionAdvanceActiveSkillCooltimeImmediate, int> primaryIndexSelector;

    public EntityMSkillBehaviourActionAdvanceActiveSkillCooltimeImmediateTable(EntityMSkillBehaviourActionAdvanceActiveSkillCooltimeImmediate[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.SkillBehaviourActionId;
    }

    public EntityMSkillBehaviourActionAdvanceActiveSkillCooltimeImmediate FindBySkillBehaviourActionId(int key) =>
        FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
