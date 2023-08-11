using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMSkillBehaviourActionAttackVitalityTable : TableBase<EntityMSkillBehaviourActionAttackVitality>
{
    private readonly Func<EntityMSkillBehaviourActionAttackVitality, int> primaryIndexSelector;

    public EntityMSkillBehaviourActionAttackVitalityTable(EntityMSkillBehaviourActionAttackVitality[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.SkillBehaviourActionId;
    }

    public bool TryFindBySkillBehaviourActionId(int key, out EntityMSkillBehaviourActionAttackVitality result) =>
        TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result);
}
