namespace NierReincarnation.Core.Dark.Component.Story.Ghost;

public class EntityMBigHuntStoryQuestChapter
{
    public int BigHuntBossQuestId { get; set; }
    public int BigHuntQuestGroupId { get; set; }

    public void Setup(int BigHuntBossQuestId, int BigHuntQuestGroupId)
    {
        this.BigHuntBossQuestId = BigHuntBossQuestId;
        this.BigHuntQuestGroupId = BigHuntQuestGroupId;
    }
}
