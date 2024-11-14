using System;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int level = 1;
    public int LevelValue
    {
        get => level;
        private set
        {
            if(value <= level) 
                return;

            level = value;
            OnLevelChanged?.Invoke(level);
        }
    }

    [SerializeField] float experience = 0f;
    public float Experience 
    { 
        get => experience;
        private set
        {
            experience = value;

            if (experience >= requiredExperience)
            {
                LevelValue++;
                experience = experience - requiredExperience;
            }
            
            OnExperienceChanged?.Invoke(experience, requiredExperience);
        }
    }
    [SerializeField] float requiredExperience = 100f;
    public float RequiredExperience { get => requiredExperience; }

    public event Action<int> OnLevelChanged;
    public event Action<float, float> OnExperienceChanged;


    public void AddExperience(float amount)
    {
        Experience += amount;
    }
}