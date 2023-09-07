using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace NierReincarnation.CodeAnalysis.Model;
public record MethodRecord(MethodDeclarationSyntax Method, string Offset);
