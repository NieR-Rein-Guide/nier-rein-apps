using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_contents_story")]
    public class EntityIUserContentsStory
    {
        [Key(0)]
        public long UserId { get; set; }

        [Key(1)]
        public int ContentsStoryId { get; set; }

        [Key(2)]
        public long PlayDatetime { get; set; }

        [Key(3)]
        public long LatestVersion { get; set; }
    }
}
