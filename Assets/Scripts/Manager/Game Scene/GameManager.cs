using System.Collections;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [field:SerializeField] public Stage currentStage { get; private set; }


    void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        if (sequenceHandler != null)
        {
            StopCoroutine(sequenceHandler);
            sequenceHandler = null;
        }

        sequenceHandler = StartCoroutine(InitializeSequence());
    }

    Coroutine sequenceHandler;
    IEnumerator InitializeSequence()
    {
        // TODO : 로딩창 만들 것
        currentStage = StageManager.Instance.stages[StageManager.Instance.selectedStageId];

        yield return null;

        GameObject playerObject = CharacterManager.Instance.CreatePlayer();

        UIManagerGame.Instance.Initialize();

        CameraManager.Instance.SetTarget(playerObject.transform);
    }
}