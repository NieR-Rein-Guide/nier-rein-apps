using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.View.UserInterface.Outgame;

public class RecoverData
{
    public int ShopId { get; set; }

    public int ShopItemId { get; set; }

    public int ConsumableId { get; set; }

    public string Name { get; set; }

    public string DetailText { get; set; }

    public int PossessionCount { get; set; }

    public int EffectValue { get; set; }

    public EffectTargetType EffectTargetType { get; set; }

    public int NeedCount { get; set; }

    public int SortOrder { get; set; }

    public bool IsGem { get; set; }

    public int ConsumableItemTermId { get; set; }
}
