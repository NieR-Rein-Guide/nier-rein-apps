namespace NierReincarnation.Core.Dark.Component.WorldMap
{
    public struct UserGimmickOrnamentProgress
    {
        public long UserId { get; set; }
        public long BaseDatetime { get; set; }
        public int GimmickSequenceScheduleId  { get; set; }
        public int GimmickSequenceId  { get; set; }
        public int GimmickId  { get; set; }
        public int GimmickOrnamentIndex  { get; set; }
        public int ProgressValueBit { get; set; }

        public void Reset()
        {
            UserId = GimmickConstant.kInvalidId;
        }

        public bool IsEnable()
        {
            return UserId != GimmickConstant.kInvalidId;
        }
    }
}
