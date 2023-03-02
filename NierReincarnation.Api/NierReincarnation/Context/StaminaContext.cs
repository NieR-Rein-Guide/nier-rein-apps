using Art.Framework.ApiNetwork.Grpc.Api.ConsumableItem;
using NierReincarnation.Context.Models;
using NierReincarnation.Core.Adam.Framework.Network;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Networking;
using NierReincarnation.Core.Dark.View.HeadUpDisplay;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NierReincarnation.Context
{
    public class StaminaContext : BaseContext
    {
        private readonly DarkClient _dc = new();

        public static StaminaPreference Preference { get; private set; } = StaminaPreference.CreateDefault();

        internal StaminaContext()
        { }

        public static void SetPreferences(StaminaType[] order)
        {
            Preference = StaminaPreference.Create(order);
        }

        public static int GetCurrentStamina()
        {
            return Stamina.CalculateCurrentStamina();
        }

        public static int GetMaxStamina()
        {
            return CalculatorUserStatus.GetMaxStamina();
        }

        public static int GetLimitMaxStamina()
        {
            return Config.GetPossessionCountLimitStamina();
        }

        public async Task<bool> RefillStamina(int refillCap)
        {
            var currentStamina = GetCurrentStamina();
            if (refillCap <= currentStamina)
                return true;

            // Get stamina items
            var staminaItems = GetStaminaItems();
            var eventPots = staminaItems.Where(x => !CalculatorConsumable.StaminaConsumableItemIds.Contains(x.ConsumableId)).ToArray();

            // Refill by preference
            var refillBy = refillCap - currentStamina;
            foreach (var orderType in Preference.GetOrder())
            {
                // Stop if amount was refilled
                if (refillBy <= 0)
                    return true;

                // Get next stamina item in preference
                var staminaItem = orderType == StaminaType.EVENT ?
                    Array.Find(eventPots, x => x.PossessionCount > 0) :
                    staminaItems.FirstOrDefault(x => x.ConsumableId == (int)orderType && x.PossessionCount > 0);

                if (staminaItem == null)
                    continue;

                // Reduce enough of stamina item to replenish
                var usedCount = 0;
                while (staminaItem.PossessionCount > 0 && staminaItem.PossessionCount / staminaItem.NeedCount > 0)
                {
                    if (refillBy <= 0)
                        break;

                    refillBy -= staminaItem.EffectValue;
                    usedCount += staminaItem.NeedCount;

                    staminaItem.PossessionCount -= staminaItem.NeedCount;
                }

                if (usedCount > 0)
                    await ConsumeStamina(staminaItem, usedCount);
            }

            return refillBy <= 0;
        }

        public static IList<RecoverData> GetStaminaItems()
        {
            return CalculatorConsumable.CreateRecoverItemData(EffectTargetType.STAMINA_RECOVERY);
        }

        private async Task ConsumeStamina(RecoverData staminaItem, int consumeCount)
        {
            await TryRequest(async () =>
            {
                var useEffectReq = new UseEffectItemRequest { ConsumableItemId = staminaItem.ConsumableId, Count = consumeCount };
                return await _dc.ConsumableItemService.UseEffectItemAsync(useEffectReq);
            });
        }
    }
}
