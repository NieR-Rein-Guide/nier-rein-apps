using ImGui.Forms.Resources;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.UnityEngine;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;

namespace NierReincarnation.App.Resources
{
    internal static class NierResources
    {
        private const string IconsAtlasPath_ = "NierReincarnation.App.Resources.Images.icons_1.png";

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

        private static readonly Rectangle FireIcon = new(863, 1294, 34, 34);
        private static readonly Rectangle WaterIcon = new(626, 1126, 34, 34);
        private static readonly Rectangle WindIcon = new(804, 1094, 34, 34);
        private static readonly Rectangle LightIcon = new(901, 1301, 34, 34);
        private static readonly Rectangle DarkIcon = new(84, 1039, 34, 34);

        private static readonly Rectangle BigSwordIcon = new(787, 1266, 34, 34);
        private static readonly Rectangle SwordIcon = new(122, 1038, 34, 34);
        private static readonly Rectangle SpearIcon = new(901, 1339, 34, 34);
        private static readonly Rectangle StaffIcon = new(901, 1263, 34, 34);
        private static readonly Rectangle GunIcon = new(817, 1175, 34, 34);
        private static readonly Rectangle FistIcon = new(863, 1256, 34, 34);

        private static readonly Rectangle AwakenDefaultIcon = new(515, 1064, 32, 32);
        private static readonly Rectangle AwakenFullIcon = new(805, 1133, 32, 32);

        private static readonly Rectangle LegendStar = new(965, 1202, 19, 19);
        private static readonly Rectangle LegendBorder = new(1, 1376, 108, 108);
        private static readonly Rectangle LegendBackground = new(863, 1711, 108, 108);
        private static readonly Rectangle SrStar = new(152, 1622, 19, 19);
        private static readonly Rectangle SrBorder = new(457, 1441, 108, 108);
        private static readonly Rectangle SrBackground = new(1, 1490, 108, 108);
        private static readonly Rectangle RareStar = new(534, 1038, 19, 19);
        private static readonly Rectangle RareBorder = new(115, 1490, 108, 108);
        private static readonly Rectangle RareBackground = new(749, 1595, 108, 108);

        private static readonly Rectangle IsExIcon = new(880, 1137, 34, 34);
        private static readonly Rectangle EditIcon = new(583, 1638, 25, 25);

        private static readonly Rectangle BonusArrow = new(962, 1406, 28, 24);
        private static readonly Rectangle BonusPlus = new(951, 1083, 26, 26);

        private static readonly Rectangle CompanionBorder = new(343, 1471, 108, 108);
        private static readonly Rectangle CompanionBackground = new(229, 1357, 108, 108);

        private static readonly Rectangle CostumePlaceholder = new(1, 1262, 108, 108);
        private static readonly Rectangle ThoughtPlaceholder = new(115, 1376, 108, 108);
        private static readonly Rectangle WeaponPlaceholder = new(115, 1262, 108, 108);
        private static readonly Rectangle CompanionPlaceholder = new(863, 1597, 108, 108);
        private static readonly Rectangle MemoryPlaceholder = new(469, 1555, 108, 108);

        private static readonly Vector2 IconPadSize = new(102, 102);

        public static readonly Vector2 ItemSlotSize = new(82, 82);
        public static readonly Vector2 IconSize = new(25, 25);
        public static readonly Vector2 RarityStarSize = new(15, 15);

        #region Embedded icons

        #region Placeholders

        public static ImageResource LoadCostumePlaceholder()
        {
            if (CostumePlaceholderResource != null)
                return CostumePlaceholderResource;

            EnsureIconsAtlas();

            var placeHolder = IconsAtlas.Clone(context => context.Crop(CostumePlaceholder));
            return CostumePlaceholderResource = LoadResource(placeHolder);
        }

        public static ImageResource LoadThoughtPlaceholder()
        {
            if (ThoughtPlaceholderResource != null)
                return ThoughtPlaceholderResource;

            EnsureIconsAtlas();

            var placeHolder = IconsAtlas.Clone(context => context.Crop(ThoughtPlaceholder));
            return ThoughtPlaceholderResource = LoadResource(placeHolder);
        }

