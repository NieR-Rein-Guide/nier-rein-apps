using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMSkillBehaviourActivationConditionInSkillFlowTable : TableBase<EntityMSkillBehaviourActivationConditionInSkillFlow>
{
    private readonly Func<EntityMSkillBehaviourActivationConditionInSkillFlow, int> primaryIndexSelector;

    public EntityMSkillBehaviourActivationConditionInSkillFlowTable(EntityMSkillBehaviourActivationConditionInSkillFlow[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.SkillBehaviourActivationConditionId;
    }

    public EntityMSkillBehaviourActivationConditionInSkillFlow FindBySkillBehaviourActivationConditionId(int key) =>
        FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
