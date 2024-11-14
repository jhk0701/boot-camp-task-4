using System.Collections;
using Unity.AI.Navigation;
using UnityEngine;
using System;

public class GameManager : Singleton<GameManager>
{
    [field:SerializeField] public Stage CurrentStage { get; private set; }
    [SerializeField] public ProceduralGenerator mapGenerator;
    
    public event Action OnGameOver;
    
    
    void Awake()
    {
        StartCoroutine(InitializeSequence());
    }

    IEnumerator InitializeSequence()
    {
        // TODO : 로딩창 만들 것
        CurrentStage = StageManager.Instance.stages[StageManager.Instance.selectedStageId];
        
        mapGenerator.Initialize(CurrentStage.mapComponent, CurrentStage.mapSize, CurrentStage.nodeLevel);
        yield return StartCoroutine(mapGenerator.GenerateRoutine());
        
        // TODO : 더 나은 접근 방법 필요
        GetComponent<NavMeshSurface>().BuildNavMesh();
        
        yield return null;
        
        CharacterManager.Instance.SpawnEnemy(CurrentStage);
        
        yield return null;

        GameObject playerObject = CharacterManager.Instance.CreatePlayer();
        CameraManager.Instance.SetTarget(playerObject.transform);

        yield return null;
        
        UIManagerGame.Instance.Initialize();
    }

    public void StageEnd(bool playerIsWin)
    {
        OnGameOver?.Invoke();
        
        if (playerIsWin) //보상 지급
        {
            GiveReward();
        }
        
        UIManagerGame.Instance.OpenClearUI(playerIsWin);

        OnGameOver = null;
    }

    void GiveReward()
    {
        DataManager.Instance.Level.AddExperience(CurrentStage.reward.exp);
        
        DataManager.Instance.Property.Earn(EProperty.Gold, CurrentStage.reward.gold);
        DataManager.Instance.Property.Earn(EProperty.Jewelry, CurrentStage.reward.jewelry);

        for (int i = 0; i < CurrentStage.reward.items.Length; i++)
        {
           DataManager.Instance.Inventory.AddItem(new Item()
           {
               data = CurrentStage.reward.items[i]
           });
        }
    }
}