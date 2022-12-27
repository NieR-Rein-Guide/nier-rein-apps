using System.Collections.Generic;
using System.Linq;
using nier_rein_gui.Controls.Buttons.Items;
using nier_rein_gui.Resources;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;

namespace nier_rein_gui.Dialogs.LoadoutSelectionDialogs
{
    class ThoughtSelectionDialog : FilterItemDialog<DataOutgameThoughtInfo>
    {
        private IDictionary<DataOutgameThoughtInfo, NierThoughtItemButton> _thoughtInfo;

        private readonly DataOutgameThoughtInfo _currentThought;
        private readonly DataOutgameThoughtInfo[] _deckThoughts;

        protected override bool ShowAttributeFilter => false;
        protected override bool ShowWeaponTypeFilter => false;
        protected override bool ShowRarityFilter => true;
        protected override bool ShowRemoveButton => _currentThought != null;

        public ThoughtSelectionDialog(DataOutgameThoughtInfo currentThought, DataOutgameThoughtInfo[] deckThoughts)
        {
            _currentThought = currentThought;
            _deckThoughts = deckThoughts;

            Caption = LocalizationResources.DebrisTitle;

            InitializeThoughtDataInfo();
        }

        private void InitializeThoughtDataInfo()
        {
            _thoughtInfo = new Dictionary<DataOutgameThoughtInfo, NierThoughtItemButton>();

            foreach (var userThought in CalculatorThought.EnumerateThoughtsInfo(CalculatorStateUser.GetUserId()))
                _thoughtInfo[userThought] = new NierThoughtItemButton
                {
                    Thought = userThought,
                    Enabled = IsValidItem(userThought),
                    Hint = GetHintType(userThought)
                };
        }

        protected override NierItemButton GetButton(DataOutgameThoughtInfo item)
        {
            _thoughtInfo[item].Clicked -= SelectItemButton_Clicked;
            _thoughtInfo[item].Clicked += SelectItemButton_Clicked;

            return _thoughtInfo[item];
        }

        protected override DataOutgameThoughtInfo GetItem(NierItemButton button)
        {
            return (button as NierThoughtItemButton).Thought;
        }

        protected override IEnumerable<DataOutgameThoughtInfo> EnumerateItems(IList<AttributeType> attributeFilter, IList<WeaponType> weaponFilter, IList<RarityType> rarityFilter)
        {
            var sortedElements = _thoughtInfo.Keys
                .OrderBy(x => GetButton(x).Hint)
                .ThenByDescending(x => x.RarityType);

            foreach (var thoughtItem in sortedElements)
            {
                if (IsValidFilter(thoughtItem, rarityFilter))
                    yield return thoughtItem;
            }
        }

        private bool IsValidFilter(DataOutgameThoughtInfo thought, IList<RarityType> rarityFilter)
        {
            return rarityFilter.Contains(thought.RarityType);
        }

        private bool IsValidItem(DataOutgameThoughtInfo thought)
        {
            return _currentThought?.UserThoughtUuid != thought.UserThoughtUuid &&
                   _deckThoughts.All(x => x.UserThoughtUuid != thought.UserThoughtUuid);
        }

        private NierItemButton.HintType GetHintType(DataOutgameThoughtInfo thought)
        {
            if (thought.UserThoughtUuid == _currentThought?.UserThoughtUuid)
                return NierItemButton.HintType.Current;

            if (_deckThoughts.Any(x => x.UserThoughtUuid == thought.UserThoughtUuid))
                return NierItemButton.HintType.InDeck;

            return NierItemButton.HintType.None;
        }
    }
}
