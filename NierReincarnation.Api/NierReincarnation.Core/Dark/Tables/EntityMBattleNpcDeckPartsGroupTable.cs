using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBattleNpcDeckPartsGroupTable : TableBase<EntityMBattleNpcDeckPartsGroup>
    {
        private readonly Func<EntityMBattleNpcDeckPartsGroup, (long, string, string)> primaryIndexSelector;

        public EntityMBattleNpcDeckPartsGroupTable(EntityMBattleNpcDeckPartsGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.BattleNpcId, element.BattleNpcDeckCharacterUuid, element.BattleNpcPartsUuid);
        }
    }
}
