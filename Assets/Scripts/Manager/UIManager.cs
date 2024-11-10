using System;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    const string BASE_PATH = "Prefabs/UI/";
    string playerCanvas = "In Game Canvas";

    public void Initialize()
    {
        GameObject canvas = Resources.Load<GameObject>(String.Concat(BASE_PATH, playerCanvas));

        Instantiate(canvas);
    }
}