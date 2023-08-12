namespace NierReincarnation.Core.Adam.Framework.Gameplay.Paradigm;

public abstract class VariableBase
{
    private static InternalDataStructure _gCreatingDataStructure;

    public abstract Type ValueType { get; }

    public abstract object ValueObject { get; set; }

    public static InternalDataStructure DataStructure => _gCreatingDataStructure;

    public static VariableBase Create(InternalDataStructure structure, Type type)
    {
        if (!type.IsAssignableFrom(typeof(VariableBase)))
            return null;

        _gCreatingDataStructure = structure;
        var dataType = GetDataType(type);

        return null;
    }

    public static Type GetDataType(Type variableClassType)
    {
        if (!variableClassType.IsAssignableFrom(typeof(Variable<>)))
            return null;

        return null;
    }
}
