using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCharacterBoardPanelReleaseEffectGroupTable : TableBase<EntityMCharacterBoardPanelReleaseEffectGroup>
    {
        private readonly Func<EntityMCharacterBoardPanelReleaseEffectGroup, (int,int)> primaryIndexSelector;

        public EntityMCharacterBoardPanelReleaseEffectGroupTable(EntityMCharacterBoardPanelReleaseEffectGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.CharacterBoardPanelReleaseEffectGroupId,element.SortOrder);
        }
        
        public EntityMCharacterBoardPanelReleaseEffectGroup FindByCharacterBoardPanelReleaseEffectGroupIdAndSortOrder(ValueTuple<int, int> key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<(int,int)>.Default, key); }

    }
}
