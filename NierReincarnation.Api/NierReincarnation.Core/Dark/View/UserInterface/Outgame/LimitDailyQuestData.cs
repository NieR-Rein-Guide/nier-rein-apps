using NierReincarnation.Core.Dark.Component.Story;
using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.View.UserInterface.Outgame;

public class LimitDailyQuestData
{
    private int _stamina;

    public IQuest Quest { get; set; }

    public EventQuestType EventQuestType { get; set; }

    public bool IsClearQuest { get; set; }

    public bool IsDailyQuestCleared { get; set; }

    public QuestDisplayAttributeType AttributeType { get; set; }

    public int Stamina { set => _stamina = value; }

    public int RecommendPower { get; set; }

    public bool IsLock { get; set; }

    public string LockText { get; set; }

    public DataPossessionItem QuestFirstReward { get; set; }

    public DataPossessionItem[] QuestDropMaterials { get; set; }

    public QuestMissionData[] MissionData { get; set; }

    public Action<LimitDailyQuestData> OnTap { get; set; }

    public DataCampaigns Campaigns { get; set; }

    // CUSTOM: Access to total clear counts
    public int SceneId { get; set; }
}
