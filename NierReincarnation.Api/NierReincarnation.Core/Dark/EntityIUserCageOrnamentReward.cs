using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_cage_ornament_reward")]
    public class EntityIUserCageOrnamentReward
    {
        [Key(0)]
        public long UserId { get; set; }

        [Key(1)]
        public int CageOrnamentId { get; set; }

        [Key(2)]
        public long AcquisitionDatetime { get; set; }

        [Key(3)]
        public long LatestVersion { get; set; }
    }
}
