using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserSideStoryQuestTable : TableBase<EntityIUserSideStoryQuest>
    {
        private readonly Func<EntityIUserSideStoryQuest, (long, int)> primaryIndexSelector;

        public EntityIUserSideStoryQuestTable(EntityIUserSideStoryQuest[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.UserId, element.SideStoryQuestId);
        }
    }
}
