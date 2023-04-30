using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCharacterRebirthMaterialGroupTable : TableBase<EntityMCharacterRebirthMaterialGroup>
    {
        private readonly Func<EntityMCharacterRebirthMaterialGroup, (int, int)> primaryIndexSelector;
        private readonly Func<EntityMCharacterRebirthMaterialGroup, int> secondaryIndexSelector;

        public EntityMCharacterRebirthMaterialGroupTable(EntityMCharacterRebirthMaterialGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.CharacterRebirthMaterialGroupId, element.MaterialId);
            secondaryIndexSelector = element => element.CharacterRebirthMaterialGroupId;
        }

        public RangeView<EntityMCharacterRebirthMaterialGroup> FindByCharacterRebirthMaterialGroupId(int key) => FindManyCore(data, secondaryIndexSelector, Comparer<int>.Default, key);
    }
}
