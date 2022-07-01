using System.Collections.Generic;
using System.Linq;
using nier_rein_gui.Controls.Buttons.Items;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;

namespace nier_rein_gui.Dialogs.LoadoutSelectionDialogs
{
    class MemorySelectionDialog : FilterItemDialog<DataOutgameMemoryInfo>
    {
        private static IDictionary<DataOutgameMemoryInfo, NierMemoryItemButton> _memoryInfo;

        private readonly DataOutgameMemoryInfo _currentMemory;
        private readonly DataOutgameMemoryInfo[] _deckMemories;

        protected override bool ShowAttributeFilter => false;
        protected override bool ShowWeaponTypeFilter => false;
        protected override bool ShowRarityFilter => true;

        public MemorySelectionDialog(DataOutgameMemoryInfo currentMemory, DataOutgameMemoryInfo[] deckMemories)
        {
            _currentMemory = currentMemory;
            _deckMemories = deckMemories;

            Caption = "Memoirs";

            InitializeCostumeDataInfo();
        }

        private void InitializeCostumeDataInfo()
        {
            if (_memoryInfo != null)
                return;

            _memoryInfo = new Dictionary<DataOutgameMemoryInfo, NierMemoryItemButton>();

            foreach (var memoryInfo in CalculatorMemory.EnumerateMemories(CalculatorStateUser.GetUserId()))
                _memoryInfo[memoryInfo] = new NierMemoryItemButton { Memory = memoryInfo };
        }

        protected override NierItemButton GetButton(DataOutgameMemoryInfo item)
        {
            _memoryInfo[item].Clicked -= SelectItemButton_Clicked;
            _memoryInfo[item].Clicked += SelectItemButton_Clicked;

            return _memoryInfo[item];
        }

        protected override DataOutgameMemoryInfo GetItem(NierItemButton button)
        {
            return (button as NierMemoryItemButton).Memory;
        }

        protected override IEnumerable<DataOutgameMemoryInfo> EnumerateItems(IList<AttributeType> attributeFilter, IList<WeaponType> weaponFilter, IList<RarityType> rarityFilter)
        {
            var sortedElements = _memoryInfo.Keys
                .OrderByDescending(x => x.RarityType);

            foreach (var memoryInfo in sortedElements)
            {
                if (IsValidFilter(memoryInfo, rarityFilter))
                    yield return memoryInfo;
            }
        }

        private bool IsValidFilter(DataOutgameMemoryInfo memoryInfo, IList<RarityType> rarityFilter)
        {
            return rarityFilter.Contains(memoryInfo.RarityType);
        }
    }
}
