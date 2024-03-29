﻿using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace NierReincarnation.CodeAnalysis.Model;
public record ClassRecord(ClassDeclarationSyntax Class,
    List<FieldRecord> Fields,
    List<PropertyRecord> Properties,
    List<ConstructorRecord> Constructors,
    List<MethodRecord> Methods,
    string NameSpace);
