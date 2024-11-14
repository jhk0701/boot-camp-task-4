using System;
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

    public event Action<string> OnLoadScene;
    
    void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
        OnLoadScene?.Invoke(scene);
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
