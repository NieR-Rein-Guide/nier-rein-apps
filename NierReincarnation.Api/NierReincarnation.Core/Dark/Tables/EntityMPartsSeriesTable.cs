using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMPartsSeriesTable : TableBase<EntityMPartsSeries> // TypeDefIndex: 12059
    {
        // Fields
        private readonly Func<EntityMPartsSeries, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C5270C Offset: 0x2C5270C VA: 0x2C5270C
        public EntityMPartsSeriesTable(EntityMPartsSeries[] sortedData):base(sortedData)
        {
            primaryIndexSelector = series => series.PartsSeriesId;
        }

        // RVA: 0x2C5280C Offset: 0x2C5280C VA: 0x2C5280C
        public EntityMPartsSeries FindByPartsSeriesId(int key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
