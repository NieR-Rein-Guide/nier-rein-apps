using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NierReincarnation.Core.MasterMemory
{
    // MasterMemory.RangeView<T>
    public readonly struct RangeView<T> : IReadOnlyList<T>
    {
        public static RangeView<T> Empty = new RangeView<T>();

        // 0x00
        private readonly T[] orderedData;
        // 0x08
        private readonly int left;
        // 0x0C
        private readonly int right;
        // 0x10
        private readonly bool ascendant;
        // 0x11
        private readonly bool hasValue;

        public int Count => hasValue ? right + 1 - left : 0;

        public T this[int index]
        {
            get
            {
                index = ascendant ? left + index : right - index;
                return orderedData[index];
            }
        }

        public RangeView(T[] orderedData, int left, int right, bool ascendant)
        {
            this.orderedData = orderedData;
            this.left = left;
            this.right = right;
            this.ascendant = ascendant;
            hasValue = left <= right && orderedData.Length != 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var enumeration = orderedData.Skip(left).Take(Count);
            if (!ascendant)
                enumeration = enumeration.Reverse();

            return enumeration.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