        public static ImageResource LoadWeaponPlaceholder()
        {
            if (WeaponPlaceholderResource != null)
                return WeaponPlaceholderResource;

            EnsureIconsAtlas();

            var placeHolder = IconsAtlas.Clone(context => context.Crop(WeaponPlaceholder));
            return WeaponPlaceholderResource = LoadResource(placeHolder);
        }

        public static ImageResource LoadCompanionPlaceholder()
        {
            if (CompanionPlaceholderResource != null)
                return CompanionPlaceholderResource;

            EnsureIconsAtlas();

            var placeHolder = IconsAtlas.Clone(context => context.Crop(CompanionPlaceholder));
            return CompanionPlaceholderResource = LoadResource(placeHolder);
        }

        public static ImageResource LoadMemoryPlaceholder()
        {
            if (MemoryPlaceholderResource != null)
                return MemoryPlaceholderResource;

            EnsureIconsAtlas();

            var placeHolder = IconsAtlas.Clone(context => context.Crop(MemoryPlaceholder));
            return MemoryPlaceholderResource = LoadResource(placeHolder);
        }

        #endregion Placeholders

        #region Icons

        public static ImageResource LoadAttributeIcon(QuestDisplayAttributeType attribute)
        {
            return attribute switch
            {
                QuestDisplayAttributeType.FIRE => LoadAttributeIcon(AttributeType.FIRE),
                QuestDisplayAttributeType.WATER => LoadAttributeIcon(AttributeType.WATER),
                QuestDisplayAttributeType.WIND => LoadAttributeIcon(AttributeType.WIND),
                QuestDisplayAttributeType.LIGHT => LoadAttributeIcon(AttributeType.LIGHT),
                QuestDisplayAttributeType.DARK => LoadAttributeIcon(AttributeType.DARK),
                _ => null,
            };
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
            return AttributeIcons[attribute] = LoadResource(icon);
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
            return WeaponIcons[weaponType] = LoadResource(icon);
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
            return RarityStarIcons[rarity] = LoadResource(starIcon);
        }

        public static ImageResource LoadExIcon()
        {
            if (IsEndIconResource != null)
                return IsEndIconResource;

            EnsureIconsAtlas();

            var icon = IconsAtlas.Clone(context => context.Crop(IsExIcon));
            return IsEndIconResource = LoadResource(icon);
        }

        public static ImageResource LoadEditIcon()
        {
            if (EditIconResource != null)
                return EditIconResource;

            EnsureIconsAtlas();

            var icon = IconsAtlas.Clone(context => context.Crop(EditIcon));
            return EditIconResource = LoadResource(icon);
        }

        public static ImageResource LoadBonusIcon()
        {
            if (BonusIconResource != null)
                return BonusIconResource;

            EnsureIconsAtlas();

            var arrow = IconsAtlas.Clone(context => context.Crop(BonusArrow));
            var plus = IconsAtlas.Clone(context => context.Crop(BonusPlus));

            var width = arrow.Width + (plus.Width / 2);
            var height = (arrow.Height * 2) + plus.Height;

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
            return AwakenDefaultIconResource = LoadResource(icon);
        }

        public static ImageResource LoadAwakenFullIcon()
        {
            if (AwakenFullIconResource != null)
                return AwakenFullIconResource;

            EnsureIconsAtlas();

            var icon = IconsAtlas.Clone(context => context.Crop(AwakenFullIcon));
            return AwakenFullIconResource = LoadResource(icon);
        }

        #endregion Icons

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
            return RarityBackgrounds[rarity] = LoadResource(item);
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
            return RarityBorders[rarity] = LoadResource(item);
        }

        public static ImageResource LoadDefaultBackground()
        {
            if (CompanionBackgroundResource != null)
                return CompanionBackgroundResource;

            EnsureIconsAtlas();

            var item = IconsAtlas.Clone(context => context.Crop(CompanionBackground));
            return CompanionBackgroundResource = LoadResource(item);
        }

        public static ImageResource LoadDefaultBorder()
        {
            if (CompanionBorderResource != null)
                return CompanionBorderResource;

            EnsureIconsAtlas();

            var item = IconsAtlas.Clone(context => context.Crop(CompanionBorder));
            return CompanionBorderResource = LoadResource(item);
        }

