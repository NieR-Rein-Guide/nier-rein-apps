﻿using NierReincarnation.Core.Dark.Calculator.Outgame;

namespace NierReincarnation.Core.Dark.View.UserInterface.Outgame;

public class DataOutgameThought
{
    public int ThoughtId { get; }

    public RarityType RarityType { get; }

    public int AbilityId { get; }

    public int AbilityLevel { get; }

    public int ThoughtAssetId { get; }

    public string UserThoughtUuid { get; }

    public long AcquisitionDatetime { get; }

    public bool IsEmptyUserData => string.IsNullOrEmpty(UserThoughtUuid) || AcquisitionDatetime == CalculatorThought.kInvalidThoughtAcquisitionDatetime;

    public string ThoughtName { get; }

    public string ThoughtDescription { get; }

    public DataAbility Ability { get; }

    public DataOutgameThought(int thoughtId, RarityType rarityType, int abilityId, int abilityLevel,
        int thoughtAssetId, string userThoughtUuid, long acquisitionDatetime, string thoughtName,
        string thoughtDescription, DataAbility ability)
    {
        ThoughtId = thoughtId;
        RarityType = rarityType;
        AbilityId = abilityId;
        AbilityLevel = abilityLevel;
        ThoughtAssetId = thoughtAssetId;
        UserThoughtUuid = userThoughtUuid;
        AcquisitionDatetime = acquisitionDatetime;
        ThoughtName = thoughtName;
        ThoughtDescription = thoughtDescription;
        Ability = ability;
    }
}
