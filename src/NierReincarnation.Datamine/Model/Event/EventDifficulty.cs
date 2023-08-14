using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Datamine.Model;

public class EventDifficulty
{
    public DifficultyType DifficultyType { get; init; }

    public List<EventQuest> Quests { get; init; }

    public bool CanGroupQuests()
    {
        if (Quests == null || Quests.Count == 0) return false;

        var firstQuest = Quests[0];

        if (Quests.Any(x => x.AttributeType != firstQuest.AttributeType)) return false;

        if (Quests.Any(x => !x.AllRewards.SequenceEqual(firstQuest.AllRewards))) return false;

        return true;
    }
}
