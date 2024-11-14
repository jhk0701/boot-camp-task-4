
using UnityEngine;

[CreateAssetMenu(fileName = "New Status Effect", menuName = "ConsumeEffect/New Status Effect")]
public class EffectOnStatus : ConsumeEffect
{
    public EStatus type;
    
    public override void Use()
    {
        DataManager.Instance.Status.Add(type, value);
    }

    public override string GetEffectInfo()
    {
        return $"{type.ToString()}를 {value}만큼 회복";
    }
}