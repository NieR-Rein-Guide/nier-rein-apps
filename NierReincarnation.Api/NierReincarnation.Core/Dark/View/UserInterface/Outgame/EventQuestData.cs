using NierReincarnation.Core.Dark.Component.Story;
using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.View.UserInterface.Outgame
{
    public class EventQuestData
    {
        private int stamina;

       
        public IQuest Quest { get; set; }
       
        public bool IsClearQuest { get; set; }
       
        public QuestDisplayAttributeType AttributeType { get; set; }
       
        public string QuestName { get; set; }
       
        public int Stamina { set => stamina = value; }
       
        public int RecommendPower { get; set; }
       
        public DataPossessionItem QuestFirstReward { get; set; }
       
        public bool IsLock { get; set; }
       
        public string LockText { get; set; }
       
        public bool IsStoryQuest { get; set; }
       
        public QuestMissionData[] MissionData { get; set; }

       
        public DataCampaigns Campaigns { get; set; }

        // CUSTOM: Determines if a quest should not be shown to the user (cleared and marked as no show; timeframe unavilable; etc.)
        public bool IsAvailable { get; set; }

        // CUSTOM: Determines SceneId
        public int SceneId { get; set; }

        // CUSTOM: Access to total clear counts
        public int ClearCount { get; set; }
    }
}
