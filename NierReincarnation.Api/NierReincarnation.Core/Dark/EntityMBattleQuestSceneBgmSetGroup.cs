using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_quest_scene_bgm_set_group")]
    public class EntityMBattleQuestSceneBgmSetGroup
    {
        [Key(0)]
        public int QuestSceneId { get; set; } // 0x10

        [Key(1)]
        public int BgmSetGroupId { get; set; } // 0x14
    }
}
