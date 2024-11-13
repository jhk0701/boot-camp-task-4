using System;
using UnityEngine;

public class UIManagerGame : Singleton<UIManagerGame>
{
    GameObject inGameCanvas;
    
    public void Initialize()
    {
        GameObject canvas = Resources.Load<GameObject>(CustomData.Constants.PATH_IN_GAME_CANVAS);
        inGameCanvas = Instantiate(canvas);
    }

    public void OpenClearUI(bool playerIsWin)
    {
        UIStageClear uiStageClear = Resources.Load<UIStageClear>(CustomData.Constants.PATH_UI_STAGE_CLEAR);
        uiStageClear = Instantiate(uiStageClear, inGameCanvas.transform);
        uiStageClear.Open(playerIsWin);
    }
}