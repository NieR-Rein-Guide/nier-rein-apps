using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMSkillAbnormalLifetimeBehaviourFrameCountTable : TableBase<EntityMSkillAbnormalLifetimeBehaviourFrameCount>
{
    private readonly Func<EntityMSkillAbnormalLifetimeBehaviourFrameCount, int> primaryIndexSelector;

    public EntityMSkillAbnormalLifetimeBehaviourFrameCountTable(EntityMSkillAbnormalLifetimeBehaviourFrameCount[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.SkillAbnormalLifetimeBehaviourId;
    }

    public EntityMSkillAbnormalLifetimeBehaviourFrameCount FindBySkillAbnormalLifetimeBehaviourId(int key) =>
        FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
