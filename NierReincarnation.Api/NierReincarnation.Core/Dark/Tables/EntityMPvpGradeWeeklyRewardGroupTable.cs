using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMPvpGradeWeeklyRewardGroupTable : TableBase<EntityMPvpGradeWeeklyRewardGroup>
{
    private readonly Func<EntityMPvpGradeWeeklyRewardGroup, (int, int)> primaryIndexSelector;

    public EntityMPvpGradeWeeklyRewardGroupTable(EntityMPvpGradeWeeklyRewardGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.PvpGradeWeeklyRewardGroupId, element.PvpRewardId);
    }
}
