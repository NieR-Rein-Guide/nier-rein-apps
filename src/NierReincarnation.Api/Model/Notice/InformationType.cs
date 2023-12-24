using System.ComponentModel.DataAnnotations;

namespace NierReincarnation.Api.Model;

public enum InformationType
{
    Update = 1,
    Event = 2,
    [Display(Name = "Summons Update")]
    SummonsUpdate = 3,
    Campaign = 4,
    Issue = 5,
    Maintenance = 6,
    Information = 7,
    [Display(Name = "Other")]
    Other1 = 8,
    [Display(Name = "Operation Letter")]
    OperationLetter = 9,
    [Display(Name = "Other")]
    Other2 = 10,
    Mission = 11,
    [Display(Name = "Other")]
    Other3 = 12
}
