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
        private static IDictionary<DataWeaponInfo, NierWeaponItemButton> _weaponInfo;

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

            InitializeWeaponDataInfo();
        }

        private void InitializeWeaponDataInfo()
        {
            if (_weaponInfo != null)
                return;

            _weaponInfo = new Dictionary<DataWeaponInfo, NierWeaponItemButton>();

            foreach (var weaponInfo in CalculatorWeapon.EnumerateWeaponInfo(CalculatorStateUser.GetUserId()))
                _weaponInfo[weaponInfo] = new NierWeaponItemButton { Weapon = weaponInfo };
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
    }
}
