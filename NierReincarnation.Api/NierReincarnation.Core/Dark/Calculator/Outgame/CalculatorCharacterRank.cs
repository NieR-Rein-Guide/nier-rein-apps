using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NierReincarnation.Core.Dark.Calculator.Database;
using NierReincarnation.Core.Dark.Status;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Calculator.Outgame
{
    public static class CalculatorCharacterRank
    {
        private static readonly int InvalidAbilityDetailId = 0; // 0x0
        private static readonly int kFirstCharacterRankExp = 0; // 0x4
        private static readonly int kFirstCharacterRank = 1; // 0x8

        public static List<DataAbilityStatus> CreateCharacterRankAbilityStatusList(long userId, int characterId)
        {
            var result = new List<DataAbilityStatus>();

            var abilityGroups = GetEntityMCharacterLevelBonusAbilityGroup(userId, characterId);
            foreach (var abilityGroup in abilityGroups)
            {
                var ability = CalculatorAbility.CreateDataAbility(abilityGroup.AbilityId, abilityGroup.AbilityLevel, 15);
                result.AddRange(ability.AbilityStatusList);
            }

            return result;
        }

        public static List<DataAbility> CreateCharacterRankAbilityList(long userId, int characterId)
        {
            var range = GetEntityMCharacterLevelBonusAbilityGroup(userId, characterId);
            return range.Select(x => CalculatorAbility.CreateDataAbility(x.AbilityId, x.AbilityLevel, 15)).ToList();
        }

        private static RangeView<EntityMCharacterLevelBonusAbilityGroup> GetEntityMCharacterLevelBonusAbilityGroup(long userId, int characterId)
        {
            var character = GetEntityMCharacter(characterId);
            if (character == null)
                return RangeView<EntityMCharacterLevelBonusAbilityGroup>.Empty;

            var characterTable = DatabaseDefine.User.EntityIUserCharacterTable;
            var userCharacter = characterTable.FindByUserIdAndCharacterId((userId, characterId));
            var rank = GetCharacterRank(userCharacter);

            return CalculatorMasterData.GetEntityMCharacterLevelBonusAbilityGroups(character.CharacterLevelBonusAbilityGroupId, rank);
        }

        private static EntityMCharacter GetEntityMCharacter(int characterId)
        {
            var table = DatabaseDefine.Master.EntityMCharacterTable;
            return table.FindByCharacterId(characterId);
        }

        public static int GetCharacterRank(int characterId)
        {
            var userId = CalculatorStateUser.GetUserId();
            var element = DatabaseDefine.User.EntityIUserCharacterTable.FindByUserIdAndCharacterId((userId, characterId));

            return GetCharacterRank(element);
        }

        private static int GetCharacterRank(EntityIUserCharacter character)
        {
            return character?.Level ?? kFirstCharacterRank;
        }
    }
}
