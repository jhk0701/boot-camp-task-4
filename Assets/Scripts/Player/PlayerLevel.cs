using System;
using UnityEngine;

// TODO : 플레이어 정보 세이브 & 로드 대상
public class PlayerLevel : MonoBehaviour
{
    [Header("Player Level")]
    [SerializeField] int level = 1;
    public int Level
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
                Level++;
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