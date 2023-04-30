using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_tutorial_unlock_condition")]
    public class EntityMTutorialUnlockCondition
    {
        [Key(0)]
        public TutorialType TutorialType { get; set; } // 0x10

        [Key(1)]
        public TutorialUnlockConditionType TutorialUnlockConditionType { get; set; } // 0x14

        [Key(2)]
        public int ConditionValue { get; set; } // 0x18
    }
}
