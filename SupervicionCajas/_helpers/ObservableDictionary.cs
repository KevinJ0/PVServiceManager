using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupervicionCajas._helpers;

public class ObservableDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        public  event EventHandler<DictionaryChangedEventArgs<TKey, TValue>> DictionaryChanged;

    public event EventHandler DictionaryCleared;

    public new void Clear()
    {
        base.Clear();
        OnDictionaryCleared();
    }

    protected virtual void OnDictionaryCleared()
    {
        DictionaryCleared?.Invoke(this, EventArgs.Empty);
    }


    public new void Add(TKey key, TValue value)
        {
            base.Add(key, value);
            OnDictionaryChanged(new DictionaryChangedEventArgs<TKey, TValue>(key, value, DictionaryChangedAction.Add));
        }

        public new bool Remove(TKey key)
        {
            if (base.Remove(key))
            {
                OnDictionaryChanged(new DictionaryChangedEventArgs<TKey, TValue>(key, default(TValue), DictionaryChangedAction.Remove));
                return true;
            }
            return false;
        }

        public new TValue this[TKey key]
        {
            get => base[key];
            set
            {
                base[key] = value;
                OnDictionaryChanged(new DictionaryChangedEventArgs<TKey, TValue>(key, value, DictionaryChangedAction.Update));
            }
        }

        protected virtual void OnDictionaryChanged(DictionaryChangedEventArgs<TKey, TValue> e)
        {
            DictionaryChanged?.Invoke(this, e);
        }
    }

    public class DictionaryChangedEventArgs<TKey, TValue> : EventArgs
    {
        public TKey Key { get; }
        public TValue Value { get; }
        public DictionaryChangedAction Action { get; }

        public DictionaryChangedEventArgs(TKey key, TValue value, DictionaryChangedAction action)
        {
            Key = key;
            Value = value;
            Action = action;
        }
    }

    public enum DictionaryChangedAction
    {
        Add,
        Remove,
        Update
    }

