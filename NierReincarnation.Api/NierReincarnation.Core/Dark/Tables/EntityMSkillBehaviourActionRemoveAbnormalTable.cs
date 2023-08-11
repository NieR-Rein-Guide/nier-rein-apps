using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMSkillBehaviourActionRemoveAbnormalTable : TableBase<EntityMSkillBehaviourActionRemoveAbnormal>
{
    private readonly Func<EntityMSkillBehaviourActionRemoveAbnormal, int> primaryIndexSelector;

    public EntityMSkillBehaviourActionRemoveAbnormalTable(EntityMSkillBehaviourActionRemoveAbnormal[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.SkillBehaviourActionId;
    }

    public EntityMSkillBehaviourActionRemoveAbnormal FindBySkillBehaviourActionId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
