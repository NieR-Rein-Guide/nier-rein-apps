using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_costume_awaken")]
    public class EntityMCostumeAwaken
    {
        [Key(0)] // RVA: 0x1E9DFC8 Offset: 0x1E9DFC8 VA: 0x1E9DFC8
        public int CostumeId { get; set; } // 0x10

        [Key(1)] // RVA: 0x1E9E008 Offset: 0x1E9E008 VA: 0x1E9E008
        public int CostumeAwakenEffectGroupId { get; set; } // 0x14

        [Key(2)] // RVA: 0x1E9E01C Offset: 0x1E9E01C VA: 0x1E9E01C
        public int CostumeAwakenStepMaterialGroupId { get; set; } // 0x18

        [Key(3)] // RVA: 0x1E9E030 Offset: 0x1E9E030 VA: 0x1E9E030
        public int CostumeAwakenPriceGroupId { get; set; } // 0x1C
    }
}
