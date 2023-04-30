using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCharacterBoardPanelTable : TableBase<EntityMCharacterBoardPanel>
    {
        private readonly Func<EntityMCharacterBoardPanel, int> primaryIndexSelector;

        public EntityMCharacterBoardPanelTable(EntityMCharacterBoardPanel[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.CharacterBoardPanelId;
        }

        public EntityMCharacterBoardPanel FindByCharacterBoardPanelId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
    }
}
