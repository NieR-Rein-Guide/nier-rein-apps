using System;
using System.Drawing;
using System.Numerics;
using ImGui.Forms;
using ImGui.Forms.Controls;
using ImGui.Forms.Extensions;
using ImGui.Forms.Models;
using ImGui.Forms.Resources;
using ImGuiNET;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using Rectangle = Veldrid.Rectangle;
using Size = ImGui.Forms.Models.Size;

namespace nier_rein_gui.Controls.Buttons
{
    class LimitContentBundleButton : Button
    {
        private const int BorderDistance_ = 3;
        private const int BorderWidth_ = 3;
        private const int SubDistanceY_ = 8;
        private const int ProgressBarHeight_ = 4;
        private const int ProgressDistanceX_ = 5;

        private static readonly uint BorderColor = Color.FromArgb(0x6B, 0x63, 0x60).ToUInt32();
        private static readonly uint BorderActiveColor = Color.FromArgb(0x74, 0x71, 0x6C).ToUInt32();
        private static readonly uint TextActiveColor = Color.FromArgb(0x2D, 0x29, 0x28).ToUInt32();
        private static readonly uint DisabledColor = Color.FromArgb(0x88, 0x00, 0x00, 0x00).ToUInt32();

        public DataLimitContentLevel Bundle { get; set; }

        public override Size GetSize()
        {
            if (Font != null)
                ImGuiNET.ImGui.PushFont((ImFontPtr)Font);

            var textSize = FontResource.MeasureText(EscapeCaption());
            var progressSize = FontResource.MeasureText("00/00");

            SizeValue width = (int)Width.Value == -1 ? Math.Max((int)Math.Ceiling(textSize.X), (int)Math.Ceiling(progressSize.X + ProgressDistanceX_)) + BorderDistance_ * 2 + BorderWidth_ * 2 + (int)Padding.X * 2 : Width;
            var height = (int)Math.Ceiling(textSize.Y) + SubDistanceY_ + Math.Max((int)Math.Ceiling(progressSize.Y), ProgressBarHeight_) + BorderDistance_ * 2 + BorderWidth_ * 2 + (int)Padding.Y * 2;

            if (Font != null)
                ImGuiNET.ImGui.PopFont();

            return new Size(width, height);
        }

        protected override void UpdateInternal(Rectangle contentRect)
        {
            var isEnabled = Enabled;
            ApplyStyles(isEnabled);

            var shouldClick = ImGuiNET.ImGui.Button(string.Empty, new Vector2(contentRect.Width, contentRect.Height));
            var isActive = Enabled && ImGuiNET.ImGui.IsItemActive() && ImGuiNET.ImGui.IsItemHovered();

            // Draw content
            DrawContent(contentRect, isActive);

            // Draw border
            DrawBorder(contentRect, isActive);

            // Draw disabled marks
            if (!Enabled)
                DrawDisabled(contentRect);

            // Execute click event
            if (shouldClick && Enabled)
                OnClicked();

            RemoveStyles(isEnabled);
        }

        private void DrawContent(Rectangle contentRect, bool isActive)
        {
            var firstRowPos = contentRect.Position + Padding + new Vector2(BorderDistance_ + BorderWidth_, BorderDistance_ + BorderWidth_);

            // Draw caption
            if (Font != null)
                ImGuiNET.ImGui.PushFont((ImFontPtr)Font);

            var caption = EscapeCaption();
            var captionSize = FontResource.MeasureText(caption);
            var captionColor = IsActive() && Enabled ? TextActiveColor : Style.GetColor(ImGuiCol.Text).ToUInt32();

            ImGuiNET.ImGui.GetWindowDrawList().AddText(firstRowPos, captionColor, caption);

            var secondRowPos = firstRowPos + new Vector2(0, captionSize.Y + SubDistanceY_);

            // Draw progress bar
            var progressCaption = $"{Bundle?.QuestClearCount ?? 0:0}/{Bundle?.QuestCount ?? 0:0}";
            var progressCaptionSize = FontResource.MeasureText(progressCaption);

            var progressBarPos = secondRowPos + new Vector2(0, (progressCaptionSize.Y - ProgressBarHeight_) / 2);
            var progressBarSize = new Vector2(200, ProgressBarHeight_);
            var progressBarSizeFilled = new Vector2(200 / (Bundle?.QuestCount ?? 1) * (Bundle?.QuestClearCount ?? 0), ProgressBarHeight_);
            var progressBarColor = !Enabled || !IsHovered() ? Style.GetColor(ImGuiCol.Text).ToUInt32() : isActive ? BorderActiveColor : BorderColor;

            ImGuiNET.ImGui.GetWindowDrawList().AddRect(progressBarPos, progressBarPos + progressBarSize, progressBarColor);
            ImGuiNET.ImGui.GetWindowDrawList().AddRectFilled(progressBarPos, progressBarPos + progressBarSizeFilled, progressBarColor);

            secondRowPos += new Vector2(progressBarSize.X + ProgressDistanceX_, 0);

            // Draw progress values
            ImGuiNET.ImGui.GetWindowDrawList().AddText(secondRowPos, captionColor, progressCaption);

            if (Font != null)
                ImGuiNET.ImGui.PopFont();
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

        private bool IsActive()
        {
            return ImGuiNET.ImGui.IsItemActive() && IsHovered();
        }

        private bool IsHovered()
        {
            return ImGuiNET.ImGui.IsItemHovered();
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
