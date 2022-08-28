using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBattleBigHuntPhaseGroupTable : TableBase<EntityMBattleBigHuntPhaseGroup>
    {
        private readonly Func<EntityMBattleBigHuntPhaseGroup, (int,int)> primaryIndexSelector;

        public EntityMBattleBigHuntPhaseGroupTable(EntityMBattleBigHuntPhaseGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.BattleBigHuntPhaseGroupId,element.BattleBigHuntPhaseGroupOrder);
        }
        
        public RangeView<EntityMBattleBigHuntPhaseGroup> FindRangeByBattleBigHuntPhaseGroupIdAndBattleBigHuntPhaseGroupOrder(ValueTuple<int, int> min, ValueTuple<int, int> max, bool ascendant = true) { return FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int,int)>.Default, min, max, ascendant); }

    }
}
