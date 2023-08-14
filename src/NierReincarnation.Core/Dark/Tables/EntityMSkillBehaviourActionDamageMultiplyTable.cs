using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMSkillBehaviourActionDamageMultiplyTable : TableBase<EntityMSkillBehaviourActionDamageMultiply>
{
    private readonly Func<EntityMSkillBehaviourActionDamageMultiply, int> primaryIndexSelector;

    public EntityMSkillBehaviourActionDamageMultiplyTable(EntityMSkillBehaviourActionDamageMultiply[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.SkillBehaviourActionId;
    }

    public EntityMSkillBehaviourActionDamageMultiply FindBySkillBehaviourActionId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
