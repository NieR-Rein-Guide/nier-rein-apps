using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMWeaponEvolutionGroupTable : TableBase<EntityMWeaponEvolutionGroup> // TypeDefIndex: 12425
    {
        // Fields
        private readonly Func<EntityMWeaponEvolutionGroup, ValueTuple<int, int>> primaryIndexSelector; // 0x18
        private readonly Func<EntityMWeaponEvolutionGroup, int> secondaryIndex0Selector; // 0x28
        private readonly Func<EntityMWeaponEvolutionGroup, int> secondaryIndex1Selector; // 0x38

        // Methods

        // RVA: 0x2BABE48 Offset: 0x2BABE48 VA: 0x2BABE48
        public EntityMWeaponEvolutionGroupTable(EntityMWeaponEvolutionGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = group => (group.WeaponEvolutionGroupId, group.EvolutionOrder);
            secondaryIndex0Selector = group => group.WeaponEvolutionGroupId;
            secondaryIndex1Selector = group => group.WeaponId;
        }

        // RVA: 0x2BAC240 Offset: 0x2BAC240 VA: 0x2BAC240
        public RangeView<EntityMWeaponEvolutionGroup> FindByWeaponId(int key)
        {
            var result = new List<EntityMWeaponEvolutionGroup>();

            foreach (var entry in data)
                if (secondaryIndex1Selector(entry) == key)
                    result.Add(entry);

            return new RangeView<EntityMWeaponEvolutionGroup>(result.ToArray(), 0, result.Count - 1, true);
        }

        public EntityMWeaponEvolutionGroup FindClosestByWeaponEvolutionGroupIdAndEvolutionOrder(ValueTuple<int, int> key, bool selectLower = true)
        {
            return FindUniqueClosestCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, key, selectLower);
        }

        public RangeView<EntityMWeaponEvolutionGroup> FindByWeaponEvolutionGroupId(int key)
        {
            var result = new List<EntityMWeaponEvolutionGroup>();

            foreach (var element in data)
                if (secondaryIndex0Selector(element) == key)
                    result.Add(element);

            return new RangeView<EntityMWeaponEvolutionGroup>(result.ToArray(), 0, result.Count - 1, true);
        }
    }
}
