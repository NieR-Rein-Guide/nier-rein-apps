using DustInTheWind.ConsoleTools.Controls.InputControls;
using DustInTheWind.ConsoleTools.Controls.Menus;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public class SearchDatabaseMenuCommand : AbstractMenuCommand
{
    public override bool IsActive => Program.AppSettings.IsSetup;

    public override bool UseApi => false;

    public override bool UseLocalizations => false;

    public override Task ExecuteAsync()
    {
        Console.Clear();
        BuildMenu().Display();

        return Task.CompletedTask;
    }

    private static TextMenu BuildMenu()
    {
        TextMenu textMenu = MenuExtensions.GetTextMenu();

        textMenu.AddItems(new List<TextMenuItem>
            {
                new TextMenuItem
                {
                    Id = "0",
                    Text = "Go Back",
                    Command = new GoBackMenuCommand()
                },
                new TextMenuItem
                {
                    Id = "1",
                    Text = "Exact Match",
                    Command = new ExactSearchMenuCommand()
                },
                new TextMenuItem
                {
                    Id = "2",
                    Text = "Partial Match",
                    Command = new PartialSearchMenuCommand()
                },
                new TextMenuItem
                {
                    Id = "3",
                    Text = "Date",
                    Command = new DateSearchMenuCommand()
                }
            });

        return textMenu;
    }

    #region Inner Commands

    private class ExactSearchMenuCommand : AbstractMenuCommand
    {
        public override async Task ExecuteAsync()
        {
            List<string> matches = await new SearchDatabaseCommand().ExecuteAsync(new SearchDatabaseCommandArg
            {
                SearchType = SearchType.ExactKeyword,
                SearchTerm = StringValue.QuickRead("Keyword:")
            });

            foreach (string match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }

    private class PartialSearchMenuCommand : AbstractMenuCommand
    {
        public override async Task ExecuteAsync()
        {
            List<string> matches = await new SearchDatabaseCommand().ExecuteAsync(new SearchDatabaseCommandArg
            {
                SearchType = SearchType.PartialKeyword,
                SearchTerm = StringValue.QuickRead("Keyword:")
            });

            foreach (string match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }

    private class DateSearchMenuCommand : AbstractMenuCommand
    {
        public override async Task ExecuteAsync()
        {
            List<string> matches = await new SearchDatabaseCommand().ExecuteAsync(new SearchDatabaseCommandArg
            {
                SearchType = SearchType.Date,
                FromDate = DateTimeOffset.UtcNow.AddDays(-Int32Value.QuickRead("Days From:")),
                ToDate = DateTimeOffset.UtcNow.AddDays(Int32Value.QuickRead("Days To:"))
            });

            foreach (string match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }

    #endregion Inner Commands
}
