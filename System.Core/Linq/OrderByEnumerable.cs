using System.Collections;
using System.Collections.Generic;

namespace System.Linq
{
    internal class OrderByEnumerable<TElement, TKey> : IOrderedEnumerable<TElement>
    {
        public readonly IComparer<TKey> Comparer;
        public readonly bool Descending;
        public readonly Func<TElement, TKey> KeySelector;
        public readonly IEnumerable<TElement> Source;

        public OrderByEnumerable(IEnumerable<TElement> source, Func<TElement, TKey> keySelector,
                                 IComparer<TKey> comparer, bool descending)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (keySelector == null) throw new ArgumentNullException("keySelector");

            Source = source;
            KeySelector = keySelector;
            Comparer = comparer ?? Comparer<TKey>.Default;
            Descending = descending;
        }

        #region IOrderedEnumerable<TElement> Members

        public IOrderedEnumerable<TElement> CreateOrderedEnumerable<TNewKey>(
            Func<TElement, TNewKey> keySelector,
            IComparer<TNewKey> comparer,
            bool descending)
        {
            return new ThenByEnumerable<TElement, TNewKey, TKey>(this, keySelector, comparer, descending);
        }

        public IEnumerator<TElement> GetEnumerator()
        {
            TElement[] array = GetElementsToSort().ToArray();
            Array.Sort(array, CompareElements);
            foreach (TElement element in array)
                yield return element;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        internal virtual int CompareElements(TElement e1, TElement e2) // ThenByEnumerable will override this method.
        {
            int result = Comparer.Compare(KeySelector(e1), KeySelector(e2));
            return Descending ? -result : result;
        }

        internal virtual IEnumerable<TElement> GetElementsToSort() // ThenByEnumerable will override this method.
        {
            return Source;
        }
    }
}