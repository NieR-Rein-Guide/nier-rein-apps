using MessagePack.Formatters;

namespace NierReincarnation.Core.MasterMemory.Internal;

public class InternStringResolver : IFormatterResolver, IMessagePackFormatter<string>
{
    private readonly IFormatterResolver innerResolver;

    public InternStringResolver(IFormatterResolver innerResolver)
    {
        this.innerResolver = innerResolver;
    }

    public IMessagePackFormatter<T> GetFormatter<T>() => innerResolver.GetFormatter<T>();

    public void Serialize(ref MessagePackWriter writer, string value, MessagePackSerializerOptions options) => throw new NotImplementedException();

    public string Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        var res = reader.ReadString();
        return res != null ? string.Intern(res) : res;
    }
}
