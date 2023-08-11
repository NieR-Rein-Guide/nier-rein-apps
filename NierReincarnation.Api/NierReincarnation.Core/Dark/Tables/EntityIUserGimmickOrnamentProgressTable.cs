using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityIUserGimmickOrnamentProgressTable : TableBase<EntityIUserGimmickOrnamentProgress>
{
    private readonly Func<EntityIUserGimmickOrnamentProgress, (long, int, int, int, int)> primaryIndexSelector;

    public EntityIUserGimmickOrnamentProgressTable(EntityIUserGimmickOrnamentProgress[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.UserId, element.GimmickSequenceScheduleId, element.GimmickSequenceId, element.GimmickId, element.GimmickOrnamentIndex);
    }

    public EntityIUserGimmickOrnamentProgress FindByUserId((long, int, int, int, int) key) => FindUniqueCore(data, primaryIndexSelector, Comparer<(long, int, int, int, int)>.Default, key);
}
