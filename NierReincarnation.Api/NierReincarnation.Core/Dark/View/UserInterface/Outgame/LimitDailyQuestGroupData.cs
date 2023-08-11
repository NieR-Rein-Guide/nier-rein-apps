using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.View.UserInterface.Outgame
{
    public class LimitDailyQuestGroupData
    {
        private EntityMEventQuestDailyGroupMessage _message;

        public int EventQuestDailyGroupId { get; set; }
        public long EndUnixTime { get; set; }  
        public List<LimitDailyQuestData> Quests { get; set; }  
        public EntityMEventQuestDailyGroupMessage EntityMEventQuestDailyGroupMessage { set => _message = value; }
        public List<DataPossessionItem> CompleteRewards { get; set; }
        public bool IsQuestAllClear { get; set; }  
        public string DailyMessage { get; set; }   
        public long CreatedDataUnixTime { get; set; }  
    }
}
