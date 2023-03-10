using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Status;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark
{
    public class DataWeapon
    {
        private int SkillAiId; // 0x44
        private int ActorMovableAreaPrefabId; // 0x48

        // 0x10
        public DataWeaponStatus WeaponStatus { get; set; }

        // 0x18
        public List<DataSkill> Skills { get; }

        // 0x20
        public List<DataAbility> Abilities { get; }

        // 0x28
        public List<DataAbility> BlessAbilities { get; }

        // 0x30
        public int WeaponId { get; set; }

        // 0x34
        public int WeaponEvolutionGroupId { get; set; }

        // 0x38
        public int WeaponEvolutionOrder { get; set; }

        // 0x3C
        public RarityType RarityType { get; set; }

        // 0x40
        public int MaxLevel { get; set; }

        // 0x4C
        public int WeaponSkillGroupId { get; set; }

        // 0x50
        public int WeaponAbilityGroupId { get; set; }

        // 0x54
        public int WeaponEvolutionMaterialGroupId { get; set; }

        // 0x58
        public int BaseEnhancementObtainedExp { get; set; }

        // 0x60
        public string Name { get; set; }

        // 0x68
        public ActorAssetId ActorAssetId { get; set; }

        // 0x70
        public int WeaponSpecificEnhanceId { get; set; }

        // 0x74
        public int WeaponSpecificLimitBreakMaterialGroupId { get; set; }

        // 0x78
        public bool IsRestrictDiscard { get; set; }

        // 0x79
        public bool IsRecyclable { get; set; }

        // 0x7C
        public RarityType SeedWeaponRarityType { get; set; }

        // 0x80
        public int EndWeaponCharacterId { get; set; }

        // 0x84
        public bool HasAwakenRelation { get; set; }

        // 0x88
        public int AwakenLevelLimitUp { get; set; }

        // 0x8C
        public int WeaponAwakenMaterialGroupId { get; set; }

        // 0x90
        public int WeaponAwakenEffectGroupId { get; set; }

        // 0x94
        public int LimitBreakCount { get; set; }

        // 0x98
        public string UserWeaponUuid { get; set; }

        // 0xA0
        public long AcquisitionDatetime { get; set; }

        // 0xA8
        public int Exp { get; set; }

        // 0xAC
        public StatusValue StatusValue { get; set; }

        // 0xC8
        public int Power { get; set; }

        // 0xCC
        public bool IsAwaken { get; set; }

        public int ActualAwakenLevelLimitUp { get; }

        // 0xD0
        public Action<bool> OnChangeProtected { get; set; }

        // 0xD8
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
