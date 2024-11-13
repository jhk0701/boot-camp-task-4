using UnityEngine;

public class UIStageMenu : UIModal
{
    [SerializeField] StageButton stageButton;
    [SerializeField] private Transform container;

    private void Awake()
    {
        for (int i = 0; i < StageManager.Instance.stages.Length; i++)
        {
            StageButton stage = Instantiate(stageButton, container);
            stage.gameObject.SetActive(true);
            stage.Initialize(i, OnStageSelect);
        }    
    }
    
    public override void Initialize()
    {
        // TODO : 시간 날 때, 무한 스크롤로 변경
    }

    void OnStageSelect(int index)
    {
        StageManager.Instance.selectedStageId = index;
        UIManager.Instance.CloseModal(this);
        
        SceneLoader.Instance.LoadGameScene();
    }
}
