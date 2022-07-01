using System;
using System.Numerics;
using nier_rein_gui.Resources;
using NierReincarnation.Core.Dark.Generated.Type;
using Veldrid;

namespace nier_rein_gui.Controls.CheckBoxes
{
    class NierAttributeCheckbox : NierIconCheckbox
    {
        public AttributeType Attribute { get; set; }

        protected override Vector2 GetIconSize()
        {
            return NierResources.IconSize;
        }

        protected override void DrawIcon(Rectangle contentRect)
        {
            var pos = contentRect.Position + GetIconPosition();
            ImGuiNET.ImGui.GetWindowDrawList().AddImage((IntPtr)NierResources.LoadAttributeIcon(Attribute), pos, pos + NierResources.IconSize);
        }
    }
}
