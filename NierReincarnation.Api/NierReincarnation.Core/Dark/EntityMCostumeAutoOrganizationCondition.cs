using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_costume_auto_organization_condition")]
    public class EntityMCostumeAutoOrganizationCondition
    {
        [Key(0)]
        public int CostumeId { get; set; } // 0x10

        [Key(1)]
        public CostumeAutoOrganizationConditionType CostumeAutoOrganizationConditionType { get; set; } // 0x14

        [Key(2)]
        public int TargetValue { get; set; } // 0x18
    }
}
