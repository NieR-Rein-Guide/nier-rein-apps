namespace NierReincarnation.Datamine.Model;

public class FateBoardStage
{
    public int StageNumber { get; init; }

    public List<FateBoardDifficulty> Difficulties { get; init; }

    public bool HasMultiDifficulties => Difficulties?.Count > 1;

    public IEnumerable<FateBoardQuest> Quests => Difficulties.SelectMany(x => x.Quests);

    public IEnumerable<Reward> SeasonRewards => Difficulties.SelectMany(x => x.SeasonRewards);
}
