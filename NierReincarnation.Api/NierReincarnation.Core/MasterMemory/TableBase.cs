using System;
using System.Collections.Generic;
using System.Linq;

namespace NierReincarnation.Core.MasterMemory
{
    // MasterMemory.TableBase<TElement>
    public abstract class TableBase<TElement>
    {
        // 0x10
        protected TElement[] data;

        public int Count => data.Length;

        public RangeView<TElement> All => new RangeView<TElement>(data, 0, data.Length - 1, true);

        public TElement[] GetRawDataUnsafe()
        {
            return data;
        }

        public void SetRawDataUnsafe(TElement[] data)
        {
            this.data = data;
        }

        public TableBase(TElement[] sortedData)
        {
            data = sortedData;
        }

        protected static TElement ThrowKeyNotFound<TKey>(TKey key)
        {
            throw new KeyNotFoundException($"DataType: {key.GetType().Name}, Key: {key}");
        }

        protected static TElement FindUniqueCore<TKey>(TElement[] indexArray, Func<TElement, TKey> keySelector, IComparer<TKey> comparer, TKey key, bool throwIfNotFound = false)
        {
            var foundElement = indexArray.FirstOrDefault(x => comparer.Compare(keySelector(x), key) == 0);

            if (foundElement == null && throwIfNotFound)
                ThrowKeyNotFound(key);

            return foundElement;
        }

        protected static bool TryFindUniqueCore<TKey>(TElement[] indexArray, Func<TElement, TKey> keySelector, IComparer<TKey> comparer, TKey key, out TElement result)
        {
            result = indexArray.FirstOrDefault(x => comparer.Compare(keySelector(x), key) == 0);

            return result != null;
        }

        // TODO: Revisit method
        protected static TElement FindUniqueClosestCore<TKey>(TElement[] indexArray, Func<TElement, TKey> keySelector, IComparer<TKey> comparer, TKey key, bool selectLower)
        {
            var ordered = indexArray.Select(x => (comparer.Compare(keySelector(x), key), x)).OrderBy(x => x.Item1);

            return selectLower ?
                ordered.LastOrDefault(x => x.Item1 <= 0).x :
                ordered.FirstOrDefault(x => x.Item1 >= 0).x;
        }

        protected static RangeView<TElement> FindUniqueRangeCore<TKey>(TElement[] indexArray, Func<TElement, TKey> keySelector, IComparer<TKey> comparer, TKey min, TKey max, bool ascendant)
        {
            var keys = indexArray.Select(keySelector).ToArray();
            var left = Array.FindIndex(keys, key => comparer.Compare(key, min) >= 0);
            var right = Array.FindLastIndex(keys, key => comparer.Compare(key, max) <= 0);

            return new RangeView<TElement>(indexArray, left, right, ascendant);
        }

        protected static RangeView<TElement> FindManyCore<TKey>(TElement[] indexKeys, Func<TElement, TKey> keySelector, IComparer<TKey> comparer, TKey key)
        {
            var foundElements = indexKeys.Where(x => comparer.Compare(keySelector(x), key) == 0).ToArray();

            return new RangeView<TElement>(foundElements, 0, foundElements.Length - 1, true);
        }

        // TODO: Implement missing methods when needed
    }
}
