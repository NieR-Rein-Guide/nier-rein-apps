using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMWeaponStoryReleaseConditionOperationGroupTable : TableBase<EntityMWeaponStoryReleaseConditionOperationGroup>
{
    private readonly Func<EntityMWeaponStoryReleaseConditionOperationGroup, int> primaryIndexSelector;

    public EntityMWeaponStoryReleaseConditionOperationGroupTable(EntityMWeaponStoryReleaseConditionOperationGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.WeaponStoryReleaseConditionOperationGroupId;
    }

    public EntityMWeaponStoryReleaseConditionOperationGroup FindByWeaponStoryReleaseConditionOperationGroupId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
