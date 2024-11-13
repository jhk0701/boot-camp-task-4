using System.Collections;
using Unity.AI.Navigation;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [field:SerializeField] public Stage CurrentStage { get; private set; }
    [SerializeField] public ProceduralGenerator mapGenerator;
    
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

        UIManagerGame.Instance.Initialize();
    }
}