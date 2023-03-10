using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserCharacterBoardTable : TableBase<EntityIUserCharacterBoard>
    {
        private readonly Func<EntityIUserCharacterBoard, (long, int)> primaryIndexSelector;

        public EntityIUserCharacterBoardTable(EntityIUserCharacterBoard[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.UserId, element.CharacterBoardId);
        }

        public EntityIUserCharacterBoard FindByUserIdAndCharacterBoardId(ValueTuple<long, int> key)
        { return FindUniqueCore(data, primaryIndexSelector, Comparer<(long, int)>.Default, key); }

        public bool TryFindByUserIdAndCharacterBoardId(ValueTuple<long, int> key, out EntityIUserCharacterBoard result)
        { return TryFindUniqueCore(data, primaryIndexSelector, Comparer<(long, int)>.Default, key, out result); }
    }
}
