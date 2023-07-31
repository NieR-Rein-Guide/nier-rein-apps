using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator.Database;
using NierReincarnation.Core.Dark.Component.WorldMap;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.HeadUpDisplay.Calculator;
using NierReincarnation.Core.Dark.View.UserInterface;
using NierReincarnation.Core.UnityEngine;

namespace NierReincarnation.Datamine.Extension;

public static class NierReinExtensions
{
    #region Date Extensions

    public static string ToFormattedDateStr(this EntityMDokan entityMDokan) => DateTimeExtensions.ToFormattedDateStr(entityMDokan.StartDatetime, entityMDokan.EndDatetime);

    public static string ToFormattedDateStr(this EntityMEnhanceCampaign entityMEnhanceCampaign) => DateTimeExtensions.ToFormattedDateStr(entityMEnhanceCampaign.StartDatetime, entityMEnhanceCampaign.EndDatetime);

    public static string ToFormattedDateStr(this EventQuestChapterData eventQuestChapterData) => DateTimeExtensions.ToFormattedDateStr(eventQuestChapterData.StartDatetime, eventQuestChapterData.EndDatetime);

    public static string ToFormattedDateStr(this EntityMQuestCampaign entityMQuestCampaign) => DateTimeExtensions.ToFormattedDateStr(entityMQuestCampaign.StartDatetime, entityMQuestCampaign.EndDatetime);

    public static string ToFormattedDateStr(this EntityMShop entityMShop) => DateTimeExtensions.ToFormattedDateStr(entityMShop.StartDatetime, entityMShop.EndDatetime);

    public static string ToFormattedDateStr(this EntityMShopItemCellTerm entityMShopItemCellTerm) => DateTimeExtensions.ToFormattedDateStr(entityMShopItemCellTerm.StartDatetime, entityMShopItemCellTerm.EndDatetime);

    public static string ToFormattedDateStr(this WorldMapGimmickOutGame worldMapGimmickOutGame) => DateTimeExtensions.ToFormattedDateStr(worldMapGimmickOutGame.StartDatetime, worldMapGimmickOutGame.EndDatetime);

    public static string ToFormattedDateStr(this EntityMEventQuestLabyrinthSeason entityMEventQuestLabyrinthSeason) => DateTimeExtensions.ToFormattedDateStr(entityMEventQuestLabyrinthSeason.StartDatetime, entityMEventQuestLabyrinthSeason.EndDatetime);

    public static string ToFormattedDateStr(this EntityMMissionPass entityMMissionPass) => DateTimeExtensions.ToFormattedDateStr(entityMMissionPass.StartDatetime, entityMMissionPass.EndDatetime);

    public static string ToFormattedDateStr(this EntityMPremiumItem entityMPremiumItem) => DateTimeExtensions.ToFormattedDateStr(entityMPremiumItem.StartDatetime, entityMPremiumItem.EndDatetime);

    #endregion Date Extensions

    #region String Extensions

    public static string ToPath(this Language language) => language switch
    {
        Language.Japanese => "ja",
        Language.Malaysia => "my",
        _ => "en"
    };

    public static string ToFormattedStr(this WeaponType weaponType)
    {
        return weaponType switch
        {
            WeaponType.SWORD => "1H Sword",
            WeaponType.BIG_SWORD => "2H Sword",
            WeaponType.STAFF => "Staff",
            WeaponType.GUN => "Gun",
            WeaponType.FIST => "Fist",
            WeaponType.SPEAR => "Spear",
            _ => "Unknown"
        };
    }

    public static string ToFormattedStr(this AttributeType attributeType)
    {
        return attributeType switch
        {
            AttributeType.FIRE => "Fire",
            AttributeType.WATER => "Water",
            AttributeType.WIND => "Wind",
            AttributeType.LIGHT => "Light",
            AttributeType.DARK => "Dark",
            _ => "Unknown"
        };
    }

    public static string ToFormattedStr(this RarityType rarityType, bool isWeapon)
    {
        return rarityType switch
        {
            RarityType.LEGEND => "★★★★",
            RarityType.SS_RARE => isWeapon ? "★★★" : "★★★★",
            RarityType.S_RARE => isWeapon ? "★★" : "★★★",
            RarityType.RARE => isWeapon ? "★" : "★★",
            _ => "Unknown"
        };
    }

    public static string ToFormattedStr(this DifficultyType difficultyType)
    {
        return difficultyType switch
        {
            DifficultyType.NORMAL => "Normal",
            DifficultyType.HARD => "Hard",
            DifficultyType.VERY_HARD => "Very Hard",
            DifficultyType.EX_HARD => "EX",
            _ => "Unknown"
        };
    }

    public static string ToFormattedStr(this QuestDisplayAttributeType questDisplayAttributeType)
    {
        return questDisplayAttributeType switch
        {
            QuestDisplayAttributeType.FIRE => "Fire",
            QuestDisplayAttributeType.WATER => "Water",
            QuestDisplayAttributeType.WIND => "Wind",
            QuestDisplayAttributeType.DARK => "Dark",
            QuestDisplayAttributeType.LIGHT => "Light",
            QuestDisplayAttributeType.ALL => "All",
            QuestDisplayAttributeType.VARIOUS => "Various",
            QuestDisplayAttributeType.NOTHING => "Nothing",
            _ => "Unknown"
        };
    }

