using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_quest_release_condition_deck_power")]
    public class EntityMQuestReleaseConditionDeckPower
    {
        [Key(0)] // RVA: 0x1DE25F8 Offset: 0x1DE25F8 VA: 0x1DE25F8
        public int QuestReleaseConditionId { get; set; }
        [Key(1)] // RVA: 0x1DE2638 Offset: 0x1DE2638 VA: 0x1DE2638
        public int MaxDeckPower { get; set; }
    }
}
