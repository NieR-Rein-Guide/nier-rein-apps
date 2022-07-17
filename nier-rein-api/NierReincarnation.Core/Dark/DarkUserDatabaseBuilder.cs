using System.Collections.Generic;
using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Tables;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    class DarkUserDatabaseBuilder : DatabaseBuilderBase
    {
        public DarkUserDatabaseBuilder() : base(null)
        {
        }

        public DarkUserDatabaseBuilder(IFormatterResolver resolver) : base(resolver)
        {
        }

        // RVA: 0x2014CD4 Offset: 0x2014CD4 VA: 0x2014CD4
        public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUser> dataSource)
        {
            AppendCore(dataSource, user => user.UserId, Comparer<long>.Default);
            return this;
        }

        public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserBigHuntMaxScore> dataSource)
        {
            AppendCore(dataSource, user => (user.UserId, user.BigHuntBossId), Comparer<(long, int)>.Default);
            return this;
        }

        public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserBigHuntProgressStatus> dataSource)
        {
            AppendCore(dataSource, user => user.UserId, Comparer<long>.Default);
            return this;
        }

        public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserBigHuntStatus> dataSource)
        {
            AppendCore(dataSource, user => (user.UserId, user.BigHuntBossQuestId), Comparer<(long, int)>.Default);
            return this;
        }

        // RVA: 0x20154B4 Offset: 0x20154B4 VA: 0x20154B4
        public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserCharacter> dataSource)
        {
            AppendCore(dataSource, user => (user.UserId, user.CharacterId), Comparer<(long, int)>.Default);
            return this;
        }

        public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserCharacterBoardAbility> dataSource)
        {
            AppendCore(dataSource, user => (user.UserId, user.CharacterId, user.AbilityId), Comparer<(long, int, int)>.Default);
            return this;
        }

        // RVA: 0x2015934 Offset: 0x2015934 VA: 0x2015934
        public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserCharacterBoardStatusUp> dataSource)
        {
            AppendCore(dataSource, user => (user.UserId, user.CharacterId, user.StatusCalculationType), Comparer<(long, int, StatusCalculationType)>.Default);
            return this;
        }

        // RVA: 0x2015C94 Offset: 0x2015C94 VA: 0x2015C94
        public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserCompanion> dataSource)
        {
            AppendCore(dataSource, user => (user.UserId, user.UserCompanionUuid), Comparer<(long, string)>.Default);
            return this;
        }

        // RVA: 0x2015A54 Offset: 0x2015A54 VA: 0x2015A54
        public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserCharacterCostumeLevelBonus> dataSource)
        {
            AppendCore(dataSource, user => (user.UserId, user.CharacterId, user.StatusCalculationType), Comparer<(long, int, StatusCalculationType)>.Default);
            return this;
        }

        public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserConsumableItem> dataSource)
        {
            AppendCore(dataSource, user => (user.UserId, user.ConsumableItemId), Comparer<(long, int)>.Default);
            return this;
        }

        // RVA: 0x2015FF4 Offset: 0x2015FF4 VA: 0x2015FF4
        public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserCostume> dataSource)
        {
            AppendCore(dataSource, user => (user.UserId, user.UserCostumeUuid), Comparer<(long, string)>.Default);
            return this;
        }

        public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserCostumeActiveSkill> dataSource)
        {
            AppendCore(dataSource, user => (user.UserId, user.UserCostumeUuid), Comparer<(long, string)>.Default);
            return this;
        }

        // RVA: 0x2016354 Offset: 0x2016354 VA: 0x2016354
        public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserDeck> dataSource)
        {
            AppendCore(dataSource, user => (user.UserId, user.DeckType, user.UserDeckNumber), Comparer<(long, DeckType, int)>.Default);
            return this;
        }

        // RVA: 0x2016474 Offset: 0x2016474 VA: 0x2016474
        public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserDeckCharacter> dataSource)
        {
            AppendCore(dataSource, user => (user.UserId, user.UserDeckCharacterUuid), Comparer<(long, string)>.Default);
            return this;
        }

        public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserDeckCharacterDressupCostume> dataSource)
        {
            AppendCore(dataSource, user => (user.UserId, user.UserDeckCharacterUuid), Comparer<(long, string)>.Default);
            return this;
        }

        // RVA: 0x2016594 Offset: 0x2016594 VA: 0x2016594
        public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserDeckPartsGroup> dataSource)
        {
            AppendCore(dataSource, user => (user.UserId, user.UserDeckCharacterUuid, user.UserPartsUuid), Comparer<(long, string, string)>.Default);
            return this;
        }

        // RVA: 0x20166B4 Offset: 0x20166B4 VA: 0x20166B4
        public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserDeckSubWeaponGroup> dataSource)
        {
            AppendCore(dataSource, user => (user.UserId, user.UserDeckCharacterUuid, user.UserWeaponUuid), Comparer<(long, string, string)>.Default);
            return this;
        }

        public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserDeckTypeNote> dataSource)
        {
            AppendCore(dataSource, user => (user.UserId, user.DeckType), Comparer<(long, DeckType)>.Default);
            return this;
        }

        public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserEventQuestProgressStatus> dataSource)
        {
            AppendCore(dataSource, user => user.UserId, Comparer<long>.Default);
            return this;
        }

        public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserExtraQuestProgressStatus> dataSource)
        {
            AppendCore(dataSource, user => user.UserId, Comparer<long>.Default);
            return this;
        }

        public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserGem> dataSource)
        {
            AppendCore(dataSource, user => user.UserId, Comparer<long>.Default);
            return this;
        }

        public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserMainQuestProgressStatus> dataSource)
        {
            AppendCore(dataSource, user => user.UserId, Comparer<long>.Default);
            return this;
        }

        public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserLimitedOpen> dataSource)
        {
            AppendCore(dataSource, user => (user.UserId, user.LimitedOpenTargetType, user.TargetId), Comparer<(long, LimitedOpenTargetType, int)>.Default);
            return this;
        }

        public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserMaterial> dataSource)
        {
            AppendCore(dataSource, user => (user.UserId, user.MaterialId), Comparer<(long, int)>.Default);
            return this;
        }

        // RVA: 0x20166B4 Offset: 0x20166B4 VA: 0x20166B4
        public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserParts> dataSource)
        {
            AppendCore(dataSource, user => (user.UserId, user.UserPartsUuid), Comparer<(long, string)>.Default);
            return this;
        }

        public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserPartsStatusSub> dataSource)
        {
            AppendCore(dataSource, user => (user.UserId, user.UserPartsUuid, user.StatusIndex), Comparer<(long, string, int)>.Default);
            return this;
        }

        public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserProfile> dataSource)
        {
            AppendCore(dataSource, user => user.UserId, Comparer<long>.Default);
            return this;
        }

        public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserQuest> dataSource)
        {
            AppendCore(dataSource, user => (user.UserId, user.QuestId), Comparer<(long, int)>.Default);
            return this;
        }

        public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserQuestMission> dataSource)
        {
            AppendCore(dataSource, user => (user.UserId, user.QuestId, user.QuestMissionId), Comparer<(long, int, int)>.Default);
            return this;
        }

        public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserShopItem> dataSource)
        {
            AppendCore(dataSource, user => (user.UserId, user.ShopItemId), Comparer<(long, int)>.Default);
            return this;
        }

        public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserStatus> dataSource)
        {
            AppendCore(dataSource, user => user.UserId, Comparer<long>.Default);
            return this;
        }

        public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserThought> dataSource)
        {
            AppendCore(dataSource, user => (user.UserId, user.UserThoughtUuid), Comparer<(long, string)>.Default);
            return this;
        }

        // RVA: 0x2019EF4 Offset: 0x2019EF4 VA: 0x2019EF4
        public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserWeapon> dataSource)
        {
            AppendCore(dataSource, user => (user.UserId, user.UserWeaponUuid), Comparer<(long, string)>.Default);
            return this;
        }

        // RVA: 0x201A014 Offset: 0x201A014 VA: 0x201A014
        public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserWeaponAbility> dataSource)
        {
            AppendCore(dataSource, user => (user.UserId, user.UserWeaponUuid, user.SlotNumber), Comparer<(long, string, int)>.Default);
            return this;
        }

        public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserWeaponNote> dataSource)
        {
            AppendCore(dataSource, user => (user.UserId, user.WeaponId), Comparer<(long, int)>.Default);
            return this;
        }

        public DarkUserDatabaseBuilder Append(IEnumerable<EntityIUserWeaponSkill> dataSource)
        {
            AppendCore(dataSource, user => (user.UserId, user.UserWeaponUuid, user.SlotNumber), Comparer<(long, string, int)>.Default);
            return this;
        }
    }
}
