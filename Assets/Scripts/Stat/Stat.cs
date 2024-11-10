using System;
using UnityEngine;

[Serializable]
public abstract class Stat
{
    [SerializeField] float _value;
    public virtual float Value { get; protected set; }

    public event Action<float, float> onValueChange;


    public abstract void Add(float amount);
    public abstract void Subtract(float amount);

    protected void CallOnValueChangeEvent(float mainValue, float subValue)
    {
        onValueChange?.Invoke(mainValue, subValue);
    }
}