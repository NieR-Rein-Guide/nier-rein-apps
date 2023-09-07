using DustInTheWind.ConsoleTools.Controls;
using DustInTheWind.ConsoleTools.Controls.Menus;
using NierReincarnation.CodeAnalysis.Command;

namespace NierReincarnation.CodeAnalysis;

public static class Program
{
    private const string DumpPath = @"D:\Archive\Nier Reincarnation\dump\dump.cs";

    private static void Main(string[] _)
    {
        try
        {
            while (true)
            {
                Console.Clear();
                BuildMenu().Display();
                Pause.QuickDisplay();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);

            if (ex.InnerException != null)
            {
                Console.WriteLine("------------------------");
                Console.WriteLine(ex.InnerException.Message);
                Console.WriteLine(ex.InnerException.StackTrace);
            }

            Pause.QuickDisplay();
        }
    }

    private static TextMenu BuildMenu()
    {
        TextMenu textMenu = new()
        {
            TitleText = "Nier Re[in]carnation Code Analysis"
        };

        textMenu.AddItems(new List<TextMenuItem>
        {
            new TextMenuItem
            {
                Id = "1",
                Text = "Print classes and methods",
                Command = new PrintClassMethodsCommand(new PrintClassMethodsCommandArg
                {
                    DumpCsParserOptions = new DumpCsParserOptions
                    {
                        IncludeMethods = true,
                        DumpPath = DumpPath
                    }
                })
            },
            new TextMenuItem
            {
                Id = "2",
                Text = "Generate Frida hooks",
                Command = new GenerateFridaHooksCommand(new GenerateFridaHooksCommandArg
                {
                    DumpCsParserOptions = new DumpCsParserOptions
                    {
                        IncludeMethods = true,
                        DumpPath = DumpPath
                    }
                })
            }
        });

        return textMenu;
    }
}
