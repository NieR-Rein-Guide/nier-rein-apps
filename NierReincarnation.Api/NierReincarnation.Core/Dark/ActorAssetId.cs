using System;

namespace NierReincarnation.Core.Dark
{
    public class ActorAssetId : IEquatable<ActorAssetId> // TypeDefIndex: 9052
    {
        // Fields
        public static readonly ActorAssetId InvalidActorAssetId = new ActorAssetId();
        private static readonly int InvalidId = 0;

       
        public int Id { get; }
       
        public SkeletonId SkeletonId { get; }
       
        public string StringId { get; }

        public ActorAssetId()
        {
            Id = InvalidId;
            SkeletonId = SkeletonId.InvalidSkeletonId;
            StringId = string.Empty;
        }

        public ActorAssetId(string id)
        {
            Id = int.Parse(id.Substring(5, 3));
            SkeletonId = new SkeletonId(id.Substring(0, 5));
            StringId = CreateStringId();
        }

        public ActorAssetId(SkeletonId skeletonId, int id)
        {
            SkeletonId = skeletonId;
            Id = id;
            StringId = CreateStringId();
        }

        public bool Equals(ActorAssetId other)
        {
            return Id == other?.Id;
        }

        public override bool Equals(object obj)
        {
            if (obj is ActorAssetId aid)
                return aid.Id == Id;

            return false;
        }

        public override int GetHashCode()
        {
            return Id + SkeletonId.Id * 1000;
        }

        public override string ToString()
        {
            return StringId;
        }

        public static bool operator ==(ActorAssetId a, ActorAssetId b) => a?.Id == b?.Id;
        public static bool operator !=(ActorAssetId a, ActorAssetId b) => a?.Id != b?.Id;

        private string CreateStringId()
        {
            return $"{SkeletonId}{Id:D3}";
        }
    }
}
