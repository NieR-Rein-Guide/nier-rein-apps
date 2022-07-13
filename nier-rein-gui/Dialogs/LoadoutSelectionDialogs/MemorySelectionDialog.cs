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
        private IDictionary<DataOutgameMemoryInfo, NierMemoryItemButton> _memoryInfo;

        private readonly DataOutgameMemoryInfo _currentMemory;
        private readonly DataOutgameMemoryInfo[] _currentMemories;
        private readonly DataOutgameMemoryInfo[] _deckOtherMemories;

        protected override bool ShowAttributeFilter => false;
        protected override bool ShowWeaponTypeFilter => false;
        protected override bool ShowRarityFilter => true;

        public MemorySelectionDialog(DataOutgameMemoryInfo currentMemory, DataOutgameMemoryInfo[] currentMemories, DataOutgameMemoryInfo[] deckOtherMemories)
        {
            _currentMemory = currentMemory;
            _currentMemories = currentMemories;
            _deckOtherMemories = deckOtherMemories;

            Caption = "Memoirs";

            InitializeCostumeDataInfo();
        }

        private void InitializeCostumeDataInfo()
        {
            _memoryInfo = new Dictionary<DataOutgameMemoryInfo, NierMemoryItemButton>();

            foreach (var memoryInfo in CalculatorMemory.EnumerateMemories(CalculatorStateUser.GetUserId()))
                _memoryInfo[memoryInfo] = new NierMemoryItemButton
                {
                    Memory = memoryInfo,
                    Enabled = IsValidItem(memoryInfo)
                };
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

        private bool IsValidItem(DataOutgameMemoryInfo memoryInfo)
        {
            return _currentMemory?.PartsId != memoryInfo.PartsId &&
                   _currentMemories.All(x => x.PartsId != memoryInfo.PartsId) &&
                   _deckOtherMemories.All(x => x.PartsId != memoryInfo.PartsId);
        }
    }
}
