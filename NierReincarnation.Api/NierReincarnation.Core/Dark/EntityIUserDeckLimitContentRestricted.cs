using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_deck_limit_content_restricted")]
    public class EntityIUserDeckLimitContentRestricted
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10

        [Key(1)]
        public int EventQuestChapterId { get; set; } // 0x18

        [Key(2)]
        public int QuestId { get; set; } // 0x1C

        [Key(3)]
        public string DeckRestrictedUuid { get; set; } // 0x20

        [Key(4)]
        public PossessionType PossessionType { get; set; } // 0x28

        [Key(5)]
        public string TargetUuid { get; set; } // 0x30

        [Key(6)]
        public long LatestVersion { get; set; } // 0x38
    }
}
