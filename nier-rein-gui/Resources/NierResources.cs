using System;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;
using ImGui.Forms.Resources;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.UnityEngine;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace nier_rein_gui.Resources
{
    static class NierResources
    {
        private const string IconsAtlasPath_ = "nier-rein-gui.Resources.Images.icons_1.png";

        private const string CostumeIconPath_ = "assets/ui/costume/{0}/{0}_standard.asset";
        private const string WeaponIconPath_ = "assets/ui/weapon/{0}/{0}_standard.asset";
        private const string CompanionIconPath_ = "assets/ui/companion/{0}/{0}_standard.asset";
        private const string MemoryIconPath_ = "assets/ui/memory/memory{0:D3}/memory{0:D3}_standard.asset";

        private static readonly IDictionary<AttributeType, ImageResource> AttributeIcons = new Dictionary<AttributeType, ImageResource>();
        private static readonly IDictionary<WeaponType, ImageResource> WeaponIcons = new Dictionary<WeaponType, ImageResource>();
        private static readonly IDictionary<RarityType, ImageResource> RarityStarIcons = new Dictionary<RarityType, ImageResource>();
        private static readonly IDictionary<RarityType, ImageResource> RarityBorders = new Dictionary<RarityType, ImageResource>();
        private static readonly IDictionary<RarityType, ImageResource> RarityBackgrounds = new Dictionary<RarityType, ImageResource>();

        private static readonly IDictionary<string, ImageResource> CostumeItems = new Dictionary<string, ImageResource>();
        private static readonly IDictionary<string, ImageResource> WeaponItems = new Dictionary<string, ImageResource>();
        private static readonly IDictionary<string, ImageResource> CompanionItems = new Dictionary<string, ImageResource>();
        private static readonly IDictionary<int, ImageResource> MemoryItems = new Dictionary<int, ImageResource>();

        private static ImageResource CompanionBackgroundResource;
        private static ImageResource CompanionBorderResource;
        private static ImageResource IsEndIconResource;

        private static ImageResource CostumePlaceholderResource;
        private static ImageResource WeaponPlaceholderResource;
        private static ImageResource CompanionPlaceholderResource;
        private static ImageResource MemoryPlaceholderResource;

        private static ImageResource EditIconResource;

        private static Image<Bgra32> IconsAtlas;

        private static readonly Rectangle FireIcon = new Rectangle(957, 990, 34, 34);
        private static readonly Rectangle WaterIcon = new Rectangle(431, 94, 34, 34);
        private static readonly Rectangle WindIcon = new Rectangle(892, 345, 34, 34);
        private static readonly Rectangle LightIcon = new Rectangle(861, 287, 34, 34);
        private static readonly Rectangle DarkIcon = new Rectangle(746, 101, 34, 34);

        private static readonly Rectangle BigSwordIcon = new Rectangle(566, 91, 34, 34);
        private static readonly Rectangle SwordIcon = new Rectangle(566, 53, 34, 34);
        private static readonly Rectangle SpearIcon = new Rectangle(815, 173, 34, 34);
        private static readonly Rectangle StaffIcon = new Rectangle(957, 952, 34, 34);
        private static readonly Rectangle GunIcon = new Rectangle(884, 421, 34, 34);
        private static readonly Rectangle FistIcon = new Rectangle(371, 34, 34, 34);

        private static readonly Rectangle LegendStar = new Rectangle(204, 630, 19, 19);
        private static readonly Rectangle LegendBorder = new Rectangle(1, 352, 108, 108);
        private static readonly Rectangle LegendBackground = new Rectangle(863, 687, 108, 108);
        private static readonly Rectangle SrStar = new Rectangle(985, 386, 19, 19);
        private static readonly Rectangle SrBorder = new Rectangle(229, 219, 108, 108);
        private static readonly Rectangle SrBackground = new Rectangle(1, 466, 108, 108);
        private static readonly Rectangle RareStar = new Rectangle(936, 113, 19, 19);
        private static readonly Rectangle RareBorder = new Rectangle(115, 466, 108, 108);
        private static readonly Rectangle RareBackground = new Rectangle(749, 571, 108, 108);

        private static readonly Rectangle IsExIcon = new Rectangle(860, 211, 34, 34);

        private static readonly Rectangle EditIcon = new Rectangle(936, 306, 25, 25);

        private static readonly Rectangle CompanionBorder = new Rectangle(469, 531, 108, 108);
        private static readonly Rectangle CompanionBackground = new Rectangle(343, 448, 108, 108);

        private static readonly Rectangle CostumePlaceholder = new Rectangle(1, 238, 108, 108);
        private static readonly Rectangle WeaponPlaceholder = new Rectangle(229, 333, 108, 108);
        private static readonly Rectangle CompanionPlaceholder = new Rectangle(863, 573, 108, 108);
        private static readonly Rectangle MemoryPlaceholder = new Rectangle(115, 352, 108, 108);

        private static readonly Vector2 IconPadSize = new Vector2(102, 102);
        public static readonly Vector2 ItemSlotSize = new Vector2(82, 82);
        public static readonly Vector2 IconSize = new Vector2(25, 25);
        public static readonly Vector2 RarityStarSize = new Vector2(15, 15);

        #region Embedded icons

        public static ImageResource LoadCostumePlaceholder()
        {
            if (CostumePlaceholderResource != null)
                return CostumePlaceholderResource;

            EnsureIconsAtlas();

            var placeHolder = IconsAtlas.Clone(context => context.Crop(CostumePlaceholder));
            return CostumePlaceholderResource = LoadItemResource(placeHolder);
        }

        public static ImageResource LoadWeaponPlaceholder()
        {
            if (WeaponPlaceholderResource != null)
                return WeaponPlaceholderResource;

            EnsureIconsAtlas();

            var placeHolder = IconsAtlas.Clone(context => context.Crop(WeaponPlaceholder));
            return WeaponPlaceholderResource = LoadItemResource(placeHolder);
        }

        public static ImageResource LoadCompanionPlaceholder()
        {
            if (CompanionPlaceholderResource != null)
                return CompanionPlaceholderResource;

            EnsureIconsAtlas();

            var placeHolder = IconsAtlas.Clone(context => context.Crop(CompanionPlaceholder));
            return CompanionPlaceholderResource = LoadItemResource(placeHolder);
        }

        public static ImageResource LoadMemoryPlaceholder()
        {
            if (MemoryPlaceholderResource != null)
                return MemoryPlaceholderResource;

            EnsureIconsAtlas();

            var placeHolder = IconsAtlas.Clone(context => context.Crop(MemoryPlaceholder));
            return MemoryPlaceholderResource = LoadItemResource(placeHolder);
        }

        public static ImageResource LoadAttributeIcon(AttributeType attribute)
        {
            if (AttributeIcons.ContainsKey(attribute))
                return AttributeIcons[attribute];

            EnsureIconsAtlas();

            Rectangle crop;
            switch (attribute)
            {
                case AttributeType.FIRE:
                    crop = FireIcon;
                    break;

                case AttributeType.WATER:
                    crop = WaterIcon;
                    break;

                case AttributeType.WIND:
                    crop = WindIcon;
                    break;

                case AttributeType.LIGHT:
                    crop = LightIcon;
                    break;

                case AttributeType.DARK:
                    crop = DarkIcon;
                    break;

                default:
                    return null;
            }

            var icon = IconsAtlas.Clone(context => context.Crop(crop));
            return AttributeIcons[attribute] = LoadIconResource(icon);
        }

        public static ImageResource LoadWeaponTypeIcon(WeaponType weaponType)
        {
            if (WeaponIcons.ContainsKey(weaponType))
                return WeaponIcons[weaponType];

            EnsureIconsAtlas();

            Rectangle crop;
            switch (weaponType)
            {
                case WeaponType.BIG_SWORD:
                    crop = BigSwordIcon;
                    break;

                case WeaponType.SWORD:
                    crop = SwordIcon;
                    break;

                case WeaponType.SPEAR:
                    crop = SpearIcon;
                    break;

                case WeaponType.STAFF:
                    crop = StaffIcon;
                    break;

                case WeaponType.GUN:
                    crop = GunIcon;
                    break;

                case WeaponType.FIST:
                    crop = FistIcon;
                    break;

                default:
                    return null;
            }

            var icon = IconsAtlas.Clone(context => context.Crop(crop));
            return WeaponIcons[weaponType] = LoadIconResource(icon);
        }

        public static ImageResource LoadRarityStarIcon(RarityType rarity)
        {
            if (RarityStarIcons.ContainsKey(rarity))
                return RarityStarIcons[rarity];

            EnsureIconsAtlas();

            Rectangle crop;
            switch (rarity)
            {
                case RarityType.LEGEND:
                case RarityType.SS_RARE:
                    crop = LegendStar;
                    break;

                case RarityType.S_RARE:
                    crop = SrStar;
                    break;

                case RarityType.RARE:
                    crop = RareStar;
                    break;

                default:
                    return null;
            }

            var starIcon = IconsAtlas.Clone(context => context.Crop(crop));
            return RarityStarIcons[rarity] = LoadStarResource(starIcon);
        }

        public static ImageResource LoadRarityBackground(RarityType rarity)
        {
            if (RarityBackgrounds.ContainsKey(rarity))
                return RarityBackgrounds[rarity];

            EnsureIconsAtlas();

            Rectangle crop;
            switch (rarity)
            {
                case RarityType.LEGEND:
                case RarityType.SS_RARE:
                    crop = LegendBackground;
                    break;

                case RarityType.S_RARE:
                    crop = SrBackground;
                    break;

                case RarityType.RARE:
                    crop = RareBackground;
                    break;

                default:
                    return null;
            }

            var item = IconsAtlas.Clone(context => context.Crop(crop));
            return RarityBackgrounds[rarity] = LoadItemResource(item);
        }

        public static ImageResource LoadRarityBorder(RarityType rarity)
        {
            if (RarityBorders.ContainsKey(rarity))
                return RarityBorders[rarity];

            EnsureIconsAtlas();

            Rectangle crop;
            switch (rarity)
            {
                case RarityType.LEGEND:
                case RarityType.SS_RARE:
                    crop = LegendBorder;
                    break;

                case RarityType.S_RARE:
                    crop = SrBorder;
                    break;

                case RarityType.RARE:
                    crop = RareBorder;
                    break;

                default:
                    return null;
            }

            var item = IconsAtlas.Clone(context => context.Crop(crop));
            return RarityBorders[rarity] = LoadItemResource(item);
        }

        public static ImageResource LoadCompanionBackground()
        {
            if (CompanionBackgroundResource != null)
                return CompanionBackgroundResource;

            EnsureIconsAtlas();

            var item = IconsAtlas.Clone(context => context.Crop(CompanionBackground));
            return CompanionBackgroundResource = LoadItemResource(item);
        }

        public static ImageResource LoadCompanionBorder()
        {
            if (CompanionBorderResource != null)
                return CompanionBorderResource;

            EnsureIconsAtlas();

            var item = IconsAtlas.Clone(context => context.Crop(CompanionBorder));
            return CompanionBorderResource = LoadItemResource(item);
        }

        public static ImageResource LoadExIcon()
        {
            if (IsEndIconResource != null)
                return IsEndIconResource;

            EnsureIconsAtlas();

            var icon = IconsAtlas.Clone(context => context.Crop(IsExIcon));
            return IsEndIconResource = LoadIconResource(icon);
        }

        public static ImageResource LoadEditIcon()
        {
            if (EditIconResource != null)
                return EditIconResource;

            EnsureIconsAtlas();

            var icon = IconsAtlas.Clone(context => context.Crop(EditIcon));
            return EditIconResource = LoadResource(icon, RarityStarSize);
        }

        private static void EnsureIconsAtlas()
        {
            if (IconsAtlas != null)
                return;

            var iconsStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(IconsAtlasPath_);

            IconsAtlas = Image.Load<Bgra32>(iconsStream);
        }

        private static ImageResource LoadItemResource(Image<Bgra32> image)
        {
            return LoadResource(image, ItemSlotSize);
        }

        private static ImageResource LoadIconResource(Image<Bgra32> image)
        {
            return LoadResource(image, IconSize);
        }

        private static ImageResource LoadStarResource(Image<Bgra32> image)
        {
            return LoadResource(image, RarityStarSize);
        }

        private static ImageResource LoadResource(Image<Bgra32> image, Vector2 size)
        {
            var asset = new ImageAsset(image);
            asset.Image.Mutate(x => x.Resize(new Size((int)size.X, (int)size.Y)));

            return ImageResource.FromStream(asset.AsStream());
        }

        #endregion

        #region Icon assets

        public static ImageResource LoadCostumeItem(ActorAssetId assetId)
        {
            if (assetId == null)
                return null;

            if (CostumeItems.ContainsKey(assetId.StringId))
                return CostumeItems[assetId.StringId];

            var asset = LoadAsset(string.Format(CostumeIconPath_, assetId));
            PadResizeItem(asset, AnchorPositionMode.BottomRight);

            return CostumeItems[assetId.StringId] = ImageResource.FromStream(asset.AsStream());
        }

        public static ImageResource LoadWeaponItem(ActorAssetId assetId)
        {
            if (assetId == null)
                return null;

            if (WeaponItems.ContainsKey(assetId.StringId))
                return WeaponItems[assetId.StringId];

            var asset = LoadAsset(string.Format(WeaponIconPath_, assetId));
            PadResizeItem(asset, AnchorPositionMode.Center);

            return WeaponItems[assetId.StringId] = ImageResource.FromStream(asset.AsStream());
        }

        public static ImageResource LoadCompanionItem(ActorAssetId assetId)
        {
            if (assetId == null)
                return null;

            if (CompanionItems.ContainsKey(assetId.StringId))
                return CompanionItems[assetId.StringId];

            var asset = LoadAsset(string.Format(CompanionIconPath_, assetId));
            PadResizeItem(asset, AnchorPositionMode.Bottom);

            return CompanionItems[assetId.StringId] = ImageResource.FromStream(asset.AsStream());
        }

        public static ImageResource LoadMemoryItem(int groupAssetId)
        {
            if (groupAssetId == 0)
                return null;

            if (MemoryItems.ContainsKey(groupAssetId))
                return MemoryItems[groupAssetId];

            var asset = LoadAsset(string.Format(MemoryIconPath_, groupAssetId));
            PadResizeItem(asset, AnchorPositionMode.Center);

            return MemoryItems[groupAssetId] = ImageResource.FromStream(asset.AsStream());
        }

        private static ImageAsset LoadAsset(string path)
        {
            return NierReincarnation.Core.UnityEngine.Resources.LoadImage(path);
        }

        private static void PadResizeItem(ImageAsset asset, AnchorPositionMode position)
        {
            asset.Image.Mutate(i => i.Resize(new ResizeOptions
            {
                // First pad to icon dimensions
                Size = new Size(Math.Max((int)IconPadSize.X, asset.Image.Width), Math.Max((int)IconPadSize.Y, asset.Image.Height)),
                Mode = ResizeMode.BoxPad,
                Sampler = KnownResamplers.NearestNeighbor,
                Position = position
            }).Resize(new Size((int)ItemSlotSize.X, (int)ItemSlotSize.Y)));
        }

        #endregion
    }
}
