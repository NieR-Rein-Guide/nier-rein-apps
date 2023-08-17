using NierReincarnation.Datamine.Extension;
using System.Text;

namespace NierReincarnation.Datamine.Model;

public class FateBoard
{
    public string Name { get; init; }

    public DateTimeOffset StartDateTimeOffset { get; init; }

    public DateTimeOffset EndDateTimeOffset { get; init; }

    public List<FateBoardSeason> Seasons { get; set; }

    public IEnumerable<EventQuest> Quests => Seasons.SelectMany(x => x.Quests);

    public IEnumerable<Reward> SeasonRewards => Seasons.SelectMany(x => x.SeasonRewards);

    public override string ToString()
    {
        StringBuilder stringBuilder = new();

        // Season info
        foreach (var fateBoardSeason in Seasons)
        {
            stringBuilder.AppendLine($"{Name} - Season {fateBoardSeason.SeasonNumber} {this.ToFormattedDateStr()}".ToBold());

            // Season stages
            foreach (var fateBoardStage in fateBoardSeason.Stages)
            {
                stringBuilder.AppendLine(fateBoardStage.ToString());
            }

            // Season rewards
            stringBuilder.AppendLine(fateBoardSeason.ToString());
        }

        return stringBuilder.ToString();
    }
}
