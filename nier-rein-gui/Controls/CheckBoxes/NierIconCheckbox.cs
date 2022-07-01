using System;
using System.Numerics;
using ImGui.Forms.Controls.Base;
using ImGui.Forms.Models;
using Veldrid;

namespace nier_rein_gui.Controls
{
    abstract class NierIconCheckbox : Component
    {
        protected static readonly Vector2 CheckboxSize = new Vector2(21, 21);

        public bool Checked { get; set; }

        public event EventHandler CheckChanged;

        public override Size GetSize()
        {
            var iconSize = GetIconSize();
            return new Size((int)(Math.Ceiling(iconSize.X) + CheckboxSize.X + ImGuiNET.ImGui.GetStyle().ItemInnerSpacing.X), (int)Math.Max(Math.Ceiling(iconSize.Y), CheckboxSize.Y));
        }

        protected override void UpdateInternal(Rectangle contentRect)
        {
            var check = Checked;

            var y = Math.Abs(CheckboxSize.Y - GetIconSize().Y) / 2;

            ImGuiNET.ImGui.SetCursorPosY(y);
            var checkChanged = ImGuiNET.ImGui.Checkbox(string.Empty, ref check);

            DrawIcon(contentRect);

            if (checkChanged)
            {
                Checked = check;
                OnCheckChanged();
            }
        }

        protected abstract Vector2 GetIconSize();

        protected abstract void DrawIcon(Rectangle contentRect);

        protected virtual Vector2 GetIconPosition()
        {
            return new Vector2(CheckboxSize.X + ImGuiNET.ImGui.GetStyle().ItemInnerSpacing.X, (CheckboxSize.Y - GetIconSize().Y) / 2);
        }

        private void OnCheckChanged()
        {
            CheckChanged?.Invoke(this, new EventArgs());
        }
    }
}
