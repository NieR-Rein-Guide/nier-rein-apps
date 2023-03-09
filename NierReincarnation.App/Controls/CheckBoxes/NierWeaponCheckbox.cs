using NierReincarnation.App.Resources;
using NierReincarnation.Core.Dark.Generated.Type;
using System;
using System.Numerics;
using Rectangle = Veldrid.Rectangle;

namespace NierReincarnation.App.Controls.CheckBoxes
{
    internal class NierWeaponCheckbox : NierIconCheckbox
    {
        public WeaponType WeaponType { get; set; }

        protected override Vector2 GetIconSize()
        {
            return NierResources.IconSize;
        }

        protected override void DrawIcon(Rectangle contentRect)
        {
            var pos = contentRect.Position + GetIconPosition();
            ImGuiNET.ImGui.GetWindowDrawList().AddImage((IntPtr)NierResources.LoadWeaponTypeIcon(WeaponType), pos, pos + NierResources.IconSize);
        }
    }
}
