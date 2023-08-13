using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_tutorial_dialog")]
public class EntityMTutorialDialog
{
    [Key(0)]
    public TutorialType TutorialType { get; set; }

    [Key(1)]
    public HelpType HelpType { get; set; }
}
