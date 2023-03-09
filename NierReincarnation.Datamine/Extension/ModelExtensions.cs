using NierReincarnation.Datamine.Model;

namespace NierReincarnation.Datamine.Extension;

public static class ModelExtensions
{
    public static string ToFormattedDateStr(this Event @event) => DateTimeExtensions.ToFormattedDateStr(@event.StartDateTimeOffset, @event.EndDateTimeOffset);

    public static string ToFormattedDateStr(this LoginBonus loginBonus) => DateTimeExtensions.ToFormattedDateStr(loginBonus.StartDateTimeOffset, loginBonus.EndDateTimeOffset);

    public static string ToFormattedDateStr(this MissionGroup missionGroup) => DateTimeExtensions.ToFormattedDateStr(missionGroup.StartDateTimeOffset, missionGroup.EndDateTimeOffset);

    public static string ToFormattedDateStr(this FateBoard faateBoard) => DateTimeExtensions.ToFormattedDateStr(faateBoard.StartDateTimeOffset, faateBoard.EndDateTimeOffset);

    public static string ToFormattedDateStr(this FateBoardSeason faateBoardSeason) => DateTimeExtensions.ToFormattedDateStr(faateBoardSeason.StartDateTimeOffset, faateBoardSeason.EndDateTimeOffset);
}
