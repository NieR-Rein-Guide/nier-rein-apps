using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBattleNpcCostumeLevelBonusReleaseStatusTable : TableBase<EntityMBattleNpcCostumeLevelBonusReleaseStatus>
    {
        private readonly Func<EntityMBattleNpcCostumeLevelBonusReleaseStatus, (long, int)> primaryIndexSelector;

        public EntityMBattleNpcCostumeLevelBonusReleaseStatusTable(EntityMBattleNpcCostumeLevelBonusReleaseStatus[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.BattleNpcId, element.CostumeId);
        }
    }
}
