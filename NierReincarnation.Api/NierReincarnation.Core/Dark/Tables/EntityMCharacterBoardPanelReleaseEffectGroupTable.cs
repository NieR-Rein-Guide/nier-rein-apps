using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMCharacterBoardPanelReleaseEffectGroupTable : TableBase<EntityMCharacterBoardPanelReleaseEffectGroup>
{
    private readonly Func<EntityMCharacterBoardPanelReleaseEffectGroup, (int, int)> primaryIndexSelector;

    public EntityMCharacterBoardPanelReleaseEffectGroupTable(EntityMCharacterBoardPanelReleaseEffectGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.CharacterBoardPanelReleaseEffectGroupId, element.SortOrder);
    }

    public EntityMCharacterBoardPanelReleaseEffectGroup FindByCharacterBoardPanelReleaseEffectGroupIdAndSortOrder(ValueTuple<int, int> key) =>
        FindUniqueCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, key);
}
