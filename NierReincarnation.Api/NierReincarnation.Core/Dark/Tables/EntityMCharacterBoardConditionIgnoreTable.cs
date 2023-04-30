using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCharacterBoardConditionIgnoreTable : TableBase<EntityMCharacterBoardConditionIgnore>
    {
        private readonly Func<EntityMCharacterBoardConditionIgnore, (int, int)> primaryIndexSelector;

        public EntityMCharacterBoardConditionIgnoreTable(EntityMCharacterBoardConditionIgnore[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.CharacterBoardConditionIgnoreId, element.IgnoreIndex);
        }
    }
}
