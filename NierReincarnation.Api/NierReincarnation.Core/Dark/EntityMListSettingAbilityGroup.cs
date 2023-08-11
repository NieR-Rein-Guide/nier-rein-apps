using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_list_setting_ability_group")]
    public class EntityMListSettingAbilityGroup
    {
        [Key(0)]
        public int ListSettingAbilityGroupId { get; set; }

        [Key(1)]
        public int SortOrder { get; set; }

        [Key(2)]
        public int ListSettingAbilityGroupTargetId { get; set; }

        [Key(3)]
        public int AssetId { get; set; }

        [Key(4)]
        public ListSettingAbilityGroupType ListSettingAbilityGroupType { get; set; }

        [Key(5)]
        public long ListSettingDisplayStartDatetime { get; set; }
    }
}
