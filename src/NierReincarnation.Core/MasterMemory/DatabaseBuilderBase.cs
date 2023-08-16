using NierReincarnation.Core.MasterMemory.Internal;
using System.Buffers;
using System.Reflection;
using System.Runtime.InteropServices;

namespace NierReincarnation.Core.MasterMemory;

public abstract class DatabaseBuilderBase
{
    // Note: Use ArrayBufferWriter instead of self-implemented ByteBufferWriter
    private readonly ArrayBufferWriter<byte> bufferWriter;

    private readonly Dictionary<string, (int, int)> header;
    private readonly MessagePackSerializerOptions options;

    protected DatabaseBuilderBase(IFormatterResolver resolver)
    {
        bufferWriter = new ArrayBufferWriter<byte>();
        header = new Dictionary<string, (int, int)>();
        options = MessagePackSerializer.DefaultOptions
                .WithCompression(MessagePackCompression.Lz4Block)
                .WithResolver(resolver ?? MessagePackSerializer.DefaultOptions.Resolver);
    }

    public byte[] Build()
    {
        using MemoryStream ms = new();
        WriteToStream(ms);

        return ms.ToArray();
    }

    public void WriteToStream(Stream stream)
    {
        // Write data header
        MessagePackSerializer.Serialize(stream, header, HeaderFormatterResolver.StandardOptions);

        // Write data blob
        MemoryMarshal.TryGetArray(bufferWriter.WrittenMemory, out var array);
        stream.Write(array);
    }

    protected void AppendCore<T, TKey>(IEnumerable<T> dataSource, Func<T, TKey> indexSelector,
        IComparer<TKey> comparer)
    {
        var memoryTableAttribute = typeof(T).GetCustomAttribute<MemoryTableAttribute>() ?? throw new InvalidOperationException($"Type is not annotated MemoryTableAttribute. Type: {typeof(T).Name}");

        if (header.ContainsKey(memoryTableAttribute.TableName))
        {
            throw new InvalidOperationException($"TableName is already appended in builder. TableName: {memoryTableAttribute.TableName} Type: {typeof(T).Name}");
        }

        var elements = dataSource.OrderBy(indexSelector, comparer).ToArray();
        var offset = bufferWriter.WrittenCount;
        MessagePackSerializer.Serialize(bufferWriter, elements, options);
        header[memoryTableAttribute.TableName] = (offset, bufferWriter.WrittenCount - offset);
    }
}
