using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_thought")]
    public class EntityIUserThought
    {
        [Key(0)]
        public long UserId { get; set; }

        [Key(1)]
        public string UserThoughtUuid { get; set; }

        [Key(2)]
        public int ThoughtId { get; set; }

        [Key(3)]
        public long AcquisitionDatetime { get; set; }

        [Key(4)]
        public long LatestVersion { get; set; }
    }
}
