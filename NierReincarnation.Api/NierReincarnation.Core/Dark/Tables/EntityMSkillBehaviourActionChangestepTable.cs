using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMSkillBehaviourActionChangestepTable : TableBase<EntityMSkillBehaviourActionChangestep>
{
    private readonly Func<EntityMSkillBehaviourActionChangestep, int> primaryIndexSelector;

    public EntityMSkillBehaviourActionChangestepTable(EntityMSkillBehaviourActionChangestep[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.SkillBehaviourActionId;
    }

    public EntityMSkillBehaviourActionChangestep FindBySkillBehaviourActionId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
