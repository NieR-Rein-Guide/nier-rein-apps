using System;
using System.Drawing;
using System.Numerics;
using ImGui.Forms;
using ImGui.Forms.Extensions;
using ImGui.Forms.Models;
using ImGui.Forms.Resources;
using ImGuiNET;
using nier_rein_gui.Controls.Buttons.Base;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using Rectangle = Veldrid.Rectangle;
using Size = ImGui.Forms.Models.Size;

namespace nier_rein_gui.Controls.Buttons
{
    class LimitContentBundleButton : BaseNierButton
    {
        private const int SubDistanceY_ = 8;
        private const int ProgressBarHeight_ = 4;
        private const int ProgressDistanceX_ = 5;

        private static readonly uint TextActiveColor = Color.FromArgb(0x2D, 0x29, 0x28).ToUInt32();

        public bool IsClickActive { get; set; }

        public FontResource Font { get; set; }
        public string Caption { get; set; }

        public SizeValue Width { get; set; } = SizeValue.Content;

        public DataLimitContentLevel Bundle { get; set; }

        public override Size GetSize()
        {
            if (Font != null)
                ImGuiNET.ImGui.PushFont((ImFontPtr)Font);

            var textSize = FontResource.MeasureText(EscapeText(Caption));
            var progressSize = FontResource.MeasureText("00/00");
            var borderSize = GetContentSize();

            SizeValue width = Width.IsContentAligned ? Math.Max((int)Math.Ceiling(textSize.X), (int)Math.Ceiling(progressSize.X + ProgressDistanceX_)) + (int)borderSize.X : Width;
            var height = (int)Math.Ceiling(textSize.Y) + SubDistanceY_ + Math.Max((int)Math.Ceiling(progressSize.Y), ProgressBarHeight_) + (int)borderSize.Y;

            if (Font != null)
                ImGuiNET.ImGui.PopFont();

            return new Size(width, height);
        }

        protected override void UpdateInternal(Rectangle contentRect)
        {
            var isEnabled = Enabled;
            ApplyStyles(isEnabled);

            var shouldClick = ImGuiNET.ImGui.Button(string.Empty, new Vector2(contentRect.Width, contentRect.Height));
            var isActive = shouldClick && Enabled ? ToggleActive(true) : IsActive();

            // Draw content
            DrawContent(contentRect, isActive);

            // Draw border
            DrawBorder(contentRect, isActive);

            // Draw disabled
            DrawDisabled(contentRect);

            // Execute click event
            if (shouldClick && Enabled)
                OnClicked();

            RemoveStyles(isEnabled);
        }

        private void DrawContent(Rectangle contentRect, bool isActive)
        {
            var firstRowPos = contentRect.Position + GetContentPosition();

            // Draw caption
            if (Font != null)
                ImGuiNET.ImGui.PushFont((ImFontPtr)Font);

            var caption = EscapeText(Caption);
            var captionSize = FontResource.MeasureText(caption);
            var captionColor = IsActive() && Enabled ? TextActiveColor : Style.GetColor(ImGuiCol.Text).ToUInt32();

            ImGuiNET.ImGui.GetWindowDrawList().AddText(firstRowPos, captionColor, caption);

            var secondRowPos = firstRowPos + new Vector2(0, captionSize.Y + SubDistanceY_);

            // Draw progress bar
            var progressCaption = $"{Bundle?.QuestClearCount ?? 0:0}/{Bundle?.QuestCount ?? 0:0}";
            var progressCaptionSize = FontResource.MeasureText(progressCaption);

            var progressBarPos = secondRowPos + new Vector2(0, (progressCaptionSize.Y - ProgressBarHeight_) / 2);
            var progressBarSize = new Vector2(200, ProgressBarHeight_);
            var progressBarSizeFilled = new Vector2(200f / (Bundle?.QuestCount ?? 1) * (Bundle?.QuestClearCount ?? 0), ProgressBarHeight_);
            var progressBarColor = !Enabled || !ImGuiNET.ImGui.IsItemHovered() ? Style.GetColor(ImGuiCol.Text).ToUInt32() : isActive ? BorderActiveColor : BorderColor;

            ImGuiNET.ImGui.GetWindowDrawList().AddRect(progressBarPos, progressBarPos + progressBarSize, progressBarColor);
            ImGuiNET.ImGui.GetWindowDrawList().AddRectFilled(progressBarPos, progressBarPos + progressBarSizeFilled, progressBarColor);

            secondRowPos += new Vector2(progressBarSize.X + ProgressDistanceX_, 0);

            // Draw progress values
            ImGuiNET.ImGui.GetWindowDrawList().AddText(secondRowPos, captionColor, progressCaption);

            if (Font != null)
                ImGuiNET.ImGui.PopFont();
        }

        protected void ApplyStyles(bool isEnabled)
        {
            if (!isEnabled)
            {
                ImGuiNET.ImGui.PushStyleColor(ImGuiCol.ButtonHovered, Style.GetColor(ImGuiCol.Button).ToUInt32());
                ImGuiNET.ImGui.PushStyleColor(ImGuiCol.ButtonActive, Style.GetColor(ImGuiCol.Button).ToUInt32());
            }
        }

        protected void RemoveStyles(bool isEnabled)
        {
            if (!isEnabled)
                ImGuiNET.ImGui.PopStyleColor(2);
        }
    }
}
