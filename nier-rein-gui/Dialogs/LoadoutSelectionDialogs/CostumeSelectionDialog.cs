using System.Collections.Generic;
using System.Linq;
using ImGui.Forms.Resources;
using nier_rein_gui.Resources;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using SixLabors.ImageSharp.Processing;

namespace nier_rein_gui.Dialogs.LoadoutSelectionDialogs
{
    class CostumeSelectionDialog : FilterItemDialog<DataOutgameCostumeInfo>
    {
        private static IDictionary<DataOutgameCostumeInfo, ImageResource> _costumeInfo;

        private readonly DataOutgameCostumeInfo _currentCostume;

        protected override bool ShowAttributeFilter => false;
        protected override bool ShowWeaponTypeFilter => true;
        protected override bool ShowRarityFilter => true;

        public CostumeSelectionDialog(DataOutgameCostumeInfo currentCostume, DataOutgameCostumeInfo[] deckCostumes)
        {
            _currentCostume = currentCostume;

            Caption = "Costumes";
        }

        public static void InitializeCostumeDataInfo()
        {
            if (_costumeInfo != null)
                return;

            _costumeInfo = new Dictionary<DataOutgameCostumeInfo, ImageResource>();

            foreach (var costumeInfo in CalculatorCostume.EnumerateCostumeInfo(CalculatorStateUser.GetUserId()))
            {
                var costumeIcon = NierResources.LoadCostumeIconAsset(costumeInfo.ActorAssetId);
                costumeIcon.Image.Mutate(x => x.Resize(new SixLabors.ImageSharp.Size((int)NierResources.IconSize.X, (int)NierResources.IconSize.Y)));

                _costumeInfo[costumeInfo] = ImageResource.FromStream(costumeIcon.AsStream());
            }
        }

        protected override IEnumerable<DataOutgameCostumeInfo> EnumerateItems(IList<AttributeType> attributeFilter, IList<WeaponType> weaponFilter, IList<RarityType> rarityFilter)
        {
            var sortedElements = _costumeInfo.Keys
                .OrderByDescending(x => x.RarityType)
                .ThenBy(x => x.WeaponType);

            foreach (var costumeInfo in sortedElements)
            {
                if (IsValidFilter(costumeInfo, weaponFilter, rarityFilter))
                    yield return costumeInfo;
            }
        }

        protected override ImageResource GetItemImageResource(DataOutgameCostumeInfo item)
        {
            return _costumeInfo[item];
        }

        protected override AttributeType GetAttributeType(DataOutgameCostumeInfo item)
        {
            return AttributeType.UNKNOWN;
        }

        protected override WeaponType GetWeaponType(DataOutgameCostumeInfo item)
        {
            return item.WeaponType;
        }

        protected override RarityType GetRarityType(DataOutgameCostumeInfo item)
        {
            return item.RarityType;
        }

        protected override bool IsEndItem(DataOutgameCostumeInfo item)
        {
            return false;
        }

        private bool IsValidFilter(DataOutgameCostumeInfo weaponInfo, IList<WeaponType> weaponFilter, IList<RarityType> rarityFilter)
        {
            return weaponFilter.Contains(weaponInfo.WeaponType) &&
                   rarityFilter.Contains(weaponInfo.RarityType);
        }
    }
}
