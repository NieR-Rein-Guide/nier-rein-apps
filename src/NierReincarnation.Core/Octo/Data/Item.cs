using NierReincarnation.Core.Octo.Util;

namespace NierReincarnation.Core.Octo.Data;

public class Item
{
    private const string Tag = "Octo/Data/Item";
    private static readonly string[] EmptyTags = Array.Empty<string>();
    private static readonly Item[] EmptyDependencies = Array.Empty<Item>();

    public int id;
    public string name;
    public ObjectName objectName;
    public ulong generation;
    public int size;
    public uint crc;
    public MD5Value md5;
    public Proto.Data.DataState state;
    public int uploadVersionId;

    public virtual ItemType Type => ItemType.Minimum;

    public virtual string[] Tags
    { get => EmptyTags; set { } }

    public virtual Item[] Dependencies => EmptyDependencies;

    public virtual Item[] FlatDependencies => EmptyDependencies;

    public bool IsValid => state != Proto.Data.DataState.Delete;

    public Item(Proto.Data data, IList<string> tagNames)
    {
        SetData(data, tagNames);
    }

    public virtual void SetData(Proto.Data data, IList<string> tagNames)
    {
        id = data.Id;
        name = data.Name;
        objectName.Set(data.ObjectName);
        generation = data.Generation;
        size = data.Size;
        crc = data.Crc;
        md5.Set(data.Md5);
        state = data.State;
        uploadVersionId = data.UploadVersionId;

        Tags = data.Tags.Select(x => $"{x}").ToArray();
    }

    // Note: Recreate Data object from Item for writing into Database
    public Proto.Data GetData(Dictionary<string, int> tagDictionary)
    {
        return new Proto.Data
        {
            Id = id,
            Name = name,
            Size = size,
            Crc = crc,
            State = state,
            Md5 = md5.ToString(),
            ObjectName = objectName.ToString(),
            Generation = generation,
            UploadVersionId = uploadVersionId,

            Tags = Tags.Select(t => tagDictionary[t]).ToArray(),
            Deps = Dependencies.Select(x => x.id).ToArray()
        };
    }

    public virtual void SetDependencies(Proto.Data data, Dictionary<int, Item> items)
    { }

    public override string ToString()
    {
        return $"[Octo.Data.Item: id={id}, name={name}, size={size}, crc={crc}, tags=[{string.Join(",", Tags)}], deps=[{string.Join(", ", Dependencies.Select(x => x.name))}], state={state}, md5={md5}, objectName={objectName}, generation={generation}";
    }
}
