using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_mission_unlock_condition")]
    public class EntityMMissionUnlockCondition
    {
        [Key(0)]
        public int MissionUnlockConditionId { get; set; } // 0x10
        [Key(1)]
        public int MissionUnlockConditionType { get; set; } // 0x14
        [Key(2)]
        public int ConditionValue { get; set; } // 0x18
    }
}