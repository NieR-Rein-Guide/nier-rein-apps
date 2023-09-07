using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NierReincarnation.CodeAnalysis.Model;
using System.Text.RegularExpressions;

namespace NierReincarnation.CodeAnalysis;

public static partial class Extensions
{
    public readonly static List<FilterRecord> GameNamespaceFilters = new()
    {
        new FilterRecord("Adam.", FilterType.StartsWith),
        new FilterRecord("Art.", FilterType.StartsWith),
        new FilterRecord("Applibot.", FilterType.StartsWith),
        new FilterRecord("Dark.", FilterType.StartsWith),
        new FilterRecord("MasterMemory.", FilterType.StartsWith),
        new FilterRecord("Octo.", FilterType.StartsWith),
        new FilterRecord("Subsystem.", FilterType.StartsWith),
    };

    [GeneratedRegex("Offset: (\\w+)")]
    private static partial Regex OffsetRegex();

    [GeneratedRegex("// (\\w+)")]
    private static partial Regex InlineOffsetRegex();

    [GeneratedRegex("Namespace: (.+)")]
    private static partial Regex NamespaceRegex();

    public static string? GetOffset(this AttributeListSyntax? attributeList)
    {
        if (attributeList == null) return null;

        var attributeText = attributeList.ToFullString();
        Match match = OffsetRegex().Match(attributeText);

        return match.Success ? match.Groups[1].Value : null;
    }

    public static string? GetOffset(this FieldDeclarationSyntax fieldDeclaration)
    {
        var methodText = fieldDeclaration.ToFullString();
        Match match = InlineOffsetRegex().Matches(methodText).Last();

        return match.Success ? match.Groups[1].Value : null;
    }

    public static string? GetOffset(this IncompleteMemberSyntax incompleteMember)
    {
        var methodText = incompleteMember.ToFullString();
        Match match = OffsetRegex().Match(methodText);

        return match.Success ? match.Groups[1].Value : null;
    }

    public static string? GetOffset(this MethodDeclarationSyntax methodDeclaration)
    {
        var methodText = methodDeclaration.ToFullString();
        Match match = OffsetRegex().Match(methodText);

        return match.Success ? match.Groups[1].Value : null;
    }

    public static string? GetNamespace(this ClassDeclarationSyntax classDeclaration)
    {
        var namespaceComment = classDeclaration.GetLeadingTrivia()
            .FirstOrDefault(x => x.IsKind(SyntaxKind.SingleLineCommentTrivia) || x.IsKind(SyntaxKind.MultiLineCommentTrivia));

        Match match = NamespaceRegex().Match(namespaceComment.ToString());

        return match.Success ? match.Groups[1].Value : null;
    }

    public static bool IsMatch(this FilterRecord filterRecord, string text)
    {
        return filterRecord.FilterType switch
        {
            FilterType.StartsWith => text.StartsWith(filterRecord.Filter),
            FilterType.EndsWith => text.EndsWith(filterRecord.Filter),
            FilterType.Contains => text.Contains(filterRecord.Filter),
            FilterType.Equals => text.Equals(filterRecord.Filter),
            FilterType.Regex => new Regex(filterRecord.Filter).IsMatch(text),
            _ => false
        };
    }
}
