using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_main_quest_flow_status")]
    public class EntityIUserMainQuestFlowStatus
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10

        [Key(1)]
        public QuestFlowType CurrentQuestFlowType { get; set; } // 0x18

        [Key(2)]
        public long LatestVersion { get; set; } // 0x20
    }
}
