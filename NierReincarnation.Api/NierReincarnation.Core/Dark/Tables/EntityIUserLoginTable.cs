using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserLoginTable : TableBase<EntityIUserLogin>
    {
        private readonly Func<EntityIUserLogin, long> primaryIndexSelector;

        public EntityIUserLoginTable(EntityIUserLogin[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.UserId;
        }
    }
}
