using System;
using System.Drawing;
using System.Numerics;
using ImGui.Forms;
using ImGui.Forms.Controls.Base;
using ImGui.Forms.Extensions;
using ImGui.Forms.Resources;
using ImGuiNET;
using NierReincarnation.Core.Dark.Localization;
using Rectangle = Veldrid.Rectangle;
using Size = ImGui.Forms.Models.Size;

namespace nier_rein_gui.Controls.Buttons
{
    class NierQuestButton : Component
    {
        private const int BorderDistance_ = 3;
        private const int BorderWidth_ = 3;
        private const int SubPadding_ = 4;
        private const int SubDistanceX_ = 8;
        private const int SubDistanceY_ = 8;
        private const int LabelDistance_ = 2;
        private const int DailyPadding_ = 2;
        private const int ClearPadding_ = 2;

        private const string SuggestedForceIdent_ = "ui.Outgame.Quest.Confirmation.RecommendPower";
        private const string StaminaIdent_ = "ui.Outgame.Quest.Confirmation.Stamina";
        private const string DailyText_ = "1 time daily";
        private const string ClearText_ = "CLEAR";

        private static readonly uint BorderColor = Color.FromArgb(0x6B, 0x63, 0x60).ToUInt32();
        private static readonly uint BorderActiveColor = Color.FromArgb(0x74, 0x71, 0x6C).ToUInt32();
        private static readonly uint TextActiveColor = Color.FromArgb(0x2D, 0x29, 0x28).ToUInt32();
        private static readonly uint DisabledColor = Color.FromArgb(0x88, 0x00, 0x00, 0x00).ToUInt32();
        private static readonly uint BoxBackgroundColor = Color.FromArgb(0xC0, 0x00, 0x00, 0x00).ToUInt32();
        private static readonly uint DailyBackgroundColor = Color.FromArgb(0xCC, 0x93, 0x93).ToUInt32();
        private static readonly uint DailyTextColor = Color.FromArgb(0x00, 0x00, 0x00).ToUInt32();
        private static readonly uint ClearBackgroundColor = Color.FromArgb(0x70, 0x70, 0x90).ToUInt32();
        private static readonly uint ClearTextColor = Color.FromArgb(0xF0, 0xF0, 0xF0).ToUInt32();

        #region Properties

        public string Caption { get; set; }

        public FontResource Font { get; set; }

        public FontResource SubFont { get; set; }

        public FontResource DailyFont { get; set; }

        public FontResource ClearFont { get; set; }

        public Vector2 Padding { get; set; }

        public int Stamina { get; set; }

        public int SuggestedPower { get; set; }

        public bool IsClear { get; set; }

        public bool IsDaily { get; set; }

        public bool Enabled { get; set; }

        #endregion

        #region Events

        public event EventHandler Clicked;

        #endregion

        public override Size GetSize()
        {
            // Get quest name size
            if (Font != null)
                ImGuiNET.ImGui.PushFont((ImFontPtr)Font);

            var questNameSize = FontResource.MeasureText(Caption);

            // Get clear text size
            if (ClearFont != null)
                ImGuiNET.ImGui.PushFont((ImFontPtr)ClearFont);

            var clearSize = FontResource.MeasureText(ClearText_);

            // Get daily text size
            if (DailyFont != null)
                ImGuiNET.ImGui.PushFont((ImFontPtr)DailyFont);

            var dailySize = FontResource.MeasureText(DailyText_);

            // Get force/stamina size
            if (SubFont != null)
                ImGuiNET.ImGui.PushFont((ImFontPtr)SubFont);

            var sugPowerSize = FontResource.MeasureText(SuggestedForceIdent_.Localize()) + FontResource.MeasureText("0000000");
            var staminaSize = FontResource.MeasureText(StaminaIdent_.Localize()) + FontResource.MeasureText("000");

            // Calculate final size
            var width = (int)Math.Max(questNameSize.X + clearSize.X + ClearPadding_ * 2 + LabelDistance_ + dailySize.X + DailyPadding_ * 2, sugPowerSize.X + staminaSize.X + SubPadding_ * 4 + SubDistanceX_) + BorderDistance_ * 2 + BorderWidth_ * 2 + (int)Padding.X * 2;
            var height = (int)(questNameSize.Y + FontResource.GetCurrentLineHeight() + SubPadding_ * 2 + SubDistanceY_ + BorderDistance_ * 2 + BorderWidth_ * 2 + Padding.Y * 2);

            // Pop fonts
            if (SubFont != null)
                ImGuiNET.ImGui.PopFont();

            if (DailyFont != null)
                ImGuiNET.ImGui.PopFont();

            if (ClearFont != null)
                ImGuiNET.ImGui.PopFont();

            if (Font != null)
                ImGuiNET.ImGui.PopFont();

            return new Size(width, height);
        }

