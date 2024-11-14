using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRegister : MonoBehaviour
{
    private string playerName;
    
    public void OnEndEdit(string name)
    {
        playerName = name;
    }
    
    public void OnClickRegister()
    {
        DataManager.Instance.CreateNewPlayerData(playerName);
        SceneLoader.Instance.LoadMenuScene();
    }
}
