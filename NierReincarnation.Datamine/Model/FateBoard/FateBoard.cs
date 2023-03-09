namespace NierReincarnation.Datamine.Model;

public class FateBoard
{
    public string Name { get; init; }

    public DateTimeOffset StartDateTimeOffset { get; init; }

    public DateTimeOffset EndDateTimeOffset { get; init; }

    public List<FateBoardSeason> Seasons { get; set; }

    public IEnumerable<EventQuest> Quests => Seasons.SelectMany(x => x.Quests);

    public IEnumerable<Reward> SeasonRewards => Seasons.SelectMany(x => x.SeasonRewards);
}
