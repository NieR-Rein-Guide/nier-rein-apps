﻿using DustInTheWind.ConsoleTools.Controls.Spinners;
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

    private static List<ClassRecord> ParseWithRoslyn(DumpCsParserOptions options)
    {
        List<ClassRecord> results = new();
        if (!File.Exists(options.DumpPath)) return results;

        string dumpText = File.ReadAllText(options.DumpPath);
        CSharpParseOptions parseOptions = new CSharpParseOptions().WithDocumentationMode(DocumentationMode.Parse);
        SyntaxTree tree = CSharpSyntaxTree.ParseText(dumpText, parseOptions);

        IEnumerable<ClassDeclarationSyntax> classes = tree.GetRoot()
            .DescendantNodes()
            .OfType<ClassDeclarationSyntax>();

        foreach (ClassDeclarationSyntax @class in classes)
        {
            string? @namespace = @class.GetNamespace();

            if (!options.IsValidNamespace(@namespace)) continue;
            if (!options.IsValidClass(@class.Identifier.Text)) continue;

            List<FieldRecord> fieldRecords = new();
            List<PropertyRecord> propertyRecords = new();
            List<ConstructorRecord> constructorRecords = new();
            List<MethodRecord> methodRecords = new();
            ClassRecord classRecord = new(@class, fieldRecords, propertyRecords, constructorRecords, methodRecords, @namespace!);

            List<SyntaxNode> descendantNodes = @class.DescendantNodes().ToList();

            foreach (var descendantNode in descendantNodes)
            {
                if (options.IncludeMethods && descendantNode is MethodDeclarationSyntax methodSyntax)
                {
                    if (!options.IsValidMethod(methodSyntax.Identifier.Text)) continue;

                    string methodOffset = methodSyntax.GetOffset() ?? string.Empty;
                    methodRecords.Add(new MethodRecord(methodSyntax, methodOffset));
                }
                else if (options.IncludeConstructors && descendantNode is ConstructorDeclarationSyntax constructorSyntax)
                {
                    int nodeIndex = descendantNodes.IndexOf(descendantNode);
                    int incompleteMemberSyntaxIndex = descendantNodes
                        .FindLastIndex(nodeIndex, 3, x => x is IncompleteMemberSyntax);

                    if (incompleteMemberSyntaxIndex == -1) continue;

                    string constructorOffset = ((IncompleteMemberSyntax)descendantNodes[incompleteMemberSyntaxIndex]).GetOffset() ?? string.Empty;
                    constructorRecords.Add(new ConstructorRecord(constructorSyntax, constructorOffset));
                }
                else if (options.IncludeFields && descendantNode is FieldDeclarationSyntax fieldDeclarationSyntax)
                {
                    //var fieldOffset = fieldDeclarationSyntax.AttributeLists.FirstOrDefault()?.GetOffset() ?? string.Empty;
                    var fieldOffset = fieldDeclarationSyntax.GetOffset() ?? string.Empty;
                    fieldRecords.Add(new FieldRecord(fieldDeclarationSyntax, fieldOffset));
                }
                else if (options.IncludeProperties && descendantNode is  PropertyDeclarationSyntax propertyDeclarationSyntax)
                {
                    propertyRecords.Add(new PropertyRecord(propertyDeclarationSyntax));
                }
            }

            results.Add(classRecord);
        }

        return results;
    }
}

public class DumpCsParserOptions
{
    public string DumpPath { get; init; }

    public bool IncludeFields { get; init; }

    public bool IncludeProperties { get; init; }

    public bool IncludeConstructors { get; init; }

    public bool IncludeMethods { get; init; }

    public List<FilterRecord> NamespaceFilters = Extensions.GameNamespaceFilters;

    public List<FilterRecord> ClassFilters = new();

    public List<FilterRecord> MethodFilters = new();

    public bool IsValidNamespace(string? @namespace)
    {
        return NamespaceFilters.Count == 0 || NamespaceFilters.Any(x => x.IsMatch(@namespace ?? string.Empty));
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