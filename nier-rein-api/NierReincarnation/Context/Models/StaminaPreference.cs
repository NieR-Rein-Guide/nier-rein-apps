using System.Collections.Generic;
using System.Linq;

namespace NierReincarnation.Context.Models
{
    public class StaminaPreference
    {
        public IList<StaminaType> Order { get; } = new List<StaminaType>
        {
            StaminaType.SMALL,
            StaminaType.MEDIUM,
            StaminaType.LARGE
        };
    }

    public enum StaminaType
    {
        //GEM,
        SMALL,
        MEDIUM,
        LARGE
    }
}
