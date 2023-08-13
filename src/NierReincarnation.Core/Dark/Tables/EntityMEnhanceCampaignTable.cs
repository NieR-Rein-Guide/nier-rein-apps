using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMEnhanceCampaignTable : TableBase<EntityMEnhanceCampaign>
{
    private readonly Func<EntityMEnhanceCampaign, int> primaryIndexSelector;

    public EntityMEnhanceCampaignTable(EntityMEnhanceCampaign[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.EnhanceCampaignId;
    }
}
