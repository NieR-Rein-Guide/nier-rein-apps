using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMBattleActorSkillAiGroupTable : TableBase<EntityMBattleActorSkillAiGroup>
{
    private readonly Func<EntityMBattleActorSkillAiGroup, (int, int)> primaryIndexSelector;

    public EntityMBattleActorSkillAiGroupTable(EntityMBattleActorSkillAiGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.BattleActorSkillAiGroupId, element.Priority);
    }

    public RangeView<EntityMBattleActorSkillAiGroup> FindRangeByBattleActorSkillAiGroupIdAndPriority(ValueTuple<int, int> min, ValueTuple<int, int> max, bool ascendant = true) =>
        FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, min, max, ascendant);
}
