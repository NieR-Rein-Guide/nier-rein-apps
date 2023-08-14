using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMSkillBehaviourActivationConditionActivationUpperCountTable : TableBase<EntityMSkillBehaviourActivationConditionActivationUpperCount>
{
    private readonly Func<EntityMSkillBehaviourActivationConditionActivationUpperCount, int> primaryIndexSelector;

    public EntityMSkillBehaviourActivationConditionActivationUpperCountTable(EntityMSkillBehaviourActivationConditionActivationUpperCount[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.SkillBehaviourActivationConditionId;
    }

    public EntityMSkillBehaviourActivationConditionActivationUpperCount FindBySkillBehaviourActivationConditionId(int key) =>
        FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
