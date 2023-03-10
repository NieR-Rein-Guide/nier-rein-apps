using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserTripleDeckTable : TableBase<EntityIUserTripleDeck>
    {
        private readonly Func<EntityIUserTripleDeck, (long, int, int)> primaryIndexSelector;

        public EntityIUserTripleDeckTable(EntityIUserTripleDeck[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.UserId, element.DeckType, element.UserDeckNumber);
        }

        public EntityIUserTripleDeck FindByUserIdAndDeckTypeAndUserDeckNumber(ValueTuple<long, int, int> key)
        { return FindUniqueCore(data, primaryIndexSelector, Comparer<(long, int, int)>.Default, key); }

        public bool TryFindByUserIdAndDeckTypeAndUserDeckNumber(ValueTuple<long, int, int> key, out EntityIUserTripleDeck result)
        { return TryFindUniqueCore(data, primaryIndexSelector, Comparer<(long, int, int)>.Default, key, out result); }
    }
}
