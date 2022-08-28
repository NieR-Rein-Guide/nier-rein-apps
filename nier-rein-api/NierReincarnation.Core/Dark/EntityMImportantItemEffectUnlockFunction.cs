using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_important_item_effect_unlock_function")]
    public class EntityMImportantItemEffectUnlockFunction
    {
        [Key(0)]
        public int ImportantItemEffectUnlockFunctionId { get; set; } // 0x10
        [Key(1)]
        public int ImportantItemEffectUnlockFunctionType { get; set; } // 0x14
        [Key(2)]
        public int UnlockFunctionEffectValue { get; set; } // 0x18
    }
}