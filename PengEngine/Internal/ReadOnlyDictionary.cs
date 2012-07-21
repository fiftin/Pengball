﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PengEngine.Internal
{
    public class ReadOnlyDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private IDictionary<TKey, TValue> baseDictionary;

        public ReadOnlyDictionary(IDictionary<TKey, TValue> baseDictionary)
        {
            this.baseDictionary = baseDictionary;
        }

        public void Add(TKey key, TValue value)
        {
            throw new NotSupportedException();
        }

        public bool ContainsKey(TKey key)
        {
            return baseDictionary.ContainsKey(key);
        }

        public ICollection<TKey> Keys
        {
            get { return baseDictionary.Keys; }
        }

        public bool Remove(TKey key)
        {
            throw new NotSupportedException();
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return baseDictionary.TryGetValue(key, out value);
        }

        public ICollection<TValue> Values
        {
            get { return baseDictionary.Values; }
        }

        public TValue this[TKey key]
        {
            get
            {
                return baseDictionary[key];
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            throw new NotSupportedException();
        }

        public void Clear()
        {
            throw new NotSupportedException();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return baseDictionary.Contains(item);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            baseDictionary.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return baseDictionary.Count; }
        }

        public bool IsReadOnly
        {
            get { return true; }
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotSupportedException();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return baseDictionary.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return baseDictionary.GetEnumerator();
        }
    }
}
