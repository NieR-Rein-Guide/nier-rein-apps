using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_quest_scene_choice")]
    public class EntityIUserQuestSceneChoice
    {
        [Key(0)] // RVA: 0x2270F34 Offset: 0x2270F34 VA: 0x2270F34
        public long UserId { get; set; }
        [Key(1)] // RVA: 0x2270F74 Offset: 0x2270F74 VA: 0x2270F74
        public int QuestSceneChoiceGroupingId { get; set; }
        [Key(2)] // RVA: 0x2270FB4 Offset: 0x2270FB4 VA: 0x2270FB4
        public int QuestSceneChoiceEffectId { get; set; }
        [Key(3)] // RVA: 0x2270FC8 Offset: 0x2270FC8 VA: 0x2270FC8
        public long LatestVersion { get; set; }
    }
}
