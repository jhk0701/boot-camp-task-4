
using UnityEngine;

[CreateAssetMenu(fileName = "New Status Effect", menuName = "ConsumeEffect/New Status Effect")]
public class EffectOnStatus : ConsumeEffect
{
    public EStatus type;
    
    public override void Use()
    {
        
    }

    public override string GetEffectInfo()
    {
        return $"{type.ToString()}: {value}";
    }
}