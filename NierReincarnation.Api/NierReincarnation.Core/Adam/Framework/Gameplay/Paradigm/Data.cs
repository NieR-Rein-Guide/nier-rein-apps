namespace NierReincarnation.Core.Adam.Framework.Gameplay.Paradigm;

class Data
{
    public string name;
    private object _objectReferenceValue;

    public bool GetVariable<T>(out T value)
    {
        value = default;

        var varBase = (VariableBase)_objectReferenceValue;
        if (varBase.ValueType == typeof(T))
        {
            value = ((Variable<T>)varBase).value;
            return true;
        }

        return false;
    }
}
