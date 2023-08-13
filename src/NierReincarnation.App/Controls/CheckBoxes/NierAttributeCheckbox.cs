using NierReincarnation.App.Resources;
using NierReincarnation.Core.Dark.Generated.Type;
using System;
using System.Numerics;
using Veldrid;

namespace NierReincarnation.App.Controls.CheckBoxes
{
    internal class NierAttributeCheckbox : NierIconCheckbox
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
