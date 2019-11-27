using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace UniversityManagement.Infrastructure.Memory.Database
{
    public class Set<T> :
        IList<T>,
        ISet<T> where T : Entity
    {
        #region Fields

        private readonly List<Action> _actions;
        private readonly List<T> _records;
        private long _currentId;

        #endregion

        #region Construction

        public Set(List<T> seed = null)
        {
            _actions = new List<Action>();
            _records = seed ?? new List<T>();
            _currentId = _records.LastOrDefault()?.Id ?? 0;
        }

        #endregion

        #region IList<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            return _records.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) _records).GetEnumerator();
        }

        public void Add(T item)
        {
            throw new Exception("Use Insert");
        }

        public void Clear()
        {
            throw new NotSupportedException();
        }

        public bool Contains(T item)
        {
            return _records.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _records.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            throw new Exception("Use Delete");
        }

        public int Count => _records.Count;

        public bool IsReadOnly => false;

        public int IndexOf(T item)
        {
            return _records.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            _records.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _records.RemoveAt(index);
        }

        public T this[int index]
        {
            get => _records[index];
            set => _records[index] = value;
        }

        #endregion

        #region ISet<T> Members

        bool ISet.HasChanges => _actions.Count > 0;

        public void Commit()
        {
            foreach (var action in _actions)
                action.Invoke();
        }

        public void Delete(long id)
        {
            if (!_records.Select(x => x.Id).Contains(id))
                return;

            _actions.Add(() => _records.RemoveAll(x => x.Id == id));
        }

        public void Insert(T record)
        {
            if (record.Id != 0)
                throw new ArgumentException();

            record.Id = ++_currentId;

            _actions.Add(() => _records.Add(record));
        }

        #endregion
    }
}
