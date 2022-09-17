using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserGimmickTable : TableBase<EntityIUserGimmick> // TypeDefIndex: 12966
    {
        // Fields
        private readonly Func<EntityIUserGimmick, ValueTuple<long, int, int, int>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x36FB224 Offset: 0x36FB224 VA: 0x36FB224
        public EntityIUserGimmickTable(EntityIUserGimmick[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = gimmick => (gimmick.UserId, gimmick.GimmickSequenceScheduleId, gimmick.GimmickSequenceId, gimmick.GimmickId);
        }

        public EntityIUserGimmick FindByUserId((long, int, int, int) key)
        {
            return FindUniqueCore(data, primaryIndexSelector, Comparer<(long, int, int, int)>.Default, key);
        }
    }
}
