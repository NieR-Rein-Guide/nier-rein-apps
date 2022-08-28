using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_help")]
    public class EntityMHelp
    {
        [Key(0)]
        public int HelpType { get; set; } // 0x10
        [Key(1)]
        public int HelpItemId { get; set; } // 0x14
        [Key(2)]
        public int HelpPageGroupId { get; set; } // 0x18
    }
}