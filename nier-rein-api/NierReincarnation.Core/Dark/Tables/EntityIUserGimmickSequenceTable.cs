using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserGimmickSequenceTable : TableBase<EntityIUserGimmickSequence> // TypeDefIndex: 12964
    {
        // Fields
        private readonly Func<EntityIUserGimmickSequence, ValueTuple<long, int>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x36FAB54 Offset: 0x36FAB54 VA: 0x36FAB54
        public EntityIUserGimmickSequenceTable(EntityIUserGimmickSequence[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = sequence => (sequence.UserId, sequence.GimmickSequenceScheduleId);
        }

        public EntityIUserGimmickSequence FindByUserId((long, int) key)
        {
            return FindUniqueCore(data, primaryIndexSelector, Comparer<(long, int)>.Default, key);
        }
    }
}
