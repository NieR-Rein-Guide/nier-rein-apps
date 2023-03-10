using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserDeckLimitContentRestrictedTable : TableBase<EntityIUserDeckLimitContentRestricted>
    {
        private readonly Func<EntityIUserDeckLimitContentRestricted, (long, int, int, string)> primaryIndexSelector;
        private readonly Func<EntityIUserDeckLimitContentRestricted, (int, int)> secondaryIndexSelector;

        public EntityIUserDeckLimitContentRestrictedTable(EntityIUserDeckLimitContentRestricted[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.UserId, element.EventQuestChapterId, element.QuestId, element.DeckRestrictedUuid);
            secondaryIndexSelector = element => (element.EventQuestChapterId, element.PossessionType);
        }

        public RangeView<EntityIUserDeckLimitContentRestricted> FindByEventQuestChapterIdAndPossessionType(ValueTuple<int, int> key)
        { return FindManyCore(data, secondaryIndexSelector, Comparer<(int, int)>.Default, key); }
    }
}
