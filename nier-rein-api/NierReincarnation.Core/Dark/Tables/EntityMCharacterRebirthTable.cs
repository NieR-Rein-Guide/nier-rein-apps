using System;
using System.Collections.Generic;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCharacterRebirthTable : TableBase<EntityMCharacterRebirth>
    {
        private readonly Func<EntityMCharacterRebirth, int> primaryIndexSelector;
        private readonly Func<EntityMCharacterRebirth, CharacterAssignmentType> secondaryIndexSelector;

        public EntityMCharacterRebirthTable(EntityMCharacterRebirth[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.CharacterId;
            secondaryIndexSelector = element => element.CharacterAssignmentType;
        }

        public EntityMCharacterRebirth FindByCharacterId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

        public RangeView<EntityMCharacterRebirth> FindByCharacterAssignmentType(CharacterAssignmentType key) { return FindManyCore(data, secondaryIndexSelector, Comparer<CharacterAssignmentType>.Default, key); }

    }
}
