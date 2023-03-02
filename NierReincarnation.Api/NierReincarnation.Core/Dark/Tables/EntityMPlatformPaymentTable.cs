using System;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMPlatformPaymentTable : TableBase<EntityMPlatformPayment> // TypeDefIndex: 12067
    {
        // Fields
        private readonly Func<EntityMPlatformPayment, (int, PlatformType)> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C4F83C Offset: 0x2C4F83C VA: 0x2C4F83C
        public EntityMPlatformPaymentTable(EntityMPlatformPayment[] sortedData):base(sortedData)
        {
            primaryIndexSelector = payment => (payment.PlatformPaymentId, payment.PlatformType);
        }

        // RVA: 0x2C4F93C Offset: 0x2C4F93C VA: 0x2C4F93C
        public EntityMPlatformPayment FindByPlatformPaymentIdAndPlatformType((int, PlatformType) key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
