using System;
using System.Collections.Generic;
using System.Linq;

namespace NierReincarnation.Context.Models
{
    public class StaminaPreference
    {
        private readonly StaminaType[] _order;

        private StaminaPreference(StaminaType[] order)
        {
            _order = order;
        }

        public static StaminaPreference CreateDefault()
        {
            return new StaminaPreference(new[]
            {
                StaminaType.EVENT,
                StaminaType.MEDIUM,
                StaminaType.SMALL,
                StaminaType.LARGE
            });
        }

        public static StaminaPreference Create(StaminaType[] order)
        {
            return new StaminaPreference(order);
        }

        public IEnumerable<StaminaType> GetOrder() => _order;

        public void Swap(StaminaType type1, StaminaType type2)
        {
            var index1 = Array.IndexOf(_order, type1);
            var index2 = Array.IndexOf(_order, type2);

            (_order[index1], _order[index2]) = (_order[index2], _order[index1]);
        }
    }

    public enum StaminaType
    {
        SMALL = 3001,
        MEDIUM = 3002,
        LARGE = 3003,
        EVENT = 3007
    }
}
