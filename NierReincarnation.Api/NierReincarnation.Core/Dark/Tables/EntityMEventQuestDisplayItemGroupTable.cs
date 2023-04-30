using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMEventQuestDisplayItemGroupTable : TableBase<EntityMEventQuestDisplayItemGroup>
    {
        private readonly Func<EntityMEventQuestDisplayItemGroup, (int, int)> primaryIndexSelector;

        public EntityMEventQuestDisplayItemGroupTable(EntityMEventQuestDisplayItemGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.EventQuestDisplayItemGroupId, element.SortOrder);
        }
    }
}
