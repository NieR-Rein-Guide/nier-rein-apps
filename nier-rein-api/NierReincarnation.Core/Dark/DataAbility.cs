using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NierReincarnation.Core.Dark.Status;

namespace NierReincarnation.Core.Dark
{
    public class DataAbility
    {
        // 0x10
        public int AbilityId { get; set; }
        // 0x14
        public int SlotNumber { get; set; }
        // 0x18
        public string AbilityName { get; set; }
        // 0x20
        public int AbilityLevel { get; set; }
        // 0x24
        public int AbilityMaxLevel { get; set; }
        // 0x28
        public int AbilityCategoryId { get; set; }
        // 0x2C
        public int AbilityVariationId { get; set; }
        // 0x30
        public string AbilityDescriptionText { get; set; }
        // 0x38
        public List<DataAbilityStatus> AbilityStatusList { get; set; }
        // 0x40
        public List<DataSkill> PassiveSkillList { get; set; }
        // 0x48
        public bool IsLocked { get; set; }
        // 0x50
        public string LockTextKey { get; set; }
    }
}
