
using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ability Effect", menuName = "ConsumeEffect/New Ability Effect")]
public class EffectOnAbility : ConsumeEffect
{
    public float duration = 30f;
    public EAbility type;
    
    public override void Use()
    {
        DataManager.Instance.StartCoroutine(AdjustEffect());
    }

    public override string GetEffectInfo()
    {
        return $"{duration}초 간 {type.ToString()}를 {value}만큼 증가";
    }

    IEnumerator AdjustEffect()
    {
        DataManager.Instance.Ability.Add(type, value);
        yield return new WaitForSeconds(duration);
        DataManager.Instance.Ability.Subtract(type, value);
    }
    
}