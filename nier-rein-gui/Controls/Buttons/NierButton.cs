using System;
using System.Drawing;
using System.Numerics;
using ImGui.Forms;
using ImGui.Forms.Controls;
using ImGui.Forms.Extensions;
using ImGui.Forms.Models;
using ImGui.Forms.Resources;
using ImGuiNET;
using Rectangle = Veldrid.Rectangle;
using Size = ImGui.Forms.Models.Size;

namespace nier_rein_gui.Controls.Buttons
{
    class NierButton : Button
    {
        private const int BorderDistance_ = 3;
        private const int BorderWidth_ = 3;

        private static readonly uint BorderColor = Color.FromArgb(0x6B, 0x63, 0x60).ToUInt32();
        private static readonly uint BorderActiveColor = Color.FromArgb(0x74, 0x71, 0x6C).ToUInt32();
        private static readonly uint TextActiveColor = Color.FromArgb(0x2D, 0x29, 0x28).ToUInt32();
        private static readonly uint DisabledColor = Color.FromArgb(0x88, 0x00, 0x00, 0x00).ToUInt32();

        private bool _isMarkedHovered;
        private bool _isMarkedActive;

        public bool Active { get; set; }

        public bool IsClickActive { get; set; }

        public override Size GetSize()
        {
            if (Font != null)
                ImGuiNET.ImGui.PushFont((ImFontPtr)Font);

            var textSize = FontResource.MeasureText(EscapeCaption());
            SizeValue width = (int)Width.Value == -1 ? (int)Math.Ceiling(textSize.X) + BorderDistance_ * 2 + BorderWidth_ * 2 + (int)Padding.X * 2 : Width;
            var height = (int)Math.Ceiling(textSize.Y) + BorderDistance_ * 2 + BorderWidth_ * 2 + (int)Padding.Y * 2;

            if (Font != null)
                ImGuiNET.ImGui.PopFont();

            return new Size(width, height);
        }

        protected override void UpdateInternal(Rectangle contentRect)
        {
            var isHoveredLocal = _isMarkedHovered;
            var isActiveLocal = _isMarkedActive;
            var isEnabledLocal = Enabled;
            var fontLocal = Font;
            ApplyStyles(isHoveredLocal, isActiveLocal, isEnabledLocal, fontLocal);

            var shouldClick = ImGuiNET.ImGui.Button(EscapeCaption(), new Vector2(contentRect.Width, contentRect.Height));

            _isMarkedHovered = ImGuiNET.ImGui.IsItemHovered();

            var isActive = ImGuiNET.ImGui.IsItemActive() && ImGuiNET.ImGui.IsItemHovered();
            _isMarkedActive = (isActive || Active) && Enabled;
            if (shouldClick && Enabled)
            {
                Active = IsClickActive;
                _isMarkedActive |= IsClickActive;
            }

            DrawBorder(contentRect, _isMarkedActive);
            if (!Enabled)
                DrawDisabled(contentRect);

            if (shouldClick && Enabled)
                OnClicked();

            RemoveStyles(isHoveredLocal, isActiveLocal, isEnabledLocal, fontLocal);
        }

        protected override void ApplyStyles() { }

        protected override void RemoveStyles() { }

        protected void ApplyStyles(bool isHovered, bool isActive, bool isEnabled, FontResource font)
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

        protected void RemoveStyles(bool isHovered, bool isActive, bool isEnabled, FontResource font)
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

        private void DrawBorder(Rectangle contentRect, bool isActive)
        {
            var topLeft = new Vector2(contentRect.X + BorderDistance_, contentRect.Y + BorderDistance_);
            var bottomRight = new Vector2(contentRect.X + contentRect.Width - BorderDistance_, contentRect.Y + contentRect.Height - BorderDistance_);
            var color = isActive ? BorderActiveColor : BorderColor;

            ImGuiNET.ImGui.GetWindowDrawList().AddRect(topLeft, bottomRight, color, 0, ImDrawFlags.None, BorderWidth_);
        }

        private void DrawDisabled(Rectangle contentRect)
        {
            var topLeft = new Vector2(contentRect.X, contentRect.Y);
            var bottomRight = new Vector2(contentRect.X + contentRect.Width, contentRect.Y + contentRect.Height);
            ImGuiNET.ImGui.GetWindowDrawList().AddRectFilled(topLeft, bottomRight, DisabledColor);

            var lockImg = Resources.ImageResources.Lock;
            topLeft = new Vector2(contentRect.X + contentRect.Width / 2 - lockImg.Width / 2, contentRect.Y + contentRect.Height / 2 - lockImg.Height / 2);
            bottomRight = new Vector2(contentRect.X + contentRect.Width / 2 + lockImg.Width / 2, contentRect.Y + contentRect.Height / 2 + lockImg.Height / 2);
            ImGuiNET.ImGui.GetWindowDrawList().AddImage((IntPtr)lockImg, topLeft, bottomRight);
        }
    }
}
