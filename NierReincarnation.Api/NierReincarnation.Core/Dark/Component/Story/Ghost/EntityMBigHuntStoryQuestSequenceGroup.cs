namespace NierReincarnation.Core.Dark.Component.Story.Ghost
{
    public class EntityMBigHuntStoryQuestSequenceGroup
    {
        public int BigHuntQuestGroupId { get; set; }
        public int SortOrder { get; set; }
        public int BigHuntQuestId { get; set; }

        public void Setup(int BigHuntQuestGroupId, int SortOrder, int BigHuntQuestId)
        {
            this.BigHuntQuestGroupId = BigHuntQuestGroupId;
            this.SortOrder = SortOrder;
            this.BigHuntQuestId = BigHuntQuestId;
        }
    }
}
