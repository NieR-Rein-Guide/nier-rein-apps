using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBigHuntQuestGroupTable : TableBase<EntityMBigHuntQuestGroup>
    {
        private readonly Func<EntityMBigHuntQuestGroup, (int, int)> primaryIndexSelector;

        public EntityMBigHuntQuestGroupTable(EntityMBigHuntQuestGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.BigHuntQuestGroupId, element.SortOrder);
        }
    }
}
