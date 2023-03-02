using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserPartsTable : TableBase<EntityIUserParts> // TypeDefIndex: 12571
    {
        // Fields
        private readonly Func<EntityIUserParts, ValueTuple<long, string>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x35B4BB8 Offset: 0x35B4BB8 VA: 0x35B4BB8
        public EntityIUserPartsTable(EntityIUserParts[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = user => (user.UserId, user.UserPartsUuid);
        }

        // RVA: 0x35B4CB8 Offset: 0x35B4CB8 VA: 0x35B4CB8
        public EntityIUserParts FindByUserIdAndUserPartsUuid(ValueTuple<long, string> key)
        {
            foreach (var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }

        // RVA: 0x35B4D40 Offset: 0x35B4D40 VA: 0x35B4D40
        public bool TryFindByUserIdAndUserPartsUuid(ValueTuple<long, string> key, out EntityIUserParts result)
        {
            result = null;

            foreach (var element in data)
                if (primaryIndexSelector(element) == key)
                {
                    result = element;
                    return true;
                }

            return false;
        }
    }
}
