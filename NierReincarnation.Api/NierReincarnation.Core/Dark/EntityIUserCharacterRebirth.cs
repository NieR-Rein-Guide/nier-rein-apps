using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_character_rebirth")]
    public class EntityIUserCharacterRebirth
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10

        [Key(1)]
        public int CharacterId { get; set; } // 0x18

        [Key(2)]
        public int RebirthCount { get; set; } // 0x1C

        [Key(3)]
        public long LatestVersion { get; set; } // 0x20
    }
}
