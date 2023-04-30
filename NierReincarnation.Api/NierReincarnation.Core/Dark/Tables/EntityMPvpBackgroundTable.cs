using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMPvpBackgroundTable : TableBase<EntityMPvpBackground>
    {
        private readonly Func<EntityMPvpBackground, (int, int, int)> primaryIndexSelector;

        public EntityMPvpBackgroundTable(EntityMPvpBackground[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.AssetBackgroundId, element.BattleFieldLocaleSettingIndex, element.BattlePointIndex);
        }
    }
}
