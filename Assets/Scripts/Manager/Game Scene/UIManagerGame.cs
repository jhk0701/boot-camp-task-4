using System;
using UnityEngine;

public class UIManagerGame : Singleton<UIManagerGame>
{

    public void Initialize()
    {
        GameObject canvas = Resources.Load<GameObject>(CustomData.Constants.PATH_IN_GAME_CANVAS);

        Instantiate(canvas);
    }
}