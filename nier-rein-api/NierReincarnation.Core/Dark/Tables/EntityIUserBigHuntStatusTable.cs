using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityIUserBigHuntStatusTable : TableBase<EntityIUserBigHuntStatus> // TypeDefIndex: 12469
    {
        // Fields
        private readonly Func<EntityIUserBigHuntStatus, (long, int)> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2DC4994 Offset: 0x2DC4994 VA: 0x2DC4994
        public EntityIUserBigHuntStatusTable(EntityIUserBigHuntStatus[] sortedData):base(sortedData)
        {
            primaryIndexSelector = status => (status.UserId, status.BigHuntBossQuestId);
        }

        // RVA: 0x2DC4A94 Offset: 0x2DC4A94 VA: 0x2DC4A94
        public EntityIUserBigHuntStatus FindByUserIdAndBigHuntBossQuestId((long, int) key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
