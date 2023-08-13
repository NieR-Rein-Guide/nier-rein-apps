using ImGui.Forms;
using ImGui.Forms.Extensions;
using ImGui.Forms.Models;
using ImGui.Forms.Resources;
using ImGuiNET;
using NierReincarnation.App.Controls.Buttons.Base;
using NierReincarnation.App.Resources;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using NierReincarnation.Core.Dark.View.UserInterface.Text;
using System;
using System.Drawing;
using System.Numerics;
using Rectangle = Veldrid.Rectangle;
using Size = ImGui.Forms.Models.Size;

namespace NierReincarnation.App.Controls.Buttons
{
    internal class NierQuestButton : BaseNierButton
    {
        private const int SubPadding_ = 4;
        private const int SubDistanceX_ = 8;
        private const int SubDistanceY_ = 8;
        private const int SubDistanceAttributeY_ = 5;
        private const int LabelDistance_ = 2;
        private const int DailyPadding_ = 2;
        private const int ClearPadding_ = 2;

        private static readonly uint TextActiveColor = Color.FromArgb(0x2D, 0x29, 0x28).ToUInt32();
        private static readonly uint ReducedStaminaText = Color.FromArgb(0xCC, 0x93, 0x93).ToUInt32();  // 954848
        private static readonly uint BoxBackgroundColor = Color.FromArgb(0xC0, 0x00, 0x00, 0x00).ToUInt32();
        private static readonly uint DailyBackgroundColor = Color.FromArgb(0xCC, 0x93, 0x93).ToUInt32();
        private static readonly uint DailyTextColor = Color.FromArgb(0x00, 0x00, 0x00).ToUInt32();
        private static readonly uint ClearBackgroundColor = Color.FromArgb(0x70, 0x70, 0x90).ToUInt32();
        private static readonly uint ClearTextColor = Color.FromArgb(0xF0, 0xF0, 0xF0).ToUInt32();

        private static FontResource DailyFont => Resources.FontResources.FotRodin(9);

        private static FontResource ClearFont => Resources.FontResources.FotRodin(11);

        private static FontResource SubFont => Resources.FontResources.FotRodin(12);

        #region Properties

        public string Text { get; set; }

        public SizeValue Width { get; set; } = SizeValue.Content;

        public int Stamina { get; set; }

        public int SuggestedPower { get; set; }

        public bool IsClear { get; set; }

        public bool IsDaily { get; set; }

        public DataQuestCampaign StaminaCampaign { get; set; }

        public QuestDisplayAttributeType Attribute { get; set; }

        #endregion Properties

        public override Size GetSize()
        {
            // Get quest name size
            var questNameSize = FontResource.MeasureText(Text);

            // Get attribute size
            var attributeSize = NierResources.IconSize + new Vector2(LabelDistance_, 0);
            var subY = SubDistanceAttributeY_;
            if (!IsAttributeVisible())
            {
                attributeSize = new Vector2();
                subY = SubDistanceY_;
            }

            // Get clear text size
            if (ClearFont != null)
                ImGuiNET.ImGui.PushFont((ImFontPtr)ClearFont);

            var clearSize = FontResource.MeasureText(LocalizationResources.ButtonClear);

            // Get daily text size
            if (DailyFont != null)
                ImGuiNET.ImGui.PushFont((ImFontPtr)DailyFont);

            var dailySize = FontResource.MeasureText(LocalizationResources.ButtonDaily);

            // Get force/stamina size
            if (SubFont != null)
                ImGuiNET.ImGui.PushFont((ImFontPtr)SubFont);

            var sugPowerSize = FontResource.MeasureText(UserInterfaceTextKey.Quest.kSuggestedPower.Localize()) + FontResource.MeasureText("0000000");
            var staminaSize = FontResource.MeasureText(UserInterfaceTextKey.Quest.kStamina.Localize()) + FontResource.MeasureText("000");

            // Calculate final size
            var borderSize = GetContentSize();
            var width = (int)Math.Max(attributeSize.X + questNameSize.X + clearSize.X + (ClearPadding_ * 2) + LabelDistance_ + dailySize.X + (DailyPadding_ * 2), sugPowerSize.X + staminaSize.X + (SubPadding_ * 4) + SubDistanceX_) + (int)borderSize.X;
            var height = (int)(Math.Max(attributeSize.Y, questNameSize.Y) + FontResource.GetCurrentLineHeight() + (SubPadding_ * 2) + subY + (int)borderSize.Y);

            // Pop fonts
            if (SubFont != null)
                ImGuiNET.ImGui.PopFont();

            if (DailyFont != null)
                ImGuiNET.ImGui.PopFont();

            if (ClearFont != null)
                ImGuiNET.ImGui.PopFont();

            return Width.IsVisible ?
                new Size(Width, height) :
                new Size(width, height);
        }

