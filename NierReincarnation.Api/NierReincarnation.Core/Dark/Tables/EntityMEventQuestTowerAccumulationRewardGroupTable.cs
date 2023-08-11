using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMEventQuestTowerAccumulationRewardGroupTable : TableBase<EntityMEventQuestTowerAccumulationRewardGroup>
{
    private readonly Func<EntityMEventQuestTowerAccumulationRewardGroup, (int, int)> primaryIndexSelector;

    public EntityMEventQuestTowerAccumulationRewardGroupTable(EntityMEventQuestTowerAccumulationRewardGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.EventQuestTowerAccumulationRewardGroupId, element.QuestMissionClearCount);
    }
}
