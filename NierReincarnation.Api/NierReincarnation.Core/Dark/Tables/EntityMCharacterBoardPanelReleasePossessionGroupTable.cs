using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCharacterBoardPanelReleasePossessionGroupTable : TableBase<EntityMCharacterBoardPanelReleasePossessionGroup>
    {
        private readonly Func<EntityMCharacterBoardPanelReleasePossessionGroup, (int, PossessionType, int)> primaryIndexSelector;

        public EntityMCharacterBoardPanelReleasePossessionGroupTable(EntityMCharacterBoardPanelReleasePossessionGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.CharacterBoardPanelReleasePossessionGroupId, element.PossessionType, element.PossessionId);
        }

        public RangeView<EntityMCharacterBoardPanelReleasePossessionGroup> FindRangeByCharacterBoardPanelReleasePossessionGroupIdAndPossessionTypeAndPossessionId(
            ValueTuple<int, PossessionType, int> min, ValueTuple<int, PossessionType, int> max, bool ascendant = true) =>
            FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, PossessionType, int)>.Default, min, max, ascendant);
    }
}
