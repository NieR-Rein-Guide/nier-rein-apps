using System;
using System.Collections.Generic;
using NierReincarnation.Core.Dark.Status;

namespace NierReincarnation.Core.Dark.Calculator.Outgame
{
    class OutgameAbilityCache
    {
        private static readonly int kCharacterCapacity = 64;
        private static readonly int kAbilityCacheCapacity = 128;
        private static readonly int kAbilityMaxLevel = 0;
        private static OutgameAbilityCache _instance = null;

        public static bool IsCacheEnabled => _instance != null;

        private Dictionary<int, List<DataAbilityStatus>> _characterAbilityStatusCache;
        private Dictionary<int, List<DataSkill>> _characterAbilityPassiveSkillCache;
        private List<IDisposable> _onUserDataUpdatedDisposable;
        private List<int> _characterIdList;

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
