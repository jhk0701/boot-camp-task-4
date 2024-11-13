
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
        return $"{duration}초 간 {type.ToString()}를 {value}만큼 증가";
    }
}