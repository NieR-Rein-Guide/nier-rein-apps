using System;
using System.Collections.Generic;
using System.Numerics;
using ImGui.Forms;
using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Controls.Lists;
using ImGui.Forms.Modals;
using ImGui.Forms.Models;
using ImGui.Forms.Resources;
using nier_rein_gui.Controls.Buttons;
using nier_rein_gui.Resources;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Text;

namespace nier_rein_gui.Controls.CheckBoxes
{
    abstract class FilterItemDialog<T> : Modal
    {
        private const int FilterItemSpacing_ = 8;
        private const int LayoutItemSpacing_ = 5;

        private readonly IList<WeaponType> _weaponFilter;
        private readonly IList<AttributeType> _attributeFilter;
        private readonly IList<RarityType> _rarityFilter;

        private NierIconButton _activeItemButton;

        private NierAttributeCheckbox fireCheck;
        private NierAttributeCheckbox waterCheck;
        private NierAttributeCheckbox windCheck;
        private NierAttributeCheckbox lightCheck;
        private NierAttributeCheckbox darkCheck;

        private NierWeaponCheckbox swordCheck;
        private NierWeaponCheckbox bigSwordCheck;
        private NierWeaponCheckbox gunCheck;
        private NierWeaponCheckbox staffCheck;
        private NierWeaponCheckbox spearCheck;
        private NierWeaponCheckbox fistCheck;

        private NierRarityCheckbox rareCheck;
        private NierRarityCheckbox srCheck;
        private NierRarityCheckbox ssrCheck;
        private NierRarityCheckbox legendCheck;

        private CheckBox allAttributeCheck;
        private CheckBox allWeaponCheck;
        private CheckBox allRarityCheck;

        private readonly List itemList;

        private readonly NierButton cancelButton;
        private readonly NierButton selectButton;

        protected abstract bool ShowAttributeFilter { get; }
        protected abstract bool ShowWeaponTypeFilter { get; }
        protected abstract bool ShowRarityFilter { get; }

        public T SelectedItem { get; private set; }

        public FilterItemDialog()
        {
            _weaponFilter = new List<WeaponType>();
            _attributeFilter = new List<AttributeType>();
            _rarityFilter = new List<RarityType>();

            itemList = new List { ItemSpacing = LayoutItemSpacing_ };

            cancelButton = new NierButton { Caption = "Cancel" };
            selectButton = new NierButton { Caption = "Select", Enabled = false };

            cancelButton.Clicked += CancelButton_Clicked;
            selectButton.Clicked += SelectButton_Clicked;

            Size = new Vector2(GetDialogWidth(), Application.Instance.MainForm.Height - 50);
            Content = new StackLayout
            {
                Alignment = Alignment.Vertical,
                ItemSpacing = LayoutItemSpacing_,
                Items =
                {
                    GetFilterLayout(),
                    itemList,
                    new StackLayout
                    {
                        ItemSpacing = LayoutItemSpacing_,
                        Alignment = Alignment.Horizontal,
                        HorizontalAlignment = HorizontalAlignment.Right,
                        Size = new Size(1f,-1),
                        Items =
                        {
                            cancelButton,
                            selectButton
                        }
                    }
                }
            };
        }

        protected abstract IEnumerable<T> EnumerateItems(IList<AttributeType> attributeFilter, IList<WeaponType> weaponFilter, IList<RarityType> rarityFilter);

        protected abstract ImageResource GetItemImageResource(T item);
        protected abstract AttributeType GetAttributeType(T item);
        protected abstract WeaponType GetWeaponType(T item);
        protected abstract RarityType GetRarityType(T item);
        protected abstract bool IsEndItem(T item);

        #region Create layout

        private TableLayout GetFilterLayout()
        {
            var layout = new TableLayout
            {
                Size = new Size(1f, -1),
                Spacing = new Vector2(5, 3)
            };

            if (ShowAttributeFilter)
                layout.Rows.Add(CreateAttributeFilter());

            if (ShowWeaponTypeFilter)
                layout.Rows.Add(CreateWeaponTypeFilter());

            if (ShowRarityFilter)
                layout.Rows.Add(CreateRarityFilter());

            return layout;
        }

