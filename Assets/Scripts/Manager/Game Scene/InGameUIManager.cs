using System;
using UnityEngine;

public class InGameUIManager : Singleton<InGameUIManager>
{

    public void Initialize()
    {
        GameObject canvas = Resources.Load<GameObject>(CustomData.Constants.PATH_IN_GAME_CANVAS);

        Instantiate(canvas);
    }
}