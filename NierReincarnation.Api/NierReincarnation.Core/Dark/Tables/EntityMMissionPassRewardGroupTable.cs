using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMMissionPassRewardGroupTable : TableBase<EntityMMissionPassRewardGroup>
{
    private readonly Func<EntityMMissionPassRewardGroup, (int, int, bool, int)> primaryIndexSelector;
    private readonly Func<EntityMMissionPassRewardGroup, int> secondaryIndexSelector;

    public EntityMMissionPassRewardGroupTable(EntityMMissionPassRewardGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.MissionPassRewardGroupId, element.Level, element.IsPremium, element.SortOrder);
        secondaryIndexSelector = element => element.MissionPassRewardGroupId;
    }

    public RangeView<EntityMMissionPassRewardGroup> FindByMissionPassRewardGroupId(int key) => FindManyCore(data, secondaryIndexSelector, Comparer<int>.Default, key);
}
