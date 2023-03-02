using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_bgm_set_group")]
    public class EntityMBattleBgmSetGroup
    {
        [Key(0)]
        public int BgmSetGroupId { get; set; } // 0x10
        [Key(1)]
        public int BgmSetGroupIndex { get; set; } // 0x14
        [Key(2)]
        public int BgmSetId { get; set; } // 0x18
        [Key(3)]
        public int RandomWeight { get; set; } // 0x1C
    }
}