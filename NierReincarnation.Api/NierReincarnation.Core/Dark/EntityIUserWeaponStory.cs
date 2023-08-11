using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_weapon_story")]
    public class EntityIUserWeaponStory
    {
        [Key(0)]
        public long UserId { get; set; }

        [Key(1)]
        public int WeaponId { get; set; }

        [Key(2)]
        public int ReleasedMaxStoryIndex { get; set; }

        [Key(3)]
        public long LatestVersion { get; set; }
    }
}
