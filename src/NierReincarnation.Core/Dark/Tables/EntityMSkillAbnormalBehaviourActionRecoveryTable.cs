using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMSkillAbnormalBehaviourActionRecoveryTable : TableBase<EntityMSkillAbnormalBehaviourActionRecovery>
{
    private readonly Func<EntityMSkillAbnormalBehaviourActionRecovery, int> primaryIndexSelector;

    public EntityMSkillAbnormalBehaviourActionRecoveryTable(EntityMSkillAbnormalBehaviourActionRecovery[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.SkillAbnormalBehaviourActionId;
    }

    public EntityMSkillAbnormalBehaviourActionRecovery FindBySkillAbnormalBehaviourActionId(int key) =>
        FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
