using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMQuestMissionRewardTable : TableBase<EntityMQuestMissionReward>
{
    private readonly Func<EntityMQuestMissionReward, int> primaryIndexSelector;

    public EntityMQuestMissionRewardTable(EntityMQuestMissionReward[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.QuestMissionRewardId;
    }
}
