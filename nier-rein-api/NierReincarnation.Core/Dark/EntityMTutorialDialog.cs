using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_tutorial_dialog")]
    public class EntityMTutorialDialog
    {
        [Key(0)]
        public int TutorialType { get; set; } // 0x10
        [Key(1)]
        public int HelpType { get; set; } // 0x14
    }
}