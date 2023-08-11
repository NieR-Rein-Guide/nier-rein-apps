﻿using System.Collections.Generic;
using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.Status
{
    public class DataCompanionStatus
    {
       
        public Dictionary<StatusKindType, NumericalFunctionSetting> StatusCalculationSettings { get; set; }
       
        public int Level { get; set; }
       
        public AttributeType AttributeType { get; set; }
    }
}
