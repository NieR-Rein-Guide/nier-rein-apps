using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_npc_weapon_story")]
    public class EntityMBattleNpcWeaponStory
    {
        [Key(0)]
        public long BattleNpcId { get; set; }

        [Key(1)]
        public int WeaponId { get; set; }

        [Key(2)]
        public int ReleasedMaxStoryIndex { get; set; }
    }
}
