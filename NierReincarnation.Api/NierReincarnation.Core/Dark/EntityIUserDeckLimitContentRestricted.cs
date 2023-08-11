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
        public long UserId { get; set; }

        [Key(1)]
        public int EventQuestChapterId { get; set; }

        [Key(2)]
        public int QuestId { get; set; }

        [Key(3)]
        public string DeckRestrictedUuid { get; set; }

        [Key(4)]
        public PossessionType PossessionType { get; set; }

        [Key(5)]
        public string TargetUuid { get; set; }

        [Key(6)]
        public long LatestVersion { get; set; }
    }
}
