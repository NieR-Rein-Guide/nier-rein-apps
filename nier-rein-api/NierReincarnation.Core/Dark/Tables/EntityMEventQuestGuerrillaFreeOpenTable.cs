using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMEventQuestGuerrillaFreeOpenTable : TableBase<EntityMEventQuestGuerrillaFreeOpen> // TypeDefIndex: 12109
    {
        // Fields
        private readonly Func<EntityMEventQuestGuerrillaFreeOpen, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2CFFB08 Offset: 0x2CFFB08 VA: 0x2CFFB08
        public EntityMEventQuestGuerrillaFreeOpenTable(EntityMEventQuestGuerrillaFreeOpen[] sortedData):base(sortedData)
        {
            primaryIndexSelector = open => open.EventQuestGuerrillaFreeOpenId;
        }
    }
}
