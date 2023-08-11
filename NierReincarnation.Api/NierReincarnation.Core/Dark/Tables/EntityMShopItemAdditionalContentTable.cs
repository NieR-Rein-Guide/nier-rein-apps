using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMShopItemAdditionalContentTable : TableBase<EntityMShopItemAdditionalContent>
{
    private readonly Func<EntityMShopItemAdditionalContent, (int, PossessionType, int)> primaryIndexSelector;

    public EntityMShopItemAdditionalContentTable(EntityMShopItemAdditionalContent[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.ShopItemAdditionalContentId, element.PossessionType, element.PossessionId);
    }
}
