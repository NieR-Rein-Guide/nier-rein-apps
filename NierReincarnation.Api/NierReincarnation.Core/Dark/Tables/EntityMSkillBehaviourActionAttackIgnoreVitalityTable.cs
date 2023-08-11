using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMSkillBehaviourActionAttackIgnoreVitalityTable : TableBase<EntityMSkillBehaviourActionAttackIgnoreVitality>
{
    private readonly Func<EntityMSkillBehaviourActionAttackIgnoreVitality, int> primaryIndexSelector;

    public EntityMSkillBehaviourActionAttackIgnoreVitalityTable(EntityMSkillBehaviourActionAttackIgnoreVitality[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.SkillBehaviourActionId;
    }

    public EntityMSkillBehaviourActionAttackIgnoreVitality FindBySkillBehaviourActionId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