        protected override void UpdateInternal(Rectangle contentRect)
        {
            var isEnabledLocal = Enabled;
            ApplyStyles(isEnabledLocal);

            // Draw base button
            var shouldClick = ImGuiNET.ImGui.Button(string.Empty, new Vector2(contentRect.Width, contentRect.Height));

            // Draw border
            DrawBorder(contentRect);

            // Draw content
            DrawContent(contentRect);

            if (!Enabled)
                DrawDisabled(contentRect);

            if (shouldClick && Enabled)
                OnClicked();

            RemoveStyles(isEnabledLocal);
        }

        protected override void ApplyStyles() { }

        protected override void RemoveStyles() { }

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

        private void DrawBorder(Rectangle contentRect)
        {
            var topLeft = new Vector2(contentRect.X + BorderDistance_, contentRect.Y + BorderDistance_);
            var bottomRight = new Vector2(contentRect.X + contentRect.Width - BorderDistance_, contentRect.Y + contentRect.Height - BorderDistance_);
            var color = IsActive() && Enabled ? BorderActiveColor : BorderColor;

            ImGuiNET.ImGui.GetWindowDrawList().AddRect(topLeft, bottomRight, color, 0, ImDrawFlags.None, BorderWidth_);
        }

        private void DrawContent(Rectangle contentRect)
        {
            var topLeft = new Vector2(contentRect.X + BorderDistance_ + BorderWidth_ + Padding.X, contentRect.Y + BorderDistance_ + BorderWidth_ + Padding.Y);

            // Draw quest name
            if (Font != null)
                ImGuiNET.ImGui.PushFont((ImFontPtr)Font);

            var questHeight = FontResource.GetCurrentLineHeight();
            var questNameColor = IsActive() && Enabled ? TextActiveColor : Style.GetColor(ImGuiCol.Text).ToUInt32();
            ImGuiNET.ImGui.GetWindowDrawList().AddText(topLeft, questNameColor, Caption ?? string.Empty);

            if (Font != null)
                ImGuiNET.ImGui.PopFont();

            // Draw daily label
            var clearOff = 0;
            if (IsDaily)
            {
                var dailyWidth = DrawDailyLabel(contentRect);
                clearOff = dailyWidth + LabelDistance_;
            }

            // Draw clear label
            if (IsClear)
                DrawClearLabel(contentRect, clearOff);

            topLeft += new Vector2(0, questHeight + SubDistanceY_);

            if (SubFont != null)
                ImGuiNET.ImGui.PushFont((ImFontPtr)SubFont);

            var height = FontResource.GetCurrentLineHeight() + SubPadding_ * 2;

            // Draw force details
            var firstForceWidth = FontResource.GetCurrentLineWidth(SuggestedForceIdent_.Localize());
            var secondForceWidth = FontResource.GetCurrentLineWidth($"{SuggestedPower}");
            var forceWidth = firstForceWidth + FontResource.GetCurrentLineWidth("0000000") + SubPadding_ * 2;

            ImGuiNET.ImGui.GetWindowDrawList().AddRectFilled(topLeft, topLeft + new Vector2(forceWidth, height), BoxBackgroundColor, 0);
            ImGuiNET.ImGui.GetWindowDrawList().AddText(topLeft + new Vector2(SubPadding_, SubPadding_), Style.GetColor(ImGuiCol.Text).ToUInt32(), SuggestedForceIdent_.Localize());
            ImGuiNET.ImGui.GetWindowDrawList().AddText(topLeft + new Vector2(forceWidth - SubPadding_ - secondForceWidth, SubPadding_), Style.GetColor(ImGuiCol.Text).ToUInt32(), $"{SuggestedPower}");

            topLeft += new Vector2(forceWidth + SubDistanceX_, 0);

            // Draw stamina details
            var firstStaminaWidth = FontResource.GetCurrentLineWidth(StaminaIdent_.Localize());
            var secondStaminaWidth = FontResource.GetCurrentLineWidth($"{Stamina}");
            var staminaWidth = firstStaminaWidth + FontResource.GetCurrentLineWidth("000") + SubPadding_ * 2;

            ImGuiNET.ImGui.GetWindowDrawList().AddRectFilled(topLeft, topLeft + new Vector2(staminaWidth, height), BoxBackgroundColor, 0);
            ImGuiNET.ImGui.GetWindowDrawList().AddText(topLeft + new Vector2(SubPadding_, SubPadding_), Style.GetColor(ImGuiCol.Text).ToUInt32(), StaminaIdent_.Localize());
            ImGuiNET.ImGui.GetWindowDrawList().AddText(topLeft + new Vector2(staminaWidth - SubPadding_ - secondStaminaWidth, SubPadding_), Style.GetColor(ImGuiCol.Text).ToUInt32(), $"{Stamina}");

            if (SubFont != null)
                ImGuiNET.ImGui.PopFont();
        }

