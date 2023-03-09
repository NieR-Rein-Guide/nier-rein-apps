using System.Collections.Generic;
using ProtoBuf;

namespace NierReincarnation.Core.Octo.Proto
{
    [ProtoContract]
    public class Data
    {
        [ProtoMember(1)]
        public int Id { get; set; } // 0x10
        [ProtoMember(2)]
        public string Filepath { get; set; }    // 0x18
        [ProtoMember(3)]
        public string Name { get; set; }    // 0x20
        [ProtoMember(4)]
        public int Size { get; set; }   // 0x28
        [ProtoMember(5)]
        public uint Crc { get; set; }   // 0x2C
        [ProtoMember(6)]
        public int Priority { get; set; }   // 0x38
        [ProtoMember(7)]
        public IList<int> Tags { get; set; }    // 0x40
        [ProtoMember(8)]
        public IList<int> Deps { get; set; }    // 0x48
        [ProtoMember(9)]
        public DataState State { get; set; }    // 0x64
        [ProtoMember(10)]
        public string Md5 { get; set; } // 0x30
        [ProtoMember(11)]
        public string ObjectName { get; set; }  // 0x50
        [ProtoMember(12)]
        public ulong Generation { get; set; }   // 0x58
        [ProtoMember(13)]
        public int UploadVersionId { get; set; }    // 0x60

        public Data()
        {
            Crc = 0;
            Priority = 0;
            Filepath = string.Empty;
            Tags = new List<int>();
            Deps = new List<int>();
            Generation = 0;
            UploadVersionId = 0;
        }

        public enum DataState
        {
            None,
            Add,
            Update,
            Latest,
            Delete
        }
    }
}
