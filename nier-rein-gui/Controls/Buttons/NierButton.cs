using System;
using System.Drawing;
using ImGui.Forms;
using ImGui.Forms.Extensions;
using ImGui.Forms.Models;
using ImGui.Forms.Resources;
using ImGuiNET;
using nier_rein_gui.Controls.Buttons.Base;
using Rectangle = Veldrid.Rectangle;
using Size = ImGui.Forms.Models.Size;

namespace nier_rein_gui.Controls.Buttons
{
    class NierButton : BaseNierButton
    {
        private static readonly uint TextActiveColor = Color.FromArgb(0x2D, 0x29, 0x28).ToUInt32();

        public bool IsClickActive { get; set; }

        public FontResource Font { get; set; }
        public string Text { get; set; }

        public SizeValue Width { get; set; } = SizeValue.Content;

        public override Size GetSize()
        {
            if (Font != null)
                ImGuiNET.ImGui.PushFont((ImFontPtr)Font);

            var textSize = FontResource.MeasureText(EscapeText(Text));
            var borderSize = GetContentSize();

            SizeValue width = Width.IsContentAligned ? (int)Math.Ceiling(textSize.X) + (int)borderSize.X : Width;
            var height = (int)Math.Ceiling(textSize.Y) + (int)borderSize.Y;

            if (Font != null)
                ImGuiNET.ImGui.PopFont();

            return new Size(width, height);
        }

        private bool _isMarkedHovered;
        private bool _isMarkedActive;

        protected override void UpdateInternal(Rectangle contentRect)
        {
            var isHoveredLocal = _isMarkedHovered;
            var isActiveLocal = _isMarkedActive;
            var isEnabledLocal = Enabled;
            var fontLocal = Font;
            ApplyStyles(isHoveredLocal, isActiveLocal, isEnabledLocal, fontLocal);

            // Create main component
            var shouldClick = ImGuiNET.ImGui.Button(EscapeText(Text), contentRect.Size);

            _isMarkedHovered = IsHoveredCore();
            _isMarkedActive = shouldClick && Enabled ? ToggleActive(IsClickActive) : IsActive();

            // Draw border
            DrawBorder(contentRect, _isMarkedActive);

            // Draw disabled item
            DrawDisabled(contentRect);

            if (shouldClick && Enabled)
                OnClicked();

            RemoveStyles(isHoveredLocal, isActiveLocal, isEnabledLocal, fontLocal);
        }

        private void ApplyStyles(bool isHovered, bool isActive, bool isEnabled, FontResource font)
        {
            if (font != null)
                ImGuiNET.ImGui.PushFont((ImFontPtr)font);

            if (!isEnabled)
            {
                ImGuiNET.ImGui.PushStyleColor(ImGuiCol.ButtonHovered, Style.GetColor(ImGuiCol.Button).ToUInt32());
                ImGuiNET.ImGui.PushStyleColor(ImGuiCol.ButtonActive, Style.GetColor(ImGuiCol.Button).ToUInt32());
                return;
            }

            if (isHovered || isActive)
                ImGuiNET.ImGui.PushStyleColor(ImGuiCol.Text, TextActiveColor);

            if (isActive)
            {
                ImGuiNET.ImGui.PushStyleColor(ImGuiCol.Button, Style.GetColor(ImGuiCol.ButtonActive).ToUInt32());
                ImGuiNET.ImGui.PushStyleColor(ImGuiCol.ButtonHovered, Style.GetColor(ImGuiCol.ButtonActive).ToUInt32());
            }
        }

        private void RemoveStyles(bool isHovered, bool isActive, bool isEnabled, FontResource font)
        {
            if (font != null)
                ImGuiNET.ImGui.PopFont();

            if (!isEnabled)
            {
                ImGuiNET.ImGui.PopStyleColor(2);
                return;
            }

            if (isHovered || isActive)
                ImGuiNET.ImGui.PopStyleColor(1);

            if (isActive)
                ImGuiNET.ImGui.PopStyleColor(2);
        }
    }
}
