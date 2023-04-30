using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMWebviewPanelMissionCompleteFlavorTextTable : TableBase<EntityMWebviewPanelMissionCompleteFlavorText>
    {
        private readonly Func<EntityMWebviewPanelMissionCompleteFlavorText, (int, LanguageType)> primaryIndexSelector;

        public EntityMWebviewPanelMissionCompleteFlavorTextTable(EntityMWebviewPanelMissionCompleteFlavorText[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.WebviewPanelMissionCompleteFlavorTextId, element.LanguageType);
        }

        public EntityMWebviewPanelMissionCompleteFlavorText FindByWebviewPanelMissionCompleteFlavorTextIdAndLanguageType(ValueTuple<int, LanguageType> key) =>
            FindUniqueCore(data, primaryIndexSelector, Comparer<(int, LanguageType)>.Default, key);
    }
}
