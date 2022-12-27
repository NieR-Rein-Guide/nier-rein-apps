using System;
using System.Drawing;
using System.Numerics;
using ImGui.Forms.Controls.Base;
using ImGui.Forms.Extensions;
using ImGuiNET;
using Rectangle = Veldrid.Rectangle;

namespace nier_rein_gui.Controls.Buttons.Base
{
    abstract class BaseNierButton : ActivableComponent
    {
        protected const int BorderDistance_ = 3;
        protected const int BorderWidth_ = 3;

        protected static readonly uint BorderColor = Color.FromArgb(0x6B, 0x63, 0x60).ToUInt32();
        protected static readonly uint BorderActiveColor = Color.FromArgb(0x74, 0x71, 0x6C).ToUInt32();
        private static readonly uint DisabledColor = Color.FromArgb(0x88, 0x00, 0x00, 0x00).ToUInt32();

        public event EventHandler Clicked;

        public Vector2 Padding { get; set; } = new Vector2(2, 2);

        protected Vector2 GetContentSize() => GetContentPosition() * 2;

        protected Vector2 GetContentPosition() => new Vector2(BorderDistance_ + BorderWidth_ + Padding.X, BorderDistance_ + BorderWidth_ + Padding.Y);

        protected void DrawBorder(Rectangle contentRect, bool isActive)
        {
            var topLeft = new Vector2(contentRect.X + BorderDistance_, contentRect.Y + BorderDistance_);
            var bottomRight = new Vector2(contentRect.X + contentRect.Width - BorderDistance_, contentRect.Y + contentRect.Height - BorderDistance_);
            var color = isActive ? BorderActiveColor : BorderColor;

            ImGuiNET.ImGui.GetWindowDrawList().AddRect(topLeft, bottomRight, color, 0, ImDrawFlags.None, BorderWidth_);
        }

        protected void DrawDisabled(Rectangle contentRect)
        {
            if(Enabled)
                return;

            var topLeft = new Vector2(contentRect.X, contentRect.Y);
            var bottomRight = new Vector2(contentRect.X + contentRect.Width, contentRect.Y + contentRect.Height);
            ImGuiNET.ImGui.GetWindowDrawList().AddRectFilled(topLeft, bottomRight, DisabledColor);

            var lockImg = Resources.ImageResources.Lock;
            topLeft = new Vector2(contentRect.X + contentRect.Width / 2 - lockImg.Width / 2, contentRect.Y + contentRect.Height / 2 - lockImg.Height / 2);
            bottomRight = new Vector2(contentRect.X + contentRect.Width / 2 + lockImg.Width / 2, contentRect.Y + contentRect.Height / 2 + lockImg.Height / 2);
            ImGuiNET.ImGui.GetWindowDrawList().AddImage((IntPtr)lockImg, topLeft, bottomRight);
        }

        protected void OnClicked()
        {
            Clicked?.Invoke(this, new EventArgs());
        }

        protected string EscapeCaption(string unescapedCaption)
        {
            return unescapedCaption?.Replace("\\n", Environment.NewLine) ?? string.Empty;
        }
    }
}
