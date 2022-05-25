using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Art.Framework.ApiNetwork.Grpc.Api.ConsumableItem;
using Newtonsoft.Json;
using NierReincarnation.Context.Models;
using NierReincarnation.Core.Adam.Framework.Network;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Networking;
using NierReincarnation.Core.Dark.View.HeadUpDisplay;

namespace NierReincarnation.Context
{
    public class StaminaContext
    {
        private static int GemReduceAmount_ = 100;
        private static int PotReduceAmount_ = 1;
        private static int SmallPotReplenishAmount_ = 10;

        private DarkClient _dc;

        public static StaminaPreference Preference { get; } = new StaminaPreference();

        internal StaminaContext()
        {
            _dc = new DarkClient();
        }

        public int GetCurrentStamina()
        {
            return Stamina.CalculateCurrentStamina();
        }

        public int GetMaxStamina()
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

            var staminaItems = GetStaminaItems();
            var refillBy = refillCap - currentStamina;

            // Refill by preference
            foreach (var orderType in preference.Order)
            {
                var orderItems = staminaItems.Where(x => x.Type == orderType);
                foreach (var orderItem in orderItems)
                {
                    var usedCount = 0;

                    var itemCount = orderItem.Count;
                    while (itemCount > 0 && itemCount / orderItem.Reduce > 0)
                    {
                        if (refillBy <= 0)
                            break;

                        refillBy -= orderItem.Replenish;
                        itemCount -= orderItem.Reduce;

                        usedCount += orderItem.Reduce;
                    }

                    await orderItem.ReduceCountyByAsync(usedCount);

                    if (refillBy <= 0)
                        return true;
                }
            }

            return refillBy <= 0;
        }

        private IList<StaminaItem> GetStaminaItems()
        {
            var result = new List<StaminaItem>();

            // Add gems
            //var userId = PlayerPreference.Instance.ActivePlayer.UserId;
            //var userGems = CalculatorGem.GetEntityIUserGemTable(userId);

            //result.Add(new StaminaItem(StaminaType.GEM, userGems.FreeGem + userGems.PaidGem, GetMaxStamina(), GemReduceAmount_, userGems));

            // Add pots
            var smallPot = DatabaseDefine.User.EntityIUserConsumableItemTable.All.FirstOrDefault(x => x.ConsumableItemId == 3001);
            var mediumPot = DatabaseDefine.User.EntityIUserConsumableItemTable.All.FirstOrDefault(x => x.ConsumableItemId == 3002);
            var largePot = DatabaseDefine.User.EntityIUserConsumableItemTable.All.FirstOrDefault(x => x.ConsumableItemId == 3003);

            result.Add(new StaminaItem(_dc, StaminaType.SMALL, smallPot?.Count ?? 0, SmallPotReplenishAmount_, PotReduceAmount_, smallPot));
            result.Add(new StaminaItem(_dc, StaminaType.MEDIUM, mediumPot?.Count ?? 0, GetMaxStamina() / 2, PotReduceAmount_, mediumPot));
            result.Add(new StaminaItem(_dc, StaminaType.LARGE, largePot?.Count ?? 0, GetMaxStamina(), PotReduceAmount_, largePot));

            return result;
        }

        class StaminaItem
        {
            private readonly object _userObj;

            private DarkClient _dc;

            public int Count { get; }
            public StaminaType Type { get; }

            public int Replenish { get; }
            public int Reduce { get; }

            public StaminaItem(DarkClient dc, StaminaType type, int count, int replenish, int reduce, object userObj)
            {
                _dc = dc;

                Type = type;
                Count = count;

                Replenish = replenish;
                Reduce = reduce;

                _userObj = userObj;
            }

            public async Task ReduceCountyByAsync(int count)
            {
                if (count <= 0)
                    return;

                //if (Type == StaminaType.GEM)
                //{
                //    var userGems = _userObj as EntityIUserGem;

                //    var freeAmount = Math.Min(userGems.FreeGem, count);
                //    userGems.FreeGem -= freeAmount;

                //    count -= freeAmount;
                //    userGems.PaidGem -= count;

                //    return;
                //}

                var userConsumable = _userObj as EntityIUserConsumableItem;
                userConsumable.Count -= count;

                var ci = _dc.ConsumableItemService;
                var useEffectRes = await ci.UseEffectItemAsync(new UseEffectItemRequest { ConsumableItemId = userConsumable.ConsumableItemId, Count = count });

                foreach (var userData in useEffectRes.DiffUserData)
                    DatabaseDefine.User.Diff(userData.Key, JsonConvert.DeserializeObject<List<object>>(userData.Value.UpdateRecordsJson));

                // Update stamina for user
                //var userId = CalculatorStateUser.GetUserId();
                //var userStatus = DatabaseDefine.User.EntityIUserStatusTable.FindByUserId(userId);
                //userStatus.StaminaMilliValue += count * Replenish * 1000;
                //userStatus.StaminaUpdateDatetime = CalculatorDateTime.UnixTimeNow();
            }
        }
    }
}
