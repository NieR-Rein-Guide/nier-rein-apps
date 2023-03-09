using NierReincarnation.App.Controls.Buttons.Base;
using NierReincarnation.App.Dialogs;
using System.Numerics;
using Rectangle = Veldrid.Rectangle;
using Size = ImGui.Forms.Models.Size;

namespace NierReincarnation.App.Controls.Buttons
{
    internal class StaminaPreferenceButton : BaseNierButton
    {
        private static readonly Vector2 ButtonSize = new(16, 16);
        private static readonly Vector2 IconSize = new(10, 10);

        public override Size GetSize() => new((int)ButtonSize.X, (int)ButtonSize.Y);

        protected override async void UpdateInternal(Rectangle contentRect)
        {
            // Draw button
            var shouldClick = ImGuiNET.ImGui.Button(string.Empty, ButtonSize);
            var isActive = shouldClick && Enabled ? ToggleActive(true) : IsActive();

            // Draw border
            DrawBorder(contentRect, isActive);

            // Draw plus
            var plusPos = contentRect.Position + new Vector2(ButtonSize.X / 2, (ButtonSize.Y - IconSize.Y) / 2) - new Vector2(1, 0);
            var plusPos2 = contentRect.Position + new Vector2((ButtonSize.X - IconSize.X) / 2, ButtonSize.Y / 2) - new Vector2(0, 0);
            ImGuiNET.ImGui.GetWindowDrawList().AddLine(plusPos, plusPos + new Vector2(0, IconSize.Y), BorderColor, 2);
            ImGuiNET.ImGui.GetWindowDrawList().AddLine(plusPos2, plusPos2 + new Vector2(IconSize.X, 0), BorderColor, 2);

            if (shouldClick && Enabled)
            {
                await new StaminaPreferenceDialog().ShowAsync();
            }
        }
    }
}
