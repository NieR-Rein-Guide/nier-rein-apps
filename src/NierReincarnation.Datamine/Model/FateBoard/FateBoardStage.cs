using NierReincarnation.Datamine.Extension;
using System.Text;

namespace NierReincarnation.Datamine.Model;

public class FateBoardStage
{
    public int StageNumber { get; init; }

    public List<FateBoardDifficulty> Difficulties { get; init; }

    public bool HasMultiDifficulties => Difficulties?.Count > 1;

    public IEnumerable<FateBoardQuest> Quests => Difficulties.SelectMany(x => x.Quests);

    public IEnumerable<Reward> SeasonRewards => Difficulties.SelectMany(x => x.SeasonRewards);

    public override string ToString()
    {
        StringBuilder stringBuilder = new();

        stringBuilder.AppendLine($"Stage {StageNumber}");

        foreach (var difficulty in Difficulties)
        {
            if (HasMultiDifficulties)
            {
                stringBuilder.AppendLine($"{difficulty.DifficultyType.ToFormattedStr()}".ToBold());
            }

            stringBuilder.AppendLine("Quests".ToListItem());
            foreach (var stageQuest in difficulty.Quests)
            {
                stringBuilder.AppendLine($"{stageQuest.Name} - {stageQuest.AttributeType.ToFormattedStr()} ({stageQuest.RecommendedForce}) -> {stageQuest.FirstClearRewards.FirstOrDefault()}".ToListItem(true));
            }

            stringBuilder.AppendLine("Missions Rewards".ToListItem());
            foreach (var reward in difficulty.MissionRewards)
            {
                stringBuilder.AppendLine($"{reward.MissionName} -> {reward}".ToListItem(true));
            }

            stringBuilder.AppendLine("Treasures".ToListItem());
            foreach (var treasure in difficulty.Treasures)
            {
                stringBuilder.AppendLine(treasure.ToString().ToListItem(true));
            }
        }

        return stringBuilder.ToString();
    }
}
