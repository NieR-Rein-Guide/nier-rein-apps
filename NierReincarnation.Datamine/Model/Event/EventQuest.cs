using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Datamine.Model;

public class EventQuest
{
    public int QuestId { get; init; }

    public string Name { get; init; }

    public QuestDisplayAttributeType AttributeType { get; init; }

    public DateTimeOffset? StartDateTimeOffset { get; init; }

    public DateTimeOffset? EndDateTimeOffset { get; init; }

    public int RecommendedForce { get; init; }

    public List<Reward> FirstClearRewards { get; init; }

    public List<Reward> PickupRewards { get; init; }

    public List<Reward> AllRewards => FirstClearRewards.Union(PickupRewards).ToList();

    public int AllRewardCount => FirstClearRewards.Count + PickupRewards.Count;
}
