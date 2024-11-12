using UnityEngine;

public abstract class UIModal : MonoBehaviour
{
    public virtual void Open()
    {
        gameObject.SetActive(true);
        Initialize();
    }

    public virtual void Close()
    {
        gameObject.SetActive(false);
    }

    public abstract void Initialize();
}