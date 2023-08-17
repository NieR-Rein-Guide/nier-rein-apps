using NierReincarnation.Datamine.Extension;
using System.Text;

namespace NierReincarnation.Datamine.Model;

public class MissionGroup
{
    public string Name { get; init; }

    public DateTimeOffset StartDateTimeOffset { get; init; }

    public DateTimeOffset EndDateTimeOffset { get; init; }

    public List<Mission> Missions { get; init; }

    public override string ToString()
    {
        StringBuilder stringBuilder = new();

        // Mission Group
        WriteMissionGroupInfo(stringBuilder);

        // Mission Group Missions
        WriteMissionGroupMissions(stringBuilder);

        return stringBuilder.ToString();
    }

    private void WriteMissionGroupInfo(StringBuilder stringBuilder)
    {
        stringBuilder.AppendLine($"{Name} {this.ToFormattedDateStr()}".ToBold());
    }

    private void WriteMissionGroupMissions(StringBuilder stringBuilder)
    {
        if (Missions == null) return;

        foreach (var mission in Missions)
        {
            var extraScheduleStr = DateTimeExtensions.GetExtraScheduleStr(StartDateTimeOffset, EndDateTimeOffset, mission.StartDateTimeOffset, mission.EndDateTimeOffset);
            stringBuilder.AppendLine($"{mission.Name} -> {mission.Reward.Name} x{mission.Reward.Count} {extraScheduleStr}");
        }
    }
}
