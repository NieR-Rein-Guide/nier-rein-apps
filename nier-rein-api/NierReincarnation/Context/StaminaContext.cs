using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Art.Framework.ApiNetwork.Grpc.Api.ConsumableItem;
using Newtonsoft.Json;
using NierReincarnation.Context.Models;
using NierReincarnation.Core.Adam.Framework.Network;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Networking;
using NierReincarnation.Core.Dark.View.HeadUpDisplay;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;

namespace NierReincarnation.Context
{
    public class StaminaContext: BaseContext
    {
        private static int GemReduceAmount_ = 100;
        private static int PotReduceAmount_ = 1;
        private static int SmallPotReplenishAmount_ = 10;

        private static readonly DarkClient _dc = new DarkClient();

        public static StaminaPreference Preference { get; } = new StaminaPreference();

        internal StaminaContext() { }

        public static int GetCurrentStamina()
        {
            return Stamina.CalculateCurrentStamina();
        }

        public static int GetMaxStamina()
        {
            return CalculatorUserStatus.GetMaxStamina();
        }

        public int GetLimitMaxStamina()
        {
            return Config.GetPossessionCountLimitStamina();
        }

        public async Task<bool> RefillStamina(int refillCap)
        {
            var currentStamina = GetCurrentStamina();
            if (refillCap <= currentStamina)
                return true;

            // Ensure preferences
            var preference = Preference;
            if (preference.Order.Count <= 0)
                preference = new StaminaPreference();

            // Get stamina items
            var staminaItems = GetStaminaItems();
            var eventPots = staminaItems.Where(x => !CalculatorConsumable.StaminaConsumableItemIds.Contains(x.ConsumableId)).ToArray();

            // Refill by preference
            var refillBy = refillCap - currentStamina;
            foreach (var orderType in preference.Order)
            {
                // Stop if amount was refilled
                if (refillBy <= 0)
                    return true;

                // Get next stamina item in preference
                var staminaItem = orderType == StaminaType.EVENT ?
                    eventPots.FirstOrDefault(x => x.PossessionCount > 0) :
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

        private IList<RecoverData> GetStaminaItems()
        {
            return CalculatorConsumable.CreateRecoverItemData(EffectTargetType.STAMINA_RECOVERY);
        }

        private async Task ConsumeStamina(RecoverData staminaItem, int consumeCount)
        {
            var useEffectRes = await TryRequest(async () =>
            {
                var useEffectReq = new UseEffectItemRequest {ConsumableItemId = staminaItem.ConsumableId, Count = consumeCount};
                return await _dc.ConsumableItemService.UseEffectItemAsync(useEffectReq);
            });

            foreach (var userData in useEffectRes.DiffUserData)
                DatabaseDefine.User.Diff(userData.Key, JsonConvert.DeserializeObject<List<object>>(userData.Value.UpdateRecordsJson));
        }
    }
}
