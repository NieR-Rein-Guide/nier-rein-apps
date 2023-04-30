using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserPartsStatusSubTable : TableBase<EntityIUserPartsStatusSub>
    {
        private readonly Func<EntityIUserPartsStatusSub, (long, string, int)> primaryIndexSelector;

        public EntityIUserPartsStatusSubTable(EntityIUserPartsStatusSub[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.UserId, element.UserPartsUuid, element.StatusIndex);
        }
    }
}
