using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_dokan_content_group")]
    public class EntityMDokanContentGroup
    {
        [Key(0)]
        public int DokanContentGroupId { get; set; } // 0x10
        [Key(1)]
        public int ContentIndex { get; set; } // 0x14
        [Key(2)]
        public int ImageId { get; set; } // 0x18
        [Key(3)]
        public int MovieId { get; set; } // 0x1C
        [Key(4)]
        public int DokanTextId { get; set; } // 0x20
    }
}