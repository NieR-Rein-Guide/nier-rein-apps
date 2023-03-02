using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMQuestCampaignEffectGroupTable : TableBase<EntityMQuestCampaignEffectGroup> // TypeDefIndex: 12129
    {
        // Fields
        private readonly Func<EntityMQuestCampaignEffectGroup, ValueTuple<int, int>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C570CC Offset: 0x2C570CC VA: 0x2C570CC
        public EntityMQuestCampaignEffectGroupTable(EntityMQuestCampaignEffectGroup[] sortedData):base(sortedData)
        {
            primaryIndexSelector = group => (group.QuestCampaignEffectGroupId, (int)group.QuestCampaignEffectType);
        }

        // RVA: 0x2C571CC Offset: 0x2C571CC VA: 0x2C571CC
        public RangeView<EntityMQuestCampaignEffectGroup> FindRangeByQuestCampaignEffectGroupIdAndQuestCampaignEffectType(ValueTuple<int, int> min, ValueTuple<int, int> max, bool ascendant = true)
        {
            return FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, min, max, ascendant);
        }
    }
}
