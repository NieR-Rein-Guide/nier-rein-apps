namespace NierReincarnation.Context.Models;

public class BattleDrops
{
    public static BattleDrops Empty = new(Array.Empty<QuestReward>(), Array.Empty<QuestReward>(), Array.Empty<QuestReward>(), Array.Empty<QuestReward>());

    public QuestReward[] DropRewards { get; }

    public QuestReward[] FirstClearRewards { get; }

    public QuestReward[] MissionRewards { get; }

    public QuestReward[] MissionCompleteRewards { get; }

    public BattleDrops(QuestReward[] drops, QuestReward[] firstClears, QuestReward[] missions, QuestReward[] missionsComplete)
    {
        DropRewards = drops;
        FirstClearRewards = firstClears;
        MissionRewards = missions;
        MissionCompleteRewards = missionsComplete;
    }

    public IEnumerable<QuestReward> EnumerateAll()
    {
        return DropRewards.Concat(FirstClearRewards).Concat(MissionRewards).Concat(MissionCompleteRewards);
    }
}
