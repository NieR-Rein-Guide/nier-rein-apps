using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using MessagePack;
using NierReincarnation.Core.MasterMemory.Internal;

namespace NierReincarnation.Core.MasterMemory
{
    abstract class DatabaseBuilderBase
    {
        // CUSTOM: Use ArrayBufferWriter instead of self-implemented ByteBufferWriter
        private readonly ArrayBufferWriter<byte> bufferWriter; // 0x10
        private readonly Dictionary<string, (int, int)> header; // 0x18
        private readonly MessagePackSerializerOptions options; // 0x20

        public DatabaseBuilderBase(IFormatterResolver resolver)
        {
            bufferWriter = new ArrayBufferWriter<byte>();
            header = new Dictionary<string, (int, int)>();

            if (resolver == null)
                return;

            options = MessagePackSerializer.DefaultOptions
                .WithCompression(MessagePackCompression.Lz4Block)
                .WithResolver(resolver);
        }

        public byte[] Build()
        {
            using var ms = new MemoryStream();
            WriteToStream(ms);

            return ms.ToArray();
        }

        public void WriteToStream(Stream stream)
        {
            // Write data header
            MessagePackSerializer.Serialize(stream, header, HeaderFormatterResolver.StandardOptions);

            // Write data blob
            if (bufferWriter == null)
                return;

            MemoryMarshal.TryGetArray(bufferWriter.WrittenMemory, out var array);
            stream.Write(array);
        }

        protected void AppendCore<T, TKey>(IEnumerable<T> dataSource, Func<T, TKey> indexSelector,
            IComparer<TKey> comparer)
        {
            var memoryTableAttribute = typeof(T).GetCustomAttribute<MemoryTableAttribute>();
            if (memoryTableAttribute == null)
                throw new InvalidOperationException($"Type is not annotated MemoryTableAttribute. Type: {typeof(T).Name}");

            if (header.ContainsKey(memoryTableAttribute.TableName))
                throw new InvalidOperationException($"TableName is already appended in builder. TableName: {memoryTableAttribute.TableName} Type: {typeof(T).Name}");

            var elements = dataSource.OrderBy(indexSelector, comparer).ToArray();

            var localOptions = options ?? MessagePackSerializer.DefaultOptions.WithCompression(MessagePackCompression.Lz4Block).WithResolver(MessagePackSerializer.DefaultOptions.Resolver);

            var offset = bufferWriter.WrittenCount;
            MessagePackSerializer.Serialize(bufferWriter, elements, localOptions);
            header[memoryTableAttribute.TableName] = (offset, bufferWriter.WrittenCount - offset);
        }
    }
}
