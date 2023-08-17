using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Datamine.Extension;
using System.Text;

namespace NierReincarnation.Datamine.Model;

public class Event
{
    public string Name { get; init; }

    public EventQuestType EventType { get; init; }

    public DateTimeOffset StartDateTimeOffset { get; init; }

    public DateTimeOffset EndDateTimeOffset { get; init; }

    public List<EventDifficulty> Difficulties { get; init; }

    public bool HasMultiDifficulties => Difficulties?.Count > 1;

    public override string ToString()
    {
        StringBuilder stringBuilder = new();

        // Event Series
        WriteEventInfo(stringBuilder);

        // Event Quests
        WriteEventQuests(stringBuilder);

        return stringBuilder.ToString();
    }

    private void WriteEventInfo(StringBuilder stringBuilder)
    {
        stringBuilder.AppendLine($"{Name} {this.ToFormattedDateStr()}".ToHeader2());
    }

    private void WriteEventQuests(StringBuilder stringBuilder)
    {
        if (Difficulties == null) return;

        foreach (var difficulty in Difficulties)
        {
            var eventQuests = EventType == EventQuestType.TOWER
                ? difficulty.Quests.TakeLast(10).ToList()
                : difficulty.Quests;

            if (HasMultiDifficulties)
            {
                stringBuilder.AppendLine(difficulty.DifficultyType.ToFormattedStr().ToBold());
            }

            if (difficulty.CanGroupQuests() && difficulty.DifficultyType != DifficultyType.EX_HARD)
            {
                WriteGenericGroupedEventQuests(stringBuilder, eventQuests);
            }
            else
            {
                WriteGenericFullEventQuests(stringBuilder, eventQuests);
            }
        }
    }

    private void WriteGenericGroupedEventQuests(StringBuilder stringBuilder, List<EventQuest> eventQuests)
    {
        string questCount = eventQuests.Count > 1 ? $"1-{eventQuests.Count}" : "1";
        var firstEventQuest = eventQuests[0];

        if (firstEventQuest.AllRewardCount > 1)
        {
            stringBuilder.AppendLine($"Quest {questCount} - {firstEventQuest.AttributeType.ToFormattedStr()}");

            foreach (var firstClearReward in firstEventQuest.FirstClearRewards)
            {
                var prefix = firstEventQuest.PickupRewards.Count > 0 ? "(First Clear) " : string.Empty;
                stringBuilder.AppendLine($"{firstClearReward.Name} x{eventQuests.SelectMany(x => x.FirstClearRewards).Where(x => x.Name == firstClearReward.Name).Sum(x => x.Count)}".ToListItem());
            }

            foreach (var pickupReward in firstEventQuest.PickupRewards)
            {
                stringBuilder.AppendLine($"{pickupReward.Name} x{eventQuests.SelectMany(x => x.PickupRewards).Where(x => x.Name == pickupReward.Name).Sum(x => x.Count)}".ToListItem());
            }
        }
        else if (firstEventQuest.PickupRewards.Count == 0)
        {
            stringBuilder.AppendLine($"Quest {questCount} - {firstEventQuest.AttributeType.ToFormattedStr()} -> {firstEventQuest.FirstClearRewards[0].Name} x{eventQuests.SelectMany(x => x.FirstClearRewards).Sum(x => x.Count)}");
        }
        else
        {
            stringBuilder.AppendLine($"Quest {questCount} - {firstEventQuest.AttributeType.ToFormattedStr()} -> {firstEventQuest.PickupRewards[0].Name} x{eventQuests.SelectMany(x => x.PickupRewards).Sum(x => x.Count)}");
        }
    }

    private void WriteGenericFullEventQuests(StringBuilder stringBuilder, List<EventQuest> eventQuests)
    {
        foreach (var eventQuest in eventQuests)
        {
            var extraScheduleStr = DateTimeExtensions.GetExtraScheduleStr(StartDateTimeOffset, EndDateTimeOffset, eventQuest.StartDateTimeOffset, eventQuest.EndDateTimeOffset);

            if (eventQuest.AllRewardCount > 1)
            {
                stringBuilder.AppendLine($"{eventQuest.Name} - {eventQuest.AttributeType.ToFormattedStr()} ({eventQuest.RecommendedForce}) {extraScheduleStr}");

                foreach (var firstClearReward in eventQuest.FirstClearRewards)
                {
                    var prefix = eventQuest.PickupRewards.Count > 0 ? "(First Clear) " : string.Empty;
                    stringBuilder.AppendLine($"{prefix}{firstClearReward.Name} x{firstClearReward.Count}".ToListItem());
                }

                foreach (var pickupReward in eventQuest.PickupRewards)
                {
                    stringBuilder.AppendLine($"{pickupReward.Name} x{pickupReward.Count}".ToListItem());
                }
            }
            else if (eventQuest.PickupRewards.Count == 0)
            {
                stringBuilder.AppendLine($"{eventQuest.Name} - {eventQuest.AttributeType.ToFormattedStr()} ({eventQuest.RecommendedForce}) -> {eventQuest.FirstClearRewards[0].Name} x{eventQuest.FirstClearRewards[0].Count} {extraScheduleStr}");
            }
            else
            {
                stringBuilder.AppendLine($"{eventQuest.Name} - {eventQuest.AttributeType.ToFormattedStr()} ({eventQuest.RecommendedForce}) -> {eventQuest.PickupRewards[0].Name} x{eventQuest.PickupRewards[0].Count} {extraScheduleStr}");
            }
        }
    }
}
