using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityIUserCharacterTable : TableBase<EntityIUserCharacter> // TypeDefIndex: 12483
    {
        // Fields
        private readonly Func<EntityIUserCharacter, (long,int)> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2DC6A6C Offset: 0x2DC6A6C VA: 0x2DC6A6C
        public EntityIUserCharacterTable(EntityIUserCharacter[] sortedData):base(sortedData)
        {
            primaryIndexSelector = user => (user.UserId, user.CharacterId);
        }

        // RVA: 0x2DC6B6C Offset: 0x2DC6B6C VA: 0x2DC6B6C
        public EntityIUserCharacter FindByUserIdAndCharacterId(ValueTuple<long, int> key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }

        public bool TryFindByUserIdAndCharacterId(ValueTuple<long, int> key, out EntityIUserCharacter result)
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
