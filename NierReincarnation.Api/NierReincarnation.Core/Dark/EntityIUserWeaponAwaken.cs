using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_weapon_awaken")]
    public class EntityIUserWeaponAwaken
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10
        [Key(1)]
        public string UserWeaponUuid { get; set; } // 0x18
        [Key(2)]
        public long LatestVersion { get; set; } // 0x20
    }
}