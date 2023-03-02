using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_character_rebirth_step_group")]
    public class EntityMCharacterRebirthStepGroup
    {
        [Key(0)]
        public int CharacterRebirthStepGroupId { get; set; } // 0x10
        [Key(1)]
        public int BeforeRebirthCount { get; set; } // 0x14
        [Key(2)]
        public int CostumeLevelLimitUp { get; set; } // 0x18
        [Key(3)]
        public int CharacterRebirthMaterialGroupId { get; set; } // 0x1C
    }
}