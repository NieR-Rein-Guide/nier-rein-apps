using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.View.UserInterface.Outgame
{
    class DataQuestCampaign : DataCampaign
    {
        // 0x20
        public QuestCampaignTargetType QuestCampaignTargetType { get; set; }
        // 0x24
        public QuestCampaignEffectType QuestCampaignEffectType { get; set; }
        // 0x28
        public int EffectValue { get; set; }
        // 0x2C
        public int TargetValue { get; set; }
    }
}
