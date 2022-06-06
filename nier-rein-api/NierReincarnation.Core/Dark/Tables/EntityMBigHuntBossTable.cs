using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMBigHuntBossTable : TableBase<EntityMBigHuntBoss> // TypeDefIndex: 11705
    {
        // Fields
        private readonly Func<EntityMBigHuntBoss, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C472E8 Offset: 0x2C472E8 VA: 0x2C472E8
        public EntityMBigHuntBossTable(EntityMBigHuntBoss[] sortedData):base(sortedData)
        {
            primaryIndexSelector = boss => boss.BigHuntBossId;
        }

        // RVA: 0x2C473E8 Offset: 0x2C473E8 VA: 0x2C473E8
        public EntityMBigHuntBoss FindByBigHuntBossId(int key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
