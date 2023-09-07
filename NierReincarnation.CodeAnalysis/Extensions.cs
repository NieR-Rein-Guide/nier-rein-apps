using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NierReincarnation.CodeAnalysis.Model;
using System.Text.RegularExpressions;

namespace NierReincarnation.CodeAnalysis;

public static partial class Extensions
{
    public static List<FilterRecord> GameNamespaceFilters = new()
    {
        new FilterRecord("Adam", FilterType.Equals),
        new FilterRecord("Art", FilterType.Equals),
        new FilterRecord("Applibot", FilterType.Equals),
        new FilterRecord("Dark", FilterType.Equals),
        new FilterRecord("MasterMemory", FilterType.Equals),
        new FilterRecord("Octo", FilterType.Equals),
        new FilterRecord("Subsystem", FilterType.Equals),
    };

    [GeneratedRegex("Offset: (\\w+)")]
    private static partial Regex OffsetRegex();

    [GeneratedRegex("Namespace: (.+)")]
    private static partial Regex NamespaceRegex();

    public static string? GetOffset(this AttributeListSyntax? attribute)
    {
        if (attribute == null) return null;

        var attributeText = attribute.ToFullString();
        Match match = OffsetRegex().Match(attributeText);

        return match.Success ? match.Groups[1].Value : null;
    }

    public static string? GetOffset(this MethodDeclarationSyntax method)
    {
        var methodText = method.ToFullString();
        Match match = OffsetRegex().Match(methodText);

        return match.Success ? match.Groups[1].Value : null;
    }

    public static string? GetNamespace(this ClassDeclarationSyntax @class)
    {
        var namespaceComment = @class.GetLeadingTrivia().FirstOrDefault(x => x.IsKind(SyntaxKind.SingleLineCommentTrivia) || x.IsKind(SyntaxKind.MultiLineCommentTrivia));

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
