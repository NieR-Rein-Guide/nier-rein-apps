using System.Collections.Generic;
using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.View.UserInterface.Outgame
{
    public class BigHuntBossQuestData
    {
        public int RemainChallengeCount { get; set; }
        public long HighScore { get; set; }
        public bool IsClear { get; set; }
        public int BigHuntBossQuestId { get; set; }
        public List<BigHuntQuestData> BigHuntQuestDataList { get; set; }
        public string BossQuestName { get; set; }
        public int BigHuntScoreRewardGroupScheduleId { get; set; }
        public int BigHuntBossGradeGroupId { get; set; }
        public int BossQuestAssetId { get; set; }
        public AttributeType AttributeType { get; set; }
	}
}
