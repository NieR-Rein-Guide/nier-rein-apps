using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_general_view_configuration")]
    public class EntityMBattleGeneralViewConfiguration
    {
        [Key(0)]
        public int QuestSceneId { get; set; } // 0x10
        [Key(1)]
        public int WaveNumber { get; set; } // 0x14
        [Key(2)]
        public bool IsDisableBattleStartVoice { get; set; } // 0x18
        [Key(3)]
        public bool IsEnableWhiteFadeout { get; set; } // 0x19
        [Key(4)]
        public int EnvSeId { get; set; } // 0x1C
        [Key(5)]
        public int WaveWinSeId { get; set; } // 0x20
    }
}