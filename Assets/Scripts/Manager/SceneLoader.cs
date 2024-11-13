using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : Singleton<SceneLoader>
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    
    public void LoadMenuScene()
    {
        LoadScene(CustomData.Constants.SCENE_MENU);
    }
    public void LoadGameScene()
    {
        LoadScene(CustomData.Constants.SCENE_GAME);
    }
}
