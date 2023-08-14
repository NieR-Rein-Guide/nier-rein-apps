using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMQuestCampaignTable : TableBase<EntityMQuestCampaign>
{
    private readonly Func<EntityMQuestCampaign, int> primaryIndexSelector;

    public EntityMQuestCampaignTable(EntityMQuestCampaign[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.QuestCampaignId;
    }
}
