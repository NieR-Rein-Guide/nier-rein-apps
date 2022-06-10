using System.Collections.Generic;

namespace NierReincarnation.Context.Models
{
    public class StaminaPreference
    {
        public IList<StaminaType> Order { get; } = new List<StaminaType>
        {
            StaminaType.EVENT,
            StaminaType.MEDIUM,
            StaminaType.SMALL,
            StaminaType.LARGE
        };
    }

    public enum StaminaType
    {
        SMALL = 3001,
        MEDIUM = 3002,
        LARGE = 3003,
        EVENT = 90000
    }
}
