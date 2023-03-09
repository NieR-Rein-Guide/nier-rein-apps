using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public sealed class EntityIUserCharacterRebirthTable : TableBase<EntityIUserCharacterRebirth> // TypeDefIndex: 14494
    {
        private readonly Func<EntityIUserCharacterRebirth, (long, int)> primaryIndexSelector; // 0x18
        
        public EntityIUserCharacterRebirthTable(EntityIUserCharacterRebirth[] sortedData):base(sortedData)
        {
            primaryIndexSelector = rebirth => (rebirth.UserId, rebirth.CharacterId);
        }
        
        public EntityIUserCharacterRebirth FindByUserIdAndCharacterId(ValueTuple<long, int> key)
        {
            return FindUniqueCore(data, primaryIndexSelector, Comparer<(long, int)>.Default, key);
        }
    }
}
