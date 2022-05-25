using System;

namespace NierReincarnation.Core.Dark
{
    public class SkeletonId : IEquatable<SkeletonId>
    {
        // Fields
        public static readonly SkeletonId InvalidSkeletonId = new SkeletonId(); // 0x0
        private static readonly int InvalidId = 0; // 0x8

        // 0x10
        public SkeletonCategory Category { get; }
        // 0x14
        public int Id { get; }
        // 0x18
        public string StringId { get; }

        public SkeletonId()
        {
            Category = SkeletonCategory.Unknown;
            Id = InvalidId;
            StringId = string.Empty;
        }

        public SkeletonId(string id)
        {
            Category = GenerateSkeletonCategory(id);
            if (id == null)
                return;

            Id = int.Parse(id.Substring(2, 3));
            StringId = CreateStringId();
        }

        public SkeletonId(SkeletonCategory category, int id)
        {
            Category = category;
            Id = id;
            StringId = CreateStringId();
        }

        public bool Equals(SkeletonId other)
        {
            return Id == other?.Id;
        }

        public override bool Equals(object obj)
        {
            if(obj is SkeletonId sid)
                return Id == sid.Id;

            return false;
        }

        public override int GetHashCode()
        {
            return Id + (int)Category * 1000;
        }

        public override string ToString()
        {
            return StringId;
        }

        private string CreateStringId()
        {
            var categoryString = SkeletonCategoryToString();
            return $"{categoryString}{Id:D3}";
        }

        private string SkeletonCategoryToString()
        {
            var s = new[] { "ch", "cm", "cw", "mt", "mw", "wp" };
            return (int)Category - 1 < 6 ? s[(int)Category - 1] : "unknown";
        }

        public static bool operator ==(SkeletonId a, SkeletonId b) => a?.Id == b?.Id;
        public static bool operator !=(SkeletonId a, SkeletonId b) => a?.Id != b?.Id;

        private SkeletonCategory GenerateSkeletonCategory(string skeletonId)
        {
            var category = skeletonId.Substring(0, 2);
            switch (category)
            {
                case "ch":
                    return SkeletonCategory.Character;

                case "cm":
                    return SkeletonCategory.Companion;

                case "cw":
                    return SkeletonCategory.CompanionWeapon;

                case "mt":
                    return SkeletonCategory.Enemy;

                case "mw":
                    return SkeletonCategory.EnemyWeapon;

                case "wp":
                    return SkeletonCategory.Weapon;
            }

            return SkeletonCategory.Unknown;
        }

        public enum SkeletonCategory
        {
            Unknown = 0,
            Character = 1,
            Companion = 2,
            CompanionWeapon = 3,
            Enemy = 4,
            EnemyWeapon = 5,
            Weapon = 6,
        }
    }
}
