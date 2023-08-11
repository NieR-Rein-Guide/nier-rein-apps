using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using NierReincarnation.Core.UnityEngine;

namespace NierReincarnation.Core.Custom;

// CUSTOM: Handles all date time related issues based on region data differences
public static class DateTimeConversions
{
    public static Term GetGuerillaTerm(DateTime termStart, DateTime termEnd)
    {
        var convertedStart = AsRegionDateTime(termStart);
        var convertedEnd = AsRegionDateTime(termEnd);

        return new Term(convertedStart, convertedEnd);
    }

    public static DateTimeOffset GetTodayChangeDateTime()
    {
        var now = RegionNow();
        return now.Subtract(now.TimeOfDay);
    }

    private static DateTimeOffset AsRegionDateTime(DateTime dateTime)
    {
        return Application.SystemLanguage switch
        {
            // HINT: For GL, CRON expressions are based on the PST timezone
            SystemLanguage.English => CalculatorDateTime.AsPst(dateTime),
            _ => throw new InvalidOperationException("Unsupported region for guerilla term."),
        };
    }

    private static DateTimeOffset RegionNow()
    {
        return Application.SystemLanguage switch
        {
            // HINT: For GL, CRON expressions are based on the PST timezone
            SystemLanguage.English => CalculatorDateTime.PstNow(),
            _ => throw new InvalidOperationException("Unsupported region for guerilla term."),
        };
    }
}
