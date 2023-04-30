using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBattleNpcCostumeAwakenStatusUpTable : TableBase<EntityMBattleNpcCostumeAwakenStatusUp>
    {
        private readonly Func<EntityMBattleNpcCostumeAwakenStatusUp, (long, string, StatusCalculationType)> primaryIndexSelector;

        public EntityMBattleNpcCostumeAwakenStatusUpTable(EntityMBattleNpcCostumeAwakenStatusUp[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.BattleNpcId, element.BattleNpcCostumeUuid, element.StatusCalculationType);
        }
    }
}
