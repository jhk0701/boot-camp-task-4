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

    
    private void Start()
    {
        DataManager.Instance.OnSave += Save;
        DataManager.Instance.OnLoadComplete += Initialize;
    }

    public void Initialize()
    {
        level = DataManager.Instance.PlayerData.level;
        experience = DataManager.Instance.PlayerData.experience;
    }

    void Save()
    {
        DataManager.Instance.PlayerData.level = level;
        DataManager.Instance.PlayerData.experience = experience;
    }
    

    public void AddExperience(float amount)
    {
        Experience += amount;
    }
}