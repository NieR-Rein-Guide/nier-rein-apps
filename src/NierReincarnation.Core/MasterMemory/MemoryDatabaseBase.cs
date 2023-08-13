using MessagePack.Formatters;
using NierReincarnation.Core.MasterMemory.Internal;
using System.Reflection;

namespace NierReincarnation.Core.MasterMemory;

public abstract class MemoryDatabaseBase
{
    protected MemoryDatabaseBase()
    { }

    protected MemoryDatabaseBase(byte[] databaseBinary, bool internString = true, IFormatterResolver formatterResolver = null)
    {
        MessagePackReader reader = new(databaseBinary);
        DictionaryFormatter<string, (int, int)> dictionaryFormatter = new();
        var deserializedData = dictionaryFormatter.Deserialize(ref reader, HeaderFormatterResolver.StandardOptions);

        formatterResolver ??= MessagePackSerializer.DefaultOptions.Resolver;
        if (internString)
            formatterResolver = new InternStringResolver(formatterResolver);

        var databaseMemory = databaseBinary.AsMemory((int)reader.Consumed);
        var finalOptions = MessagePackSerializer.DefaultOptions.WithResolver(formatterResolver).WithCompression(MessagePackCompression.Lz4Block);

        Init(deserializedData!, databaseMemory, finalOptions);
    }

    protected static TView ExtractTableData<TView, T>(Dictionary<string, (int, int)> header,
        ReadOnlyMemory<byte> databaseBinary, MessagePackSerializerOptions options, Func<T[], TView> createView)
    {
        var memoryTableAttribute = typeof(T).GetCustomAttribute<MemoryTableAttribute>() ?? throw new InvalidOperationException($"Type is not annotated MemoryTableAttribute. Type: {typeof(T).Name}");

        if (header.TryGetValue(memoryTableAttribute.TableName, out var headerValue))
        {
            var slice = databaseBinary.Slice(headerValue.Item1, headerValue.Item2);
            var elements = MessagePackSerializer.Deserialize<T[]>(slice, options);

            return createView(elements);
        }

        return createView(Array.Empty<T>());
    }

    protected abstract void Init(Dictionary<string, (int, int)> header, ReadOnlyMemory<byte> databaseBinary, MessagePackSerializerOptions options);
}
