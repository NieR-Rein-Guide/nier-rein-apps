using DustInTheWind.ConsoleTools.Controls.Menus;
using NierReincarnation.CodeAnalysis.Model;

namespace NierReincarnation.CodeAnalysis.Command;

public class PrintClassMethodsCommand : ICommand
{
    private readonly PrintClassMethodsCommandArg _arg;

    public bool IsActive => true;

    public PrintClassMethodsCommand(PrintClassMethodsCommandArg arg)
    {
        _arg = arg;
    }

    public void Execute()
    {
        List<ClassRecord> classRecords = DumpCsParser.Parse(_arg.DumpCsParserOptions);

        foreach (ClassRecord classRecord in classRecords.OrderBy(x => x.Class.Identifier.Text))
        {
            Console.WriteLine($"{classRecord.Class.Identifier.Text} ({classRecord.Methods.Count})");

            foreach (MethodRecord methodRecord in classRecord.Methods)
            {
                Console.WriteLine("- " + methodRecord.Method.Identifier.Text + $" {methodRecord.Offset}");
            }
        }
    }
}

public class PrintClassMethodsCommandArg
{
    public DumpCsParserOptions DumpCsParserOptions { get; init; } = null!;
}
