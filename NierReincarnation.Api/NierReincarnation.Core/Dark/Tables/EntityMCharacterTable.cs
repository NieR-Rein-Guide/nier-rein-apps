using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCharacterTable : TableBase<EntityMCharacter>
    {
        // Fields
        private readonly Func<EntityMCharacter, int> primaryIndexSelector; // 0x18
        private readonly Func<EntityMCharacter, int> secondaryIndex0Selector; // 0x28

        public EntityMCharacterTable(EntityMCharacter[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = character => character.CharacterId;
            secondaryIndex0Selector = character => character.EndWeaponId;
        }

        public EntityMCharacter FindByCharacterId(int key)
        {
            foreach (var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }

        public RangeView<EntityMCharacter> FindByEndWeaponId(int key)
        {
            var result = new List<EntityMCharacter>();

            foreach (var element in data)
                if (secondaryIndex0Selector(element) == key)
                    result.Add(element);

            return new RangeView<EntityMCharacter>(result.ToArray(), 0, result.Count - 1, true);
        }
    }
}
