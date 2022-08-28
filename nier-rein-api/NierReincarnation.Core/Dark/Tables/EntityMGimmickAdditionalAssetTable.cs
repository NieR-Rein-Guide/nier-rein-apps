using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMGimmickAdditionalAssetTable : TableBase<EntityMGimmickAdditionalAsset>
    {
        private readonly Func<EntityMGimmickAdditionalAsset, int> primaryIndexSelector;

        public EntityMGimmickAdditionalAssetTable(EntityMGimmickAdditionalAsset[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.GimmickId;
        }
        
    }
}
