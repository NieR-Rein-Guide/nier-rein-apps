using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace NierReincarnation.CodeAnalysis.Model;
public record FieldRecord(FieldDeclarationSyntax Field, string Offset);
