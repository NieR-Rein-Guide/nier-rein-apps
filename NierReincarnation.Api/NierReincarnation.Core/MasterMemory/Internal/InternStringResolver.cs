using System;
using MessagePack;
using MessagePack.Formatters;

namespace NierReincarnation.Core.MasterMemory.Internal
{
    // MasterMemory.Internal.InternStringResolver
    internal class InternStringResolver : IFormatterResolver, IMessagePackFormatter<string>
    {
        // 0x10
        private readonly IFormatterResolver innerResolver;

        public InternStringResolver(IFormatterResolver innerResolver)
        {
            this.innerResolver = innerResolver;
        }

        public IMessagePackFormatter<T> GetFormatter<T>()
        {
            return innerResolver.GetFormatter<T>();
        }

        public void Serialize(ref MessagePackWriter writer, string value, MessagePackSerializerOptions options)
        {
            // Not implemented in assembly as well
            throw new NotImplementedException();
        }

        public string Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            var res = reader.ReadString();
            if (res != null)
                res = string.Intern(res);

            return res;
        }
    }
}
