using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NierReincarnation.CodeAnalysis.Model;
public record ConstructorRecord(ConstructorDeclarationSyntax Constructor, string Offset);
