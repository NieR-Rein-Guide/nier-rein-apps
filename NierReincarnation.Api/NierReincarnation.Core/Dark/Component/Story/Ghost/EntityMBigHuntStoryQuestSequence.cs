namespace NierReincarnation.Core.Dark.Component.Story.Ghost
{
    public class EntityMBigHuntStoryQuestSequence
    {
        public int BigHuntQuestId { get; set; }
        public int QuestId { get; set; }
        public int BigHuntQuestScoreCoefficientId { get; set; }

        public void Setup(int BigHuntQuestId, int QuestId, int BigHuntQuestScoreCoefficientId)
        {
            this.BigHuntQuestId = BigHuntQuestId;
            this.QuestId = QuestId;
            this.BigHuntQuestScoreCoefficientId = BigHuntQuestScoreCoefficientId;
        }
    }
}
