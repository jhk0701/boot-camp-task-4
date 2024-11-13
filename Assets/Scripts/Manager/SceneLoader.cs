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

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
