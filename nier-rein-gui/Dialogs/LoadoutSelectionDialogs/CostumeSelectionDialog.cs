using System.Collections.Generic;
using System.Linq;
using nier_rein_gui.Controls.Buttons.Items;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;

namespace nier_rein_gui.Dialogs.LoadoutSelectionDialogs
{
    class CostumeSelectionDialog : FilterItemDialog<DataOutgameCostumeInfo>
    {
        private static IDictionary<DataOutgameCostumeInfo, NierCostumeItemButton> _costumeInfo;

        private readonly DataOutgameCostumeInfo _currentCostume;
        private readonly DataOutgameCostumeInfo[] _deckCostumes;

        protected override bool ShowAttributeFilter => false;
        protected override bool ShowWeaponTypeFilter => true;
        protected override bool ShowRarityFilter => true;

        public CostumeSelectionDialog(DataOutgameCostumeInfo currentCostume, DataOutgameCostumeInfo[] deckCostumes)
        {
            _currentCostume = currentCostume;
            _deckCostumes = deckCostumes;

            Caption = "Costumes";

            InitializeCostumeDataInfo();
        }

        private void InitializeCostumeDataInfo()
        {
            if (_costumeInfo != null)
                return;

            _costumeInfo = new Dictionary<DataOutgameCostumeInfo, NierCostumeItemButton>();

            foreach (var costumeInfo in CalculatorCostume.EnumerateCostumeInfo(CalculatorStateUser.GetUserId()))
                _costumeInfo[costumeInfo] = new NierCostumeItemButton { Costume = costumeInfo };
        }

        protected override NierItemButton GetButton(DataOutgameCostumeInfo item)
        {
            _costumeInfo[item].Clicked -= SelectItemButton_Clicked;
            _costumeInfo[item].Clicked += SelectItemButton_Clicked;

            return _costumeInfo[item];
        }

        protected override DataOutgameCostumeInfo GetItem(NierItemButton button)
        {
            return (button as NierCostumeItemButton).Costume;
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

        private bool IsValidFilter(DataOutgameCostumeInfo weaponInfo, IList<WeaponType> weaponFilter, IList<RarityType> rarityFilter)
        {
            return weaponFilter.Contains(weaponInfo.WeaponType) &&
                   rarityFilter.Contains(weaponInfo.RarityType);
        }
    }
}
