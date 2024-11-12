using UnityEngine;
using System.IO;

public class DataManager : Singleton<DataManager>
{
    string savePath;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        savePath = Application.persistentDataPath;
    }

    public void SaveData<T>(T data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(savePath + $"/{typeof(T).ToString()}.txt", json);
    }

    public T LoadData<T>()
    {
        string file = File.ReadAllText(savePath + $"/{typeof(T).ToString()}.txt");
        return JsonUtility.FromJson<T>(file);
    }
}