        private TableRow CreateAttributeFilter()
        {
            fireCheck = new NierAttributeCheckbox { Attribute = AttributeType.FIRE };
            waterCheck = new NierAttributeCheckbox { Attribute = AttributeType.WATER };
            windCheck = new NierAttributeCheckbox { Attribute = AttributeType.WIND };
            lightCheck = new NierAttributeCheckbox { Attribute = AttributeType.LIGHT };
            darkCheck = new NierAttributeCheckbox { Attribute = AttributeType.DARK };
            allAttributeCheck = new CheckBox { Caption = UserInterfaceTextKey.Organization.kAll.Localize() };

            fireCheck.CheckChanged += (s, e) => ToggleAttributeFilter(AttributeType.FIRE);
            waterCheck.CheckChanged += (s, e) => ToggleAttributeFilter(AttributeType.WATER);
            windCheck.CheckChanged += (s, e) => ToggleAttributeFilter(AttributeType.WIND);
            lightCheck.CheckChanged += (s, e) => ToggleAttributeFilter(AttributeType.LIGHT);
            darkCheck.CheckChanged += (s, e) => ToggleAttributeFilter(AttributeType.DARK);
            allAttributeCheck.CheckChanged += AllAttributeCheck_CheckChanged;

            return new TableRow
            {
                Cells =
                {
                    new StackLayout
                    {
                        Alignment = Alignment.Horizontal,
                        ItemSpacing = FilterItemSpacing_,
                        Size = ImGui.Forms.Models.Size.Content,
                        Items =
                        {
                            fireCheck,
                            waterCheck,
                            windCheck,
                            lightCheck,
                            darkCheck
                        }
                    },
                    allAttributeCheck
                }
            };
        }

        private TableRow CreateWeaponTypeFilter()
        {
            swordCheck = new NierWeaponCheckbox { WeaponType = WeaponType.SWORD };
            bigSwordCheck = new NierWeaponCheckbox { WeaponType = WeaponType.BIG_SWORD };
            gunCheck = new NierWeaponCheckbox { WeaponType = WeaponType.GUN };
            staffCheck = new NierWeaponCheckbox { WeaponType = WeaponType.STAFF };
            spearCheck = new NierWeaponCheckbox { WeaponType = WeaponType.SPEAR };
            fistCheck = new NierWeaponCheckbox { WeaponType = WeaponType.FIST };
            allWeaponCheck = new CheckBox { Caption = UserInterfaceTextKey.Organization.kAll.Localize() };

            swordCheck.CheckChanged += (s, e) => ToggleWeaponFilter(WeaponType.SWORD);
            bigSwordCheck.CheckChanged += (s, e) => ToggleWeaponFilter(WeaponType.BIG_SWORD);
            staffCheck.CheckChanged += (s, e) => ToggleWeaponFilter(WeaponType.STAFF);
            spearCheck.CheckChanged += (s, e) => ToggleWeaponFilter(WeaponType.SPEAR);
            gunCheck.CheckChanged += (s, e) => ToggleWeaponFilter(WeaponType.GUN);
            fistCheck.CheckChanged += (s, e) => ToggleWeaponFilter(WeaponType.FIST);
            allWeaponCheck.CheckChanged += AllWeaponCheck_CheckChanged;

            return new TableRow
            {
                Cells =
                {
                    new StackLayout
                    {
                        Alignment = Alignment.Horizontal,
                        ItemSpacing = FilterItemSpacing_,
                        Size = ImGui.Forms.Models.Size.Content,
                        Items =
                        {
                            swordCheck,
                            bigSwordCheck,
                            gunCheck,
                            staffCheck,
                            spearCheck,
                            fistCheck
                        }
                    },
                    allWeaponCheck
                }
            };
        }

        private TableRow CreateRarityFilter()
        {
            rareCheck = new NierRarityCheckbox { RarityType = RarityType.RARE };
            srCheck = new NierRarityCheckbox { RarityType = RarityType.S_RARE };
            ssrCheck = new NierRarityCheckbox { RarityType = RarityType.SS_RARE };
            legendCheck = new NierRarityCheckbox { RarityType = RarityType.LEGEND };
            allRarityCheck = new CheckBox { Caption = UserInterfaceTextKey.Organization.kAll.Localize() };

            rareCheck.CheckChanged += (s, e) => ToggleRarityFilter(RarityType.RARE);
            srCheck.CheckChanged += (s, e) => ToggleRarityFilter(RarityType.S_RARE);
            ssrCheck.CheckChanged += (s, e) => ToggleRarityFilter(RarityType.SS_RARE);
            legendCheck.CheckChanged += (s, e) => ToggleRarityFilter(RarityType.LEGEND);
            allRarityCheck.CheckChanged += AllRarityCheck_CheckChanged;

            return new TableRow
            {
                Cells =
                {
                    new StackLayout
                    {
                        Alignment = Alignment.Horizontal,
                        ItemSpacing = 8,
                        Size = ImGui.Forms.Models.Size.Content,
                        Items =
                        {
                            rareCheck,
                            srCheck,
                            ssrCheck,
                            legendCheck
                        }
                    },
                    allRarityCheck
                }
            };
        }

        private int GetDialogWidth()
        {
            var width = Application.Instance.MainForm.Width - 150;
            var remainder = (width - (int)ImGuiNET.ImGui.GetStyle().FramePadding.X * 2) %
                            ((int)NierResources.IconSize.X + FilterItemSpacing_);

            return width - remainder;
        }

        #endregion

        #region Item management

