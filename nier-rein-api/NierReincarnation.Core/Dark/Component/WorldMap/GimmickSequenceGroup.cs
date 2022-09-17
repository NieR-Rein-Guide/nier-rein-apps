namespace NierReincarnation.Core.Dark.Component.WorldMap
{
    public struct GimmickSequenceGroup
    {
        public int GimmickSequenceGroupId { get; set; }
        public int GimmickSequenceId { get; set; }

        public void Reset()
        {
            GimmickSequenceGroupId = GimmickConstant.kInvalidId;
        }

        public bool IsEnable()
        {
            return GimmickSequenceGroupId != GimmickConstant.kInvalidId;
        }
    }
}
