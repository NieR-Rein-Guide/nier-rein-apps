using System;
using System.Numerics;
using System.Reflection;
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

        private static readonly Rectangle CompanionBorder = new Rectangle(469, 531, 108, 108);
        private static readonly Rectangle CompanionBackground = new Rectangle(343, 448, 108, 108);

        private static readonly Vector2 IconPadSize = new Vector2(102, 102);
        public static readonly Vector2 ItemSlotSize = new Vector2(82, 82);
        public static readonly Vector2 IconSize = new Vector2(25, 25);

        #region Embedded icons

        public static ImageAsset LoadAttributeIcon(AttributeType attribute)
        {
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
            return new ImageAsset(icon);
        }

        public static ImageAsset LoadWeaponTypeIcon(WeaponType weaponType)
        {
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
            return new ImageAsset(icon);
        }

        public static ImageAsset LoadRarityStarIcon(RarityType rarity)
        {
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

            var icon = IconsAtlas.Clone(context => context.Crop(crop));
            return new ImageAsset(icon);
        }

        public static ImageAsset LoadRarityBackground(RarityType rarity)
        {
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

            var icon = IconsAtlas.Clone(context => context.Crop(crop));
            return new ImageAsset(icon);
        }

        public static ImageAsset LoadRarityBorder(RarityType rarity)
        {
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

            var icon = IconsAtlas.Clone(context => context.Crop(crop));
            return new ImageAsset(icon);
        }

        public static ImageAsset LoadCompanionBackground()
        {
            EnsureIconsAtlas();

            var icon = IconsAtlas.Clone(context => context.Crop(CompanionBackground));
            return new ImageAsset(icon);
        }

        public static ImageAsset LoadCompanionBorder()
        {
            EnsureIconsAtlas();

            var icon = IconsAtlas.Clone(context => context.Crop(CompanionBorder));
            return new ImageAsset(icon);
        }

        public static ImageAsset LoadExIcon()
        {
            EnsureIconsAtlas();

            var icon = IconsAtlas.Clone(context => context.Crop(IsExIcon));
            return new ImageAsset(icon);
        }

        private static void EnsureIconsAtlas()
        {
            if (IconsAtlas != null)
                return;

            var iconsStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(IconsAtlasPath_);

            IconsAtlas = Image.Load<Bgra32>(iconsStream);
        }

        #endregion

        #region Icon assets

        public static ImageAsset LoadCostumeIconAsset(ActorAssetId assetId)
        {
            if (assetId == null)
                return null;

            var asset = LoadAsset(string.Format(CostumeIconPath_, assetId));
            PadResize(asset, AnchorPositionMode.BottomRight);

            return asset;
        }

        public static ImageAsset LoadWeaponIconAsset(ActorAssetId assetId)
        {
            if (assetId == null)
                return null;

            var asset = LoadAsset(string.Format(WeaponIconPath_, assetId));
            PadResize(asset, AnchorPositionMode.Center);

            return asset;
        }

        public static ImageAsset LoadCompanionIconAsset(ActorAssetId assetId)
        {
            if (assetId == null)
                return null;

            var asset = LoadAsset(string.Format(CompanionIconPath_, assetId));
            PadResize(asset, AnchorPositionMode.Bottom);

            return asset;
        }

        public static ImageAsset LoadMemoryIconAsset(int groupAssetId)
        {
            if (groupAssetId == 0)
                return null;

            var asset = LoadAsset(string.Format(MemoryIconPath_, groupAssetId));
            PadResize(asset, AnchorPositionMode.Center);

            return asset;
        }

        private static ImageAsset LoadAsset(string path)
        {
            return NierReincarnation.Core.UnityEngine.Resources.LoadImage(path);
        }

        private static void PadResize(ImageAsset asset, AnchorPositionMode position)
        {
            asset.Image.Mutate(i => i.Resize(new ResizeOptions
            {
                // First pad to icon dimensions
                Size = new Size(Math.Max((int)IconPadSize.X, asset.Image.Width), Math.Max((int)IconPadSize.Y, asset.Image.Height)),
                Mode = ResizeMode.BoxPad,
                Sampler = KnownResamplers.NearestNeighbor,
                Position = position
            }));
        }

        #endregion
    }
}
