using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;

namespace NierReincarnation.Core.Dark.View.UserInterface;

public class EventQuestChapterData
{
    public int EventQuestChapterId { get; set; }

    public EventQuestType EventQuestType { get; set; }

    public string EventQuestName { get; set; }

    public List<DifficultyType> EventQuestChapterDifficultyTypes { get; set; }

    // CUSTOM: Helpful properties and methods for public information
    public long StartDatetime { get; set; }

    public long EndDatetime { get; set; }

    public DateTime StartDate => DateTime.UnixEpoch + TimeSpan.FromMilliseconds(StartDatetime);

    public DateTime EndDate => DateTime.UnixEpoch + TimeSpan.FromMilliseconds(EndDatetime);

    public bool IsCurrent()
    {
        return CalculatorDateTime.IsWithinThePeriod(StartDatetime, EndDatetime);
    }

    public bool IsFuture()
    {
        var now = CalculatorDateTime.UnixTimeNow();

        return !IsCurrent() && StartDate.Year < 2099 && EndDatetime > now;
    }
}
