using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCharacterRebirthStepGroupTable : TableBase<EntityMCharacterRebirthStepGroup>
    {
        private readonly Func<EntityMCharacterRebirthStepGroup, (int, int)> primaryIndexSelector;

        public EntityMCharacterRebirthStepGroupTable(EntityMCharacterRebirthStepGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.CharacterRebirthStepGroupId, element.BeforeRebirthCount);
        }

        public EntityMCharacterRebirthStepGroup FindByCharacterRebirthStepGroupIdAndBeforeRebirthCount(ValueTuple<int, int> key) =>
            FindUniqueCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, key);
    }
}
