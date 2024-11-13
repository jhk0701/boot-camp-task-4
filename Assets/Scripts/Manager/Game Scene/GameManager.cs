using System.Collections;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [field:SerializeField] public Stage CurrentStage { get; private set; }

    void Awake()
    {
        StartCoroutine(InitializeSequence());
    }

    IEnumerator InitializeSequence()
    {
        // TODO : 로딩창 만들 것
        CurrentStage = StageManager.Instance.stages[StageManager.Instance.selectedStageId];

        CharacterManager.Instance.SpawnEnemy(CurrentStage);
        
        yield return null;

        GameObject playerObject = CharacterManager.Instance.CreatePlayer();
        CameraManager.Instance.SetTarget(playerObject.transform);

        UIManagerGame.Instance.Initialize();
    }
}