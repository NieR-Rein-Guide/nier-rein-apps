using DustInTheWind.ConsoleTools.Controls.Menus;
using DustInTheWind.ConsoleTools.Controls.Spinners;

namespace NierReincarnation.Datamine.Extension;

public static class MenuExtensions
{
    public static TextMenu GetTextMenu(string title = null)
    {
        return new TextMenu()
        {
            TitleText = title ?? "Choose an option",
            InvalidOptionText = "Mama couldn't find that option, try again",
            QuestionText = "Mama wants you to pick: ",
            OptionDisabledText = "Mama can't do this right now"
        };
    }

    public static Spinner GetSpinner()
    {
        return new Spinner
        {
            Label = "Setting up the cage...",
            DoneText = "Done",
            EnsureBeginOfLine = true
        };
    }
}
