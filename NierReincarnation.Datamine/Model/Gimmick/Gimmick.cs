using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Datamine.Model;

public class Gimmick
{
    public int ChapterId { get; init; }

    public int SequenceId { get; init; }

    public GimmickType GimmickType { get; init; }

    public FlowType FlowType { get; init; }

    public DateTimeOffset? StartDateTimeOffset { get; init; }

    public DateTimeOffset? EndDateTimeOffset { get; init; }

    public DateTimeOffset ProgressStartDateTimeOffset { get; init; }

    public long ProgressRequireHour { get; init; }

    public int IntervalValue { get; init; }

    public int MaxValue { get; init; }

    public int OrnamentCount { get; init; }

    public int IconDifficultyValue { get; init; }

    public Reward Reward { get; init; }

    public List<string> ClearConditions { get; init; }

    public int NextSequenceId { get; set; }

    public Gimmick NextGimmick { get; set; }
}
