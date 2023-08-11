using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMAssetDataSettingTable : TableBase<EntityMAssetDataSetting>
{
    private readonly Func<EntityMAssetDataSetting, int> primaryIndexSelector;

    public EntityMAssetDataSettingTable(EntityMAssetDataSetting[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.AssetDataSettingId;
    }
}
