using System;
using System.Collections.Generic;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Status;

namespace NierReincarnation.Core.Dark.Calculator
{
    public static class CalculatorStatusOutgame
    {
        private static List<DataWeaponStatus> _subWeaponStatusListPool; // 0x0
        private static List<DataAbilityStatus> _abilityStatusListPool; // 0x8
        private static List<DataPartsMainStatus> _partsMainStatusListPool; // 0x10
        private static List<DataPartsSubStatus> _partsSubStatusListPool; // 0x18
        private static List<DataCostumeLevelBonusStatus> _costumeLevelBonusStatusListPool; // 0x20

        private static List<DataWeaponStatus> SubWeaponStatusListPool => _subWeaponStatusListPool ??= new List<DataWeaponStatus>();
        private static List<DataAbilityStatus> AbilityStatusListPool => _abilityStatusListPool ??= new List<DataAbilityStatus>();
        private static List<DataPartsMainStatus> PartsMainStatusListPool => _partsMainStatusListPool ??= new List<DataPartsMainStatus>();
        private static List<DataPartsSubStatus> PartsSubStatusListPool => _partsSubStatusListPool ??= new List<DataPartsSubStatus>();
        private static List<DataCostumeLevelBonusStatus> CostumeLevelBonusStatusListPool => _costumeLevelBonusStatusListPool ??= new List<DataCostumeLevelBonusStatus>();

        public static StatusValue GetDeckActorStatus(long userId, DataDeckActor deckActor)
        {
            if (deckActor == null)
                return new StatusValue();

            ClearCalculateBuffer();

            var costumeStatus = deckActor.Costume?.CostumeStatus;
            var companionStatus = deckActor.Companion?.CompanionStatus;
            var mainWeaponStatus = deckActor.MainWeapon?.WeaponStatus;

            CollectSubWeaponStatus(deckActor);
            CollectPartsStatusList(deckActor);

            CollectAbilityStatusToPool(deckActor.AbilityStatusList);
            CollectAbilityStatusToPool(deckActor.DeckOtherDeckActorAbilityStatusList);

            var characterBoardStatusList = CreateDataCharacterBoardStatusList(userId, deckActor);
            CollectDataCostumeLevelBonusStatusList(userId, deckActor);

            return CalculatorStatus.CalculateDeckActorStatus(costumeStatus, companionStatus, mainWeaponStatus, SubWeaponStatusListPool, PartsMainStatusListPool, PartsSubStatusListPool, AbilityStatusListPool, characterBoardStatusList, CostumeLevelBonusStatusListPool);
        }

        public static StatusValue GetDeckActorCostumeStatus(long userId, DataDeckActor deckActor)
        {
            if (deckActor == null)
                return new StatusValue();

            ClearCalculateBuffer();

            DataCostumeStatus costumeStatus = null;
            if (deckActor.Costume != null)
                costumeStatus = deckActor.Costume.CostumeStatus;

            CollectAbilityStatusToPool(deckActor.AbilityStatusList);
            CollectAbilityStatusToPool(deckActor.DeckOtherDeckActorAbilityStatusList);

            var statusPool = AbilityStatusListPool;
            var boardStatusList = CreateDataCharacterBoardStatusList(userId, deckActor);
            CollectDataCostumeLevelBonusStatusList(userId, deckActor);

            var levelBonusStatusPool = CostumeLevelBonusStatusListPool;
            return CalculatorStatus.GetCostumeStatus(costumeStatus, null, null, statusPool, boardStatusList, levelBonusStatusPool);
        }

        public static StatusValue GetCostumeStatus(DataOutgameCostume costume)
        {
            if (costume?.CostumeStatus == null)
                return new StatusValue();

            ClearCalculateBuffer();

            CollectCostumeAbilityStatus(costume, AbilityStatusListPool);

            return CalculatorStatus.GetCostumeStatus(costume.CostumeStatus, null, null, AbilityStatusListPool, null, null);
        }

