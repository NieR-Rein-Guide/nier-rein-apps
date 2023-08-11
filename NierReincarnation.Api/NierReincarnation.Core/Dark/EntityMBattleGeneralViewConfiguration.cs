using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_general_view_configuration")]
    public class EntityMBattleGeneralViewConfiguration
    {
        [Key(0)]
        public int QuestSceneId { get; set; }

        [Key(1)]
        public int WaveNumber { get; set; }

        [Key(2)]
        public bool IsDisableBattleStartVoice { get; set; }

        [Key(3)]
        public bool IsEnableWhiteFadeout { get; set; }

        [Key(4)]
        public int EnvSeId { get; set; }

        [Key(5)]
        public int WaveWinSeId { get; set; }

        [Key(6)]
        public bool IsDisablePlayWinTimeline { get; set; }
    }
}
