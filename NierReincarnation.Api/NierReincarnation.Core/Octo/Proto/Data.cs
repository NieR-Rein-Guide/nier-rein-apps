using System.Collections.Generic;
using ProtoBuf;

namespace NierReincarnation.Core.Octo.Proto
{
    [ProtoContract]
    public class Data
    {
        [ProtoMember(1)]
        public int Id { get; set; }
        [ProtoMember(2)]
        public string Filepath { get; set; }   
        [ProtoMember(3)]
        public string Name { get; set; }   
        [ProtoMember(4)]
        public int Size { get; set; }  
        [ProtoMember(5)]
        public uint Crc { get; set; }  
        [ProtoMember(6)]
        public int Priority { get; set; }  
        [ProtoMember(7)]
        public IList<int> Tags { get; set; }   
        [ProtoMember(8)]
        public IList<int> Deps { get; set; }   
        [ProtoMember(9)]
        public DataState State { get; set; }   
        [ProtoMember(10)]
        public string Md5 { get; set; }
        [ProtoMember(11)]
        public string ObjectName { get; set; } 
        [ProtoMember(12)]
        public ulong Generation { get; set; }  
        [ProtoMember(13)]
        public int UploadVersionId { get; set; }   

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
