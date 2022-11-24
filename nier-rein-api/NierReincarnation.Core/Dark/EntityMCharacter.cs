using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_character")]
    public class EntityMCharacter
    {
        [Key(0)] // RVA: 0x1DDA29C Offset: 0x1DDA29C VA: 0x1DDA29C
        public int CharacterId { get; set; } // 0x10
        [Key(1)] // RVA: 0x1DDA2DC Offset: 0x1DDA2DC VA: 0x1DDA2DC
        public int CharacterLevelBonusAbilityGroupId { get; set; } // 0x14
        [Key(2)] // RVA: 0x1DDA2F0 Offset: 0x1DDA2F0 VA: 0x1DDA2F0
        public int NameCharacterTextId { get; set; } // 0x18
        [Key(3)] // RVA: 0x1DDA304 Offset: 0x1DDA304 VA: 0x1DDA304
        public int CharacterAssetId { get; set; } // 0x1C
        [Key(4)] // RVA: 0x1DDA318 Offset: 0x1DDA318 VA: 0x1DDA318
        public int SortOrder { get; set; } // 0x20
        [Key(5)] // RVA: 0x1DDA32C Offset: 0x1DDA32C VA: 0x1DDA32C
        public int DefaultCostumeId { get; set; } // 0x24
        [Key(6)] // RVA: 0x1DDA340 Offset: 0x1DDA340 VA: 0x1DDA340
        public int DefaultWeaponId { get; set; } // 0x28
        [Key(7)] // RVA: 0x1DDA354 Offset: 0x1DDA354 VA: 0x1DDA354
        public int EndCostumeId { get; set; } // 0x2C
        [Key(8)] // RVA: 0x1DDA368 Offset: 0x1DDA368 VA: 0x1DDA368
        public int EndWeaponId { get; set; } // 0x30
        [Key(9)] // RVA: 0x1DDA3BC Offset: 0x1DDA3BC VA: 0x1DDA3BC
        public int MaxLevelNumericalFunctionId { get; set; } // 0x34
        [Key(10)] // RVA: 0x1DDA3D0 Offset: 0x1DDA3D0 VA: 0x1DDA3D0
        public int RequiredExpForLevelUpNumericalParameterMapId { get; set; } // 0x38
	}
}
