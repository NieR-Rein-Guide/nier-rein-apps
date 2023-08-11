using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMSkillCasttimeBehaviourTable : TableBase<EntityMSkillCasttimeBehaviour>
{
    private readonly Func<EntityMSkillCasttimeBehaviour, int> primaryIndexSelector;

    public EntityMSkillCasttimeBehaviourTable(EntityMSkillCasttimeBehaviour[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.SkillCasttimeBehaviourId;
    }

    public EntityMSkillCasttimeBehaviour FindBySkillCasttimeBehaviourId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
