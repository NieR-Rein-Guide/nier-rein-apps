using System;

namespace NierReincarnation.Core.Dark.View.UserInterface.Outgame
{
    public class Term
    {
        // 0x10
        public DateTimeOffset Start { get; set; }
        // 0x18
        public DateTimeOffset End { get; set; }

        public Term(DateTimeOffset start, DateTimeOffset end)
        {
            Start = start;
            End = end;
        }
    }
}
