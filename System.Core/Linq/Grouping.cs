using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace System.Linq
{
    internal class Grouping<TKey, TElement> : ReadOnlyCollection<TElement>, IGrouping<TKey, TElement>
    {
        public Grouping(TKey key) : base(new List<TElement>())
        {
            Key = key;
        }

        internal IList<TElement> InnerList
        {
            get { return Items; }
        }

        #region IGrouping<TKey,TElement> Members

        public TKey Key { get; private set; }

        #endregion
    }
}