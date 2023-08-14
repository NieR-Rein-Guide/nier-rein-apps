using MessagePack.Formatters;

namespace NierReincarnation.Core.MasterMemory.Internal;

public class HeaderFormatterResolver : IFormatterResolver
{
    public static readonly IFormatterResolver Instance = new HeaderFormatterResolver();

    public static readonly MessagePackSerializerOptions StandardOptions = MessagePackSerializerOptions.Standard.WithResolver(Instance);

    public IMessagePackFormatter<T> GetFormatter<T>()
    {
        if (typeof(T) == typeof(Dictionary<string, (int, int)>))
        {
            return (IMessagePackFormatter<T>)(object)new DictionaryFormatter<string, (int, int)>();
        }

        if (typeof(T) == typeof(string))
        {
            return (IMessagePackFormatter<T>)(object)NullableStringFormatter.Instance;
        }

        if (typeof(T) == typeof((int, int)))
        {
            return (IMessagePackFormatter<T>)new IntIntValueTupleFormatter();
        }

        if (typeof(T) == typeof(int))
        {
            return (IMessagePackFormatter<T>)(object)Int32Formatter.Instance;
        }

        return null;
    }
}
