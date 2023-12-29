using ProtoBuf;

namespace NierReincarnation.Core.Octo.Proto;

[ProtoContract]
public class Database
{
    [ProtoMember(1)]
    public int Revision { get; set; }

    [ProtoMember(2)]
    public List<Data> AssetBundleList { get; set; }

    [ProtoMember(3)]
    public List<string> TagName { get; set; }

    [ProtoMember(4)]
    public List<Data> ResourceList { get; set; }

    [ProtoMember(5)]
    public string UrlFormat { get; set; }

    public Database()
    {
        AssetBundleList = [];
        TagName = [];
        ResourceList = [];
        UrlFormat = string.Empty;
    }
}
