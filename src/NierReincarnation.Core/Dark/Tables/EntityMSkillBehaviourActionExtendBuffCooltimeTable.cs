﻿using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMSkillBehaviourActionExtendBuffCooltimeTable : TableBase<EntityMSkillBehaviourActionExtendBuffCooltime>
{
    private readonly Func<EntityMSkillBehaviourActionExtendBuffCooltime, int> primaryIndexSelector;

    public EntityMSkillBehaviourActionExtendBuffCooltimeTable(EntityMSkillBehaviourActionExtendBuffCooltime[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.SkillBehaviourActionId;
    }

    public EntityMSkillBehaviourActionExtendBuffCooltime FindBySkillBehaviourActionId(int key) =>
        FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
