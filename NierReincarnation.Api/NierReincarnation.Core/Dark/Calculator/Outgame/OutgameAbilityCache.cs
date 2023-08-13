using NierReincarnation.Core.Dark.Status;

namespace NierReincarnation.Core.Dark.Calculator.Outgame;

public sealed class OutgameAbilityCache
{
    private const int kCharacterCapacity = 64;
    private const int kAbilityCacheCapacity = 128;
    private const int kAbilityMaxLevel = 0;
    private static readonly OutgameAbilityCache _instance;

    public static bool IsCacheEnabled => _instance != null;

    private readonly Dictionary<int, List<DataAbilityStatus>> _characterAbilityStatusCache;
    private readonly Dictionary<int, List<DataSkill>> _characterAbilityPassiveSkillCache;
    private readonly List<IDisposable> _onUserDataUpdatedDisposable;
    private readonly List<int> _characterIdList;

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
