using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_character_rebirth_step_group")]
    public class EntityMCharacterRebirthStepGroup
    {
        [Key(0)]
        public int CharacterRebirthStepGroupId { get; set; }

        [Key(1)]
        public int BeforeRebirthCount { get; set; }

        [Key(2)]
        public int CostumeLevelLimitUp { get; set; }

        [Key(3)]
        public int CharacterRebirthMaterialGroupId { get; set; }
    }
}
