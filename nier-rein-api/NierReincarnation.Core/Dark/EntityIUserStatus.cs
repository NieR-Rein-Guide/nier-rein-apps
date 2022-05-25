using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_status")]
    public class EntityIUserStatus
    {
        [Key(0)] // RVA: 0x1DEAED4 Offset: 0x1DEAED4 VA: 0x1DEAED4
        public long UserId { get; set; }
        [Key(1)] // RVA: 0x1DEAF14 Offset: 0x1DEAF14 VA: 0x1DEAF14
        public int Level { get; set; }
        [Key(2)] // RVA: 0x1DEAF28 Offset: 0x1DEAF28 VA: 0x1DEAF28
        public int Exp { get; set; }
        [Key(3)] // RVA: 0x1DEAF3C Offset: 0x1DEAF3C VA: 0x1DEAF3C
        public int StaminaMilliValue { get; set; }  // 0x20
        [Key(4)] // RVA: 0x1DEAF50 Offset: 0x1DEAF50 VA: 0x1DEAF50
        public long StaminaUpdateDatetime { get; set; }
        [Key(5)] // RVA: 0x1DEAF64 Offset: 0x1DEAF64 VA: 0x1DEAF64
        public long LatestVersion { get; set; }

        // CUSTOM: To easily update the user status, if necessary
        public void SetUserStatus(EntityIUserStatus source)
        {
            UserId = source.UserId;
            Level = source.Level;
            Exp = source.Exp;
            StaminaMilliValue = source.StaminaMilliValue;
            StaminaUpdateDatetime = source.StaminaUpdateDatetime;
            LatestVersion = source.LatestVersion;
        }
	}
}
