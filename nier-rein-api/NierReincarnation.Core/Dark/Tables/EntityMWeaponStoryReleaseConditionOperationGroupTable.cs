using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMWeaponStoryReleaseConditionOperationGroupTable : TableBase<EntityMWeaponStoryReleaseConditionOperationGroup>
    {
        private readonly Func<EntityMWeaponStoryReleaseConditionOperationGroup, int> primaryIndexSelector;

        public EntityMWeaponStoryReleaseConditionOperationGroupTable(EntityMWeaponStoryReleaseConditionOperationGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.WeaponStoryReleaseConditionOperationGroupId;
        }
        
        public EntityMWeaponStoryReleaseConditionOperationGroup FindByWeaponStoryReleaseConditionOperationGroupId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}
