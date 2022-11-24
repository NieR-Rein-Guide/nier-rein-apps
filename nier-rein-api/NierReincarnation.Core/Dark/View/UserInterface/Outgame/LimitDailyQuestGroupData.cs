using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.View.UserInterface.Outgame
{
    public class LimitDailyQuestGroupData
    {
        private EntityMEventQuestDailyGroupMessage _message;

        public int EventQuestDailyGroupId { get; set; } // 0x10
        public long EndUnixTime { get; set; }   // 0x18
        public List<LimitDailyQuestData> Quests { get; set; }   // 0x20
        public EntityMEventQuestDailyGroupMessage EntityMEventQuestDailyGroupMessage { set => _message = value; }
        public List<DataPossessionItem> CompleteRewards { get; set; } // 0x30
        public bool IsQuestAllClear { get; set; }   // 0x38
        public string DailyMessage { get; set; }    // 0x40
        public long CreatedDataUnixTime { get; set; }   // 0x48
    }
}
