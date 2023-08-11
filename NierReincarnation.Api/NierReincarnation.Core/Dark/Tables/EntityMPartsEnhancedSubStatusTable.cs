using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMPartsEnhancedSubStatusTable : TableBase<EntityMPartsEnhancedSubStatus>
{
    private readonly Func<EntityMPartsEnhancedSubStatus, (int, int)> primaryIndexSelector;

    public EntityMPartsEnhancedSubStatusTable(EntityMPartsEnhancedSubStatus[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.PartsEnhancedId, element.StatusIndex);
    }
}
