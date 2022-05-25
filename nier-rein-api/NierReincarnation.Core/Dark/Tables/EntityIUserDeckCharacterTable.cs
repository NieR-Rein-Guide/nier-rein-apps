using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserDeckCharacterTable : TableBase<EntityIUserDeckCharacter> // TypeDefIndex: 12499
    {
        // Fields
        private readonly Func<EntityIUserDeckCharacter, ValueTuple<long, string>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x35A50F8 Offset: 0x35A50F8 VA: 0x35A50F8
        public EntityIUserDeckCharacterTable(EntityIUserDeckCharacter[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = user => (user.UserId, user.UserDeckCharacterUuid);
        }

        // RVA: 0x35A51F8 Offset: 0x35A51F8 VA: 0x35A51F8
        public EntityIUserDeckCharacter FindByUserIdAndUserDeckCharacterUuid(ValueTuple<long, string> key)
        {
            foreach (var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
