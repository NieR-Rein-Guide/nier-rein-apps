using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserGimmickOrnamentProgressTable : TableBase<EntityIUserGimmickOrnamentProgress> // TypeDefIndex: 12962
    {
        // Fields
        private readonly Func<EntityIUserGimmickOrnamentProgress, ValueTuple<long, int, int, int, int>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x36FA2C0 Offset: 0x36FA2C0 VA: 0x36FA2C0
        public EntityIUserGimmickOrnamentProgressTable(EntityIUserGimmickOrnamentProgress[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = progress => (progress.UserId, progress.GimmickSequenceScheduleId,
                progress.GimmickSequenceId, progress.GimmickId, progress.GimmickOrnamentIndex);
        }

        public EntityIUserGimmickOrnamentProgress FindByUserId((long, int, int, int, int) key)
        {
            return FindUniqueCore(data, primaryIndexSelector, Comparer<(long, int, int, int, int)>.Default, key);
        }
    }
}
