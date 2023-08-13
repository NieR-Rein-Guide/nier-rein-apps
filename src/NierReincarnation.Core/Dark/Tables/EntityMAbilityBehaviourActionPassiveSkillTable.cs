using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMAbilityBehaviourActionPassiveSkillTable : TableBase<EntityMAbilityBehaviourActionPassiveSkill>
{
    private readonly Func<EntityMAbilityBehaviourActionPassiveSkill, int> primaryIndexSelector;

    public EntityMAbilityBehaviourActionPassiveSkillTable(EntityMAbilityBehaviourActionPassiveSkill[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.AbilityBehaviourActionId;
    }

    public EntityMAbilityBehaviourActionPassiveSkill FindByAbilityBehaviourActionId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
