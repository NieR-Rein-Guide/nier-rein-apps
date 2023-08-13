namespace NierReincarnation.Core.Dark.Status;

public class DataSkillPower
{
    public List<DataPowerReferenceStatus> ReferenceStatusSettings { get; set; }

    public int SkillPowerBaseValue { get; set; }

    public PowerCalculationReferenceStatusType ReferenceStatusType { get; set; }
}
