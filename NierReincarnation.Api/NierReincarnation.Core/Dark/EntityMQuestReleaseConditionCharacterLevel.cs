using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_quest_release_condition_character_level")]
    public class EntityMQuestReleaseConditionCharacterLevel
    {
        [Key(0)] // RVA: 0x1DE2590 Offset: 0x1DE2590 VA: 0x1DE2590
        public int QuestReleaseConditionId { get; set; } // 0x10

        [Key(1)] // RVA: 0x1DE25D0 Offset: 0x1DE25D0 VA: 0x1DE25D0
        public int CharacterId { get; set; } // 0x14

        [Key(2)] // RVA: 0x1DE25E4 Offset: 0x1DE25E4 VA: 0x1DE25E4
        public int CharacterLevel { get; set; } // 0x18
    }
}
