using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_important_item_effect_target_quest_group")]
    public class EntityMImportantItemEffectTargetQuestGroup
    {
        [Key(0)]
        public int ImportantItemEffectTargetQuestGroupId { get; set; } // 0x10
        [Key(1)]
        public int TargetIndex { get; set; } // 0x14
        [Key(2)]
        public int ImportantItemEffectTargetQuestGroupType { get; set; } // 0x18
        [Key(3)]
        public int TargetValue { get; set; } // 0x1C
    }
}