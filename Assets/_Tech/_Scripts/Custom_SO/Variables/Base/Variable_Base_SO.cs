using System;
using UnityEngine;

public class Variable_Base_SO<T> : ScriptableObject
{
    private T _value = default(T);

    public Action<T> OnChanged;

    public T Value
    {
        set
        {
            _value = value;

            OnChanged?.Invoke(_value);
        }
        get
        {
            return _value;
        }
    }
}
