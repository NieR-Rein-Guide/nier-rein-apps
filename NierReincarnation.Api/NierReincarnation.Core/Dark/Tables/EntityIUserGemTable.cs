using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityIUserGemTable : TableBase<EntityIUserGem> // TypeDefIndex: 12523
    {
        // Fields
        private readonly Func<EntityIUserGem, long> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x35ADC7C Offset: 0x35ADC7C VA: 0x35ADC7C
        public EntityIUserGemTable(EntityIUserGem[] sortedData):base(sortedData)
        {
            primaryIndexSelector = gem => gem.UserId;
        }

        // RVA: 0x35ADD7C Offset: 0x35ADD7C VA: 0x35ADD7C
        public EntityIUserGem FindByUserId(long key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
