using System;
using System.Drawing;
using System.Numerics;
using ImGui.Forms;
using ImGui.Forms.Controls.Base;
using ImGui.Forms.Extensions;
using ImGui.Forms.Resources;
using ImGuiNET;
using nier_rein_gui.Resources;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.UnityEngine;
using SixLabors.ImageSharp.Processing;
using Rectangle = Veldrid.Rectangle;
using Size = ImGui.Forms.Models.Size;

namespace nier_rein_gui.Controls.Buttons
{
    class NierIconButton : Component
    {
        private static readonly Vector2 PlaceHolderSize = new Vector2(20, 20);
        protected static readonly Vector2 IconSize = new Vector2(25, 25);

        private static readonly uint BorderColor = Color.FromArgb(0x6B, 0x63, 0x60).ToUInt32();
        private static readonly uint BorderActiveColor = Color.FromArgb(0x74, 0x71, 0x6C).ToUInt32();

        private ImageResource _attributeResource;
        private ImageResource _weaponResource;
        private ImageResource _borderResource;
        private ImageResource _backgroundResource;
        private ImageResource _isExResource;
        private AttributeType _attribute;
        private WeaponType _weapon;
        private RarityType _rarity;
        private bool isEnd;

        #region Properties

        public Vector2 Padding { get; set; }

        public Vector2 EmptySize { get; set; }
        public ImageResource Image { get; set; }

        public bool Active { get; set; }

        public AttributeType Attribute
        {
            get => _attribute;
            set
            {
                if (value == AttributeType.UNKNOWN || value == AttributeType.NOTHING)
                {
                    _attribute = AttributeType.UNKNOWN;

                    _attributeResource?.Destroy();
                    _attributeResource = null;

                    return;
                }

                _attribute = value;

                var asset = NierResources.LoadAttributeIcon(value);
                asset.Image.Mutate(x => x.Resize(new SixLabors.ImageSharp.Size((int)IconSize.X, (int)IconSize.Y)));

                _attributeResource = ImageResource.FromStream(asset.AsStream());
            }
        }

        public WeaponType WeaponType
        {
            get => _weapon;
            set
            {
                if (value == WeaponType.UNKNOWN)
                {
                    _weapon = WeaponType.UNKNOWN;

                    _weaponResource?.Destroy();
                    _weaponResource = null;

                    return;
                }

                _weapon = value;

                var asset = NierResources.LoadWeaponTypeIcon(value);
                asset.Image.Mutate(x => x.Resize(new SixLabors.ImageSharp.Size((int)IconSize.X, (int)IconSize.Y)));

                _weaponResource = ImageResource.FromStream(asset.AsStream());
            }
        }

        public RarityType RarityType
        {
            get => _rarity;
            set
            {
                if (value == RarityType.UNKNOWN)
                {
                    _rarity = RarityType.UNKNOWN;

                    _borderResource?.Destroy();
                    _borderResource = null;
                    _backgroundResource?.Destroy();
                    _backgroundResource = null;

                    return;
                }

                _rarity = value;

                var border = NierResources.LoadRarityBorder(value);
                var background = NierResources.LoadRarityBackground(value);

                border.Image.Mutate(x => x.Resize(new SixLabors.ImageSharp.Size((int)NierResources.ItemSlotSize.X, (int)NierResources.ItemSlotSize.Y)));
                background.Image.Mutate(x => x.Resize(new SixLabors.ImageSharp.Size((int)NierResources.ItemSlotSize.X, (int)NierResources.ItemSlotSize.Y)));

                _borderResource = ImageResource.FromStream(border.AsStream());
                _backgroundResource = ImageResource.FromStream(background.AsStream());
            }
        }

        public bool IsEnd
        {
            get => isEnd;
            set
            {
                isEnd = value;

                if (_isExResource == null)
                {
                    var asset = NierResources.LoadExIcon();
                    asset.Image.Mutate(x => x.Resize(new SixLabors.ImageSharp.Size((int)IconSize.X, (int)IconSize.Y)));

                    _isExResource = ImageResource.FromStream(asset.AsStream());
                }
            }
        }

        #endregion

        public event EventHandler Clicked;

