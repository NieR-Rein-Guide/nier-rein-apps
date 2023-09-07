using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace NierReincarnation.CodeAnalysis.Model;
public record ClassRecord(ClassDeclarationSyntax Class, List<ConstructorRecord> Constructors, List<MethodRecord> Methods, string NameSpace);
