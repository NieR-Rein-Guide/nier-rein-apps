using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_mission_clear_condition_value_view")]
    public class EntityMMissionClearConditionValueView
    {
        [Key(0)]
        public MissionClearConditionType MissionClearConditionType { get; set; } // 0x10

        [Key(1)]
        public int ViewClearConditionValue { get; set; } // 0x14
    }
}
