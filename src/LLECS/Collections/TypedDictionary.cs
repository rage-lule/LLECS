using System;
using System.Collections;
using System.Collections.Generic;

namespace LLECS.Collections
{
    public class TypedDictionary<TValue> : IDictionary<Type, TValue>
    {
        private IDictionary<Type, TValue> _innerDic;

        public TypedDictionary(IDictionary<Type, TValue> innerDic)
        {
            _innerDic = innerDic;
        }

        #region Typed Methods
        public void Add<T>(T value) where T : TValue
        {
            var type = typeof(T);

            if (_innerDic.ContainsKey(type))
            {
                _innerDic[type] = value;
            }
            else
            {
                _innerDic.Add(type, value);
            }
        }

        public T Get<T>() where T : TValue
        {
            // Will throw KeyNotFoundException
            return (T)_innerDic[typeof(T)];
        }

        public bool Contains<T>() where T : TValue
        {
            return _innerDic.ContainsKey(typeof(T));
        }

        public bool TryGetValue<T>(out T value) where T : TValue
        {
            var type = typeof(T);
            TValue intermediateResult;

            if (_innerDic.TryGetValue(type, out intermediateResult))
            {
                value = (T)intermediateResult;
                return true;
            }

            value = default(T);
            return false;
        }
        #endregion

        #region IDictionary
        public TValue this[Type key] { get => _innerDic[key]; set => _innerDic[key] = value; }
        public ICollection<Type> Keys => _innerDic.Keys;
        public ICollection<TValue> Values => _innerDic.Values;
        public int Count => _innerDic.Count;
        public bool IsReadOnly => _innerDic.IsReadOnly;
        public void Add(KeyValuePair<Type, TValue> item) => _innerDic.Add(item);
        public void Add(Type key, TValue value) => _innerDic.Add(key, value);
        public bool TryGetValue(Type key, out TValue value) => _innerDic.TryGetValue(key, out value);
        public void CopyTo(KeyValuePair<Type, TValue>[] array, int arrayIndex) => _innerDic.CopyTo(array, arrayIndex);
        public bool Contains(KeyValuePair<Type, TValue> item) => _innerDic.Contains(item);
        public bool ContainsKey(Type key) => _innerDic.ContainsKey(key);
        public bool Remove(KeyValuePair<Type, TValue> item) => _innerDic.Remove(item);
        public bool Remove(Type key) => _innerDic.Remove(key);
        public void Clear() => _innerDic.Clear();
        public IEnumerator<KeyValuePair<Type, TValue>> GetEnumerator() => _innerDic.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _innerDic.GetEnumerator();
        #endregion
    }
}