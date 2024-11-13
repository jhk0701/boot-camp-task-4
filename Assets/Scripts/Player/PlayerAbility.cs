using UnityEngine;


public class PlayerAbility : MonoBehaviour
{
    public Ability data => DataManager.Instance.Ability;

    public void AddAbility(EAbility type, float amount)
    {
        data.Add(type, amount);
    }

    public void SubtractAbility(EAbility type, float amount)
    {
        data.Subtract(type, amount);
    }

    public float GetValue(EAbility type)
    {
        if (data.ability.TryGetValue(type, out PassiveStat stat))
        {
            return stat.Value / data.applying[type]; // 적용치 적용
        }
        else
            return 0f;
    }

}