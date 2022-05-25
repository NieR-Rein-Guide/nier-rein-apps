using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMBattleNpcCostumeTable : TableBase<EntityMBattleNpcCostume> // TypeDefIndex: 11643
    {
        // Fields
        private readonly Func<EntityMBattleNpcCostume, ValueTuple<long, string>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C46AF8 Offset: 0x2C46AF8 VA: 0x2C46AF8
        public EntityMBattleNpcCostumeTable(EntityMBattleNpcCostume[] sortedData):base(sortedData)
        {
            primaryIndexSelector = costume => (costume.BattleNpcId, costume.BattleNpcCostumeUuid);
        }

        // RVA: 0x2C46BF8 Offset: 0x2C46BF8 VA: 0x2C46BF8
        public EntityMBattleNpcCostume FindByBattleNpcIdAndBattleNpcCostumeUuid(ValueTuple<long, string> key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
