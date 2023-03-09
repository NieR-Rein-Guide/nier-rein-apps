using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    // Dark.Tables.EntityMConfigTable
    public sealed class EntityMConfigTable : TableBase<EntityMConfig>
    {
        // 0x18
        private readonly Func<EntityMConfig, string> primaryIndexSelector;

        public EntityMConfigTable(EntityMConfig[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.ConfigKey;
        }

        public EntityMConfig FindByConfigKey(string key)
        {
            return FindUniqueCore(data, primaryIndexSelector, StringComparer.InvariantCulture, key, false);
        }
    }
}
