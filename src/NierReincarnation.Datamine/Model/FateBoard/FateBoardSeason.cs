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
}
