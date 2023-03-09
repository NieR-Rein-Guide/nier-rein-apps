using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_cage_ornament_reward")]
    public class EntityIUserCageOrnamentReward
    {
        [Key(0)] // RVA: 0x1F83D84 Offset: 0x1F83D84 VA: 0x1F83D84
        public long UserId { get; set; }
        [Key(1)] // RVA: 0x1F83DC4 Offset: 0x1F83DC4 VA: 0x1F83DC4
        public int CageOrnamentId { get; set; }
        [Key(2)] // RVA: 0x1F83E04 Offset: 0x1F83E04 VA: 0x1F83E04
        public long AcquisitionDatetime { get; set; }
        [Key(3)] // RVA: 0x1F83E18 Offset: 0x1F83E18 VA: 0x1F83E18
        public long LatestVersion { get; set; }
	}
}
