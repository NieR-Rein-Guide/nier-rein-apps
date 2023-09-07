using DustInTheWind.ConsoleTools.Controls.Spinners;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NierReincarnation.CodeAnalysis.Model;

namespace NierReincarnation.CodeAnalysis;

public static class DumpCsParser
{
    public static List<ClassRecord> Parse(DumpCsParserOptions options)
    {
        List<ClassRecord> results = new();
        using Spinner spinner = new()
        {
            Label = "Parsing dump.cs...",
            DoneText = "Done",
            EnsureBeginOfLine = true
        };
        try
        {
            spinner.Display();
            results = ParseWithRoslyn(options);
        }
        finally
        {
            spinner.Close();
        }

        return results;
    }

    private static List<ClassRecord> ParseWithRoslyn(DumpCsParserOptions arg)
    {
        List<ClassRecord> results = new();
        if (!File.Exists(arg.DumpPath)) return results;

        string dumpText = File.ReadAllText(arg.DumpPath);
        CSharpParseOptions options = new CSharpParseOptions().WithDocumentationMode(DocumentationMode.Parse);
        SyntaxTree tree = CSharpSyntaxTree.ParseText(dumpText, options);

        IEnumerable<ClassDeclarationSyntax> classes = tree.GetRoot()
            .DescendantNodes()
            .OfType<ClassDeclarationSyntax>();

        foreach (ClassDeclarationSyntax @class in classes)
        {
            string? @namespace = @class.GetNamespace();

            if (!arg.IsValidNamespace(@namespace)) continue;
            if (!arg.IsValidClass(@class.Identifier.Text)) continue;

            List<MethodRecord> methodRecords = new();
            ClassRecord classRecord = new(@class, methodRecords, @namespace!);

            IEnumerable<MethodDeclarationSyntax> methods = @class.DescendantNodes()
                .OfType<MethodDeclarationSyntax>();

            foreach (MethodDeclarationSyntax method in methods)
            {
                if (!arg.IsValidMethod(method.Identifier.Text)) continue;

                string? methodOffset = method.GetOffset();
                if (methodOffset == null) continue;

                methodRecords.Add(new MethodRecord(method, methodOffset));
            }

            if (arg.IncludeEmptyClasses || methodRecords.Count > 0)
            {
                results.Add(classRecord);
            }
        }

        return results;
    }
}

public class DumpCsParserOptions
{
    public string DumpPath { get; init; }

    public bool IncludeEmptyClasses { get; init; }

    public List<FilterRecord> NamespaceFilters = Extensions.GameNamespaceFilters;

    public List<FilterRecord> ClassFilters = new();

    public List<FilterRecord> MethodFilters = new();

    public bool IsValidNamespace(string? @namespace)
    {
        return NamespaceFilters.Count == 0 || NamespaceFilters.Any(x => x.IsMatch(@namespace?.Split(".")[0] ?? string.Empty));
    }

    public bool IsValidClass(string className)
    {
        return ClassFilters.Count == 0 || ClassFilters.Any(x => x.IsMatch(className));
    }

    public bool IsValidMethod(string methodName)
    {
        return MethodFilters.Count == 0 || MethodFilters.Any(x => x.IsMatch(methodName));
    }
}
