namespace NierReincarnation.Core.Adam.Framework.Gameplay.Paradigm;

public class Variable<T> : VariableBase
{
    private T _data;

    public override Type ValueType => typeof(T);

    public override object ValueObject { get => _data; set => _data = (T)value; }

    public T value { get; set; }
}
