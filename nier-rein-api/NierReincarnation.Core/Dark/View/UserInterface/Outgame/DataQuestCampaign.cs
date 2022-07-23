using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.View.UserInterface.Outgame
{
    public class DataQuestCampaign : DataCampaign
    {
        // 0x28
        public QuestCampaignTargetType QuestCampaignTargetType { get; set; }
        // 0x2C
        public QuestCampaignEffectType QuestCampaignEffectType { get; set; }
        // 0x30
        public int EffectValue { get; set; }
        // 0x34
        public int TargetValue { get; set; }
    }
}
