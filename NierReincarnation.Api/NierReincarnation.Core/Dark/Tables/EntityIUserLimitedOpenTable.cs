using System;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityIUserLimitedOpenTable : TableBase<EntityIUserLimitedOpen> // TypeDefIndex: 12535
    {
        // Fields
        private readonly Func<EntityIUserLimitedOpen, (long,LimitedOpenTargetType,int)> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x35B08C8 Offset: 0x35B08C8 VA: 0x35B08C8
        public EntityIUserLimitedOpenTable(EntityIUserLimitedOpen[] sortedData):base(sortedData)
        {
            primaryIndexSelector = open => (open.UserId,open.LimitedOpenTargetType,open.TargetId);
        }

        // RVA: 0x35B09C8 Offset: 0x35B09C8 VA: 0x35B09C8
        public EntityIUserLimitedOpen FindByUserIdAndLimitedOpenTargetTypeAndTargetId((long, LimitedOpenTargetType, int) key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
