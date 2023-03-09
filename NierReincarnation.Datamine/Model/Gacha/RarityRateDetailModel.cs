namespace NierReincarnation.Datamine.Model;

public class RarityRateDetailModel
{
    public GachaWeaponModel Weapon { get; init; }

    public GachaCostumeModel Costume { get; init; }

    public decimal Rate { get; set; }
}
