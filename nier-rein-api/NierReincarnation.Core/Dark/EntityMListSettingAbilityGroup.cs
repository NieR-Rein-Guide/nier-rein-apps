using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_list_setting_ability_group")]
    public class EntityMListSettingAbilityGroup
    {
        [Key(0)]
        public int ListSettingAbilityGroupId { get; set; } // 0x10
        [Key(1)]
        public int SortOrder { get; set; } // 0x14
        [Key(2)]
        public int ListSettingAbilityGroupTargetId { get; set; } // 0x18
        [Key(3)]
        public int AssetId { get; set; } // 0x1C
        [Key(4)]
        public int ListSettingAbilityGroupType { get; set; } // 0x20
        [Key(5)]
        public long ListSettingDisplayStartDatetime { get; set; } // 0x28
    }
}