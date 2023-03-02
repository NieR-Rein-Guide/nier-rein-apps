using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_npc_weapon_story")]
    public class EntityMBattleNpcWeaponStory
    {
        [Key(0)]
        public long BattleNpcId { get; set; } // 0x10
        [Key(1)]
        public int WeaponId { get; set; } // 0x18
        [Key(2)]
        public int ReleasedMaxStoryIndex { get; set; } // 0x1C
    }
}