    public static string ToFormattedStr(this GimmickType gimmickType)
    {
        return gimmickType switch
        {
            GimmickType.CAGE_INTERVAL_DROP_ITEM => "Lost Items",
            GimmickType.CAGE_MEMORY => "Lost Archives",
            GimmickType.CAGE_TREASURE_HUNT => "Fickle Black Birds",
            GimmickType.MAP_ONLY_CAGE_INTERVAL_DROP_ITEM => "Mama Room Items",
            GimmickType.MAP_ONLY_CAGE_TREASURE_HUNT => "Story Black Birds",
            GimmickType.MAP_ONLY_HIDE_OBELISK => "Stray Scarecrows",
            GimmickType.REPORT => "Hidden Stories",
            _ => gimmickType.ToString(),
        };
    }

    public static string ToFormattedStr(this QuestType QuestType)
    {
        return QuestType switch
        {
            QuestType.MAIN_QUEST => "Story",
            QuestType.EVENT_QUEST => "Event",
            QuestType.EXTRA_QUEST => "Extra",
            QuestType.BIG_HUNT_QUEST => "Subjugation",
            _ => "Unknown",
        };
    }

    public static string ToFormattedStr(this EventQuestType eventQuestType)
    {
        return eventQuestType switch
        {
            EventQuestType.SPECIAL => "Special",
            EventQuestType.MARATHON => "Record",
            EventQuestType.TOWER => "Tower",
            EventQuestType.GUERRILLA => "Guerrilla",
            EventQuestType.DUNGEON => "Dungeon",
            EventQuestType.CHARACTER => "Character",
            EventQuestType.HUNT => "Variation",
            EventQuestType.LIMIT_CONTENT => "Recollections of Dusk",
            EventQuestType.DAY_OF_THE_WEEK => "Daily",
            EventQuestType.END_CONTENTS => "Dark Memory",
            _ => "Unknown",
        };
    }

    public static string ToFormattedStr(this ShopType eventQuestType)
    {
        return eventQuestType switch
        {
            ShopType.BATTLE_POINT_RECOVERY_SHOP => "Arena Shop",
            ShopType.EXCHANGE_SHOP => "Exchange",
            ShopType.GEM_SHOP => "Gem Shop",
            ShopType.GOLD_SHOP => "Gold Shop",
            ShopType.ITEM_SHOP => "Item Shop",
            ShopType.MISSION_SHOP => "Mission Shop",
            ShopType.PACK_SHOP => "Pack Shop",
            ShopType.PREMIUM_PACK_SHOP => "Premium Pack Shop",
            ShopType.STAMINA_RECOVERY_SHOP => "Stamina Recovery Shop",
            ShopType.MOM_SHOP => "Mama Shop",
            ShopType.PREMIUM_MISSION_PASS_SHOP => "Monthly Mission Pass",
            _ => "Unknown",
        };
    }

    public static string ToFormattedStr(this QuestCampaignTargetType questCampaignTargetType, int value)
    {
        return questCampaignTargetType switch
        {
            QuestCampaignTargetType.WHOLE_QUEST => "All",
            QuestCampaignTargetType.QUEST_TYPE => ((QuestType)value).ToFormattedStr(),
            QuestCampaignTargetType.EVENT_QUEST_TYPE => ((EventQuestType)value).ToFormattedStr(),
            QuestCampaignTargetType.MAIN_QUEST_CHAPTER_ID => "Main Quests",
            QuestCampaignTargetType.MAIN_QUEST_QUEST_ID => "Main Quest",
            QuestCampaignTargetType.SUB_QUEST_CHAPTER_ID => "Sub Quests",
            QuestCampaignTargetType.SUB_QUEST_QUEST_ID => "Sub Quest",
            _ => "Unknown",
        };
    }

    public static string ToFormattedStr(this EnhanceCampaignTargetType enhanceCampaignTargetType, int value)
    {
        return enhanceCampaignTargetType switch
        {
            EnhanceCampaignTargetType.COSTUME_ALL => "Costumes",
            EnhanceCampaignTargetType.WEAPON_ALL => "Weapons",
            EnhanceCampaignTargetType.PARTS_ALL => "Memoirs",
            EnhanceCampaignTargetType.COSTUME_CHARACTER_ID => "Character",
            EnhanceCampaignTargetType.COSTUME_SKILLFUL_WEAPON_TYPE_ID => $"{CalculatorWeaponType.GetWeaponTypeText(value)} Costumes",
            EnhanceCampaignTargetType.COSTUME_ID => "Costume",
            EnhanceCampaignTargetType.WEAPON_TYPE_ID => $"{CalculatorWeaponType.GetWeaponTypeText(value)} Weapons",
            EnhanceCampaignTargetType.WEAPON_ATTRIBUTE_TYPE_ID => $"{CalculatorAttribute.GetAttributeText(value)} Weapons",
            EnhanceCampaignTargetType.WEAPON_ID => "Weapon",
            EnhanceCampaignTargetType.PARTS_SERIES_ID => "Memoir Series",
            EnhanceCampaignTargetType.PARTS_ID => "Memoir",
            _ => "Unknown",
        };
    }

