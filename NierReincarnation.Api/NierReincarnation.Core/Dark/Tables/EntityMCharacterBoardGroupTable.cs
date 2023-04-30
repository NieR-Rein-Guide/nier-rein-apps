using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCharacterBoardGroupTable : TableBase<EntityMCharacterBoardGroup>
    {
        private readonly Func<EntityMCharacterBoardGroup, int> primaryIndexSelector;

        public EntityMCharacterBoardGroupTable(EntityMCharacterBoardGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.CharacterBoardGroupId;
        }

        public EntityMCharacterBoardGroup FindByCharacterBoardGroupId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
    }
}
