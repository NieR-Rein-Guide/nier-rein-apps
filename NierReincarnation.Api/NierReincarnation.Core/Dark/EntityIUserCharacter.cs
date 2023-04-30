using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_character")]
    public class EntityIUserCharacter
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10

        [Key(1)]
        public int CharacterId { get; set; } // 0x18

        [Key(2)]
        public int Level { get; set; } // 0x1C

        [Key(3)]
        public int Exp { get; set; } // 0x20

        [Key(4)]
        public long LatestVersion { get; set; } // 0x28
    }
}
