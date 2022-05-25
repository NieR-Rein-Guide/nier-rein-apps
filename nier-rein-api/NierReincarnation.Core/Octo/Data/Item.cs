using System.Collections.Generic;
using System.Linq;
using NierReincarnation.Core.Octo.Util;
using ProtoBuf;

namespace NierReincarnation.Core.Octo.Data
{
    public class Item
    {
        private static readonly string Tag = "Octo/Data/Item"; // 0x0
        private static string[] EmptyTags = new string[0]; // 0x8
        private static Item[] EmptyDependencies = new Item[0]; // 0x10

        public int id; // 0x10
        public string name; // 0x18
        public ObjectName objectName; // 0x20
        public ulong generation; // 0x28
        public int size; // 0x30
        public uint crc; // 0x34
        public MD5Value md5; // 0x38
        public Proto.Data.DataState state; // 0x48
        public int uploadVersionId; // 0x4C

        // Properties
        public virtual ItemType Type => ItemType.Minimum;
        public virtual string[] Tags { get => EmptyTags; set { } }
        public virtual Item[] Dependencies => EmptyDependencies;
        public virtual Item[] FlatDependencies => EmptyDependencies;
        public bool IsValid => state != Proto.Data.DataState.Delete;  // Hint: Unknown what exactly is checked for validity here
        //public Hash128 Hash { get; }
        //public CachedAssetBundle CachedAssetBundle { get; }

        // Methods

        // RVA: 0x3302AE4 Offset: 0x3302AE4 VA: 0x3302AE4
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

        // CUSTOM: Recreate Data object from Item for writing into Database
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

        public virtual void SetDependencies(Proto.Data data, Dictionary<int, Item> items) { }

        public override string ToString()
        {
            return $"[Octo.Data.Item: id={id}, name={name}, size={size}, crc={crc}, tags=[{string.Join(",", Tags)}], deps=[{string.Join(", ", Dependencies.Select(x => x.name))}], state={state}, md5={md5}, objectName={objectName}, generation={generation}";
        }
    }
}
