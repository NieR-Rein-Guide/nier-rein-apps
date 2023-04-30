using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserDeckCharacterDressupCostumeTable : TableBase<EntityIUserDeckCharacterDressupCostume>
    {
        private readonly Func<EntityIUserDeckCharacterDressupCostume, (long, string)> primaryIndexSelector;

        public EntityIUserDeckCharacterDressupCostumeTable(EntityIUserDeckCharacterDressupCostume[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.UserId, element.UserDeckCharacterUuid);
        }

        public bool TryFindByUserIdAndUserDeckCharacterUuid(ValueTuple<long, string> key, out EntityIUserDeckCharacterDressupCostume result) =>
            TryFindUniqueCore(data, primaryIndexSelector, Comparer<(long, string)>.Default, key, out result);
    }
}
