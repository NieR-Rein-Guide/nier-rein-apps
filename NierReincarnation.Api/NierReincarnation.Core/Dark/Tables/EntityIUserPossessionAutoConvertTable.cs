using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserPossessionAutoConvertTable : TableBase<EntityIUserPossessionAutoConvert>
    {
        private readonly Func<EntityIUserPossessionAutoConvert, (long, PossessionType, int)> primaryIndexSelector;

        public EntityIUserPossessionAutoConvertTable(EntityIUserPossessionAutoConvert[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.UserId, element.PossessionType, element.PossessionId);
        }
    }
}
