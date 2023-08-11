using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMSkillBehaviourActionAbnormalTable : TableBase<EntityMSkillBehaviourActionAbnormal>
{
    private readonly Func<EntityMSkillBehaviourActionAbnormal, int> primaryIndexSelector;

    public EntityMSkillBehaviourActionAbnormalTable(EntityMSkillBehaviourActionAbnormal[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.SkillBehaviourActionId;
    }

    public EntityMSkillBehaviourActionAbnormal FindBySkillBehaviourActionId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
