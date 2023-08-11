using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMGimmickSequenceTable : TableBase<EntityMGimmickSequence>
{
    private readonly Func<EntityMGimmickSequence, int> primaryIndexSelector;

    public EntityMGimmickSequenceTable(EntityMGimmickSequence[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.GimmickSequenceId;
    }

    public EntityMGimmickSequence FindByGimmickSequenceId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
