using System;
using System.Collections.Generic;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Status;

namespace NierReincarnation.Core.Dark
{
    public class DataWeapon
    {
        private int SkillAiId; // 0x3C
        private int ActorMovableAreaPrefabId; // 0x40

        // 0x10
        public DataWeaponStatus WeaponStatus { get; set; }
        // 0x18
        public List<DataSkill> Skills { get; }
        // 0x20
        public List<DataAbility> Abilities { get; }
        // 0x28
        public int WeaponId { get; set; }
        // 0x2C
        public int WeaponEvolutionGroupId { get; set; }
        // 0x30
        public int WeaponEvolutionOrder { get; set; }
        // 0x34
        public RarityType RarityType { get; set; }
        // 0x38
        public int MaxLevel { get; set; }

        // 0x44
        public int WeaponSkillGroupId { get; set; }
        // 0x48
        public int WeaponAbilityGroupId { get; set; }
        // 0x4C
        public int WeaponEvolutionMaterialGroupId { get; set; }
        // 0x50
        public int BaseEnhancementObtainedExp { get; set; }
        // 0x58
        public string Name { get; set; }
        // 0x60
        public ActorAssetId ActorAssetId { get; set; }
        // 0x68
        public int WeaponSpecificEnhanceId { get; set; }
        // 0x6C
        public int WeaponSpecificLimitBreakMaterialGroupId { get; set; }
        // 0x70
        public bool IsRestrictDiscard { get; set; }
        // 0x74
        public RarityType SeedWeaponRarityType { get; set; }
        // 0x78
        public int EndWeaponCharacterId { get; set; }
        // 0x7C
        public int LimitBreakCount { get; set; }
        // 0x80
        public string UserWeaponUuid { get; set; }
        // 0x88
        public long AcquisitionDatetime { get; set; }
        // 0x90
        public int Exp { get; set; }
        // 0x94
        public StatusValue StatusValue { get; set; }
        // 0xB0
        public int Power { get; set; }
        // 0xB8
        public Action<bool> OnChangeProtected { get; set; }
        // 0xC0
        public bool IsProtected { get; set; }

        public int Hp => StatusValue.Hp;
        public int Attack => StatusValue.Attack;
        public int Vitality => StatusValue.Vitality;

        public DataWeapon()
        {
            Skills = new List<DataSkill>();
            Abilities = new List<DataAbility>();
        }
    }
}