    public static string ToFormattedStr(this TargetUserStatusType targetUserStatusType)
    {
        return targetUserStatusType switch
        {
            TargetUserStatusType.ALL => "All",
            TargetUserStatusType.COMEBACK => "Returning",
            TargetUserStatusType.BEGINNER => "Beginner",
            _ => "Unknown",
        };
    }

    public static string ToFormattedStr(this FieldEffectApplyScopeType fieldEffectApplyScopeType)
    {
        return fieldEffectApplyScopeType switch
        {
            FieldEffectApplyScopeType.ALL_ACTOR => "All",
            FieldEffectApplyScopeType.PLAYER_ACTOR => "Self",
            _ => "Unknown",
        };
    }

    public static string ToFormattedStr(this MaintenanceBlockFunctionType blockFunctionType)
    {
        return blockFunctionType switch
        {
            MaintenanceBlockFunctionType.NONE => "None",
            MaintenanceBlockFunctionType.CHARACTER_ENHANCE => "Character Enhancement",
            MaintenanceBlockFunctionType.WEAPON_ENHANCE => "Weapon Enhancement",
            MaintenanceBlockFunctionType.COMPANION_ENHANCE => "Companion Enhancement",
            MaintenanceBlockFunctionType.PARTS_ENHANCE => "Memoir Enhancement",
            MaintenanceBlockFunctionType.LIST_SELL => "List/Sell",
            MaintenanceBlockFunctionType.DECK => "Loadout",
            MaintenanceBlockFunctionType.SUB_QUEST_ALL => "Sub-quests",
            MaintenanceBlockFunctionType.PVP => "Arena",
            MaintenanceBlockFunctionType.EXPLORE => "Exploration",
            MaintenanceBlockFunctionType.GACHA => "Gacha",
            MaintenanceBlockFunctionType.SHOP => "Shop",
            MaintenanceBlockFunctionType.GIFT => "Gift",
            MaintenanceBlockFunctionType.MISSION => "Mission",
            MaintenanceBlockFunctionType.FRIEND => "Friends",
            MaintenanceBlockFunctionType.MENU => "Menu",
            MaintenanceBlockFunctionType.MAMA_BANNER => "Mama Banner",
            MaintenanceBlockFunctionType.BRIDGE => "SQX Bridge",
            MaintenanceBlockFunctionType.SUB_QUEST_CHAPTER_ID => "Quest Category",
            MaintenanceBlockFunctionType.SUB_QUEST_QUEST_ID => "Quest",
            MaintenanceBlockFunctionType.SUB_QUEST_EVENT_QUEST_TYPE => "Quest Type",
            MaintenanceBlockFunctionType.REWARD_GACHA => "Gacha Pity",
            MaintenanceBlockFunctionType.BIG_HUNT => "Subjugation",
            MaintenanceBlockFunctionType.CHARACTER_BOARD => "Mythic Slabs",
            MaintenanceBlockFunctionType.WORLD_MAP => "World Map",
            MaintenanceBlockFunctionType.LIMIT_CONTENT => "Recollections of Dusk",
            MaintenanceBlockFunctionType.LIMIT_CONTENT_CHARACTER => "Recollections of Dusk Character",
            MaintenanceBlockFunctionType.CHARACTER_VIEWER => "3D Viewer",
            MaintenanceBlockFunctionType.SUB_QUEST_EVENT_QUEST_DAILY_GROUP => "Daily Quests",
            _ => "Unknown",
        };
    }

    public static string HtmlToDiscordText(this string text)
    {
        return text.Replace("<i>", "*")
            .Replace("</i>", "*")
            .Replace("<b>", "**")
            .Replace("</b>", "**")
            .Replace("<size=40>", "**")
            .Replace("</size>", "**")
            .Replace("<align=\"center\">", string.Empty)
            .Replace("<align=\"right\">", string.Empty)
            .Replace("</align>", string.Empty)
            .Replace("<cspace=-0.16em>", string.Empty)
            .Replace("</cspace>", string.Empty)
            .Replace("<br>", "\\n");
    }

    #endregion String Extensions

    #region Data Extensions

    public static string GetCharacterSymbolName(int characterId)
    {
        EntityMCharacterDisplaySwitch entityMCharacterDisplaySwitch = CalculatorMasterData.GetEntityMCharacterDisplaySwitch(characterId);
        if (entityMCharacterDisplaySwitch != null)
        {
            return GetSymbolName(entityMCharacterDisplaySwitch.NameCharacterTextId);
        }

        EntityMCharacter entityMCharacter = CalculatorMasterData.GetEntityMCharacter(characterId);
        if (entityMCharacter == null)
        {
            return null;
        }

        return GetSymbolName(entityMCharacter.NameCharacterTextId);
    }

    private static string GetSymbolName(int nameTextId) => $"character.symbol.{nameTextId}".Localize();

    #endregion
}