        private int DrawDailyLabel(Rectangle contentRect)
        {
            if (DailyFont != null)
                ImGuiNET.ImGui.PushFont((ImFontPtr)DailyFont);

            var dailySize = FontResource.MeasureText(DailyText_);
            var dailyTopLeft = new Vector2(contentRect.X + contentRect.Width - BorderWidth_ - BorderDistance_ - dailySize.X - DailyPadding_ * 2,
                contentRect.Y + BorderWidth_ + BorderDistance_);
            var dailyBottomRight = dailyTopLeft + new Vector2(DailyPadding_ * 2 + dailySize.X, DailyPadding_ * 2 + dailySize.Y);

            ImGuiNET.ImGui.GetWindowDrawList().AddRectFilled(dailyTopLeft, dailyBottomRight, DailyBackgroundColor, 0);
            ImGuiNET.ImGui.GetWindowDrawList().AddText(dailyTopLeft + new Vector2(DailyPadding_, DailyPadding_), DailyTextColor, DailyText_);

            if (DailyFont != null)
                ImGuiNET.ImGui.PopFont();

            return (int)(dailyBottomRight.X - dailyTopLeft.X);
        }

        private void DrawClearLabel(Rectangle contentRect, int offsetX)
        {
            if (ClearFont != null)
                ImGuiNET.ImGui.PushFont((ImFontPtr)ClearFont);

            var clearSize = FontResource.MeasureText(ClearText_);
            var clearTopLeft = new Vector2(contentRect.X + contentRect.Width - BorderWidth_ - BorderDistance_ - clearSize.X - ClearPadding_ * 2 + offsetX,
                contentRect.Y + BorderWidth_ + BorderDistance_);
            var clearBottomRight = clearTopLeft + new Vector2(ClearPadding_ * 2 + clearSize.X + offsetX, ClearPadding_ * 2 + clearSize.Y);

            ImGuiNET.ImGui.GetWindowDrawList().AddRectFilled(clearTopLeft, clearBottomRight, ClearBackgroundColor, 0);
            ImGuiNET.ImGui.GetWindowDrawList().AddText(clearTopLeft + new Vector2(ClearPadding_, ClearPadding_), ClearTextColor, ClearText_);

            if (ClearFont != null)
                ImGuiNET.ImGui.PopFont();
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
            return ImGuiNET.ImGui.IsItemActive() && ImGuiNET.ImGui.IsItemHovered();
        }

        private void OnClicked()
        {
            Clicked?.Invoke(this, new EventArgs());
        }
    }
}
