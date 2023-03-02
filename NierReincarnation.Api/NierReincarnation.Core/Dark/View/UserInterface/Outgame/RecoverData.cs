using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.View.UserInterface.Outgame
{
    public class RecoverData
    {
        public int ShopId { get; set; } // 0x10
        public int ShopItemId { get; set; } // 0x14
        public int ConsumableId { get; set; } // 0x18
        public string Name { get; set; } // 0x20
        public string DetailText { get; set; } // 0x28
        public int PossessionCount { get; set; } // 0x30
        public int EffectValue { get; set; } // 0x34
        public EffectTargetType EffectTargetType { get; set; } // 0x38
        public int NeedCount { get; set; } // 0x3C
        public int SortOrder { get; set; } // 0x40
        public bool IsGem { get; set; } // 0x44
        public int ConsumableItemTermId { get; set; } // 0x48
	}
}
