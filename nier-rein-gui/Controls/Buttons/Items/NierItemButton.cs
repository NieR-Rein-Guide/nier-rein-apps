using System;
using System.Drawing;
using ImGui.Forms.Extensions;
using ImGui.Forms.Resources;
using ImGuiNET;
using nier_rein_gui.Resources;
using NierReincarnation.Core.UnityEngine;
using SixLabors.ImageSharp.Processing;
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
            ImGuiNET.ImGui.PushStyleColor(ImGuiCol.Button,0);
            ImGuiNET.ImGui.PushStyleColor(ImGuiCol.ButtonActive, 0);
            ImGuiNET.ImGui.PushStyleColor(ImGuiCol.ButtonHovered, 0);

            var isClicked = ImGuiNET.ImGui.Button(string.Empty, contentRect.Size);
            var isHovered = ImGuiNET.ImGui.IsItemHovered();

            ImGuiNET.ImGui.PopStyleColor(3);

            // Draw content
            if (GetBackground() != null)
                ImGuiNET.ImGui.GetWindowDrawList().AddImage((IntPtr)GetBackground(), contentRect.Position, contentRect.Position + contentRect.Size);
            if (GetContent() != null)
                ImGuiNET.ImGui.GetWindowDrawList().AddImage((IntPtr)GetContent(), contentRect.Position, contentRect.Position + contentRect.Size);
            if (GetBorder() != null)
                ImGuiNET.ImGui.GetWindowDrawList().AddImage((IntPtr)GetBorder(), contentRect.Position, contentRect.Position + contentRect.Size);

            // Draw selection
            var overlayColor = Selected ? SelectionColor : isHovered ? HoverColor : 0;

            ImGuiNET.ImGui.GetWindowDrawList().AddRectFilled(contentRect.Position, contentRect.Position + contentRect.Size, overlayColor);

            // Draw icons
            var iconPos = contentRect.Position;
            foreach (var icon in GetIcons())
            {
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

            // Invoke click event
            if (isHovered && isClicked)
                OnClicked();
        }

        protected abstract ImageResource GetBackground();

        protected abstract ImageResource GetBorder();

        protected abstract ImageResource GetContent();

        protected virtual ImageResource[] GetIcons() => Array.Empty<ImageResource>();

        protected ImageResource LoadItemResource(ImageAsset asset)
        {
            ResizeToItemSlot(asset);

            return ImageResource.FromStream(asset.AsStream());
        }

        protected ImageResource LoadIconResource(ImageAsset asset)
        {
            ResizeToIcon(asset);

            return ImageResource.FromStream(asset.AsStream());
        }

        private void ResizeToItemSlot(ImageAsset asset)
        {
            asset.Image.Mutate(x => x.Resize(new SixLabors.ImageSharp.Size((int)NierResources.ItemSlotSize.X, (int)NierResources.ItemSlotSize.Y)));
        }

        private void ResizeToIcon(ImageAsset asset)
        {
            asset.Image.Mutate(x => x.Resize(new SixLabors.ImageSharp.Size((int)NierResources.IconSize.X, (int)NierResources.IconSize.Y)));
        }

        protected virtual void OnClicked()
        {
            Clicked?.Invoke(this, new EventArgs());
        }
    }
}
