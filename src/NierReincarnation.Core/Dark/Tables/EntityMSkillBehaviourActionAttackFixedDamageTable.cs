using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMSkillBehaviourActionAttackFixedDamageTable : TableBase<EntityMSkillBehaviourActionAttackFixedDamage>
{
    private readonly Func<EntityMSkillBehaviourActionAttackFixedDamage, int> primaryIndexSelector;

    public EntityMSkillBehaviourActionAttackFixedDamageTable(EntityMSkillBehaviourActionAttackFixedDamage[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.SkillBehaviourActionId;
    }

    public EntityMSkillBehaviourActionAttackFixedDamage FindBySkillBehaviourActionId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
