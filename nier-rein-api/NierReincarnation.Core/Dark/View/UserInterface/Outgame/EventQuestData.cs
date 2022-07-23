using NierReincarnation.Core.Dark.Component.Story;
using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.View.UserInterface.Outgame
{
    public class EventQuestData
    {
        private int stamina;

        // 0x10
        public IQuest Quest { get; set; }
        // 0x18
        public bool IsClearQuest { get; set; }
        // 0x1C
        public QuestDisplayAttributeType AttributeType { get; set; }
        // 0x20
        public string QuestName { get; set; }
        // 0x28
        public int Stamina { set => stamina = value; }
        // 0x2C
        public int RecommendPower { get; set; }
        // 0x30
        public DataPossessionItem QuestFirstReward { get; set; }
        // 0x38
        public bool IsLock { get; set; }
        // 0x40
        public string LockText { get; set; }
        // 0x48
        public bool IsStoryQuest { get; set; }
        // 0x50
        public QuestMissionData[] MissionData { get; set; }

        // 0x68
        public DataCampaigns Campaigns { get; set; }

        // CUSTOM: Determines if a quest should not be shown to the user (cleared and marked as no show; timeframe unavilable; etc.)
        public bool IsAvailable { get; set; }

        // CUSTOM: Determines SceneId
        public int SceneId { get; set; }

        // CUSTOM: Access to total clear counts
        public int ClearCount { get; set; }
    }
}