        private void UpdateItems()
        {
            CleanIcons();

            var widthCount = (int)Math.Floor(Size.X / (NierResources.IconSize.X + FilterItemSpacing_));

            StackLayout currentRow = null;
            var weaponIndex = 0;

            foreach (var item in EnumerateItems(_attributeFilter, _weaponFilter, _rarityFilter))
            {
                if (weaponIndex % widthCount == 0)
                {
                    currentRow = new StackLayout { Alignment = Alignment.Horizontal, ItemSpacing = FilterItemSpacing_ };
                    itemList.Items.Add(currentRow);
                }

                var button = new NierIconButton
                {
                    Image = GetItemImageResource(item),
                    Attribute = GetAttributeType(item),
                    WeaponType = GetWeaponType(item),
                    RarityType = GetRarityType(item),
                    IsEnd = IsEndItem(item)
                };
                button.Clicked += (s, e) =>
                {
                    if (_activeItemButton != null)
                        _activeItemButton.Active = false;

                    button.Active = true;
                    _activeItemButton = button;

                    SelectedItem = item;
                    selectButton.Enabled = true;
                };

                currentRow?.Items.Add(button);

                weaponIndex++;
            }
        }

        private void CleanIcons()
        {
            itemList.Items.Clear();
        }

        #endregion

        #region Attribute events

        private void AllAttributeCheck_CheckChanged(object sender, EventArgs e)
        {
            if (_attributeFilter.Count >= 5)
            {
                _attributeFilter.Clear();

                fireCheck.Checked = false;
                waterCheck.Checked = false;
                windCheck.Checked = false;
                darkCheck.Checked = false;
                lightCheck.Checked = false;

                UpdateItems();
                return;
            }

            for (var i = 1; i <= 6; i++)
                if (i != 4 && !_attributeFilter.Contains((AttributeType)i))
                    _attributeFilter.Add((AttributeType)i);

            fireCheck.Checked = true;
            waterCheck.Checked = true;
            windCheck.Checked = true;
            darkCheck.Checked = true;
            lightCheck.Checked = true;

            UpdateItems();
        }

        private void ToggleAttributeFilter(AttributeType attribute)
        {
            if (_attributeFilter.Contains(attribute))
            {
                _attributeFilter.Remove(attribute);
                if (_attributeFilter.Count < 5)
                    allAttributeCheck.Checked = false;
            }
            else
            {
                _attributeFilter.Add(attribute);
                if (_attributeFilter.Count >= 5)
                    allAttributeCheck.Checked = true;
            }

            UpdateItems();
        }

        #endregion

        #region Weapon type events

        private void AllWeaponCheck_CheckChanged(object sender, EventArgs e)
        {
            if (_weaponFilter.Count >= 5)
            {
                _weaponFilter.Clear();

                swordCheck.Checked = false;
                bigSwordCheck.Checked = false;
                staffCheck.Checked = false;
                spearCheck.Checked = false;
                gunCheck.Checked = false;
                fistCheck.Checked = false;

                UpdateItems();
                return;
            }

            for (var i = 1; i <= 5; i++)
                if (!_weaponFilter.Contains((WeaponType)i))
                    _weaponFilter.Add((WeaponType)i);

            swordCheck.Checked = true;
            bigSwordCheck.Checked = true;
            staffCheck.Checked = true;
            spearCheck.Checked = true;
            gunCheck.Checked = true;
            fistCheck.Checked = true;

            UpdateItems();
        }

        private void ToggleWeaponFilter(WeaponType weaponType)
        {
            if (_weaponFilter.Contains(weaponType))
            {
                _weaponFilter.Remove(weaponType);
                if (_weaponFilter.Count < 6)
                    allWeaponCheck.Checked = false;
            }
            else
            {
                _weaponFilter.Add(weaponType);
                if (_weaponFilter.Count >= 6)
                    allWeaponCheck.Checked = true;
            }

            UpdateItems();
        }

        #endregion

        #region Rarity events

        private void AllRarityCheck_CheckChanged(object sender, EventArgs e)
        {
            if (_rarityFilter.Count >= 4)
            {
                _rarityFilter.Clear();

                rareCheck.Checked = false;
                srCheck.Checked = false;
                ssrCheck.Checked = false;
                legendCheck.Checked = false;

                UpdateItems();
                return;
            }

            for (var i = 20; i <= 50; i += 10)
                if (!_rarityFilter.Contains((RarityType)i))
                    _rarityFilter.Add((RarityType)i);

            rareCheck.Checked = true;
            srCheck.Checked = true;
            ssrCheck.Checked = true;
            legendCheck.Checked = true;

            UpdateItems();
        }

        private void ToggleRarityFilter(RarityType rarityType)
        {
            if (_rarityFilter.Contains(rarityType))
            {
                _rarityFilter.Remove(rarityType);
                if (_rarityFilter.Count < 4)
                    allRarityCheck.Checked = false;
            }
            else
            {
                _rarityFilter.Add(rarityType);
                if (_rarityFilter.Count >= 4)
                    allRarityCheck.Checked = true;
            }

            UpdateItems();
        }

        #endregion

        #region Button events

        private void SelectButton_Clicked(object sender, EventArgs e)
        {
            Close(DialogResult.Ok);
        }

        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            Close(DialogResult.Cancel);
        }

        #endregion
    }
}
