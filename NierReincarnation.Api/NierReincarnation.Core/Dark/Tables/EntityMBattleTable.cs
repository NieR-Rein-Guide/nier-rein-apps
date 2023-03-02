using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMBattleTable : TableBase<EntityMBattle> // TypeDefIndex: 11693
    {
        // Fields
        private readonly Func<EntityMBattle, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C49DDC Offset: 0x2C49DDC VA: 0x2C49DDC
        public EntityMBattleTable(EntityMBattle[] sortedData):base(sortedData)
        {
            primaryIndexSelector = battle => battle.BattleId;
        }

        // RVA: 0x2C49EDC Offset: 0x2C49EDC VA: 0x2C49EDC
        public EntityMBattle FindByBattleId(int key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }

        // RVA: 0x2C49F70 Offset: 0x2C49F70 VA: 0x2C49F70
        public bool TryFindByBattleId(int key, out EntityMBattle result)
        {
            result = null;

            foreach (var element in data)
                if (primaryIndexSelector(element) == key)
                {
                    result = element;
                    return true;
                }

            return false;
        }
    }
}
