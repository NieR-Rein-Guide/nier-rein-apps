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
    abstract class NierItemButton : Component
    {
        private static readonly uint HoverColor = Color.FromArgb(0x50, 0xC5, 0xC1, 0xB0).ToUInt32();
        private static readonly uint SelectionColor = Color.FromArgb(0x88, 0xC5, 0xC1, 0xB0).ToUInt32();
        private static readonly uint DisabledColor = Color.FromArgb(0x88, 0x00, 0x00, 0x00).ToUInt32();
        private static readonly uint TextActiveColor = Color.FromArgb(0x2D, 0x29, 0x28).ToUInt32();

        #region Properties

        private FontResource HintFont => Resources.FontResources.FotRodin(11);

        public HintType Hint { get; set; } = HintType.None;

        public bool Enabled { get; set; } = true;

        public bool Selected { get; set; }

        public bool HasBonus { get; set; }

        #endregion

        #region Events

        public event EventHandler Clicked;

        #endregion

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

            var shouldClick = ImGuiNET.ImGui.Button(string.Empty, contentRect.Size);;

            ImGuiNET.ImGui.PopStyleColor(3);

            // Draw content
            DrawContent(contentRect, IsHoveredCore());

            // Invoke click event
            if (shouldClick && Enabled)
                OnClicked();
        }

        protected abstract bool IsPlaceholder();

        protected abstract ImageResource GetPlaceholder();

        protected abstract ImageResource GetBackground();

        protected abstract ImageResource GetBorder();

        protected abstract ImageResource GetContent();

        protected virtual ImageResource[] GetIcons() => Array.Empty<ImageResource>();

        protected virtual void UpdateIcon(int iconIndex, Rectangle iconRect) { }

        protected void OnClicked()
        {
            Clicked?.Invoke(this, new EventArgs());
        }

        private void DrawContent(Rectangle contentRect, bool isHovered)
        {
            if (IsPlaceholder())
            {
                if (GetPlaceholder() != null)
                    ImGuiNET.ImGui.GetWindowDrawList().AddImage((IntPtr)GetPlaceholder(), contentRect.Position, contentRect.Position + contentRect.Size);

                if (Enabled)
                    DrawSelectionOverlay(contentRect, isHovered, false);

                if (!Enabled)
                    ImGuiNET.ImGui.GetWindowDrawList().AddRectFilled(contentRect.Position, contentRect.Position + contentRect.Size, DisabledColor);

                return;
            }

            // Draw content
            if (GetBackground() != null)
                ImGuiNET.ImGui.GetWindowDrawList().AddImage((IntPtr)GetBackground(), contentRect.Position, contentRect.Position + contentRect.Size);
            if (GetContent() != null)
                ImGuiNET.ImGui.GetWindowDrawList().AddImage((IntPtr)GetContent(), contentRect.Position, contentRect.Position + contentRect.Size);
            if (GetBorder() != null)
                ImGuiNET.ImGui.GetWindowDrawList().AddImage((IntPtr)GetBorder(), contentRect.Position, contentRect.Position + contentRect.Size);

            // Draw selection, when button is enabled
            if (Enabled)
                DrawSelectionOverlay(contentRect, isHovered, Selected);

            // Draw icons
            var iconPos = contentRect.Position;
            var iconIndex = 0;
            foreach (var icon in GetIcons())
            {
                if (icon == null)
                    continue;

                ImGuiNET.ImGui.GetWindowDrawList().AddImage((IntPtr)icon, iconPos, iconPos + NierResources.IconSize);
                UpdateIcon(iconIndex++, new Rectangle((int)iconPos.X, (int)iconPos.Y, (int)NierResources.IconSize.X, (int)NierResources.IconSize.Y));

                iconPos += new Vector2(0, NierResources.IconSize.Y);
            }

            // Draw hint text
            if (Hint != HintType.None)
                DrawHint(contentRect);

            // Draw bonus indicator
            if (HasBonus)
                DrawBonusIcon(contentRect);

            if (!Enabled)
                ImGuiNET.ImGui.GetWindowDrawList().AddRectFilled(contentRect.Position, contentRect.Position + contentRect.Size, DisabledColor);
        }

        private void DrawSelectionOverlay(Rectangle contentRect, bool isHovered, bool isSelected)
        {
            var overlayColor = isSelected ? SelectionColor : isHovered ? HoverColor : 0;

            ImGuiNET.ImGui.GetWindowDrawList().AddRectFilled(contentRect.Position, contentRect.Position + contentRect.Size, overlayColor);
        }

        private void DrawHint(Rectangle contentRect)
        {
            uint bgColor;
            uint txtColor;
            string text;

            switch (Hint)
            {
                case HintType.Current:
                    bgColor = ImGuiNET.ImGui.GetColorU32(ImGuiCol.ButtonActive);
                    txtColor = TextActiveColor;
                    text = LocalizationResources.ItemChosen;
                    break;

                case HintType.InDeck:
                    bgColor = ImGuiNET.ImGui.GetColorU32(ImGuiCol.Button);
                    txtColor = ImGuiNET.ImGui.GetColorU32(ImGuiCol.Text);
                    text = LocalizationResources.ItemInDeck;
                    break;

                default:
                    return;
            }

            // Draw hint text
            var textWidth = HintFont.GetLineWidth(text);
            var textStart = contentRect.Width - textWidth;

            ImGuiNET.ImGui.GetWindowDrawList().AddRectFilled(contentRect.Position + new Vector2(textStart - 4, 0), contentRect.Position + new Vector2(contentRect.Width, HintFont.GetLineHeight() + 2), bgColor);

            ImGuiNET.ImGui.PushFont((ImFontPtr)HintFont);
            ImGuiNET.ImGui.GetWindowDrawList().AddText(contentRect.Position + new Vector2(textStart - 2, 0), txtColor, text);
            ImGuiNET.ImGui.PopFont();
        }

        private void DrawBonusIcon(Rectangle contentRect)
        {
            var bonusIcon = NierResources.LoadBonusIcon();

            var x = contentRect.Width - bonusIcon.Width;
            var y = (contentRect.Height - bonusIcon.Height) / 2;
            var imgPos = contentRect.Position + new Vector2(x, y);

            ImGuiNET.ImGui.GetWindowDrawList().AddImage((IntPtr)bonusIcon, imgPos, imgPos + new Vector2(bonusIcon.Width, bonusIcon.Height));
        }

        public enum HintType
        {
            Current,
            InDeck,
            None
        }
    }
}
