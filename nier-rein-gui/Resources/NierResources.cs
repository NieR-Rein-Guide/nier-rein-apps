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
        private const string ThoughtIconPath_ = "assets/ui/thought/thought{0:D6}/thought{0:D6}_standard.asset";
        private const string MemoryIconPath_ = "assets/ui/memory/memory{0:D3}/memory{0:D3}_standard.asset";
        private const string ConsumableItemPath_ = "assets/ui/consumable_item/consumable{0:D3}{1:D3}/consumable{0:D3}{1:D3}_standard.asset";

        private static readonly IDictionary<AttributeType, ImageResource> AttributeIcons = new Dictionary<AttributeType, ImageResource>();
        private static readonly IDictionary<WeaponType, ImageResource> WeaponIcons = new Dictionary<WeaponType, ImageResource>();
        private static readonly IDictionary<RarityType, ImageResource> RarityStarIcons = new Dictionary<RarityType, ImageResource>();
        private static readonly IDictionary<RarityType, ImageResource> RarityBorders = new Dictionary<RarityType, ImageResource>();
        private static readonly IDictionary<RarityType, ImageResource> RarityBackgrounds = new Dictionary<RarityType, ImageResource>();

        private static readonly IDictionary<string, ImageResource> CostumeItems = new Dictionary<string, ImageResource>();
        private static readonly IDictionary<string, ImageResource> WeaponItems = new Dictionary<string, ImageResource>();
        private static readonly IDictionary<string, ImageResource> CompanionItems = new Dictionary<string, ImageResource>();
        private static readonly IDictionary<int, ImageResource> ThoughtItems = new Dictionary<int, ImageResource>();
        private static readonly IDictionary<int, ImageResource> MemoryItems = new Dictionary<int, ImageResource>();
        private static readonly IDictionary<(int, int), ImageResource> ConsumableItems = new Dictionary<(int, int), ImageResource>();

        private static ImageResource CompanionBackgroundResource;
        private static ImageResource CompanionBorderResource;
        private static ImageResource IsEndIconResource;

        private static ImageResource CostumePlaceholderResource;
        private static ImageResource ThoughtPlaceholderResource;
        private static ImageResource WeaponPlaceholderResource;
        private static ImageResource CompanionPlaceholderResource;
        private static ImageResource MemoryPlaceholderResource;

        private static ImageResource EditIconResource;
        private static ImageResource BonusIconResource;
        private static ImageResource AwakenDefaultIconResource;
        private static ImageResource AwakenFullIconResource;

        private static Image<Bgra32> IconsAtlas;

        private static readonly Rectangle FireIcon = new Rectangle(863, 1294, 34, 34);
        private static readonly Rectangle WaterIcon = new Rectangle(626, 1126, 34, 34);
        private static readonly Rectangle WindIcon = new Rectangle(804, 1094, 34, 34);
        private static readonly Rectangle LightIcon = new Rectangle(901, 1301, 34, 34);
        private static readonly Rectangle DarkIcon = new Rectangle(84, 1039, 34, 34);

        private static readonly Rectangle BigSwordIcon = new Rectangle(787, 1266, 34, 34);
        private static readonly Rectangle SwordIcon = new Rectangle(122, 1038, 34, 34);
        private static readonly Rectangle SpearIcon = new Rectangle(901, 1339, 34, 34);
        private static readonly Rectangle StaffIcon = new Rectangle(901, 1263, 34, 34);
        private static readonly Rectangle GunIcon = new Rectangle(817, 1175, 34, 34);
        private static readonly Rectangle FistIcon = new Rectangle(863, 1256, 34, 34);

        private static readonly Rectangle AwakenDefaultIcon = new Rectangle(515, 1064, 32, 32);
        private static readonly Rectangle AwakenFullIcon = new Rectangle(805, 1133, 32, 32);

        private static readonly Rectangle LegendStar = new Rectangle(965, 1202, 19, 19);
        private static readonly Rectangle LegendBorder = new Rectangle(1, 1376, 108, 108);
        private static readonly Rectangle LegendBackground = new Rectangle(863, 1711, 108, 108);
        private static readonly Rectangle SrStar = new Rectangle(152, 1622, 19, 19);
        private static readonly Rectangle SrBorder = new Rectangle(457, 1441, 108, 108);
        private static readonly Rectangle SrBackground = new Rectangle(1, 1490, 108, 108);
        private static readonly Rectangle RareStar = new Rectangle(534, 1038, 19, 19);
        private static readonly Rectangle RareBorder = new Rectangle(115, 1490, 108, 108);
        private static readonly Rectangle RareBackground = new Rectangle(749, 1595, 108, 108);

        private static readonly Rectangle IsExIcon = new Rectangle(880,1137, 34, 34);
        private static readonly Rectangle EditIcon = new Rectangle(583, 1638, 25, 25);

        private static readonly Rectangle BonusArrow = new Rectangle(962, 1406, 28, 24);
        private static readonly Rectangle BonusPlus = new Rectangle(951, 1083, 26, 26);

        private static readonly Rectangle CompanionBorder = new Rectangle(343, 1471, 108, 108);
        private static readonly Rectangle CompanionBackground = new Rectangle(229, 1357, 108, 108);

        private static readonly Rectangle CostumePlaceholder = new Rectangle(1, 1262, 108, 108);
        private static readonly Rectangle ThoughtPlaceholder = new Rectangle(115, 1376, 108, 108);
        private static readonly Rectangle WeaponPlaceholder = new Rectangle(115, 1262, 108, 108);
        private static readonly Rectangle CompanionPlaceholder = new Rectangle(863, 1597, 108, 108);
        private static readonly Rectangle MemoryPlaceholder = new Rectangle(469, 1555, 108, 108);

        private static readonly Vector2 IconPadSize = new Vector2(102, 102);
        public static readonly Vector2 ItemSlotSize = new Vector2(82, 82);
        public static readonly Vector2 IconSize = new Vector2(25, 25);
        public static readonly Vector2 RarityStarSize = new Vector2(15, 15);

        #region Embedded icons

        #region Placeholders

        public static ImageResource LoadCostumePlaceholder()
        {
            if (CostumePlaceholderResource != null)
                return CostumePlaceholderResource;

            EnsureIconsAtlas();

            var placeHolder = IconsAtlas.Clone(context => context.Crop(CostumePlaceholder));
            return CostumePlaceholderResource = LoadItemResource(placeHolder);
        }

        public static ImageResource LoadThoughtPlaceholder()
        {
            if (ThoughtPlaceholderResource != null)
                return ThoughtPlaceholderResource;

            EnsureIconsAtlas();

            var placeHolder = IconsAtlas.Clone(context => context.Crop(ThoughtPlaceholder));
            return ThoughtPlaceholderResource = LoadItemResource(placeHolder);
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

        #endregion

        #region Icons

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

        public static ImageResource LoadBonusIcon()
        {
            if (BonusIconResource != null)
                return BonusIconResource;

            EnsureIconsAtlas();

            var arrow = IconsAtlas.Clone(context => context.Crop(BonusArrow));
            var plus = IconsAtlas.Clone(context => context.Crop(BonusPlus));

            var width = arrow.Width + plus.Width / 2;
            var height = arrow.Height * 2 + plus.Height;

            var result = new Image<Bgra32>(width, height);
            result.Mutate(i => i.DrawImage(arrow, new Point(0, 0), 1).DrawImage(arrow, new Point(0, arrow.Height), 1).DrawImage(plus, new Point(width - plus.Width, arrow.Height * 2), 1));
            result.Mutate(i => i.Resize(width / 2, 0));

            return BonusIconResource = LoadResource(result);
        }

        public static ImageResource LoadAwakenDefaultIcon()
        {
            if (AwakenDefaultIconResource != null)
                return AwakenDefaultIconResource;

            EnsureIconsAtlas();

            var icon = IconsAtlas.Clone(context => context.Crop(AwakenDefaultIcon));
            return AwakenDefaultIconResource = LoadIconResource(icon);
        }

        public static ImageResource LoadAwakenFullIcon()
        {
            if (AwakenFullIconResource != null)
                return AwakenFullIconResource;

            EnsureIconsAtlas();

            var icon = IconsAtlas.Clone(context => context.Crop(AwakenFullIcon));
            return AwakenFullIconResource = LoadIconResource(icon);
        }

        #endregion

        #region Background and Borders

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

        public static ImageResource LoadDefaultBackground()
        {
            if (CompanionBackgroundResource != null)
                return CompanionBackgroundResource;

            EnsureIconsAtlas();

            var item = IconsAtlas.Clone(context => context.Crop(CompanionBackground));
            return CompanionBackgroundResource = LoadItemResource(item);
        }

        public static ImageResource LoadDefaultBorder()
        {
            if (CompanionBorderResource != null)
                return CompanionBorderResource;

            EnsureIconsAtlas();

            var item = IconsAtlas.Clone(context => context.Crop(CompanionBorder));
            return CompanionBorderResource = LoadItemResource(item);
        }

        #endregion

        #region Support

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

        private static ImageResource LoadResource(Image<Bgra32> image)
        {
            var asset = new ImageAsset(image);
            return ImageResource.FromStream(asset.AsStream());
        }

        #endregion

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

        public static ImageResource LoadThoughtItem(int thoughtId)
        {
            if (thoughtId == 0)
                return null;

            if (ThoughtItems.ContainsKey(thoughtId))
                return ThoughtItems[thoughtId];

            var asset = LoadAsset(string.Format(ThoughtIconPath_, thoughtId));
            //PadResizeItem(asset, AnchorPositionMode.Bottom);

            return ThoughtItems[thoughtId] = ImageResource.FromStream(asset.AsStream());
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

        public static ImageResource LoadConsumableItem(int categoryId, int variationId)
        {
            if (categoryId == 0 || variationId == 0)
                return null;

            if (ConsumableItems.ContainsKey((categoryId, variationId)))
                return ConsumableItems[(categoryId, variationId)];

            var asset = LoadAsset(string.Format(ConsumableItemPath_, categoryId, variationId));
            PadResizeItem(asset, AnchorPositionMode.Center);

            return ConsumableItems[(categoryId, variationId)] = ImageResource.FromStream(asset.AsStream());
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
