using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Networking;
using NierReincarnation.Core.Dark.Status;
using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Calculator.Outgame
{
    public static class CalculatorAwaken
    {
        public static readonly int kDefaultAwakenRank = 0; // 0x0
        public static readonly int kInvalidCostumeAwakenEffectGroupId = 0; // 0x4
        public static readonly int kInvalidCostumeAwakenStepMaterialGroupId = 0; // 0x8
        public static readonly int kInvalidCostumeAwakenPriceGroupId = 0; // 0xC
        public static readonly int kStatusDataListCapacity = 2; // 0x10

        public static DataAbility[] CreateCostumeAwakenAbilities(int costumeAwakenEffectGroupId, int awakenCount, bool withoutAwakenAbilityNotMatchAwakenCount = false)
        {
            List<DataAbility> dataAbilities = new();
            var costumeAwakenEffectGroups = DatabaseDefine.Master.EntityMCostumeAwakenEffectGroupTable
                .FindByCostumeAwakenEffectGroupIdAndCostumeAwakenEffectType((costumeAwakenEffectGroupId, CostumeAwakenEffectType.ABILITY));

            if (costumeAwakenEffectGroups.Count == 0) return Array.Empty<DataAbility>();

            foreach (var costumeAwakenEffectGroup in costumeAwakenEffectGroups)
            {
                if (withoutAwakenAbilityNotMatchAwakenCount || costumeAwakenEffectGroup.AwakenStep == awakenCount)
                {
                    var awakenAbility = CreateAwakenAbility(costumeAwakenEffectGroup, awakenCount);
                    awakenAbility.SlotNumber = costumeAwakenEffectGroup.AwakenStep;
                    dataAbilities.Add(awakenAbility);
                }
            }

            return dataAbilities.ToArray();
        }

        private static DataAbility CreateAwakenAbility(EntityMCostumeAwakenEffectGroup entityAwakenEffectGroup, int awakenCount)
        {
            var costumeAwakenAbility = DatabaseDefine.Master.EntityMCostumeAwakenAbilityTable.FindByCostumeAwakenAbilityId(entityAwakenEffectGroup.CostumeAwakenEffectId);

            DataAbility awakenAbility = CalculatorAbility.CreateDataAbility(costumeAwakenAbility.AbilityId, costumeAwakenAbility.AbilityLevel, costumeAwakenAbility.AbilityLevel);
            awakenAbility.IsLocked = entityAwakenEffectGroup.AwakenStep > awakenCount;
            awakenAbility.LockTextKey = GetAwakenAbilityLockTextKey(entityAwakenEffectGroup.AwakenStep);

            return awakenAbility;
        }

        private static string GetAwakenAbilityLockTextKey(int awakenStep)
        {
            return string.Format(View.UserInterface.Text.UserInterfaceTextKey.Skill.kLockAwaken, awakenStep);
        }

        //public static List<DataCostumeAwakenMaterial> CreateCostumeAwakenMaterials(int costumeAwakenStepMaterialGroupId, int awakenStep)
        //{
        //    throw new NotImplementedException();
        //}

        public static bool TryGetEntityAwakenMaterialGroups(int costumeAwakenStepMaterialGroupId, int awakenStep, out RangeView<EntityMCostumeAwakenMaterialGroup> entityAwakenMaterialGroups)
        {
            entityAwakenMaterialGroups = new RangeView<EntityMCostumeAwakenMaterialGroup>();
            var costumeAwakenStepMaterialGroups = DatabaseDefine.Master.EntityMCostumeAwakenStepMaterialGroupTable
                .FindRangeByCostumeAwakenStepMaterialGroupIdAndAwakenStepLowerLimit((costumeAwakenStepMaterialGroupId, int.MinValue), (costumeAwakenStepMaterialGroupId, int.MaxValue), false);

            foreach (var costumeAwakenStepMaterialGroup in costumeAwakenStepMaterialGroups)
            {
                if (costumeAwakenStepMaterialGroup.AwakenStepLowerLimit <= awakenStep)
                {
                    entityAwakenMaterialGroups = DatabaseDefine.Master.EntityMCostumeAwakenMaterialGroupTable
                        .FindRangeByCostumeAwakenMaterialGroupIdAndMaterialId((costumeAwakenStepMaterialGroup.CostumeAwakenMaterialGroupId, int.MinValue),
                        (costumeAwakenStepMaterialGroup.CostumeAwakenMaterialGroupId, int.MaxValue));

                    return true;
                }
            }

            return false;
        }

        public static int GetNextAwakenStep(int awakenStep) => awakenStep++;

        public static int GetPrevAwakenStep(int awakenStep) => awakenStep--;

        public static bool IsMaxAwakenCostume(DataOutgameCostume costume) => costume.AwakenCount > Config.GetCostumeAwakenAvailableCount();

        public static CostumeAwakenEffectType GetCostumeAwakenEffectType(int costumeAwakenEffectGroupId, int awakenStep)
        {
            var costumeAwakenEffectGroups = DatabaseDefine.Master.EntityMCostumeAwakenEffectGroupTable.FindRangeByCostumeAwakenEffectGroupIdAndAwakenStepAndCostumeAwakenEffectType(
                (costumeAwakenEffectGroupId, int.MinValue, CostumeAwakenEffectType.UNKNOWN),
                (costumeAwakenEffectGroupId, int.MaxValue, CostumeAwakenEffectType.ITEM_ACQUIRE));

            foreach (var costumeAwakenEffectGroup in costumeAwakenEffectGroups)
            {
                if (costumeAwakenEffectGroup.CostumeAwakenEffectGroupId == costumeAwakenEffectGroupId && costumeAwakenEffectGroup.AwakenStep == awakenStep)
                {
                    return costumeAwakenEffectGroup.CostumeAwakenEffectType;
                }
            }

            return CostumeAwakenEffectType.UNKNOWN;
        }

        public static void CreateCostumeAwakenStatusList(int costumeAwakenEffectGroupId, int awakenStep,
            List<DataCostumeAwakenStatus> costumeAwakenStatusList, bool withoutAwakenStatusNotMatchAwakenCount = false)
        {
            var costumeAwakenEffectGroups = DatabaseDefine.Master.EntityMCostumeAwakenEffectGroupTable
                .FindByCostumeAwakenEffectGroupIdAndCostumeAwakenEffectType((costumeAwakenEffectGroupId, CostumeAwakenEffectType.STATUS_UP));

            if (costumeAwakenEffectGroups.Count == 0)
            {
                costumeAwakenStatusList.Add(new DataCostumeAwakenStatus() { StatusChangeValue = new(), StatusCalculationType = StatusCalculationType.ADD });
                costumeAwakenStatusList.Add(new DataCostumeAwakenStatus() { StatusChangeValue = new(), StatusCalculationType = StatusCalculationType.MULTIPLY });
            }
            else
            {
                foreach (var costumeAwakenEffectGroup in costumeAwakenEffectGroups)
                {
                    if (!withoutAwakenStatusNotMatchAwakenCount || costumeAwakenEffectGroup.AwakenStep == awakenStep)
                    {
                        var costumeAwakenStatusUpGroups = DatabaseDefine.Master.EntityMCostumeAwakenStatusUpGroupTable.FindRangeByCostumeAwakenStatusUpGroupIdAndSortOrder(
                            (costumeAwakenEffectGroup.CostumeAwakenEffectId, int.MinValue),
                            (costumeAwakenEffectGroup.CostumeAwakenEffectId, int.MaxValue));

                        foreach (var costumeAwakenStatusUpGroup in costumeAwakenStatusUpGroups)
                        {
                            if (costumeAwakenStatusUpGroup.StatusCalculationType != StatusCalculationType.UNKNOWN &&
                                costumeAwakenStatusUpGroup.StatusKindType != StatusKindType.UNKNOWN)
                            {
                                // Add
                                StatusValue statusValueAdd = new();
                                StatusValue statusValueMult = new();

                                if (costumeAwakenStatusUpGroup.StatusCalculationType == StatusCalculationType.ADD)
                                {
                                    AddCostumeAwakenStatusValue(ref statusValueAdd, costumeAwakenStatusUpGroup.EffectValue, costumeAwakenStatusUpGroup.StatusKindType);
                                }
                                else
                                {
                                    AddCostumeAwakenStatusValue(ref statusValueMult, costumeAwakenStatusUpGroup.EffectValue, costumeAwakenStatusUpGroup.StatusKindType);
                                }

                                costumeAwakenStatusList.Add(new DataCostumeAwakenStatus() { StatusChangeValue = statusValueAdd, StatusCalculationType = StatusCalculationType.ADD });
                                costumeAwakenStatusList.Add(new DataCostumeAwakenStatus() { StatusChangeValue = statusValueMult, StatusCalculationType = StatusCalculationType.MULTIPLY });
                            }
                        }
                    }
                }
            }
        }

        private static DataCostumeAwakenStatus CreateDataCostumeAwakenStatus(ref StatusValue statusValue, StatusCalculationType statusCalculationType)
        {
            return CalculatorDataCostumeAwakenStatus.CreateDataCostumeAwakenStatus(statusValue.Agility, statusValue.Attack,
                statusValue.CriticalAttack, statusValue.CriticalRatio, 0, statusValue.Hp, statusValue.Vitality, statusCalculationType);
        }

        private static void AddCostumeAwakenStatusValue(ref StatusValue statusValue, int effectValue, StatusKindType statusKindType)
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
