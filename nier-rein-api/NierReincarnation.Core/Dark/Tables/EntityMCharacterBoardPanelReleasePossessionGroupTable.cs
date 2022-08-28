using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCharacterBoardPanelReleasePossessionGroupTable : TableBase<EntityMCharacterBoardPanelReleasePossessionGroup>
    {
        private readonly Func<EntityMCharacterBoardPanelReleasePossessionGroup, (int,int,int)> primaryIndexSelector;

        public EntityMCharacterBoardPanelReleasePossessionGroupTable(EntityMCharacterBoardPanelReleasePossessionGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.CharacterBoardPanelReleasePossessionGroupId,element.PossessionType,element.PossessionId);
        }
        
        public RangeView<EntityMCharacterBoardPanelReleasePossessionGroup> FindRangeByCharacterBoardPanelReleasePossessionGroupIdAndPossessionTypeAndPossessionId(ValueTuple<int, int, int> min, ValueTuple<int, int, int> max, bool ascendant = true) { return FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int,int,int)>.Default, min, max, ascendant); }

    }
}
