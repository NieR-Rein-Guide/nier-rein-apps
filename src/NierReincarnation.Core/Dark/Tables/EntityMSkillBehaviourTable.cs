using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMSkillBehaviourTable : TableBase<EntityMSkillBehaviour>
{
    private readonly Func<EntityMSkillBehaviour, int> primaryIndexSelector;

    public EntityMSkillBehaviourTable(EntityMSkillBehaviour[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.SkillBehaviourId;
    }

    public EntityMSkillBehaviour FindBySkillBehaviourId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
