using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_quest_scene")]
    public class EntityMQuestScene
    {
        [Key(0)] // RVA: 0x1DE2914 Offset: 0x1DE2914 VA: 0x1DE2914
        public int QuestSceneId { get; set; }
        [Key(1)] // RVA: 0x1DE2954 Offset: 0x1DE2954 VA: 0x1DE2954
        public int QuestId { get; set; }
        [Key(2)] // RVA: 0x1DE2968 Offset: 0x1DE2968 VA: 0x1DE2968
        public int SortOrder { get; set; }
        [Key(3)] // RVA: 0x1DE297C Offset: 0x1DE297C VA: 0x1DE297C
        public QuestSceneType QuestSceneType { get; set; }
        [Key(4)] // RVA: 0x1DE2990 Offset: 0x1DE2990 VA: 0x1DE2990
        public int AssetBackgroundId { get; set; }
        [Key(5)] // RVA: 0x1DE29A4 Offset: 0x1DE29A4 VA: 0x1DE29A4
        public int EventMapNumberUpper { get; set; }
        [Key(6)] // RVA: 0x1DE29B8 Offset: 0x1DE29B8 VA: 0x1DE29B8
        public int EventMapNumberLower { get; set; }
        [Key(7)] // RVA: 0x1DE29CC Offset: 0x1DE29CC VA: 0x1DE29CC
        public bool IsMainFlowQuestTarget { get; set; }
        [Key(8)] // RVA: 0x1DE29E0 Offset: 0x1DE29E0 VA: 0x1DE29E0
        public bool IsBattleOnlyTarget { get; set; }
        [Key(9)] // RVA: 0x1DE29F4 Offset: 0x1DE29F4 VA: 0x1DE29F4
        public int QuestResultType { get; set; }
        [Key(10)] // RVA: 0x1DE2A08 Offset: 0x1DE2A08 VA: 0x1DE2A08
        public bool IsStorySkipTarget { get; set; }
	}
}
