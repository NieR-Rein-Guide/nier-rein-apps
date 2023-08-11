using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMSkillAbnormalBehaviourActionHitRatioDownTable : TableBase<EntityMSkillAbnormalBehaviourActionHitRatioDown>
{
    private readonly Func<EntityMSkillAbnormalBehaviourActionHitRatioDown, int> primaryIndexSelector;

    public EntityMSkillAbnormalBehaviourActionHitRatioDownTable(EntityMSkillAbnormalBehaviourActionHitRatioDown[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.SkillAbnormalBehaviourActionId;
    }

    public EntityMSkillAbnormalBehaviourActionHitRatioDown FindBySkillAbnormalBehaviourActionId(int key) =>
        FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
