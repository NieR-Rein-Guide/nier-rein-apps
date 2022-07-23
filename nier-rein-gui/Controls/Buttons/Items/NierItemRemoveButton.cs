using System;
using System.Drawing;
using System.Numerics;
using ImGui.Forms;
using ImGui.Forms.Controls.Base;
using ImGui.Forms.Extensions;
using ImGui.Forms.Resources;
using ImGuiNET;
using nier_rein_gui.Resources;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Text;
using Rectangle = Veldrid.Rectangle;
using Size = ImGui.Forms.Models.Size;

namespace nier_rein_gui.Controls.Buttons.Items
{
    class NierItemRemoveButton : Component
    {
        private static readonly uint BorderColor = Color.FromArgb(0x6B, 0x63, 0x60).ToUInt32();
        private static readonly uint SelectionColor = Color.FromArgb(0x88, 0xC5, 0xC1, 0xB0).ToUInt32();

        public bool Selected { get; set; }

        public event EventHandler Clicked;

        public override Size GetSize()
        {
            return new Size((int)NierResources.ItemSlotSize.X, (int)NierResources.ItemSlotSize.Y);
        }

        protected override void UpdateInternal(Rectangle contentRect)
        {
            var (isClicked, isHovered) = AddButtonStub(contentRect);

            DrawBorders(contentRect);
            DrawRemoveText(contentRect);
            DrawSelection(contentRect, isHovered);

            RemoveButtonStub();

            if (isClicked)
                OnClicked();
        }

        private (bool, bool) AddButtonStub(Rectangle contentRect)
        {
            // Use button component to use actions
            ImGuiNET.ImGui.PushStyleColor(ImGuiCol.Button, 0);
            ImGuiNET.ImGui.PushStyleColor(ImGuiCol.ButtonActive, 0);
            ImGuiNET.ImGui.PushStyleColor(ImGuiCol.ButtonHovered, 0);

            var isClicked = ImGuiNET.ImGui.Button(string.Empty, contentRect.Size);
            var isHovered = ImGuiNET.ImGui.IsItemHovered();

            return (isClicked, isHovered);
        }

        private void RemoveButtonStub()
        {
            ImGuiNET.ImGui.PopStyleColor(3);
        }

        private void DrawBorders(Rectangle contentRect)
        {
            ImGuiNET.ImGui.GetWindowDrawList().AddRect(contentRect.Position, contentRect.Position + contentRect.Size, BorderColor, 0, ImDrawFlags.None, 2);
            ImGuiNET.ImGui.GetWindowDrawList().AddRect(contentRect.Position + new Vector2(4, 4), contentRect.Position + contentRect.Size - new Vector2(4, 4), BorderColor, 0, ImDrawFlags.None, 2);
        }

        private void DrawRemoveText(Rectangle contentRect)
        {
            var text = UserInterfaceTextKey.Organization.kRemove.Localize();
            var textSize = FontResource.MeasureText(text);

            var pos = new Vector2((contentRect.Width - textSize.X) / 2, (contentRect.Height - textSize.Y) / 2);
            ImGuiNET.ImGui.GetWindowDrawList().AddText(contentRect.Position + pos, Style.GetColor(ImGuiCol.Text).ToUInt32(), text);
        }

        private void DrawSelection(Rectangle contentRect, bool isHovered)
        {
            if (!isHovered && !Selected)
                return;

            ImGuiNET.ImGui.GetWindowDrawList().AddRectFilled(contentRect.Position, contentRect.Position + contentRect.Size, SelectionColor);
        }

        protected void OnClicked()
        {
            Clicked?.Invoke(this, new EventArgs());
        }
    }
}
