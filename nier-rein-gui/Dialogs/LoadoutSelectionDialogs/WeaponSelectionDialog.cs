using System.Collections.Generic;
using System.Linq;
using nier_rein_gui.Controls.Buttons.Items;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.View.HeadUpDisplay.Calculator;

namespace nier_rein_gui.Dialogs.LoadoutSelectionDialogs
{
    class WeaponSelectionDialog : FilterItemDialog<DataWeaponInfo>
    {
        private IDictionary<DataWeaponInfo, NierWeaponItemButton> _weaponInfo;

        private readonly DataWeaponInfo _currentWeapon;
        private readonly DataWeaponInfo[] _currentWeapons;
        private readonly DataWeaponInfo[] _deckOtherWeapons;

        protected override bool ShowAttributeFilter => true;
        protected override bool ShowWeaponTypeFilter => true;
        protected override bool ShowRarityFilter => true;

        public WeaponSelectionDialog(DataWeaponInfo currentWeapon, DataWeaponInfo[] currentWeapons, DataWeaponInfo[] deckOtherWeapons)
        {
            _currentWeapon = currentWeapon;
            _currentWeapons = currentWeapons;
            _deckOtherWeapons = deckOtherWeapons;

            Caption = "Weapons";

            InitializeWeaponDataInfo();
        }

        private void InitializeWeaponDataInfo()
        {
            _weaponInfo = new Dictionary<DataWeaponInfo, NierWeaponItemButton>();

            foreach (var weaponInfo in CalculatorWeapon.EnumerateWeaponInfo(CalculatorStateUser.GetUserId()))
                _weaponInfo[weaponInfo] = new NierWeaponItemButton
                {
                    Weapon = weaponInfo,
                    Enabled = IsValidItem(weaponInfo)
                };
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

        protected override NierItemButton GetButton(DataWeaponInfo item)
        {
            _weaponInfo[item].Clicked -= SelectItemButton_Clicked;
            _weaponInfo[item].Clicked += SelectItemButton_Clicked;

            return _weaponInfo[item];
        }

        protected override DataWeaponInfo GetItem(NierItemButton button)
        {
            return (button as NierWeaponItemButton).Weapon;
        }

        private bool IsValidFilter(DataWeaponInfo weaponInfo, IList<AttributeType> attributeFilter, IList<WeaponType> weaponFilter, IList<RarityType> rarityFilter)
        {
            return attributeFilter.Contains(weaponInfo.Attribute) &&
                   weaponFilter.Contains(weaponInfo.WeaponType) &&
                   rarityFilter.Contains(weaponInfo.RarityType);
        }

        private bool IsValidItem(DataWeaponInfo weaponInfo)
        {
            return _currentWeapon?.WeaponId != weaponInfo.WeaponId &&
                   _currentWeapons.All(x => x.WeaponId != weaponInfo.WeaponId) &&
                   _deckOtherWeapons.All(x => x.WeaponId != weaponInfo.WeaponId);
        }
    }
}
