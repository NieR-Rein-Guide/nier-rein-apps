using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_quest_campaign_target_item_group")]
    public class EntityMQuestCampaignTargetItemGroup
    {
        [Key(0)]
        public int QuestCampaignTargetItemGroupId { get; set; } // 0x10

        [Key(1)]
        public int TargetIndex { get; set; } // 0x14

        [Key(2)]
        public PossessionType PossessionType { get; set; } // 0x18

        [Key(3)]
        public int PossessionId { get; set; } // 0x1C

        [Key(4)]
        public int Count { get; set; } // 0x20
    }
}
