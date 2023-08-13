using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_tutorial_unlock_condition")]
public class EntityMTutorialUnlockCondition
{
    [Key(0)]
    public TutorialType TutorialType { get; set; }

    [Key(1)]
    public TutorialUnlockConditionType TutorialUnlockConditionType { get; set; }

    [Key(2)]
    public int ConditionValue { get; set; }
}
