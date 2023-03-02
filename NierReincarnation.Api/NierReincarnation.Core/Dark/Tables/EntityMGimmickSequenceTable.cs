using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMGimmickSequenceTable : TableBase<EntityMGimmickSequence>
    {
        private readonly Func<EntityMGimmickSequence, int> primaryIndexSelector;

        public EntityMGimmickSequenceTable(EntityMGimmickSequence[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.GimmickSequenceId;
        }
        
        public EntityMGimmickSequence FindByGimmickSequenceId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}