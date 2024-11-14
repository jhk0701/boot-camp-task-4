using System;
using UnityEngine;
using UnityEngine.UI;

public class UILoading : MonoBehaviour
{
    [SerializeField] private Image loadingBar;
    private void Awake()
    {
        
    }

    public void StartLoading()
    {
        loadingBar.fillAmount = 0f;
    }
}
