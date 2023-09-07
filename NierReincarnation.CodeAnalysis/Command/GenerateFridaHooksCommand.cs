using DustInTheWind.ConsoleTools.Controls.Menus;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NierReincarnation.CodeAnalysis.Model;
using System.Text;

namespace NierReincarnation.CodeAnalysis.Command;

public class GenerateFridaHooksCommand : ICommand
{
    private readonly GenerateFridaHooksCommandArg _arg;

    public bool IsActive => true;

    public GenerateFridaHooksCommand(GenerateFridaHooksCommandArg arg)
    {
        _arg = arg;
    }

    public void Execute()
    {
        List<ClassRecord> classRecords = DumpCsParser.Parse(_arg.DumpCsParserOptions);

        Console.WriteLine("Generating Frida hooks...");
        StringBuilder sb = new();
        List<string> offsets = new();

        foreach (ClassRecord classRecord in classRecords)
        {
            string className = classRecord.Class.Identifier.Text;

            foreach (var methodRecord in classRecord.Methods)
            {
                if (offsets.Contains(methodRecord.Offset)) continue;

                offsets.Add(methodRecord.Offset);
                string hookName = GenerateHookName(classRecord.Class, methodRecord.Method, true);
                //sb.Append("genericEnterHook(\"").Append(hookName).Append("\", ").Append(methodRecord.Offset).AppendLine(");");
                //sb.Append("genericLeaveHook(\"").Append(hookName).Append("\", ").Append(methodRecord.Offset).AppendLine(");");
                sb.Append("genericEnterLeaveHook(\"").Append(hookName).Append("\", ").Append(methodRecord.Offset).AppendLine(");");
            }
        }

        if (_arg.OutputToFile)
        {
            File.WriteAllText("hooks.txt", sb.ToString());
        }
        else
        {
            Console.WriteLine(sb.ToString());
        }
    }

    private static string GenerateHookName(ClassDeclarationSyntax classDeclaration, MethodDeclarationSyntax methodDeclaration, bool includeParameters = false)
    {
        string hookName = $"{classDeclaration.Identifier.Text}.{methodDeclaration.Identifier.Text}";

        if (includeParameters && methodDeclaration.ParameterList.Parameters.Count > 0)
        {
            hookName += $"({string.Join(", ", methodDeclaration.ParameterList.Parameters.Select(x => x.ToFullString().Replace("\"", "\\\"")))})";
        }

        return hookName;
    }
}

public class GenerateFridaHooksCommandArg
{
    public DumpCsParserOptions DumpCsParserOptions { get; init; } = null!;

    public bool OutputToFile { get; init; }
}
