using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_progress_ui_type")]
    public class EntityMBattleProgressUiType
    {
        [Key(0)]
        public int QuestSceneId { get; set; } // 0x10

        [Key(1)]
        public int BattleProgressUiTypeId { get; set; } // 0x14
    }
}
