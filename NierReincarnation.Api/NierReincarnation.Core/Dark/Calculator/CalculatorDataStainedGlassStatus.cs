using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Status;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Calculator
{
    public static class CalculatorDataStainedGlassStatus
    {
        public static bool CreateStainedGlassStatusList(long userId, int characterId, WeaponType skillfulWeaponType, List<DataStainedGlassStatus> stainedGlassStatusList)
        {
            var result = false;
            StatusValue statusValue = new();
            var importantItems = DatabaseDefine.Master.EntityMImportantItemTable.FindByImportantItemType(5);

            foreach (var importantItem in importantItems)
            {
                if (DatabaseDefine.User.EntityIUserImportantItemTable.TryFindByUserIdAndImportantItemId((userId, importantItem.ImportantItemId), out var userImportantItem))
                {
                    var stainedGlass = DatabaseDefine.Master.EntityMStainedGlassTable.FindByStainedGlassId(importantItem.ExternalReferenceId);

                    if (IsCharacterStatusUpTarget(stainedGlass.StainedGlassStatusUpTargetGroupId, characterId, skillfulWeaponType))
                    {
                        CollectStatusValueFromStainedGlassStatusUpGroup(ref statusValue, stainedGlass.StainedGlassStatusUpGroupId);
                        result = true;
                    }
                }
            }

            if (result)
            {
                stainedGlassStatusList.Add(CreateDataStainedGlassStatus(statusValue.Agility, statusValue.Attack, statusValue.CriticalAttack,
                    statusValue.CriticalRatio, statusValue.EvasionRatio, statusValue.Hp, statusValue.Vitality, StatusCalculationType.ADD));
            }
            return result;
        }

        private static DataStainedGlassStatus CreateDataStainedGlassStatus(ref StatusValue statusValue, StatusCalculationType statusCalculationType)
        {
            return CreateDataStainedGlassStatus(statusValue.Agility, statusValue.Attack, statusValue.CriticalAttack, statusValue.CriticalRatio, 0, statusValue.Hp, statusValue.Vitality, statusCalculationType);
        }

        public static DataStainedGlassStatus CreateDataStainedGlassStatus(int agility, int attack, int criticalAttack, int criticalRatio,
            int evasionRatio, int hp, int vitality, StatusCalculationType statusCalculationType)
        {
            return new DataStainedGlassStatus
            {
                StatusCalculationType = statusCalculationType,
                StatusChangeValue = new StatusValue(agility, attack, criticalAttack, criticalRatio, evasionRatio, hp, vitality)
            };
        }

        private static bool IsCharacterStatusUpTarget(int stainedGlassStatusUpTargetGroupId, int characterId, WeaponType skillfulWeaponType)
        {
            foreach (var stainedGlassStatusUpTargetGroup in DatabaseDefine.Master.EntityMStainedGlassStatusUpTargetGroupTable.FindByStainedGlassStatusUpTargetGroupId(stainedGlassStatusUpTargetGroupId))
            {
                if (stainedGlassStatusUpTargetGroup.StatusUpTargetType == StainedGlassStatusUpTargetType.SKILLFUL_WEAPON &&
                    (WeaponType)stainedGlassStatusUpTargetGroup.TargetValue == skillfulWeaponType)
                {
                    return true;
                }
                else if (stainedGlassStatusUpTargetGroup.StatusUpTargetType == StainedGlassStatusUpTargetType.CHARACTER &&
                    stainedGlassStatusUpTargetGroup.TargetValue == characterId)
                {
                    return true;
                }
            }

            return false;
        }

        private static void CollectStatusValueFromStainedGlassStatusUpGroup(ref StatusValue statusValue, int stainedGlassStatusUpGroupId)
        {
            foreach (var stainedGlassStatusUpGroup in DatabaseDefine.Master.EntityMStainedGlassStatusUpGroupTable.FindByStainedGlassStatusUpGroupId(stainedGlassStatusUpGroupId))
            {
                if (stainedGlassStatusUpGroup.StatusCalculationType == StatusCalculationType.ADD)
                {
                    AddStainedGlassStatusValue(ref statusValue, stainedGlassStatusUpGroup.EffectValue, stainedGlassStatusUpGroup.StatusKindType);
                }
            }
        }

        private static void AddStainedGlassStatusValue(ref StatusValue statusValue, int effectValue, StatusKindType statusKindType)
        {
            switch (statusKindType)
            {
                case StatusKindType.AGILITY:
                    statusValue.Agility += effectValue;
                    break;

                case StatusKindType.ATTACK:
                    statusValue.Attack += effectValue;
                    break;

                case StatusKindType.CRITICAL_ATTACK:
                    statusValue.CriticalAttack += effectValue;
                    break;

                case StatusKindType.CRITICAL_RATIO:
                    statusValue.CriticalRatio += effectValue;
                    break;

                case StatusKindType.HP:
                    statusValue.Hp += effectValue;
                    break;

                case StatusKindType.VITALITY:
                    statusValue.Vitality += effectValue;
                    break;
            }
        }
    }
}
