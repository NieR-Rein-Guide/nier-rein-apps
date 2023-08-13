namespace NierReincarnation.Core.Dark;

public class SkeletonId : IEquatable<SkeletonId>
{
    public static readonly SkeletonId InvalidSkeletonId = new();

    private static readonly int InvalidId;

    public SkeletonCategory Category { get; }

    public int Id { get; }

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
        if (obj is SkeletonId sid)
            return Id == sid.Id;

        return false;
    }

    public override int GetHashCode()
    {
        return Id + ((int)Category * 1000);
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
        return skeletonId[..2] switch
        {
            "ch" => SkeletonCategory.Character,
            "cm" => SkeletonCategory.Companion,
            "cw" => SkeletonCategory.CompanionWeapon,
            "mt" => SkeletonCategory.Enemy,
            "mw" => SkeletonCategory.EnemyWeapon,
            "wp" => SkeletonCategory.Weapon,
            _ => SkeletonCategory.Unknown,
        };
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
