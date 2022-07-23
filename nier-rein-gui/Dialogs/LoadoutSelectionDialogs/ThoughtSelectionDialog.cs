using System.Collections.Generic;
using System.Linq;
using nier_rein_gui.Controls.Buttons.Items;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;

namespace nier_rein_gui.Dialogs.LoadoutSelectionDialogs
{
    class ThoughtSelectionDialog : FilterItemDialog<DataOutgameThought>
    {
        private IDictionary<DataOutgameThought, NierThoughtItemButton> _thoughtInfo;

        private readonly DataOutgameThought _currentThought;
        private readonly DataOutgameThought[] _deckThoughts;

        protected override bool ShowAttributeFilter => false;
        protected override bool ShowWeaponTypeFilter => false;
        protected override bool ShowRarityFilter => true;
        protected override bool ShowRemoveButton => _currentThought != null;

        public ThoughtSelectionDialog(DataOutgameThought currentThought, DataOutgameThought[] deckThoughts)
        {
            _currentThought = currentThought;
            _deckThoughts = deckThoughts;

            Caption = "Debris";

            InitializeThoughtDataInfo();
        }

        private void InitializeThoughtDataInfo()
        {
            _thoughtInfo = new Dictionary<DataOutgameThought, NierThoughtItemButton>();

            foreach (var userThought in CalculatorThought.EnumerateThoughts(CalculatorStateUser.GetUserId()))
                _thoughtInfo[userThought] = new NierThoughtItemButton
                {
                    Thought = userThought,
                    Enabled = IsValidItem(userThought),
                    Hint = GetHintType(userThought)
                };
        }

        protected override NierItemButton GetButton(DataOutgameThought item)
        {
            _thoughtInfo[item].Clicked -= SelectItemButton_Clicked;
            _thoughtInfo[item].Clicked += SelectItemButton_Clicked;

            return _thoughtInfo[item];
        }

        protected override DataOutgameThought GetItem(NierItemButton button)
        {
            return (button as NierThoughtItemButton).Thought;
        }

        protected override IEnumerable<DataOutgameThought> EnumerateItems(IList<AttributeType> attributeFilter, IList<WeaponType> weaponFilter, IList<RarityType> rarityFilter)
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

        private bool IsValidFilter(DataOutgameThought thought, IList<RarityType> rarityFilter)
        {
            return rarityFilter.Contains(thought.RarityType);
        }

        private bool IsValidItem(DataOutgameThought thought)
        {
            return _currentThought?.UserThoughtUuid != thought.UserThoughtUuid &&
                   _deckThoughts.All(x => x.UserThoughtUuid != thought.UserThoughtUuid);
        }

        private NierItemButton.HintType GetHintType(DataOutgameThought thought)
        {
            if (thought.UserThoughtUuid == _currentThought?.UserThoughtUuid)
                return NierItemButton.HintType.Current;

            if (_deckThoughts.Any(x => x.UserThoughtUuid == thought.UserThoughtUuid))
                return NierItemButton.HintType.InDeck;

            return NierItemButton.HintType.None;
        }
    }
}
