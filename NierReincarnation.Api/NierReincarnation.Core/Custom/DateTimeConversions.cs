using System;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using NierReincarnation.Core.UnityEngine;

namespace NierReincarnation.Core.Custom
{
    // CUSTOM: Handles all date time related issues based on region data differences
    static class DateTimeConversions
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
            switch (Application.Language)
            {
                // HINT: For GL, CRON expressions are based on the PST timezone
                case Language.English:
                    return CalculatorDateTime.AsPst(dateTime);

                default:
                    throw new InvalidOperationException("Unsupported region for guerilla term.");
            }
        }

        private static DateTimeOffset RegionNow()
        {
            switch (Application.Language)
            {
                // HINT: For GL, CRON expressions are based on the PST timezone
                case Language.English:
                    return CalculatorDateTime.PstNow();

                default:
                    throw new InvalidOperationException("Unsupported region for guerilla term.");
            }
        }
    }
}
