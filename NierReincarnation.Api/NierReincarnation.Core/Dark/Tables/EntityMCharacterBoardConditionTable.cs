using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCharacterBoardConditionTable : TableBase<EntityMCharacterBoardCondition>
    {
        private readonly Func<EntityMCharacterBoardCondition, (int, int)> primaryIndexSelector;

        public EntityMCharacterBoardConditionTable(EntityMCharacterBoardCondition[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.CharacterBoardConditionGroupId, element.GroupIndex);
        }

        public RangeView<EntityMCharacterBoardCondition> FindRangeByCharacterBoardConditionGroupIdAndGroupIndex(ValueTuple<int, int> min, ValueTuple<int, int> max, bool ascendant = true) =>
            FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, min, max, ascendant);
    }
}
