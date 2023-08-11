using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMEnhanceCampaignTargetGroupTable : TableBase<EntityMEnhanceCampaignTargetGroup>
{
    private readonly Func<EntityMEnhanceCampaignTargetGroup, (int, int)> primaryIndexSelector;

    public EntityMEnhanceCampaignTargetGroupTable(EntityMEnhanceCampaignTargetGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.EnhanceCampaignTargetGroupId, element.EnhanceCampaignTargetIndex);
    }

    public RangeView<EntityMEnhanceCampaignTargetGroup> FindRangeByEnhanceCampaignTargetGroupIdAndEnhanceCampaignTargetIndex(ValueTuple<int, int> min, ValueTuple<int, int> max, bool ascendant = true) =>
        FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, min, max, ascendant);
}