        public static StatusValue GetWeaponStatus(DataWeapon dataWeapon)
        {
            if (dataWeapon?.WeaponStatus == null)
                return new StatusValue();

            ClearCalculateBuffer();

            CollectWeaponAbilityStatus(dataWeapon, AbilityStatusListPool);

            return CalculatorStatus.GetWeaponStatus(dataWeapon.WeaponStatus, AbilityStatusListPool);
        }

        public static StatusValue GetCompanionStatus(DataOutgameCompanion companion)
        {
            if (companion?.CompanionStatus == null)
                return new StatusValue();

            ClearCalculateBuffer();

            CollectCompanionAbilityStatus(companion, AbilityStatusListPool);

            return CalculatorStatus.GetCompanionStatus(companion.CompanionStatus, AbilityStatusListPool);
        }

        public static StatusValue GetDeckActorWeaponStatus(long userId, DataDeckActor deckActor, DataWeapon dataWeapon, bool isMainWeapon, bool isSkillful)
        {
            ClearCalculateBuffer();

            CollectAbilityStatusToPool(deckActor.AbilityStatusList);
            CollectAbilityStatusToPool(deckActor.DeckOtherDeckActorAbilityStatusList);

            return CalculatorStatus.GetWeaponStatus(dataWeapon.WeaponStatus, AbilityStatusListPool, isSkillful, isMainWeapon);
        }

        public static StatusValue GetDeckActorCompanionStatus(long userId, DataDeckActor deckActor)
        {
            if (deckActor?.Companion == null)
                return new StatusValue();

            ClearCalculateBuffer();

            CollectAbilityStatusToPool(deckActor.AbilityStatusList);
            CollectAbilityStatusToPool(deckActor.DeckOtherDeckActorAbilityStatusList);

            return CalculatorStatus.GetCompanionStatus(deckActor.Companion.CompanionStatus, AbilityStatusListPool);
        }

        public static void ApplyDeckAbilityStatusList(long userId, DataDeck dataDeck)
        {
            foreach (var actor in dataDeck.UserDeckActors)
            {
                ApplyAbilityStatusList(userId, actor);
                ClearDeckOtherDeckActorAbility(actor);

                foreach (var actor2 in dataDeck.UserDeckActors)
                {
                    if (actor == actor2)
                        continue;

                    ApplyDeckOtherDeckActorAbility(actor, actor2);
                }
            }
        }

        private static void ApplyAbilityStatusList(long userId, DataDeckActor deckActor)
        {
            if (deckActor?.Costume == null)
                return;

            var statusList = deckActor.AbilityStatusList ??= new List<DataAbilityStatus>();

            statusList.Clear();
            CollectAbilityStatus(userId, deckActor, statusList);
        }

        private static void CollectAbilityStatus(long userId, DataDeckActor deckActor, List<DataAbilityStatus> abilityStatusList)
        {
            CollectCostumeAbilityStatus(deckActor.Costume, abilityStatusList);

            if (!OutgameAbilityCache.IsCacheEnabled)
                CollectCharacterAbility(userId, deckActor.Costume.CharacterId, abilityStatusList);
            else
            {
                OutgameAbilityCache.TryGetCharacterAbilityStatusList(deckActor.Costume.CharacterId, out var characterStatusList);
                abilityStatusList.AddRange(characterStatusList);
            }

            var companionAbility = deckActor.Companion?.CompanionAbility;
            if (companionAbility != null)
                abilityStatusList.AddRange(companionAbility.AbilityStatusList);

            CollectWeaponAbilityStatus(deckActor.MainWeapon, abilityStatusList);
            CollectWeaponAbilityStatus(deckActor.SubWeapon01, abilityStatusList);
            CollectWeaponAbilityStatus(deckActor.SubWeapon02, abilityStatusList);

            foreach (var ability in deckActor.MemorySeriesBonus)
            {
                if (ability.IsLocked)
                    continue;

                abilityStatusList.AddRange(ability.AbilityStatusList);
            }
        }

        private static void CollectCostumeAbilityStatus(DataOutgameCostume costume, List<DataAbilityStatus> abilityStatusList)
        {
            var abilities = costume.CostumeAbilities;
            if (abilities == null)
                return;

            foreach (var ability in abilities)
            {
                if (ability.IsLocked)
                    continue;

                abilityStatusList.AddRange(ability.AbilityStatusList);
            }
        }