        public override Size GetSize()
        {
            var size = GetImageSize() + Padding * 2;
            return new Size((int)size.X, (int)size.Y);
        }

        protected override void UpdateInternal(Rectangle contentRect)
        {
            var isActive = Active;
            if (isActive)
            {
                ImGuiNET.ImGui.PushStyleColor(ImGuiCol.Button, Style.GetColor(ImGuiCol.ButtonActive).ToUInt32());
                ImGuiNET.ImGui.PushStyleColor(ImGuiCol.ButtonHovered, Style.GetColor(ImGuiCol.ButtonActive).ToUInt32());
            }

            ImGuiNET.ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, Padding);

            var isClicked = ImGuiNET.ImGui.Button(string.Empty, GetImageSize() + Padding * 2);
            DrawContent(contentRect);

            if (isClicked)
                OnClicked();

            if (isActive)
                ImGuiNET.ImGui.PopStyleColor(2);

            ImGuiNET.ImGui.PopStyleVar(1);
        }

        protected override void ApplyStyles()
        {
            ImGuiNET.ImGui.PushStyleColor(ImGuiCol.Button, 0);
        }

        protected override void RemoveStyles()
        {
            ImGuiNET.ImGui.PopStyleColor(1);
        }

        private Vector2 GetImageSize()
        {
            if (Image != null)
                return NierResources.ItemSlotSize;

            return EmptySize;
        }

        private void DrawContent(Rectangle rect)
        {
            var isActive = Active || ImGuiNET.ImGui.IsItemActive() && ImGuiNET.ImGui.IsItemHovered();
            var borderColor = isActive ? BorderActiveColor : BorderColor;

            if (Image != null)
            {
                ImGuiNET.ImGui.GetWindowDrawList().AddImage((IntPtr)_backgroundResource, rect.Position + Padding, rect.Position + Padding + GetImageSize());
                ImGuiNET.ImGui.GetWindowDrawList().AddImage((IntPtr)Image, rect.Position + Padding, rect.Position + Padding + GetImageSize());
                ImGuiNET.ImGui.GetWindowDrawList().AddImage((IntPtr)_borderResource, rect.Position + Padding, rect.Position + Padding + GetImageSize());

                var iconPos = rect.Position + Padding;
                if (_attributeResource != null)
                {
                    ImGuiNET.ImGui.GetWindowDrawList().AddImage((IntPtr)_attributeResource, iconPos, iconPos + _attributeResource.Size);
                    iconPos += new Vector2(0, _attributeResource.Height);
                }

                if (_weaponResource != null)
                {
                    ImGuiNET.ImGui.GetWindowDrawList().AddImage((IntPtr)_weaponResource, iconPos, iconPos + _weaponResource.Size);
                    iconPos += new Vector2(0, _weaponResource.Height);
                }

                if (isEnd)
                    ImGuiNET.ImGui.GetWindowDrawList().AddImage((IntPtr)_isExResource, iconPos, iconPos + _isExResource.Size);
            }
            else
                DrawPlaceholder(rect, borderColor);

            //ImGuiNET.ImGui.GetWindowDrawList().AddRect(rect.Position + Padding / 2, rect.Position + rect.Size - Padding / 2, borderColor, 0, ImDrawFlags.None, 1);
        }

        private void DrawPlaceholder(Rectangle rect, uint borderColor)
        {
            var thickness = 2;

            var topLeft = rect.Position + Padding + (EmptySize - PlaceHolderSize) / 2;
            ImGuiNET.ImGui.GetWindowDrawList().AddLine(topLeft + new Vector2(0, PlaceHolderSize.Y / 2), topLeft + new Vector2(PlaceHolderSize.X, PlaceHolderSize.Y / 2), borderColor, thickness);
            ImGuiNET.ImGui.GetWindowDrawList().AddLine(topLeft + new Vector2(PlaceHolderSize.X / 2 - thickness / 2, 0), topLeft + new Vector2(PlaceHolderSize.X / 2 - thickness / 2, PlaceHolderSize.Y), borderColor, thickness);
        }

        private void OnClicked()
        {
            Clicked?.Invoke(this, new EventArgs());
        }
    }
}
