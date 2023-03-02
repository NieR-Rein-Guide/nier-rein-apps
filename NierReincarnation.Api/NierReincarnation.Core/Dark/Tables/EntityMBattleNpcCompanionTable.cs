using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMBattleNpcCompanionTable : TableBase<EntityMBattleNpcCompanion> // TypeDefIndex: 11635
    {
        // Fields
        private readonly Func<EntityMBattleNpcCompanion, ValueTuple<long, string>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C462CC Offset: 0x2C462CC VA: 0x2C462CC
        public EntityMBattleNpcCompanionTable(EntityMBattleNpcCompanion[] sortedData):base(sortedData)
        {
            primaryIndexSelector = companion => (companion.BattleNpcId, companion.BattleNpcCompanionUuid);
        }

        // RVA: 0x2C463CC Offset: 0x2C463CC VA: 0x2C463CC
        public EntityMBattleNpcCompanion FindByBattleNpcIdAndBattleNpcCompanionUuid(ValueTuple<long, string> key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
