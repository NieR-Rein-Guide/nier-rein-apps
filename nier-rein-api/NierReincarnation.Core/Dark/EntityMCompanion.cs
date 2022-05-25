using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_companion")]
    public class EntityMCompanion
    {
        [Key(0)] // RVA: 0x1DDB3DC Offset: 0x1DDB3DC VA: 0x1DDB3DC
        public int CompanionId { get; set; }    // 0x10
        [Key(1)] // RVA: 0x1DDB41C Offset: 0x1DDB41C VA: 0x1DDB41C
        public AttributeType AttributeType { get; set; }
        [Key(2)] // RVA: 0x1DDB430 Offset: 0x1DDB430 VA: 0x1DDB430
        public int CompanionCategoryType { get; set; }
        [Key(3)] // RVA: 0x1DDB444 Offset: 0x1DDB444 VA: 0x1DDB444
        public int CompanionBaseStatusId { get; set; }
        [Key(4)] // RVA: 0x1DDB458 Offset: 0x1DDB458 VA: 0x1DDB458
        public int CompanionStatusCalculationId { get; set; }   // 0x20
        [Key(5)] // RVA: 0x1DDB46C Offset: 0x1DDB46C VA: 0x1DDB46C
        public int SkillId { get; set; }
        [Key(6)] // RVA: 0x1DDB480 Offset: 0x1DDB480 VA: 0x1DDB480
        public int CompanionAbilityGroupId { get; set; }
        [Key(7)] // RVA: 0x1DDB494 Offset: 0x1DDB494 VA: 0x1DDB494
        public int ActorId { get; set; }
        [Key(8)] // RVA: 0x1DDB4A8 Offset: 0x1DDB4A8 VA: 0x1DDB4A8
        public int ActorSkeletonId { get; set; }    // 0x30
        [Key(9)] // RVA: 0x1DDB4BC Offset: 0x1DDB4BC VA: 0x1DDB4BC
        public int AssetVariationId { get; set; }
        [Key(10)] // RVA: 0x1DDB4D0 Offset: 0x1DDB4D0 VA: 0x1DDB4D0
        public int CharacterMoverBattleActorAiId { get; set; }
	}
}
