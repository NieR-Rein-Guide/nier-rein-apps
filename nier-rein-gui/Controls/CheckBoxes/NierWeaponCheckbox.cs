using System;
using System.Numerics;
using ImGui.Forms.Resources;
using nier_rein_gui.Resources;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.UnityEngine;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using Rectangle = Veldrid.Rectangle;

namespace nier_rein_gui.Controls.CheckBoxes
{
    class NierWeaponCheckbox : NierIconCheckbox
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
