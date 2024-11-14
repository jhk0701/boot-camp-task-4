using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIStageClear : MonoBehaviour
{
    [SerializeField][TextArea] private string messageOnWin;
    [SerializeField][TextArea] private string messageOnFail;
    [SerializeField] private TextMeshProUGUI messageText;

    public void Open(bool playerIsWin)
    {
        messageText.text = playerIsWin ? messageOnWin : messageOnFail;
    }

    public void OnClickReturn()
    {
        SceneLoader.Instance.LoadMenuScene();
    }
}
