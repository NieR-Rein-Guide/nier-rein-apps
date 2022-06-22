using System.Collections.Generic;
using System.Linq;
using ImGui.Forms.Resources;
using nier_rein_gui.Resources;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.View.HeadUpDisplay.Calculator;
using SixLabors.ImageSharp.Processing;

namespace nier_rein_gui.Dialogs.LoadoutSelectionDialogs
{
    class WeaponSelectionDialog : FilterItemDialog<DataWeaponInfo>
    {
        private static IDictionary<DataWeaponInfo, ImageResource> _weaponInfo;

        private readonly DataWeaponInfo _currentWeapon;
        private readonly DataWeaponInfo[] _deckWeapons;

        protected override bool ShowAttributeFilter => true;
        protected override bool ShowWeaponTypeFilter => true;
        protected override bool ShowRarityFilter => true;

        public WeaponSelectionDialog(DataWeaponInfo currentWeapon, DataWeaponInfo[] deckWeapons)
        {
            _currentWeapon = currentWeapon;
            _deckWeapons = deckWeapons;

            Caption = "Weapons";
        }

        public static void InitializeWeaponDataInfo()
        {
            if (_weaponInfo != null)
                return;

            _weaponInfo = new Dictionary<DataWeaponInfo, ImageResource>();

            foreach (var weaponInfo in CalculatorWeapon.EnumerateWeaponInfo(CalculatorStateUser.GetUserId()))
            {
                var weaponIcon = NierResources.LoadWeaponIconAsset(weaponInfo.ActorAssetId);
                weaponIcon.Image.Mutate(x => x.Resize(new SixLabors.ImageSharp.Size((int)NierResources.IconSize.X, (int)NierResources.IconSize.Y)));

                _weaponInfo[weaponInfo] = ImageResource.FromStream(weaponIcon.AsStream());
            }
        }

        protected override IEnumerable<DataWeaponInfo> EnumerateItems(IList<AttributeType> attributeFilter, IList<WeaponType> weaponFilter, IList<RarityType> rarityFilter)
        {
            var sortedElements = _weaponInfo.Keys
                .OrderByDescending(x => x.RarityType)
                .ThenBy(x => x.WeaponType)
                .ThenByDescending(x => x.IsEndWeapon)
                .ThenBy(x => x.Attribute)
                .ThenBy(x => x.WeaponId);

            foreach (var weaponInfo in sortedElements)
            {
                if (IsValidFilter(weaponInfo, attributeFilter, weaponFilter, rarityFilter))
                    yield return weaponInfo;
            }
        }

        protected override ImageResource GetItemImageResource(DataWeaponInfo item)
        {
            return _weaponInfo[item];
        }

        protected override AttributeType GetAttributeType(DataWeaponInfo item)
        {
            return item.Attribute;
        }

        protected override WeaponType GetWeaponType(DataWeaponInfo item)
        {
            return item.WeaponType;
        }

        protected override RarityType GetRarityType(DataWeaponInfo item)
        {
            return item.RarityType;
        }

        protected override bool IsEndItem(DataWeaponInfo item)
        {
            return item.IsEndWeapon;
        }

        private bool IsValidFilter(DataWeaponInfo weaponInfo, IList<AttributeType> attributeFilter, IList<WeaponType> weaponFilter, IList<RarityType> rarityFilter)
        {
            return attributeFilter.Contains(weaponInfo.Attribute) &&
                   weaponFilter.Contains(weaponInfo.WeaponType) &&
                   rarityFilter.Contains(weaponInfo.RarityType);
        }
    }
}