        protected override void UpdateInternal(Rectangle contentRect)
        {
            var isEnabledLocal = Enabled;
            ApplyStyles(isEnabledLocal);

            // Draw button
            var shouldClick = ImGuiNET.ImGui.Button(string.Empty, new Vector2(contentRect.Width, contentRect.Height));
            var isActive = shouldClick && Enabled ? ToggleActive(true) : IsActive();

            // Draw content
            DrawContent(contentRect);

            // Draw border
            DrawBorder(contentRect, isActive);

            // Draw disabled
            DrawDisabled(contentRect);

            if (shouldClick && Enabled)
                OnClicked();

            RemoveStyles(isEnabledLocal);
        }

        protected static void ApplyStyles(bool isEnabled)
        {
            if (!isEnabled)
            {
                ImGuiNET.ImGui.PushStyleColor(ImGuiCol.ButtonHovered, Style.GetColor(ImGuiCol.Button).ToUInt32());
                ImGuiNET.ImGui.PushStyleColor(ImGuiCol.ButtonActive, Style.GetColor(ImGuiCol.Button).ToUInt32());
            }
        }

        protected static void RemoveStyles(bool isEnabled)
        {
            if (!isEnabled)
                ImGuiNET.ImGui.PopStyleColor(2);
        }

        private void DrawContent(Rectangle contentRect)
        {
            var topLeft = contentRect.Position + GetContentPosition();

            // Draw top line
            var topLine = topLeft;
            var questNameHeight = FontResource.GetCurrentLineHeight();

            // Draw attribute
            if (IsAttributeVisible())
            {
                var attributeIcon = NierResources.LoadAttributeIcon(Attribute);
                ImGuiNET.ImGui.GetWindowDrawList().AddImage((IntPtr)attributeIcon, topLine, topLine + NierResources.IconSize);

                topLine += new Vector2(NierResources.IconSize.X + LabelDistance_, (NierResources.IconSize.Y - questNameHeight) / 2f);
            }

            // Draw quest name
            var questNameColor = IsActive() && Enabled ? TextActiveColor : Style.GetColor(ImGuiCol.Text).ToUInt32();
            ImGuiNET.ImGui.GetWindowDrawList().AddText(topLine, questNameColor, Text ?? string.Empty);

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

            var bottomLine = topLeft + new Vector2(0, Math.Max(questNameHeight, IsAttributeVisible() ? NierResources.IconSize.Y : 0) + (IsAttributeVisible() ? SubDistanceAttributeY_ : SubDistanceY_));

            if (SubFont != null)
                ImGuiNET.ImGui.PushFont((ImFontPtr)SubFont);

            var height = FontResource.GetCurrentLineHeight() + (SubPadding_ * 2);

            // Draw force details
            var firstForceWidth = FontResource.GetCurrentLineWidth(UserInterfaceTextKey.Quest.kSuggestedPower.Localize());
            var secondForceWidth = FontResource.GetCurrentLineWidth($"{SuggestedPower}");
            var forceWidth = firstForceWidth + FontResource.GetCurrentLineWidth("0000000") + (SubPadding_ * 2);

            ImGuiNET.ImGui.GetWindowDrawList().AddRectFilled(bottomLine, bottomLine + new Vector2(forceWidth, height), BoxBackgroundColor, 0);
            ImGuiNET.ImGui.GetWindowDrawList().AddText(bottomLine + new Vector2(SubPadding_, SubPadding_), Style.GetColor(ImGuiCol.Text).ToUInt32(), UserInterfaceTextKey.Quest.kSuggestedPower.Localize());
            ImGuiNET.ImGui.GetWindowDrawList().AddText(bottomLine + new Vector2(forceWidth - SubPadding_ - secondForceWidth, SubPadding_), Style.GetColor(ImGuiCol.Text).ToUInt32(), $"{SuggestedPower}");

            bottomLine += new Vector2(forceWidth + SubDistanceX_, 0);

            // Draw stamina details
            var stamina = Stamina;
            var staminaIdentColor = Style.GetColor(ImGuiCol.Text).ToUInt32();
            var staminaTextColor = staminaIdentColor;

            if (StaminaCampaign != null)
            {
                stamina = stamina * StaminaCampaign.EffectValue / 1000;
                staminaTextColor = ReducedStaminaText;
            }

            var firstStaminaWidth = FontResource.GetCurrentLineWidth(UserInterfaceTextKey.Quest.kStamina.Localize());
            var secondStaminaWidth = FontResource.GetCurrentLineWidth($"{stamina}");
            var staminaWidth = firstStaminaWidth + FontResource.GetCurrentLineWidth("000") + (SubPadding_ * 2);

            ImGuiNET.ImGui.GetWindowDrawList().AddRectFilled(bottomLine, bottomLine + new Vector2(staminaWidth, height), BoxBackgroundColor, 0);
            ImGuiNET.ImGui.GetWindowDrawList().AddText(bottomLine + new Vector2(SubPadding_, SubPadding_), staminaIdentColor, UserInterfaceTextKey.Quest.kStamina.Localize());
            ImGuiNET.ImGui.GetWindowDrawList().AddText(bottomLine + new Vector2(staminaWidth - SubPadding_ - secondStaminaWidth, SubPadding_), staminaTextColor, $"{stamina}");

            if (SubFont != null)
                ImGuiNET.ImGui.PopFont();
        }

