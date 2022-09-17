using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.Component.WorldMap
{
    public struct Gimmick
    {
        public int GimmickId { get; set; }
        public GimmickType GimmickType  { get; set; }
        public int GimmickOrnamentGroupId  { get; set; }

        public void Reset()
        {
            GimmickId = GimmickConstant.kInvalidId;
        }

        public bool IsEnable()
        {
            return GimmickId != GimmickConstant.kInvalidId;
        }
    }
}
