using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMSkillBehaviourActionAttackComboTable : TableBase<EntityMSkillBehaviourActionAttackCombo>
{
    private readonly Func<EntityMSkillBehaviourActionAttackCombo, int> primaryIndexSelector;

    public EntityMSkillBehaviourActionAttackComboTable(EntityMSkillBehaviourActionAttackCombo[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.SkillBehaviourActionId;
    }

    public EntityMSkillBehaviourActionAttackCombo FindBySkillBehaviourActionId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
