using System;
using UnityEngine;

public enum EStatus
{
    Health,
    Stamina,
    Mana,
}

public enum EAbility
{
    Strength,
    Dexterity,
    Defense,
    // Critical,
    // Resistance
}

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