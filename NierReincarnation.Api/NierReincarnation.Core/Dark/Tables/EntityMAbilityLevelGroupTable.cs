using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMAbilityLevelGroupTable : TableBase<EntityMAbilityLevelGroup> // TypeDefIndex: 11545
    {
        // Fields
        private readonly Func<EntityMAbilityLevelGroup, (int, int)> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C402D0 Offset: 0x2C402D0 VA: 0x2C402D0
        public EntityMAbilityLevelGroupTable(EntityMAbilityLevelGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = group => (group.AbilityLevelGroupId, group.LevelLowerLimit);
        }

        // RVA: 0x2C403D0 Offset: 0x2C403D0 VA: 0x2C403D0
        public EntityMAbilityLevelGroup FindClosestByAbilityLevelGroupIdAndLevelLowerLimit((int, int) key, bool selectLower = true)
        {
            return FindUniqueClosestCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, key, selectLower);
        }
    }
}
