using System;
using System.Drawing;
using ImGui.Forms.Extensions;
using ImGui.Forms.Resources;
using ImGuiNET;
using nier_rein_gui.Resources;
using Component = ImGui.Forms.Controls.Base.Component;
using Rectangle = Veldrid.Rectangle;
using Size = ImGui.Forms.Models.Size;
using Vector2 = System.Numerics.Vector2;

namespace nier_rein_gui.Controls.Buttons.Items
{
    // TODO: Implement base class for item slot buttons
    abstract class NierItemButton : Component
    {
        private static readonly uint HoverColor = Color.FromArgb(0x50, 0xC5, 0xC1, 0xB0).ToUInt32();
        private static readonly uint SelectionColor = Color.FromArgb(0x88, 0xC5, 0xC1, 0xB0).ToUInt32();
        private static readonly uint DisabledColor = Color.FromArgb(0x88, 0x00, 0x00, 0x00).ToUInt32();

        public bool Enabled { get; set; } = true;

        public bool Selected { get; set; }

        public bool HasBonus { get; set; }

        public string HintText { get; set; }

        public event EventHandler Clicked;

        public override Size GetSize()
        {
            return new Size((int)NierResources.ItemSlotSize.X, (int)NierResources.ItemSlotSize.Y);
        }

        protected override void UpdateInternal(Rectangle contentRect)
        {
            // Use button component to use actions
            ImGuiNET.ImGui.PushStyleColor(ImGuiCol.Button, 0);
            ImGuiNET.ImGui.PushStyleColor(ImGuiCol.ButtonActive, 0);
            ImGuiNET.ImGui.PushStyleColor(ImGuiCol.ButtonHovered, 0);

            var isClicked = ImGuiNET.ImGui.Button(string.Empty, contentRect.Size);
            var isHovered = ImGuiNET.ImGui.IsItemHovered();

            ImGuiNET.ImGui.PopStyleColor(3);

            // Draw content
            DrawContent(contentRect, isHovered);

            // Invoke click event
            if (isHovered && isClicked && Enabled)
                OnClicked();
        }

        protected abstract bool IsPlaceholder();

        protected abstract ImageResource GetPlaceholder();

        protected abstract ImageResource GetBackground();

        protected abstract ImageResource GetBorder();

        protected abstract ImageResource GetContent();

        protected virtual ImageResource[] GetIcons() => Array.Empty<ImageResource>();

        protected virtual void OnClicked()
        {
            Clicked?.Invoke(this, new EventArgs());
        }

        private void DrawContent(Rectangle contentRect, bool isHovered)
        {
            if (IsPlaceholder())
            {
                if (GetPlaceholder() != null)
                    ImGuiNET.ImGui.GetWindowDrawList().AddImage((IntPtr)GetPlaceholder(), contentRect.Position, contentRect.Position + contentRect.Size);

                if (!Enabled)
                {
                    ImGuiNET.ImGui.GetWindowDrawList().AddRectFilled(contentRect.Position, contentRect.Position + contentRect.Size, DisabledColor);
                    return;
                }

                DrawSelectionOverlay(contentRect, isHovered, false);

                return;
            }

            // Draw content
            if (GetBackground() != null)
                ImGuiNET.ImGui.GetWindowDrawList().AddImage((IntPtr)GetBackground(), contentRect.Position, contentRect.Position + contentRect.Size);
            if (GetContent() != null)
                ImGuiNET.ImGui.GetWindowDrawList().AddImage((IntPtr)GetContent(), contentRect.Position, contentRect.Position + contentRect.Size);
            if (GetBorder() != null)
                ImGuiNET.ImGui.GetWindowDrawList().AddImage((IntPtr)GetBorder(), contentRect.Position, contentRect.Position + contentRect.Size);

            // Draw selection
            DrawSelectionOverlay(contentRect, isHovered, Selected);

            // Draw icons
            var iconPos = contentRect.Position;
            foreach (var icon in GetIcons())
            {
                if (icon == null)
                    continue;

                ImGuiNET.ImGui.GetWindowDrawList().AddImage((IntPtr)icon, iconPos, iconPos + icon.Size);
                iconPos += new Vector2(0, icon.Height);
            }

            // Draw hint text
            if (!string.IsNullOrEmpty(HintText))
            {
                // TODO: Draw hint text
            }

            // Draw bonus indicator
            if (HasBonus)
            {
                // TODO: Draw bonus indicator
            }

            if(!Enabled)
                ImGuiNET.ImGui.GetWindowDrawList().AddRectFilled(contentRect.Position,contentRect.Position+contentRect.Size, DisabledColor);
        }

        private void DrawSelectionOverlay(Rectangle contentRect, bool isHovered, bool isSelected)
        {
            var overlayColor = isSelected ? SelectionColor : isHovered ? HoverColor : 0;

            ImGuiNET.ImGui.GetWindowDrawList().AddRectFilled(contentRect.Position, contentRect.Position + contentRect.Size, overlayColor);
        }
    }
}
