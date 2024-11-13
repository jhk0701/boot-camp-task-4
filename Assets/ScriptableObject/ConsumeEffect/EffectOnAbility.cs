
using UnityEngine;

[CreateAssetMenu(fileName = "New Ability Effect", menuName = "ConsumeEffect/New Ability Effect")]
public class EffectOnAbility : ConsumeEffect
{
    public float duration = 30f;
    public EAbility type;
    
    public override void Use()
    {
        
    }

    public override string GetEffectInfo()
    {
        return $"{type.ToString()}: {value}";
    }
}