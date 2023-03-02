using System;
using System.Collections.Generic;
using NierReincarnation.Core.Dark.Status;

namespace NierReincarnation.Core.Dark.Calculator.Outgame
{
    class OutgameAbilityCache
    {
        private static readonly int kCharacterCapacity = 64; // 0x0
        private static readonly int kAbilityCacheCapacity = 128; // 0x4
        private static readonly int kAbilityMaxLevel = 0; // 0x8
        private static OutgameAbilityCache _instance = null; // 0x10

        public static bool IsCacheEnabled => _instance != null;

        private Dictionary<int, List<DataAbilityStatus>> _characterAbilityStatusCache; // 0x10
        private Dictionary<int, List<DataSkill>> _characterAbilityPassiveSkillCache; // 0x18
        private List<IDisposable> _onUserDataUpdatedDisposable; // 0x20
        private List<int> _characterIdList; // 0x28

        public static bool TryGetCharacterAbilityStatusList(int characterId, out List<DataAbilityStatus> abilityStatusList)
        {
            abilityStatusList = null;

            if (!IsCacheEnabled)
                return false;

            return _instance._characterAbilityStatusCache.TryGetValue(characterId, out abilityStatusList);
        }

        public static bool TryGetCharacterAbilityPassiveSkillList(int characterId, out List<DataSkill> abilityPassiveSkillList)
        {
            abilityPassiveSkillList = null;

            if (!IsCacheEnabled)
                return false;

            return _instance._characterAbilityPassiveSkillCache.TryGetValue(characterId, out abilityPassiveSkillList);
        }
    }
}
