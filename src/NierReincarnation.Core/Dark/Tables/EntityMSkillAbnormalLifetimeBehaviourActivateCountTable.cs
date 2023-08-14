using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMSkillAbnormalLifetimeBehaviourActivateCountTable : TableBase<EntityMSkillAbnormalLifetimeBehaviourActivateCount>
{
    private readonly Func<EntityMSkillAbnormalLifetimeBehaviourActivateCount, int> primaryIndexSelector;

    public EntityMSkillAbnormalLifetimeBehaviourActivateCountTable(EntityMSkillAbnormalLifetimeBehaviourActivateCount[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.SkillAbnormalLifetimeBehaviourId;
    }

    public EntityMSkillAbnormalLifetimeBehaviourActivateCount FindBySkillAbnormalLifetimeBehaviourId(int key) =>
        FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
