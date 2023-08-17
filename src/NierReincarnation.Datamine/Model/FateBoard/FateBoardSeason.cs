using NierReincarnation.Datamine.Extension;
using System.Text;

namespace NierReincarnation.Datamine.Model;

public class FateBoardSeason
{
    public int SeasonNumber { get; init; }

    public DateTimeOffset StartDateTimeOffset { get; init; }

    public DateTimeOffset EndDateTimeOffset { get; init; }

    public List<FateBoardStage> Stages { get; set; }

    public IEnumerable<FateBoardQuest> Quests => Stages.SelectMany(x => x.Quests);

    public IEnumerable<Reward> SeasonRewards => Stages.SelectMany(x => x.SeasonRewards);

    public IEnumerable<FateBoardQuest> SeasonRewardQuests => Stages.SelectMany(x => x.Quests).Where(x => x.SeasonRewards.Count > 0);

    public override string ToString()
    {
        StringBuilder stringBuilder = new();

        stringBuilder.AppendLine($"Season {SeasonNumber} Rewards");

        foreach (var seasonRewardQuestGroup in SeasonRewardQuests.GroupBy(x => string.Join(",", x.SeasonRewards.Select(x => x.ToString()))))
        {
            var first = seasonRewardQuestGroup.First();
            if (seasonRewardQuestGroup.Count() > 1)
            {
                var last = seasonRewardQuestGroup.Last();
                stringBuilder.AppendLine($"{first.Name} - {last.Name}".ToListItem());
            }
            else
            {
                stringBuilder.AppendLine(first.Name.ToListItem());
            }

            foreach (var reward in first.SeasonRewards)
            {
                stringBuilder.AppendLine(reward.ToString().ToListItem(true));
            }
        }

        return stringBuilder.ToString();
    }
}
