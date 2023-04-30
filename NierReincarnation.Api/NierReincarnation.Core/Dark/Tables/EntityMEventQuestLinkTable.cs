using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMEventQuestLinkTable : TableBase<EntityMEventQuestLink>
    {
        private readonly Func<EntityMEventQuestLink, int> primaryIndexSelector;

        public EntityMEventQuestLinkTable(EntityMEventQuestLink[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.EventQuestLinkId;
        }

        public EntityMEventQuestLink FindByEventQuestLinkId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
    }
}
