using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMAssetEffectTable : TableBase<EntityMAssetEffect>
{
    private readonly Func<EntityMAssetEffect, int> primaryIndexSelector;

    public EntityMAssetEffectTable(EntityMAssetEffect[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.AssetEffectId;
    }
}
