using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMBigHuntLinkTable : TableBase<EntityMBigHuntLink>
{
    private readonly Func<EntityMBigHuntLink, int> primaryIndexSelector;

    public EntityMBigHuntLinkTable(EntityMBigHuntLink[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.BigHuntLinkId;
    }
}
