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
        private IDictionary<DataOutgameCompanionInfo, NierCompanionItemButton> _companionInfo;

        private readonly DataOutgameCompanionInfo _currentCompanion;
        private readonly DataOutgameCompanionInfo[] _deckCompanions;

        protected override bool ShowAttributeFilter => true;
        protected override bool ShowWeaponTypeFilter => false;
        protected override bool ShowRarityFilter => false;
        protected override bool ShowRemoveButton => _currentCompanion != null;

        public CompanionSelectionDialog(DataOutgameCompanionInfo currentCompanion, DataOutgameCompanionInfo[] deckCompanions)
        {
            _currentCompanion = currentCompanion;
            _deckCompanions = deckCompanions;

            Caption = "Costumes";

            InitializeCostumeDataInfo();
        }

        private void InitializeCostumeDataInfo()
        {
            _companionInfo = new Dictionary<DataOutgameCompanionInfo, NierCompanionItemButton>();

            foreach (var companionInfo in CalculatorCompanion.EnumerateCompanionInfo(CalculatorStateUser.GetUserId()))
                _companionInfo[companionInfo] = new NierCompanionItemButton
                {
                    Companion = companionInfo,
                    Enabled = IsValidItem(companionInfo),
                    Hint = GetHintType(companionInfo)
                };
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
                .OrderBy(x => GetButton(x).Hint)
                .ThenByDescending(x => x.Attribute);

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

        private bool IsValidItem(DataOutgameCompanionInfo companionInfo)
        {
            return _currentCompanion?.CompanionId != companionInfo.CompanionId &&
                   _deckCompanions.All(x => x.CompanionId != companionInfo.CompanionId);
        }

        private NierItemButton.HintType GetHintType(DataOutgameCompanionInfo companionInfo)
        {
            if (companionInfo.UserCompanionUuid == _currentCompanion?.UserCompanionUuid)
                return NierItemButton.HintType.Current;

            if (_deckCompanions.Any(x => x.UserCompanionUuid == companionInfo.UserCompanionUuid))
                return NierItemButton.HintType.InDeck;

            return NierItemButton.HintType.None;
        }
    }
}
