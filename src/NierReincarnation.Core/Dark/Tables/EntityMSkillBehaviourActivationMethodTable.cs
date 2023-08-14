using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMSkillBehaviourActivationMethodTable : TableBase<EntityMSkillBehaviourActivationMethod>
{
    private readonly Func<EntityMSkillBehaviourActivationMethod, int> primaryIndexSelector;

    public EntityMSkillBehaviourActivationMethodTable(EntityMSkillBehaviourActivationMethod[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.SkillBehaviourActivationMethodId;
    }

    public EntityMSkillBehaviourActivationMethod FindBySkillBehaviourActivationMethodId(int key) =>
        FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
