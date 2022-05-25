using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMQuestCampaignTargetGroupTable : TableBase<EntityMQuestCampaignTargetGroup> // TypeDefIndex: 12133
    {
        // Fields
        private readonly Func<EntityMQuestCampaignTargetGroup, ValueTuple<int, int>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C574CC Offset: 0x2C574CC VA: 0x2C574CC
        public EntityMQuestCampaignTargetGroupTable(EntityMQuestCampaignTargetGroup[] sortedData):base(sortedData)
        {
            primaryIndexSelector = group => (group.QuestCampaignTargetGroupId, group.QuestCampaignTargetIndex);
        }

        // RVA: 0x2C575CC Offset: 0x2C575CC VA: 0x2C575CC
        public RangeView<EntityMQuestCampaignTargetGroup> FindRangeByQuestCampaignTargetGroupIdAndQuestCampaignTargetIndex(ValueTuple<int, int> min, ValueTuple<int, int> max, bool ascendant = true)
        {
            return FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, min, max, ascendant);
        }
    }
}
