using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Datamine.Model;

public class FateBoardDifficulty
{
    public DifficultyType DifficultyType { get; init; }

    public List<FateBoardQuest> Quests { get; init; }

    public List<MissionReward> MissionRewards { get; init; }

    public List<Reward> Treasures { get; init; }

    public IEnumerable<Reward> SeasonRewards => Quests.SelectMany(x => x.SeasonRewards);

    public bool CanGroupQuests()
    {
        if (Quests == null || Quests.Count == 0) return false;

        var firstQuest = Quests[0];

        if (Quests.Any(x => x.AttributeType != firstQuest.AttributeType)) return false;

        if (Quests.Any(x => !x.AllRewards.SequenceEqual(firstQuest.AllRewards))) return false;

        return true;
    }
}
