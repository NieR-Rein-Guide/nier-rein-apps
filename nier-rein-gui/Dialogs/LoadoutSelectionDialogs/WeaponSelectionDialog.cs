using System.Collections.Generic;
using System.Linq;
using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Models;
using nier_rein_gui.Controls.Buttons.Items;
using nier_rein_gui.Resources;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.View.HeadUpDisplay.Calculator;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;

namespace nier_rein_gui.Dialogs.LoadoutSelectionDialogs
{
    class WeaponSelectionDialog : FilterItemDialog<DataWeaponInfo>
    {
        private IDictionary<DataWeaponInfo, NierWeaponItemButton> _weaponInfo;

        private readonly bool _isMain;
        private readonly DataWeaponInfo _currentWeapon;
        private readonly DataWeaponInfo[] _currentWeapons;
        private readonly DataWeaponInfo[] _deckOtherWeapons;

        private ComboBox<QuestItem> questSelection;

        protected override bool ShowAttributeFilter => true;
        protected override bool ShowWeaponTypeFilter => true;
        protected override bool ShowRarityFilter => true;
        protected override bool ShowRemoveButton => !_isMain && _currentWeapon != null;

        public WeaponSelectionDialog(DataWeaponInfo currentWeapon, bool isMain, DataWeaponInfo[] currentWeapons, DataWeaponInfo[] deckOtherWeapons)
        {
            _isMain = isMain;
            _currentWeapon = currentWeapon;
            _currentWeapons = currentWeapons;
            _deckOtherWeapons = deckOtherWeapons;

            Caption = LocalizationResources.WeaponsTitle;

            questSelection = AddQuestSelection();
            questSelection.SelectedItemChanged += QuestSelection_SelectedItemChanged;

            InitializeWeaponDataInfo();
            InitializeEventQuestData();
        }

        private void InitializeWeaponDataInfo()
        {
            _weaponInfo = new Dictionary<DataWeaponInfo, NierWeaponItemButton>();

            foreach (var weaponInfo in CalculatorWeapon.EnumerateWeaponInfo(CalculatorStateUser.GetUserId()))
                _weaponInfo[weaponInfo] = new NierWeaponItemButton
                {
                    Weapon = weaponInfo,
                    Enabled = IsValidItem(weaponInfo),
                    Hint = GetHintType(weaponInfo)
                };
        }

        private void InitializeEventQuestData()
        {
            questSelection.Items.Add(QuestItem.Empty);
            questSelection.SelectedItem = questSelection.Items[0];

            foreach (var chapter in CalculatorQuest.GetEventQuestChapters(EventQuestType.HUNT, EventQuestType.MARATHON).Where(c => c.IsCurrent()))
            {
                var quest = CalculatorQuest.GenerateEventQuestData(chapter.EventQuestChapterId, DifficultyType.NORMAL)[0];
                questSelection.Items.Add(new QuestItem(quest, chapter.EventQuestName));
            }
        }

        protected override IEnumerable<DataWeaponInfo> EnumerateItems(IList<AttributeType> attributeFilter, IList<WeaponType> weaponFilter, IList<RarityType> rarityFilter)
        {
            var sortedElements = _weaponInfo.Keys
                .OrderBy(x => GetButton(x).Hint)
                .ThenByDescending(x => GetButton(x).HasBonus)
                .ThenByDescending(x => x.RarityType)
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
                   _deckOtherWeapons.All(x => x.UserWeaponUuid != weaponInfo.UserWeaponUuid);
        }

        private NierItemButton.HintType GetHintType(DataWeaponInfo weaponInfo)
        {
            if (weaponInfo.UserWeaponUuid == _currentWeapon?.UserWeaponUuid)
                return NierItemButton.HintType.Current;

            if (_currentWeapons.Any(x => x.UserWeaponUuid == weaponInfo.UserWeaponUuid))
                return NierItemButton.HintType.InDeck;

            if (_deckOtherWeapons.Any(x => x.UserWeaponUuid == weaponInfo.UserWeaponUuid))
                return NierItemButton.HintType.InDeck;

            return NierItemButton.HintType.None;
        }

        private ComboBox<QuestItem> AddQuestSelection()
        {
            var cells = ((Content as StackLayout).Items[0].Content as TableLayout).Rows[0].Cells;

            var selection = new ComboBox<QuestItem>();
            cells.Add(new TableCell(selection) { Size = ImGui.Forms.Models.Size.WidthAlign, HorizontalAlignment = HorizontalAlignment.Right });

            return selection;
        }

        private void QuestSelection_SelectedItemChanged(object sender, System.EventArgs e)
        {
            if (questSelection.SelectedItem.Content.IsEmpty)
            {
                foreach (var weaponInfo in _weaponInfo.Values)
                    weaponInfo.HasBonus = false;

                UpdateItems();
                return;
            }

            var bonuses = CalculatorQuestBonus.GetQuestBonuses(questSelection.SelectedItem.Content.Quest.Quest);
            foreach (var weaponInfo in _weaponInfo)
                weaponInfo.Value.HasBonus = bonuses.Any(x => x.Id == weaponInfo.Key.WeaponId);

            UpdateItems();
        }

        class QuestItem
        {
            public static readonly QuestItem Empty = new QuestItem();

            public EventQuestData Quest { get; }
            public string Name { get; }

            public bool IsEmpty => Quest == null && Name == null;

            public QuestItem(EventQuestData quest = null, string name = null)
            {
                Quest = quest;
                Name = name;
            }

            public override string ToString()
            {
                return IsEmpty ? LocalizationResources.WeaponsNone : Name;
            }
        }
    }
}
