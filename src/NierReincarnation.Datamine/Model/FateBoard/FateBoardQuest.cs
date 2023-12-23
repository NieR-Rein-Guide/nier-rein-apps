namespace NierReincarnation.Datamine.Model;

public class FateBoardQuest : EventQuest
{
    public List<Reward> SeasonRewards { get; init; }

    public FateBoardQuest()
    { }

    public FateBoardQuest(EventQuest eventQuest)
    {
        QuestId = eventQuest.QuestId;
        Name = eventQuest.Name;
        AttributeType = eventQuest.AttributeType;
        StartDateTimeOffset = eventQuest.StartDateTimeOffset;
        EndDateTimeOffset = eventQuest.EndDateTimeOffset;
        RecommendedForce = eventQuest.RecommendedForce;
        FirstClearRewards = eventQuest.FirstClearRewards;
        PickupRewards = eventQuest.PickupRewards;
        SeasonRewards = [];
    }
}
