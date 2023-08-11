using System;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;

namespace NierReincarnation.Core.Dark.View.UserInterface.Outgame;

public class Term
{
    // CUSTOM: Get term of current day
    public static Term CurrentDay => new Term(CalculatorDateTime.GetTodayChangeDateTime(), CalculatorDateTime.GetNextChangeDateTime());

   
    public DateTimeOffset Start { get; set; }
   
    public DateTimeOffset End { get; set; }

    public Term(DateTimeOffset start, DateTimeOffset end)
    {
        Start = start;
        End = end;
    }
}
