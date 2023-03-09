using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_tutorial_dialog")]
    public class EntityMTutorialDialog
    {
        [Key(0)]
        public TutorialType TutorialType { get; set; } // 0x10
        [Key(1)]
        public HelpType HelpType { get; set; } // 0x14
    }
}