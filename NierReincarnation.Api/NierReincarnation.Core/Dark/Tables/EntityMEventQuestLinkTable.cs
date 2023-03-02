using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMEventQuestLinkTable : TableBase<EntityMEventQuestLink> // TypeDefIndex: 11892
    {
        // Fields
        private readonly Func<EntityMEventQuestLink, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2B57A40 Offset: 0x2B57A40 VA: 0x2B57A40
        public EntityMEventQuestLinkTable(EntityMEventQuestLink[] sortedData):base(sortedData)
        {
            primaryIndexSelector = link => link.EventQuestLinkId;
        }

        // RVA: 0x2B57B40 Offset: 0x2B57B40 VA: 0x2B57B40
        public EntityMEventQuestLink FindByEventQuestLinkId(int key)
        {
            foreach(var link in data)
                if (primaryIndexSelector(link) == key)
                    return link;

            return null;
        }
    }
}
