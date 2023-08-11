using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMTitleStillTable : TableBase<EntityMTitleStill>
{
    private readonly Func<EntityMTitleStill, int> primaryIndexSelector;

    public EntityMTitleStillTable(EntityMTitleStill[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.TitleStillId;
    }
}
