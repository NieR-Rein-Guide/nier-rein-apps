using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_deck_entrust_coefficient_status")]
    public class EntityMDeckEntrustCoefficientStatus
    {
        [Key(0)]
        public int EntrustDeckStatusType { get; set; }

        [Key(1)]
        public int DeckStatusType { get; set; }

        [Key(2)]
        public int CoefficientPermil { get; set; }
    }
}
