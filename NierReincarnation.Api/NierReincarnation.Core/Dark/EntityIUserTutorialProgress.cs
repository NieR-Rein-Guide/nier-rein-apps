using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_tutorial_progress")]
    public class EntityIUserTutorialProgress
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10
        [Key(1)]
        public TutorialType TutorialType { get; set; } // 0x18
        [Key(2)]
        public int ProgressPhase { get; set; } // 0x1C
        [Key(3)]
        public int ChoiceId { get; set; } // 0x20
        [Key(4)]
        public long LatestVersion { get; set; } // 0x28
    }
}