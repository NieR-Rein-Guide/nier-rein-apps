using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark
{
    public class DataDeckRestriction
    {
        public int SlotNumber { get; }
        public QuestDeckRestrictionType QuestDeckRestrictionType { get; }
        public int RestrictionValue { get; }

        public DataDeckRestriction(int slotNumber, QuestDeckRestrictionType restrictionType, int restrictionValue)
        {
            SlotNumber = slotNumber;
            QuestDeckRestrictionType = restrictionType;
            RestrictionValue = restrictionValue;
        }
    }
}
