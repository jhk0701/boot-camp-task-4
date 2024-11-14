using UnityEngine;

public abstract class ConsumeEffect :ScriptableObject
{
    public float value;
    
    public abstract void Use();
    public abstract string GetEffectInfo();
}