        private static void CollectCharacterAbility(long userId, int characterId, List<DataAbilityStatus> abilityStatusList)
        {
            var statusList = CalculatorCharacterRank.CreateCharacterRankAbilityStatusList(userId, characterId);
            if (statusList != null)
                abilityStatusList.AddRange(statusList);

            var boardStatusList = CalculatorCharacterBoard.CreateCharacterBoardAbilityStatusList(userId, characterId);
            if (boardStatusList != null)
                abilityStatusList.AddRange(boardStatusList);
        }

        private static void CollectWeaponAbilityStatus(DataWeapon dataWeapon, List<DataAbilityStatus> abilityStatusList)
        {
            if (dataWeapon?.Abilities == null)
                return;

            foreach (var ability in dataWeapon.Abilities)
            {
                if (ability.IsLocked)
                    continue;

                abilityStatusList.AddRange(ability.AbilityStatusList);
            }
        }

        private static void CollectSubWeaponStatus(DataDeckActor deckActor)
        {
            if (deckActor?.SubWeapon01 != null)
                SubWeaponStatusListPool.Add(deckActor.SubWeapon01.WeaponStatus);

            if (deckActor?.SubWeapon02 != null)
                SubWeaponStatusListPool.Add(deckActor.SubWeapon02.WeaponStatus);
        }

        private static void CollectCompanionAbilityStatus(DataOutgameCompanion companion, List<DataAbilityStatus> abilityStatusList)
        {
            if (companion.CompanionAbility == null || companion.CompanionAbility.IsLocked)
                return;

            abilityStatusList.AddRange(companion.CompanionAbility.AbilityStatusList);
        }

        private static void CollectPartsStatusList(DataDeckActor actor)
        {
            foreach (var part in actor.Memories)
            {
                if (part == null)
                    continue;

                PartsMainStatusListPool.Add(part.MainMemoryStatus);

                if (part.SubMemoryStatus != null)
                    PartsSubStatusListPool.AddRange(part.SubMemoryStatus);
            }
        }

        private static void ClearDeckOtherDeckActorAbility(DataDeckActor deckActor)
        {
            if (deckActor == null)
                return;

            deckActor.DeckOtherDeckActorAbilityStatusList ??= new List<DataAbilityStatus>();
            deckActor.DeckOtherDeckActorAbilityStatusList.Clear();
        }

        private static void ApplyDeckOtherDeckActorAbility(DataDeckActor source, DataDeckActor destination)
        {
            if (source == null || destination == null)
                return;

            if (source.IsEmpty || destination.IsEmpty)
                return;

            foreach (var abilityStatus in source.AbilityStatusList)
            {
                if (abilityStatus.ApplyScopeType == AbilityBehaviourStatusApplyScopeType.PARTY)
                    destination.DeckOtherDeckActorAbilityStatusList.Add(abilityStatus);
            }
        }

        private static void ClearCalculateBuffer()
        {
            _subWeaponStatusListPool?.Clear();
            _abilityStatusListPool?.Clear();
            _partsMainStatusListPool?.Clear();
            _partsSubStatusListPool?.Clear();
            _costumeLevelBonusStatusListPool?.Clear();
        }

        private static void CollectAbilityStatusToPool(List<DataAbilityStatus> abilityStatusList)
        {
            if (abilityStatusList == null)
                return;

            AbilityStatusListPool.AddRange(abilityStatusList);
        }

        private static List<DataCharacterBoardStatus> CreateDataCharacterBoardStatusList(long userId, DataDeckActor deckActor)
        {
            if (deckActor?.Costume == null)
                return null;

            return CalculatorCharacterBoard.CreateCharacterBoardStatusList(userId, deckActor.Costume.CharacterId);
        }

        private static void CollectDataCostumeLevelBonusStatusList(long userId, DataDeckActor deckActor)
        {
            if (deckActor?.Costume == null)
                return;

            CalculatorCostumeLevelBonus.CreateCostumeLevelBonusStatusList(userId, deckActor.Costume.CharacterId, CostumeLevelBonusStatusListPool);
        }
    }
}
