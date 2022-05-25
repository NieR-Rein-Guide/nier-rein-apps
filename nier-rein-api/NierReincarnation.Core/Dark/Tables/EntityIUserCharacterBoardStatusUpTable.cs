using System;
using System.Collections.Generic;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserCharacterBoardStatusUpTable : TableBase<EntityIUserCharacterBoardStatusUp> // TypeDefIndex: 12477
    {
        // Fields
        private readonly Func<EntityIUserCharacterBoardStatusUp, (long, int, StatusCalculationType)> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2DC4C7C Offset: 0x2DC4C7C VA: 0x2DC4C7C
        public EntityIUserCharacterBoardStatusUpTable(EntityIUserCharacterBoardStatusUp[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = user => (user.UserId, user.CharacterId, user.StatusCalculationType);
        }

        // RVA: 0x2DC4D7C Offset: 0x2DC4D7C VA: 0x2DC4D7C
        public EntityIUserCharacterBoardStatusUp FindByUserIdAndCharacterIdAndStatusCalculationType((long, int, StatusCalculationType) key)
        {
            foreach (var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }

        public RangeView<EntityIUserCharacterBoardStatusUp> FindRangeByUserIdAndCharacterIdAndStatusCalculationType(ValueTuple<long, int, StatusCalculationType> min, ValueTuple<long, int, StatusCalculationType> max, bool ascendant = true)
        {
            return FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(long, int, StatusCalculationType)>.Default, min, max, ascendant);
        }
    }
}
