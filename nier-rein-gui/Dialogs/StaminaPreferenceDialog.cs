using System.Linq;
using System.Numerics;
using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Controls.Lists;
using ImGui.Forms.Modals;
using ImGui.Forms.Models;
using ImGuiNET;
using nie_rein_gui.Controls.Buttons.Items;
using nier_rein_gui.Properties;
using nier_rein_gui.Resources;
using NierReincarnation.Context;
using NierReincarnation.Context.Models;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;

namespace nier_rein_gui.Dialogs
{
    class StaminaPreferenceDialog : Modal
    {
        private StaminaType[] _order;

        private List orderList;

        public StaminaPreferenceDialog()
        {
            Size = new Vector2(300, 350);
            Caption = "Stamina Usage Preference";
            Content = orderList = CreateList();
        }

        private List CreateList()
        {
            var list = new List { ItemSpacing = 5 };

            _order = StaminaContext.Preference.GetOrder().ToArray();
            for (var i = 0; i < _order.Length; i++)
            {
                var item = _order[i];

                var currentIndex = i;
                var prevIndex = i - 1 < 0 ? 0 : i - 1;
                var nextIndex = i + 1 >= _order.Length ? _order.Length - 1 : i + 1;

                var upButton = new ArrowButton { Direction = ImGuiDir.Up, Enabled = i > 0 };
                var downButton = new ArrowButton { Direction = ImGuiDir.Down, Enabled = i + 1 < _order.Length };

                upButton.Clicked += (s, e) => SwapPreference(currentIndex, prevIndex);
                downButton.Clicked += (s, e) => SwapPreference(currentIndex, nextIndex);

                var dataItem = CalculatorConsumable.CreateDataConsumableItem((int)item);
                var itemIcon = NierResources.LoadConsumableItem(dataItem.AssetCategoryId, dataItem.AssetVariationId);

                list.Items.Add(new StackLayout
                {
                    Alignment = Alignment.Horizontal,
                    ItemSpacing = 5,
                    Size = new Size(1f, itemIcon.Height),
                    Items =
                    {
                        new NierConsumableItemButton(dataItem),
                        new StackLayout
                        {
                            Alignment = Alignment.Vertical,
                            ItemSpacing = 5,
                            Items =
                            {
                                new StackItem(new Label{Caption = dataItem.Name}){Size = new Size(1f, -1)},
                                new StackItem(new Label{Caption = dataItem.Description}){Size = ImGui.Forms.Models.Size.Parent,VerticalAlignment = VerticalAlignment.Center}
                            }
                        },
                        new StackItem(new StackLayout
                        {
                            Alignment = Alignment.Vertical,
                            ItemSpacing = 5,
                            Size = ImGui.Forms.Models.Size.Content,
                            Items =
                            {
                                upButton,
                                downButton
                            }
                        }){Size = new Size(-1,1f),VerticalAlignment = VerticalAlignment.Center}
                    }
                });
            }

            return list;
        }

        private void SwapPreference(int currentIndex, int swapIndex)
        {
            StaminaContext.Preference.Swap(_order[currentIndex], _order[swapIndex]);
            (_order[currentIndex], _order[swapIndex]) = (_order[swapIndex], _order[currentIndex]);

            // Update UI
            ((orderList.Items[currentIndex] as StackLayout).Items[0], (orderList.Items[swapIndex] as StackLayout).Items[0]) =
                ((orderList.Items[swapIndex] as StackLayout).Items[0], (orderList.Items[currentIndex] as StackLayout).Items[0]);

            for (var i = 0; i < _order.Length; i++)
            {
                (((orderList.Items[i] as StackLayout).Items[1].Content as StackLayout).Items[0].Content as Label).Caption = CalculatorConsumable.ConsumableItemName((int)_order[i]);
                (((orderList.Items[i] as StackLayout).Items[1].Content as StackLayout).Items[1].Content as Label).Caption = CalculatorConsumable.ConsumableItemDescription((int)_order[i]);
            }

            // Update order in settings
            Settings.Default.StaminaPreference = _order;
            Settings.Default.Save();
        }
    }
}
