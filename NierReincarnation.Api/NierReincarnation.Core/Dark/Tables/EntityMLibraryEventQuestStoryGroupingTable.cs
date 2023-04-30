using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMLibraryEventQuestStoryGroupingTable : TableBase<EntityMLibraryEventQuestStoryGrouping>
    {
        private readonly Func<EntityMLibraryEventQuestStoryGrouping, (int, int)> primaryIndexSelector;

        public EntityMLibraryEventQuestStoryGroupingTable(EntityMLibraryEventQuestStoryGrouping[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.LibraryStoryGroupingId, element.EventQuestChapterId);
        }
    }
}
