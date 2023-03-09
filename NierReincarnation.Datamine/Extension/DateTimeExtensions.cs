using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using System.Globalization;

namespace NierReincarnation.Datamine.Extension;

public static class DateTimeExtensions
{
    public static long Yesterday => DateTimeOffset.UtcNow.AddDays(-1).ToUnixTimeMilliseconds();

    public static long Now => DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

    public static long NextYear => DateTimeOffset.UtcNow.AddYears(1).ToUnixTimeMilliseconds();

    public static DateTimeOffset YesterdayV2 => DateTimeOffset.UtcNow.AddDays(-1);

    public static DateTimeOffset NowV2 => DateTimeOffset.UtcNow;

    public static DateTimeOffset NextYearV2 => DateTimeOffset.UtcNow.AddYears(1);

    public static bool IsCurrentOrFuture(long startDateTime, long endDateTime)
    {
        return endDateTime < NextYear &&
            ((Now > startDateTime && Now < endDateTime) || Now < startDateTime);
    }

    public static string ToFormattedDate(this long unixTimeMs, bool @long = false, bool useDiscordDate = true) => CalculatorDateTime.FromUnixTime(unixTimeMs).ToFormattedDate(@long, useDiscordDate);

    public static string ToFormattedDate(this DateTimeOffset dateTimeOffset, bool @long = false, bool useDiscordDate = true)
    {
        return useDiscordDate && Program.AppSettings.UseDiscordDates
            ? $"<t:{dateTimeOffset.ToUnixTimeSeconds()}:R>"
            : @long
                ? dateTimeOffset.ToLocalTime().ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
                : dateTimeOffset.ToLocalTime().ToString("dd/MM", CultureInfo.InvariantCulture);
    }

    public static string ToFormattedDateStr(long startDateTime, long endDateTime, bool @long = false) => $"({startDateTime.ToFormattedDate(@long)} ~ {endDateTime.ToFormattedDate(@long)})";

    public static string ToFormattedDateStr(DateTimeOffset startDateTime, DateTimeOffset endDateTime, bool @long = false) => $"({startDateTime.ToFormattedDate(@long)} ~ {endDateTime.ToFormattedDate(@long)})";

    public static string GetExtraScheduleStr(DateTimeOffset start, DateTimeOffset end, DateTimeOffset? compareStart, DateTimeOffset? compareEnd)
    {
        // Same schedule as parent event or daily quest
        if (!compareStart.HasValue ||
            compareEnd - compareStart <= TimeSpan.FromDays(1) ||
            (compareStart == start && compareEnd == end))
        {
            return string.Empty;
        }
        // Different start and end date
        else if (compareStart.Value != start && compareEnd.Value != end)
        {
            return $"({compareStart.Value.ToFormattedDate()} ~ {compareEnd.Value.ToFormattedDate()})";
        }
        // Different start date
        else if (compareStart.Value != start)
        {
            return $"({compareStart.Value.ToFormattedDate()} ~ )";
        }
        // Different end date
        else if (compareEnd.Value != end)
        {
            return $"( ~ {compareEnd.Value.ToFormattedDate()})";
        }
        else
        {
            return string.Empty;
        }
    }
}
