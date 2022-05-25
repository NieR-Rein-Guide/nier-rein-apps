using System;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityIUserDeckTable : TableBase<EntityIUserDeck> // TypeDefIndex: 12505
    {
        // Fields
        private readonly Func<EntityIUserDeck, ValueTuple<long, DeckType, int>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x35A6610 Offset: 0x35A6610 VA: 0x35A6610
        public EntityIUserDeckTable(EntityIUserDeck[] sortedData):base(sortedData)
        {
            primaryIndexSelector = user => (user.UserId, user.DeckType, user.UserDeckNumber);
        }

        // RVA: 0x35A6710 Offset: 0x35A6710 VA: 0x35A6710
        public EntityIUserDeck FindByUserIdAndDeckTypeAndUserDeckNumber(ValueTuple<long, DeckType, int> key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }

        // RVA: 0x35A6798 Offset: 0x35A6798 VA: 0x35A6798
        public bool TryFindByUserIdAndDeckTypeAndUserDeckNumber(ValueTuple<long, DeckType, int> key,
            out EntityIUserDeck result)
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