        #endregion Background and Borders

        #region Support

        private static void EnsureIconsAtlas()
        {
            if (IconsAtlas != null)
                return;

            var iconsStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(IconsAtlasPath_);

            IconsAtlas = Image.Load<Bgra32>(iconsStream);
        }

        private static ImageResource LoadResource(Image<Bgra32> image)
        {
            var asset = new ImageAsset(image);
            return ImageResource.FromStream(asset.AsStream());
        }

        #endregion Support

        #endregion Embedded icons

        #region Icon assets

        public static ImageResource LoadCostumeItem(ActorAssetId assetId)
        {
            if (assetId == null)
                return null;

            if (CostumeItems.ContainsKey(assetId.StringId))
                return CostumeItems[assetId.StringId];

            var asset = LoadAsset(string.Format(CostumeIconPath_, assetId));
            PadItem(asset, AnchorPositionMode.BottomRight);

            return CostumeItems[assetId.StringId] = ImageResource.FromStream(asset.AsStream());
        }

        public static ImageResource LoadWeaponItem(ActorAssetId assetId)
        {
            if (assetId == null)
                return null;

            if (WeaponItems.ContainsKey(assetId.StringId))
                return WeaponItems[assetId.StringId];

            var asset = LoadAsset(string.Format(WeaponIconPath_, assetId));
            PadItem(asset, AnchorPositionMode.Center);

            return WeaponItems[assetId.StringId] = ImageResource.FromStream(asset.AsStream());
        }

        public static ImageResource LoadCompanionItem(ActorAssetId assetId)
        {
            if (assetId == null)
                return null;

            if (CompanionItems.ContainsKey(assetId.StringId))
                return CompanionItems[assetId.StringId];

            var asset = LoadAsset(string.Format(CompanionIconPath_, assetId));
            PadItem(asset, AnchorPositionMode.Bottom);

            return CompanionItems[assetId.StringId] = ImageResource.FromStream(asset.AsStream());
        }

        public static ImageResource LoadThoughtItem(int thoughtId)
        {
            if (thoughtId == 0)
                return null;

            if (ThoughtItems.ContainsKey(thoughtId))
                return ThoughtItems[thoughtId];

            var asset = LoadAsset(string.Format(ThoughtIconPath_, thoughtId));
            //PadItem(asset, AnchorPositionMode.Bottom);

            return ThoughtItems[thoughtId] = ImageResource.FromStream(asset.AsStream());
        }

        public static ImageResource LoadMemoryItem(int groupAssetId)
        {
            if (groupAssetId == 0)
                return null;

            if (MemoryItems.ContainsKey(groupAssetId))
                return MemoryItems[groupAssetId];

            var asset = LoadAsset(string.Format(MemoryIconPath_, groupAssetId));
            PadItem(asset, AnchorPositionMode.Center);

            return MemoryItems[groupAssetId] = ImageResource.FromStream(asset.AsStream());
        }

        public static ImageResource LoadConsumableItem(int categoryId, int variationId)
        {
            if (categoryId == 0 || variationId == 0)
                return null;

            if (ConsumableItems.ContainsKey((categoryId, variationId)))
                return ConsumableItems[(categoryId, variationId)];

            var asset = LoadAsset(string.Format(ConsumableItemPath_, categoryId, variationId));
            PadItem(asset, AnchorPositionMode.Center);

            return ConsumableItems[(categoryId, variationId)] = ImageResource.FromStream(asset.AsStream());
        }

        private static ImageAsset LoadAsset(string path)
        {
            return Core.UnityEngine.Resources.LoadImage(path);
        }

        private static void PadItem(ImageAsset asset, AnchorPositionMode position)
        {
            // Resize to padding
            var paddingOptions = new ResizeOptions
            {
                Size = new Size(Math.Max((int)IconPadSize.X, asset.Image.Width), Math.Max((int)IconPadSize.Y, asset.Image.Height)),
                Mode = ResizeMode.BoxPad,
                Sampler = KnownResamplers.NearestNeighbor,
                Position = position
            };

            asset.Image.Mutate(i => i.Resize(paddingOptions));
        }

        #endregion Icon assets
    }
}
