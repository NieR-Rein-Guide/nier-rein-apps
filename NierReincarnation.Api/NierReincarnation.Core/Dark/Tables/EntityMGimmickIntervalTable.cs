using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMGimmickIntervalTable : TableBase<EntityMGimmickInterval>
{
    private readonly Func<EntityMGimmickInterval, int> primaryIndexSelector;

    public EntityMGimmickIntervalTable(EntityMGimmickInterval[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.GimmickId;
    }
}