        private static int DrawDailyLabel(Rectangle contentRect)
        {
            if (DailyFont != null)
                ImGuiNET.ImGui.PushFont((ImFontPtr)DailyFont);

            var dailySize = FontResource.MeasureText(LocalizationResources.ButtonDaily);
            var dailyTopLeft = contentRect.Position + new Vector2(contentRect.Width - BorderWidth_ - BorderDistance_ - dailySize.X - (DailyPadding_ * 2), BorderWidth_ + BorderDistance_);
            var dailyBottomRight = dailyTopLeft + new Vector2((DailyPadding_ * 2) + dailySize.X, (DailyPadding_ * 2) + dailySize.Y);

            ImGuiNET.ImGui.GetWindowDrawList().AddRectFilled(dailyTopLeft, dailyBottomRight, DailyBackgroundColor, 0);
            ImGuiNET.ImGui.GetWindowDrawList().AddText(dailyTopLeft + new Vector2(DailyPadding_, DailyPadding_), DailyTextColor, LocalizationResources.ButtonDaily);

            if (DailyFont != null)
                ImGuiNET.ImGui.PopFont();

            return (int)(dailyBottomRight.X - dailyTopLeft.X);
        }

        private static void DrawClearLabel(Rectangle contentRect, int offsetX)
        {
            if (ClearFont != null)
                ImGuiNET.ImGui.PushFont((ImFontPtr)ClearFont);

            var clearSize = FontResource.MeasureText(LocalizationResources.ButtonClear);
            var clearTopLeft = new Vector2(contentRect.X + contentRect.Width - BorderWidth_ - BorderDistance_ - clearSize.X - (ClearPadding_ * 2) + offsetX,
                contentRect.Y + BorderWidth_ + BorderDistance_);
            var clearBottomRight = clearTopLeft + new Vector2((ClearPadding_ * 2) + clearSize.X + offsetX, (ClearPadding_ * 2) + clearSize.Y);

            ImGuiNET.ImGui.GetWindowDrawList().AddRectFilled(clearTopLeft, clearBottomRight, ClearBackgroundColor, 0);
            ImGuiNET.ImGui.GetWindowDrawList().AddText(clearTopLeft + new Vector2(ClearPadding_, ClearPadding_), ClearTextColor, LocalizationResources.ButtonClear);

            if (ClearFont != null)
                ImGuiNET.ImGui.PopFont();
        }

        private bool IsAttributeVisible()
        {
            return Attribute != QuestDisplayAttributeType.UNKNOWN &&
                   Attribute != QuestDisplayAttributeType.NOTHING &&
                   Attribute != QuestDisplayAttributeType.ALL &&
                   Attribute != QuestDisplayAttributeType.VARIOUS;
        }
    }
}
