using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMDeckEntrustCoefficientPartsSeriesBonusCountTable : TableBase<EntityMDeckEntrustCoefficientPartsSeriesBonusCount>
{
    private readonly Func<EntityMDeckEntrustCoefficientPartsSeriesBonusCount, int> primaryIndexSelector;

    public EntityMDeckEntrustCoefficientPartsSeriesBonusCountTable(EntityMDeckEntrustCoefficientPartsSeriesBonusCount[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.PartsSeriesBonusCount;
    }
}
