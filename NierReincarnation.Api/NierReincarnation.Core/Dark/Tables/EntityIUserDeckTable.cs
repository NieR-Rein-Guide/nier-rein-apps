using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserDeckTable : TableBase<EntityIUserDeck>
    {
        private readonly Func<EntityIUserDeck, (long, DeckType, int)> primaryIndexSelector;

        public EntityIUserDeckTable(EntityIUserDeck[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.UserId, element.DeckType, element.UserDeckNumber);
        }

        public EntityIUserDeck FindByUserIdAndDeckTypeAndUserDeckNumber(ValueTuple<long, DeckType, int> key) =>
            FindUniqueCore(data, primaryIndexSelector, Comparer<(long, DeckType, int)>.Default, key);

        public bool TryFindByUserIdAndDeckTypeAndUserDeckNumber(ValueTuple<long, DeckType, int> key, out EntityIUserDeck result) =>
            TryFindUniqueCore(data, primaryIndexSelector, Comparer<(long, DeckType, int)>.Default, key, out result);
    }
}
