using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_quest_mission")]
    public class EntityIUserQuestMission
    {
        [Key(0)] // RVA: 0x1DEAAD4 Offset: 0x1DEAAD4 VA: 0x1DEAAD4
        public long UserId { get; set; }
        [Key(1)] // RVA: 0x1DEAB14 Offset: 0x1DEAB14 VA: 0x1DEAB14
        public int QuestId { get; set; }
        [Key(2)] // RVA: 0x1DEAB54 Offset: 0x1DEAB54 VA: 0x1DEAB54
        public int QuestMissionId { get; set; }
        [Key(3)] // RVA: 0x1DEAB94 Offset: 0x1DEAB94 VA: 0x1DEAB94
        public int ProgressValue { get; set; }
        [Key(4)] // RVA: 0x1DEABA8 Offset: 0x1DEABA8 VA: 0x1DEABA8
        public bool IsClear { get; set; }
        [Key(5)] // RVA: 0x1DEABBC Offset: 0x1DEABBC VA: 0x1DEABBC
        public long LatestClearDatetime { get; set; }
        [Key(6)] // RVA: 0x1DEABD0 Offset: 0x1DEABD0 VA: 0x1DEABD0
        public long LatestVersion { get; set; }
	}
}
