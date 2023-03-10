using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserCharacterViewerFieldTable : TableBase<EntityIUserCharacterViewerField>
    {
        private readonly Func<EntityIUserCharacterViewerField, (long, int)> primaryIndexSelector;

        public EntityIUserCharacterViewerFieldTable(EntityIUserCharacterViewerField[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.UserId, element.CharacterViewerFieldId);
        }
    }
}
