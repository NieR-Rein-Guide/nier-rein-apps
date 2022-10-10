using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCharacterBoardConditionGroupTable : TableBase<EntityMCharacterBoardConditionGroup>
    {
        private readonly Func<EntityMCharacterBoardConditionGroup, int> primaryIndexSelector;

        public EntityMCharacterBoardConditionGroupTable(EntityMCharacterBoardConditionGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.CharacterBoardConditionGroupId;
        }
        
        public EntityMCharacterBoardConditionGroup FindByCharacterBoardConditionGroupId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}