using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortedWord
{
    public interface ISortedFour<T>
    {
        /// <summary>
        /// Number of row of matrix
        /// </summary>
        int RowCount { get; }

        /// <summary>
        /// Total number of items
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Adds item.
        /// </summary>
        /// <param name="val">Item to add.</param>
        void Add(T val);

        /// <summary>
        /// Removes item.
        /// </summary>
        /// <param name="val">Item to remove.</param>
        /// <returns></returns>
        bool Remove(T val);

        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="idx">Index</param>
        /// <returns>Elements at Row's index.</returns>
        IList<T> this[int idx] { get; }
    }

    /// <summary>
    /// SortedFour class which accepts non-duplicated elements of type 'T'
    /// and present them in a 4-column matrix form  
    /// sorted by alphabetically top to bottom and Then left to right.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SortedFour<T> : ISortedFour<T>
        where T : IComparable
    {
        #region Private Members
        /// <summary>
        /// Specifies number of columns desired for maxtrix
        /// </summary>
        private int _numberOfColumn = 4;

        private IDictionary<int, SortedSet<T>> _columns;
        private SortedSet<T> _mainList = new SortedSet<T>();
        private bool _needBalance = false;
        #endregion

        #region Constructor
        /// <summary>
        /// Instantiates <c>SortedFour</c>
        /// </summary>
        public SortedFour()
        {
            Init();
        }
        #endregion

        #region Properties and Indexer
        /// <summary>
        /// Number of elements in the Collection
        /// </summary>
        public int Count
        {
            get
            {
                return _mainList.Count;
            }
        }

        /// <summary>
        /// Number of rows in of the  matrix/table
        /// </summary>
        public int RowCount
        {
            get
            {
                var n = _mainList.Count;
                var r = n / _numberOfColumn;
                var rm = n % _numberOfColumn;
                return rm == 0 ? r : r + 1;
            }
        }

        /// <summary>
        /// Gets elements by Row
        /// </summary>
        /// <param name="index">Row's index</param>
        /// <returns>Elements at row's <paramref name="index"/></returns>
        public IList<T> this[int index]
        {
            get { return GetRowAt(index); }
        }
        #endregion

        #region Class Methods

        /// <summary>
        /// Adds single item
        /// </summary>
        /// <param name="val">Item to add</param>
        public void Add(T val)
        {
            if (val == null) return;

            if (_mainList.Add(val))
                // Update re-balance flage
                _needBalance = true;
        }

        /// <summary>
        /// Adds items to collection.
        /// </summary>
        /// <param name="val">Items to add</param>
        public void AddAll(IList<T> val)
        {
            if (val == null) return;
            val.ToList().ForEach(x => _mainList.Add(x));

            // Update re-balance flag
            _needBalance = true;
        }

        /// <summary>
        /// Remove item from collection
        /// </summary>
        /// <param name="val">Item to remove</param>
        /// <returns>True if Remove succeeded; False, otherwise.</returns>
        public bool Remove(T val)
        {
            if (!_mainList.Any(x => x.CompareTo(val) == 0))
                return false;
            _needBalance = true;
            return _mainList.RemoveWhere(x => x.CompareTo(val) == 0) != -1;
        }

        /// <summary>
        /// Balance the collection into desired matrix
        /// </summary>
        private void Balance()
        {
            if (!_needBalance) return;

            var row = RowCount;
            var itemsOnLastRow = Count % _numberOfColumn;
            var idx = 0;

            for (int c = 0; c < _numberOfColumn; c++)
            {
                _columns[c] = new SortedSet<T>();
                for (int r = 0; r < row; r++)
                {
                    if (r == row - 1 &&
                        itemsOnLastRow != 0 &&
                        c >= itemsOnLastRow
                       ) continue;

                    _columns[c].Add(_mainList.ElementAtOrDefault(idx++));
                }
            }

            _needBalance = false;
        }

        /// <summary>
        /// Gets items at row <paramref name="idx"/>
        /// </summary>
        /// <param name="idx">Index of row</param>
        /// <returns>Items at <paramref name="idx"/> row specified</returns>
        private IList<T> GetRowAt(int idx)
        {
            var items = new List<T>();

            // Balance before retrieving the row
            Balance();

            for (int i = 0; i < _numberOfColumn; i++)
            {
                items.Add(_columns[i].ElementAtOrDefault(idx));
            }
            return items;
        }

        /// <summary>
        /// Gets formatted items in matrix form
        /// </summary>
        /// <returns>Matrix string of items in Collection</returns>
        public override string ToString()
        {
            if (Count == 0) return string.Empty;

            // Balance the columns before outputing
            Balance();

            var sb = new StringBuilder();
            for (int i = 0; i < RowCount; i++)
            {
                var line = new List<T>(); ;
                for (int c = 0; c < _numberOfColumn; c++)
                    line.Add(_columns[c].ElementAtOrDefault(i));

                sb.Append(String.Join("\t", line));
                sb.AppendLine();
            }
            return sb.ToString();
        }

        private void Init()
        {
            _columns = new Dictionary<int, SortedSet<T>>();
            for (int i = 0; i < _numberOfColumn; i++)
            {
                _columns.Add(i, new SortedSet<T>());
            }
        }
        #endregion
    }
}
