using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserThoughtTable : TableBase<EntityIUserThought> // TypeDefIndex: 12863
    {
        // Fields
        private readonly Func<EntityIUserThought, ValueTuple<long, string>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2ECEFF8 Offset: 0x2ECEFF8 VA: 0x2ECEFF8
        public EntityIUserThoughtTable(EntityIUserThought[] sortedData):base(sortedData)
        {
            primaryIndexSelector = thought => (thought.UserId, thought.UserThoughtUuid);
        }

        public EntityIUserThought FindByUserIdAndUserThoughtUuid(ValueTuple<long, string> key)
        {
            foreach (var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }

        // RVA: 0x2ECF0F8 Offset: 0x2ECF0F8 VA: 0x2ECF0F8
        public bool TryFindByUserIdAndUserThoughtUuid(ValueTuple<long, string> key, out EntityIUserThought result)
        {
            result = null;

            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                {
                    result = element;
                    return true;
                }

            return false;
        }
    }
}
