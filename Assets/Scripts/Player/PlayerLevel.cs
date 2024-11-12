using System;
using UnityEngine;

// TODO : 플레이어 정보 세이브 & 로드 대상
public class PlayerLevel : MonoBehaviour
{
    [Header("Player Level")]
    [SerializeField] int _level = 1;
    public int Level
    {
        get => _level;
        private set
        {
            if(value <= _level) 
                return;

            _level = value;
            OnLevelChanged?.Invoke(_level);
        }
    }

    [SerializeField] float _experience = 0f;
    public float Experience 
    { 
        get => _experience;
        private set
        {
            _experience = value;

            if (_experience >= _requiredExperience)
            {
                Level++;
                _experience = _experience - _requiredExperience;
            }
            
            OnExperienceChanged?.Invoke(_experience, _requiredExperience);
        }
    }
    [SerializeField] float _requiredExperience = 100f;
    public float RequiredExperience { get => _requiredExperience; }

    public event Action<int> OnLevelChanged;
    public event Action<float, float> OnExperienceChanged;


    public void AddExperience(float amount)
    {
        Experience += amount;
    }
}