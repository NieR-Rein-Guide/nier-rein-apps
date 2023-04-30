using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserDeckPartsGroupTable : TableBase<EntityIUserDeckPartsGroup>
    {
        private readonly Func<EntityIUserDeckPartsGroup, (long, string, string)> primaryIndexSelector;

        public EntityIUserDeckPartsGroupTable(EntityIUserDeckPartsGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.UserId, element.UserDeckCharacterUuid, element.UserPartsUuid);
        }
    }
}
