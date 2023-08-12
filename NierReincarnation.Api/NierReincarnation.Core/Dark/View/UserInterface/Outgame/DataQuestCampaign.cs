using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.View.UserInterface.Outgame;

public class DataQuestCampaign : DataCampaign
{
    public QuestCampaignTargetType QuestCampaignTargetType { get; set; }

    public QuestCampaignEffectType QuestCampaignEffectType { get; set; }

    public int EffectValue { get; set; }

    public int TargetValue { get; set; }
}
