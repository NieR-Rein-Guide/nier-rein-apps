using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_big_hunt_quest")]
    public class EntityMBigHuntQuest
    {
        [Key(0)] // RVA: 0x1DD651C Offset: 0x1DD651C VA: 0x1DD651C
        public int BigHuntQuestId { get; set; }
        [Key(1)] // RVA: 0x1DD655C Offset: 0x1DD655C VA: 0x1DD655C
        public int QuestId { get; set; }
        [Key(2)] // RVA: 0x1DD6570 Offset: 0x1DD6570 VA: 0x1DD6570
        public int BigHuntQuestScoreCoefficientId { get; set; }
	}
}
