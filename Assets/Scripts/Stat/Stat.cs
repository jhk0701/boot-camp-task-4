using System;
using UnityEngine;

[Serializable]
public abstract class Stat
{
    [SerializeField] float _value;
    public virtual float Value 
    {
        get => _value;
        protected set 
        {
            _value = value;
            onValueChanged?.Invoke(value);
        }
    }

    public event Action<float> onValueChanged;

    public abstract void Add(float amount);
    public abstract void Subtract(float amount);
}