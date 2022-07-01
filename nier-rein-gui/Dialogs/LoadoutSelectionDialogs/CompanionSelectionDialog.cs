using System.Collections.Generic;
using System.Linq;
using nier_rein_gui.Controls.Buttons.Items;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;

namespace nier_rein_gui.Dialogs.LoadoutSelectionDialogs
{
    class CompanionSelectionDialog : FilterItemDialog<DataOutgameCompanionInfo>
    {
        private static IDictionary<DataOutgameCompanionInfo, NierCompanionItemButton> _companionInfo;

        private readonly DataOutgameCompanionInfo _currentCompanion;
        private readonly DataOutgameCompanionInfo[] _deckCompanions;

        protected override bool ShowAttributeFilter => true;
        protected override bool ShowWeaponTypeFilter => false;
        protected override bool ShowRarityFilter => false;

        public CompanionSelectionDialog(DataOutgameCompanionInfo currentCompanion, DataOutgameCompanionInfo[] deckCompanions)
        {
            _currentCompanion = currentCompanion;
            _deckCompanions = deckCompanions;

            Caption = "Costumes";

            InitializeCostumeDataInfo();
        }

        private void InitializeCostumeDataInfo()
        {
            if (_companionInfo != null)
                return;

            _companionInfo = new Dictionary<DataOutgameCompanionInfo, NierCompanionItemButton>();

            foreach (var companionInfo in CalculatorCompanion.EnumerateCompanionInfo(CalculatorStateUser.GetUserId()))
                _companionInfo[companionInfo] = new NierCompanionItemButton { Companion = companionInfo };
        }

        protected override NierItemButton GetButton(DataOutgameCompanionInfo item)
        {
            _companionInfo[item].Clicked -= SelectItemButton_Clicked;
            _companionInfo[item].Clicked += SelectItemButton_Clicked;

            return _companionInfo[item];
        }

        protected override DataOutgameCompanionInfo GetItem(NierItemButton button)
        {
            return (button as NierCompanionItemButton).Companion;
        }

        protected override IEnumerable<DataOutgameCompanionInfo> EnumerateItems(IList<AttributeType> attributeFilter, IList<WeaponType> weaponFilter, IList<RarityType> rarityFilter)
        {
            var sortedElements = _companionInfo.Keys
                .OrderByDescending(x => x.Attribute);

            foreach (var companionInfo in sortedElements)
            {
                if (IsValidFilter(companionInfo, attributeFilter))
                    yield return companionInfo;
            }
        }

        private bool IsValidFilter(DataOutgameCompanionInfo companionInfo, IList<AttributeType> attributeFilter)
        {
            return attributeFilter.Contains(companionInfo.Attribute);
        }
    }
}
