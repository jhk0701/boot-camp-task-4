using UnityEngine;


public class UIManager : Singleton<UIManager>
{
    [SerializeField] GameObject commonCanvas;
    [SerializeField] GameObject modalCanvas;

    [SerializeField] GameObject menuSceneButtons;
    
    public UILoading UILoading { get; set; }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        
        commonCanvas.SetActive(false);
        modalCanvas.SetActive(false);
        
        menuSceneButtons.SetActive(false);
    }

    private void Start()
    {
        SceneLoader.Instance.OnLoadScene += SetUI;
    }


    public void OpenModal(UIModal uiModal)
    {
        if (modalCanvas.activeInHierarchy)
            return;

        modalCanvas.SetActive(true);
        uiModal.Open();
    }

    public void CloseModal(UIModal uiModal)
    {
        modalCanvas.SetActive(false);
        uiModal.Close();
    }

    void SetUI(string sceneName)
    {
        commonCanvas.SetActive(true);
        
        switch (sceneName)
        {
            case CustomData.Constants.SCENE_MENU:
                menuSceneButtons.SetActive(true);
                break;
            case CustomData.Constants.SCENE_GAME:
                menuSceneButtons.SetActive(false);
                break;
        }
    }
}
