using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMSkillAbnormalBehaviourActionDamageTable : TableBase<EntityMSkillAbnormalBehaviourActionDamage>
{
    private readonly Func<EntityMSkillAbnormalBehaviourActionDamage, int> primaryIndexSelector;

    public EntityMSkillAbnormalBehaviourActionDamageTable(EntityMSkillAbnormalBehaviourActionDamage[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.SkillAbnormalBehaviourActionId;
    }

    public EntityMSkillAbnormalBehaviourActionDamage FindBySkillAbnormalBehaviourActionId(int key) =>
        FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
